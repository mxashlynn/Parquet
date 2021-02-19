using System.Collections.Generic;
using Parquet.Crafts;

namespace Parquet.EditorSupport
{
    /// <summary>
    /// Facilitates editing of a <see cref="CraftingRecipe"/> from design tools while maintaining a read-only face for use during play.
    /// </summary>
    /// <remarks>
    /// By design, subtypes of <see cref="CraftingRecipe"/> should never themselves use <see cref="IMutableCraftingRecipe"/>.
    /// ICraftingRecipeEdit is for use only by external types that require read/write access to model properties.
    /// </remarks>
    public interface IMutableCraftingRecipe : IMutableModel
    {
        /// <summary>The types and amounts of <see cref="Items.ItemModel"/>s created by following this recipe.</summary>
        public ICollection<RecipeElement> Products { get; }

        /// <summary>All materials and their quantities needed to follow this recipe once.</summary>
        public ICollection<RecipeElement> Ingredients { get; }

        /// <summary>The arrangement of panels encompassed by this recipe.</summary>
        public IGrid<StrikePanel> PanelPattern { get; }

        /// <summary>Replaces the content of <see cref="PanelPattern"/> with the given pattern.</summary>
        /// <param name="inReplacement">The new pattern to use.</param>
        public void PanelPatternReplace(IGrid<StrikePanel> inReplacement);
    }
}
