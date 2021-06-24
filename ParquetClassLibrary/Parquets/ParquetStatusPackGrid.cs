using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Parquet.Regions;

namespace Parquet.Parquets
{
    /// <summary>
    /// A square, two-dimensional collection of <see cref="ParquetStatusPack"/>es for use in <see cref="RegionModel"/>s.
    /// Instances of this class are mutable during play.
    /// </summary>
    /// <remarks>
    /// The intent is that this class function much like an array.
    /// </remarks>
    public class ParquetStatusPackGrid : IGrid<ParquetStatusPack>, IReadOnlyGrid<ParquetStatusPack>
    {
        #region Class Defaults
        /// <summary>A value to use in place of uninitialized <see cref="ParquetStatusPackGrid"/>s.</summary>
        public static ParquetStatusPackGrid Empty => new();
        #endregion

        /// <summary>The backing collection of <see cref="ParquetStatusPack"/>es.</summary>
        private readonly ParquetStatusPack[,] ParquetStatuses;

        #region Initialization
        /// <summary>
        /// Initializes a new <see cref="ParquetStatusPackGrid"/> with unusable dimensions.
        /// </summary>
        /// <remarks>
        /// For this class, there are no reasonable default values.
        /// However, this version of the constructor exists to make the generic new() constraint happy
        /// and is used in the library in a context where its limitations are understood.
        /// You probably don't want to use this constructor in your own code.
        ///</remarks>
        public ParquetStatusPackGrid()
            : this(0, 0) { }

        /// <summary>
        /// Initializes a new <see cref="ParquetStatusPackGrid"/>.
        /// </summary>
        /// <param name="rowCount">The length of the Y dimension of the collection.</param>
        /// <param name="columnCount">The length of the X dimension of the collection.</param>
        public ParquetStatusPackGrid(int rowCount, int columnCount)
        {
            ParquetStatuses = new ParquetStatusPack[rowCount, columnCount];
            for (var y = 0; y < rowCount; y++)
            {
                for (var x = 0; x < columnCount; x++)
                {
                    ParquetStatuses[y, x] = ParquetStatusPack.Default.DeepClone();
                }
            }
        }

        /// <summary>
        /// Initializes an instance of the <see cref="ParquetStatusPackGrid"/> class
        /// based on a given <see cref="ParquetModelPackGrid"/> instance.
        /// </summary>
        /// <param name="parquetModelPackGrid">The grid of definitions being tracked.</param>
        public ParquetStatusPackGrid(ParquetModelPackGrid parquetModelPackGrid)
        {
            Precondition.IsNotNull(parquetModelPackGrid);
            var nonNullParquetModelPackGrid = parquetModelPackGrid is null
                ? new ParquetModelPackGrid()
                : parquetModelPackGrid;

            ParquetStatuses = new ParquetStatusPack[nonNullParquetModelPackGrid.Rows, nonNullParquetModelPackGrid.Columns];
            for (var y = 0; y < nonNullParquetModelPackGrid.Rows; y++)
            {
                for (var x = 0; x < nonNullParquetModelPackGrid.Columns; x++)
                {
                    if (!nonNullParquetModelPackGrid[y, x].IsEmpty)
                    {
                        ParquetStatuses[y, x] = new ParquetStatusPack(nonNullParquetModelPackGrid[y, x]);
                    }
                }
            }
        }
        #endregion

        #region IGrid Implementation
        /// <summary>Separates elements within this grid.</summary>
        public string GridDelimiter
            => Delimiters.SecondaryDelimiter;

        /// <summary>Gets the number of elements in the Y dimension of the <see cref="ParquetStatusPackGrid"/>.</summary>
        public int Rows
            => ParquetStatuses?.GetLength(0) ?? 0;

        /// <summary>Gets the number of elements in the X dimension of the <see cref="ParquetStatusPackGrid"/>.</summary>
        public int Columns
            => ParquetStatuses?.GetLength(1) ?? 0;

        /// <summary>The total number of parquets collected.</summary>
        public int Count
            => Columns * Rows;

        /// <summary>Access to any <see cref="ParquetStatusPack"/> in the grid.</summary>
        public ref ParquetStatusPack this[int y, int x]
            => ref ParquetStatuses[y, x];

        /// <summary>
        /// Exposes an <see cref="IEnumerator{ParquetStatus}"/>, which supports simple iteration.
        /// </summary>
        /// <returns>An enumerator.</returns>
        IEnumerator<ParquetStatusPack> IEnumerable<ParquetStatusPack>.GetEnumerator()
            => ParquetStatuses.Cast<ParquetStatusPack>().GetEnumerator();

        /// <summary>
        /// Exposes an enumerator for the <see cref="ParquetStatusPackGrid"/>, which supports simple iteration.
        /// </summary>
        /// <returns>An enumerator.</returns>
        public IEnumerator GetEnumerator()
            => ParquetStatuses.GetEnumerator();

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>The new instance.</returns>
        public IGrid<ParquetStatusPack> DeepClone()
        {
            var newInstance = new ParquetStatusPackGrid(Rows, Columns);
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
        /// <summary>Access to any <see cref="ParquetStatusPack"/> in the grid.</summary>
        ParquetStatusPack IReadOnlyGrid<ParquetStatusPack>.this[int y, int x]
            => ParquetStatuses[y, x];

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>The new instance.</returns>
        IReadOnlyGrid<ParquetStatusPack> IDeeplyCloneable<IReadOnlyGrid<ParquetStatusPack>>.DeepClone()
            => (IReadOnlyGrid<ParquetStatusPack>)DeepClone();
        #endregion

        #region Utilities
        /// <summary>
        /// Determines if the given position corresponds to a point within the collection.
        /// </summary>
        /// <param name="position">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public bool IsValidPosition(Point2D position)
            => ParquetStatuses.IsValidPosition(position);
        #endregion
    }
}
