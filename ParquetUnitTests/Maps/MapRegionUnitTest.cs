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
        private static readonly EntityID testID = TestModels.TestMapRegion.ID;
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

        #region Parquets Replacement
        [Fact]
        public void TrySetFloorFailsOnInvalidPositionTest()
        {
            var parquet = TestModels.TestFloor.ID;

            var result = TestModels.TestMapRegion.TrySetFloorDefinition(parquet, invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFloorSucceedsOnDefaultParquetAndPositionTest()
        {
            var parquet = TestModels.TestFloor.ID;

            var result = TestModels.TestMapRegion.TrySetFloorDefinition(parquet, Vector2D.Zero);

            Assert.True(result);
            Assert.Equal(parquet, TestModels.TestMapRegion.GetDefinitionAtPosition(Vector2D.Zero).Floor);
        }

        [Fact]
        public void TrySetBlockFailsOnInvalidPositionTest()
        {
            var parquet = TestModels.TestBlock.ID;

            var result = TestModels.TestMapRegion.TrySetBlockDefinition(parquet, invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetBlockSucceedsOnDefaultParquetAndPositionTest()
        {
            var parquet = TestModels.TestBlock.ID;

            var result = TestModels.TestMapRegion.TrySetBlockDefinition(parquet, Vector2D.Zero);

            Assert.True(result);
            Assert.Equal(parquet, TestModels.TestMapRegion.GetDefinitionAtPosition(Vector2D.Zero).Block);
        }

        [Fact]
        public void TrySetFurnishingFailsOnInvalidPositionTest()
        {
            var parquet = TestModels.TestFurnishing.ID;

            var result = TestModels.TestMapRegion.TrySetFurnishingDefinition(parquet, invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFurnishingSucceedsOnDefaultParquetAndPositionTest()
        {
            var parquet = TestModels.TestFurnishing.ID;

            var result = TestModels.TestMapRegion.TrySetFurnishingDefinition(parquet, Vector2D.Zero);

            Assert.True(result);
            Assert.Equal(parquet, TestModels.TestMapRegion.GetDefinitionAtPosition(Vector2D.Zero).Furnishing);
        }

        [Fact]
        public void TrySetCollectibleFailsOnInvalidPositionTest()
        {
            var parquet = TestModels.TestCollectible.ID;

            var result = TestModels.TestMapRegion.TrySetCollectibleDefinition(parquet, invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetCollectibleSucceedsOnDefaultParquetAndPositionTest()
        {
            var parquet = TestModels.TestCollectible.ID;

            var result = TestModels.TestMapRegion.TrySetCollectibleDefinition(parquet, Vector2D.Zero);

            Assert.True(result);
            Assert.Equal(parquet, TestModels.TestMapRegion.GetDefinitionAtPosition(Vector2D.Zero).Collectible);
        }

        [Fact]
        public void TrySetParquetDefinitionSucceedsWithMapSpaceTest()
        {
            var stack = new ParquetStack(TestModels.TestFloor.ID,
                                         TestModels.TestBlock.ID,
                                         TestModels.TestFurnishing.ID,
                                         TestModels.TestCollectible.ID);
            var space = new MapSpace(Vector2D.Zero, stack, null);

            var result = TestModels.TestMapRegion.TrySetParquetDefinition(space);

            Assert.True(result);
            Assert.Equal(stack, TestModels.TestMapRegion.GetDefinitionAtPosition(Vector2D.Zero));
        }
        #endregion

        #region Special Location
        [Fact]
        public void TrySetExitPointSucceedsOnValidPositionTest()
        {
            var point = new ExitPoint(Vector2D.Zero, TestModels.TestMapRegion.ID);

            var result = TestModels.TestMapRegion.TrySetExitPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveExitPointFailsOnInvalidPositionTest()
        {
            var map = new MapRegion(-All.MapRegionIDs.Minimum - 1, "Unused Region 1", "Test", "Test");
            var point = new ExitPoint(invalidPosition, testID);

            var result = map.TryRemoveExitPoint(point);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveExitPointFailsOnExitPointMissingTest()
        {
            var map = new MapRegion(-All.MapRegionIDs.Minimum - 2, "Unused Region 2", "Test", "Test");
            var point = new ExitPoint(Vector2D.Zero, testID - 1);

            var result = map.TryRemoveExitPoint(point);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveExitPointSucceedsOnExitPointExistsTest()
        {
            var point = new ExitPoint(Vector2D.Zero, testID);
            TestModels.TestMapRegion.TrySetExitPoint(point);

            var result = TestModels.TestMapRegion.TryRemoveExitPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void GetExitsReturnsNullsOnInvalidPositionTest()
        {
            IReadOnlyList<ExitPoint> specialData = TestModels.TestMapRegion.GetExitsAtPosition(invalidPosition);

            Assert.Empty(specialData);
        }
        #endregion

        #region State Queries
        [Fact]
        public void GetDefinitionReturnsThrowsOnInvalidPositionTest()
        {
            void TestCode()
            {
                var _ = TestModels.TestMapRegion.GetDefinitionAtPosition(invalidPosition);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }

        [Fact]
        public void GetDefinitionReturnsNoneOnEmptyMapTest()
        {
            ParquetStack result = MapRegion.Empty.GetDefinitionAtPosition(Vector2D.Zero);

            Assert.Equal(EntityID.None, result.Floor);
            Assert.Equal(EntityID.None, result.Block);
            Assert.Equal(EntityID.None, result.Furnishing);
            Assert.Equal(EntityID.None, result.Collectible);
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
                                .GetProperty("ParquetDefinitions", BindingFlags.NonPublic | BindingFlags.Instance)
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
                                .GetProperty("ParquetDefinitions", BindingFlags.NonPublic | BindingFlags.Instance)
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
