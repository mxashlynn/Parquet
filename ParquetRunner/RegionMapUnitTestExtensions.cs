using ParquetClassLibrary.Sandbox;
using ParquetClassLibrary.Sandbox.Parquets;
using ParquetClassLibrary.Sandbox.ID;
using ParquetClassLibrary.Stubs;

namespace ParquetRunner
{
    internal static class RegionMapUnitTestExtensions
    {
        /// <summary>Fills the region with a test pattern.</summary>
        public static RegionMap FillTestPattern(this RegionMap in_regionMap)
        {
            for (var x = 0; x < RegionMap.Dimensions.x; x++)
            {
                for (var y = 0; y < RegionMap.Dimensions.y; y++)
                {
                    in_regionMap.TrySetFloor(new Floor(Floors.SandSand), new Vector2Int(x, y));
                }

                in_regionMap.TrySetBlock(new Block(Blocks.Brick), new Vector2Int(x, 0));
                in_regionMap.TrySetBlock(new Block(Blocks.Brick), new Vector2Int(x, RegionMap.Dimensions.y - 1));
            }
            for (var y = 0; y < RegionMap.Dimensions.y; y++)
            {
                in_regionMap.TrySetBlock(new Block(Blocks.Brick), new Vector2Int(0, y));
                in_regionMap.TrySetBlock(new Block(Blocks.Brick), new Vector2Int(RegionMap.Dimensions.x - 1, y));
            }
            in_regionMap.TrySetFurnishing(new Furnishing(Furnishings.Chair), new Vector2Int(1, 2));
            in_regionMap.TrySetCollectable(new Collectable(Collectables.Flower), new Vector2Int(3, 3));

            return in_regionMap;
        }
    }
}
