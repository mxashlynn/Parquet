using ParquetClassLibrary;
using Xunit;

namespace ParquetUnitTests
{
    public class AssemblyInfoUnitTest
    {
        #region Values for Tests
        /// <summary>This is the cannonical invalid version string used in serialization tests.</summary>
        private const string invalidDataVersion = "0.0.0";
        #endregion

        [Fact]
        public void SupportedMapDataVersionIsDefinedTest()
        {
            Assert.False(string.IsNullOrEmpty(AssemblyInfo.SupportedMapDataVersion));
        }

        [Fact]
        public void SupportedMapDataVersionIsNotInvalidTest()
        {
            Assert.NotEqual(invalidDataVersion, AssemblyInfo.SupportedMapDataVersion);
        }

        [Fact]
        public void SupportedCharacterDataVersionIsDefinedTest()
        {
            Assert.False(string.IsNullOrEmpty(AssemblyInfo.SupportedBeingDataVersion));
        }

        [Fact]
        public void SupportedCharacterDataVersionIsNotInvalidTest()
        {
            Assert.NotEqual(invalidDataVersion, AssemblyInfo.SupportedBeingDataVersion);
        }
    }
}
