using Xunit;
using System;
using ParquetClassLibrary.Sandbox;
using ParquetClassLibrary.Sandbox.SpecialPoints;
using ParquetClassLibrary.Sandbox.Parquets;
using ParquetClassLibrary.Stubs;
using ParquetUnitTests.Sandbox.Parquets;

namespace ParquetUnitTests.Sandbox
{
    public class MapChunkUnitTest
    {
        #region Values for Tests
        private readonly Vector2Int InvalidPosition = new Vector2Int(-1, -1);
        #endregion

        #region chunk Map Initialization
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
            var chunk = new MapChunk();

            var result = chunk.TrySetFloor(null, Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFloorFailsOnInvalidPositionTest()
        {
            var chunk = new MapChunk();
            var parquet = TestParquets.TestFloor;

            var result = chunk.TrySetFloor(parquet, InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFloorSucceedsOnDefaultParquetAndPositionTest()
        {
            var chunk = new MapChunk();
            var parquet = TestParquets.TestFloor;

            var result = chunk.TrySetFloor(parquet, Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TrySetBlockFailsOnNullParquetTest()
        {
            var chunk = new MapChunk();

            var result = chunk.TrySetBlock(null, Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void TrySetBlockFailsOnInvalidPositionTest()
        {
            var chunk = new MapChunk();
            var parquet = TestParquets.TestBlock;

            var result = chunk.TrySetBlock(parquet, InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetBlockSucceedsOnDefaultParquetAndPositionTest()
        {
            var chunk = new MapChunk();
            var parquet = TestParquets.TestBlock;

            var result = chunk.TrySetBlock(parquet, Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TrySetFurnishingFailsOnNullParquetTest()
        {
            var chunk = new MapChunk();

            var result = chunk.TrySetFurnishing(null, Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFurnishingFailsOnInvalidPositionTest()
        {
            var chunk = new MapChunk();
            var parquet = TestParquets.TestFurnishing;

            var result = chunk.TrySetFurnishing(parquet, InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFurnishingSucceedsOnDefaultParquetAndPositionTest()
        {
            var chunk = new MapChunk();
            var parquet = TestParquets.TestFurnishing;

            var result = chunk.TrySetFurnishing(parquet, Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TrySetCollectableFailsOnNullParquetTest()
        {
            var chunk = new MapChunk();

            var result = chunk.TrySetCollectable(null, Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void TrySetCollectableFailsOnInvalidPositionTest()
        {
            var chunk = new MapChunk();
            var parquet = TestParquets.TestCollectable;

            var result = chunk.TrySetCollectable(parquet, InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetCollectableSucceedsOnDefaultParquetAndPositionTest()
        {
            var chunk = new MapChunk();
            var parquet = TestParquets.TestCollectable;

            var result = chunk.TrySetCollectable(parquet, Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveFloorFailsOnInvalidPositionTest()
        {
            var chunk = new MapChunk();

            var result = chunk.TryRemoveFloor(InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveFloorSucceedsOnDefaultPositionTest()
        {
            var chunk = new MapChunk();

            var result = chunk.TryRemoveFloor(Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveBlockFailsOnInvalidPositionTest()
        {
            var chunk = new MapChunk();

            var result = chunk.TryRemoveBlock(InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveBlockSucceedsOnDefaultPositionTest()
        {
            var chunk = new MapChunk();

            var result = chunk.TryRemoveBlock(Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveFurnishingFailsOnInvalidPositionTest()
        {
            var chunk = new MapChunk();

            var result = chunk.TryRemoveFurnishing(InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveFurnishingSucceedsOnDefaultPositionTest()
        {
            var chunk = new MapChunk();

            var result = chunk.TryRemoveFurnishing(Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveCollectableFailsOnInvalidPositionTest()
        {
            var chunk = new MapChunk();

            var result = chunk.TryRemoveCollectable(InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveCollectableSucceedsOnDefaultPositionTest()
        {
            var chunk = new MapChunk();

            var result = chunk.TryRemoveCollectable(Vector2Int.ZeroVector);

            Assert.True(result);
        }
        #endregion

        #region Special Location Methods
        [Fact]
        public void TrySetSpawnPointFailsOnInvalidPositionTest()
        {
            var chunk = new MapChunk();
            var point = new SpawnPoint(InvalidPosition, SpawnType.Player);

            var result = chunk.TrySetSpawnPoint(point);

            Assert.False(result);
        }

        [Fact]
        public void TrySetSpawnPointSucceedsOnValidPositionTest()
        {
            var chunk = new MapChunk();
            var point = new SpawnPoint(Vector2Int.ZeroVector, SpawnType.Player);

            var result = chunk.TrySetSpawnPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveSpawnPointFailsOnInvalidPositionTest()
        {
            var chunk = new MapChunk();
            var point = new SpawnPoint(InvalidPosition, SpawnType.Player);

            var result = chunk.TryRemoveSpawnPoint(point);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveSpawnPointSucceedsOnSpawnPointMissingTest()
        {
            var chunk = new MapChunk();
            var point = new SpawnPoint(Vector2Int.ZeroVector, SpawnType.Player);

            var result = chunk.TryRemoveSpawnPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveSpawnPointSucceedsOnSpawnPointSetTest()
        {
            var chunk = new MapChunk();
            var point = new SpawnPoint(Vector2Int.ZeroVector, SpawnType.Player);
            chunk.TrySetSpawnPoint(point);

            var result = chunk.TryRemoveSpawnPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void TrySetExitPointFailsOnInvalidPositionTest()
        {
            var chunk = new MapChunk();
            var point = new ExitPoint(InvalidPosition, new Guid());

            var result = chunk.TrySetExitPoint(point);

            Assert.False(result);
        }

        [Fact]
        public void TrySetExitPointSucceedsOnValidPositionTest()
        {
            var chunk = new MapChunk();
            var point = new ExitPoint(Vector2Int.ZeroVector, new Guid());

            var result = chunk.TrySetExitPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveExitPointFailsOnInvalidPositionTest()
        {
            var chunk = new MapChunk();
            var point = new ExitPoint(InvalidPosition, new Guid());

            var result = chunk.TryRemoveExitPoint(point);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveExitPointSucceedsOnExitPointMissingTest()
        {
            var chunk = new MapChunk();
            var point = new ExitPoint(Vector2Int.ZeroVector, new Guid());

            var result = chunk.TryRemoveExitPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveExitPointSucceedsOnExitPointExistsTest()
        {
            var chunk = new MapChunk();
            var point = new ExitPoint(Vector2Int.ZeroVector, new Guid());
            chunk.TrySetExitPoint(point);

            var result = chunk.TryRemoveExitPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void GetSpecialDataReturnsNullsOnInvalidPositionTest()
        {
            var chunk = new MapChunk();

            var specialData = chunk.GetSpecialPointsAtPosition(InvalidPosition);

            Assert.Empty(specialData);
        }
        #endregion

        #region Serialization Methods
        [Fact]
        public void SerializingKnownMapProducesKnownStringTest()
        {
            var chunk = new MapChunk().FillTestPattern();

            var result = chunk.SerializeToString();

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
            var chunk = new MapChunk().FillTestPattern();

            var result = chunk.GetFloorAtPosition(InvalidPosition);

            Assert.Null(result);
        }

        [Fact]
        public void GetFloorReturnsNullOnEmptyMapTest()
        {
            var chunk = new MapChunk();

            var result = chunk.GetFloorAtPosition(Vector2Int.ZeroVector);

            Assert.Null(result);
        }

        [Fact]
        public void GetBlockReturnsNullOnInvalidPositionTest()
        {
            var chunk = new MapChunk().FillTestPattern();

            var result = chunk.GetBlockAtPosition(InvalidPosition);

            Assert.Null(result);
        }

        [Fact]
        public void GetBlockReturnsNullOnEmptyMapTest()
        {
            var chunk = new MapChunk();

            var result = chunk.GetBlockAtPosition(Vector2Int.ZeroVector);

            Assert.Null(result);
        }

        [Fact]
        public void GetFurnishingReturnsNullOnInvalidPositionTest()
        {
            var chunk = new MapChunk().FillTestPattern();

            var result = chunk.GetFurnishingAtPosition(InvalidPosition);

            Assert.Null(result);
        }

        [Fact]
        public void GetFurnishingReturnsNullOnEmptyMapTest()
        {
            var chunk = new MapChunk();

            var result = chunk.GetFurnishingAtPosition(Vector2Int.ZeroVector);

            Assert.Null(result);
        }

        [Fact]
        public void GetCollectableReturnsNullOnInvalidPositionTest()
        {
            var chunk = new MapChunk().FillTestPattern();

            var result = chunk.GetCollectableAtPosition(InvalidPosition);

            Assert.Null(result);
        }

        [Fact]
        public void GetCollectableReturnsNullOnEmptyMapTest()
        {
            var chunk = new MapChunk();

            var result = chunk.GetCollectableAtPosition(Vector2Int.ZeroVector);

            Assert.Null(result);
        }

        [Fact]
        public void GetAllParquetsReturnsNullsOnInvalidPositionTest()
        {
            var chunk = new MapChunk().FillTestPattern();

            var parquetStack = chunk.GetAllParquetsAtPosition(InvalidPosition);

            Assert.Null(parquetStack.Floor);
            Assert.Null(parquetStack.Block);
            Assert.Null(parquetStack.Furnishing);
            Assert.Null(parquetStack.Collectable);
        }

        [Fact]
        public void GetAllParquetsReturnsNullsOnEmptyMapTest()
        {
            var chunk = new MapChunk();

            var parquetStack = chunk.GetAllParquetsAtPosition(Vector2Int.ZeroVector);

            Assert.Null(parquetStack.Floor);
            Assert.Null(parquetStack.Block);
            Assert.Null(parquetStack.Furnishing);
            Assert.Null(parquetStack.Collectable);
        }
        #endregion
    }
}
