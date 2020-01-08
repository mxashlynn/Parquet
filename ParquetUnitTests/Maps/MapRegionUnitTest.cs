using System;
using System.Reflection;
using ParquetClassLibrary;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Rooms;
using ParquetClassLibrary.Utilities;
using Xunit;

namespace ParquetUnitTests.Maps
{
    public class MapRegionUnitTest
    {
        #region Values for Tests
        private static readonly Vector2D invalidPosition = new Vector2D(-1, -1);
        private static readonly PCLColor testColor = new PCLColor(255, 128, 26, 230);
        private const string testTitle = "Test Region";
        private const Elevation testStory = Elevation.AboveGround;
        private const int testElevation = -3;
        private static readonly EntityID testID = TestEntities.TestMapRegion.ID;
        private static readonly MapRegion defaultRegion = new MapRegion(TestEntities.TestMapRegion.ID - 2, "", "", "");
        #endregion

        #region Region Map Initialization
        [Fact]
        public void NewDefaultMapRegionTest()
        {
            Assert.Equal(MapRegion.DefaultTitle, defaultRegion.Title);
            Assert.Equal(MapRegion.DefaultColor, defaultRegion.Background);
        }

        [Fact]
        public void NewCustomMapRegionTest()
        {
            var customRegion = new MapRegion(TestEntities.TestMapRegion.ID - 1, testTitle, "", "", 0, testColor, testStory, testElevation);

            Assert.Equal(testTitle, customRegion.Title);
            Assert.Equal(testColor, customRegion.Background);
            Assert.Equal(testStory, customRegion.ElevationLocal);
            Assert.Equal(testElevation, customRegion.ElevationGlobal);
        }
        #endregion

        #region Whole Region Characteristics Editing
        [Fact]
        public void MapRegionMayBeEditedTest()
        {
            var customRegion = new MapRegion(TestEntities.TestMapRegion.ID - 1, testTitle, "", "", 0, testColor, testStory, testElevation);
            IMapRegionEdit editableRegion = customRegion;

            editableRegion.Title = testTitle;
            editableRegion.Background = testColor;
            editableRegion.ElevationLocal = testStory;
            editableRegion.ElevationGlobal = testElevation;

            Assert.Equal(testTitle, customRegion.Title);
            Assert.Equal(testColor, customRegion.Background);
            Assert.Equal(testStory, customRegion.ElevationLocal);
            Assert.Equal(testElevation, customRegion.ElevationGlobal);
        }
        #endregion

