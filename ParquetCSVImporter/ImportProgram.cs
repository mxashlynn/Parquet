using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.TypeConversion;
using ParquetClassLibrary;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Characters;
using ParquetClassLibrary.Crafting;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Quests;
using ParquetClassLibrary.Rooms;
using ParquetCSVImporter.ClassMaps;

namespace ParquetCSVImporter
{
    /// <summary>
    /// A program that reads in game definitions from CSV files, and outputs them as JSON.
    /// </summary>
    internal class ImportProgram
    {
        /// <summary>The location of the Designer files.</summary>
        public static readonly string SearchPath =
#if DEBUG
            $"{Directory.GetCurrentDirectory()}/../../../../";
#else
            Directory.GetCurrentDirectory().FullName;
#endif


        /// <summary>All <see cref="Being"/>s defined in the CSV files.</summary>
        public static readonly HashSet<Being> Beings = new HashSet<Being>();

        /// <summary>All parquets defined in the CSV files.</summary>
        public static readonly HashSet<ParquetParent> Parquets = new HashSet<ParquetParent>();

        /// <summary>All <see cref="RoomRecipe"/>s defined in the CSV files.</summary>
        public static readonly HashSet<RoomRecipe> RoomRecipes = new HashSet<RoomRecipe>();

        /// <summary>All <see cref="CraftingRecipe"/>s defined in the CSV files.</summary>
        public static readonly HashSet<CraftingRecipe> CraftingRecipes = new HashSet<CraftingRecipe>();

        /// <summary>All <see cref="Quest"/>s defined in the CSV files.</summary>
        public static readonly HashSet<Quest> Quests = new HashSet<Quest>();

        /// <summary>All <see cref="Biome"/>s defined in the CSV files.</summary>
        public static readonly HashSet<Biome> Biomes = new HashSet<Biome>();

        /// <summary>All <see cref="Item"/>s defined in the CSV files.</summary>
        public static readonly HashSet<Item> Items = new HashSet<Item>();

        /// <summary>Instructions for handling integer type conversion when reading in identifiers.</summary>
        public static readonly TypeConverterOptions IdentifierOptions = new TypeConverterOptions
        {
            NumberStyle = NumberStyles.AllowLeadingSign &
                          NumberStyles.Integer
        };

        /// <summary>
        /// The entry point of the Importer, where program control starts and ends.
        /// </summary>
        public static void Main()
        {
            #region Deserialization from CSV
            Beings.Clear();
            // NOTE Player Characters are not designed in CSVs but at run-time in-game.
            Beings.UnionWith(Enumerable.Empty<PlayerCharacter>());
            //Beings.UnionWith(GetRecordsForType<Critter>() ?? Enumerable.Empty<Critter>());
            //Beings.UnionWith(GetRecordsForType<NPC>() ?? Enumerable.Empty<NPC>());

            Parquets.Clear();
            Parquets.UnionWith(GetRecordsForType<Floor>() ?? Enumerable.Empty<Floor>());
            Parquets.UnionWith(GetRecordsForType<Block>() ?? Enumerable.Empty<Block>());
            Parquets.UnionWith(GetRecordsForType<Furnishing>() ?? Enumerable.Empty<Furnishing>());
            Parquets.UnionWith(GetRecordsForType<Collectible>() ?? Enumerable.Empty<Collectible>());

            RoomRecipes.Clear();
            //RoomRecipes.UnionWith(GetRecordsForType<RoomRecipe>() ?? Enumerable.Empty<RoomRecipe>());

            CraftingRecipes.Clear();
            //CraftingRecipes.UnionWith(GetRecordsForType<CraftingRecipe>() ?? Enumerable.Empty<CraftingRecipe>());

            Quests.Clear();
            //Quests.UnionWith(GetRecordsForType<Quest>() ?? Enumerable.Empty<Quest>());

            Biomes.Clear();
            //Biomes.UnionWith(GetRecordsForType<Biome>() ?? Enumerable.Empty<Biome>());

            Items.Clear();
            //Items.UnionWith(GetRecordsForType<Item>() ?? Enumerable.Empty<Item>());
            #endregion

            #region Reserialize as JSON
            All.InitializeCollections(Beings, Parquets, RoomRecipes, CraftingRecipes, Quests, Biomes, Items);
            var recordsToJSON = All.Parquets.SerializeToString();
            var filenameAndPath = Path.Combine(SearchPath, "Designer/Parquets.json");
            using (var writer = new StreamWriter(filenameAndPath, false, Encoding.UTF8))
            {
                writer.Write(recordsToJSON);
            }
            #endregion
        }

        /// <summary>
        /// Reads all records of the given type from the appropriate file.
        /// </summary>
        /// <typeparam name="T">The type of records to read.</typeparam>
        /// <returns>The records read.</returns>
        private static IEnumerable<T> GetRecordsForType<T>()
            where T : ParquetParent
        {
            IEnumerable<T> records;
            var filenameAndPath = Path.Combine(SearchPath, $"Designer/{typeof(T).Name}.csv");
            using (var reader = new StreamReader(filenameAndPath))
            {
                using (var csv = new CsvReader(reader))
                {
                    csv.Configuration.TypeConverterCache.AddConverter(typeof(EntityTag), new EntityTagConverter());
                    csv.Configuration.TypeConverterCache.AddConverter(typeof(EntityID), new EntityIDConverter());
                    csv.Configuration.TypeConverterOptionsCache.AddOptions(typeof(EntityID), IdentifierOptions);
                    csv.Configuration.RegisterClassMapFor<T>();
                    records = csv.GetRecordsViaShim<T>();
                }
            }

            return records;
        }
    }
}
