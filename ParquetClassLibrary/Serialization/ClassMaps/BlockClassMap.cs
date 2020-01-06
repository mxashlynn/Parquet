using CsvHelper.Configuration;
using ParquetClassLibrary.Serialization.Shims;

namespace ParquetClassLibrary.Serialization.ClassMaps
{
    /// <summary>
    /// Maps the values in a <see cref="BlockShim"/> to records that CSVHelper recognizes.
    /// </summary>
    public sealed class BlockClassMap : ClassMap<BlockShim>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlockClassMap"/> class.
        /// </summary>
        public BlockClassMap()
        {
            // Properties are ordered by index to facilitate a logical layout in spreadsheet apps.
            Map(m => m.ID).Index(0);
            Map(m => m.Name).Index(1);
            Map(m => m.Description).Index(2);
            Map(m => m.Comment).Index(3);

            Map(m => m.ItemID).Index(4);
            Map(m => m.AddsToBiome).Index(5);
            Map(m => m.AddsToRoom).Index(6);

            Map(m => m.GatherTool).Index(7);
            Map(m => m.GatherEffect).Index(8);
            Map(m => m.CollectibleID).Index(9);
            Map(m => m.IsFlammable).Index(10);
            Map(m => m.IsLiquid).Index(11);
            Map(m => m.MaxToughness).Index(12);
        }
    }
}
