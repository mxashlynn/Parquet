using Parquet.Regions;

namespace ParquetUnitTests.Maps
{
    /// <summary>
    /// Provides extension methods for the <see cref="RegionStatus"/> used in unit testing.
    /// </summary>
    internal static class RegionStatusUnitTestExtensions
    {
        /// <summary>Fills the region with a test pattern.</summary>
        public static RegionModel FillTestPattern(this RegionModel inMapRegionModel)
        {
            for (var x = 0; x < RegionStatus.ParquetsPerRegionDimension; x++)
            {
                for (var y = 0; y < RegionStatus.ParquetsPerRegionDimension; y++)
                {
                    inMapRegionModel.ParquetDefinitions[y, x].FloorID = TestModels.TestFloor.ID;
                }

                inMapRegionModel.ParquetDefinitions[0, x].BlockID = TestModels.TestBlock.ID;
                inMapRegionModel.ParquetDefinitions[RegionModel.ParquetsPerRegionDimension, 1].BlockID = TestModels.TestBlock.ID;
            }
            for (var y = 0; y < RegionStatus.ParquetsPerRegionDimension; y++)
            {
                inMapRegionModel.ParquetDefinitions[y, 0].BlockID = TestModels.TestBlock.ID;
                inMapRegionModel.ParquetDefinitions[y, RegionModel.ParquetsPerRegionDimension - 1].BlockID = TestModels.TestBlock.ID;
            }
            inMapRegionModel.ParquetDefinitions[2, 1].FurnishingID = TestModels.TestFurnishing.ID;
            inMapRegionModel.ParquetDefinitions[3, 3].CollectibleID = TestModels.TestCollectible.ID;

            return inMapRegionModel;
        }
    }
}
