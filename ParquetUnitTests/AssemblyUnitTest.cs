using Xunit;
using System;
using ParquetClassLibrary;
using ParquetClassLibrary.Sandbox.ID;

namespace ParquetUnitTests
{
    public class AssemblyUnitTest
    {
        #region Values for Tests
        private const string invalidDataVersion = "0.0.0";
        private const int upperBound = 10;
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
            // TODO Does this type of sanity check make sense?
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
        public void NoneIsAValidCollectableTest()
        {
            var result = EntityID.None.IsValidForRange(Assembly.CollectableIDs);

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
        public void MinimumIsAValidCollectableTest()
        {
            var range = Assembly.CollectableIDs;
            var collectable = range.Minimum;
            var result = collectable.IsValidForRange(range);

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
