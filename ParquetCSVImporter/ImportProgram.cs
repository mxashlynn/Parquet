using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.TypeConversion;
using ParquetClassLibrary;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Beings;
using ParquetClassLibrary.Crafting;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Quests;
using ParquetClassLibrary.Rooms;
using ParquetCSVImporter.ClassMaps;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Dialogues;

namespace ParquetCSVImporter
{
    /// <summary>
    /// A tool that reads in game definitions from CSV files, verifies, modifies, and outputs them.
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

        /// <summary>All <see cref="Biome"/>s defined in the CSV files.</summary>
        public static readonly HashSet<Biome> Biomes = new HashSet<Biome>();

        /// <summary>All <see cref="CraftingRecipe"/>s defined in the CSV files.</summary>
        public static readonly HashSet<CraftingRecipe> CraftingRecipes = new HashSet<CraftingRecipe>();

        /// <summary>All <see cref="Dialogue"/>s defined in the CSV files.</summary>
        public static readonly HashSet<Dialogue> Dialogues = new HashSet<Dialogue>();

        /// <summary>All <see cref="MapParent"/>s defined in the CSV files.</summary>
        public static readonly HashSet<MapParent> Maps = new HashSet<MapParent>();

        /// <summary>All parquets defined in the CSV files.</summary>
        public static readonly HashSet<ParquetParent> Parquets = new HashSet<ParquetParent>();

        /// <summary>All <see cref="Quest"/>s defined in the CSV files.</summary>
        public static readonly HashSet<Quest> Quests = new HashSet<Quest>();

        /// <summary>All <see cref="RoomRecipe"/>s defined in the CSV files.</summary>
        public static readonly HashSet<RoomRecipe> RoomRecipes = new HashSet<RoomRecipe>();

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
            #region Deserialize from CSV
            Beings.Clear();
            // NOTE Player Characters are not designed in CSVs but at run-time in-game.
            Beings.UnionWith(Enumerable.Empty<PlayerCharacter>());
            Beings.UnionWith(GetRecordsForType<Critter>() ?? Enumerable.Empty<Critter>());
            Beings.UnionWith(GetRecordsForType<NPC>() ?? Enumerable.Empty<NPC>());

            Biomes.Clear();
            Biomes.UnionWith(GetRecordsForType<Biome>() ?? Enumerable.Empty<Biome>());

            CraftingRecipes.Clear();
            CraftingRecipes.UnionWith(GetRecordsForType<CraftingRecipe>() ?? Enumerable.Empty<CraftingRecipe>());

            Dialogues.Clear();
            Dialogues.UnionWith(GetRecordsForType<Dialogue>() ?? Enumerable.Empty<Dialogue>());

            Maps.Clear();
            Maps.UnionWith(GetRecordsForType<MapChunk>() ?? Enumerable.Empty<MapChunk>());
            Maps.UnionWith(GetRecordsForType<MapRegion>() ?? Enumerable.Empty<MapRegion>());

            Parquets.Clear();
            Parquets.UnionWith(GetRecordsForType<Floor>() ?? Enumerable.Empty<Floor>());
            Parquets.UnionWith(GetRecordsForType<Block>() ?? Enumerable.Empty<Block>());
            Parquets.UnionWith(GetRecordsForType<Furnishing>() ?? Enumerable.Empty<Furnishing>());
            Parquets.UnionWith(GetRecordsForType<Collectible>() ?? Enumerable.Empty<Collectible>());

            Quests.Clear();
            Quests.UnionWith(GetRecordsForType<Quest>() ?? Enumerable.Empty<Quest>());

            RoomRecipes.Clear();
            RoomRecipes.UnionWith(GetRecordsForType<RoomRecipe>() ?? Enumerable.Empty<RoomRecipe>());

            Items.Clear();
            Items.UnionWith(GetRecordsForType<Item>() ?? Enumerable.Empty<Item>());
            #endregion

            All.InitializeCollections(Beings, Biomes, CraftingRecipes, Dialogues, Maps, Parquets, Quests, RoomRecipes, Items);

            #region Reserialize to CSV
            //var recordsToJSON = All.Parquets.SerializeToString();
            //var filenameAndPath = Path.Combine(SearchPath, "Designer/Parquets.json");
            //using (var writer = new StreamWriter(filenameAndPath, false, Encoding.UTF8))
            //{
            //    writer.Write(recordsToJSON);
            //}
            #endregion
        }

        /// <summary>
        /// Reads all records of the given type from the appropriate file.
        /// </summary>
        /// <typeparam name="T">The type of records to read.</typeparam>
        /// <returns>The records read.</returns>
        private static IEnumerable<T> GetRecordsForType<T>()
            where T : Entity
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
