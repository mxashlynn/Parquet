using ParquetClassLibrary.Maps;

namespace ParquetUnitTests.Maps
{
    /// <summary>
    /// Provides extension methods for <see cref="ChunkDescriptionGrid"/> used in unit testing.
    /// </summary>
    internal static class ChunkDescriptionGridUnitTestExtensions
    {
        private static readonly ChunkDescription grassyChunk = new ChunkDescription(ChunkTopography.Solid, "grassy", ChunkTopography.Empty, "");
        private static readonly ChunkDescription sandyLakeChunk = new ChunkDescription(ChunkTopography.Solid, "sandy", ChunkTopography.Central, "watery");
        private static readonly ChunkDescription icyChunk = new ChunkDescription(ChunkTopography.Solid, "snowy", ChunkTopography.Scattered, "icy");

        /// <summary>Fills the chunk grid with a test pattern.</summary>
        public static ChunkDescriptionGrid FillTestPattern(this ChunkDescriptionGrid inMapChunkGrid)
        {
            for (var y = 0; y < MapRegion.ChunksPerRegionDimension; y++)
            {
                for (var x = 0; x < MapRegion.ChunksPerRegionDimension; x++)
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
