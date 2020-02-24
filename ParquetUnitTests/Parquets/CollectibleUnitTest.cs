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
        private static readonly ModelID newCollectibleID = TestModels.TestCollectible.ID - 1;
        #endregion

        [Fact]
        public void ValidCollectibleIDsArePermittedTest()
        {
            var testCollectible = new CollectibleModel(newCollectibleID, "will be created", "", "");

            Assert.NotNull(testCollectible);
        }

        [Fact]
        public void InvalidCollectibleIDsRaiseExceptionTest()
        {
            var badCollectibleID = TestModels.TestBlock.ID;

            void TestCode()
            {
                var _ = new CollectibleModel(badCollectibleID, "will fail", "", "");
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }

        [Fact]
        public void ValidItemIDsArePermittedTest()
        {
            ModelID goodItemID = -All.ItemIDs.Minimum;

            var testBlock = new CollectibleModel(newCollectibleID, "will be created", "", "", goodItemID);

            Assert.NotNull(testBlock);
        }

        [Fact]
        public void InvalidItemIDsRaiseExceptionTest()
        {
            var badItemID = TestModels.TestBlock.ID;

            void TestCode()
            {
                var _ = new CollectibleModel(newCollectibleID, "will fail", "", "", badItemID);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }
    }
}
