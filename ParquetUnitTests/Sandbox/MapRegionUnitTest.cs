using Xunit;
using System;
using ParquetClassLibrary.Sandbox;
using ParquetClassLibrary.Sandbox.SpecialPoints;
using ParquetClassLibrary.Sandbox.Parquets;
using ParquetClassLibrary.Stubs;

namespace ParquetUnitTests.Sandbox
{
    public class MapRegionUnitTest
    {
        #region Values for Tests
        private readonly Vector2Int InvalidPosition = new Vector2Int(-1, -1);
        private readonly Color TestColor = new Color(255, 128, 26, 230);
        private const string TestTitle = "New Region";
        private const int TestElevation = -3;
        private readonly Guid TestID = Guid.Parse("2F06E2CB-72D7-437F-ABA8-0D360AEDEA98");
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
            var nulledRegion = new MapRegion(null, null);

            Assert.Equal(MapRegion.DefaultTitle, nulledRegion.Title);
            Assert.Equal(MapRegion.DefaultColor, nulledRegion.Background);
        }

        [Fact]
        public void NewCustomMapRegionTest()
        {
            var customRegion = new MapRegion(TestTitle, TestColor, TestElevation, TestID);

            Assert.Equal(TestTitle, customRegion.Title);
            Assert.Equal(TestColor, customRegion.Background);
            Assert.Equal(TestElevation, customRegion.GlobalElevation);
            Assert.Equal(TestID, customRegion.RegionID);
        }
        #endregion

