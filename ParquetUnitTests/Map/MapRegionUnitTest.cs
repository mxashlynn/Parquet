using System;
using System.Reflection;
using ParquetClassLibrary;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Map;
using ParquetClassLibrary.Map.SpecialPoints;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Stubs;
using Xunit;

namespace ParquetUnitTests.Map
{
    public class MapRegionUnitTest
    {
        #region Values for Tests
        private static readonly Vector2Int invalidPosition = new Vector2Int(-1, -1);
        private static readonly Color testColor = new Color(255, 128, 26, 230);
        private const string testTitle = "New Region";
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

            var result = region.TrySetFloorDefinition(parquet, Vector2Int.ZeroVector);

            Assert.True(result);
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

            var result = region.TrySetBlockDefinition(parquet, Vector2Int.ZeroVector);

            Assert.True(result);
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

            var result = region.TrySetFurnishingDefinition(parquet, Vector2Int.ZeroVector);

            Assert.True(result);
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

            var result = region.TrySetCollectibleDefinition(parquet, Vector2Int.ZeroVector);

            Assert.True(result);
        }
        #endregion

        #region Special Location Methods
        [Fact]
        public void TrySetSpawnPointFailsOnInvalidPositionTest()
        {
            var region = new MapRegion();
            var point = new SpawnPoint(invalidPosition, SpawnType.Player);

            var result = region.TrySetSpawnPoint(point);

            Assert.False(result);
        }

        [Fact]
        public void TrySetSpawnPointSucceedsOnValidPositionTest()
        {
            var region = new MapRegion();
            var point = new SpawnPoint(Vector2Int.ZeroVector, SpawnType.Player);

            var result = region.TrySetSpawnPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveSpawnPointFailsOnInvalidPositionTest()
        {
            var region = new MapRegion();
            var point = new SpawnPoint(invalidPosition, SpawnType.Player);

            var result = region.TryRemoveSpawnPoint(point);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveSpawnPointSucceedsOnSpawnPointMissingTest()
        {
            var region = new MapRegion();
            var point = new SpawnPoint(Vector2Int.ZeroVector, SpawnType.Player);

            var result = region.TryRemoveSpawnPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveSpawnPointSucceedsOnSpawnPointSetTest()
        {
            var region = new MapRegion();
            var point = new SpawnPoint(Vector2Int.ZeroVector, SpawnType.Player);
            region.TrySetSpawnPoint(point);

            var result = region.TryRemoveSpawnPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void TrySetExitPointFailsOnInvalidPositionTest()
        {
            var region = new MapRegion();
            var point = new ExitPoint(invalidPosition, new Guid());

            var result = region.TrySetExitPoint(point);

            Assert.False(result);
        }

        [Fact]
        public void TrySetExitPointSucceedsOnValidPositionTest()
        {
            var region = new MapRegion();
            var point = new ExitPoint(Vector2Int.ZeroVector, new Guid());

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
        public void TryRemoveExitPointSucceedsOnExitPointMissingTest()
        {
            var region = new MapRegion();
            var point = new ExitPoint(Vector2Int.ZeroVector, new Guid());

            var result = region.TryRemoveExitPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveExitPointSucceedsOnExitPointExistsTest()
        {
            var region = new MapRegion();
            var point = new ExitPoint(Vector2Int.ZeroVector, new Guid());
            region.TrySetExitPoint(point);

            var result = region.TryRemoveExitPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void GetSpecialDataReturnsNullsOnInvalidPositionTest()
        {
            var region = new MapRegion();

            var specialData = region.GetSpecialPointsAtPosition(invalidPosition);

            Assert.Empty(specialData);
        }
        #endregion

        #region Serialization Methods
        // TODO: Consider removing these, and associated pre-serialized files.
        //[Fact]
        //public void SerializingKnownMapProducesKnownStringTest()
        //{
        //    var region = new MapRegion(false).FillTestPattern();
        //
        //    var result = region.SerializeToString();
        //
        //    Assert.Equal(SerializedRegionMapsForTest.KnownGoodString, result);
        //}

        [Fact]
        public void DeserializingNullFailsTest()
        {
            var result = MapRegion.TryDeserializeFromString(null, out var mapRegionResults);

            Assert.Null(mapRegionResults);
            Assert.False(result);
        }

        [Fact]
        public void DeserializingUnsupportedVersionFailsTest()
        {
            var result = MapRegion.TryDeserializeFromString(SerializedRegionMapsForTest.UnsupportedVersionString,
                                                            out var mapRegionResults);

            Assert.Null(mapRegionResults);
            Assert.False(result);
        }

        [Fact]
        public void DeserializingKnownBadStringFailsTest()
        {
            var result = MapRegion.TryDeserializeFromString(SerializedRegionMapsForTest.NonJsonString,
                                                            out var mapRegionResults);

            Assert.Null(mapRegionResults);
            Assert.False(result);
        }

        [Fact]
        public void DeserializingKnownGoodStringSucceedsTest()
        {
            var result = MapRegion.TryDeserializeFromString(SerializedRegionMapsForTest.KnownGoodString,
                                                            out var mapRegionResults);

            Assert.NotNull(mapRegionResults);
            Assert.True(result);
        }

        #endregion

        #region State Query Methods
        [Fact]
        public void GetDefinitionReturnsNoneOnInvalidPositionTest()
        {
            var chunk = new MapRegion().FillTestPattern();

            var result = chunk.GetDefinitionAtPosition(invalidPosition);

            Assert.Equal(EntityID.None, result.Floor);
            Assert.Equal(EntityID.None, result.Block);
            Assert.Equal(EntityID.None, result.Furnishing);
            Assert.Equal(EntityID.None, result.Collectible);
        }

        [Fact]
        public void GetDefinitionReturnsNoneOnEmptyMapTest()
        {
            var chunk = new MapRegion();

            var result = chunk.GetDefinitionAtPosition(Vector2Int.ZeroVector);

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
            var validLowerRight = new Vector2Int(defaultRegion.DimensionsInParquets.X - 1,
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
            var validUpperLeft = Vector2Int.ZeroVector;
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
            var validUpperLeft = Vector2Int.ZeroVector;
            var validLowerRight = new Vector2Int(defaultRegion.DimensionsInParquets.X - 1,
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
                                ?.GetValue(defaultRegion) as ParquetStack[,];
            var validUpperLeft = new Vector2Int(1, 4);
            var validLowerRight = new Vector2Int(10, 14);

            var subregion = defaultRegion.GetSubregion();

            for (var x = validUpperLeft.X; x < validLowerRight.X; x++)
            {
                for (var y = validUpperLeft.Y; y < validLowerRight.Y; y++)
                {
                    Assert.Equal(subregion[y, x], originalChunk[y, x]);
                }
            }
        }

        [Fact]
        public void GetSubregionOnWholeSubregionMatchesPattern()
        {
            var originalChunk = typeof(MapRegion)
                                .GetProperty("ParquetDefintion", BindingFlags.NonPublic | BindingFlags.Instance)
                                ?.GetValue(defaultRegion) as ParquetStack[,];

            var subregion = defaultRegion.GetSubregion();

            for (var x = 0; x < defaultRegion.DimensionsInParquets.X; x++)
            {
                for (var y = 0; y < defaultRegion.DimensionsInParquets.Y; y++)
                {
                    Assert.Equal(subregion[y, x], originalChunk[y, x]);
                }
            }
        }
        #endregion
    }
}
