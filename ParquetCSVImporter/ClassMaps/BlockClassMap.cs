using CsvHelper.Configuration;

// ReSharper disable InconsistentNaming

namespace ParquetCSVImporter.ClassMaps
{
    /// <summary>
    /// Maps the values in a <see cref="T:ParquetCSVImporter.Shims.BlockShim"/> to records that CSVHelper recognizes.
    /// </summary>
    public sealed class BlockClassMap : ClassMap<BlockShim>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ParquetCSVImporter.ClassMaps.BlockClassMap"/> class.
        /// </summary>
        public BlockClassMap()
        {
            // Properties are ordered by index to facilitate a logical layout in spreadsheet apps.
            Map(m => m.ID).Index(0);
            Map(m => m.Name).Index(1);
            Map(m => m.AddsToBiome).Index(2);

            Map(m => m.GatherTool).Index(3);
            Map(m => m.GatherEffect).Index(4);
            Map(m => m.ItemID).Index(5);
            Map(m => m.CollectibleID).Index(6);
            Map(m => m.IsFlammable).Index(7);
            Map(m => m.IsLiquid).Index(8);
            Map(m => m.MaxToughness).Index(9);
        }
    }
}
