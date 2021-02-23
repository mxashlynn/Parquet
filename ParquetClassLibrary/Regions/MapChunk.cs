using System;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Parquet.Parquets;

namespace Parquet.Regions
{
    /// <summary>
    /// Models details of a portion of a <see cref="RegionModel"/>,
    /// either directly composed of parquets or generated from <see cref="ChunkDetail"/>s.
    /// Instances of this class are mutable during play.
    /// </summary>
    public class MapChunk : IEquatable<MapChunk>, ITypeConverter, IDeeplyCloneable<MapChunk>
    {
        #region Class Defaults
        /// <summary>Used to indicate an uninitialized chunk.</summary>
        public static MapChunk Empty { get; } = new MapChunk(false);

        /// <summary>The length of each <see cref="MapChunk"/> dimension in parquets.</summary>
        public const int ParquetsPerChunkDimension = 16;

        /// <summary>The chunk's dimensions in parquets.</summary>
        public Vector2D DimensionsInParquets { get; } = new Vector2D(ParquetsPerChunkDimension,
                                                                     ParquetsPerChunkDimension);
        #endregion

        #region Characteristics
        /// <summary>If <c>true</c>, the <see cref="MapChunk"/> is created at design time instead of procedurally generated.</summary>
        public bool IsFilledOut { get; private set; }

        /// <summary>A description of the type and arrangement of parquets to generate at runtime.</summary>
        public ChunkDetail Details { get; set; }

        /// <summary>Floors and walkable terrain in the chunk.</summary>
        public ParquetModelPackGrid ParquetDefinitions { get; set; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new default instance of the <see cref="ParquetModelPack"/> class.
        /// </summary>
        /// <remarks>This is primarily useful for serialization.</remarks>
        public MapChunk() :
            this(false)
        { }

        /// <summary>
        /// Initializes an instance of the <see cref="MapChunk"/> class.
        /// </summary>
        /// <param name="inIsFilledOut">
        /// If <c>true</c>, the <see cref="MapChunk"/> was either created at design time or
        /// has already been procedurally generated on load in-game.
        /// </param>
        /// <param name="inDetails">Cues to the generation routines if generated at runtime.</param>
        /// <param name="inParquetDefinitions">The definitions of the collected parquets if designed by hand.</param>        
        public MapChunk(bool inIsFilledOut, ChunkDetail inDetails = null,
                        // TODO [MAP EDITOR] [API] Should this accept an IReadOnlyGrid<ParquetPack>s instead?
                        ParquetModelPackGrid inParquetDefinitions = null)
        {
            IsFilledOut = inIsFilledOut;

            if (IsFilledOut)
            {
                Details = ChunkDetail.None;
                ParquetDefinitions = inParquetDefinitions ?? new ParquetModelPackGrid(ParquetsPerChunkDimension, ParquetsPerChunkDimension);
            }
            else
            {
                Details = inDetails ?? ChunkDetail.None;
                ParquetDefinitions = ParquetModelPackGrid.Empty;
            }
        }
        #endregion

        #region Procedural Generation
        /// <summary>
        /// Transforms the current <see cref="MapChunk"/> so that it is ready to be stitched together
        /// with others in its <see cref="MapRegionSketch"/> into a playable <see cref="RegionModel"/>.
        /// </summary>
        /// <remarks>
        /// If a chunk <see cref="IsFilledOut"/>, it is ready to go.
        /// Chunks that are not handmade at design time need to undergo procedural generation based on their <see cref="ChunkDetail"/>s.
        /// </remarks>
        /// <returns>The generated <see cref="MapChunk"/>.</returns>
        public MapChunk Generate()
        {
            // If this chunk has already been generated, no work is needed.
            if (IsFilledOut)
            {
                return this;
            }

            // Create a subregion to hold the generated parquets.
            var newParquetDefinitions = new ParquetModelPackGrid(ParquetsPerChunkDimension, ParquetsPerChunkDimension);

            // TODO [MAP EDITOR] Replace this pass-through implementation.
            #region Pass-Through Implementation
            Details = ChunkDetail.None;
            for (var x = 0; x < ParquetsPerChunkDimension; x++)
            {
                for (var y = 0; y < ParquetsPerChunkDimension; y++)
                {
                    newParquetDefinitions[y, x].FloorID = All.FloorIDs.Minimum;
                }
                newParquetDefinitions[0, x].BlockID = All.BlockIDs.Minimum;
                newParquetDefinitions[ParquetsPerChunkDimension - 1, 1].BlockID = All.BlockIDs.Minimum;
            }
            for (var y = 0; y < ParquetsPerChunkDimension; y++)
            {
                newParquetDefinitions[y, 0].BlockID = All.BlockIDs.Minimum;
                newParquetDefinitions[y, ParquetsPerChunkDimension - 1].BlockID = All.BlockIDs.Minimum;
            }
            newParquetDefinitions[2, 1].FurnishingID = All.FurnishingIDs.Minimum;
            newParquetDefinitions[3, 3].CollectibleID = All.CollectibleIDs.Minimum;
            #endregion

            // Create a new MapChunkModel with the new subregion.
            var newChunk = new MapChunk(true, null, newParquetDefinitions);

            return newChunk;
        }
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="MapChunk"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public override int GetHashCode()
            => (IsFilledOut, Details, ParquetDefinitions).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="MapChunk"/> is equal to the current <see cref="MapChunk"/>.
        /// </summary>
        /// <param name="inStack">The <see cref="MapChunk"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(MapChunk inChunk)
            => inChunk is MapChunk chunk
            && IsFilledOut == chunk.IsFilledOut
            && Details == chunk.Details
            && ParquetDefinitions == chunk.ParquetDefinitions;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="MapChunk"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="MapChunk"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is MapChunk chunk
            && Equals(chunk);

        /// <summary>
        /// Determines whether a specified instance of <see cref="MapChunk"/> is equal to another specified instance of <see cref="MapChunk"/>.
        /// </summary>
        /// <param name="inChunk1">The first <see cref="MapChunk"/> to compare.</param>
        /// <param name="inChunk2">The second <see cref="MapChunk"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(MapChunk inChunk1, MapChunk inChunk2)
            => inChunk1?.Equals(inChunk2) ?? inChunk2?.Equals(inChunk1) ?? true;

        /// <summary>
        /// Determines whether a specified instance of <see cref="MapChunk"/> is not equal to another specified instance of <see cref="MapChunk"/>.
        /// </summary>
        /// <param name="inChunk1">The first <see cref="MapChunk"/> to compare.</param>
        /// <param name="inChunk2">The second <see cref="MapChunk"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(MapChunk inChunk1, MapChunk inChunk2)
            => !(inChunk1 == inChunk2);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static MapChunk ConverterFactory { get; } = Empty;

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => inValue is MapChunk chunk
                ? $"{IsFilledOut}{Delimiters.MapChunkDelimiter}" +
                  $"{chunk.Details.ConvertToString(Details, inRow, inMemberMapData)}{Delimiters.MapChunkDelimiter}" +
                  $"{GridConverter<ParquetModelPack, ParquetModelPackGrid>.ConverterFactory.ConvertToString(ParquetDefinitions, inRow, inMemberMapData)}"
                : Logger.DefaultWithConvertLog(inValue?.ToString() ?? "null", nameof(MapChunk), nameof(Empty));

        /// <summary>
        /// Converts the given <see cref="string"/> to an <see cref="object"/> as deserialization.
        /// </summary>
        /// <param name="inText">The text to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            if (string.IsNullOrEmpty(inText)
                || string.Compare(nameof(Empty), inText, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return Empty;
            }

            var parameterText = inText.Split(Delimiters.MapChunkDelimiter);
            var parsedIsFilledOut = bool.TryParse(parameterText[0], out var tempIsFilledOut)
                ? tempIsFilledOut
                : Logger.DefaultWithParseLog(parameterText[0], nameof(IsFilledOut), false);
            var parsedDetails = (ChunkDetail)ChunkDetail.ConverterFactory.ConvertFromString(parameterText[1], inRow, inMemberMapData);
            var parsedParquetDefinitions = (ParquetModelPackGrid)GridConverter<ParquetModelPack, ParquetModelPackGrid>
                .ConverterFactory
                .ConvertFromString(parameterText[2], inRow, inMemberMapData);

            return new MapChunk(parsedIsFilledOut, parsedDetails, parsedParquetDefinitions);
        }
        #endregion

