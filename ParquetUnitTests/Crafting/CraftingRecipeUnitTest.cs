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
        private static readonly List<CraftingElement> ingredientList = new List<CraftingElement>
        {
            new CraftingElement( TestEntities.TestItem.ID - 1, 1 ),
        };

        /// <summary>A valid minimal list of test products.</summary>
        private static readonly List<CraftingElement> productList = new List<CraftingElement>
        {
            new CraftingElement( TestEntities.TestItem.ID - 2, 1 ),
        };

        /// <summary>A trivial panel pattern.</summary>
        private static readonly StrikePanel[,] emptyPanelPattern = new StrikePanel[All.Dimensions.PanelsPerPatternWidth,
                                                                                   All.Dimensions.PanelsPerPatternHeight];
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
            var emptyProductList = new List<CraftingElement>();

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
            var emptyIngredientList = new List<CraftingElement>();

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
        public void ImproperlySizedPanelPatternsThrowTest()
        {
            var patternTooWide = new StrikePanel[All.Dimensions.PanelsPerPatternWidth + 1,
                                                All.Dimensions.PanelsPerPatternHeight];

            var patternTooHigh = new StrikePanel[All.Dimensions.PanelsPerPatternWidth,
                                                 All.Dimensions.PanelsPerPatternHeight + 1];

            var patternTooSmall = new StrikePanel[0, 0];

            void TestCodeTooWide()
            {
                var _ = new CraftingRecipe(newCraftingRecipeID, "will fail", "", "",
                                           productList, ingredientList, patternTooWide);
            }

            void TestCodeTooHigh()
            {
                var _ = new CraftingRecipe(newCraftingRecipeID, "will fail", "", "",
                                           productList, ingredientList, patternTooHigh);
            }

            void TestCodeTooSmall()
            {
                var _ = new CraftingRecipe(newCraftingRecipeID, "will fail", "", "",
                                           productList, ingredientList, patternTooSmall);
            }

            Assert.Throws<IndexOutOfRangeException>(TestCodeTooWide);
            Assert.Throws<IndexOutOfRangeException>(TestCodeTooHigh);
            Assert.Throws<IndexOutOfRangeException>(TestCodeTooSmall);
        }
    }
}
