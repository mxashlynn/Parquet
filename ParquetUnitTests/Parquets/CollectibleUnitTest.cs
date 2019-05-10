using System;
using ParquetClassLibrary;
using ParquetClassLibrary.Parquets;
using Xunit;

namespace ParquetUnitTests.Parquets
{
    public class CollectibleUnitTest
    {
        #region Test Values
        /// <summary>Identifier used when creating a new collectible.</summary>
        private static readonly EntityID newCollectibleID = TestEntities.TestCollectible.ID - 1;
        #endregion

        [Fact]
        public void ValidCollectibleIDsArePermittedTest()
        {
            var testCollectible = new Collectible(newCollectibleID, "will be created", "", "");

            Assert.NotNull(testCollectible);
        }

        [Fact]
        public void InvalidCollectibleIDsRaiseExceptionTest()
        {
            var badCollectibleID = TestEntities.TestBlock.ID;

            void TestCode()
            {
                var _ = new Collectible(badCollectibleID, "will fail", "", "");
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }

        [Fact]
        public void ValidItemIDsArePermittedTest()
        {
            EntityID goodItemID = -All.ItemIDs.Minimum;

            var testBlock = new Collectible(newCollectibleID, "will be created", "", "", goodItemID);

            Assert.NotNull(testBlock);
        }

        [Fact]
        public void InvalidItemIDsRaiseExceptionTest()
        {
            var badItemID = TestEntities.TestBlock.ID;

            void TestCode()
            {
                var _ = new Collectible(newCollectibleID, "will fail", "", "", badItemID);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }
    }
}
