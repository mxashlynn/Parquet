using Xunit;
using System;
using ParquetClassLibrary.Sandbox;
using ParquetClassLibrary.Sandbox.SpecialPoints;
using ParquetClassLibrary.Sandbox.Parquets;
using ParquetClassLibrary.Stubs;

namespace ParquetUnitTests.Sandbox
{
    public class MapChunkGridUnitTest
    {
        #region Values for Tests
        private readonly Vector2Int InvalidPosition = new Vector2Int(-1, -1);
        private readonly Color TestColor = new Color(255, 128, 26, 230);
        private const string TestTitle = "New Region";
        private const int TestElevation = 4;
        private readonly Guid TestID = Guid.Parse("2F06E2CB-72D7-437F-ABA8-0D360AEDEA98");
        #endregion

        #region Initialization
        [Fact]
        public void NewDefaultMapChunkGridTest()
        {
            var defaultGrid = new MapChunkGrid();

            Assert.Equal(MapChunkGrid.DefaultTitle, defaultGrid.Title);
            Assert.Equal(MapChunkGrid.DefaultColor, defaultGrid.Background);
        }

        [Fact]
        public void NewNullMapRegionTest()
        {
            var nulledGrid = new MapRegion(null, null);

            Assert.Equal(MapRegion.DefaultTitle, nulledGrid.Title);
            Assert.Equal(MapChunkGrid.DefaultColor, nulledGrid.Background);
        }

        [Fact]
        public void NewCustomMapRegionTest()
        {
            var customRegion = new MapRegion(TestTitle, TestColor);

            Assert.Equal(TestTitle, customRegion.Title);
            Assert.Equal(TestColor, customRegion.Background);
            Assert.Equal(TestElevation, customRegion.GlobalElevation);
            Assert.Equal(TestID, customRegion.RegionID);
        }
        #endregion

        #region Chunk Methods
        [Fact]
        public void SetChunkFailsOnInvalidPositionTest()
        {
            var grid = new MapChunkGrid();

            var wasSet = grid.SetChunk(ChunkType.Handmade, ChunkOrientation.EastWest, InvalidPosition);

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

            var chunkData = grid.GetChunk(InvalidPosition);

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
            var region = new MapChunkGrid(false).FillTestPattern();

            var result = region.SerializeToString();

            Assert.Equal(SerializedMapChunkGridsForTest.KnownGoodString, result);
        }

        [Fact]
        public void DeserializingNullFailsTest()
        {
            var result = MapChunkGrid.TryDeserializeFromString(null, out MapChunkGrid mapGridResults);

            Assert.Null(mapGridResults);
            Assert.False(result);
        }

        [Fact]
        public void DeserializingUnsupportedVersionFailsTest()
        {
            var result = MapChunkGrid.TryDeserializeFromString(SerializedMapChunkGridsForTest.UnsupportedVersionString,
                                                               out MapChunkGrid mapChunkGridResults);

            Assert.Null(mapChunkGridResults);
            Assert.False(result);
        }

        [Fact]
        public void DeserializingKnownBadStringFailsTest()
        {
            var result = MapChunkGrid.TryDeserializeFromString(SerializedMapChunkGridsForTest.NonJsonString,
                                                               out MapChunkGrid mapChunkGridResults);

            Assert.Null(mapChunkGridResults);
            Assert.False(result);
        }

        [Fact]
        public void DeserializingKnownGoodStringSucceedsTest()
        {
            var result = MapChunkGrid.TryDeserializeFromString(SerializedMapChunkGridsForTest.KnownGoodString,
                                                               out MapChunkGrid mapChunkGridResults);

            Assert.NotNull(mapChunkGridResults);
            Assert.True(result);
        }
        #endregion
    }
}
