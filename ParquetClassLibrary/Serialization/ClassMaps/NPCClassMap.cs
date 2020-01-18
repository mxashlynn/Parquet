using CsvHelper.Configuration;
using ParquetClassLibrary.Serialization.Shims;

namespace ParquetClassLibrary.Serialization.ClassMaps
{
    /// <summary>
    /// Maps the values in a <see cref="NPCShim"/> to records that CSVHelper recognizes.
    /// </summary>
    public sealed class NPCClassMap : ClassMap<NPCShim>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NPCClassMap"/> class.
        /// </summary>
        public NPCClassMap()
        {
            // Properties are ordered by index to facilitate a logical layout in spreadsheet apps.
            Map(m => m.ID).Index(0);
            Map(m => m.Name).Index(1);
            Map(m => m.FamilyName).Index(2);
            Map(m => m.Description).Index(3);
            Map(m => m.Comment).Index(4);

            Map(m => m.NativeBiome).Index(5);
            Map(m => m.PrimaryBehavior).Index(6);
            Map(m => m.Avoids).Index(7);
            Map(m => m.Seeks).Index(8);

            Map(m => m.Pronouns).Index(9);
            Map(m => m.StoryCharacterID).Index(10);
            Map(m => m.StartingQuests).Index(11);
            Map(m => m.StartingInventory).Index(12);
        }
    }
}
