using ParquetClassLibrary;
using ParquetClassLibrary.Sandbox;
using ParquetClassLibrary.Sandbox.IDs;
using ParquetClassLibrary.Stubs;

namespace ParquetUnitTests.Sandbox
{
    /// <summary>
    /// Provides extension methods for <see cref="T:ParquetClassLibrary.Sandbox.MapChunkGrid"/> used in unit testing.
    /// </summary>
    internal static class MapChunkGridUnitTestExtensions
    {
        /// <summary>Fills the chunk grid with a test pattern.</summary>
        public static MapChunkGrid FillTestPattern(this MapChunkGrid in_mapChunkGrid)
        {
            for (var x = 0; x < AssemblyInfo.ChunksPerRegionDimension; x++)
            {
                for (var y = 0; y < AssemblyInfo.ChunksPerRegionDimension; y++)
                {
                    in_mapChunkGrid.SetChunk(ChunkType.GrassyField, ChunkOrientation.None, new Vector2Int(x, y));
                }
            }

            in_mapChunkGrid.SetChunk(ChunkType.SandyLake, ChunkOrientation.None, new Vector2Int(1, 1));
            in_mapChunkGrid.SetChunk(ChunkType.IcyCave, ChunkOrientation.EastWest, new Vector2Int(2, 2));
            in_mapChunkGrid.SetChunk(ChunkType.IcyCave, ChunkOrientation.NorthSouth, new Vector2Int(3, 2));
            in_mapChunkGrid.SetChunk(ChunkType.IcyCave, ChunkOrientation.NorthWest, new Vector2Int(4, 2));

            return in_mapChunkGrid;
        }
    }
}
