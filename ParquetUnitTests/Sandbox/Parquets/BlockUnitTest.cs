using System;
using ParquetClassLibrary.Sandbox.ID;
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
        public void ToughnessCannotBeSetBelowZeroTest()
        {
            var testBlock = TestParquets.TestBlock;

            testBlock.Toughness = int.MinValue;

            Assert.Equal(Block.LowestPossibleToughness, testBlock.Toughness);
        }

        [Fact]
        public void ToughnessCannotBeAboveMaxToughnessTest()
        {
            var testBlock = TestParquets.TestBlock;
            var priorToughness = testBlock.Toughness;

            testBlock.Toughness = int.MaxValue;

            Assert.Equal(priorToughness, testBlock.Toughness);
        }

        [Fact]
        public void ValidItemIDsArePermittedTest()
        {
            // TODO When we have a cannonical source of item IDs, use that instead.
            EntityID goodItemID = -50000;

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
        public void ValidCollectableIDsArePermittedTest()
        {
            var goodCollectableID = TestParquets.TestCollectable.ID;

            var testBlock = new Block(newBlockID, "will be created", in_collectableID: goodCollectableID);

            Assert.NotNull(testBlock);
        }

        [Fact]
        public void InvalidCollectableIDsRaiseExceptionTest()
        {
            var badCollectableID = TestParquets.TestBlock.ID;

            void TestCode()
            {
                var _ = new Block(newBlockID, "will fail", in_collectableID: badCollectableID);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }
    }
}
