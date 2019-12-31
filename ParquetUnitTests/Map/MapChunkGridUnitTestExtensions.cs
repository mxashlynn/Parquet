using ParquetClassLibrary;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Utilities;

namespace ParquetUnitTests.Map
{
    /// <summary>
    /// Provides extension methods for <see cref="ChunkTypeGridCollection"/> used in unit testing.
    /// </summary>
    internal static class MapChunkGridUnitTestExtensions
    {
        private static readonly ChunkType grassyChunk = new ChunkType(ChunkTopography.Solid, "grassy", ChunkTopography.Empty, "");
        private static readonly ChunkType sandyLakeChunk = new ChunkType(ChunkTopography.Solid, "sandy", ChunkTopography.Central, "watery");
        private static readonly ChunkType icyChunk = new ChunkType(ChunkTopography.Solid, "snowy", ChunkTopography.Scattered, "icy");

        /// <summary>Fills the chunk grid with a test pattern.</summary>
        public static ChunkTypeGridCollection FillTestPattern(this ChunkTypeGridCollection inMapChunkGrid)
        {
            for (var y = 0; y < Rules.Dimensions.ChunksPerRegion; y++)
            {
                for (var x = 0; x < Rules.Dimensions.ChunksPerRegion; x++)
                {
                    inMapChunkGrid.SetChunk(grassyChunk, new Vector2D(x, y));
                }
            }

            inMapChunkGrid.SetChunk(sandyLakeChunk, new Vector2D(1, 1));
            inMapChunkGrid.SetChunk(sandyLakeChunk, new Vector2D(2, 2));
            inMapChunkGrid.SetChunk(sandyLakeChunk, new Vector2D(3, 2));
            inMapChunkGrid.SetChunk(icyChunk, new Vector2D(4, 2));

            return inMapChunkGrid;
        }
    }
}
