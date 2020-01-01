using System;
using ParquetClassLibrary;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Utilities;
using Xunit;

namespace ParquetUnitTests.Map
{
    public class ChunkTypeGridUnitTest
    {
        #region Values for Tests
        private static readonly Vector2D invalidPosition = new Vector2D(-1, -1);
        private static readonly PCLColor testColor = new PCLColor(255, 128, 26, 230);
        private const string testTitle = "Test Region";
        private const int testElevation = 4;
        private static readonly EntityID testID = TestEntities.TestMapRegion.ID + 3;
        private static readonly ChunkType testChunk = new ChunkType(ChunkTopography.Solid, "test base", ChunkTopography.Scattered, "test modifier");
        #endregion

        #region Initialization
        [Fact]
        public void NewDefaultMapChunkGridTest()
        {
            var defaultGrid = new ChunkTypeGrid();

            Assert.Equal(MapRegion.DefaultTitle, defaultGrid.Title);
            Assert.Equal(MapRegion.DefaultColor, defaultGrid.Background);
        }

        [Fact]
        public void NewNullMapChunkGridTest()
        {
            var nulledGrid = new ChunkTypeGrid(null);

            Assert.Equal(MapRegion.DefaultTitle, nulledGrid.Title);
            Assert.Equal(MapRegion.DefaultColor, nulledGrid.Background);
        }

        [Fact]
        public void NewCustomMapChunkGridTest()
        {
            var customRegion = new ChunkTypeGrid(testID, testTitle, testColor, testElevation);

            Assert.Equal(testID, customRegion.RegionID);
            Assert.Equal(testTitle, customRegion.Title);
            Assert.Equal(testColor, customRegion.Background);
            Assert.Equal(testElevation, customRegion.GlobalElevation);
        }
        #endregion

        #region Chunks
        [Fact]
        public void SetGetChunkFailsOnInvalidPositionTest()
        {
            var grid = new ChunkTypeGrid();

            void TestCode()
            {
                grid[invalidPosition.Y, invalidPosition.X] = testChunk;
            }

            Assert.Throws<IndexOutOfRangeException>(TestCode);
        }

        [Fact]
        public void SetGetChunkSucceedsOnOriginPositionTest()
        {
            var grid = new ChunkTypeGrid();
            grid[Vector2D.Zero.Y, Vector2D.Zero.X] = testChunk;

            var returnedChunk = grid[Vector2D.Zero.Y, Vector2D.Zero.Y];

            Assert.Equal(testChunk, returnedChunk);
        }
        #endregion
    }
}
