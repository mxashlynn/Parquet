using ParquetClassLibrary;
using ParquetClassLibrary.Sandbox.ID;
using Xunit;

namespace ParquetUnitTests
{
    public class AssemblyUnitTest
    {
        #region Values for Tests
        private const string invalidDataVersion = "0.0.0";
        #endregion

        [Fact]
        public void SupportedDataVersionIsDefinedTest()
        {
            Assert.False(string.IsNullOrEmpty(Assembly.SupportedDataVersion));
        }

        [Fact]
        public void SupportedDataVersionIsNotInvalidTest()
        {
            Assert.NotEqual(invalidDataVersion, Assembly.SupportedDataVersion);
        }

        [Fact]
        public void AllDimensionsAreGreaterThanZeroTest()
        {
            // ReSharper disable All
            var result = Assembly.ParquetsPerChunkDimension > 0
                         && Assembly.ChunksPerRegionDimension > 0
                         && Assembly.ParquetsPerRegionDimension > 0;
            Assert.True(result);
        }

        [Fact]
        public void NoneIsAValidFloorTest()
        {
            var result = EntityID.None.IsValidForRange(Assembly.FloorIDs);

            Assert.True(result);
        }

        [Fact]
        public void NoneIsAValidBlockTest()
        {
            var result = EntityID.None.IsValidForRange(Assembly.BlockIDs);

            Assert.True(result);
        }

        [Fact]
        public void NoneIsAValidFurnishingTest()
        {
            var result = EntityID.None.IsValidForRange(Assembly.FurnishingIDs);

            Assert.True(result);
        }

        [Fact]
        public void NoneIsAValidCollectibleTest()
        {
            var result = EntityID.None.IsValidForRange(Assembly.CollectibleIDs);

            Assert.True(result);
        }

        [Fact]
        public void NoneIsAValidItemTest()
        {
            var result = EntityID.None.IsValidForRange(Assembly.ItemIDs);

            Assert.True(result);
        }

        [Fact]
        public void MinimumIsAValidFloorTest()
        {
            var range = Assembly.FloorIDs;
            var floor = range.Minimum;
            var result = floor.IsValidForRange(range);

            Assert.True(result);
        }

        [Fact]
        public void MinimumIsAValidBlockTest()
        {
            var range = Assembly.BlockIDs;
            var block = range.Minimum;
            var result = block.IsValidForRange(range);

            Assert.True(result);
        }

        [Fact]
        public void MinimumIsAValidFurnishingTest()
        {
            var range = Assembly.FurnishingIDs;
            var furnishing = range.Minimum;
            var result = furnishing.IsValidForRange(range);

            Assert.True(result);
        }

        [Fact]
        public void MinimumIsAValidCollectibleTest()
        {
            var range = Assembly.CollectibleIDs;
            var collectible = range.Minimum;
            var result = collectible.IsValidForRange(range);

            Assert.True(result);
        }

        [Fact]
        public void MinimumIsAValidItemTest()
        {
            var range = Assembly.ItemIDs;
            var item = range.Minimum;
            var result = item.IsValidForRange(range);

            Assert.True(result);
        }
    }
}
