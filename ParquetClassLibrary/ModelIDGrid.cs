using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Parquet
{
    /// <summary>
    /// A square, two-dimensional collection of <see cref="ModelID"/>s for use in <see cref="ModelID"/>s.
    /// Instances of this class are mutable during play.
    /// </summary>
    /// <remark>
    /// The intent is that this class function much like an array.
    /// </remark>
    public class ModelIDGrid : IGrid<ModelID>, IReadOnlyGrid<ModelID>
    {
        #region Class Defaults
        /// <summary>A value to use in place of uninitialized <see cref="ModelIDGrid"/>s.</summary>
        public static ModelIDGrid Empty => new();
        #endregion

        /// <summary>The backing collection of <see cref="ModelID"/>es.</summary>
        private readonly ModelID[,] IDs;

        #region Initialization
        /// <summary>
        /// Initializes an empty <see cref="ModelID"/> with unusable dimensions.
        /// </summary>
        /// <remarks>
        /// For this class, there are no reasonable default values.
        /// However, this version of the constructor exists to make the generic new() constraint happy
        /// and is used in the library in a context where its limitations are understood.
        /// You probably don't want to use this constructor in your own code.
        ///</remarks>
        public ModelIDGrid()
            : this(0, 0) { }

        /// <summary>
        /// Initializes a new <see cref="ModelID"/>.
        /// </summary>
        /// <param name="rowCount">The length of the Y dimension of the collection.</param>
        /// <param name="columnCount">The length of the X dimension of the collection.</param>
        public ModelIDGrid(int rowCount, int columnCount)
        {
            IDs = new ModelID[rowCount, columnCount];
            for (var y = 0; y < rowCount; y++)
            {
                for (var x = 0; x < columnCount; x++)
                {
                    IDs[y, x] = ModelID.None;
                }
            }
        }
        #endregion

        #region IGrid Implementation
        /// <summary>Separates elements within this grid.</summary>
        public string GridDelimiter
            => Delimiters.SecondaryDelimiter;

        /// <summary>Gets the number of elements in the Y dimension of an array of <see cref="ModelID"/>.</summary>
        public int Rows
            => IDs?.GetLength(0) ?? 0;

        /// <summary>Gets the number of elements in the X dimension of an array of <see cref="ModelID"/>.</summary>
        public int Columns
            => IDs?.GetLength(1) ?? 0;

        /// <summary>The total number of <see cref="ModelID"/>s collected.</summary>
        public int Count
            => Columns * Rows;

        /// <summary>Access to any <see cref="ModelID"/> in the grid.</summary>
        public ref ModelID this[int y, int x]
            => ref IDs[y, x];

        /// <summary>
        /// Exposes an <see cref="IEnumerator{ModelID}"/>, which supports simple iteration.
        /// </summary>
        /// <remarks>For serialization, this guarantees stable iteration order.</remarks>
        /// <returns>An enumerator.</returns>
        IEnumerator<ModelID> IEnumerable<ModelID>.GetEnumerator()
            => IDs.Cast<ModelID>().GetEnumerator();

        /// <summary>
        /// Exposes an enumerator for the <see cref="ModelID"/>, which supports simple iteration.
        /// </summary>
        /// <remarks>For serialization, this guarantees stable iteration order.</remarks>
        /// <returns>An enumerator.</returns>
        public IEnumerator GetEnumerator()
            => IDs.GetEnumerator();

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>The new instance.</returns>
        public IGrid<ModelID> DeepClone()
        {
            var newInstance = new ModelIDGrid(Rows, Columns);
            for (var x = 0; x < Columns; x++)
            {
                for (var y = 0; y < Rows; y++)
                {
                    newInstance[y, x] = this[y, x];
                }
            }
            return newInstance;
        }
        #endregion

        #region IReadOnlyGrid Implementation
        /// <summary>Access to any <see cref="ModelID"/> in the grid.</summary>
        ModelID IReadOnlyGrid<ModelID>.this[int y, int x]
            => IDs[y, x];

        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same characteristics as the current instance.</returns>
        IReadOnlyGrid<ModelID> IDeeplyCloneable<IReadOnlyGrid<ModelID>>.DeepClone()
            => (IReadOnlyGrid<ModelID>)DeepClone();
        #endregion

        #region Utilities
        /// <summary>
        /// Determines if the given position corresponds to a point within the collection.
        /// </summary>
        /// <param name="position">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public bool IsValidPosition(Point2D position)
            => IDs.IsValidPosition(position);
        #endregion
    }
}
