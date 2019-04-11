using System;
using ParquetClassLibrary.Sandbox;
using ParquetClassLibrary.Sandbox.IDs;
using ParquetClassLibrary.Stubs;
using Xunit;

namespace ParquetUnitTests.Sandbox
{
    public class MapChunkGridUnitTest
    {
        #region Values for Tests
        private static readonly Vector2Int invalidPosition = new Vector2Int(-1, -1);
        private static readonly Color testColor = new Color(255, 128, 26, 230);
        private const string testTitle = "Test Region";
        private const int testElevation = 4;
        private static readonly Guid testID = Guid.Parse("ead51b96-21d5-4619-86e9-462a52564089");
        #endregion

        #region Initialization
        [Fact]
        public void NewDefaultMapChunkGridTest()
        {
            var defaultGrid = new MapChunkGrid();

            Assert.Equal(MapRegion.DefaultTitle, defaultGrid.Title);
            Assert.Equal(MapRegion.DefaultColor, defaultGrid.Background);
        }

        [Fact]
        public void NewNullMapChunkGridTest()
        {
            var nulledGrid = new MapChunkGrid(null);

            Assert.Equal(MapRegion.DefaultTitle, nulledGrid.Title);
            Assert.Equal(MapRegion.DefaultColor, nulledGrid.Background);
        }

        [Fact]
        public void NewCustomMapChunkGridTest()
        {
            var customRegion = new MapChunkGrid(testTitle, testColor, testElevation, testID);

            Assert.Equal(testTitle, customRegion.Title);
            Assert.Equal(testColor, customRegion.Background);
            Assert.Equal(testElevation, customRegion.GlobalElevation);
            Assert.Equal(testID, customRegion.RegionID);
        }
        #endregion

        #region Chunk Methods
        [Fact]
        public void SetChunkFailsOnInvalidPositionTest()
        {
            var grid = new MapChunkGrid();

            var wasSet = grid.SetChunk(ChunkType.Handmade, ChunkOrientation.EastWest, invalidPosition);

            Assert.False(wasSet);
        }

        [Fact]
        public void SetChunkSucceedsOnOriginPositionTest()
        {
            var grid = new MapChunkGrid();
            var chunkType = ChunkType.Handmade;
            var chunkOrientation = ChunkOrientation.EastWest;

            var wasSet = grid.SetChunk(chunkType, chunkOrientation, Vector2Int.ZeroVector);

            Assert.True(wasSet);
        }

        [Fact]
        public void GetChunkFailsOnInvalidPositionTest()
        {
            var grid = new MapChunkGrid();

            var chunkData = grid.GetChunk(invalidPosition);

            Assert.Null(chunkData);
        }

        [Fact]
        public void GetChunkSucceedsOnOriginPositionTest()
        {
            var grid = new MapChunkGrid();
            var chunkType = ChunkType.Handmade;
            var chunkOrientation = ChunkOrientation.EastWest;

            var wasSet = grid.SetChunk(chunkType, chunkOrientation, Vector2Int.ZeroVector);

            var chunkData = grid.GetChunk(Vector2Int.ZeroVector).GetValueOrDefault();

            Assert.True(wasSet);
            Assert.Equal(chunkData.type, chunkType);
            Assert.Equal(chunkData.orientation, chunkOrientation);
        }
        #endregion

        #region Serialization Methods
        [Fact]
        public void SerializingKnownMapProducesKnownStringTest()
        {
            var grid = new MapChunkGrid(false).FillTestPattern();

            var result = grid.SerializeToString();

            Assert.Equal(SerializedMapChunkGridsForTest.KnownGoodString, result);
        }

        [Fact]
        public void DeserializingNullFailsTest()
        {
            var result = MapChunkGrid.TryDeserializeFromString(null, out var mapGridResults);

            Assert.Null(mapGridResults);
            Assert.False(result);
        }

        [Fact]
        public void DeserializingUnsupportedVersionFailsTest()
        {
            var result = MapChunkGrid.TryDeserializeFromString(SerializedMapChunkGridsForTest.UnsupportedVersionString,
                                                               out var mapChunkGridResults);

            Assert.Null(mapChunkGridResults);
            Assert.False(result);
        }

        [Fact]
        public void DeserializingKnownBadStringFailsTest()
        {
            var result = MapChunkGrid.TryDeserializeFromString(SerializedMapChunkGridsForTest.NonJsonString,
                                                               out var mapChunkGridResults);

            Assert.Null(mapChunkGridResults);
            Assert.False(result);
        }

        [Fact]
        public void DeserializingKnownGoodStringSucceedsTest()
        {
            var result = MapChunkGrid.TryDeserializeFromString(SerializedMapChunkGridsForTest.KnownGoodString,
                                                               out var mapChunkGridResults);

            Assert.NotNull(mapChunkGridResults);
            Assert.True(result);
        }
        #endregion
    }
}
