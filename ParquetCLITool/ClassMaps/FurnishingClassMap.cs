using CsvHelper.Configuration;
using ParquetCLITool.Shims;


namespace ParquetCLITool.ClassMaps
{
    /// <summary>
    /// Maps the values in a <see cref="FurnishingShim"/> to records that CSVHelper recognizes.
    /// </summary>
    public sealed class FurnishingClassMap : ClassMap<FurnishingShim>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FurnishingClassMap"/> class.
        /// </summary>
        public FurnishingClassMap()
        {
            // Properties are ordered by index to facilitate a logical layout in spreadsheet apps.
            Map(m => m.ID).Index(0);
            Map(m => m.Name).Index(1);
            Map(m => m.Description).Index(2);
            Map(m => m.Comment).Index(3);

            Map(m => m.ItemID).Index(4);
            Map(m => m.AddsToBiome).Index(5);
            Map(m => m.AddsToRoom).Index(6);

            Map(m => m.IsWalkable).Index(7);
            Map(m => m.IsEntry).Index(8);
            Map(m => m.IsEnclosing).Index(9);
            Map(m => m.SwapID).Index(10);
        }
    }
}
