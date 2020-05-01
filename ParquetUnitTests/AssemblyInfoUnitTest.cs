using ParquetClassLibrary;
using Xunit;

namespace ParquetUnitTests
{
    public class AssemblyInfoUnitTest
    {
        #region Values for Tests
        /// <summary>This is the cannonical invalid data version string used in serialization tests.</summary>
        private const string invalidDataVersion = "0.0";

        /// <summary>This is the cannonical invalid library version string used in serialization tests.</summary>
        private const string invalidLibVersion = "0.0.0.0";
        #endregion

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
        public void SupportedScriptDataVersionIsDefinedTest()
        {
            Assert.False(string.IsNullOrEmpty(AssemblyInfo.SupportedScriptDataVersion));
        }

        [Fact]
        public void SupportedScriptDataVersionIsNotInvalidTest()
        {
            Assert.NotEqual(invalidDataVersion, AssemblyInfo.SupportedScriptpDataVersion);
        }

        [Fact]
        public void SupportedLibraryVersionIsDefinedTest()
        {
            Assert.False(string.IsNullOrEmpty(AssemblyInfo.LibraryVersion));
        }

        [Fact]
        public void SupportedLibraryVersionIsNotInvalidTest()
        {
            Assert.NotEqual(invalidLibVersion, AssemblyInfo.LibraryVersion);
        }
    }
}
