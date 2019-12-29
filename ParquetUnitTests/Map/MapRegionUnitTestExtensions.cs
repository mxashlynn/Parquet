using ParquetClassLibrary;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Utilities;

namespace ParquetUnitTests.Map
{
    /// <summary>
    /// Provides extension methods for the <see cref="MapRegion"/> used in unit testing.
    /// </summary>
    internal static class MapRegionUnitTestExtensions
    {
        /// <summary>Fills the region with a test pattern.</summary>
        public static MapRegion FillTestPattern(this MapRegion in_mapRegion)
        {
            for (var x = 0; x < Rules.Dimensions.ParquetsPerRegion; x++)
            {
                for (var y = 0; y < Rules.Dimensions.ParquetsPerRegion; y++)
                {
                    in_mapRegion.TrySetFloorDefinition(TestEntities.TestFloor.ID, new Vector2D(x, y));
                }

                in_mapRegion.TrySetBlockDefinition(TestEntities.TestBlock.ID, new Vector2D(x, 0));
                in_mapRegion.TrySetBlockDefinition(TestEntities.TestBlock.ID, new Vector2D(x, Rules.Dimensions.ParquetsPerRegion - 1));
            }
            for (var y = 0; y < Rules.Dimensions.ParquetsPerRegion; y++)
            {
                in_mapRegion.TrySetBlockDefinition(TestEntities.TestBlock.ID, new Vector2D(0, y));
                in_mapRegion.TrySetBlockDefinition(TestEntities.TestBlock.ID, new Vector2D(Rules.Dimensions.ParquetsPerRegion - 1, y));
            }
            in_mapRegion.TrySetFurnishingDefinition(TestEntities.TestFurnishing.ID, new Vector2D(1, 2));
            in_mapRegion.TrySetCollectibleDefinition(TestEntities.TestCollectible.ID, new Vector2D(3, 3));

            return in_mapRegion;
        }
    }
}
