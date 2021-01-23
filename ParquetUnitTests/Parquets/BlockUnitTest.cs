using System;
using Parquet;
using Parquet.Parquets;
using Xunit;

namespace ParquetUnitTests.Parquets
{
    public class BlockUnitTest
    {
        #region Test Values
        /// <summary>Identifier used when creating a new block.</summary>
        private static readonly ModelID newBlockID = TestModels.TestBlock.ID - 1;
        #endregion

        [Fact]
        public void ValidBlockIDsArePermittedTest()
        {
            var testBlock = new BlockModel(newBlockID, "will be created", "", "");

            Assert.NotNull(testBlock);
        }

        [Fact]
        public void InvalidBlockIDsRaiseExceptionTest()
        {
            var badBlockID = TestModels.TestFloor.ID;

            void TestCode()
            {
                var _ = new BlockModel(badBlockID, "will fail", "", "");
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }

        [Fact]
        public void ValidItemIDsArePermittedTest()
        {
            ModelID goodItemID = -All.ItemIDs.Minimum;

            var testBlock = new BlockModel(newBlockID, "will be created", "", "", goodItemID);

            Assert.NotNull(testBlock);
        }

        [Fact]
        public void InvalidItemIDsRaiseExceptionTest()
        {
            var badItemID = TestModels.TestBlock.ID;

            void TestCode()
            {
                var _ = new BlockModel(newBlockID, "will fail", "", "", badItemID);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }

        [Fact]
        public void ValidCollectibleIDsArePermittedTest()
        {
            var goodCollectibleID = TestModels.TestCollectible.ID;

            var testBlock = new BlockModel(newBlockID, "will be created", "", "", inCollectibleID: goodCollectibleID);

            Assert.NotNull(testBlock);
        }

        [Fact]
        public void InvalidCollectibleIDsRaiseExceptionTest()
        {
            var badCollectibleID = TestModels.TestBlock.ID;

            void TestCode()
            {
                var _ = new BlockModel(newBlockID, "will fail", "", "", inCollectibleID: badCollectibleID);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }
    }
}
