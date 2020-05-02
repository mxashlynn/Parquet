using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ParquetClassLibrary.Crafts
{
    /// <summary>
    /// A square, two-dimensional collection of <see cref="StrikePanel"/>s for use in <see cref="CraftingRecipe"/>s.
    /// </summary>
    /// <remark>
    /// The intent is that this class function much like a read-only array.
    /// </remark>
    public class StrikePanelGrid : IGrid<StrikePanel>
    {
        #region Class Defaults
        /// <summary>Width of the <see cref="Crafts.StrikePanel"/> pattern in <see cref="Crafts.CraftingRecipe"/>.</summary>
        public const int PanelsPerPatternWidth = 2;

        /// <summary>Height of the <see cref="Crafts.StrikePanel"/> pattern in <see cref="Crafts.CraftingRecipe"/>.</summary>
        public const int PanelsPerPatternHeight = 2;
        #endregion

        /// <summary>The backing collection of <see cref="StrikePanel"/>es.</summary>
        private StrikePanel[,] StrikePanels { get; }

        #region Initialization
        /// <summary>
        /// Initializes a new <see cref="StrikePanelGrid"/> with default dimensions.
        /// </summary>
        public StrikePanelGrid()
            : this(PanelsPerPatternHeight, PanelsPerPatternWidth) { }

        /// <summary>
        /// Initializes a new <see cref="StrikePanelGrid"/>.
        /// </summary>
        /// <param name="inRowCount">The length of the Y dimension of the collection.</param>
        /// <param name="inColumnCount">The length of the X dimension of the collection.</param>
        public StrikePanelGrid(int inRowCount, int inColumnCount)
        {
            // TODO DO we need to check that parameters don't exceed the defaults?  Or are we scrapping the defaults?
            StrikePanels = new StrikePanel[inRowCount, inColumnCount];
            for (var y = 0; y < inRowCount; y++)
            {
                for (var x = 0; x < inColumnCount; x++)
                {
                    StrikePanels[y, x] = StrikePanel.Unused.Clone();
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
            => Columns == 1
            && Rows == 1
            && (StrikePanels[0, 0] == null
                || StrikePanels[0, 0] == StrikePanel.Unused)
                    ? 0
                    : Columns * Rows;

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
