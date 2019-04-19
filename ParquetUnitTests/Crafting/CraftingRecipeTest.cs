using System;
using System.Collections.Generic;
using ParquetClassLibrary;
using ParquetClassLibrary.Crafting;
using Xunit;

namespace ParquetUnitTests
{
    public class CraftingRecipeTest
    {
        #region Test Values
        /// <summary>Identifier used when creating a new block.</summary>
        private static readonly EntityID newCraftingRecipeID = TestEntities.TestCraftingRecipe.ID - 1;

        /// <summary>A valid minimal list of test ingredients.</summary>
        private static readonly List<EntityID> ingredientList = new List<EntityID>
        {
            TestEntities.TestItem.ID - 1,
        };

        /// <summary>A trivial panel pattern.</summary>
        private static readonly StrikePanel[,] emptyPanelPattern = new StrikePanel[All.Dimensions.PanelsPerPatternWidth,
                                                                                   All.Dimensions.PanelsPerPatternHeight];
        #endregion

        [Fact]
        public void ValidCraftingRecipeIDsArePermittedTest()
        {
            var newCraftingRecipe = new CraftingRecipe(newCraftingRecipeID, "will be created",
                                                       TestEntities.TestItem.ID, 1, ingredientList,
                                                       emptyPanelPattern);

            Assert.NotNull(newCraftingRecipe);
        }

        [Fact]
        public void InvalidCraftingRecipeIDsThrowTest()
        {
            var badCraftingRecipeID = TestEntities.TestBlock.ID - 1;

            void TestCode()
            {
                var _ = new CraftingRecipe(badCraftingRecipeID, "will fail",
                                           TestEntities.TestItem.ID, 1, ingredientList,
                                           emptyPanelPattern);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }

        [Fact]
        public void InvalidItemProducedIDsThrowTest()
        {
            var badItemRecipeID = TestEntities.TestBlock.ID - 1;

            void TestCode()
            {
                var _ = new CraftingRecipe(newCraftingRecipeID, "will fail",
                                           badItemRecipeID, 1, ingredientList,
                                           emptyPanelPattern);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }

        [Fact]
        public void NonPositiveQuantiesProducedThrowTest()
        {
            var badQuanitityProducedZero = 0;
            var badQuanitityProducedNegativeOne = -1;

            void TestCodeZero()
            {
                var _ = new CraftingRecipe(newCraftingRecipeID, "will fail",
                                           TestEntities.TestItem.ID, badQuanitityProducedZero,
                                           ingredientList, emptyPanelPattern);
            }

            void TestCodeNegativeOne()
            {
                var _ = new CraftingRecipe(newCraftingRecipeID, "will fail",
                                           TestEntities.TestItem.ID, badQuanitityProducedNegativeOne,
                                           ingredientList, emptyPanelPattern);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCodeZero);
            Assert.Throws<ArgumentOutOfRangeException>(TestCodeNegativeOne);
        }

        [Fact]
        public void NullAndEmptyIngredientListsThrowTest()
        {
            var emptyIngredientList = new List<EntityID>();

            void TestCodeNull()
            {
                var _ = new CraftingRecipe(newCraftingRecipeID, "will fail",
                                           TestEntities.TestItem.ID, 1,
                                           null, emptyPanelPattern);
            }

            void TestCodeEmpty()
            {
                var _ = new CraftingRecipe(newCraftingRecipeID, "will fail",
                                           TestEntities.TestItem.ID, 1,
                                           emptyIngredientList, emptyPanelPattern);
            }

            Assert.Throws<ArgumentNullException>(TestCodeNull);
            Assert.Throws<IndexOutOfRangeException>(TestCodeEmpty);
        }

        [Fact]
        public void NonItemIngredientListsThrowTest()
        {
            var badIngredientList = new List<EntityID>
            {
                TestEntities.TestCollectible.ID,
            };

            void TestCode()
            {
                var _ = new CraftingRecipe(newCraftingRecipeID, "will fail",
                                           TestEntities.TestItem.ID, 1,
                                           badIngredientList, emptyPanelPattern);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }


        [Fact]
        public void NullPanelPatternsThrowTest()
        {
            void TestCode()
            {
                var _ = new CraftingRecipe(newCraftingRecipeID, "will fail",
                                           TestEntities.TestItem.ID, 1,
                                           ingredientList, null);
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
                var _ = new CraftingRecipe(newCraftingRecipeID, "will fail",
                                           TestEntities.TestItem.ID, 1,
                                           ingredientList, patternTooWide);
            }

            void TestCodeTooHigh()
            {
                var _ = new CraftingRecipe(newCraftingRecipeID, "will fail",
                                           TestEntities.TestItem.ID, 1,
                                           ingredientList, patternTooHigh);
            }

            void TestCodeTooSmall()
            {
                var _ = new CraftingRecipe(newCraftingRecipeID, "will fail",
                                           TestEntities.TestItem.ID, 1,
                                           ingredientList, patternTooSmall);
            }

            Assert.Throws<IndexOutOfRangeException>(TestCodeTooWide);
            Assert.Throws<IndexOutOfRangeException>(TestCodeTooHigh);
            Assert.Throws<IndexOutOfRangeException>(TestCodeTooSmall);
        }
    }
}
