using Xunit;
using System;
using ParquetClassLibrary.Sandbox;
using ParquetClassLibrary.Sandbox.SpecialPoints;
using ParquetClassLibrary.Sandbox.Parquets;
using ParquetClassLibrary.Stubs;

namespace ParquetUnitTests.Sandbox
{
    public class MapChunkUnitTest
    {
        #region Values for Tests
        private readonly Vector2Int InvalidPosition = new Vector2Int(-1, -1);
        #endregion

        #region Region Map Initialization
        [Fact]
        public void NewDefaultMapChunkTest()
        {
            var defaultRegion = new MapChunk();

            Assert.Equal(0, defaultRegion.Revision);
        }
        #endregion

        #region Parquets Replacement Methods
        [Fact]
        public void TrySetFloorFailsOnNullParquetTest()
        {
            var region = new MapChunk();

            var result = region.TrySetFloor(null, Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFloorFailsOnInvalidPositionTest()
        {
            var region = new MapChunk();
            var parquet = AllParquets.TestFloor;

            var result = region.TrySetFloor(parquet, InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFloorSucceedsOnDefaultParquetAndPositionTest()
        {
            var region = new MapChunk();
            var parquet = AllParquets.TestFloor;

            var result = region.TrySetFloor(parquet, Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TrySetBlockFailsOnNullParquetTest()
        {
            var region = new MapChunk();

            var result = region.TrySetBlock(null, Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void TrySetBlockFailsOnInvalidPositionTest()
        {
            var region = new MapChunk();
            var parquet = AllParquets.TestBlock;

            var result = region.TrySetBlock(parquet, InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetBlockSucceedsOnDefaultParquetAndPositionTest()
        {
            var region = new MapChunk();
            var parquet = AllParquets.TestBlock;

            var result = region.TrySetBlock(parquet, Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TrySetFurnishingFailsOnNullParquetTest()
        {
            var region = new MapChunk();

            var result = region.TrySetFurnishing(null, Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFurnishingFailsOnInvalidPositionTest()
        {
            var region = new MapChunk();
            var parquet = AllParquets.TestFurnishing;

            var result = region.TrySetFurnishing(parquet, InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFurnishingSucceedsOnDefaultParquetAndPositionTest()
        {
            var region = new MapChunk();
            var parquet = AllParquets.TestFurnishing;

            var result = region.TrySetFurnishing(parquet, Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TrySetCollectableFailsOnNullParquetTest()
        {
            var region = new MapChunk();

            var result = region.TrySetCollectable(null, Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void TrySetCollectableFailsOnInvalidPositionTest()
        {
            var region = new MapChunk();
            var parquet = AllParquets.TestCollectable;

            var result = region.TrySetCollectable(parquet, InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetCollectableSucceedsOnDefaultParquetAndPositionTest()
        {
            var region = new MapChunk();
            var parquet = AllParquets.TestCollectable;

            var result = region.TrySetCollectable(parquet, Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveFloorFailsOnInvalidPositionTest()
        {
            var region = new MapChunk();

            var result = region.TryRemoveFloor(InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveFloorSucceedsOnDefaultPositionTest()
        {
            var region = new MapChunk();

            var result = region.TryRemoveFloor(Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveBlockFailsOnInvalidPositionTest()
        {
            var region = new MapChunk();

            var result = region.TryRemoveBlock(InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveBlockSucceedsOnDefaultPositionTest()
        {
            var region = new MapChunk();

            var result = region.TryRemoveBlock(Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveFurnishingFailsOnInvalidPositionTest()
        {
            var region = new MapChunk();

            var result = region.TryRemoveFurnishing(InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveFurnishingSucceedsOnDefaultPositionTest()
        {
            var region = new MapChunk();

            var result = region.TryRemoveFurnishing(Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveCollectableFailsOnInvalidPositionTest()
        {
            var region = new MapChunk();

            var result = region.TryRemoveCollectable(InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveCollectableSucceedsOnDefaultPositionTest()
        {
            var region = new MapChunk();

            var result = region.TryRemoveCollectable(Vector2Int.ZeroVector);

            Assert.True(result);
        }
        #endregion

        #region Special Location Methods
        [Fact]
        public void TrySetSpawnPointFailsOnInvalidPositionTest()
        {
            var region = new MapChunk();
            var point = new SpawnPoint(InvalidPosition, SpawnType.Player);

            var result = region.TrySetSpawnPoint(point);

            Assert.False(result);
        }

        [Fact]
        public void TrySetSpawnPointSucceedsOnValidPositionTest()
        {
            var region = new MapChunk();
            var point = new SpawnPoint(Vector2Int.ZeroVector, SpawnType.Player);

            var result = region.TrySetSpawnPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveSpawnPointFailsOnInvalidPositionTest()
        {
            var region = new MapChunk();
            var point = new SpawnPoint(InvalidPosition, SpawnType.Player);

            var result = region.TryRemoveSpawnPoint(point);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveSpawnPointSucceedsOnSpawnPointMissingTest()
        {
            var region = new MapChunk();
            var point = new SpawnPoint(Vector2Int.ZeroVector, SpawnType.Player);

            var result = region.TryRemoveSpawnPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveSpawnPointSucceedsOnSpawnPointSetTest()
        {
            var region = new MapChunk();
            var point = new SpawnPoint(Vector2Int.ZeroVector, SpawnType.Player);
            region.TrySetSpawnPoint(point);

            var result = region.TryRemoveSpawnPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void TrySetExitPointFailsOnInvalidPositionTest()
        {
            var region = new MapChunk();
            var point = new ExitPoint(InvalidPosition, new Guid());

            var result = region.TrySetExitPoint(point);

            Assert.False(result);
        }

        [Fact]
        public void TrySetExitPointSucceedsOnValidPositionTest()
        {
            var region = new MapChunk();
            var point = new ExitPoint(Vector2Int.ZeroVector, new Guid());

            var result = region.TrySetExitPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveExitPointFailsOnInvalidPositionTest()
        {
            var region = new MapChunk();
            var point = new ExitPoint(InvalidPosition, new Guid());

            var result = region.TryRemoveExitPoint(point);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveExitPointSucceedsOnExitPointMissingTest()
        {
            var region = new MapChunk();
            var point = new ExitPoint(Vector2Int.ZeroVector, new Guid());

            var result = region.TryRemoveExitPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveExitPointSucceedsOnExitPointExistsTest()
        {
            var region = new MapChunk();
            var point = new ExitPoint(Vector2Int.ZeroVector, new Guid());
            region.TrySetExitPoint(point);

            var result = region.TryRemoveExitPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void GetSpecialDataReturnsNullsOnInvalidPositionTest()
        {
            var region = new MapChunk();

            var specialData = region.GetSpecialPointsAtPosition(InvalidPosition);

            Assert.Empty(specialData);
        }
        #endregion

        #region Serialization Methods
        [Fact]
        public void SerializingKnownMapProducesKnownStringTest()
        {
            var region = new MapChunk().FillTestPattern();

            var result = region.SerializeToString();

            Assert.Equal(SerializedMapChunksForTest.KnownGoodString, result);
        }

        [Fact]
        public void DeserializingNullFailsTest()
        {
            var result = MapChunk.TryDeserializeFromString(null, out MapChunk mapChunkResults);

            Assert.Null(mapChunkResults);
            Assert.False(result);
        }

        [Fact]
        public void DeserializingUnsupportedVersionFailsTest()
        {
            var result = MapChunk.TryDeserializeFromString(SerializedMapChunksForTest.UnsupportedVersionString,
                                                           out MapChunk mapChunkResults);

            Assert.Null(mapChunkResults);
            Assert.False(result);
        }

        [Fact]
        public void DeserializingKnownBadStringFailsTest()
        {
            var result = MapChunk.TryDeserializeFromString(SerializedMapChunksForTest.NonJsonString,
                                                           out MapChunk mapChunkResults);

            Assert.Null(mapChunkResults);
            Assert.False(result);
        }

        [Fact]
        public void DeserializingKnownGoodStringSucceedsTest()
        {
            var result = MapChunk.TryDeserializeFromString(SerializedMapChunksForTest.KnownGoodString,
                                                           out MapChunk mapChunkResults);

            Assert.NotNull(mapChunkResults);
            Assert.True(result);
        }

        #endregion

        #region State Query Methods
        [Fact]
        public void GetFloorReturnsNullOnInvalidPositionTest()
        {
            var region = new MapChunk().FillTestPattern();

            var result = region.GetFloorAtPosition(InvalidPosition);

            Assert.Null(result);
        }

        [Fact]
        public void GetFloorReturnsNullOnEmptyMapTest()
        {
            var region = new MapChunk();

            var result = region.GetFloorAtPosition(Vector2Int.ZeroVector);

            Assert.Null(result);
        }

        [Fact]
        public void GetBlockReturnsNullOnInvalidPositionTest()
        {
            var region = new MapChunk().FillTestPattern();

            var result = region.GetBlockAtPosition(InvalidPosition);

            Assert.Null(result);
        }

        [Fact]
        public void GetBlockReturnsNullOnEmptyMapTest()
        {
            var region = new MapChunk();

            var result = region.GetBlockAtPosition(Vector2Int.ZeroVector);

            Assert.Null(result);
        }

        [Fact]
        public void GetFurnishingReturnsNullOnInvalidPositionTest()
        {
            var region = new MapChunk().FillTestPattern();

            var result = region.GetFurnishingAtPosition(InvalidPosition);

            Assert.Null(result);
        }

        [Fact]
        public void GetFurnishingReturnsNullOnEmptyMapTest()
        {
            var region = new MapChunk();

            var result = region.GetFurnishingAtPosition(Vector2Int.ZeroVector);

            Assert.Null(result);
        }

        [Fact]
        public void GetCollectableReturnsNullOnInvalidPositionTest()
        {
            var region = new MapChunk().FillTestPattern();

            var result = region.GetCollectableAtPosition(InvalidPosition);

            Assert.Null(result);
        }

        [Fact]
        public void GetCollectableReturnsNullOnEmptyMapTest()
        {
            var region = new MapChunk();

            var result = region.GetCollectableAtPosition(Vector2Int.ZeroVector);

            Assert.Null(result);
        }

        [Fact]
        public void GetAllParquetsReturnsNullsOnInvalidPositionTest()
        {
            var region = new MapChunk().FillTestPattern();

            var parquetStack = region.GetAllParquetsAtPosition(InvalidPosition);

            Assert.Null(parquetStack.Floor);
            Assert.Null(parquetStack.Block);
            Assert.Null(parquetStack.Furnishing);
            Assert.Null(parquetStack.Collectable);
        }

        [Fact]
        public void GetAllParquetsReturnsNullsOnEmptyMapTest()
        {
            var region = new MapChunk();

            var parquetStack = region.GetAllParquetsAtPosition(Vector2Int.ZeroVector);

            Assert.Null(parquetStack.Floor);
            Assert.Null(parquetStack.Block);
            Assert.Null(parquetStack.Furnishing);
            Assert.Null(parquetStack.Collectable);
        }
        #endregion
    }
}
