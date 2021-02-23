using Parquet;
using Parquet.Regions;
using Xunit;

namespace ParquetUnitTests.Maps
{
    public class RegionModelUnitTest
    {
        #region Values for Tests
        private static readonly Vector2D invalidPosition = new Vector2D(-1, -1);
        private const string testColor = "#FF8822EE";
        private const string testName = "Test Region";
        private static readonly RegionModel defaultRegion = new RegionModel(TestModels.TestMapRegionModel.ID - 1,
                                                                                  nameof(RegionModelUnitTest.defaultRegion),
                                                                                  "", "");
        #endregion

        #region Region Map Initialization
        [Fact]
        public void NewDefaultMapRegionModelTest()
        {
            Assert.Equal(RegionModel.DefaultColor, defaultRegion.BackgroundColor);
        }

        [Fact]
        public void NewCustomMapRegionModelTest()
        {
            var customRegion = new RegionModel(TestModels.TestMapRegionModel.ID - 1, testName, "", "", null, testColor);

            Assert.Equal(testName, customRegion.Name);
            Assert.Equal(testColor, customRegion.BackgroundColor);
        }
        #endregion

        #region Whole Region Characteristics Editing
        [Fact]
        public void MapRegionModelMayBeEditedTest()
        {
            if (LibraryState.IsDebugMode)
            {
                var customRegion = new RegionModel(TestModels.TestMapRegionModel.ID - 1, testName, "", "", null, testColor);
                IMutableRegionModel editableRegion = customRegion;

                editableRegion.Name = testName;
                editableRegion.BackgroundColor = testColor;

                Assert.Equal(testName, customRegion.Name);
                Assert.Equal(testColor, customRegion.BackgroundColor);
            }
        }
        #endregion
    }
}
