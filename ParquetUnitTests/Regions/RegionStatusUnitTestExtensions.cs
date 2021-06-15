using Parquet.Regions;

// TODO [TESTING] This needs to use RegionStatus instead of RegionModel.
/*
namespace ParquetUnitTests.Maps
{
    /// <summary>
    /// Provides extension methods for the <see cref="RegionStatus"/> used in unit testing.
    /// </summary>
    internal static class RegionStatusUnitTestExtensions
    {
        /// <summary>Fills the region with a test pattern.</summary>
        internal static RegionModel FillTestPattern(this RegionModel regionModel)
        {
            for (var x = 0; x < RegionStatus.ParquetsPerRegionDimension; x++)
            {
                for (var y = 0; y < RegionStatus.ParquetsPerRegionDimension; y++)
                {
                    regionModel.ParquetDefinitions[y, x].FloorID = TestModels.TestFloor.ID;
                }

                regionModel.ParquetDefinitions[0, x].BlockID = TestModels.TestBlock.ID;
                regionModel.ParquetDefinitions[RegionModel.ParquetsPerRegionDimension, 1].BlockID = TestModels.TestBlock.ID;
            }
            for (var y = 0; y < RegionStatus.ParquetsPerRegionDimension; y++)
            {
                regionModel.ParquetDefinitions[y, 0].BlockID = TestModels.TestBlock.ID;
                regionModel.ParquetDefinitions[y, RegionModel.ParquetsPerRegionDimension - 1].BlockID = TestModels.TestBlock.ID;
            }
            regionModel.ParquetDefinitions[2, 1].FurnishingID = TestModels.TestFurnishing.ID;
            regionModel.ParquetDefinitions[3, 3].CollectibleID = TestModels.TestCollectible.ID;

            return regionModel;
        }
    }
}
*/
