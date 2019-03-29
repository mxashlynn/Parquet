using System;
using ParquetClassLibrary.Sandbox.ID;
using ParquetClassLibrary.Sandbox.Parquets;
using Xunit;

namespace ParquetUnitTests.Sandbox.Parquets
{
    public class CollectableUnitTest
    {
        #region Test Values
        /// <summary>Identifier used when creating a new collectable.</summary>
        private static readonly EntityID newCollectableID = TestParquets.TestCollectable.ID - 1;
        #endregion

        [Fact]
        public void ValidCollectableIDsArePermittedTest()
        {
            var testCollectable = new Collectable(newCollectableID, "will be created");

            Assert.NotNull(testCollectable);
        }

        [Fact]
        public void InvalidCollectableIDsRaiseExceptionTest()
        {
            var badCollectableID = TestParquets.TestBlock.ID;

            void TestCode()
            {
                var _ = new Collectable(badCollectableID, "will fail");
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }

        [Fact]
        public void ValidItemIDsArePermittedTest()
        {
            // TODO When we have a cannonical source of item IDs, use that instead.
            EntityID goodItemID = -50000;

            var testBlock = new Collectable(newCollectableID, "will be created", in_itemID: goodItemID);

            Assert.NotNull(testBlock);
        }

        [Fact]
        public void InvalidItemIDsRaiseExceptionTest()
        {
            var badItemID = TestParquets.TestBlock.ID;

            void TestCode()
            {
                var _ = new Collectable(newCollectableID, "will fail", in_itemID: badItemID);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }
    }
}
