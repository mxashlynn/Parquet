using System;
using System.Collections.Generic;
using Parquet;
using Parquet.Crafts;
using Xunit;

namespace ParquetUnitTests.Crafts
{
    public class CraftingRecipeUnitTest
    {
        #region Test Values
        /// <summary>Identifier used when creating a new block.</summary>
        private static readonly ModelID newCraftingRecipeID = TestModels.TestCraftingRecipe.ID - 1;

        /// <summary>A valid minimal list of test ingredients.</summary>
        private static readonly IReadOnlyList<RecipeElement> ingredientList = new List<RecipeElement>
        {
            new RecipeElement(1, "ingredient"),
        };

        /// <summary>A valid minimal list of test products.</summary>
        private static readonly IReadOnlyList<RecipeElement> productList = new List<RecipeElement>
        {
            new RecipeElement(1, "product"),
        };

        /// <summary>A trivial panel pattern.</summary>
        private static readonly StrikePanelGrid emptyPanelPattern = new StrikePanelGrid(StrikePanelGrid.PanelsPerPatternHeight,
                                                                                        StrikePanelGrid.PanelsPerPatternWidth);
        #endregion

        [Fact]
        public void ValidCraftingRecipeIDsArePermittedTest()
        {
            var newCraftingRecipe = new CraftingRecipe(newCraftingRecipeID, "will be created", "", "", null,
                                                       productList, ingredientList, emptyPanelPattern);

            Assert.NotNull(newCraftingRecipe);
        }

        [Fact]
        public void InvalidCraftingRecipeIDsThrowTest()
        {
            var badCraftingRecipeID = TestModels.TestBlock.ID - 1;

            void TestCode()
            {
                var _ = new CraftingRecipe(badCraftingRecipeID, "will fail", "", "", null,
                                           productList, ingredientList, emptyPanelPattern);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }

        [Fact]
        public void PanelTooHighPatternsThrowTest()
        {
            var patternTooHigh = new StrikePanelGrid(StrikePanelGrid.PanelsPerPatternHeight + 1,
                                                     StrikePanelGrid.PanelsPerPatternWidth);

            void TestCodeTooHigh()
            {
                var _ = new CraftingRecipe(newCraftingRecipeID, "will fail", "", "", null,
                                           productList, ingredientList, patternTooHigh);
            }

            Assert.Throws<IndexOutOfRangeException>(TestCodeTooHigh);
        }

        [Fact]
        public void PanelTooWidePatternsThrowTest()
        {
            var patternTooWide = new StrikePanelGrid(StrikePanelGrid.PanelsPerPatternHeight,
                                                     StrikePanelGrid.PanelsPerPatternWidth + 1);

            void TestCodeTooWide()
            {
                var _ = new CraftingRecipe(newCraftingRecipeID, "will fail", "", "", null,
                                           productList, ingredientList, patternTooWide);
            }

            Assert.Throws<IndexOutOfRangeException>(TestCodeTooWide);
        }
    }
}
