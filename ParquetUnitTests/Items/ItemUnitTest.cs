using System;
using ParquetClassLibrary;
using ParquetClassLibrary.Items;
using Xunit;

namespace ParquetUnitTests
{
    public class ItemUnitTest
    {
        #region Test Values
        /// <summary>Identifier used when creating a new block.</summary>
        private static readonly EntityID newItemID = TestEntities.TestItem.ID - 1;

        // TODO: If Inventory provides a default for this, use it instead.
        /// <summary>A valid number of <see cref="Item"/>s to stack.</summary>
        private const int goodStackMax = 99;
        #endregion

        [Fact]
        public void ValidCritterIDsArePermittedTest()
        {
            var newItem = new Item(newItemID, ItemType.Consumable, "will be created", "", "",
                                   1, 1, goodStackMax, 0, 0, TestEntities.TestBlock.ID);

            Assert.NotNull(newItem);
        }

        [Fact]
        public void InvalidCritterIDsRaiseExceptionTest()
        {
            var badItemID = TestEntities.TestBlock.ID - 1;

            void TestCode()
            {
                var _ = new Item(badItemID, ItemType.Consumable, "will fail", "", "",
                                 1, 1, goodStackMax, 0, 0, TestEntities.TestBlock.ID);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }

        [Fact]
        public void StackMaxMustBePositiveTest()
        {
            var badStackMaxZero = 0;
            var badStackMaxNegativeOne = -1;

            void TestCodeZero()
            {
                var _ = new Item(newItemID, ItemType.Consumable, "will fail", "", "",
                                 1, 1, badStackMaxZero, 0, 0, TestEntities.TestBlock.ID);
            }

            void TestCodeNegativeOne()
            {
                var _ = new Item(newItemID, ItemType.Consumable, "will fail", "", "",
                                 1, 1, badStackMaxNegativeOne, 0, 0, TestEntities.TestBlock.ID);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCodeZero);
            Assert.Throws<ArgumentOutOfRangeException>(TestCodeNegativeOne);
        }

        /* TODO This check is a good idea but it's current implementation in Item.cs is improper.
         * See note in that file for details.

        [Fact]
        public void RecipeForGivenItemMustProduceGivenItemTest()
        {
            var recipeForOtherItem = TestEntities.TestCraftingRecipe;

            void TestCode()
            {
                var _ = new Item(newItemID, ItemType.Consumable, "will fail", "", "", 1, 1, goodStackMax, 0, 0,
                                 TestEntities.TestBlock.ID, KeyItem.None, TestEntities.TestCraftingRecipe.ID);
            }

            Assert.Throws<ArgumentException>(TestCode);
        }
        */
    }
}
