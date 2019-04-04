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
        #region Defaults
        public const int PanelPatternMaxWidth = 2;
        public const int PanelPatternMaxHeight = 4;
        #endregion

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
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the either the in_itemProduced or any of the in_ingredients are not within
        /// the <c see="AssemblyInfo.ItemIDs"/> range.
        /// </exception>
        public CraftingRecipe(EntityID in_itemProduced, int in_quantityProduced,
                              List<EntityID> in_ingredients, StrikePanel[,] in_panelPattern)
        {
            if (!in_itemProduced.IsValidForRange(AssemblyInfo.ItemIDs))
            {
                throw new ArgumentOutOfRangeException(nameof(in_itemProduced));
            }
            foreach (var ingredient in in_ingredients)
            {
                if (!ingredient.IsValidForRange(AssemblyInfo.ItemIDs))
                {
                    throw new ArgumentOutOfRangeException(nameof(in_ingredients));
                }
            }
            if (in_panelPattern.GetLength(0) > PanelPatternMaxWidth
                || in_panelPattern.GetLength(1) > PanelPatternMaxHeight)
            {
                throw new IndexOutOfRangeException(nameof(in_panelPattern));
            }

            ItemProduced = in_itemProduced;
            QuantityProduced = in_quantityProduced;
            Ingredients = in_ingredients;
            PanelPattern = in_panelPattern;
        }
    }
}
