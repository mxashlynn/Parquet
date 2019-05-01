using System;
using System.Collections.Generic;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Crafting
{
    /// <summary>
    /// Models the ingredients and process needed to produce a new item.
    /// </summary>
    public class CraftingRecipe : Entity
    {
        /// <summary>Used in defining <see cref="NotCraftable"/>.</summary>
        private static readonly List<CraftingElement> EmptyCraftingElementList =
            new List<CraftingElement> { CraftingElement.None };

        /// <summary>Represents the lack of a <see cref="CraftingRecipe"/> for uncraftable <see cref="Items.Item"/>s.</summary>
        public static readonly CraftingRecipe NotCraftable =
            new CraftingRecipe(EntityID.None, "Not Craftable", EmptyCraftingElementList, EmptyCraftingElementList,
                               new StrikePanel[All.Dimensions.PanelsPerPatternWidth,
                                               All.Dimensions.PanelsPerPatternHeight]);

        /// <summary>The types and amounts of <see cref="Items.Item"/>s created by following this recipe.</summary>
        public List<CraftingElement> Products { get; }

        /// <summary>All materials and their quantities needed to follow this recipe once.</summary>
        public List<CraftingElement> Ingredients { get; }

        /// <summary>The arrangment of panels encompassed by this recipe.</summary>
        public StrikePanel[,] PanelPattern { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CraftingRecipe"/> class.
        /// </summary>
        /// <param name="in_id">Unique identifier for the <see cref="CraftingRecipe"/>.  Cannot be null.</param>
        /// <param name="in_name">Player-friendly name of the <see cref="CraftingRecipe"/>.  Cannot be null or empty.</param>
        /// <param name="in_products">The types and quantities of <see cref="Items.Item"/>s created by following this recipe once.</param>
        /// <param name="in_ingredients">All items needed to follow this <see cref="CraftingRecipe"/> once.</param>
        /// <param name="in_panelPattern">The arrangment of panels encompassed by this <see cref="CraftingRecipe"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="in_products"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="in_ingredients"/> is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="in_panelPattern"/> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">Thrown when <paramref name="in_products"/> is empty.</exception>
        /// <exception cref="IndexOutOfRangeException">Thrown when <paramref name="in_ingredients"/> is empty.</exception>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown when <paramref name="in_panelPattern"/> has zero-dimensions or dimensions larger than those given by
        /// <see cref="All.Dimensions.PanelsPerPatternWidth"/> and <see cref="All.Dimensions.PanelsPerPatternHeight"/>.
        /// </exception>
        public CraftingRecipe(EntityID in_id, string in_name, List<CraftingElement> in_products,
                              List<CraftingElement> in_ingredients, StrikePanel[,] in_panelPattern)
            : base(All.CraftingRecipeIDs, in_id, in_name)
        {
            Precondition.IsNotNull(in_products, nameof(in_products));
            Precondition.IsNotEmpty(in_products, nameof(in_products));
            Precondition.IsNotNull(in_ingredients, nameof(in_ingredients));
            Precondition.IsNotEmpty(in_ingredients, nameof(in_ingredients));
            Precondition.IsNotNull(in_panelPattern, nameof(in_panelPattern));
            if (in_panelPattern.GetLength(0) > All.Dimensions.PanelsPerPatternWidth
                || in_panelPattern.GetLength(1) > All.Dimensions.PanelsPerPatternHeight
                || in_panelPattern.GetLength(0) < 1
                || in_panelPattern.GetLength(1) < 1)
            {
                throw new IndexOutOfRangeException($"Dimension outside specification: {nameof(in_panelPattern)}");
            }

            Products = in_products;
            Ingredients = in_ingredients;
            PanelPattern = in_panelPattern;
        }
    }
}