        #region Parquets Replacement Methods
        [Fact]
        public void TrySetFloorFailsOnNullParquetTest()
        {
            var region = new MapRegion();

            var result = region.TrySetFloor(null, Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFloorFailsOnInvalidPositionTest()
        {
            var region = new MapRegion();
            var parquet = new Floor();

            var result = region.TrySetFloor(parquet, InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFloorSucceedsOnDefaultParquetAndPositionTest()
        {
            var region = new MapRegion();
            var parquet = new Floor();

            var result = region.TrySetFloor(parquet, Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TrySetBlockFailsOnNullParquetTest()
        {
            var region = new MapRegion();

            var result = region.TrySetBlock(null, Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void TrySetBlockFailsOnInvalidPositionTest()
        {
            var region = new MapRegion();
            var parquet = new Block();

            var result = region.TrySetBlock(parquet, InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetBlockSucceedsOnDefaultParquetAndPositionTest()
        {
            var region = new MapRegion();
            var parquet = new Block();

            var result = region.TrySetBlock(parquet, Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TrySetFurnishingFailsOnNullParquetTest()
        {
            var region = new MapRegion();

            var result = region.TrySetFurnishing(null, Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFurnishingFailsOnInvalidPositionTest()
        {
            var region = new MapRegion();
            var parquet = new Furnishing();

            var result = region.TrySetFurnishing(parquet, InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFurnishingSucceedsOnDefaultParquetAndPositionTest()
        {
            var region = new MapRegion();
            var parquet = new Furnishing();

            var result = region.TrySetFurnishing(parquet, Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TrySetCollectableFailsOnNullParquetTest()
        {
            var region = new MapRegion();

            var result = region.TrySetCollectable(null, Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void TrySetCollectableFailsOnInvalidPositionTest()
        {
            var region = new MapRegion();
            var parquet = new Collectable();

            var result = region.TrySetCollectable(parquet, InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetCollectableSucceedsOnDefaultParquetAndPositionTest()
        {
            var region = new MapRegion();
            var parquet = new Collectable();

            var result = region.TrySetCollectable(parquet, Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveFloorFailsOnInvalidPositionTest()
        {
            var region = new MapRegion();

            var result = region.TryRemoveFloor(InvalidPosition);

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

            var result = region.TryRemoveBlock(InvalidPosition);

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

            var result = region.TryRemoveFurnishing(InvalidPosition);

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
        public void TryRemoveCollectableFailsOnInvalidPositionTest()
        {
            var region = new MapRegion();

            var result = region.TryRemoveCollectable(InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveCollectableSucceedsOnDefaultPositionTest()
        {
            var region = new MapRegion();

            var result = region.TryRemoveCollectable(Vector2Int.ZeroVector);

            Assert.True(result);
        }
        #endregion

        #region Special Location Methods
        [Fact]
        public void TrySetSpawnPointFailsOnInvalidPositionTest()
        {
            var region = new MapRegion();
            var point = new SpawnPoint(InvalidPosition, SpawnType.Player);

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
            var point = new SpawnPoint(InvalidPosition, SpawnType.Player);

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
            var point = new ExitPoint(InvalidPosition, new Guid());

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
            var point = new ExitPoint(InvalidPosition, new Guid());

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

            var specialData = region.GetSpecialPointsAtPosition(InvalidPosition);

            Assert.Empty(specialData);
        }
        #endregion

        #region Serialization Methods
        [Fact]
        public void SerializingKnownMapProducesKnownStringTest()
        {
            var region = new MapRegion(in_generateID: false).FillTestPattern();

            var result = region.SerializeToString();

            Assert.Equal(SerializedRegionMapsForTest.KnownGoodString, result);
        }

        [Fact]
        public void DeserializingNullFailsTest()
        {
            var result = MapRegion.TryDeserializeFromString(null, out MapRegion mapRegionResults);

            Assert.Null(mapRegionResults);
            Assert.False(result);
        }

        [Fact]
        public void DeserializingUnsupportedVersionFailsTest()
        {
            var result = MapRegion.TryDeserializeFromString(SerializedRegionMapsForTest.UnsupportedVersionString,
                                                            out MapRegion mapRegionResults);

            Assert.Null(mapRegionResults);
            Assert.False(result);
        }

        [Fact]
        public void DeserializingKnownBadStringFailsTest()
        {
            var result = MapRegion.TryDeserializeFromString(SerializedRegionMapsForTest.NonJsonString,
                                                            out MapRegion mapRegionResults);

            Assert.Null(mapRegionResults);
            Assert.False(result);
        }

        [Fact]
        public void DeserializingKnownGoodStringSucceedsTest()
        {
            var result = MapRegion.TryDeserializeFromString(SerializedRegionMapsForTest.KnownGoodString,
                                                            out MapRegion mapRegionResults);

            Assert.NotNull(mapRegionResults);
            Assert.True(result);
        }

        #endregion

        #region State Query Methods
        [Fact]
        public void GetFloorReturnsNullOnInvalidPositionTest()
        {
            var region = new MapRegion().FillTestPattern();

            var result = region.GetFloorAtPosition(InvalidPosition);

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

            var result = region.GetBlockAtPosition(InvalidPosition);

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

            var result = region.GetFurnishingAtPosition(InvalidPosition);

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
        public void GetCollectableReturnsNullOnInvalidPositionTest()
        {
            var region = new MapRegion().FillTestPattern();

            var result = region.GetCollectableAtPosition(InvalidPosition);

            Assert.Null(result);
        }

        [Fact]
        public void GetCollectableReturnsNullOnEmptyMapTest()
        {
            var region = new MapRegion();

            var result = region.GetCollectableAtPosition(Vector2Int.ZeroVector);

            Assert.Null(result);
        }

        [Fact]
        public void GetAllParquetsReturnsNullsOnInvalidPositionTest()
        {
            var region = new MapRegion().FillTestPattern();

            var parquetStack = region.GetAllParquetsAtPosition(InvalidPosition);

            Assert.Null(parquetStack.Floor);
            Assert.Null(parquetStack.Block);
            Assert.Null(parquetStack.Furnishing);
            Assert.Null(parquetStack.Collectable);
        }

        [Fact]
        public void GetAllParquetsReturnsNullsOnEmptyMapTest()
        {
            var region = new MapRegion();

            var parquetStack = region.GetAllParquetsAtPosition(Vector2Int.ZeroVector);

            Assert.Null(parquetStack.Floor);
            Assert.Null(parquetStack.Block);
            Assert.Null(parquetStack.Furnishing);
            Assert.Null(parquetStack.Collectable);
        }
        #endregion
    }
}
