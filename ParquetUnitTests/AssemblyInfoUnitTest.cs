using ParquetClassLibrary;
using Xunit;

namespace ParquetUnitTests
{
    public class AssemblyInfoUnitTest
    {
        #region Values for Tests
        /// <summary>This is the cannonical invalid library version string used in serialization tests.</summary>
        private const string invalidLibVersion = "0.0.0.0";
        #endregion

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