        #region IDeeplyCloneable Implementation
        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same characteristics as the current instance.</returns>
        public MapChunk DeepClone()
            => new MapChunk(IsFilledOut, Details, ParquetDefinitions);
        #endregion

        #region Utilities
        /// <summary>
        /// The number of parquets within the <see cref="MapChunk"/> whose identity has been determined.
        /// If <see cref="IsFilledOut"/> is <c>false</c>, this will always be <c>0</c>.</summary>
        /// <returns>The total number of parquets collected.</returns>
        public int Count
            => IsFilledOut
                ? ParquetDefinitions.Count
                : 0;

        /// <summary>
        /// Describes the <see cref="MapChunk"/> as a <see cref="string"/> containing basic information.
        /// </summary>
        /// <returns>A <see cref="string"/> that represents the current <see cref="MapChunk"/>.</returns>
        public override string ToString()
            => IsFilledOut
                ? $"{nameof(MapChunk)}: {ParquetDefinitions.Count}"
                : $"{nameof(MapChunk)}: {Details}";
        #endregion
    }

    /// <summary>
    /// Provides extension methods useful when dealing with 2D arrays of <see cref="MapChunk"/>s.
    /// </summary>
    public static class MapChunkArrayExtensions
    {
        /// <summary>
        /// Determines if the given position corresponds to a point within the current array.
        /// </summary>
        /// <param name="inArray">The <see cref="Pack{T}"/> array to validate against.</param>
        /// <param name="inPosition">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public static bool IsValidPosition(this MapChunk[,] inArray, Vector2D inPosition)
            => inArray is not null
            && inPosition.X > -1
            && inPosition.Y > -1
            && inPosition.X < inArray.GetLength(1)
            && inPosition.Y < inArray.GetLength(0);
    }
}
