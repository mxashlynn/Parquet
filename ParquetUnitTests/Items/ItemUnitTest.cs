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
        private static readonly EntityID newItemID = TestModels.TestItem.ID - 1;

        /// <summary>A valid number of <see cref="ItemModel"/>s to stack.</summary>
        private const int goodStackMax = 99;
        #endregion

        [Fact]
        public void ValidCritterIDsArePermittedTest()
        {
            var newItem = new ItemModel(newItemID, "will be created", "", "", ItemType.Consumable,
                                   1, 1, goodStackMax, 0, 0, TestModels.TestBlock.ID);

            Assert.NotNull(newItem);
        }

        [Fact]
        public void InvalidCritterIDsRaiseExceptionTest()
        {
            var badItemID = TestModels.TestBlock.ID - 1;

            void TestCode()
            {
                var _ = new ItemModel(badItemID, "will fail", "", "", ItemType.Consumable,
                                 1, 1, goodStackMax, 0, 0, TestModels.TestBlock.ID);
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
                var _ = new ItemModel(newItemID, "will fail", "", "", ItemType.Consumable,
                                 1, 1, badStackMaxZero, 0, 0, TestModels.TestBlock.ID);
            }

            void TestCodeNegativeOne()
            {
                var _ = new ItemModel(newItemID, "will fail", "", "", ItemType.Consumable,
                                 1, 1, badStackMaxNegativeOne, 0, 0, TestModels.TestBlock.ID);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCodeZero);
            Assert.Throws<ArgumentOutOfRangeException>(TestCodeNegativeOne);
        }
    }
}
