using CsvHelper.Configuration;
// ReSharper disable InconsistentNaming

namespace ParquetCSVImporter.ClassMaps
{
    /// <summary>
    /// Maps the values in a <see cref="T:ParquetCSVImporter.Shims.ParquetParentShim"/> to records that CSVHelper recognizes.
    /// </summary>
    public sealed class ParquetParentClassMap : ClassMap<ParquetParentShim>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ParquetCSVImporter.ClassMaps.ParquetParentClassMap"/> class.
        /// </summary>
        public ParquetParentClassMap()
        {
            Map(m => m.ID).Index(0);
            Map(m => m.Name).Index(1);
            Map(m => m.AddsToBiome).Index(2);
        }
    }
}
