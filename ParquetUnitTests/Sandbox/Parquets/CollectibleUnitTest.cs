using System;
using ParquetClassLibrary;
using ParquetClassLibrary.Sandbox.Parquets;
using Xunit;

namespace ParquetUnitTests.Sandbox.Parquets
{
    public class CollectibleUnitTest
    {
        #region Test Values
        /// <summary>Identifier used when creating a new collectible.</summary>
        private static readonly EntityID newCollectibleID = TestParquets.TestCollectible.ID - 1;
        #endregion

        [Fact]
        public void ValidCollectibleIDsArePermittedTest()
        {
            var testCollectible = new Collectible(newCollectibleID, "will be created");

            Assert.NotNull(testCollectible);
        }

        [Fact]
        public void InvalidCollectibleIDsRaiseExceptionTest()
        {
            var badCollectibleID = TestParquets.TestBlock.ID;

            void TestCode()
            {
                var _ = new Collectible(badCollectibleID, "will fail");
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }

        [Fact]
        public void ValidItemIDsArePermittedTest()
        {
            // TODO When we have a cannonical source of item IDs, use that instead.
            EntityID goodItemID = -50000;

            var testBlock = new Collectible(newCollectibleID, "will be created", in_itemID: goodItemID);

            Assert.NotNull(testBlock);
        }

        [Fact]
        public void InvalidItemIDsRaiseExceptionTest()
        {
            var badItemID = TestParquets.TestBlock.ID;

            void TestCode()
            {
                var _ = new Collectible(newCollectibleID, "will fail", in_itemID: badItemID);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }
    }
}
