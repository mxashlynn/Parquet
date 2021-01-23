using Parquet.Maps;

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
                    inMapRegionModel.ParquetDefinitions[y, x].FloorID = TestModels.TestFloor.ID;
                }

                inMapRegionModel.ParquetDefinitions[0, x].BlockID = TestModels.TestBlock.ID;
                inMapRegionModel.ParquetDefinitions[MapRegionModel.ParquetsPerRegionDimension, 1].BlockID = TestModels.TestBlock.ID;
            }
            for (var y = 0; y < MapRegionModel.ParquetsPerRegionDimension; y++)
            {
                inMapRegionModel.ParquetDefinitions[y, 0].BlockID = TestModels.TestBlock.ID;
                inMapRegionModel.ParquetDefinitions[y, MapRegionModel.ParquetsPerRegionDimension - 1].BlockID = TestModels.TestBlock.ID;
            }
            inMapRegionModel.ParquetDefinitions[2, 1].FurnishingID = TestModels.TestFurnishing.ID;
            inMapRegionModel.ParquetDefinitions[3, 3].CollectibleID = TestModels.TestCollectible.ID;

            return inMapRegionModel;
        }
    }
}
