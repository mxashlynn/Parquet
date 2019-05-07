using ParquetClassLibrary;
using ParquetClassLibrary.Map;
using ParquetClassLibrary.Stubs;
using ParquetUnitTests.Sandbox.Parquets;

namespace ParquetUnitTests.Sandbox
{
    /// <summary>
    /// Provides extension methods for the <see cref="MapRegion"/> used in unit testing.
    /// </summary>
    internal static class MapRegionUnitTestExtensions
    {
        /// <summary>Fills the region with a test pattern.</summary>
        public static MapRegion FillTestPattern(this MapRegion in_mapRegion)
        {
            for (var x = 0; x < All.Dimensions.ParquetsPerRegion; x++)
            {
                for (var y = 0; y < All.Dimensions.ParquetsPerRegion; y++)
                {
                    in_mapRegion.TrySetFloor(TestEntities.TestFloor.ID, new Vector2Int(x, y));
                }

                in_mapRegion.TrySetBlock(TestEntities.TestBlock.ID, new Vector2Int(x, 0));
                in_mapRegion.TrySetBlock(TestEntities.TestBlock.ID, new Vector2Int(x, All.Dimensions.ParquetsPerRegion - 1));
            }
            for (var y = 0; y < All.Dimensions.ParquetsPerRegion; y++)
            {
                in_mapRegion.TrySetBlock(TestEntities.TestBlock.ID, new Vector2Int(0, y));
                in_mapRegion.TrySetBlock(TestEntities.TestBlock.ID, new Vector2Int(All.Dimensions.ParquetsPerRegion - 1, y));
            }
            in_mapRegion.TrySetFurnishing(TestEntities.TestFurnishing.ID, new Vector2Int(1, 2));
            in_mapRegion.TrySetCollectible(TestEntities.TestCollectible.ID, new Vector2Int(3, 3));

            return in_mapRegion;
        }
    }
}
