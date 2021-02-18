using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Parquet.Crafts
{
    /// <summary>
    /// A square, two-dimensional collection of <see cref="StrikePanel"/>s for use in <see cref="CraftingRecipe"/>s.
    /// Instances of this class are mutable during play.
    /// </summary>
    /// <remark>
    /// The intent is that this class function much like a read-only array.
    /// </remark>
    public class StrikePanelGrid : IGrid<StrikePanel>, IReadOnlyGrid<StrikePanel>
    {
        #region Class Defaults
        /// <summary>A value to use in place of uninitialized <see cref="StrikePanelGrid"/>s.</summary>
        public static StrikePanelGrid Empty => new StrikePanelGrid(0, 0);

        /// <summary>Width of the <see cref="StrikePanel"/> pattern in <see cref="CraftingRecipe"/>.</summary>
        public const int PanelsPerPatternWidth = 4;

        /// <summary>Height of the <see cref="StrikePanel"/> pattern in <see cref="CraftingRecipe"/>.</summary>
        public const int PanelsPerPatternHeight = 4;
        #endregion

        /// <summary>The backing collection of <see cref="StrikePanel"/>es.</summary>
        private readonly StrikePanel[,] StrikePanels;

        #region Initialization
        /// <summary>
        /// Initializes a new <see cref="StrikePanelGrid"/> with unusable dimensions.
        /// </summary>
        /// <remarks>
        /// For this class, there are no reasonable default values.
        /// However, this version of the constructor exists to make the generic new() constraint happy
        /// and is used in the library in a context where its limitations are understood.
        /// You probably don't want to use this constructor in your own code.
        ///</remarks>
        public StrikePanelGrid()
            : this(0, 0) { }

        /// <summary>
        /// Initializes a new <see cref="StrikePanelGrid"/>.
        /// </summary>
        /// <param name="inRowCount">The length of the Y dimension of the collection.</param>
        /// <param name="inColumnCount">The length of the X dimension of the collection.</param>
        /// <remarks>This constructor supports instance creation via reflection from the <see cref="GridConverter{TElement, TGrid}"/> class.</remarks>
        public StrikePanelGrid(int inRowCount, int inColumnCount)
        {
            StrikePanels = new StrikePanel[inRowCount, inColumnCount];
            for (var y = 0; y < inRowCount; y++)
            {
                for (var x = 0; x < inColumnCount; x++)
                {
                    StrikePanels[y, x] = StrikePanel.Unused.DeepClone();
                }
            }
        }

        /// <summary>
        /// Initializes a new <see cref="StrikePanelGrid"/> similar to the one provided but with the given dimensions.
        /// </summary>
        /// <param name="inContent">An existing <see cref="StrikePanelGrid"/>.</param>
        /// <param name="inRowCount">The length of the Y dimension of the collection.</param>
        /// <param name="inColumnCount">The length of the X dimension of the collection.</param>
        /// <remarks>This constructor supports instance creation via reflection from the <see cref="GridConverter{TElement, TGrid}"/> class.</remarks>
        public StrikePanelGrid(IGrid<StrikePanel> inContent, int inRowCount, int inColumnCount)
        {
            StrikePanels = new StrikePanel[inRowCount, inColumnCount];
            if (inContent is not null)
            {
                for (var y = 0; y < inRowCount; y++)
                {
                    for (var x = 0; x < inColumnCount; x++)
                    {
                        StrikePanels[y, x] = x < inContent.Columns
                                           && y < inContent.Rows
                            ? inContent[y, x].DeepClone()
                            : StrikePanel.Unused.DeepClone();
                    }
                }
            }
        }
        #endregion

        #region IGrid Implementation
        /// <summary>Gets the number of elements in the Y dimension of the <see cref="StrikePanelGrid"/>.</summary>
        public int Rows
            => StrikePanels?.GetLength(0) ?? 0;

        /// <summary>Gets the number of elements in the X dimension of the <see cref="StrikePanelGrid"/>.</summary>
        public int Columns
            => StrikePanels?.GetLength(1) ?? 0;

        /// <summary>The total number of parquets collected.</summary>
        public int Count
            => Columns * Rows;

        /// <summary>Access to any <see cref="StrikePanel"/> in the grid.</summary>
        public ref StrikePanel this[int y, int x]
            => ref StrikePanels[y, x];

        /// <summary>
        /// Exposes an <see cref="IEnumerator{StrikePanel}"/>, which supports simple iteration.
        /// </summary>
        /// <remarks>For serialization, this guarantees stable iteration order.</remarks>
        /// <returns>An enumerator.</returns>
        IEnumerator<StrikePanel> IEnumerable<StrikePanel>.GetEnumerator()
            => StrikePanels.Cast<StrikePanel>().GetEnumerator();

        /// <summary>
        /// Exposes an enumerator for the <see cref="StrikePanelGrid"/>, which supports simple iteration.
        /// </summary>
        /// <remarks>For serialization, this guarantees stable iteration order.</remarks>
        /// <returns>An enumerator.</returns>
        public IEnumerator GetEnumerator()
            => StrikePanels.GetEnumerator();


        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same characteristics as the current instance.</returns>
        public IGrid<StrikePanel> DeepClone()
        {
            var newInstance = new StrikePanelGrid(Rows, Columns);
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
        /// <summary>Access to any <see cref="StrikePanel"/> in the grid.</summary>
        StrikePanel IReadOnlyGrid<StrikePanel>.this[int y, int x]
            => StrikePanels[y, x];

        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same characteristics as the current instance.</returns>
        IReadOnlyGrid<StrikePanel> IDeeplyCloneable<IReadOnlyGrid<StrikePanel>>.DeepClone()
            => (IReadOnlyGrid<StrikePanel>)DeepClone();
        #endregion

        #region Utilities
        /// <summary>
        /// Determines if the given position corresponds to a point within the collection.
        /// </summary>
        /// <param name="inPosition">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public bool IsValidPosition(Vector2D inPosition)
            => StrikePanels.IsValidPosition(inPosition);
        #endregion
    }
}
