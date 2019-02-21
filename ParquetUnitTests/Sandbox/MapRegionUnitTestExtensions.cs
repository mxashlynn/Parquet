using ParquetClassLibrary.Sandbox;
using ParquetClassLibrary.Sandbox.Parquets;
using ParquetClassLibrary.Sandbox.ID;
using ParquetClassLibrary.Stubs;

namespace ParquetUnitTests.Sandbox
{
    internal static class MapRegionUnitTestExtensions
    {
        /// <summary>Fills the region with a test pattern.</summary>
        public static MapRegion FillTestPattern(this MapRegion in_mapRegion)
        {
            for (var x = 0; x < MapRegion.Dimensions.x; x++)
            {
                for (var y = 0; y < MapRegion.Dimensions.y; y++)
                {
                    in_mapRegion.TrySetFloor(new Floor(Floors.SandSand), new Vector2Int(x, y));
                }

                in_mapRegion.TrySetBlock(new Block(Blocks.Brick), new Vector2Int(x, 0));
                in_mapRegion.TrySetBlock(new Block(Blocks.Brick), new Vector2Int(x, MapRegion.Dimensions.y - 1));
            }
            for (var y = 0; y < MapRegion.Dimensions.y; y++)
            {
                in_mapRegion.TrySetBlock(new Block(Blocks.Brick), new Vector2Int(0, y));
                in_mapRegion.TrySetBlock(new Block(Blocks.Brick), new Vector2Int(MapRegion.Dimensions.x - 1, y));
            }
            in_mapRegion.TrySetFurnishing(new Furnishing(Furnishings.Chair), new Vector2Int(1, 2));
            in_mapRegion.TrySetCollectable(new Collectable(Collectables.Flower), new Vector2Int(3, 3));

            return in_mapRegion;
        }
    }
}
