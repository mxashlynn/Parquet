using System.Collections;
using System.Collections.Generic;

namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// A square, two-dimensional collection of <see cref="ParquetStack"/>s for use in <see cref="MapParent"/> and derived classes.
    /// </summary>
    /// <remarks>
    /// The intent is that this class function much like a read-only array.
    /// </remarks>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming",
        "CA1710:Identifiers should have correct suffix",
        Justification = "Grid is a custom suffix implying Collection.  See https://github.com/dotnet/roslyn-analyzers/issues/3072")]
    public class ParquetStackGrid : IGrid<ParquetStack>
    {
        /// <summary>The backing collection of <see cref="ParquetStack"/>s.</summary>
        private ParquetStack[,] ParquetStacks { get; }

        /// <summary>Gets the number of elements in the Y dimension of the <see cref="ParquetStackGrid"/>.</summary>
        public int Rows => ParquetStacks?.GetLength(0) ?? 0;

        /// <summary>Gets the number of elements in the X dimension of the <see cref="ParquetStackGrid"/>.</summary>
        public int Columns => ParquetStacks?.GetLength(1) ?? 0;

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
                        count += ParquetStacks[y, x].Count;
                    }
                }

                return count;
            }
        }

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
            : this(1, 1) { }

        /// <summary>
        /// Initializes a new empty <see cref="ParquetStackGrid"/>.
        /// </summary>
        /// <param name="inRows">The length of the Y dimension of the collection.</param>
        /// <param name="inColumns">The length of the X dimension of the collection.</param>
        public ParquetStackGrid(int inRows, int inColumns)
            => ParquetStacks = new ParquetStack[inRows, inColumns];

        /// <summary>
        /// Initializes a new <see cref="ParquetStackGrid"/> from the given 2D <see cref="ParquetStack"/> array.
        /// </summary>
        /// <param name="inParquetStackArray">The array containing the subregion.</param>
        public ParquetStackGrid(ParquetStack[,] inParquetStackArray)
        {
            ParquetStacks = inParquetStackArray;
        }
        #endregion

        /// <summary>
        /// Determines if the given position corresponds to a point within the collection.
        /// </summary>
        /// <param name="inPosition">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public bool IsValidPosition(Vector2D inPosition)
            => ParquetStacks.IsValidPosition(inPosition);

        /// <summary>Access to any <see cref="ParquetStack"/> in the grid.</summary>
        public ref ParquetStack this[int y, int x]
        {
            get => ref ParquetStacks[y, x];
        }

        /// <summary>
        /// Exposes an <see cref="IEnumerator{ParquetStack}"/>, which supports simple iteration.
        /// </summary>
        /// <remarks>For serialization, this guarantees stable iteration order.</remarks>
        /// <returns>An enumerator.</returns>
        IEnumerator<ParquetStack> IEnumerable<ParquetStack>.GetEnumerator()
            => (IEnumerator<ParquetStack>)ParquetStacks.GetEnumerator();

        /// <summary>
        /// Exposes an enumerator for the <see cref="ParquetStackGrid"/>, which supports simple iteration.
        /// </summary>
        /// <remarks>For serialization, this guarantees stable iteration order.</remarks>
        /// <returns>An enumerator.</returns>
        public IEnumerator GetEnumerator()
            => ParquetStacks.GetEnumerator();
    }
}
