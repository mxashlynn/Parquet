using System;
using ParquetClassLibrary;
using ParquetClassLibrary.Sandbox;
using ParquetClassLibrary.Sandbox.SpecialPoints;
using ParquetClassLibrary.Stubs;
using ParquetUnitTests.Sandbox.Parquets;
using Xunit;

namespace ParquetUnitTests.Sandbox
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
        #endregion

        #region Region Map Initialization
        [Fact]
        public void NewDefaultMapRegionTest()
        {
            var defaultRegion = new MapRegion();

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
        public void TrySetFloorFailsOnNullParquetTest()
        {
            var region = new MapRegion();

            var result = region.TrySetFloor(EntityID.None, Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFloorFailsOnInvalidPositionTest()
        {
            var region = new MapRegion();
            var parquet = TestParquets.TestFloor.ID;

            var result = region.TrySetFloor(parquet, invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFloorSucceedsOnDefaultParquetAndPositionTest()
        {
            var region = new MapRegion();
            var parquet = TestParquets.TestFloor.ID;

            var result = region.TrySetFloor(parquet, Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TrySetBlockFailsOnNullParquetTest()
        {
            var region = new MapRegion();

            var result = region.TrySetBlock(EntityID.None, Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void TrySetBlockFailsOnInvalidPositionTest()
        {
            var region = new MapRegion();
            var parquet = TestParquets.TestBlock.ID;

            var result = region.TrySetBlock(parquet, invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetBlockSucceedsOnDefaultParquetAndPositionTest()
        {
            var region = new MapRegion();
            var parquet = TestParquets.TestBlock.ID;

            var result = region.TrySetBlock(parquet, Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TrySetFurnishingFailsOnNullParquetTest()
        {
            var region = new MapRegion();

            var result = region.TrySetFurnishing(EntityID.None, Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFurnishingFailsOnInvalidPositionTest()
        {
            var region = new MapRegion();
            var parquet = TestParquets.TestFurnishing.ID;

            var result = region.TrySetFurnishing(parquet, invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFurnishingSucceedsOnDefaultParquetAndPositionTest()
        {
            var region = new MapRegion();
            var parquet = TestParquets.TestFurnishing.ID;

            var result = region.TrySetFurnishing(parquet, Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TrySetCollectibleFailsOnNullParquetTest()
        {
            var region = new MapRegion();

            var result = region.TrySetCollectible(EntityID.None, Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void TrySetCollectibleFailsOnInvalidPositionTest()
        {
            var region = new MapRegion();
            var parquet = TestParquets.TestCollectible.ID;

            var result = region.TrySetCollectible(parquet, invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetCollectibleSucceedsOnDefaultParquetAndPositionTest()
        {
            var region = new MapRegion();
            var parquet = TestParquets.TestCollectible.ID;

            var result = region.TrySetCollectible(parquet, Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveFloorFailsOnInvalidPositionTest()
        {
            var region = new MapRegion();

            var result = region.TryRemoveFloor(invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveFloorSucceedsOnDefaultPositionTest()
        {
            var region = new MapRegion();

            var result = region.TryRemoveFloor(Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveBlockFailsOnInvalidPositionTest()
        {
            var region = new MapRegion();

            var result = region.TryRemoveBlock(invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveBlockSucceedsOnDefaultPositionTest()
        {
            var region = new MapRegion();

            var result = region.TryRemoveBlock(Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveFurnishingFailsOnInvalidPositionTest()
        {
            var region = new MapRegion();

            var result = region.TryRemoveFurnishing(invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveFurnishingSucceedsOnDefaultPositionTest()
        {
            var region = new MapRegion();

            var result = region.TryRemoveFurnishing(Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveCollectibleFailsOnInvalidPositionTest()
        {
            var region = new MapRegion();

            var result = region.TryRemoveCollectible(invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveCollectibleSucceedsOnDefaultPositionTest()
        {
            var region = new MapRegion();

            var result = region.TryRemoveCollectible(Vector2Int.ZeroVector);

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
        [Fact]
        public void SerializingKnownMapProducesKnownStringTest()
        {
            var region = new MapRegion(false).FillTestPattern();

            var result = region.SerializeToString();

            Assert.Equal(SerializedRegionMapsForTest.KnownGoodString, result);
        }

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
        public void GetFloorReturnsNullOnInvalidPositionTest()
        {
            var region = new MapRegion().FillTestPattern();

            var result = region.GetFloorAtPosition(invalidPosition);

            Assert.Null(result);
        }

        [Fact]
        public void GetFloorReturnsNullOnEmptyMapTest()
        {
            var region = new MapRegion();

            var result = region.GetFloorAtPosition(Vector2Int.ZeroVector);

            Assert.Null(result);
        }

        [Fact]
        public void GetBlockReturnsNullOnInvalidPositionTest()
        {
            var region = new MapRegion().FillTestPattern();

            var result = region.GetBlockAtPosition(invalidPosition);

            Assert.Null(result);
        }

        [Fact]
        public void GetBlockReturnsNullOnEmptyMapTest()
        {
            var region = new MapRegion();

            var result = region.GetBlockAtPosition(Vector2Int.ZeroVector);

            Assert.Null(result);
        }

        [Fact]
        public void GetFurnishingReturnsNullOnInvalidPositionTest()
        {
            var region = new MapRegion().FillTestPattern();

            var result = region.GetFurnishingAtPosition(invalidPosition);

            Assert.Null(result);
        }

        [Fact]
        public void GetFurnishingReturnsNullOnEmptyMapTest()
        {
            var region = new MapRegion();

            var result = region.GetFurnishingAtPosition(Vector2Int.ZeroVector);

            Assert.Null(result);
        }

        [Fact]
        public void GetCollectibleReturnsNullOnInvalidPositionTest()
        {
            var region = new MapRegion().FillTestPattern();

            var result = region.GetCollectibleAtPosition(invalidPosition);

            Assert.Null(result);
        }

        [Fact]
        public void GetCollectibleReturnsNullOnEmptyMapTest()
        {
            var region = new MapRegion();

            var result = region.GetCollectibleAtPosition(Vector2Int.ZeroVector);

            Assert.Null(result);
        }

        [Fact]
        public void GetAllParquetsReturnsNullsOnInvalidPositionTest()
        {
            var region = new MapRegion().FillTestPattern();

            var parquetStack = region.GetAllParquetsAtPosition(invalidPosition);

            Assert.Null(parquetStack.Floor);
            Assert.Null(parquetStack.Block);
            Assert.Null(parquetStack.Furnishing);
            Assert.Null(parquetStack.Collectible);
        }

        [Fact]
        public void GetAllParquetsReturnsNullsOnEmptyMapTest()
        {
            var region = new MapRegion();

            var parquetStack = region.GetAllParquetsAtPosition(Vector2Int.ZeroVector);

            Assert.Null(parquetStack.Floor);
            Assert.Null(parquetStack.Block);
            Assert.Null(parquetStack.Furnishing);
            Assert.Null(parquetStack.Collectible);
        }
        #endregion
    }
}
