#if DESIGN
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.EditorSupport;

namespace ParquetClassLibrary.Crafts
{
    /// <summary>
    /// Models the ingredients and process needed to produce a new item.
    /// </summary>
    [SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
                     Justification = "By design, subtypes of Model should never themselves use IMutableModel or derived interfaces to access their own members.  The IMutableModel family of interfaces is for external types that require read/write access.")]
    public partial class CraftingRecipe : IMutableCraftingRecipe
    {
        #region ICraftingRecipeEdit Implementation
        /// <summary>The types and amounts of <see cref="Items.ItemModel"/>s created by following this recipe.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        IList<RecipeElement> IMutableCraftingRecipe.Products => (IList<RecipeElement>)Products;

        /// <summary>All materials and their quantities needed to follow this recipe once.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        IList<RecipeElement> IMutableCraftingRecipe.Ingredients => (IList<RecipeElement>)Ingredients;

        /// <summary>The arrangement of panels encompassed by this recipe.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        IGrid<StrikePanel> IMutableCraftingRecipe.PanelPattern => (IGrid<StrikePanel>)PanelPattern;

        /// <summary>Replaces the content of <see cref="PanelPattern"/> with the given pattern.</summary>
        /// <param name="inReplacement">The new pattern to use.</param>
        public void PanelPatternReplace(IGrid<StrikePanel> inReplacement)
        {
            var nonNullPanelPattern = (StrikePanelGrid)inReplacement ?? StrikePanelGrid.Empty;
            PanelPattern = nonNullPanelPattern;
        }
        #endregion
    }
}
#endif
