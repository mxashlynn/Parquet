using System;
using System.Collections.Generic;
using System.Linq;
using CsvHelper.Configuration;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Crafts
{
    /// <summary>
    /// Models the ingredients and process needed to produce a new item.
    /// </summary>
    public sealed class CraftingRecipe : EntityModel
    {
        #region Characteristics
        /// <summary>Used in defining <see cref="NotCraftable"/>.</summary>
        private static IReadOnlyList<RecipeElement> EmptyCraftingElementList { get; } =
            new List<RecipeElement> { RecipeElement.None };

        /// <summary>Represents the lack of a <see cref="CraftingRecipe"/> for uncraftable <see cref="Items.ItemModel"/>s.</summary>
        public static CraftingRecipe NotCraftable { get; } = new CraftingRecipe(EntityID.None, "Not Craftable", "Not Craftable", "",
                                                                                EmptyCraftingElementList, EmptyCraftingElementList,
                                                                                new StrikePanelGrid());

        /// <summary>The types and amounts of <see cref="Items.ItemModel"/>s created by following this recipe.</summary>
        public IReadOnlyList<RecipeElement> Products { get; }

        /// <summary>All materials and their quantities needed to follow this recipe once.</summary>
        public IReadOnlyList<RecipeElement> Ingredients { get; }

        /// <summary>The arrangment of panels encompassed by this recipe.</summary>
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
        /// Thrown when <paramref name="inPanelPattern"/> has dimensions less than <c>1</c> or dimensions larger than those given by
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
        #endregion

        #region Serialization
        #region Serializer Shim
        /// <summary>
        /// Provides a default public parameterless constructor for a
        /// <see cref="CraftingRecipe"/>-like class that CSVHelper can instantiate.
        /// 
        /// Provides the ability to generate a <see cref="CraftingRecipe"/> from this class.
        /// </summary>
        internal class CraftingRecipeShim : EntityShim
        {
            /// <summary>The types and amounts of <see cref="Items.ItemModel"/>s created by following this recipe.</summary>
            public IReadOnlyList<RecipeElement> Products;

            /// <summary>All materials and their quantities needed to follow this recipe once.</summary>
            public IReadOnlyList<RecipeElement> Ingredients;

            /// <summary>The arrangment of panels encompassed by this recipe.</summary>
            public StrikePanelGrid PanelPattern;

            /// <summary>
            /// Converts a shim into the class it corresponds to.
            /// </summary>
            /// <typeparam name="TModel">The type to convert this shim to.</typeparam>
            /// <returns>An instance of a child class of <see cref="EnityModel"/>.</returns>
            public override TModel ToEntity<TModel>()
            {
                Precondition.IsOfType<TModel, CraftingRecipe>(typeof(TModel).ToString());

                return (TModel)(EntityModel)new CraftingRecipe(ID, Name, Description, Comment, Products, Ingredients, PanelPattern);
            }
        }
        #endregion

        #region Class Map
        /// <summary>
        /// Maps the values in a <see cref="CraftingRecipeShim"/> to records that CSVHelper recognizes.
        /// </summary>
        internal sealed class CraftingRecipeClassMap : ClassMap<CraftingRecipeShim>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="CraftingRecipeClassMap"/> class.
            /// </summary>
            public CraftingRecipeClassMap()
            {
                // Properties are ordered by index to facilitate a logical layout in spreadsheet apps.
                Map(m => m.ID).Index(0);
                Map(m => m.Name).Index(1);
                Map(m => m.Description).Index(2);
                Map(m => m.Comment).Index(3);

                Map(m => m.Products).Index(4);
                Map(m => m.Ingredients).Index(5);
                Map(m => m.PanelPattern).Index(6);
            }
        }
        #endregion

        /// <summary>Caches a class mapper.</summary>
        private static CraftingRecipeClassMap classMapCache;

        /// <summary>
        /// Provides the means to map all members of this class to a CSV file.
        /// </summary>
        /// <returns>The member mapping.</returns>
        internal static ClassMap GetClassMap()
            => classMapCache
            ?? (classMapCache = new CraftingRecipeClassMap());

        /// <summary>
        /// Provides the means to map all members of this class to a CSV file.
        /// </summary>
        /// <returns>The member mapping.</returns>
        internal static Type GetShimType()
            => typeof(CraftingRecipeShim);
        #endregion
    }
}
