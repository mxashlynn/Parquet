using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using CsvHelper.Configuration.Attributes;
using Parquet.Properties;

namespace Parquet.Crafts
{
    /// <summary>
    /// Models the ingredients and process needed to produce a new item.
    /// </summary>
    /// <remarks>
    /// The crafting gameplay revolves around the data represented by instances of this class.
    /// </remarks>
    public class CraftingRecipe : Model, IMutableCraftingRecipe
    {
        #region Class Defaults
        /// <summary>Used in defining <see cref="NotCraftable"/>.</summary>
        private static IReadOnlyList<RecipeElement> EmptyCraftingElementList { get; } =
            new List<RecipeElement> { RecipeElement.None };

        /// <summary>Represents the lack of a <see cref="CraftingRecipe"/> for uncraftable <see cref="Items.ItemModel"/>s.</summary>
        public static CraftingRecipe NotCraftable { get; } = new CraftingRecipe(ModelID.None, "Not Craftable",
                                                                                "Not Craftable", "", null,
                                                                                EmptyCraftingElementList,
                                                                                EmptyCraftingElementList);
        #endregion

        #region Characteristics
        /// <summary>The types and amounts of <see cref="Items.ItemModel"/>s created by following this recipe.</summary>
        [Index(5)]
        public IReadOnlyList<RecipeElement> Products { get; }

        /// <summary>All materials and their quantities needed to follow this recipe once.</summary>
        [Index(6)]
        public IReadOnlyList<RecipeElement> Ingredients { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="CraftingRecipe"/> class.
        /// </summary>
        /// <param name="id">Unique identifier for the <see cref="CraftingRecipe"/>.  Cannot be null.</param>
        /// <param name="name">Player-friendly name of the <see cref="CraftingRecipe"/>.  Cannot be null or empty.</param>
        /// <param name="description">Player-friendly description of the <see cref="CraftingRecipe"/>.</param>
        /// <param name="comment">Comment of, on, or by the <see cref="CraftingRecipe"/>.</param>
        /// <param name="tags">Any additional functionality this <see cref="CraftingRecipe"/> has.</param>
        /// <param name="products">The types and quantities of <see cref="Items.ItemModel"/>s created by following this recipe once.</param>
        /// <param name="ingredients">All items needed to follow this <see cref="CraftingRecipe"/> once.</param>
        public CraftingRecipe(ModelID id, string name, string description, string comment,
                              IEnumerable<ModelTag> tags = null, IEnumerable<RecipeElement> products = null,
                              IEnumerable<RecipeElement> ingredients = null)
            : base(All.CraftingRecipeIDs, id, name, description, comment, tags)
        {
            var nonNullProducts = products ?? Enumerable.Empty<RecipeElement>();
            var nonNullIngredients = ingredients ?? Enumerable.Empty<RecipeElement>();

            // NOTE that these two checks should not be made from within editing tools.
            if (LibraryState.IsPlayMode)
            {
                var count = nonNullProducts.Count();
                if (!CraftConfiguration.ProductCount.ContainsValue(count))
                {
                    Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.ErrorOutOfBounds,
                                                               $"{nameof(products)}.Count", count,
                                                               CraftConfiguration.ProductCount));
                }
                count = nonNullIngredients.Count();
                if (!CraftConfiguration.IngredientCount.ContainsValue(count))
                {
                    Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.ErrorOutOfBounds,
                                                               $"{nameof(ingredients)}.Count", count,
                                                               CraftConfiguration.IngredientCount));
                }
            }

            Products = nonNullProducts.ToList();
            Ingredients = nonNullIngredients.ToList();
        }
        #endregion

        #region IMutableCraftingRecipe Implementation
        /// <summary>The types and amounts of <see cref="Items.ItemModel"/>s created by following this recipe.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="CraftingRecipe"/> should never themselves use <see cref="IMutableCraftingRecipe"/>.
        /// IMutableCraftingRecipe is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        ICollection<RecipeElement> IMutableCraftingRecipe.Products
            => LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(Products), new Collection<RecipeElement>())
                : (ICollection<RecipeElement>)Products;

        /// <summary>All materials and their quantities needed to follow this recipe once.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="CraftingRecipe"/> should never themselves use <see cref="IMutableCraftingRecipe"/>.
        /// IMutableCraftingRecipe is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        ICollection<RecipeElement> IMutableCraftingRecipe.Ingredients
            => LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(Ingredients), new Collection<RecipeElement>())
                : (ICollection<RecipeElement>)Ingredients;
        #endregion
    }
}
