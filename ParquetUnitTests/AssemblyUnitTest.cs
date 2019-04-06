using ParquetClassLibrary;
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
            Assert.False(string.IsNullOrEmpty(AssemblyInfo.SupportedDataVersion));
        }

        [Fact]
        public void SupportedDataVersionIsNotInvalidTest()
        {
            Assert.NotEqual(invalidDataVersion, AssemblyInfo.SupportedDataVersion);
        }

        [Fact]
        public void AllDimensionsAreGreaterThanZeroTest()
        {
            // ReSharper disable All
            var result = AssemblyInfo.ParquetsPerChunkDimension > 0
                         && AssemblyInfo.ChunksPerRegionDimension > 0
                         && AssemblyInfo.ParquetsPerRegionDimension > 0;
            Assert.True(result);
        }

        [Fact]
        public void NoneIsAValidFloorTest()
        {
            var result = EntityID.None.IsValidForRange(AssemblyInfo.FloorIDs);

            Assert.True(result);
        }

        [Fact]
        public void NoneIsAValidBlockTest()
        {
            var result = EntityID.None.IsValidForRange(AssemblyInfo.BlockIDs);

            Assert.True(result);
        }

        [Fact]
        public void NoneIsAValidFurnishingTest()
        {
            var result = EntityID.None.IsValidForRange(AssemblyInfo.FurnishingIDs);

            Assert.True(result);
        }

        [Fact]
        public void NoneIsAValidCollectibleTest()
        {
            var result = EntityID.None.IsValidForRange(AssemblyInfo.CollectibleIDs);

            Assert.True(result);
        }

        [Fact]
        public void NoneIsAValidItemTest()
        {
            var result = EntityID.None.IsValidForRange(AssemblyInfo.ItemIDs);

            Assert.True(result);
        }

        [Fact]
        public void MinimumIsAValidFloorTest()
        {
            var range = AssemblyInfo.FloorIDs;
            var floor = range.Minimum;
            var result = floor.IsValidForRange(range);

            Assert.True(result);
        }

        [Fact]
        public void MinimumIsAValidBlockTest()
        {
            var range = AssemblyInfo.BlockIDs;
            var block = range.Minimum;
            var result = block.IsValidForRange(range);

            Assert.True(result);
        }

        [Fact]
        public void MinimumIsAValidFurnishingTest()
        {
            var range = AssemblyInfo.FurnishingIDs;
            var furnishing = range.Minimum;
            var result = furnishing.IsValidForRange(range);

            Assert.True(result);
        }

        [Fact]
        public void MinimumIsAValidCollectibleTest()
        {
            var range = AssemblyInfo.CollectibleIDs;
            var collectible = range.Minimum;
            var result = collectible.IsValidForRange(range);

            Assert.True(result);
        }

        [Fact]
        public void MinimumIsAValidItemTest()
        {
            var range = AssemblyInfo.ItemIDs;
            var item = range.Minimum;
            var result = item.IsValidForRange(range);

            Assert.True(result);
        }
    }
}
