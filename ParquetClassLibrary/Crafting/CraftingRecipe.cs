using System;
using System.Collections.Generic;
using System.Linq;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Crafting
{
    /// <summary>
    /// Models the ingredients and process needed to produce a new item.
    /// </summary>
    public sealed class CraftingRecipe : EntityModel
    {
        /// <summary>Used in defining <see cref="NotCraftable"/>.</summary>
        private static IReadOnlyList<RecipeElement> EmptyCraftingElementList { get; } =
            new List<RecipeElement> { RecipeElement.None };

        /// <summary>Represents the lack of a <see cref="CraftingRecipe"/> for uncraftable <see cref="Items.ItemModel"/>s.</summary>
        public static CraftingRecipe NotCraftable { get; } =
            new CraftingRecipe(EntityID.None, "Not Craftable", "Not Craftable", "",
                               EmptyCraftingElementList, EmptyCraftingElementList,
                               new StrikePanelGrid(Rules.Dimensions.PanelsPerPatternHeight,
                                                   Rules.Dimensions.PanelsPerPatternWidth));

        /// <summary>The types and amounts of <see cref="Items.ItemModel"/>s created by following this recipe.</summary>
        public IReadOnlyList<RecipeElement> Products { get; }

        /// <summary>All materials and their quantities needed to follow this recipe once.</summary>
        public IReadOnlyList<RecipeElement> Ingredients { get; }

        /// <summary>The arrangment of panels encompassed by this recipe.</summary>
        public StrikePanelGrid PanelPattern { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CraftingRecipe"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="CraftingRecipe"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="CraftingRecipe"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="CraftingRecipe"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="CraftingRecipe"/>.</param>
        /// <param name="inProducts">The types and quantities of <see cref="Items.ItemModel"/>s created by following this recipe once.</param>
        /// <param name="inIngredients">All items needed to follow this <see cref="CraftingRecipe"/> once.</param>
        /// <param name="inPanelPattern">The arrangment of panels encompassed by this <see cref="CraftingRecipe"/>.</param>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown when <paramref name="inPanelPattern"/> has zero-dimensions or dimensions larger than those given by
        /// <see cref="Rules.Dimensions.PanelsPerPatternWidth"/> and <see cref="Rules.Dimensions.PanelsPerPatternHeight"/>.
        /// </exception>
        public CraftingRecipe(EntityID inID, string inName, string inDescription, string inComment,
                              IEnumerable<RecipeElement> inProducts,
                              IEnumerable<RecipeElement> inIngredients, StrikePanelGrid inPanelPattern)
            : base(All.CraftingRecipeIDs, inID, inName, inDescription, inComment)
        {
            Precondition.IsNotNullOrEmpty(inProducts, nameof(inProducts));
            Precondition.IsInRange(inProducts.Count(), Rules.Recipes.Craft.ProductCount);
            Precondition.IsNotNullOrEmpty(inIngredients, nameof(inIngredients));
            Precondition.IsInRange(inIngredients.Count(), Rules.Recipes.Craft.IngredientCount);
            Precondition.IsNotNull(inPanelPattern, nameof(inPanelPattern));
            if (inPanelPattern.Rows > Rules.Dimensions.PanelsPerPatternHeight
                || inPanelPattern.Columns > Rules.Dimensions.PanelsPerPatternWidth
                || inPanelPattern.Rows < 1
                || inPanelPattern.Columns < 1)
            {
                throw new IndexOutOfRangeException($"Dimension outside specification: {nameof(inPanelPattern)}");
            }

            Products = inProducts.ToList();
            Ingredients = inIngredients.ToList();
            PanelPattern = inPanelPattern;
        }
    }
}
