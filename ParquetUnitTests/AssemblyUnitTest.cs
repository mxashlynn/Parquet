using System.Linq;
using System.Collections.Generic;
using ParquetClassLibrary;
using ParquetClassLibrary.Utilities;
using Xunit;

namespace ParquetUnitTests
{
    public class AssemblyUnitTest
    {
        #region Values for Tests
        /// <summary>This is the cannonical invalid version string used in serialization tests.</summary>
        private const string invalidDataVersion = "0.0.0";

        /// <summary>
        /// The highest <see cref="Range{EntityID}.Maximum"/> defined in <see cref="AssemblyInfo"/>
        /// except for <see cref="AssemblyInfo.ItemIDs"/>.Maximum.
        /// </summary>
        public static readonly EntityID MaximumIDRangeUpperLimit = typeof(AssemblyInfo).GetFields()
            .Where(fieldInfo => fieldInfo.FieldType.IsGenericType
                && fieldInfo.FieldType == typeof(Range<EntityID>)
                && fieldInfo.Name != nameof(AssemblyInfo.ItemIDs))
            .Select(fieldInfo => fieldInfo.GetValue(null))
            .Cast<Range<EntityID>>()
            .Select(range => range.Maximum)
            .Max();
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
                         && AssemblyInfo.ParquetsPerRegionDimension > 0
                         && AssemblyInfo.PanelPatternWidth > 0
                         && AssemblyInfo.PanelPatternHeight > 0;
            Assert.True(result);
        }

        [Fact]
        public void ItemIDMinimumIsGreaterThanMaximumDefinedRangeUpperBoundTest()
        {
            Assert.True(AssemblyInfo.ItemIDs.Minimum > MaximumIDRangeUpperLimit);
        }
    }
}
