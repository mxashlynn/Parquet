using CsvHelper.Configuration;
using ParquetClassLibrary.Serialization.Shims;

namespace ParquetClassLibrary.Serialization.ClassMaps
{
    /// <summary>
    /// Maps the values in a <see cref="MapRegionShim"/> to records that CSVHelper recognizes.
    /// </summary>
    public sealed class MapRegionClassMap : ClassMap<MapRegionShim>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapRegionClassMap"/> class.
        /// </summary>
        public MapRegionClassMap()
        {
            // TODO This is a stub.

            // Properties are ordered by index to facilitate a logical layout in spreadsheet apps.
            Map(m => m.ID).Index(0);
            Map(m => m.Name).Index(1);
            Map(m => m.Description).Index(2);
            Map(m => m.Comment).Index(3);
        }
    }
}