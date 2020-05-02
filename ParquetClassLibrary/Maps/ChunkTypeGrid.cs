using System.Collections;
using System.Collections.Generic;

namespace ParquetClassLibrary.Maps
{
    /// <summary>
    /// A pattern for generating a playable <see cref="MapRegion"/>.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming",
        "CA1710:Identifiers should have correct suffix",
        Justification = "Grid is a custom suffix implying Collection.  See https://github.com/dotnet/roslyn-analyzers/issues/3072")]
    public class ChunkTypeGrid : IGrid<ChunkType>
    {
        #region Class Defaults
        /// <summary>The length of each <see cref="ChunkTypeGrid"/> dimension in parquets.</summary>
        public const int ParquetsPerChunkDimension = 16;

        /// <summary>The grid's dimensions in chunks.</summary>
        public static Vector2D DimensionsInChunks { get; } = new Vector2D(MapRegion.ChunksPerRegionDimension,
                                                                          MapRegion.ChunksPerRegionDimension);
        #endregion

        /// <summary>The backing collection of <see cref="ChunkType"/>s.</summary>
        private ChunkType[,] ChunkTypes { get; }

        #region Initialization
        /// <summary>
        /// Initializes a new <see cref="Parquets.ParquetStatusGrid"/> with unusable dimensions.
        /// </summary>
        /// <remarks>
        /// For this class, there are no reasonable default values.
        /// However, this version of the constructor exists to make the generic new() constraint happy
        /// and is used in the library in a context where its limitations are understood.
        /// You probably don't want to use this constructor in your own code.
        ///</remarks>
        public ChunkTypeGrid()
            : this(1, 1) { }

        /// <summary>
        /// Initializes a new <see cref="Parquets.ParquetStatusGrid"/>.
        /// </summary>
        /// <param name="inRowCount">The length of the Y dimension of the collection.</param>
        /// <param name="inColumnCount">The length of the X dimension of the collection.</param>
        public ChunkTypeGrid(int inRowCount, int inColumnCount)
        {
            ChunkTypes = new ChunkType[inRowCount, inColumnCount];
            for (var y = 0; y < inRowCount; y++)
            {
                for (var x = 0; x < inColumnCount; x++)
                {
                    ChunkTypes[y, x] = ChunkType.Empty.Clone();
                }
            }
        }
        #endregion

        #region IGrid Implementation
        /// <summary>Gets the number of elements in the Y dimension of the <see cref="ChunkTypeGrid"/>.</summary>
        public int Rows
            => ChunkTypes?.GetLength(0) ?? 0;

        /// <summary>Gets the number of elements in the X dimension of the <see cref="ChunkTypeGrid"/>.</summary>
        public int Columns
            => ChunkTypes?.GetLength(1) ?? 0;

        /// <summary>The total number of chunks collected.</summary>
        public int Count
            => Columns == 1
            && Rows == 1
            && (ChunkTypes[0, 0] == null
                || ChunkTypes[0, 0] == ChunkType.Empty)
                    ? 0
                    : Columns * Rows;

        /// <summary>Access to any <see cref="Parquets.ParquetStatus"/> in the 2D collection.</summary>
        public ref ChunkType this[int y, int x]
            => ref ChunkTypes[y, x];

        /// <summary>
        /// Exposes an <see cref="IEnumerator{ChunkType}"/>, which supports simple iteration.
        /// </summary>
        /// <remarks>For serialization, this guarantees stable iteration order.</remarks>
        /// <returns>An enumerator.</returns>
        IEnumerator<ChunkType> IEnumerable<ChunkType>.GetEnumerator()
            => (IEnumerator<ChunkType>)ChunkTypes.GetEnumerator();

        /// <summary>
        /// Exposes an enumerator for the <see cref="Parquets.ParquetStatusGrid"/>, which supports simple iteration.
        /// </summary>
        /// <remarks>For serialization, this guarantees stable iteration order.</remarks>
        /// <returns>An enumerator.</returns>
        public IEnumerator GetEnumerator()
            => ChunkTypes.GetEnumerator();
        #endregion

        #region Utilities
        /// <summary>
        /// Determines if the given position corresponds to a point on the grid.
        /// </summary>
        /// <param name="inPosition">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public bool IsValidPosition(Vector2D inPosition)
            => ChunkTypes.IsValidPosition(inPosition);
        #endregion
    }
}
