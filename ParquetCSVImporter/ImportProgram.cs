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

            #region Beings

            var beingRecordsFromCSV = new List<Being>();
            // TODO Unresolved design question -- do we predefine players, or are they all defined at runtime?
            beingRecordsFromCSV.AddRange(GetBeingRecordsForType<PlayerCharacter>() ?? Enumerable.Empty<PlayerCharacter>());
            beingRecordsFromCSV.AddRange(GetBeingRecordsForType<Critter>() ?? Enumerable.Empty<Critter>());
            beingRecordsFromCSV.AddRange(GetBeingRecordsForType<NPC>() ?? Enumerable.Empty<NPC>());
            Beings.Clear();
            Beings.UnionWith(beingRecordsFromCSV);
            #endregion

            #region Parquets
            var parquetRecordsFromCSV = new List<ParquetParent>();
            parquetRecordsFromCSV.AddRange(GetParquetRecordsForType<Floor>() ?? Enumerable.Empty<Floor>());
            parquetRecordsFromCSV.AddRange(GetParquetRecordsForType<Block>() ?? Enumerable.Empty<Block>());
            parquetRecordsFromCSV.AddRange(GetParquetRecordsForType<Furnishing>() ?? Enumerable.Empty<Furnishing>());
            parquetRecordsFromCSV.AddRange(GetParquetRecordsForType<Collectible>() ?? Enumerable.Empty<Collectible>());
            Parquets.Clear();
            Parquets.UnionWith(parquetRecordsFromCSV);
            #endregion

            #region Room Recipes

            #endregion

            #region Crafting Recipes

            #endregion

            #region Quests

            #endregion

            #region Biomes

            #endregion

            #region Items

            #endregion

            #endregion

            #region Reserialization as JSON
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
        /// <typeparam name="BeingType">The type of records to read.</typeparam>
        /// <returns>The records read.</returns>
        private static IEnumerable<BeingType> GetBeingRecordsForType<BeingType>()
            where BeingType : Being
        {
            IEnumerable<BeingType> records;
            var filenameAndPath = Path.Combine(SearchPath, $"Designer/{typeof(BeingType).Name}.csv");
            using (var reader = new StreamReader(filenameAndPath))
            {
                using (var csv = new CsvReader(reader))
                {
                    csv.Configuration.TypeConverterCache.AddConverter(typeof(EntityTag), new EntityTagConverter());
                    csv.Configuration.TypeConverterCache.AddConverter(typeof(EntityID), new EntityIDConverter());
                    csv.Configuration.TypeConverterOptionsCache.AddOptions(typeof(EntityID), IdentifierOptions);
                    csv.Configuration.RegisterClassMapFor<BeingType>();
                    records = csv.GetRecordsViaShim<BeingType>();
                }
            }

            return records;
        }

        /// <summary>
        /// Reads all records of the given type from the appropriate file.
        /// </summary>
        /// <typeparam name="ParquetType">The type of records to read.</typeparam>
        /// <returns>The records read.</returns>
        private static IEnumerable<ParquetType> GetParquetRecordsForType<ParquetType>()
            where ParquetType : ParquetParent
        {
            IEnumerable<ParquetType> records;
            var filenameAndPath = Path.Combine(SearchPath, $"Designer/{typeof(ParquetType).Name}.csv");
            using (var reader = new StreamReader(filenameAndPath))
            {
                using (var csv = new CsvReader(reader))
                {
                    csv.Configuration.TypeConverterCache.AddConverter(typeof(EntityTag), new EntityTagConverter());
                    csv.Configuration.TypeConverterCache.AddConverter(typeof(EntityID), new EntityIDConverter());
                    csv.Configuration.TypeConverterOptionsCache.AddOptions(typeof(EntityID), IdentifierOptions);
                    csv.Configuration.RegisterClassMapFor<ParquetType>();
                    records = csv.GetRecordsViaShim<ParquetType>();
                }
            }

            return records;
        }
    }
}
