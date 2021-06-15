using System;
using Parquet;
using Parquet.Parquets;
using Xunit;

namespace ParquetUnitTests.Parquets
{
    /// <summary>
    /// Unit tests <see cref="FurnishingModel"/>.
    /// </summary>
    public class FurnishingModelUnitTest
    {
        #region Test Values
        /// <summary>Identifier used when creating a new furnishing.</summary>
        private static readonly ModelID newFurnishingID = TestModels.TestFurnishing.ID - 1;
        #endregion

        [Fact]
        internal void ValidCollectibleIDsArePermittedTest()
        {
            var testFurnishing = new FurnishingModel(newFurnishingID, "will be created", "", "");

            Assert.NotNull(testFurnishing);
        }

        [Fact]
        internal void InvalidCollectibleIDsRaiseExceptionTest()
        {
            var badFurnishingID = TestModels.TestBlock.ID;

            void TestCode()
            {
                var _ = new FurnishingModel(badFurnishingID, "will fail", "", "");
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }

        [Fact]
        internal void ValidItemIDsArePermittedTest()
        {
            ModelID goodItemID = -All.ItemIDs.Minimum;

            var testBlock = new FurnishingModel(newFurnishingID, "will be created", "", "", null, goodItemID);

            Assert.NotNull(testBlock);
        }

        [Fact]
        internal void InvalidItemIDsRaiseExceptionTest()
        {
            var badItemID = TestModels.TestBlock.ID;

            void TestCode()
            {
                var _ = new FurnishingModel(newFurnishingID, "will fail", "", "", null, badItemID);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }

        [Fact]
        internal void ValidSwapIDsArePermittedTest()
        {
            var goodItemID = newFurnishingID - 1;

            var testBlock = new FurnishingModel(newFurnishingID, "will be created", "", "", itemID: goodItemID);

            Assert.NotNull(testBlock);
        }

        [Fact]
        internal void InvalidSwapIDsRaiseExceptionTest()
        {
            var badItemID = TestModels.TestBlock.ID;

            void TestCode()
            {
                var _ = new FurnishingModel(newFurnishingID, "will fail", "", "", itemID: badItemID);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }
    }
}
