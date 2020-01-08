using CsvHelper.Configuration;
using ParquetClassLibrary.Serialization.Shims;

namespace ParquetClassLibrary.Serialization.ClassMaps
{
    /// <summary>
    /// Maps the values in a <see cref="CraftingRecipeShim"/> to records that CSVHelper recognizes.
    /// </summary>
    public sealed class CraftingRecipeClassMap : ClassMap<CraftingRecipeShim>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CraftingRecipeClassMap"/> class.
        /// </summary>
        public CraftingRecipeClassMap()
        {
            // Properties are ordered by index to facilitate a logical layout in spreadsheet apps.
            Map(m => m.ID).Index(0);
            Map(m => m.Name).Index(1);
            Map(m => m.Description).Index(2);
            Map(m => m.Comment).Index(3);

            Map(m => m.Products).Index(4);
            Map(m => m.Ingredients).Index(5);
            Map(m => m.PanelPattern).Index(6);
        }
    }
}
