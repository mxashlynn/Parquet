using CsvHelper.Configuration;
using ParquetCLITool.Shims;

namespace ParquetCLITool.ClassMaps
{
    /// <summary>
    /// Maps the values in a <see cref="CritterShim"/> to records that CSVHelper recognizes.
    /// </summary>
    public sealed class CritterClassMap : ClassMap<CritterShim>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CritterClassMap"/> class.
        /// </summary>
        public CritterClassMap()
        {
            // Properties are ordered by index to facilitate a logical layout in spreadsheet apps.
            Map(m => m.ID).Index(0);
            Map(m => m.Name).Index(1);
            Map(m => m.Description).Index(2);
            Map(m => m.Comment).Index(3);

            Map(m => m.NativeBiome).Index(4);
            Map(m => m.PrimaryBehavior).Index(5);
            Map(m => m.Avoids).Index(6);
            Map(m => m.Seeks).Index(7);
        }
    }
}
