using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ParquetClassLibrary
{
    /// <summary>
    /// A square, two-dimensional collection of <see cref="ModelID"/>s for use in <see cref="ModelID"/>s.
    /// </summary>
    /// <remark>
    /// The intent is that this class function much like a read-only array.
    /// </remark>
    public class ModelIDGrid : IGrid<ModelID>
    {
        #region Class Defaults
        /// <summary>A value to use in place of uninitialized <see cref="ModelIDGrid"/>s.</summary>
        public static ModelIDGrid Empty => new ModelIDGrid();
        #endregion

        /// <summary>The backing collection of <see cref="ModelID"/>es.</summary>
        private ModelID[,] IDs { get; }

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
            : this(0, 0) {}

        /// <summary>
        /// Initializes a new <see cref="ModelID"/>.
        /// </summary>
        /// <param name="inRowCount">The length of the Y dimension of the collection.</param>
        /// <param name="inColumnCount">The length of the X dimension of the collection.</param>
        public ModelIDGrid(int inRowCount, int inColumnCount)
        {
            IDs = new ModelID[inRowCount, inColumnCount];
            for (var y = 0; y < inRowCount; y++)
            {
                for (var x = 0; x < inColumnCount; x++)
                {
                    IDs[y, x] = ModelID.None;
                }
            }
        }
        #endregion

        #region IGrid Implementation
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
        #endregion

        #region Utilities
        /// <summary>
        /// Determines if the given position corresponds to a point within the collection.
        /// </summary>
        /// <param name="inPosition">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public bool IsValidPosition(Vector2D inPosition)
            => IDs.IsValidPosition(inPosition);
        #endregion
    }
}
