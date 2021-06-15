using System;
using Parquet;
using Parquet.Parquets;
using Xunit;

namespace ParquetUnitTests.Parquets
{
    /// <summary>
    /// Unit tests <see cref="BlockModel"/>.
    /// </summary>
    public class BlockModelUnitTest
    {
        #region Test Values
        /// <summary>Identifier used when creating a new block.</summary>
        private static readonly ModelID newBlockID = TestModels.TestBlock.ID - 1;
        #endregion

        [Fact]
        internal void ValidBlockIDsArePermittedTest()
        {
            var testBlock = new BlockModel(newBlockID, "will be created", "", "");

            Assert.NotNull(testBlock);
        }

        [Fact]
        internal void InvalidBlockIDsRaiseExceptionTest()
        {
            var badBlockID = TestModels.TestFloor.ID;

            void TestCode()
            {
                var _ = new BlockModel(badBlockID, "will fail", "", "");
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }

        [Fact]
        internal void ValidItemIDsArePermittedTest()
        {
            ModelID goodItemID = -All.ItemIDs.Minimum;

            var testBlock = new BlockModel(newBlockID, "will be created", "", "", null, goodItemID);

            Assert.NotNull(testBlock);
        }

        [Fact]
        internal void InvalidItemIDsRaiseExceptionTest()
        {
            var badItemID = TestModels.TestBlock.ID;

            void TestCode()
            {
                var _ = new BlockModel(newBlockID, "will fail", "", "", null, badItemID);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }

        [Fact]
        internal void ValidCollectibleIDsArePermittedTest()
        {
            var goodCollectibleID = TestModels.TestCollectible.ID;

            var testBlock = new BlockModel(newBlockID, "will be created", "", "", collectibleID: goodCollectibleID);

            Assert.NotNull(testBlock);
        }

        [Fact]
        internal void InvalidCollectibleIDsRaiseExceptionTest()
        {
            var badCollectibleID = TestModels.TestBlock.ID;

            void TestCode()
            {
                var _ = new BlockModel(newBlockID, "will fail", "", "", collectibleID: badCollectibleID);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }
    }
}
