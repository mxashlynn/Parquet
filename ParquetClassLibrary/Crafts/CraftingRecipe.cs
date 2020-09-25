using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.Properties;

namespace ParquetClassLibrary.Crafts
{
    /// <summary>
    /// Models the ingredients and process needed to produce a new item.
    /// </summary>
    public partial class CraftingRecipe : Model
    {
        #region Class Defaults
        /// <summary>Used in defining <see cref="NotCraftable"/>.</summary>
        private static IReadOnlyList<RecipeElement> EmptyCraftingElementList { get; } =
            new List<RecipeElement> { RecipeElement.None };

        /// <summary>Represents the lack of a <see cref="CraftingRecipe"/> for uncraftable <see cref="Items.ItemModel"/>s.</summary>
        public static CraftingRecipe NotCraftable { get; } = new CraftingRecipe(ModelID.None, "Not Craftable", "Not Craftable", "",
                                                                                EmptyCraftingElementList, EmptyCraftingElementList,
                                                                                new StrikePanelGrid());
        #endregion

        #region Characteristics
        /// <summary>The types and amounts of <see cref="Items.ItemModel"/>s created by following this recipe.</summary>
        [Index(4)]
        public IReadOnlyList<RecipeElement> Products { get; }

        /// <summary>All materials and their quantities needed to follow this recipe once.</summary>
        [Index(5)]
        public IReadOnlyList<RecipeElement> Ingredients { get; }

        /// <summary>The arrangment of panels encompassed by this recipe.</summary>
        [Index(6)]
        public StrikePanelGrid PanelPattern { get; }
        #endregion

        #region Initialization
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
        /// When <paramref name="inPanelPattern"/> has dimensions less than <c>1</c> or dimensions larger than those given by
        /// <see cref="StrikePanelGrid.PanelsPerPatternWidth"/> and <see cref="StrikePanelGrid.PanelsPerPatternHeight"/>.
        /// </exception>
        public CraftingRecipe(ModelID inID, string inName, string inDescription, string inComment,
                              IEnumerable<RecipeElement> inProducts = null,
                              IEnumerable<RecipeElement> inIngredients = null, StrikePanelGrid inPanelPattern = null)
            : base(All.CraftingRecipeIDs, inID, inName, inDescription, inComment)
        {
            var nonNullProducts = inProducts ?? Enumerable.Empty<RecipeElement>();
            var nonNullIngredients = inIngredients ?? Enumerable.Empty<RecipeElement>();
            var nonNullPanelPattern = inPanelPattern ?? StrikePanelGrid.Empty;

#if !DESIGN
            // DESIGN-Time Note: These two checks should not be made from within editing tools.
            Precondition.IsInRange(nonNullProducts.Count(), CraftConfiguration.ProductCount, $"{nameof(inProducts)}.Count");
            Precondition.IsInRange(nonNullIngredients.Count(), CraftConfiguration.IngredientCount, $"{nameof(inIngredients)}.Count");
#endif

            if (nonNullPanelPattern.Rows > StrikePanelGrid.PanelsPerPatternHeight
                || nonNullPanelPattern.Columns > StrikePanelGrid.PanelsPerPatternWidth)
            {
                throw new IndexOutOfRangeException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorUnsupportedDimension,
                                                                 nameof(inPanelPattern)));
            }

            Products = nonNullProducts.ToList();
            Ingredients = nonNullIngredients.ToList();
            PanelPattern = nonNullPanelPattern;
        }
        #endregion
    }
}
