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
        public static MapRegion FillTestPattern(this MapRegion inMapRegion)
        {
            for (var x = 0; x < Rules.Dimensions.ParquetsPerRegion; x++)
            {
                for (var y = 0; y < Rules.Dimensions.ParquetsPerRegion; y++)
                {
                    inMapRegion.TrySetFloorDefinition(TestEntities.TestFloor.ID, new Vector2D(x, y));
                }

                inMapRegion.TrySetBlockDefinition(TestEntities.TestBlock.ID, new Vector2D(x, 0));
                inMapRegion.TrySetBlockDefinition(TestEntities.TestBlock.ID, new Vector2D(x, Rules.Dimensions.ParquetsPerRegion - 1));
            }
            for (var y = 0; y < Rules.Dimensions.ParquetsPerRegion; y++)
            {
                inMapRegion.TrySetBlockDefinition(TestEntities.TestBlock.ID, new Vector2D(0, y));
                inMapRegion.TrySetBlockDefinition(TestEntities.TestBlock.ID, new Vector2D(Rules.Dimensions.ParquetsPerRegion - 1, y));
            }
            inMapRegion.TrySetFurnishingDefinition(TestEntities.TestFurnishing.ID, new Vector2D(1, 2));
            inMapRegion.TrySetCollectibleDefinition(TestEntities.TestCollectible.ID, new Vector2D(3, 3));

            return inMapRegion;
        }
    }
}
