using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Parquet.Properties;

namespace Parquet.Parquets
{
    /// <summary>
    /// A square, two-dimensional collection of <see cref="ParquetModelPack"/>s.
    /// Instances of this class are mutable during play.
    /// </summary>
    /// <remarks>
    /// The intent is that this class function much like an array.
    /// </remarks>
    public class ParquetModelPackGrid : IGrid<ParquetModelPack>, IReadOnlyGrid<ParquetModelPack>
    {
        #region Class Defaults
        /// <summary>A value to use in place of uninitialized <see cref="ParquetModelPackGrid"/>s.</summary>
        public static ParquetModelPackGrid Empty => new();
        #endregion

        /// <summary>The backing collection of <see cref="ParquetModelPack"/>s.</summary>
        private readonly ParquetModelPack[,] ParquetPacks;

        #region Initialization
        /// <summary>
        /// Initializes a new <see cref="ParquetModelPackGrid"/> with unusable dimensions.
        /// </summary>
        /// <remarks>
        /// For this class, there are no reasonable default values.
        /// However, this version of the constructor exists to make the generic new() constraint happy
        /// and is used in the library in a context where its limitations are understood.
        /// You probably don't want to use this constructor in your own code.
        ///</remarks>
        public ParquetModelPackGrid()
            : this(0, 0) { }

        /// <summary>
        /// Initializes a new empty <see cref="ParquetModelPackGrid"/>.
        /// </summary>
        /// <param name="rowCount">The length of the Y dimension of the collection.</param>
        /// <param name="columnCount">The length of the X dimension of the collection.</param>
        public ParquetModelPackGrid(int rowCount, int columnCount)
        {
            ParquetPacks = new ParquetModelPack[rowCount, columnCount];
            for (var y = 0; y < rowCount; y++)
            {
                for (var x = 0; x < columnCount; x++)
                {
                    ParquetPacks[y, x] = new ParquetModelPack();
                }
            }
        }

        /// <summary>
        /// Initializes a new <see cref="ParquetModelPackGrid"/> from the given 2D <see cref="ParquetModelPack"/> array.
        /// </summary>
        /// <param name="parquetPackArray">The array containing the <see cref="ParquetModelPack"/>s.</param>
        public ParquetModelPackGrid(ParquetModelPack[,] parquetPackArray)
            => ParquetPacks = parquetPackArray;
        #endregion

        #region Finding Subgrids
        /// <summary>
        /// Provides all parquet definitions within the current map.
        /// </summary>
        /// <returns>The entire map as a subgrid.</returns>
        public IReadOnlyGrid<ParquetModelPack> GetSubgrid()
            => GetSubgrid(Point2D.Origin, new Point2D(ParquetPacks.GetLength(1) - 1, ParquetPacks.GetLength(0) - 1));

        /// <summary>
        /// Provides all parquet definitions within the specified rectangular subsection of the current grid.
        /// </summary>
        /// <param name="upperLeft">The position of the upper-leftmost corner of the subgrid.</param>
        /// <param name="lowerRight">The position of the lower-rightmost corner of the subgrid.</param>
        /// <returns>A portion of the grid.</returns>
        /// <remarks>If the coordinates given are not well-formed, the subgrid returned will be invalid.</remarks>
        public IReadOnlyGrid<ParquetModelPack> GetSubgrid(Point2D upperLeft, Point2D lowerRight)
        {
            if (!ParquetPacks.IsValidPosition(upperLeft))
            {
                Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.ErrorInvalidPosition,
                                                           nameof(upperLeft), nameof(ParquetPacks)));
            }
            else if (!ParquetPacks.IsValidPosition(lowerRight))
            {
                Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.ErrorInvalidPosition,
                                                           nameof(lowerRight), nameof(ParquetPacks)));
            }
            else if (lowerRight.X < upperLeft.X || lowerRight.Y < upperLeft.Y)
            {
                Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.ErrorOutOfOrderGTE,
                                                           nameof(lowerRight), lowerRight, upperLeft));
            }
            else
            {
                var subgrid = new ParquetModelPack[lowerRight.X - upperLeft.X + 1,
                                                     lowerRight.Y - upperLeft.Y + 1];

                for (var x = upperLeft.X; x <= lowerRight.X; x++)
                {
                    for (var y = upperLeft.Y; y <= lowerRight.Y; y++)
                    {
                        subgrid[y - upperLeft.Y, x - upperLeft.X] = ParquetPacks[y, x];
                    }
                }

                return new ParquetModelPackGrid(subgrid);
            }

            return new ParquetModelPackGrid();
        }
        #endregion

        #region IGrid Implementation
        /// <summary>Separates elements within this grid.</summary>
        public string GridDelimiter
            => Delimiters.SecondaryDelimiter;

        /// <summary>Gets the number of elements in the Y dimension of the <see cref="ParquetModelPackGrid"/>.</summary>
        public int Rows
            => ParquetPacks?.GetLength(0) ?? 0;

        /// <summary>Gets the number of elements in the X dimension of the <see cref="ParquetModelPackGrid"/>.</summary>
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

        /// <summary>Access to any <see cref="ParquetModelPack"/> in the grid.</summary>
        public ref ParquetModelPack this[int y, int x]
            => ref ParquetPacks[y, x];

        /// <summary>
        /// Exposes an <see cref="IEnumerator{ParquetPack}"/>, which supports simple iteration.
        /// </summary>
        /// <remarks>For serialization, this guarantees stable iteration order.</remarks>
        /// <returns>An enumerator.</returns>
        IEnumerator<ParquetModelPack> IEnumerable<ParquetModelPack>.GetEnumerator()
            => ParquetPacks.Cast<ParquetModelPack>().GetEnumerator();

        /// <summary>
        /// Exposes an enumerator for the <see cref="ParquetModelPackGrid"/>, which supports simple iteration.
        /// </summary>
        /// <remarks>For serialization, this guarantees stable iteration order.</remarks>
        /// <returns>An enumerator.</returns>
        public IEnumerator GetEnumerator()
            => ParquetPacks.GetEnumerator();

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>The new instance.</returns>
        public IGrid<ParquetModelPack> DeepClone()
        {
            var newInstance = new ParquetModelPackGrid(Rows, Columns);
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
        /// <summary>Access to any <see cref="ParquetModelPack"/> in the grid.</summary>
        ParquetModelPack IReadOnlyGrid<ParquetModelPack>.this[int y, int x]
            => ParquetPacks[y, x];

        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same characteristics as the current instance.</returns>
        IReadOnlyGrid<ParquetModelPack> IDeeplyCloneable<IReadOnlyGrid<ParquetModelPack>>.DeepClone()
            => (IReadOnlyGrid<ParquetModelPack>)DeepClone();
        #endregion

        #region Utilities
        /// <summary>
        /// Determines if the given position corresponds to a point within the collection.
        /// </summary>
        /// <param name="position">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public bool IsValidPosition(Point2D position)
            => ParquetPacks.IsValidPosition(position);
        #endregion
    }
}