        #region Parquets Replacement
        [Fact]
        public void TrySetFloorFailsOnInvalidPositionTest()
        {
            var parquet = TestEntities.TestFloor.ID;

            var result = TestEntities.TestMapRegion.TrySetFloorDefinition(parquet, invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFloorSucceedsOnDefaultParquetAndPositionTest()
        {
            var parquet = TestEntities.TestFloor.ID;

            var result = TestEntities.TestMapRegion.TrySetFloorDefinition(parquet, Vector2D.Zero);

            Assert.True(result);
            Assert.Equal(parquet, TestEntities.TestMapRegion.GetDefinitionAtPosition(Vector2D.Zero).Floor);
        }

        [Fact]
        public void TrySetBlockFailsOnInvalidPositionTest()
        {
            var parquet = TestEntities.TestBlock.ID;

            var result = TestEntities.TestMapRegion.TrySetBlockDefinition(parquet, invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetBlockSucceedsOnDefaultParquetAndPositionTest()
        {
            var parquet = TestEntities.TestBlock.ID;

            var result = TestEntities.TestMapRegion.TrySetBlockDefinition(parquet, Vector2D.Zero);

            Assert.True(result);
            Assert.Equal(parquet, TestEntities.TestMapRegion.GetDefinitionAtPosition(Vector2D.Zero).Block);
        }

        [Fact]
        public void TrySetFurnishingFailsOnInvalidPositionTest()
        {
            var parquet = TestEntities.TestFurnishing.ID;

            var result = TestEntities.TestMapRegion.TrySetFurnishingDefinition(parquet, invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFurnishingSucceedsOnDefaultParquetAndPositionTest()
        {
            var parquet = TestEntities.TestFurnishing.ID;

            var result = TestEntities.TestMapRegion.TrySetFurnishingDefinition(parquet, Vector2D.Zero);

            Assert.True(result);
            Assert.Equal(parquet, TestEntities.TestMapRegion.GetDefinitionAtPosition(Vector2D.Zero).Furnishing);
        }

        [Fact]
        public void TrySetCollectibleFailsOnInvalidPositionTest()
        {
            var parquet = TestEntities.TestCollectible.ID;

            var result = TestEntities.TestMapRegion.TrySetCollectibleDefinition(parquet, invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetCollectibleSucceedsOnDefaultParquetAndPositionTest()
        {
            var parquet = TestEntities.TestCollectible.ID;

            var result = TestEntities.TestMapRegion.TrySetCollectibleDefinition(parquet, Vector2D.Zero);

            Assert.True(result);
            Assert.Equal(parquet, TestEntities.TestMapRegion.GetDefinitionAtPosition(Vector2D.Zero).Collectible);
        }

        [Fact]
        public void TrySetParquetDefinitionSucceedsWithMapSpaceTest()
        {
            var stack = new ParquetStack(TestEntities.TestFloor.ID,
                                         TestEntities.TestBlock.ID,
                                         TestEntities.TestFurnishing.ID,
                                         TestEntities.TestCollectible.ID);
            var space = new MapSpace(Vector2D.Zero, stack, null);

            var result = TestEntities.TestMapRegion.TrySetParquetDefinition(space);

            Assert.True(result);
            Assert.Equal(stack, TestEntities.TestMapRegion.GetDefinitionAtPosition(Vector2D.Zero));
        }
        #endregion

        #region Special Location
        [Fact]
        public void TrySetExitPointSucceedsOnValidPositionTest()
        {
            var point = new ExitPoint(Vector2D.Zero, TestEntities.TestMapRegion.ID);

            var result = TestEntities.TestMapRegion.TrySetExitPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveExitPointFailsOnInvalidPositionTest()
        {
            var point = new ExitPoint(invalidPosition, testID);

            var result = TestEntities.TestMapRegion.TryRemoveExitPoint(point);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveExitPointFailsOnExitPointMissingTest()
        {
            var point = new ExitPoint(Vector2D.Zero, testID);

            var result = TestEntities.TestMapRegion.TryRemoveExitPoint(point);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveExitPointSucceedsOnExitPointExistsTest()
        {
            var point = new ExitPoint(Vector2D.Zero, testID);
            TestEntities.TestMapRegion.TrySetExitPoint(point);

            var result = TestEntities.TestMapRegion.TryRemoveExitPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void GetExitsReturnsNullsOnInvalidPositionTest()
        {
            var specialData = TestEntities.TestMapRegion.GetExitsAtPosition(invalidPosition);

            Assert.Empty(specialData);
        }
        #endregion

        #region State Queries
        [Fact]
        public void GetDefinitionReturnsThrowsOnInvalidPositionTest()
        {
            void TestCode()
            {
                var _ = TestEntities.TestMapRegion.GetDefinitionAtPosition(invalidPosition);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }

        [Fact]
        public void GetDefinitionReturnsNoneOnEmptyMapTest()
        {
            var result = MapRegion.Empty.GetDefinitionAtPosition(Vector2D.Zero);

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
            var originalChunk = typeof(MapRegion)
                                .GetProperty("ParquetDefintion", BindingFlags.NonPublic | BindingFlags.Instance)
                                ?.GetValue(defaultRegion) as ParquetStackGrid;
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
            var originalChunk = typeof(MapRegion)
                                .GetProperty("ParquetDefintion", BindingFlags.NonPublic | BindingFlags.Instance)
                                ?.GetValue(defaultRegion) as ParquetStackGrid;

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
