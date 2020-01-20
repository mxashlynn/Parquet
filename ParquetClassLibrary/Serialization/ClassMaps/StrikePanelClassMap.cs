using CsvHelper.Configuration;
using ParquetClassLibrary.Crafts;

namespace ParquetClassLibrary.Serialization.ClassMaps
{
    /// <summary>
    /// Maps the values in a <see cref="StrikePanelClassMap"/> to records that CSVHelper recognizes.
    /// </summary>
    public sealed class StrikePanelClassMap : ClassMap<StrikePanel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StrikePanelClassMap"/> class.
        /// </summary>
        public StrikePanelClassMap()
        {
            Map(m => m.IsVoid);
            References<RangeClassMap<int>>(m => m.WorkingRange);
            References<RangeClassMap<int>>(m => m.IdealRange);
        }
    }
}
