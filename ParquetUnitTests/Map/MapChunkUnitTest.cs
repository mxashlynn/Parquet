using System;
using ParquetClassLibrary;
using ParquetClassLibrary.Map;
using ParquetClassLibrary.Map.SpecialPoints;
using ParquetClassLibrary.Stubs;
using Xunit;

namespace ParquetUnitTests.Map
{
    public class MapChunkUnitTest
    {
        #region Values for Tests
        private static readonly Vector2Int invalidPosition = new Vector2Int(-1, -1);
        #endregion

        #region Initialization
        [Fact]
        public void NewDefaultMapChunkTest()
        {
            var defaultRegion = new MapChunk();

            Assert.Equal(0, defaultRegion.Revision);
        }
        #endregion

        #region Parquets Replacement Methods
        [Fact]
        public void TrySetFloorFailsOnInvalidPositionTest()
        {
            var chunk = new MapChunk();
            var parquetID = TestEntities.TestFloor.ID;

            var result = chunk.TrySetFloorDefinition(parquetID, invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFloorSucceedsOnDefaultParquetAndPositionTest()
        {
            var chunk = new MapChunk();
            var parquetID = TestEntities.TestFloor.ID;

            var result = chunk.TrySetFloorDefinition(parquetID, Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TrySetBlockFailsOnInvalidPositionTest()
        {
            var chunk = new MapChunk();
            var parquetID = TestEntities.TestBlock.ID;

            var result = chunk.TrySetBlockDefinition(parquetID, invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetBlockSucceedsOnDefaultParquetAndPositionTest()
        {
            var chunk = new MapChunk();
            var parquetID = TestEntities.TestBlock.ID;

            var result = chunk.TrySetBlockDefinition(parquetID, Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TrySetFurnishingFailsOnInvalidPositionTest()
        {
            var chunk = new MapChunk();
            var parquetID = TestEntities.TestFurnishing.ID;

            var result = chunk.TrySetFurnishingDefinition(parquetID, invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFurnishingSucceedsOnDefaultParquetAndPositionTest()
        {
            var chunk = new MapChunk();
            var parquetID = TestEntities.TestFurnishing.ID;

            var result = chunk.TrySetFurnishingDefinition(parquetID, Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TrySetCollectibleFailsOnInvalidPositionTest()
        {
            var chunk = new MapChunk();
            var parquetID = TestEntities.TestCollectible.ID;

            var result = chunk.TrySetCollectibleDefinition(parquetID, invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetCollectibleSucceedsOnDefaultParquetAndPositionTest()
        {
            var chunk = new MapChunk();
            var parquetID = TestEntities.TestCollectible.ID;

            var result = chunk.TrySetCollectibleDefinition(parquetID, Vector2Int.ZeroVector);

            Assert.True(result);
        }
        #endregion

        #region Special Location Methods
        [Fact]
        public void TrySetSpawnPointFailsOnInvalidPositionTest()
        {
            var chunk = new MapChunk();
            var point = new SpawnPoint(invalidPosition, SpawnType.Player);

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
            var point = new SpawnPoint(invalidPosition, SpawnType.Player);

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
            var point = new ExitPoint(invalidPosition, new Guid());

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
            var point = new ExitPoint(invalidPosition, new Guid());

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

            var specialData = chunk.GetSpecialPointsAtPosition(invalidPosition);

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
            var result = MapChunk.TryDeserializeFromString(null, out var mapChunkResults);

            Assert.Null(mapChunkResults);
            Assert.False(result);
        }

        [Fact]
        public void DeserializingUnsupportedVersionFailsTest()
        {
            var result = MapChunk.TryDeserializeFromString(SerializedMapChunksForTest.UnsupportedVersionString,
                                                           out var mapChunkResults);

            Assert.Null(mapChunkResults);
            Assert.False(result);
        }

        [Fact]
        public void DeserializingKnownBadStringFailsTest()
        {
            var result = MapChunk.TryDeserializeFromString(SerializedMapChunksForTest.NonJsonString,
                                                           out var mapChunkResults);

            Assert.Null(mapChunkResults);
            Assert.False(result);
        }

        [Fact]
        public void DeserializingKnownGoodStringSucceedsTest()
        {
            var result = MapChunk.TryDeserializeFromString(SerializedMapChunksForTest.KnownGoodString,
                                                           out var mapChunkResults);

            Assert.NotNull(mapChunkResults);
            Assert.True(result);
        }
        #endregion

        #region State Query Methods
        [Fact]
        public void GetDefinitionReturnsNoneOnInvalidPositionTest()
        {
            var chunk = new MapChunk().FillTestPattern();

            var result = chunk.GetDefinitionAtPosition(invalidPosition);

            Assert.Equal(EntityID.None, result.Floor);
            Assert.Equal(EntityID.None, result.Block);
            Assert.Equal(EntityID.None, result.Furnishing);
            Assert.Equal(EntityID.None, result.Collectible);
        }

        [Fact]
        public void GetDefinitionReturnsNoneOnEmptyMapTest()
        {
            var chunk = new MapChunk();

            var result = chunk.GetDefinitionAtPosition(Vector2Int.ZeroVector);

            Assert.Equal(EntityID.None, result.Floor);
            Assert.Equal(EntityID.None, result.Block);
            Assert.Equal(EntityID.None, result.Furnishing);
            Assert.Equal(EntityID.None, result.Collectible);
        }
        #endregion
    }
}
