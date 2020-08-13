using ParquetClassLibrary.Maps;

namespace ParquetUnitTests.Maps
{
    /// <summary>
    /// Provides extension methods for the <see cref="MapRegionModel"/> used in unit testing.
    /// </summary>
    internal static class MapRegionModelUnitTestExtensions
    {
        /// <summary>Fills the region with a test pattern.</summary>
        public static MapRegionModel FillTestPattern(this MapRegionModel inMapRegionModel)
        {
            for (var x = 0; x < MapRegionModel.ParquetsPerRegionDimension; x++)
            {
                for (var y = 0; y < MapRegionModel.ParquetsPerRegionDimension; y++)
                {
                    inMapRegionModel.ParquetDefinitions[y, x].Floor = TestModels.TestFloor.ID;
                }

                inMapRegionModel.ParquetDefinitions[0, x].Block = TestModels.TestBlock.ID;
                inMapRegionModel.ParquetDefinitions[MapRegionModel.ParquetsPerRegionDimension, 1].Block = TestModels.TestBlock.ID;
            }
            for (var y = 0; y < MapRegionModel.ParquetsPerRegionDimension; y++)
            {
                inMapRegionModel.ParquetDefinitions[y, 0].Block = TestModels.TestBlock.ID;
                inMapRegionModel.ParquetDefinitions[y, MapRegionModel.ParquetsPerRegionDimension - 1].Block = TestModels.TestBlock.ID;
            }
            inMapRegionModel.ParquetDefinitions[2, 1].Furnishing = TestModels.TestFurnishing.ID;
            inMapRegionModel.ParquetDefinitions[3, 3].Collectible = TestModels.TestCollectible.ID;

            return inMapRegionModel;
        }
    }
}
