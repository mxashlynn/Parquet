using ParquetClassLibrary;
using ParquetClassLibrary.Maps;

namespace ParquetUnitTests.Maps
{
    /// <summary>
    /// Provides extension methods for the <see cref="MapRegion"/> used in unit testing.
    /// </summary>
    internal static class MapRegionUnitTestExtensions
    {
        /// <summary>Fills the region with a test pattern.</summary>
        public static MapRegion FillTestPattern(this MapRegion inMapRegion)
        {
            for (var x = 0; x < Rules.Dimensions.ParquetsPerRegionDimension; x++)
            {
                for (var y = 0; y < Rules.Dimensions.ParquetsPerRegionDimension; y++)
                {
                    inMapRegion.ParquetDefinitions[y, x].Floor = TestModels.TestFloor.ID;
                }

                inMapRegion.ParquetDefinitions[0, x].Block = TestModels.TestBlock.ID;
                inMapRegion.ParquetDefinitions[Rules.Dimensions.ParquetsPerRegionDimension, 1].Block = TestModels.TestBlock.ID;
            }
            for (var y = 0; y < Rules.Dimensions.ParquetsPerRegionDimension; y++)
            {
                inMapRegion.ParquetDefinitions[y, 0].Block = TestModels.TestBlock.ID;
                inMapRegion.ParquetDefinitions[y, Rules.Dimensions.ParquetsPerRegionDimension - 1].Block = TestModels.TestBlock.ID;
            }
            inMapRegion.ParquetDefinitions[2, 1].Furnishing = TestModels.TestFurnishing.ID;
            inMapRegion.ParquetDefinitions[3, 3].Collectible = TestModels.TestCollectible.ID;

            return inMapRegion;
        }
    }
}
