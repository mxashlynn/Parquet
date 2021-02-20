using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using CsvHelper.Configuration.Attributes;
using Parquet.EditorSupport;

namespace Parquet.Crafts
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
        ICollection<RecipeElement> IMutableCraftingRecipe.Products
            => LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(Products), new Collection<RecipeElement>())
                : (ICollection<RecipeElement>)Products;

        /// <summary>All materials and their quantities needed to follow this recipe once.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        ICollection<RecipeElement> IMutableCraftingRecipe.Ingredients
            => LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(Ingredients), new Collection<RecipeElement>())
                : (ICollection<RecipeElement>)Ingredients;

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
            => PanelPattern = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(PanelPattern), PanelPattern)
                : inReplacement as StrikePanelGrid ?? StrikePanelGrid.Empty;
        #endregion
    }
}
