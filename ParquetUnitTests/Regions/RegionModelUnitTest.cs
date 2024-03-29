using Parquet;
using Parquet.Regions;
using Xunit;

namespace ParquetUnitTests.Maps
{
    /// <summary>
    /// Unit tests <see cref="RegionModel"/>.
    /// </summary>
    public class RegionModelUnitTest
    {
        #region Values for Tests
        private const string testColor = "#FF8822EE";
        private const string testName = "Test Region";
        private static readonly RegionModel defaultRegion = new(TestModels.TestRegionModel.ID - 1, nameof(defaultRegion), "", "");
        #endregion

        #region Region Map Initialization
        [Fact]
        internal void NewDefaultMapRegionModelTest()
        {
            Assert.Equal(RegionModel.DefaultColor, defaultRegion.BackgroundColor);
        }

        [Fact]
        internal void NewCustomMapRegionModelTest()
        {
            var customRegion = new RegionModel(TestModels.TestRegionModel.ID - 1, testName, "", "", null, testColor);

            Assert.Equal(testName, customRegion.Name);
            Assert.Equal(testColor, customRegion.BackgroundColor);
        }
        #endregion

        #region Whole Region Characteristics Editing
#pragma warning disable IDE0079 // Remove unnecessary suppression -- conditional compilation.
#pragma warning disable CS0162 // Unreachable code detected -- conditional compilation.
        [Fact]
        internal void MapRegionModelMayBeEditedTest()
        {
            if (LibraryState.IsDebugMode)
            {
                var customRegion = new RegionModel(TestModels.TestRegionModel.ID - 1, testName, "", "", null, testColor);
                IMutableRegionModel editableRegion = customRegion;

                editableRegion.Name = testName;
                editableRegion.BackgroundColor = testColor;

                Assert.Equal(testName, customRegion.Name);
                Assert.Equal(testColor, customRegion.BackgroundColor);
            }
        }
#pragma warning restore CS0162 // Unreachable code detected -- conditional compilation.
#pragma warning restore IDE0079 // Remove unnecessary suppression -- conditional compilation.
        #endregion
    }
}
