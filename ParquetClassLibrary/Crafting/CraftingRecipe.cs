using System;
using System.Collections.Generic;
using System.Linq;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Crafting
{
    /// <summary>
    /// Models the ingredients and process needed to produce a new item.
    /// </summary>
    public class CraftingRecipe : Entity
    {
        /// <summary>Used in defining <see cref="NotCraftable"/>.</summary>
        private static IReadOnlyList<RecipeElement> EmptyCraftingElementList { get; } =
            new List<RecipeElement> { RecipeElement.None };

        /// <summary>Represents the lack of a <see cref="CraftingRecipe"/> for uncraftable <see cref="Items.Item"/>s.</summary>
        public static CraftingRecipe NotCraftable { get; } =
            new CraftingRecipe(EntityID.None, "Not Craftable", "Not Craftable", "",
                               EmptyCraftingElementList, EmptyCraftingElementList,
                               new StrikePanel[Rules.Dimensions.PanelsPerPatternHeight,
                                               Rules.Dimensions.PanelsPerPatternWidth]);

        /// <summary>The types and amounts of <see cref="Items.Item"/>s created by following this recipe.</summary>
        public IReadOnlyList<RecipeElement> Products { get; }

        /// <summary>All materials and their quantities needed to follow this recipe once.</summary>
        public IReadOnlyList<RecipeElement> Ingredients { get; }

        /// <summary>Backing field for the arrangment of panels encompassed by this recipe.</summary>
        private StrikePanel[,] PanelPattern { get; }

        /// <summary>The arrangment of panels encompassed by this recipe.</summary>
        public StrikePanel this[int y, int x]
        {
            get
            {
                return PanelPattern[y, x];
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CraftingRecipe"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="CraftingRecipe"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="CraftingRecipe"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="CraftingRecipe"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="CraftingRecipe"/>.</param>
        /// <param name="inProducts">The types and quantities of <see cref="Items.Item"/>s created by following this recipe once.</param>
        /// <param name="inIngredients">All items needed to follow this <see cref="CraftingRecipe"/> once.</param>
        /// <param name="inPanelPattern">The arrangment of panels encompassed by this <see cref="CraftingRecipe"/>.</param>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown when <paramref name="inPanelPattern"/> has zero-dimensions or dimensions larger than those given by
        /// <see cref="Rules.Dimensions.PanelsPerPatternWidth"/> and <see cref="Rules.Dimensions.PanelsPerPatternHeight"/>.
        /// </exception>
        public CraftingRecipe(EntityID inID, string inName, string inDescription, string inComment,
                              IEnumerable<RecipeElement> inProducts,
                              IEnumerable<RecipeElement> inIngredients, StrikePanel[,] inPanelPattern)
            : base(All.CraftingRecipeIDs, inID, inName, inDescription, inComment)
        {
            Precondition.IsNotNullOrEmpty(inProducts, nameof(inProducts));
            Precondition.IsInRange(inProducts.Count(), Rules.Recipes.Craft.ProductCount);
            Precondition.IsNotNullOrEmpty(inIngredients, nameof(inIngredients));
            Precondition.IsInRange(inIngredients.Count(), Rules.Recipes.Craft.IngredientCount);
            Precondition.IsNotNull(inPanelPattern, nameof(inPanelPattern));
            if (inPanelPattern.GetLength(0) > Rules.Dimensions.PanelsPerPatternHeight
                || inPanelPattern.GetLength(1) > Rules.Dimensions.PanelsPerPatternWidth
                || inPanelPattern.GetLength(0) < 1
                || inPanelPattern.GetLength(1) < 1)
            {
                throw new IndexOutOfRangeException($"Dimension outside specification: {nameof(inPanelPattern)}");
            }

            Products = inProducts.ToList();
            Ingredients = inIngredients.ToList();
            PanelPattern = inPanelPattern;
        }
    }
}
