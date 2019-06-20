using System;
using System.Reflection;
using ParquetClassLibrary;
using ParquetClassLibrary.Map;
using ParquetClassLibrary.Map.SpecialPoints;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Stubs;
using Xunit;

namespace ParquetUnitTests.Map
{
    public class MapChunkUnitTest
    {
        #region Values for Tests
        private static readonly Vector2Int invalidPosition = new Vector2Int(-1, -1);
        private static readonly MapChunk defaultChunk = new MapChunk().FillTestPattern();
        #endregion

        #region Initialization
        [Fact]
        public void NewDefaultMapChunkTest()
        {
            Assert.Equal(0, defaultChunk.Revision);
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

        #region Subregion Methods
        [Fact]
        public void GetSubregionThrowsOnInvalidUpperLeftTest()
        {
            var invalidUpperLeft = invalidPosition;
            var validLowerRight = new Vector2Int(defaultChunk.DimensionsInParquets.X - 1,
                                                 defaultChunk.DimensionsInParquets.Y - 1);

            void InvalidSubregion()
            {
                var _ = defaultChunk.GetSubregion(invalidUpperLeft, validLowerRight);
            }

            Assert.Throws<ArgumentOutOfRangeException>(InvalidSubregion);
        }

        [Fact]
        public void GetSubregionThrowsOnInvalidLowerRightTest()
        {
            var validUpperLeft = Vector2Int.ZeroVector;
            var invalidLowerRight = defaultChunk.DimensionsInParquets;

            void InvalidSubregion()
            {
                var _ = defaultChunk.GetSubregion(validUpperLeft, invalidLowerRight);
            }

            Assert.Throws<ArgumentOutOfRangeException>(InvalidSubregion);
        }

        [Fact]
        public void GetSubregionThrowsOnInvalidOrderingTest()
        {
            var validUpperLeft = Vector2Int.ZeroVector;
            var validLowerRight = new Vector2Int(defaultChunk.DimensionsInParquets.X - 1,
                                                 defaultChunk.DimensionsInParquets.Y - 1);

            void InvalidSubregion()
            {
                var _ = defaultChunk.GetSubregion(validLowerRight, validUpperLeft);
            }

            Assert.Throws<ArgumentException>(InvalidSubregion);
        }

        [Fact]
        public void GetSubregionMatchesPattern()
        {
            var originalChunk = typeof(MapChunk)
                                .GetProperty("ParquetDefintion", BindingFlags.NonPublic | BindingFlags.Instance)
                                ?.GetValue(defaultChunk) as ParquetStack[,];
            var validUpperLeft = new Vector2Int(1, 4);
            var validLowerRight = new Vector2Int(10, 14);

            var subregion = defaultChunk.GetSubregion();

            for (var x = validUpperLeft.X; x < validLowerRight.X; x++)
            {
                for (var y = validUpperLeft.Y; y < validLowerRight.Y; y++)
                {
                    Assert.Equal(subregion[x, y], originalChunk[x, y]);
                }
            }
        }

        [Fact]
        public void GetSubregionOnWholeSubregionMatchesPattern()
        {
            var originalChunk = typeof(MapChunk)
                                .GetProperty("ParquetDefintion", BindingFlags.NonPublic | BindingFlags.Instance)
                                ?.GetValue(defaultChunk) as ParquetStack[,];

            var subregion = defaultChunk.GetSubregion();

            for (var x = 0; x < defaultChunk.DimensionsInParquets.X; x++)
            {
                for (var y = 0; y < defaultChunk.DimensionsInParquets.Y; y++)
                {
                    Assert.Equal(subregion[x, y], originalChunk[x, y]);
                }
            }
        }
        #endregion
    }
}
