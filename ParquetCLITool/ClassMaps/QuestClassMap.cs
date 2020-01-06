using CsvHelper.Configuration;
using ParquetCLITool.Shims;

namespace ParquetCLITool.ClassMaps
{
    /// <summary>
    /// Maps the values in a <see cref="QuestShim"/> to records that CSVHelper recognizes.
    /// </summary>
    public sealed class QuestClassMap : ClassMap<QuestShim>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuestClassMap"/> class.
        /// </summary>
        public QuestClassMap()
        {
            // Properties are ordered by index to facilitate a logical layout in spreadsheet apps.
            Map(m => m.ID).Index(0);
            Map(m => m.Name).Index(1);
            Map(m => m.Description).Index(2);
            Map(m => m.Comment).Index(3);

            Map(m => m.CompletionRequirements).Index(4);
        }
    }
}
