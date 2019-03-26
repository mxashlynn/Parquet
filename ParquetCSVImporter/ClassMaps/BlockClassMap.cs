using CsvHelper.Configuration;

namespace ParquetCSVImporter.ClassMaps
{
    /// <summary>
    /// Maps the values in a <see cref="T:ParquetCSVImporter.Shims.BlockShim"/> to records that CSVHelper recognizes.
    /// </summary>
    public class BlockClassMap : ClassMap<BlockShim>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ParquetCSVImporter.ClassMaps.BlockClassMap"/> class.
        /// </summary>
        public BlockClassMap()
        {
            Map(m => m.ID).Index(0);
            Map(m => m.Name).Index(1);
            Map(m => m.AddsToBiome).Index(2);

            Map(m => m.GatherTool).Index(3);
            Map(m => m.IsFlammable).Index(4);
            Map(m => m.IsLiquid).Index(5);
            Map(m => m.MaxToughness).Index(6);
        }
    }
}
