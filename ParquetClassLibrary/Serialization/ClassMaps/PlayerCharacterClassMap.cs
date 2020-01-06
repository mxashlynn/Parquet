using CsvHelper.Configuration;
using ParquetClassLibrary.Serialization.Shims;

namespace ParquetClassLibrary.Serialization.ClassMaps
{
    /// <summary>
    /// Maps the values in a <see cref="PlayerCharacterShim"/> to records that CSVHelper recognizes.
    /// </summary>
    public sealed class PlayerCharacterClassMap : ClassMap<PlayerCharacterShim>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerCharacterClassMap"/> class.
        /// </summary>
        public PlayerCharacterClassMap()
        {
            // Properties are ordered by index to facilitate a logical layout in spreadsheet apps.
            Map(m => m.ID).Index(0);
            Map(m => m.Name).Index(1);
            Map(m => m.Description).Index(2);
            Map(m => m.Comment).Index(3);

            Map(m => m.Pronoun).Index(4);
            Map(m => m.StoryCharacterID).Index(5);
            Map(m => m.StartingQuests).Index(6);
            Map(m => m.StartingInventory).Index(7);
        }
    }
}
