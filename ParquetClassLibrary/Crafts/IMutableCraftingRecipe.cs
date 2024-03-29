using System.Collections.Generic;

namespace Parquet.Crafts
{
    /// <summary>
    /// Facilitates editing of a <see cref="CraftingRecipe"/> from design tools while maintaining a read-only face for use during play.
    /// </summary>
    /// <remarks>
    /// By design, subtypes of <see cref="CraftingRecipe"/> should never themselves use <see cref="IMutableCraftingRecipe"/>.
    /// IMutableCraftingRecipe is for use only by external types that require read/write access to model properties.
    /// </remarks>
    public interface IMutableCraftingRecipe : IMutableModel
    {
        /// <summary>The types and amounts of <see cref="Items.ItemModel"/>s created by following this recipe.</summary>
        public ICollection<RecipeElement> Products { get; }

        /// <summary>All materials and their quantities needed to follow this recipe once.</summary>
        public ICollection<RecipeElement> Ingredients { get; }
    }
}
