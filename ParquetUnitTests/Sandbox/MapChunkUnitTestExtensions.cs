using ParquetClassLibrary.Sandbox;
using ParquetClassLibrary.Stubs;
using ParquetUnitTests.Sandbox.Parquets;

namespace ParquetUnitTests.Sandbox
{
    internal static class MapChunkUnitTestExtensions
    {
        /// <summary>Fills the chunk with a test pattern.</summary>
        public static MapChunk FillTestPattern(this MapChunk in_mapChunk)
        {
            for (var x = 0; x < in_mapChunk.DimensionsInParquets.x; x++)
            {
                for (var y = 0; y < in_mapChunk.DimensionsInParquets.y; y++)
                {
                    in_mapChunk.TrySetFloor(TestParquets.TestFloor.ID, new Vector2Int(x, y));
                }

                in_mapChunk.TrySetBlock(TestParquets.TestBlock.ID, new Vector2Int(x, 0));
                in_mapChunk.TrySetBlock(TestParquets.TestBlock.ID, new Vector2Int(x, in_mapChunk.DimensionsInParquets.y - 1));
            }
            for (var y = 0; y < in_mapChunk.DimensionsInParquets.y; y++)
            {
                in_mapChunk.TrySetBlock(TestParquets.TestBlock.ID, new Vector2Int(0, y));
                in_mapChunk.TrySetBlock(TestParquets.TestBlock.ID, new Vector2Int(in_mapChunk.DimensionsInParquets.x - 1, y));
            }
            in_mapChunk.TrySetFurnishing(TestParquets.TestFurnishing.ID, new Vector2Int(1, 2));
            in_mapChunk.TrySetCollectable(TestParquets.TestCollectable.ID, new Vector2Int(3, 3));

            return in_mapChunk;
        }
    }
}
