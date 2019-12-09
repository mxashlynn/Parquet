using CsvHelper.Configuration;
using ParquetCSVImporter.Shims;

namespace ParquetCSVImporter.ClassMaps
{
    /// <summary>
    /// Maps the values in a <see cref="CollectibleShim"/> to records that CSVHelper recognizes.
    /// </summary>
    public sealed class CollectibleClassMap : ClassMap<CollectibleShim>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CollectibleClassMap"/> class.
        /// </summary>
        public CollectibleClassMap()
        {
            // Properties are ordered by index to facilitate a logical layout in spreadsheet apps.
            Map(m => m.ID).Index(0);
            Map(m => m.Name).Index(1);
            Map(m => m.Description).Index(2);
            Map(m => m.Comment).Index(3);
            Map(m => m.ItemID).Index(4);
            Map(m => m.AddsToBiome).Index(5);
            Map(m => m.AddsToRoom).Index(6);

            Map(m => m.Effect).Index(7);
            Map(m => m.EffectAmount).Index(8);
        }
    }
}
