#if DESIGN
using System.Collections.Generic;
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.EditorSupport;

namespace ParquetClassLibrary.Crafts
{
    /// <summary>
    /// Models the ingredients and process needed to produce a new item.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
        Justification = "By design, subtypes of Model should never themselves use IModelEdit or derived interfaces to access their own members.  The IModelEdit family of interfaces is for external types that require read/write access.")]
    public partial class CraftingRecipe : ICraftingRecipeEdit
    {
        #region ICraftingRecipeEdit Implementation
        /// <summary>The types and amounts of <see cref="Items.ItemModel"/>s created by following this recipe.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require readwrite access.
        /// </remarks>
        [Ignore]
        IList<RecipeElement> ICraftingRecipeEdit.Products => (IList<RecipeElement>)Products;

        /// <summary>All materials and their quantities needed to follow this recipe once.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require readwrite access.
        /// </remarks>
        [Ignore]
        IList<RecipeElement> ICraftingRecipeEdit.Ingredients => (IList<RecipeElement>)Ingredients;

        /// <summary>The arrangment of panels encompassed by this recipe.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require readwrite access.
        /// </remarks>
        [Ignore]
        // TODO Revisit this implementation.  IGrid is read-write as of Aug 21 2020 anyway.
        StrikePanelGrid ICraftingRecipeEdit.PanelPattern => PanelPattern;
        #endregion
    }
}
#endif
