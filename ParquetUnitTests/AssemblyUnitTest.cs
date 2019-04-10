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
    }
}
