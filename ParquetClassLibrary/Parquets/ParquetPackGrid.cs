using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Parquet.Parquets
{
    /// <summary>
    /// A square, two-dimensional collection of <see cref="ParquetPack"/>s for use in <see cref="Maps.MapModel"/> and derived classes.
    /// </summary>
    /// <remarks>
    /// The intent is that this class function much like a read-only array.
    /// </remarks>
    public class ParquetPackGrid : IGrid<ParquetPack>, IReadOnlyGrid<ParquetPack>
    {
        #region Class Defaults
        /// <summary>A value to use in place of uninitialized <see cref="ParquetPackGrid"/>s.</summary>
        public static ParquetPackGrid Empty => new ParquetPackGrid();
        #endregion

        /// <summary>The backing collection of <see cref="ParquetPack"/>s.</summary>
        private readonly ParquetPack[,] ParquetPacks;

        #region Initialization
        /// <summary>
        /// Initializes a new <see cref="ParquetPackGrid"/> with unusable dimensions.
        /// </summary>
        /// <remarks>
        /// For this class, there are no reasonable default values.
        /// However, this version of the constructor exists to make the generic new() constraint happy
        /// and is used in the library in a context where its limitations are understood.
        /// You probably don't want to use this constructor in your own code.
        ///</remarks>
        public ParquetPackGrid()
            : this(0, 0) { }

        /// <summary>
        /// Initializes a new empty <see cref="ParquetPackGrid"/>.
        /// </summary>
        /// <param name="inRowCount">The length of the Y dimension of the collection.</param>
        /// <param name="inColumnCount">The length of the X dimension of the collection.</param>
        public ParquetPackGrid(int inRowCount, int inColumnCount)
        {
            ParquetPacks = new ParquetPack[inRowCount, inColumnCount];
            for (var y = 0; y < inRowCount; y++)
            {
                for (var x = 0; x < inColumnCount; x++)
                {
                    ParquetPacks[y, x] = new ParquetPack();
                }
            }
        }

        /// <summary>
        /// Initializes a new <see cref="ParquetPackGrid"/> from the given 2D <see cref="ParquetPack"/> array.
        /// </summary>
        /// <param name="inParquetPackArray">The array containing the subregion.</param>
        public ParquetPackGrid(ParquetPack[,] inParquetPackArray)
            => ParquetPacks = inParquetPackArray;
        #endregion

        #region IGrid Implementation
        /// <summary>Gets the number of elements in the Y dimension of the <see cref="ParquetPackGrid"/>.</summary>
        public int Rows
            => ParquetPacks?.GetLength(0) ?? 0;

        /// <summary>Gets the number of elements in the X dimension of the <see cref="ParquetPackGrid"/>.</summary>
        public int Columns
            => ParquetPacks?.GetLength(1) ?? 0;

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
                        count += ParquetPacks[y, x]?.Count ?? 0;
                    }
                }

                return count;
            }
        }

        /// <summary>Access to any <see cref="ParquetPack"/> in the grid.</summary>
        public ref ParquetPack this[int y, int x]
            => ref ParquetPacks[y, x];

        /// <summary>
        /// Exposes an <see cref="IEnumerator{ParquetPack}"/>, which supports simple iteration.
        /// </summary>
        /// <remarks>For serialization, this guarantees stable iteration order.</remarks>
        /// <returns>An enumerator.</returns>
        IEnumerator<ParquetPack> IEnumerable<ParquetPack>.GetEnumerator()
            => ParquetPacks.Cast<ParquetPack>().GetEnumerator();

        /// <summary>
        /// Exposes an enumerator for the <see cref="ParquetPackGrid"/>, which supports simple iteration.
        /// </summary>
        /// <remarks>For serialization, this guarantees stable iteration order.</remarks>
        /// <returns>An enumerator.</returns>
        public IEnumerator GetEnumerator()
            => ParquetPacks.GetEnumerator();

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>The new instance.</returns>
        public IGrid<ParquetPack> DeepClone()
        {
            var newInstance = new ParquetPackGrid(Rows, Columns);
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
        /// <summary>Access to any <see cref="ParquetPack"/> in the grid.</summary>
        ParquetPack IReadOnlyGrid<ParquetPack>.this[int y, int x]
            => ParquetPacks[y, x];

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>The new instance.</returns>
        IReadOnlyGrid<ParquetPack> IReadOnlyGrid<ParquetPack>.DeepClone()
            => (IReadOnlyGrid<ParquetPack>)DeepClone();
        #endregion

        #region Utilities
        /// <summary>
        /// Determines if the given position corresponds to a point within the collection.
        /// </summary>
        /// <param name="inPosition">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public bool IsValidPosition(Vector2D inPosition)
            => ParquetPacks.IsValidPosition(inPosition);
        #endregion
    }
}
