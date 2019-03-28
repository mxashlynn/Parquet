using CsvHelper.Configuration;
// ReSharper disable InconsistentNaming

namespace ParquetCSVImporter.ClassMaps
{
    /// <summary>
    /// Maps the values in a <see cref="T:ParquetCSVImporter.Shims.FloorShim"/> to records that CSVHelper recognizes.
    /// </summary>
    public sealed class FloorClassMap : ClassMap<FloorShim>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ParquetCSVImporter.ClassMaps.FloorClassMap"/> class.
        /// </summary>
        public FloorClassMap()
        {
            // Properties are ordered by index to facilitate a logical layout in spreadsheet apps.
            Map(m => m.ID).Index(0);
            Map(m => m.Name).Index(1);
            Map(m => m.AddsToBiome).Index(2);

            Map(m => m.ModTool).Index(3);
            Map(m => m.NameWhenHole).Index(4);
            Map(m => m.IsWalkable).Index(5);
        }
    }
}
