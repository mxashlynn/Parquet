using System;
using Parquet;
using Parquet.Parquets;
using Xunit;

namespace ParquetUnitTests.Parquets
{
    public class FurnishingUnitTest
    {
        #region Test Values
        /// <summary>Identifier used when creating a new furnishing.</summary>
        private static readonly ModelID newFurnishingID = TestModels.TestFurnishing.ID - 1;
        #endregion

        [Fact]
        public void ValidCollectibleIDsArePermittedTest()
        {
            var testFurnishing = new FurnishingModel(newFurnishingID, "will be created", "", "");

            Assert.NotNull(testFurnishing);
        }

        [Fact]
        public void InvalidCollectibleIDsRaiseExceptionTest()
        {
            var badFurnishingID = TestModels.TestBlock.ID;

            void TestCode()
            {
                var _ = new FurnishingModel(badFurnishingID, "will fail", "", "");
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }

        [Fact]
        public void ValidItemIDsArePermittedTest()
        {
            ModelID goodItemID = -All.ItemIDs.Minimum;

            var testBlock = new FurnishingModel(newFurnishingID, "will be created", "", "", goodItemID);

            Assert.NotNull(testBlock);
        }

        [Fact]
        public void InvalidItemIDsRaiseExceptionTest()
        {
            var badItemID = TestModels.TestBlock.ID;

            void TestCode()
            {
                var _ = new FurnishingModel(newFurnishingID, "will fail", "", "", badItemID);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }

        [Fact]
        public void ValidSwapIDsArePermittedTest()
        {
            var goodSwapID = newFurnishingID - 1;

            var testBlock = new FurnishingModel(newFurnishingID, "will be created", "", "", inSwapID: goodSwapID);

            Assert.NotNull(testBlock);
        }

        [Fact]
        public void InvalidSwapIDsRaiseExceptionTest()
        {
            var badSwapID = TestModels.TestBlock.ID;

            void TestCode()
            {
                var _ = new FurnishingModel(newFurnishingID, "will fail", "", "", inSwapID: badSwapID);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }
    }
}
