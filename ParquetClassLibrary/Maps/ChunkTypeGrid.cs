using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Maps
{
    /// <summary>
    /// A pattern for generating a playable <see cref="MapRegion"/> in sandbox.
    /// </summary>
    /// <remarks>
    /// Regions in the editor are stored as <see cref="ChunkTypeGrid"/>s before being fleshed out on load in-game.
    /// </remarks>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming",
        "CA1710:Identifiers should have correct suffix",
        Justification = "Grid is a custom suffix implying Collection.  See https://github.com/dotnet/roslyn-analyzers/issues/3072")]
    public class ChunkTypeGrid : IGrid<ChunkType>
    {
        #region Class Defaults
        /// <summary>Used to indicate an empty grid.</summary>
        public static readonly ChunkTypeGrid Empty = new ChunkTypeGrid();

        /// <summary>The grid's dimensions in chunks.</summary>
        public static Vector2D DimensionsInChunks { get; } = new Vector2D(Rules.Dimensions.ChunksPerRegion, Rules.Dimensions.ChunksPerRegion);
        #endregion

        #region Whole-Region Characteristics
        /// <summary>
        /// Describes the version of serialized data.
        /// Allows selecting data files that can be successfully deserialized.
        /// </summary>
        // TODO We should be validating against this.
        public string DataVersion { get; } = AssemblyInfo.SupportedMapDataVersion;

        /// <summary>The identifier for the region that this grid will generate.</summary>
        public EntityID RegionID { get; set; }

        /// <summary>What the region that this grid generates will be called in-game.</summary>
        public string Title { get; set; }

        /// <summary>A color to display in any empty areas of the region that this grid will generate.</summary>
        public string Background { get; set; }

        /// <summary>The region's elevation relative to all other regions.</summary>
        public int GlobalElevation { get; set; }
        #endregion

        /// <summary>The backing collection of <see cref="ChunkType"/>s.</summary>
        private ChunkType[,] ChunkTypes { get; }

        #region Initialization
        /// <summary>
        /// Initializes a new empty <see cref="ChunkTypeGrid"/> with default values.
        /// </summary>
        public ChunkTypeGrid()
            : this(EntityID.None, MapRegion.DefaultTitle, MapRegion.DefaultColor,
                   MapRegion.DefaultGlobalElevation, new ChunkType[DimensionsInChunks.Y, DimensionsInChunks.X]) { }

        /// <summary>
        /// Constructs a new instance of the <see cref="MapChunk"/> class.
        /// </summary>
        /// <param name="inID">A pre-existing RegionID; if null, the ID is set to <see cref="EntityID.None"/>.</param>
        /// <param name="inTitle">The name of the new region.</param>
        /// <param name="inBackground">Background color for the new region.</param>
        /// <param name="inGlobalElevation">The relative elevation of this region expressed as a signed integer.</param>
        /// <param name="inChunkTypeArray">The array containing the subregion.</param>
        public ChunkTypeGrid(EntityID inID, string inTitle, string inBackground, int inGlobalElevation, ChunkType[,] inChunkTypeArray)
        {
            Precondition.IsInRange(inID, All.MapRegionIDs, nameof(inID));

            RegionID = inID;
            Title = inTitle;
            Background = inBackground;
            GlobalElevation = inGlobalElevation;
            ChunkTypes = inChunkTypeArray;
        }
        #endregion

        #region IGrid Implementation
        /// <summary>Gets the number of elements in the Y dimension of the <see cref="ParquetStackGrid"/>.</summary>
        public int Rows => DimensionsInChunks.Y;

        /// <summary>Gets the number of elements in the X dimension of the <see cref="ParquetStackGrid"/>.</summary>
        public int Columns => DimensionsInChunks.X;

        /// <summary>The total number of chunks collected.</summary>
        public int Count => Rows * Columns;

        /// <summary>Access to any <see cref="ParquetStatus"/> in the 2D collection.</summary>
        public ref ChunkType this[int y, int x]
        {
            get => ref ChunkTypes[y, x];
        }

        /// <summary>
        /// Exposes an <see cref="IEnumerator{ChunkType}"/>, which supports simple iteration.
        /// </summary>
        /// <remarks>For serialization, this guarantees stable iteration order.</remarks>
        /// <returns>An enumerator.</returns>
        IEnumerator<ChunkType> IEnumerable<ChunkType>.GetEnumerator()
            => (IEnumerator<ChunkType>)ChunkTypes.GetEnumerator();

        /// <summary>
        /// Exposes an enumerator for the <see cref="ParquetStatusGrid"/>, which supports simple iteration.
        /// </summary>
        /// <remarks>For serialization, this guarantees stable iteration order.</remarks>
        /// <returns>An enumerator.</returns>
        public IEnumerator GetEnumerator()
            => ChunkTypes.GetEnumerator();
        #endregion

        #region Self Serialization
        /// <summary>
        /// Reads all records of the given type from the appropriate file.
        /// </summary>
        /// <returns>The instances read.</returns>
        public static HashSet<ChunkTypeGrid> GetRecords()
        {
            using var reader = new StreamReader($"{All.WorkingDirectory}/{nameof(ChunkTypeGrid)}s.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Configuration.TypeConverterOptionsCache.AddOptions(typeof(EntityID), All.IdentifierOptions);
            csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.StartsWith("in", StringComparison.InvariantCulture)
                                                                                        ? header.Substring(2).ToUpperInvariant()
                                                                                        : header.ToUpperInvariant();
            csv.Configuration.RegisterClassMap<ChunkTypeGridClassMap>();
            foreach (var kvp in All.ConversionConverters)
            {
                csv.Configuration.TypeConverterCache.AddConverter(kvp.Key, kvp.Value);
            }

            return new HashSet<ChunkTypeGrid>(csv.GetRecords<ChunkTypeGridShim>().Select(shim => shim.ToGrid()));
        }

        /// <summary>
        /// Writes all of the given type to records to the appropriate file.
        /// </summary>
        internal void PutRecords(IEnumerable<ChunkTypeGrid> inGrids)
        {
            using var writer = new StreamWriter($"{All.WorkingDirectory}/{nameof(ChunkTypeGrid)}s.csv");
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.Configuration.TypeConverterOptionsCache.AddOptions(typeof(EntityID), All.IdentifierOptions);
            foreach (var kvp in All.ConversionConverters)
            {
                csv.Configuration.TypeConverterCache.AddConverter(kvp.Key, kvp.Value);
            }

            csv.WriteHeader<ChunkTypeGrid>();
            csv.NextRecord();
            csv.WriteRecords(inGrids);
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Determines if the given position corresponds to a point on the grid.
        /// </summary>
        /// <param name="inPosition">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public bool IsValidPosition(Vector2D inPosition)
            => ChunkTypes.IsValidPosition(inPosition);

        /// <summary>
        /// Describes the <see cref="ChunkTypeGrid"/>'s basic information.
        /// </summary>
        /// <returns>A <see langword="string"/> that represents the current <see cref="ChunkTypeGrid"/>.</returns>
        public override string ToString()
            => $"Chunk Grid {Title} is ({Background}) at {GlobalElevation}.";
        #endregion
    }

    #region Serialization Helper Classes
    /// <summary>
    /// Maps the values in a <see cref="ChunkTypeGrid"/> to records that CSVHelper recognizes.
    /// </summary>
    internal sealed class ChunkTypeGridClassMap : ClassMap<ChunkTypeGridShim>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BiomeClassMap"/> class.
        /// </summary>
        public ChunkTypeGridClassMap()
        {
            // Properties are ordered by index to facilitate a logical layout in spreadsheet apps.
            Map(m => m.ID).Index(0);
            Map(m => m.Title).Index(1);
            Map(m => m.Background).Index(2);
            Map(m => m.GlobalElevation).Index(3);
            Map(m => m.ChunkTypeArray).Index(4);
        }
    }

    /// <summary>
    /// Provides a <see cref="ChunkTypeGrid"/>-like object that can be easily serialized.
    /// </summary>
    internal class ChunkTypeGridShim : ITypeConverter
    {
        /// <summary>The identifier for the region that this grid will generate.</summary>
        internal EntityID ID;

        /// <summary>What the region that this grid generates will be called in-game.</summary>
        internal string Title;

        /// <summary>A color to display in any empty areas of the region that this grid will generate.</summary>
        internal string Background;

        /// <summary>The region's elevation relative to all other regions.</summary>
        internal int GlobalElevation;

        /// <summary>The backing collection of <see cref="ChunkType"/>s.</summary>
        internal ChunkType[,] ChunkTypeArray;

        /// <summary>
        /// Converts a <see cref="ChunkTypeGridShim"/> into a <see cref="ChunkTypeGrid"/>.
        /// </summary>
        /// <returns>A <see cref="ChunkTypeGrid"/>.</returns>
        public ChunkTypeGrid ToGrid()
            => new ChunkTypeGrid(ID, Title, Background, GlobalElevation, ChunkTypeArray);

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static ChunkTypeGridShim ConverterFactory { get; } = new ChunkTypeGridShim();

        /// <summary>
        /// Converts the given <see langword="string"/> to a <see cref="StrikePanel"/>.
        /// </summary>
        /// <param name="inText">The <see langword="string"/> to convert to an object.</param>
        /// <param name="inRow">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="inMemberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
        /// <returns>The <see cref="StrikePanel"/> created from the <see langword="string"/>.</returns>
        public object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            try
            {
                var numberStyle = inMemberMapData?.TypeConverterOptions?.NumberStyle ?? All.SerializedNumberStyle;
                var cultureInfo = inMemberMapData?.TypeConverterOptions?.CultureInfo ?? All.SerializedCultureInfo;
                var splitText = inText.Split(inRow.Configuration.Delimiter);

                var id = (EntityID)EntityID.ConverterFactory.ConvertFromString(splitText[0], inRow, inMemberMapData);
                var title = splitText[1];
                var background = splitText[2];
                var globalElevation = int.Parse(splitText[3], numberStyle, cultureInfo);
                var chunkArray = GridConverter<ChunkType, ChunkTypeGrid>.ConverterFactory.ConvertFromString(splitText[4], inRow, inMemberMapData);

                // HERE -- I feel like this approach to serialization for ChunkTypeGrids is hopelessly tangled -- rethinkg this from square 1.

                return new ChunkTypeGrid(id, title, background, globalElevation, chunkArray);
            }
            catch (Exception e)
            {
                throw new FormatException($"Could not parse '{inText}' as {nameof(ChunkTypeGrid)}: {e}", e);
            }
        }

        /// <summary>
        /// Converts the given <see cref="EntityTag"/> to a record column.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="inMemberMapData">The <see cref="MemberMapData"/> for the member being serialized.</param>
        /// <returns>The <see cref="StrikePanel"/> as a CSV record.</returns>
        public string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => inValue == None || string.IsNullOrEmpty((string)inValue)
                ? nameof(None)
                : (string)inValue;
        #endregion
    }
}
#endregion
