using ParquetClassLibrary;
using ParquetClassLibrary.Map;
using ParquetClassLibrary.Utilities;

namespace ParquetUnitTests.Map
{
    /// <summary>
    /// Provides extension methods for <see cref="MapChunkGrid"/> used in unit testing.
    /// </summary>
    internal static class MapChunkGridUnitTestExtensions
    {
        /// <summary>Fills the chunk grid with a test pattern.</summary>
        public static MapChunkGrid FillTestPattern(this MapChunkGrid in_mapChunkGrid)
        {
            for (var y = 0; y < Rules.Dimensions.ChunksPerRegion; y++)
            {
                for (var x = 0; x < Rules.Dimensions.ChunksPerRegion; x++)
                {
                    in_mapChunkGrid.SetChunk(ChunkType.GrassyField, ChunkOrientation.None, new Vector2D(x, y));
                }
            }

            in_mapChunkGrid.SetChunk(ChunkType.SandyLake, ChunkOrientation.None, new Vector2D(1, 1));
            in_mapChunkGrid.SetChunk(ChunkType.IcyCave, ChunkOrientation.EastWest, new Vector2D(2, 2));
            in_mapChunkGrid.SetChunk(ChunkType.IcyCave, ChunkOrientation.NorthSouth, new Vector2D(3, 2));
            in_mapChunkGrid.SetChunk(ChunkType.IcyCave, ChunkOrientation.NorthWest, new Vector2D(4, 2));

            return in_mapChunkGrid;
        }
    }
}
