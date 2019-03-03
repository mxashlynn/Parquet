using ParquetClassLibrary;
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
            for (var x = 0; x < Assembly.ParquetsPerRegionDimension; x++)
            {
                for (var y = 0; y < Assembly.ParquetsPerRegionDimension; y++)
                {
                    in_mapRegion.TrySetFloor(AllParquets.TestFloor, new Vector2Int(x, y));
                }

                in_mapRegion.TrySetBlock(AllParquets.TestBlock, new Vector2Int(x, 0));
                in_mapRegion.TrySetBlock(AllParquets.TestBlock, new Vector2Int(x, Assembly.ParquetsPerRegionDimension - 1));
            }
            for (var y = 0; y < Assembly.ParquetsPerRegionDimension; y++)
            {
                in_mapRegion.TrySetBlock(AllParquets.TestBlock, new Vector2Int(0, y));
                in_mapRegion.TrySetBlock(AllParquets.TestBlock, new Vector2Int(Assembly.ParquetsPerRegionDimension - 1, y));
            }
            in_mapRegion.TrySetFurnishing(AllParquets.TestFurnishing, new Vector2Int(1, 2));
            in_mapRegion.TrySetCollectable(AllParquets.TestCollectable, new Vector2Int(3, 3));

            return in_mapRegion;
        }
    }
}
