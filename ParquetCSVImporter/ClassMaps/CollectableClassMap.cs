using CsvHelper.Configuration;

namespace ParquetCSVImporter.ClassMaps
{
    /// <summary>
    /// Maps the values in a <see cref="T:ParquetCSVImporter.Shims.CollectableShim"/> to records that CSVHelper recognizes.
    /// </summary>
    public class CollectableClassMap : ClassMap<CollectableShim>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ParquetCSVImporter.ClassMaps.CollectableClassMap"/> class.
        /// </summary>
        public CollectableClassMap()
        {
            Map(m => m.ID).Index(0);
            Map(m => m.Name).Index(1);
            Map(m => m.AddsToBiome).Index(2);
        }
    }
}
