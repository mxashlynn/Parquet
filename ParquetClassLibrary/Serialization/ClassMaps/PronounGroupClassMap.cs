using CsvHelper.Configuration;
using ParquetClassLibrary.Serialization.Shims;

namespace ParquetClassLibrary.Serialization.ClassMaps
{
    /// <summary>
    /// Maps the values in a <see cref="PronounGroupShim"/> to records that CSVHelper recognizes.
    /// </summary>
    public sealed class PronounGroupClassMap : ClassMap<PronounGroupShim>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PronounGroupClassMap"/> class.
        /// </summary>
        public PronounGroupClassMap()
        {
            // Properties are ordered by index to facilitate a logical layout in spreadsheet apps.
            Map(m => m.Subjective).Index(0);
            Map(m => m.Objective).Index(1);
            Map(m => m.Determiner).Index(2);
            Map(m => m.Possessive).Index(3);
            Map(m => m.Reflexive).Index(4);
        }
    }
}
