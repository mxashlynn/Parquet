using System;
using System.Collections.Generic;
using Parquet;
using Parquet.Items;
using Xunit;

namespace ParquetUnitTests.Items
{
    public class ItemUnitTest
    {
        #region Test Values
        /// <summary>Identifier used when creating a new block.</summary>
        private static readonly ModelID newItemID = TestModels.TestItem1.ID - 1;

        /// <summary>A valid number of <see cref="ItemModel"/>s to stack.</summary>
        private const int goodStackMax = 99;

        /// <summary></summary>
        private static readonly List<ModelTag> TestTagList = new List<ModelTag>() { "Test-Tag" };
        #endregion

        [Fact]
        public void ValidItemIDsArePermittedTest()
        {
            var newItem = new ItemModel(newItemID, "will be created", "", "", TestTagList, ItemType.Consumable,
                                   1, 1, goodStackMax, 0, 0, TestModels.TestBlock.ID);

            Assert.NotNull(newItem);
        }

        [Fact]
        public void InvalidItemIDsRaiseExceptionTest()
        {
            var badItemID = TestModels.TestBlock.ID - 1;

            void TestCode()
            {
                var _ = new ItemModel(badItemID, "will fail", "", "", TestTagList, ItemType.Consumable,
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
                var _ = new ItemModel(newItemID, "will fail", "", "", TestTagList, ItemType.Consumable,
                                 1, 1, badStackMaxZero, 0, 0, TestModels.TestBlock.ID);
            }

            void TestCodeNegativeOne()
            {
                var _ = new ItemModel(newItemID, "will fail", "", "", TestTagList, ItemType.Consumable,
                                 1, 1, badStackMaxNegativeOne, 0, 0, TestModels.TestBlock.ID);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCodeZero);
            Assert.Throws<ArgumentOutOfRangeException>(TestCodeNegativeOne);
        }
    }
}
