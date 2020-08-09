using System;
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
        /// <summary>A value to use in place of uninitialized <see cref="StrikePanelGrid"/>s.</summary>
        public static StrikePanelGrid Empty => new StrikePanelGrid(false);

        /// <summary>Width of the <see cref="Crafts.StrikePanel"/> pattern in <see cref="Crafts.CraftingRecipe"/>.</summary>
        public const int PanelsPerPatternWidth = 4;

        /// <summary>Height of the <see cref="Crafts.StrikePanel"/> pattern in <see cref="Crafts.CraftingRecipe"/>.</summary>
        public const int PanelsPerPatternHeight = 4;
        #endregion

        /// <summary>The backing collection of <see cref="StrikePanel"/>es.</summary>
        private StrikePanel[,] StrikePanels { get; }

        #region Initialization
        /// <summary>
        /// Initializes a new <see cref="StrikePanelGrid"/>.
        /// </summary>
        public StrikePanelGrid()
        {
            StrikePanels = new StrikePanel[PanelsPerPatternHeight, PanelsPerPatternWidth];
            for (var y = 0; y < PanelsPerPatternHeight; y++)
            {
                for (var x = 0; x < PanelsPerPatternWidth; x++)
                {
                    StrikePanels[y, x] = StrikePanel.Unused.Clone();
                }
            }
        }

        /// <summary>
        /// Initializes an empty <see cref="StrikePanelGrid"/>.
        /// </summary>
        /// <param name="in_IsEmpty">If true, an empty <see cref="StrikePanel"/> array will also be created.</param>
        private StrikePanelGrid(bool in_IsEmpty)
        {
            if (in_IsEmpty)
            {
                StrikePanels = new StrikePanel[0, 0];
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
