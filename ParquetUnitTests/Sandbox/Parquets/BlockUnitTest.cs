using System;
using ParquetClassLibrary;
using ParquetClassLibrary.Sandbox.Parquets;
using Xunit;

namespace ParquetUnitTests.Sandbox.Parquets
{
    public class BlockUnitTest
    {
        #region Test Values
        /// <summary>Identifier used when creating a new block.</summary>
        private static readonly EntityID newBlockID = TestParquets.TestBlock.ID - 1;
        #endregion

        [Fact]
        public void ValidBlockIDsArePermittedTest()
        {
            var testBlock = new Block(newBlockID, "will be created");

            Assert.NotNull(testBlock);
        }

        [Fact]
        public void InvalidBlockIDsRaiseExceptionTest()
        {
            var badBlockID = TestParquets.TestFloor.ID;

            void TestCode()
            {
                var _ = new Block(badBlockID, "will fail");
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }

        [Fact]
        public void ValidItemIDsArePermittedTest()
        {
            EntityID goodItemID = -AssemblyInfo.ItemIDs.Minimum;

            var testBlock = new Block(newBlockID, "will be created", in_itemID: goodItemID);

            Assert.NotNull(testBlock);
        }

        [Fact]
        public void InvalidItemIDsRaiseExceptionTest()
        {
            var badItemID = TestParquets.TestBlock.ID;

            void TestCode()
            {
                var _ = new Block(newBlockID, "will fail", in_itemID: badItemID);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }

        [Fact]
        public void ValidCollectibleIDsArePermittedTest()
        {
            var goodCollectibleID = TestParquets.TestCollectible.ID;

            var testBlock = new Block(newBlockID, "will be created", in_collectibleID: goodCollectibleID);

            Assert.NotNull(testBlock);
        }

        [Fact]
        public void InvalidCollectibleIDsRaiseExceptionTest()
        {
            var badCollectibleID = TestParquets.TestBlock.ID;

            void TestCode()
            {
                var _ = new Block(newBlockID, "will fail", in_collectibleID: badCollectibleID);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }
    }
}
