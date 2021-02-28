using System;
using Parquet;
using Parquet.Parquets;
using Xunit;

namespace ParquetUnitTests.Parquets
{
    /// <summary>
    /// Unit tests <see cref="CollectibleModel"/>.
    /// </summary>
    public class CollectibleModelUnitTest
    {
        #region Test Values
        /// <summary>Identifier used when creating a new collectible.</summary>
        private static readonly ModelID newCollectibleID = TestModels.TestCollectible.ID - 1;
        #endregion

        [Fact]
        internal void ValidCollectibleIDsArePermittedTest()
        {
            var testCollectible = new CollectibleModel(newCollectibleID, "will be created", "", "");

            Assert.NotNull(testCollectible);
        }

        [Fact]
        internal void InvalidCollectibleIDsRaiseExceptionTest()
        {
            var badCollectibleID = TestModels.TestBlock.ID;

            void TestCode()
            {
                var _ = new CollectibleModel(badCollectibleID, "will fail", "", "");
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }

        [Fact]
        internal void ValidItemIDsArePermittedTest()
        {
            ModelID goodItemID = -All.ItemIDs.Minimum;

            var testBlock = new CollectibleModel(newCollectibleID, "will be created", "", "", null, goodItemID);

            Assert.NotNull(testBlock);
        }

        [Fact]
        internal void InvalidItemIDsRaiseExceptionTest()
        {
            var badItemID = TestModels.TestBlock.ID;

            void TestCode()
            {
                var _ = new CollectibleModel(newCollectibleID, "will fail", "", "", null, badItemID);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }
    }
}
