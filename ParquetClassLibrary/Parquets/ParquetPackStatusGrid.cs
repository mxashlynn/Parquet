using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Parquet.Parquets
{
    /// <summary>
    /// A square, two-dimensional collection of <see cref="ParquetPackStatus"/>es for use in <see cref="Maps.MapModel"/> and derived classes.
    /// </summary>
    /// <remarks>
    /// The intent is that this class function much like a read-only array.
    /// </remarks>
    public class ParquetPackStatusGrid : IGrid<ParquetPackStatus>, IReadOnlyGrid<ParquetPackStatus>
    {
        #region Class Defaults
        /// <summary>A value to use in place of uninitialized <see cref="ParquetPackStatusGrid"/>s.</summary>
        public static ParquetPackStatusGrid Empty => new ParquetPackStatusGrid();
        #endregion

        /// <summary>The backing collection of <see cref="ParquetPackStatus"/>es.</summary>
        private readonly ParquetPackStatus[,] ParquetStatuses;

        #region Initialization
        /// <summary>
        /// Initializes a new <see cref="ParquetPackStatusGrid"/> with unusable dimensions.
        /// </summary>
        /// <remarks>
        /// For this class, there are no reasonable default values.
        /// However, this version of the constructor exists to make the generic new() constraint happy
        /// and is used in the library in a context where its limitations are understood.
        /// You probably don't want to use this constructor in your own code.
        ///</remarks>
        public ParquetPackStatusGrid()
            : this(0, 0) { }

        /// <summary>
        /// Initializes a new <see cref="ParquetPackStatusGrid"/>.
        /// </summary>
        /// <param name="inRowCount">The length of the Y dimension of the collection.</param>
        /// <param name="inColumnCount">The length of the X dimension of the collection.</param>
        public ParquetPackStatusGrid(int inRowCount, int inColumnCount)
        {
            ParquetStatuses = new ParquetPackStatus[inRowCount, inColumnCount];
            for (var y = 0; y < inRowCount; y++)
            {
                for (var x = 0; x < inColumnCount; x++)
                {
                    ParquetStatuses[y, x] = ParquetPackStatus.Unused.Clone();
                }
            }
        }
        #endregion

        #region IGrid Implementation
        /// <summary>Gets the number of elements in the Y dimension of the <see cref="ParquetPackStatusGrid"/>.</summary>
        public int Rows
            => ParquetStatuses?.GetLength(0) ?? 0;

        /// <summary>Gets the number of elements in the X dimension of the <see cref="ParquetPackStatusGrid"/>.</summary>
        public int Columns
            => ParquetStatuses?.GetLength(1) ?? 0;

        /// <summary>The total number of parquets collected.</summary>
        public int Count
            => Columns * Rows;

        /// <summary>Access to any <see cref="ParquetPackStatus"/> in the grid.</summary>
        public ref ParquetPackStatus this[int y, int x]
            => ref ParquetStatuses[y, x];

        /// <summary>
        /// Exposes an <see cref="IEnumerator{ParquetStatus}"/>, which supports simple iteration.
        /// </summary>
        /// <returns>An enumerator.</returns>
        IEnumerator<ParquetPackStatus> IEnumerable<ParquetPackStatus>.GetEnumerator()
            => ParquetStatuses.Cast<ParquetPackStatus>().GetEnumerator();

        /// <summary>
        /// Exposes an enumerator for the <see cref="ParquetPackStatusGrid"/>, which supports simple iteration.
        /// </summary>
        /// <returns>An enumerator.</returns>
        public IEnumerator GetEnumerator()
            => ParquetStatuses.GetEnumerator();

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>The new instance.</returns>
        public IGrid<ParquetPackStatus> Clone()
        {
            var newInstance = new ParquetPackStatusGrid(Rows, Columns);
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
        /// <summary>Access to any <see cref="ParquetPackStatus"/> in the grid.</summary>
        ParquetPackStatus IReadOnlyGrid<ParquetPackStatus>.this[int y, int x]
            => ParquetStatuses[y, x];

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>The new instance.</returns>
        IReadOnlyGrid<ParquetPackStatus> IReadOnlyGrid<ParquetPackStatus>.Clone()
            => (IReadOnlyGrid<ParquetPackStatus>)Clone();
        #endregion

        #region Utilities
        /// <summary>
        /// Determines if the given position corresponds to a point within the collection.
        /// </summary>
        /// <param name="inPosition">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public bool IsValidPosition(Vector2D inPosition)
            => ((ModelStatus<ParquetPack>[,])ParquetStatuses).IsValidPosition(inPosition);
        #endregion
    }
}
