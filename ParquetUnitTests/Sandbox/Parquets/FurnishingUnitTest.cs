using System;
using ParquetClassLibrary;
using ParquetClassLibrary.Sandbox.Parquets;
using Xunit;

namespace ParquetUnitTests.Sandbox.Parquets
{
    public class FurnishingUnitTest
    {
        #region Test Values
        /// <summary>Identifier used when creating a new furnishing.</summary>
        private static readonly EntityID newFurnishingID = TestParquets.TestFurnishing.ID - 1;
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
            var badFurnishingID = TestParquets.TestBlock.ID;

            void TestCode()
            {
                var _ = new Furnishing(badFurnishingID, "will fail");
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }

        [Fact]
        public void ValidItemIDsArePermittedTest()
        {
            // TODO When we have a cannonical source of item IDs, use that instead.
            EntityID goodItemID = -50000;

            var testBlock = new Furnishing(newFurnishingID, "will be created", in_itemID: goodItemID);

            Assert.NotNull(testBlock);
        }

        [Fact]
        public void InvalidItemIDsRaiseExceptionTest()
        {
            var badItemID = TestParquets.TestBlock.ID;

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
            var badSwapID = TestParquets.TestBlock.ID;

            void TestCode()
            {
                var _ = new Furnishing(newFurnishingID, "will fail", in_swapID: badSwapID);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }
    }
}
