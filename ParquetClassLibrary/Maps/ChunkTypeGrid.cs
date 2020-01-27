using System.Collections;
using System.Collections.Generic;
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
        /// <summary>Used to indicate an empty grid.</summary>
        public static readonly ChunkTypeGrid Empty = new ChunkTypeGrid();

        #region Class Defaults
        /// <summary>The grid's dimensions in chunks.</summary>
        public static Vector2D DimensionsInChunks { get; } = new Vector2D(Rules.Dimensions.ChunksPerRegion,
                                                                          Rules.Dimensions.ChunksPerRegion);
        #endregion

        #region Whole-Region Characteristics
        /// <summary>
        /// Describes the version of serialized data.
        /// Allows selecting data files that can be successfully deserialized.
        /// </summary>
        public string DataVersion { get; } = AssemblyInfo.SupportedMapDataVersion;

        /// <summary>The identifier for the region that this grid will generate.</summary>
        public EntityID RegionID { get; set; }

        /// <summary>What the region that this grid generates will be called in-game.</summary>
        public string Title { get; set; }

        /// <summary>A color to display in any empty areas of the region that this grid will generate.</summary>
        public PCLColor Background { get; set; }

        /// <summary>The region's elevation relative to all other regions.</summary>
        public int GlobalElevation { get; set; }
        #endregion

        #region Grid Contents
        /// <summary>The types of chunks which make up the grid.</summary>
        private readonly ChunkType[,] chunkTypes = new ChunkType[DimensionsInChunks.Y, DimensionsInChunks.X];

        /// <summary>Gets the number of elements in the Y dimension of the <see cref="ParquetStackGrid"/>.</summary>
        public int Rows => DimensionsInChunks.Y;

        /// <summary>Gets the number of elements in the X dimension of the <see cref="ParquetStackGrid"/>.</summary>
        public int Columns => DimensionsInChunks.X;

        /// <summary>The total number of chunks collected.</summary>
        public int Count => Rows * Columns;
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new <see cref="ChunkTypeGrid"/> with default values.
        /// </summary>
        public ChunkTypeGrid()
            // This version of the constructor exists to make the generic new() constraint happy.
            : this(null, null, null, MapRegion.DefaultGlobalElevation) { }

        /// <summary>
        /// Constructs a new instance of the <see cref="MapChunk"/> class.
        /// </summary>
        /// <param name="inID">A pre-existing RegionID; if null, the ID is set to <see cref="EntityID.None"/>.</param>
        /// <param name="inTitle">The name of the new region.</param>
        /// <param name="inBackground">Background color for the new region.</param>
        /// <param name="inGlobalElevation">The relative elevation of this region expressed as a signed integer.</param>
        public ChunkTypeGrid(EntityID? inID = null, string inTitle = null, PCLColor? inBackground = null,
                            int inGlobalElevation = MapRegion.DefaultGlobalElevation)
        {
            RegionID = inID ?? EntityID.None;
            Title = string.IsNullOrEmpty(inTitle)
                ? MapRegion.DefaultTitle
                : inTitle;
            Background = inBackground ?? MapRegion.DefaultColor;
            GlobalElevation = inGlobalElevation;
        }
        #endregion

        #region Collection Access
        /// <summary>Access to any <see cref="ParquetStatus"/> in the 2D collection.</summary>
        public ref ChunkType this[int y, int x]
        {
            get => ref chunkTypes[y, x];
        }

        /// <summary>
        /// Exposes an <see cref="IEnumerator{ChunkType}"/>, which supports simple iteration.
        /// </summary>
        /// <returns>An enumerator.</returns>
        IEnumerator<ChunkType> IEnumerable<ChunkType>.GetEnumerator()
            => (IEnumerator<ChunkType>)chunkTypes.GetEnumerator();

        /// <summary>
        /// Exposes an enumerator for the <see cref="ParquetStatusGrid"/>, which supports simple iteration.
        /// </summary>
        /// <returns>An enumerator.</returns>
        public IEnumerator GetEnumerator()
            => chunkTypes.GetEnumerator();
        #endregion

        #region Utilities
        /// <summary>
        /// Determines if the given position corresponds to a point on the grid.
        /// </summary>
        /// <param name="inPosition">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public bool IsValidPosition(Vector2D inPosition)
            => chunkTypes.IsValidPosition(inPosition);

        /// <summary>
        /// Describes the <see cref="ChunkTypeGrid"/>'s basic information.
        /// </summary>
        /// <returns>A <see langword="string"/> that represents the current <see cref="ChunkTypeGrid"/>.</returns>
        public override string ToString()
            => $"Chunk Grid {Title} is ({Background}) at {GlobalElevation}.";
        #endregion
    }
}
