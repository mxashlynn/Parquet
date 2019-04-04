using System;
using System.Collections.Generic;
using ParquetClassLibrary.Sandbox.ID;

namespace ParquetClassLibrary.Crafting
{
    /// <summary>
    /// Models the ingredients and process needed to produce a new item.
    /// </summary>
    public struct CraftingRecipe
    {
        /// <summary>The type of item created by following this recipe.</summary>
        public EntityID ItemProduced { get; }

        /// <summary>The number of items created by following this recipe.</summary>
        public int QuantityProduced { get; }

        /// <summary>All materials needed to follow this recipe once.</summary>
        public readonly List<EntityID> Ingredients;

        /// <summary>The arrangment of panels encompassed by this recipe.</summary>
        public readonly StrikePanel[,] PanelPattern;

        /// <summary>
        /// Initializes a new instance of the <see cref="CraftingRecipe"/> struct.
        /// </summary>
        /// <param name="in_itemProduced">The type of item created by following this recipe.</param>
        /// <param name="in_quantityProduced">The number of items created by following this recipe.</param>
        /// <param name="in_ingredients">All items needed to follow this recipe once.</param>
        /// <param name="in_panelPattern">The arrangment of panels encompassed by this recipe.</param>
        /// <exception cref="ArgumentNullException">Thrown when in_ingredients is null.</exception>
        /// <exception cref="ArgumentNullException">Thrown when in_panelPattern is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when in_quantityProduced is less than 1.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when in_itemProduced is not within the <c see="AssemblyInfo.ItemIDs"/> range.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when any in_ingredients are not within the <c see="AssemblyInfo.ItemIDs"/> range.
        /// </exception>
        /// <exception cref="IndexOutOfRangeException">Thrown when in_ingredients is empty.</exception>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown when in_panelPattern has dimensions other than those given by
        /// <see cref="AssemblyInfo.PanelPatternWidth"/> and <see cref="AssemblyInfo.PanelPatternHeight"/>.
        /// </exception>
        public CraftingRecipe(EntityID in_itemProduced, int in_quantityProduced,
                              List<EntityID> in_ingredients, StrikePanel[,] in_panelPattern)
        {
            if (!in_itemProduced.IsValidForRange(AssemblyInfo.ItemIDs))
            {
                throw new ArgumentOutOfRangeException(nameof(in_itemProduced));
            }
            if (in_quantityProduced < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(in_quantityProduced));
            }
            foreach (var ingredient in in_ingredients)
            {
                if (!ingredient.IsValidForRange(AssemblyInfo.ItemIDs))
                {
                    throw new ArgumentOutOfRangeException(nameof(in_ingredients));
                }
            }
            if (null == in_ingredients)
            {
                throw new ArgumentNullException(nameof(in_ingredients));
            }
            if (in_ingredients.Count < 1)
            {
                throw new IndexOutOfRangeException(nameof(in_ingredients));
            }
            if (in_panelPattern.GetLength(0) != AssemblyInfo.PanelPatternWidth
                || in_panelPattern.GetLength(1) != AssemblyInfo.PanelPatternHeight)
            {
                throw new IndexOutOfRangeException(nameof(in_panelPattern));
            }

            ItemProduced = in_itemProduced;
            QuantityProduced = in_quantityProduced;
            Ingredients = in_ingredients;
            PanelPattern = in_panelPattern ?? throw new ArgumentNullException(nameof(in_panelPattern));
        }
    }
}
