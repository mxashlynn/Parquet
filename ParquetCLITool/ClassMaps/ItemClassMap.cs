using CsvHelper.Configuration;
using ParquetCLITool.Shims;

namespace ParquetCLITool.ClassMaps
{
    /// <summary>
    /// Maps the values in a <see cref="ItemShim"/> to records that CSVHelper recognizes.
    /// </summary>
    public sealed class ItemClassMap : ClassMap<ItemShim>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemClassMap"/> class.
        /// </summary>
        public ItemClassMap()
        {
            // Properties are ordered by index to facilitate a logical layout in spreadsheet apps.
            Map(m => m.ID).Index(0);
            Map(m => m.Name).Index(1);
            Map(m => m.Description).Index(2);
            Map(m => m.Comment).Index(3);

            Map(m => m.Subtype).Index(4);
            Map(m => m.Price).Index(5);
            Map(m => m.Rarity).Index(6);
            Map(m => m.StackMax).Index(7);
            Map(m => m.EffectWhileHeld).Index(8);
            Map(m => m.EffectWhenUsed).Index(9);
            Map(m => m.AsParquet).Index(10);
            Map(m => m.ItemTags).Index(11);
            Map(m => m.Recipe).Index(12);
        }
    }
}
