using System;
using ParquetClassLibrary;
using ParquetClassLibrary.Parquets;
using Xunit;

namespace ParquetUnitTests.Sandbox.Parquets
{
    public class FurnishingUnitTest
    {
        #region Test Values
        /// <summary>Identifier used when creating a new furnishing.</summary>
        private static readonly EntityID newFurnishingID = TestEntities.TestFurnishing.ID - 1;
        #endregion

        [Fact]
        public void ValidCollectibleIDsArePermittedTest()
        {
            var testFurnishing = new Furnishing(newFurnishingID, "will be created");

            Assert.NotNull(testFurnishing);
        }

        [Fact]
        public void InvalidCollectibleIDsRaiseExceptionTest()
        {
            var badFurnishingID = TestEntities.TestBlock.ID;

            void TestCode()
            {
                var _ = new Furnishing(badFurnishingID, "will fail");
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }

        [Fact]
        public void ValidItemIDsArePermittedTest()
        {
            EntityID goodItemID = -All.ItemIDs.Minimum;

            var testBlock = new Furnishing(newFurnishingID, "will be created", in_itemID: goodItemID);

            Assert.NotNull(testBlock);
        }

        [Fact]
        public void InvalidItemIDsRaiseExceptionTest()
        {
            var badItemID = TestEntities.TestBlock.ID;

            void TestCode()
            {
                var _ = new Furnishing(newFurnishingID, "will fail", in_itemID: badItemID);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }

        [Fact]
        public void ValidSwapIDsArePermittedTest()
        {
            var goodSwapID = newFurnishingID - 1;

            var testBlock = new Furnishing(newFurnishingID, "will be created", in_swapID: goodSwapID);

            Assert.NotNull(testBlock);
        }

        [Fact]
        public void InvalidSwapIDsRaiseExceptionTest()
        {
            var badSwapID = TestEntities.TestBlock.ID;

            void TestCode()
            {
                var _ = new Furnishing(newFurnishingID, "will fail", in_swapID: badSwapID);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }
    }
}
