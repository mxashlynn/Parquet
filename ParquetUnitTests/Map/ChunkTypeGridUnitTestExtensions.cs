using ParquetClassLibrary;
using ParquetClassLibrary.Maps;

namespace ParquetUnitTests.Map
{
    /// <summary>
    /// Provides extension methods for <see cref="ChunkTypeGrid"/> used in unit testing.
    /// </summary>
    internal static class ChunkTypeGridUnitTestExtensions
    {
        private static readonly ChunkType grassyChunk = new ChunkType(ChunkTopography.Solid, "grassy", ChunkTopography.Empty, "");
        private static readonly ChunkType sandyLakeChunk = new ChunkType(ChunkTopography.Solid, "sandy", ChunkTopography.Central, "watery");
        private static readonly ChunkType icyChunk = new ChunkType(ChunkTopography.Solid, "snowy", ChunkTopography.Scattered, "icy");

        /// <summary>Fills the chunk grid with a test pattern.</summary>
        public static ChunkTypeGrid FillTestPattern(this ChunkTypeGrid inMapChunkGrid)
        {
            for (var y = 0; y < Rules.Dimensions.ChunksPerRegion; y++)
            {
                for (var x = 0; x < Rules.Dimensions.ChunksPerRegion; x++)
                {
                    inMapChunkGrid[y, x] = grassyChunk;
                }
            }

            inMapChunkGrid[1, 1] = sandyLakeChunk;
            inMapChunkGrid[2, 2] = sandyLakeChunk;
            inMapChunkGrid[3, 2] = sandyLakeChunk;
            inMapChunkGrid[4, 2] = icyChunk;

            return inMapChunkGrid;
        }
    }
}
