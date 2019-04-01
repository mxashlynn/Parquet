using ParquetClassLibrary;
using ParquetClassLibrary.Sandbox;
using ParquetClassLibrary.Stubs;
using ParquetUnitTests.Sandbox.Parquets;

namespace ParquetUnitTests.Sandbox
{
    /// <summary>
    /// Provides extension methods for the <see cref="T:ParquetClassLibrary.Sandbox.MapRegion"/> used in unit testing.
    /// </summary>
    internal static class MapRegionUnitTestExtensions
    {
        /// <summary>Fills the region with a test pattern.</summary>
        public static MapRegion FillTestPattern(this MapRegion in_mapRegion)
        {
            for (var x = 0; x < AssemblyInfo.ParquetsPerRegionDimension; x++)
            {
                for (var y = 0; y < AssemblyInfo.ParquetsPerRegionDimension; y++)
                {
                    in_mapRegion.TrySetFloor(TestParquets.TestFloor.ID, new Vector2Int(x, y));
                }

                in_mapRegion.TrySetBlock(TestParquets.TestBlock.ID, new Vector2Int(x, 0));
                in_mapRegion.TrySetBlock(TestParquets.TestBlock.ID, new Vector2Int(x, AssemblyInfo.ParquetsPerRegionDimension - 1));
            }
            for (var y = 0; y < AssemblyInfo.ParquetsPerRegionDimension; y++)
            {
                in_mapRegion.TrySetBlock(TestParquets.TestBlock.ID, new Vector2Int(0, y));
                in_mapRegion.TrySetBlock(TestParquets.TestBlock.ID, new Vector2Int(AssemblyInfo.ParquetsPerRegionDimension - 1, y));
            }
            in_mapRegion.TrySetFurnishing(TestParquets.TestFurnishing.ID, new Vector2Int(1, 2));
            in_mapRegion.TrySetCollectible(TestParquets.TestCollectible.ID, new Vector2Int(3, 3));

            return in_mapRegion;
        }
    }
}
