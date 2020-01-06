using CsvHelper.Configuration;
using ParquetClassLibrary.Serialization.Shims;

namespace ParquetClassLibrary.Serialization.ClassMaps
{
    /// <summary>
    /// Maps the values in a <see cref="RoomRecipeShim"/> to records that CSVHelper recognizes.
    /// </summary>
    public sealed class RoomRecipeClassMap : ClassMap<RoomRecipeShim>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomRecipeClassMap"/> class.
        /// </summary>
        public RoomRecipeClassMap()
        {
            // Properties are ordered by index to facilitate a logical layout in spreadsheet apps.
            Map(m => m.ID).Index(0);
            Map(m => m.Name).Index(1);
            Map(m => m.Description).Index(2);
            Map(m => m.Comment).Index(3);

            Map(m => m.RequiredFloors).Index(4);
            Map(m => m.MinimumWalkableSpaces).Index(5);
            Map(m => m.RequiredPerimeterBlocks).Index(6);
            Map(m => m.RequiredFurnishings).Index(7);
        }
    }
}
