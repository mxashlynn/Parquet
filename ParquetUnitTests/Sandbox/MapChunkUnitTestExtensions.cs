using ParquetClassLibrary.Sandbox;
using ParquetClassLibrary.Sandbox.Parquets;
using ParquetClassLibrary.Sandbox.ID;
using ParquetClassLibrary.Stubs;

namespace ParquetUnitTests.Sandbox
{
    internal static class MapChunkUnitTestExtensions
    {
        /// <summary>Fills the chunk with a test pattern.</summary>
        public static MapChunk FillTestPattern(this MapChunk in_mapChunk)
        {
            for (var x = 0; x < MapChunk.DimensionsInParquets.x; x++)
            {
                for (var y = 0; y < MapChunk.DimensionsInParquets.y; y++)
                {
                    in_mapChunk.TrySetFloor(AllParquets.TestFloor, new Vector2Int(x, y));
                }

                in_mapChunk.TrySetBlock(AllParquets.TestBlock, new Vector2Int(x, 0));
                in_mapChunk.TrySetBlock(AllParquets.TestBlock, new Vector2Int(x, MapChunk.DimensionsInParquets.y - 1));
            }
            for (var y = 0; y < MapChunk.DimensionsInParquets.y; y++)
            {
                in_mapChunk.TrySetBlock(AllParquets.TestBlock, new Vector2Int(0, y));
                in_mapChunk.TrySetBlock(AllParquets.TestBlock, new Vector2Int(MapChunk.DimensionsInParquets.x - 1, y));
            }
            in_mapChunk.TrySetFurnishing(AllParquets.TestFurnishing, new Vector2Int(1, 2));
            in_mapChunk.TrySetCollectable(AllParquets.TestCollectable, new Vector2Int(3, 3));

            return in_mapChunk;
        }
    }
}
