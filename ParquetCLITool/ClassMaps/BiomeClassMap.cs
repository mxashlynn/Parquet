using CsvHelper.Configuration;
using ParquetCLITool.Shims;

namespace ParquetCLITool.ClassMaps
{
    /// <summary>
    /// Maps the values in a <see cref="BiomeShim"/> to records that CSVHelper recognizes.
    /// </summary>
    public sealed class BiomeClassMap : ClassMap<BiomeShim>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BiomeClassMap"/> class.
        /// </summary>
        public BiomeClassMap()
        {
            // Properties are ordered by index to facilitate a logical layout in spreadsheet apps.
            Map(m => m.ID).Index(0);
            Map(m => m.Name).Index(1);
            Map(m => m.Description).Index(2);
            Map(m => m.Comment).Index(3);

            Map(m => m.Tier).Index(4);
            Map(m => m.ElevationCategory).Index(5);
            Map(m => m.IsLiquidBased).Index(6);
            Map(m => m.ParquetCriteria).Index(7);
            Map(m => m.EntryRequirements).Index(8);
        }
    }
}
