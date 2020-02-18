using System;
using ParquetClassLibrary;
using ParquetClassLibrary.Maps;
using Xunit;

namespace ParquetUnitTests.Maps
{
    public class ChunkTypeGridUnitTest
    {
        #region Values for Tests
        private static readonly Vector2D invalidPosition = new Vector2D(-1, -1);
        private const string testColor = "#FF8822EE";
        private const string testTitle = "Test Region";
        private const int testElevation = 4;
        private static readonly EntityID testID = TestModels.TestMapRegion.ID + 3;
        private static readonly ChunkType testChunk = new ChunkType(ChunkTopography.Solid, "test base", ChunkTopography.Scattered, "test modifier");
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

            ChunkType returnedChunk = grid[Vector2D.Zero.Y, Vector2D.Zero.Y];

            Assert.Equal(testChunk, returnedChunk);
        }
        #endregion
    }
}
