using System;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Utilities;
using Xunit;

namespace ParquetUnitTests.Map
{
    public class MapChunkGridUnitTest
    {
        #region Values for Tests
        private static readonly Vector2D invalidPosition = new Vector2D(-1, -1);
        private static readonly PCLColor testColor = new PCLColor(255, 128, 26, 230);
        private const string testTitle = "Test Region";
        private const int testElevation = 4;
        private static readonly Guid testID = Guid.Parse("ead51b96-21d5-4619-86e9-462a52564089");
        private static readonly ChunkType testChunk = new ChunkType(ChunkTopography.Solid, "test base", ChunkTopography.Scattered, "test modifier");
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

        #region Chunks
        [Fact]
        public void SetGetChunkFailsOnInvalidPositionTest()
        {
            var grid = new MapChunkGrid();
            grid.SetChunk(testChunk, invalidPosition);

            var returnedChunk = grid.GetChunk(invalidPosition);

            Assert.NotEqual(testChunk, returnedChunk);
        }

        [Fact]
        public void SetGetChunkSucceedsOnOriginPositionTest()
        {
            var grid = new MapChunkGrid();
            grid.SetChunk(testChunk, Vector2D.Zero);

            var returnedChunk = grid.GetChunk(Vector2D.Zero);

            Assert.Equal(testChunk, returnedChunk);
        }
        #endregion
    }
}
