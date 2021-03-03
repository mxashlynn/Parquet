using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Parquet.Regions
{
    /// <summary>
    /// A square, two-dimensional collection of <see cref="MapChunk"/>s.
    /// Instances of this class are mutable during play.
    /// </summary>
    /// <remarks>
    /// The intent is that this class function much like an array.
    /// </remarks>
    public class MapChunkGrid : IGrid<MapChunk>, IReadOnlyGrid<MapChunk>
    {
        #region Class Defaults
        /// <summary>A value to use in place of uninitialized <see cref="MapChunkGrid"/>s.</summary>
        public static MapChunkGrid Empty => new();
        #endregion

        /// <summary>The backing collection of <see cref="MapChunk"/>s.</summary>
        private readonly MapChunk[,] MapChunks;

        #region Initialization
        /// <summary>
        /// Initializes a new <see cref="MapChunkGrid"/> with dimensions determined by <see cref="RegionModel"/>.
        /// </summary>
        public MapChunkGrid()
            : this(RegionModel.ChunksPerRegionDimension, RegionModel.ChunksPerRegionDimension) { }

        /// <summary>
        /// Initializes a new empty <see cref="MapChunkGrid"/>.
        /// </summary>
        /// <param name="inRowCount">The length of the Y dimension of the collection.</param>
        /// <param name="inColumnCount">The length of the X dimension of the collection.</param>
        public MapChunkGrid(int inRowCount, int inColumnCount)
        {
            MapChunks = new MapChunk[inRowCount, inColumnCount];
            for (var y = 0; y < inRowCount; y++)
            {
                for (var x = 0; x < inColumnCount; x++)
                {
                    MapChunks[y, x] = new MapChunk();
                }
            }
        }

        /// <summary>
        /// Initializes a new <see cref="MapChunkGrid"/> from the given 2D <see cref="MapChunk"/> array.
        /// </summary>
        /// <param name="inMapChunkArray">An existing array of MapChunks.</param>
        public MapChunkGrid(MapChunk[,] inMapChunkArray)
            => MapChunks = inMapChunkArray;
        #endregion

        #region IGrid Implementation
        /// <summary>Separates elements within this grid.</summary>
        public string GridDelimiter
            // NOTE Tertiary delimiter is used here because MapChunkGrids embed ParquetModelPackGrids.
            => Delimiters.TertiaryDelimiter;

        /// <summary>Gets the number of elements in the Y dimension of the <see cref="MapChunkGrid"/>.</summary>
        public int Rows
            => MapChunks?.GetLength(0) ?? 0;

        /// <summary>Gets the number of elements in the X dimension of the <see cref="MapChunkGrid"/>.</summary>
        public int Columns
            => MapChunks?.GetLength(1) ?? 0;

        /// <summary>The total number of parquets collected.</summary>
        public int Count
        {
            get
            {
                var count = 0;
                for (var y = 0; y < Rows; y++)
                {
                    for (var x = 0; x < Columns; x++)
                    {
                        count += MapChunks[y, x]?.Count ?? 0;
                    }
                }
                return count;
            }
        }

        /// <summary>Access to any <see cref="MapChunk"/> in the grid.</summary>
        public ref MapChunk this[int y, int x]
            => ref MapChunks[y, x];

        /// <summary>
        /// Exposes an <see cref="IEnumerator{ParquetPack}"/>, which supports simple iteration.
        /// </summary>
        /// <remarks>For serialization, this guarantees stable iteration order.</remarks>
        /// <returns>An enumerator.</returns>
        IEnumerator<MapChunk> IEnumerable<MapChunk>.GetEnumerator()
            => MapChunks.Cast<MapChunk>().GetEnumerator();

        /// <summary>
        /// Exposes an enumerator for the <see cref="MapChunkGrid"/>, which supports simple iteration.
        /// </summary>
        /// <remarks>For serialization, this guarantees stable iteration order.</remarks>
        /// <returns>An enumerator.</returns>
        public IEnumerator GetEnumerator()
            => MapChunks.GetEnumerator();

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>The new instance.</returns>
        public IGrid<MapChunk> DeepClone()
        {
            var newInstance = new MapChunkGrid(Rows, Columns);
            for (var x = 0; x < Columns; x++)
            {
                for (var y = 0; y < Rows; y++)
                {
                    newInstance[y, x] = this[y, x].DeepClone();
                }
            }
            return newInstance;
        }
        #endregion

        #region IReadOnlyGrid Implementation
        /// <summary>Access to any <see cref="MapChunk"/> in the grid.</summary>
        MapChunk IReadOnlyGrid<MapChunk>.this[int y, int x]
            => MapChunks[y, x];

        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same characteristics as the current instance.</returns>
        IReadOnlyGrid<MapChunk> IDeeplyCloneable<IReadOnlyGrid<MapChunk>>.DeepClone()
            => (IReadOnlyGrid<MapChunk>)DeepClone();
        #endregion

        #region Utilities
        /// <summary>
        /// Determines if the given position corresponds to a point within the collection.
        /// </summary>
        /// <param name="inPosition">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public bool IsValidPosition(Point2D inPosition)
            => MapChunks.IsValidPosition(inPosition);
        #endregion
    }
}
