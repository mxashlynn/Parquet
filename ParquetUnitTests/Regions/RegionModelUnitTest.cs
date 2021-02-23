using System;
using System.Reflection;
using Parquet;
using Parquet.Regions;
using Parquet.Parquets;
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

        #region Subregions
        [Fact]
        public void GetSubregionThrowsOnInvalidUpperLeftTest()
        {
            var invalidUpperLeft = invalidPosition;
            var validLowerRight = new Vector2D(defaultRegion.DimensionsInParquets.X - 1,
                                                 defaultRegion.DimensionsInParquets.Y - 1);

            void InvalidSubregion()
            {
                var _ = defaultRegion.GetSubregion(invalidUpperLeft, validLowerRight);
            }

            Assert.Throws<ArgumentOutOfRangeException>(InvalidSubregion);
        }

        [Fact]
        public void GetSubregionThrowsOnInvalidLowerRightTest()
        {
            var validUpperLeft = Vector2D.Zero;
            var invalidLowerRight = defaultRegion.DimensionsInParquets;

            void InvalidSubregion()
            {
                var _ = defaultRegion.GetSubregion(validUpperLeft, invalidLowerRight);
            }

            Assert.Throws<ArgumentOutOfRangeException>(InvalidSubregion);
        }

        [Fact]
        public void GetSubregionThrowsOnInvalidOrderingTest()
        {
            var validUpperLeft = Vector2D.Zero;
            var validLowerRight = new Vector2D(defaultRegion.DimensionsInParquets.X - 1,
                                                 defaultRegion.DimensionsInParquets.Y - 1);

            void InvalidSubregion()
            {
                var _ = defaultRegion.GetSubregion(validLowerRight, validUpperLeft);
            }

            Assert.Throws<ArgumentException>(InvalidSubregion);
        }

        [Fact]
        public void GetSubregionMatchesPattern()
        {
            var originalChunk = (ParquetModelPackGrid)(typeof(RegionModel)
                                .GetProperty("ParquetDefinitions", BindingFlags.Public | BindingFlags.Instance)
                                ?.GetValue(defaultRegion));
            var validUpperLeft = new Vector2D(1, 4);
            var validLowerRight = new Vector2D(10, 14);

            var subregion = defaultRegion.GetSubregion();

            for (var x = validUpperLeft.X; x < validLowerRight.X; x++)
            {
                for (var y = validUpperLeft.Y; y < validLowerRight.Y; y++)
                {
                    Assert.Equal(originalChunk[y, x], subregion[y, x]);
                }
            }
        }

        [Fact]
        public void GetSubregionOnWholeSubregionMatchesPattern()
        {
            var originalChunk = (ParquetModelPackGrid)(typeof(RegionModel)
                                .GetProperty("ParquetDefinitions", BindingFlags.Public | BindingFlags.Instance)
                                ?.GetValue(defaultRegion));

            var subregion = defaultRegion.GetSubregion();

            for (var x = 0; x < defaultRegion.DimensionsInParquets.X; x++)
            {
                for (var y = 0; y < defaultRegion.DimensionsInParquets.Y; y++)
                {
                    Assert.Equal(originalChunk[y, x], subregion[y, x]);
                }
            }
        }
        #endregion
    }
}