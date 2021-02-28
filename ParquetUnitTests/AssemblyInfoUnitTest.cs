using System;
using System.Runtime.InteropServices;
using Parquet;
using Xunit;

// Make no promises to maintain internal services.
[assembly: ComVisible(false)]

// ParquetUnitTests are API consumers, not API providers.
[assembly: CLSCompliant(false)]

namespace ParquetUnitTests
{
    /// <summary>
    /// Unit tests <see cref="AssemblyInfo"/>.
    /// </summary>
    public class AssemblyInfoUnitTest
    {
        #region Values for Tests
        /// <summary>This is the canonical invalid library version string used in serialization tests.</summary>
        private const string invalidLibVersion = "0.0.0.0";
        #endregion

        [Fact]
        internal void SupportedLibraryVersionIsDefinedTest()
        {
            Assert.False(string.IsNullOrEmpty(AssemblyInfo.LibraryVersion));
        }

        [Fact]
        internal void SupportedLibraryVersionIsNotInvalidTest()
        {
            Assert.NotEqual(invalidLibVersion, AssemblyInfo.LibraryVersion);
        }
    }
}
