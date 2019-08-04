using System;
using System.Collections.Generic;
using ParquetClassLibrary;
using ParquetClassLibrary.Crafting;
using Xunit;

namespace ParquetUnitTests
{
    public class CraftingRecipeUnitTest
    {
        #region Test Values
        /// <summary>Identifier used when creating a new block.</summary>
        private static readonly EntityID newCraftingRecipeID = TestEntities.TestCraftingRecipe.ID - 1;

        /// <summary>A valid minimal list of test ingredients.</summary>
        private static readonly List<RecipeElement> ingredientList = new List<RecipeElement>
        {
            new RecipeElement( "ingredient", 1 ),
        };

        /// <summary>A valid minimal list of test products.</summary>
        private static readonly List<RecipeElement> productList = new List<RecipeElement>
        {
            new RecipeElement( "product", 1 ),
        };

        /// <summary>A trivial panel pattern.</summary>
        private static readonly StrikePanel[,] emptyPanelPattern = new StrikePanel[Rules.Dimensions.PanelsPerPatternHeight,
                                                                                   Rules.Dimensions.PanelsPerPatternWidth];
        #endregion

        [Fact]
        public void ValidCraftingRecipeIDsArePermittedTest()
        {
            var newCraftingRecipe = new CraftingRecipe(newCraftingRecipeID, "will be created", "", "",
                                                       productList, ingredientList, emptyPanelPattern);

            Assert.NotNull(newCraftingRecipe);
        }

        [Fact]
        public void InvalidCraftingRecipeIDsThrowTest()
        {
            var badCraftingRecipeID = TestEntities.TestBlock.ID - 1;

            void TestCode()
            {
                var _ = new CraftingRecipe(badCraftingRecipeID, "will fail", "", "",
                                           productList, ingredientList, emptyPanelPattern);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }

        [Fact]
        public void NullAndEmptyProductListsThrowTest()
        {
            var emptyProductList = new List<RecipeElement>();

            void TestCodeNull()
            {
                var _ = new CraftingRecipe(newCraftingRecipeID, "will fail", "", "",
                                           null, ingredientList, emptyPanelPattern);
            }

            void TestCodeEmpty()
            {
                var _ = new CraftingRecipe(newCraftingRecipeID, "will fail", "", "",
                                           emptyProductList, ingredientList, emptyPanelPattern);
            }

            Assert.Throws<ArgumentNullException>(TestCodeNull);
            Assert.Throws<IndexOutOfRangeException>(TestCodeEmpty);
        }

        [Fact]
        public void NullAndEmptyIngredientListsThrowTest()
        {
            var emptyIngredientList = new List<RecipeElement>();

            void TestCodeNull()
            {
                var _ = new CraftingRecipe(newCraftingRecipeID, "will fail", "", "",
                                           productList, null, emptyPanelPattern);
            }

            void TestCodeEmpty()
            {
                var _ = new CraftingRecipe(newCraftingRecipeID, "will fail", "", "",
                                           productList, emptyIngredientList, emptyPanelPattern);
            }

            Assert.Throws<ArgumentNullException>(TestCodeNull);
            Assert.Throws<IndexOutOfRangeException>(TestCodeEmpty);
        }

        [Fact]
        public void NullPanelPatternsThrowTest()
        {
            void TestCode()
            {
                var _ = new CraftingRecipe(newCraftingRecipeID, "will fail", "", "",
                                           productList, ingredientList, null);
            }

            Assert.Throws<ArgumentNullException>(TestCode);
        }

        [Fact]
        public void PanelTooNarrowPatternsThrowTest()
        {
            var patternTooNarrow = new StrikePanel[Rules.Dimensions.PanelsPerPatternHeight, 0];

            void TestCodeTooNarrow()
            {
                var _ = new CraftingRecipe(newCraftingRecipeID, "will fail", "", "",
                                           productList, ingredientList, patternTooNarrow);
            }

            Assert.Throws<IndexOutOfRangeException>(TestCodeTooNarrow);
        }

        [Fact]
        public void PanelTooShortPatternsThrowTest()
        {
            var patternTooShort = new StrikePanel[0, Rules.Dimensions.PanelsPerPatternWidth];

            void TestCodeTooShort()
            {
                var _ = new CraftingRecipe(newCraftingRecipeID, "will fail", "", "",
                                           productList, ingredientList, patternTooShort);
            }

            Assert.Throws<IndexOutOfRangeException>(TestCodeTooShort);
        }

        [Fact]
        public void PanelTooHighPatternsThrowTest()
        {
            var patternTooHigh = new StrikePanel[Rules.Dimensions.PanelsPerPatternHeight + 1,
                                                 Rules.Dimensions.PanelsPerPatternWidth];

            void TestCodeTooHigh()
            {
                var _ = new CraftingRecipe(newCraftingRecipeID, "will fail", "", "",
                                           productList, ingredientList, patternTooHigh);
            }

            Assert.Throws<IndexOutOfRangeException>(TestCodeTooHigh);
        }

        [Fact]
        public void PanelTooWidePatternsThrowTest()
        {
            var patternTooWide = new StrikePanel[Rules.Dimensions.PanelsPerPatternHeight,
                                                 Rules.Dimensions.PanelsPerPatternWidth + 1];

            void TestCodeTooWide()
            {
                var _ = new CraftingRecipe(newCraftingRecipeID, "will fail", "", "",
                                           productList, ingredientList, patternTooWide);
            }

            Assert.Throws<IndexOutOfRangeException>(TestCodeTooWide);
        }
    }
}
