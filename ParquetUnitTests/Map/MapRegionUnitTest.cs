using System;
using System.Reflection;
using ParquetClassLibrary;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Utilities;
using Xunit;

namespace ParquetUnitTests.Map
{
    public class MapRegionUnitTest
    {
        #region Values for Tests
        private static readonly Vector2D invalidPosition = new Vector2D(-1, -1);
        private static readonly PCLColor testColor = new PCLColor(255, 128, 26, 230);
        private const string testTitle = "Test Region";
        private const Elevation testStory = Elevation.AboveGround;
        private const int testElevation = -3;
        private static readonly Guid testID = Guid.Parse("2F06E2CB-72D7-437F-ABA8-0D360AEDEA98");
        private static readonly MapRegion defaultRegion = new MapRegion();
        #endregion

        #region Region Map Initialization
        [Fact]
        public void NewDefaultMapRegionTest()
        {
            Assert.Equal(MapRegion.DefaultTitle, defaultRegion.Title);
            Assert.Equal(MapRegion.DefaultColor, defaultRegion.Background);
        }

        [Fact]
        public void NewNullMapRegionTest()
        {
            var nulledRegion = new MapRegion(null);

            Assert.Equal(MapRegion.DefaultTitle, nulledRegion.Title);
            Assert.Equal(MapRegion.DefaultColor, nulledRegion.Background);
        }

        [Fact]
        public void NewCustomMapRegionTest()
        {
            var customRegion = new MapRegion(testTitle, testColor, testStory, testElevation, testID);

            Assert.Equal(testTitle, customRegion.Title);
            Assert.Equal(testColor, customRegion.Background);
            Assert.Equal(testStory, customRegion.ElevationLocal);
            Assert.Equal(testElevation, customRegion.ElevationGlobal);
            Assert.Equal(testID, customRegion.RegionID);
        }
        #endregion

        #region Whole Region Characteristics Editing
        [Fact]
        public void MapRegionMayBeEditedTest()
        {
            var customRegion = new MapRegion();
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

        #region Parquets Replacement Methods
        [Fact]
        public void TrySetFloorFailsOnInvalidPositionTest()
        {
            var region = new MapRegion();
            var parquet = TestEntities.TestFloor.ID;

            var result = region.TrySetFloorDefinition(parquet, invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFloorSucceedsOnDefaultParquetAndPositionTest()
        {
            var region = new MapRegion();
            var parquet = TestEntities.TestFloor.ID;

            var result = region.TrySetFloorDefinition(parquet, Vector2D.Zero);

            Assert.True(result);
            Assert.Equal(parquet, region.GetDefinitionAtPosition(Vector2D.Zero).Floor);
        }

        [Fact]
        public void TrySetBlockFailsOnInvalidPositionTest()
        {
            var region = new MapRegion();
            var parquet = TestEntities.TestBlock.ID;

            var result = region.TrySetBlockDefinition(parquet, invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetBlockSucceedsOnDefaultParquetAndPositionTest()
        {
            var region = new MapRegion();
            var parquet = TestEntities.TestBlock.ID;

            var result = region.TrySetBlockDefinition(parquet, Vector2D.Zero);

            Assert.True(result);
            Assert.Equal(parquet, region.GetDefinitionAtPosition(Vector2D.Zero).Block);
        }

        [Fact]
        public void TrySetFurnishingFailsOnInvalidPositionTest()
        {
            var region = new MapRegion();
            var parquet = TestEntities.TestFurnishing.ID;

            var result = region.TrySetFurnishingDefinition(parquet, invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFurnishingSucceedsOnDefaultParquetAndPositionTest()
        {
            var region = new MapRegion();
            var parquet = TestEntities.TestFurnishing.ID;

            var result = region.TrySetFurnishingDefinition(parquet, Vector2D.Zero);

            Assert.True(result);
            Assert.Equal(parquet, region.GetDefinitionAtPosition(Vector2D.Zero).Furnishing);
        }

        [Fact]
        public void TrySetCollectibleFailsOnInvalidPositionTest()
        {
            var region = new MapRegion();
            var parquet = TestEntities.TestCollectible.ID;

            var result = region.TrySetCollectibleDefinition(parquet, invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetCollectibleSucceedsOnDefaultParquetAndPositionTest()
        {
            var region = new MapRegion();
            var parquet = TestEntities.TestCollectible.ID;

            var result = region.TrySetCollectibleDefinition(parquet, Vector2D.Zero);

            Assert.True(result);
            Assert.Equal(parquet, region.GetDefinitionAtPosition(Vector2D.Zero).Collectible);
        }

        [Fact]
        public void TrySetParquetDefinitionSucceedsWithMapSpaceTest()
        {
            var region = new MapRegion();
            var stack = new ParquetStack(TestEntities.TestFloor.ID,
                                         TestEntities.TestBlock.ID,
                                         TestEntities.TestFurnishing.ID,
                                         TestEntities.TestCollectible.ID);
            var space = new MapSpace(Vector2D.Zero, stack);

            var result = region.TrySetParquetDefinition(space);

            Assert.True(result);
            Assert.Equal(stack, region.GetDefinitionAtPosition(Vector2D.Zero));
        }
        #endregion

        #region Special Location Methods
        [Fact]
        public void TrySetExitPointSucceedsOnValidPositionTest()
        {
            var region = new MapRegion();
            var point = new ExitPoint(Vector2D.Zero, new Guid());

            var result = region.TrySetExitPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveExitPointFailsOnInvalidPositionTest()
        {
            var region = new MapRegion();
            var point = new ExitPoint(invalidPosition, new Guid());

            var result = region.TryRemoveExitPoint(point);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveExitPointFailsOnExitPointMissingTest()
        {
            var region = new MapRegion();
            var point = new ExitPoint(Vector2D.Zero, new Guid());

            var result = region.TryRemoveExitPoint(point);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveExitPointSucceedsOnExitPointExistsTest()
        {
            var region = new MapRegion();
            var point = new ExitPoint(Vector2D.Zero, new Guid());
            region.TrySetExitPoint(point);

            var result = region.TryRemoveExitPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void GetExitsReturnsNullsOnInvalidPositionTest()
        {
            var region = new MapRegion();

            var specialData = region.GetExitsAtPosition(invalidPosition);

            Assert.Empty(specialData);
        }
        #endregion

        #region State Query Methods
        [Fact]
        public void GetDefinitionReturnsThrowsOnInvalidPositionTest()
        {
            var chunk = new MapRegion().FillTestPattern();

            void TestCode()
            {
                var _ = chunk.GetDefinitionAtPosition(invalidPosition);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }

        [Fact]
        public void GetDefinitionReturnsNoneOnEmptyMapTest()
        {
            var chunk = new MapRegion();

            var result = chunk.GetDefinitionAtPosition(Vector2D.Zero);

            Assert.Equal(EntityID.None, result.Floor);
            Assert.Equal(EntityID.None, result.Block);
            Assert.Equal(EntityID.None, result.Furnishing);
            Assert.Equal(EntityID.None, result.Collectible);
        }
        #endregion

        #region Subregion Methods
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
                                ?.GetValue(defaultRegion) as ParquetStack2DCollection;
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
                                ?.GetValue(defaultRegion) as ParquetStack2DCollection;

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
