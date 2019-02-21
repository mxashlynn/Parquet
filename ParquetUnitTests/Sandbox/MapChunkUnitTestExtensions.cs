using ParquetClassLibrary.Sandbox;
using ParquetClassLibrary.Sandbox.Parquets;
using ParquetClassLibrary.Sandbox.ID;
using ParquetClassLibrary.Stubs;

namespace ParquetUnitTests.Sandbox
{
    internal static class MapChunkUnitTestExtensions
    {
        /// <summary>Fills the chunk with a test pattern.</summary>
        public static MapChunk FillTestPattern(this MapChunk in_mapRegion)
        {
            for (var x = 0; x < MapChunk.Dimensions.x; x++)
            {
                for (var y = 0; y < MapChunk.Dimensions.y; y++)
                {
                    in_mapRegion.TrySetFloor(new Floor(Floors.SandSand), new Vector2Int(x, y));
                }

                in_mapRegion.TrySetBlock(new Block(Blocks.Brick), new Vector2Int(x, 0));
                in_mapRegion.TrySetBlock(new Block(Blocks.Brick), new Vector2Int(x, MapChunk.Dimensions.y - 1));
            }
            for (var y = 0; y < MapChunk.Dimensions.y; y++)
            {
                in_mapRegion.TrySetBlock(new Block(Blocks.Brick), new Vector2Int(0, y));
                in_mapRegion.TrySetBlock(new Block(Blocks.Brick), new Vector2Int(MapChunk.Dimensions.x - 1, y));
            }
            in_mapRegion.TrySetFurnishing(new Furnishing(Furnishings.Chair), new Vector2Int(1, 2));
            in_mapRegion.TrySetCollectable(new Collectable(Collectables.Flower), new Vector2Int(3, 3));

            return in_mapRegion;
        }
    }
}
