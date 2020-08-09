using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// A square, two-dimensional collection of <see cref="ParquetStack"/>s for use in <see cref="Maps.MapModel"/> and derived classes.
    /// </summary>
    /// <remarks>
    /// The intent is that this class function much like a read-only array.
    /// </remarks>
    public class ParquetStackGrid : IGrid<ParquetStack>
    {
        #region Class Defaults
        /// <summary>A value to use in place of uninitialized <see cref="ParquetStackGrid"/>s.</summary>
        public static ParquetStackGrid Empty => new ParquetStackGrid();
        #endregion

        /// <summary>The backing collection of <see cref="ParquetStack"/>s.</summary>
        private ParquetStack[,] ParquetStacks { get; }

        #region Initialization
        /// <summary>
        /// Initializes a new <see cref="ParquetStackGrid"/> with unusable dimensions.
        /// </summary>
        /// <remarks>
        /// For this class, there are no reasonable default values.
        /// However, this version of the constructor exists to make the generic new() constraint happy
        /// and is used in the library in a context where its limitations are understood.
        /// You probably don't want to use this constructor in your own code.
        ///</remarks>
        public ParquetStackGrid()
            : this(0, 0) { }

        /// <summary>
        /// Initializes a new empty <see cref="ParquetStackGrid"/>.
        /// </summary>
        /// <param name="inRowCount">The length of the Y dimension of the collection.</param>
        /// <param name="inColumnCount">The length of the X dimension of the collection.</param>
        public ParquetStackGrid(int inRowCount, int inColumnCount)
        {
            ParquetStacks = new ParquetStack[inRowCount, inColumnCount];
            for (var y = 0; y < inRowCount; y++)
            {
                for (var x = 0; x < inColumnCount; x++)
                {
                    ParquetStacks[y, x] = new ParquetStack();
                }
            }
        }

        /// <summary>
        /// Initializes a new <see cref="ParquetStackGrid"/> from the given 2D <see cref="ParquetStack"/> array.
        /// </summary>
        /// <param name="inParquetStackArray">The array containing the subregion.</param>
        public ParquetStackGrid(ParquetStack[,] inParquetStackArray)
            => ParquetStacks = inParquetStackArray;
        #endregion

        #region IGrid Implementation
        /// <summary>Gets the number of elements in the Y dimension of the <see cref="ParquetStackGrid"/>.</summary>
        public int Rows
            => ParquetStacks?.GetLength(0) ?? 0;

        /// <summary>Gets the number of elements in the X dimension of the <see cref="ParquetStackGrid"/>.</summary>
        public int Columns
            => ParquetStacks?.GetLength(1) ?? 0;

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
                        count += ParquetStacks[y, x]?.Count ?? 0;
                    }
                }

                return count;
            }
        }

        /// <summary>Access to any <see cref="ParquetStack"/> in the grid.</summary>
        public ref ParquetStack this[int y, int x]
            => ref ParquetStacks[y, x];

        /// <summary>
        /// Exposes an <see cref="IEnumerator{ParquetStack}"/>, which supports simple iteration.
        /// </summary>
        /// <remarks>For serialization, this guarantees stable iteration order.</remarks>
        /// <returns>An enumerator.</returns>
        IEnumerator<ParquetStack> IEnumerable<ParquetStack>.GetEnumerator()
            => ParquetStacks.Cast<ParquetStack>().GetEnumerator();

        /// <summary>
        /// Exposes an enumerator for the <see cref="ParquetStackGrid"/>, which supports simple iteration.
        /// </summary>
        /// <remarks>For serialization, this guarantees stable iteration order.</remarks>
        /// <returns>An enumerator.</returns>
        public IEnumerator GetEnumerator()
            => ParquetStacks.GetEnumerator();
        #endregion

        #region Utilities
        /// <summary>
        /// Determines if the given position corresponds to a point within the collection.
        /// </summary>
        /// <param name="inPosition">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public bool IsValidPosition(Vector2D inPosition)
            => ParquetStacks.IsValidPosition(inPosition);
        #endregion
    }
}
