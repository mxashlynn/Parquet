using System;
using System.Collections.Generic;
using System.Reflection;
using ParquetClassLibrary;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Rooms;
using Xunit;

namespace ParquetUnitTests.Maps
{
    public class MapRegionUnitTest
    {
        #region Values for Tests
        private static readonly Vector2D invalidPosition = new Vector2D(-1, -1);
        private const string testColor = "#FF8822EE";
        private const string testName = "Test Region";
        private const Elevation testStory = Elevation.AboveGround;
        private const int testElevation = -3;
        private static readonly ModelID testID = TestModels.TestMapRegion.ID;
        private static readonly MapRegion defaultRegion = new MapRegion(TestModels.TestMapRegion.ID - 1, "", "", "");
        #endregion

        #region Region Map Initialization
        [Fact]
        public void NewDefaultMapRegionTest()
        {
            Assert.Equal(MapRegion.DefaultName, defaultRegion.Name);
            Assert.Equal(MapRegion.DefaultColor, defaultRegion.BackgroundColor);
        }

        [Fact]
        public void NewCustomMapRegionTest()
        {
            var customRegion = new MapRegion(TestModels.TestMapRegion.ID - 1, testName, "", "",
                                             AssemblyInfo.SupportedMapDataVersion, 0, testColor, testStory, testElevation);

            Assert.Equal(testName, customRegion.Name);
            Assert.Equal(testColor, customRegion.BackgroundColor);
            Assert.Equal(testStory, customRegion.ElevationLocal);
            Assert.Equal(testElevation, customRegion.ElevationGlobal);
        }
        #endregion

        #region Whole Region Characteristics Editing
        [Fact]
        public void MapRegionMayBeEditedTest()
        {
            var customRegion = new MapRegion(TestModels.TestMapRegion.ID - 1, testName, "", "", AssemblyInfo.SupportedMapDataVersion,
                                             0, testColor, testStory, testElevation);
            IMapRegionEdit editableRegion = customRegion;

            editableRegion.Name = testName;
            editableRegion.BackgroundColor = testColor;
            editableRegion.ElevationLocal = testStory;
            editableRegion.ElevationGlobal = testElevation;

            Assert.Equal(testName, customRegion.Name);
            Assert.Equal(testColor, customRegion.BackgroundColor);
            Assert.Equal(testStory, customRegion.ElevationLocal);
            Assert.Equal(testElevation, customRegion.ElevationGlobal);
        }
        #endregion

        #region Subregions
        [Fact]
        public void GetSubregionThrowsOnInvalidUpperLeftTest()
        {
            Vector2D invalidUpperLeft = invalidPosition;
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
            Vector2D validUpperLeft = Vector2D.Zero;
            Vector2D invalidLowerRight = defaultRegion.DimensionsInParquets;

            void InvalidSubregion()
            {
                var _ = defaultRegion.GetSubregion(validUpperLeft, invalidLowerRight);
            }

            Assert.Throws<ArgumentOutOfRangeException>(InvalidSubregion);
        }

        [Fact]
        public void GetSubregionThrowsOnInvalidOrderingTest()
        {
            Vector2D validUpperLeft = Vector2D.Zero;
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
            var originalChunk = typeof(MapRegion)
                                .GetProperty("ParquetDefinitions", BindingFlags.Public | BindingFlags.Instance)
                                ?.GetValue(defaultRegion) as ParquetStackGrid;
            var validUpperLeft = new Vector2D(1, 4);
            var validLowerRight = new Vector2D(10, 14);

            ParquetStackGrid subregion = defaultRegion.GetSubregion();

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
            var originalChunk = typeof(MapRegion)
                                .GetProperty("ParquetDefinitions", BindingFlags.Public | BindingFlags.Instance)
                                ?.GetValue(defaultRegion) as ParquetStackGrid;

            ParquetStackGrid subregion = defaultRegion.GetSubregion();

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
