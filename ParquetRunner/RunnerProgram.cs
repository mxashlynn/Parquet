using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ParquetClassLibrary;
using ParquetClassLibrary.Beings;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Crafting;
using ParquetClassLibrary.Dialogues;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Quests;
using ParquetClassLibrary.Rooms;
using ParquetClassLibrary.Serialization;

namespace ParquetRunner
{
    /// <summary>
    /// A simple program used to run some basic features of the <see cref="ParquetClassLibrary"/>.
    /// </summary>
    internal class MainClass
    {
        /// <summary>
        /// A simple program used to run some basic features of the <see cref="ParquetClassLibrary"/>.
        /// </summary>
        public static void Main()
        {
            #region Deserialize from CSV
            #region Local Variables
            /// <summary>All <see cref="Being"/>s defined in the CSV files.</summary>
            var Beings = new HashSet<Being>();
            /// <summary>All <see cref="Biome"/>s defined in the CSV files.</summary>
            var Biomes = new HashSet<Biome>();
            /// <summary>All <see cref="CraftingRecipe"/>s defined in the CSV files.</summary>
            var CraftingRecipes = new HashSet<CraftingRecipe>();
            /// <summary>All <see cref="Dialogue"/>s defined in the CSV files.</summary>
            var Dialogues = new HashSet<Dialogue>();
            /// <summary>All <see cref="MapParent"/>s defined in the CSV files.</summary>
            var Maps = new HashSet<MapParent>();
            /// <summary>All parquets defined in the CSV files.</summary>
            var Parquets = new HashSet<ParquetParent>();
            /// <summary>All <see cref="Quest"/>s defined in the CSV files.</summary>
            var Quests = new HashSet<Quest>();
            /// <summary>All <see cref="RoomRecipe"/>s defined in the CSV files.</summary>
            var RoomRecipes = new HashSet<RoomRecipe>();
            /// <summary>All <see cref="Item"/>s defined in the CSV files.</summary>
            var Items = new HashSet<Item>();
            #endregion

            // Set the working directory depending on build.
            Serializer.SearchPath =
#if DEBUG
            $"{Directory.GetCurrentDirectory()}/../../../../";
#else
            Directory.GetCurrentDirectory().FullName;
#endif

            // NOTE Player Characters are not designed in CSVs but at run-time in-game.
            Beings.UnionWith(Serializer.GetRecordsForType<Critter>() ?? Enumerable.Empty<Critter>());
            Beings.UnionWith(Serializer.GetRecordsForType<NPC>() ?? Enumerable.Empty<NPC>());
            Biomes.UnionWith(Serializer.GetRecordsForType<Biome>() ?? Enumerable.Empty<Biome>());
            CraftingRecipes.UnionWith(Serializer.GetRecordsForType<CraftingRecipe>() ?? Enumerable.Empty<CraftingRecipe>());
            Dialogues.UnionWith(Serializer.GetRecordsForType<Dialogue>() ?? Enumerable.Empty<Dialogue>());
            Maps.UnionWith(Serializer.GetRecordsForType<MapChunk>() ?? Enumerable.Empty<MapChunk>());
            Maps.UnionWith(Serializer.GetRecordsForType<MapRegion>() ?? Enumerable.Empty<MapRegion>());
            Parquets.UnionWith(Serializer.GetRecordsForType<Floor>() ?? Enumerable.Empty<Floor>());
            Parquets.UnionWith(Serializer.GetRecordsForType<Block>() ?? Enumerable.Empty<Block>());
            Parquets.UnionWith(Serializer.GetRecordsForType<Furnishing>() ?? Enumerable.Empty<Furnishing>());
            Parquets.UnionWith(Serializer.GetRecordsForType<Collectible>() ?? Enumerable.Empty<Collectible>());
            Quests.UnionWith(Serializer.GetRecordsForType<Quest>() ?? Enumerable.Empty<Quest>());
            RoomRecipes.UnionWith(Serializer.GetRecordsForType<RoomRecipe>() ?? Enumerable.Empty<RoomRecipe>());
            Items.UnionWith(Serializer.GetRecordsForType<Item>() ?? Enumerable.Empty<Item>());
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

            var region = new MapRegion(All.MapRegionIDs.Minimum, "Sample Region");
            Console.WriteLine(region);
            Console.WriteLine($"Item range = {All.ItemIDs}");
        }
    }
}
