using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Parquet.Parquets
{
    /// <summary>
    /// A square, two-dimensional collection of <see cref="ParquetStatus"/>es for use in <see cref="Maps.MapModel"/> and derived classes.
    /// </summary>
    /// <remarks>
    /// The intent is that this class function much like a read-only array.
    /// </remarks>
    public class ParquetStatusGrid : IGrid<ParquetStatus>, IReadOnlyGrid<ParquetStatus>
    {
        #region Class Defaults
        /// <summary>A value to use in place of uninitialized <see cref="ParquetStatusGrid"/>s.</summary>
        public static ParquetStatusGrid Empty => new ParquetStatusGrid();
        #endregion

        /// <summary>The backing collection of <see cref="ParquetStatus"/>es.</summary>
        private readonly ParquetStatus[,] ParquetStatuses;

        #region Initialization
        /// <summary>
        /// Initializes a new <see cref="ParquetStatusGrid"/> with unusable dimensions.
        /// </summary>
        /// <remarks>
        /// For this class, there are no reasonable default values.
        /// However, this version of the constructor exists to make the generic new() constraint happy
        /// and is used in the library in a context where its limitations are understood.
        /// You probably don't want to use this constructor in your own code.
        ///</remarks>
        public ParquetStatusGrid()
            : this(0, 0) { }

        /// <summary>
        /// Initializes a new <see cref="ParquetStatusGrid"/>.
        /// </summary>
        /// <param name="inRowCount">The length of the Y dimension of the collection.</param>
        /// <param name="inColumnCount">The length of the X dimension of the collection.</param>
        public ParquetStatusGrid(int inRowCount, int inColumnCount)
        {
            ParquetStatuses = new ParquetStatus[inRowCount, inColumnCount];
            for (var y = 0; y < inRowCount; y++)
            {
                for (var x = 0; x < inColumnCount; x++)
                {
                    ParquetStatuses[y, x] = ParquetStatus.Unused.Clone();
                }
            }
        }
        #endregion

        #region IGrid Implementation
        /// <summary>Gets the number of elements in the Y dimension of the <see cref="ParquetStatusGrid"/>.</summary>
        public int Rows
            => ParquetStatuses?.GetLength(0) ?? 0;

        /// <summary>Gets the number of elements in the X dimension of the <see cref="ParquetStatusGrid"/>.</summary>
        public int Columns
            => ParquetStatuses?.GetLength(1) ?? 0;

        /// <summary>The total number of parquets collected.</summary>
        public int Count
            => Columns * Rows;

        /// <summary>Access to any <see cref="ParquetStatus"/> in the grid.</summary>
        public ref ParquetStatus this[int y, int x]
            => ref ParquetStatuses[y, x];

        /// <summary>
        /// Exposes an <see cref="IEnumerator{ParquetStatus}"/>, which supports simple iteration.
        /// </summary>
        /// <returns>An enumerator.</returns>
        IEnumerator<ParquetStatus> IEnumerable<ParquetStatus>.GetEnumerator()
            => ParquetStatuses.Cast<ParquetStatus>().GetEnumerator();

        /// <summary>
        /// Exposes an enumerator for the <see cref="ParquetStatusGrid"/>, which supports simple iteration.
        /// </summary>
        /// <returns>An enumerator.</returns>
        public IEnumerator GetEnumerator()
            => ParquetStatuses.GetEnumerator();

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>The new instance.</returns>
        public IGrid<ParquetStatus> Clone()
        {
            var newInstance = new ParquetStatusGrid(Rows, Columns);
            for (var x = 0; x < Columns; x++)
            {
                for (var y = 0; y < Rows; y++)
                {
                    newInstance[y, x] = this[y, x].Clone();
                }
            }
            return newInstance;
        }
        #endregion

        #region IReadOnlyGrid Implementation
        /// <summary>Access to any <see cref="ParquetStatus"/> in the grid.</summary>
        ParquetStatus IReadOnlyGrid<ParquetStatus>.this[int y, int x]
            => ParquetStatuses[y, x];

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>The new instance.</returns>
        IReadOnlyGrid<ParquetStatus> IReadOnlyGrid<ParquetStatus>.Clone()
            => (IReadOnlyGrid<ParquetStatus>)Clone();
        #endregion

        #region Utilities
        /// <summary>
        /// Determines if the given position corresponds to a point within the collection.
        /// </summary>
        /// <param name="inPosition">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public bool IsValidPosition(Vector2D inPosition)
            => ParquetStatuses.IsValidPosition(inPosition);
        #endregion
    }
}
