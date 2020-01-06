using CsvHelper.Configuration;
using ParquetCLITool.Shims;

namespace ParquetCLITool.ClassMaps
{
    /// <summary>
    /// Maps the values in a <see cref="FloorShim"/> to records that CSVHelper recognizes.
    /// </summary>
    public sealed class FloorClassMap : ClassMap<FloorShim>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FloorClassMap"/> class.
        /// </summary>
        public FloorClassMap()
        {
            // Properties are ordered by index to facilitate a logical layout in spreadsheet apps.
            Map(m => m.ID).Index(0);
            Map(m => m.Name).Index(1);
            Map(m => m.Description).Index(2);
            Map(m => m.Comment).Index(3);

            Map(m => m.ItemID).Index(4);
            Map(m => m.AddsToBiome).Index(5);
            Map(m => m.AddsToRoom).Index(6);

            Map(m => m.ModTool).Index(7);
            Map(m => m.TrenchName).Index(8);
        }
    }
}
