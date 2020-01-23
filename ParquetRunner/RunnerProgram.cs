using System;
using System.Collections.Generic;
using System.IO;
using ParquetClassLibrary;
using ParquetClassLibrary.Beings;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Crafts;
using ParquetClassLibrary.Interactions;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Rooms;
using ParquetClassLibrary.Serialization;
using ParquetClassLibrary.Utilities;

namespace ParquetRunner
{
    #region Test Stuff
    /// <summary>
    /// Stores <see cref="EntityModel"/>s for use in unit testing.
    /// </summary>
    public static class TestModels
    {
        #region Test Value Components
        public static readonly EntityTag TestTag = "Test Tag";
        public static readonly List<RecipeElement> TestRecipeElementList = new List<RecipeElement> { new RecipeElement(1, TestTag) };
        public static readonly List<EntityTag> TestQuestRequirementsList = new List<EntityTag> { TestTag };
        #endregion

        #region Test Values
        /// <summary>Used in test patterns in QA routines.</summary>
        public static PlayerCharacterModel TestPlayer { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static CritterModel TestCritter { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static NPCModel TestNPC { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static BiomeModel TestBiome { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static CraftingRecipe TestCraftingRecipe { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static DialogueModel TestDialogue { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static MapChunk TestMapChunk { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static MapRegion TestMapRegion { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static FloorModel TestFloor { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static BlockModel TestBlock { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static BlockModel TestLiquid { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static FurnishingModel TestFurnishing { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static CollectibleModel TestCollectible { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static QuestModel TestQuest { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static RoomRecipe TestRoomRecipe { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static ItemModel TestItem1 { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static ItemModel TestItem2 { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static ItemModel TestItem3 { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static ItemModel TestItem4 { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<BeingModel> Beings { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<BiomeModel> Biomes { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<CraftingRecipe> CraftingRecipes { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<InteractionModel> Interactions { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<MapModel> Maps { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<ParquetModel> Parquets { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<RoomRecipe> RoomRecipes { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<ItemModel> Items { get; }
        #endregion

        /// <summary>
        /// Initializes unit test example models.
        /// Sets up <see cref="All"/> so that bounds can be checked in various constructors.
        /// </summary>
        static TestModels()
        {
            #region Initialize EntityModels
            TestPlayer = new PlayerCharacterModel(-All.PlayerCharacterIDs.Minimum, "0", "Test Player", "Test", "Test",
                                                  All.BiomeIDs.Minimum, Behavior.PlayerControlled);
            TestCritter = new CritterModel(-All.CritterIDs.Minimum, "1 Test Critter", "Test", "Test",
                                      All.BiomeIDs.Minimum, Behavior.Still);
            TestNPC = new NPCModel(-All.NpcIDs.Minimum, "2", "Test NPC", "Test", "Test",
                                   All.BiomeIDs.Minimum, Behavior.Still);
            TestBiome = new BiomeModel(-All.BiomeIDs.Minimum, "3 Test Biome", "Test", "Test",
                                  1, Elevation.LevelGround, false, null, null);
            TestCraftingRecipe = new CraftingRecipe(-All.CraftingRecipeIDs.Minimum, "4 Test Crafting Recipe",
                                                    "Test", "Test",
                                                    TestRecipeElementList, TestRecipeElementList,
                                                    new StrikePanelGrid(Rules.Dimensions.PanelsPerPatternHeight,
                                                                        Rules.Dimensions.PanelsPerPatternWidth));
            TestDialogue = new DialogueModel(-All.DialogueIDs.Minimum, "5 Test Dialogue", "Test", "Test", null, null, null); // TODO Fill in these nulls.
            TestMapChunk = new MapChunk(-All.MapChunkIDs.Minimum, "11 Test Map Chunk", "Test", "Test");
            TestMapRegion = new MapRegion(-All.MapRegionIDs.Minimum, "12 Test Map Region", "Test", "Test");
            TestFloor = new FloorModel(-All.FloorIDs.Minimum, "3 Test Floor", "Test", "Test", inAddsToRoom: TestTag);
            TestBlock = new BlockModel(-All.BlockIDs.Minimum, "4 Test Block", "Test", "Test", inAddsToRoom: TestTag);
            TestLiquid = new BlockModel(-All.BlockIDs.Minimum - 1, "L Test Liquid Block", "Test", "Test", inIsLiquid: true, inAddsToRoom: TestTag);
            TestFurnishing = new FurnishingModel(-All.FurnishingIDs.Minimum, "5 Test Furnishing", "Test", "Test",
                                            inIsEntry: true, inAddsToRoom: TestTag);
            TestCollectible = new CollectibleModel(-All.CollectibleIDs.Minimum, "6 Test Collectible", "Test", "Test",
                                              inAddsToRoom: TestTag);
            TestQuest = new QuestModel(-All.QuestIDs.Minimum, "9 Test Quest", "Test", "Test", TestQuestRequirementsList, null, null, null); // TODO Fill in these nulls.
            TestRoomRecipe = new RoomRecipe(-All.RoomRecipeIDs.Minimum - 1, "7 Test Room Recipe", "Test", "Test",
                                            TestRecipeElementList, Rules.Recipes.Room.MinWalkableSpaces + 1,
                                            TestRecipeElementList, TestRecipeElementList);
            TestItem1 = new ItemModel(-All.ItemIDs.Minimum, "11 Test Item 1", "Test", "Test", ItemType.Other,
                                      1, 0, 99, 1, 1, -All.BlockIDs.Minimum);
            TestItem2 = new ItemModel(-All.ItemIDs.Minimum - 1, "11 Test Item 2", "Test", "Test", ItemType.Other,
                                      1, 0, 999, 1, 1, -All.BlockIDs.Minimum - 1);
            TestItem3 = new ItemModel(-All.ItemIDs.Minimum - 2, "11 Test Item 3", "Test", "Test", ItemType.Other,
                                      1, 0, 999, 1, 1, -All.BlockIDs.Minimum - 2);
            TestItem4 = new ItemModel(-All.ItemIDs.Minimum - 3, "11 Test Item 4", "Test", "Test", ItemType.Other,
                                      1, 0, 999, 1, 1, -All.BlockIDs.Minimum - 3);

            #region Initialize TestMapChunk
            for (var y = 0; y < TestMapChunk.DimensionsInParquets.Y; y++)
            {
                for (var x = 0; x < TestMapChunk.DimensionsInParquets.X; x++)
                {
                    TestMapChunk.TrySetFloorDefinition(TestModels.TestFloor.ID, new Vector2D(x, y));
                }

                TestMapChunk.TrySetBlockDefinition(TestModels.TestBlock.ID, new Vector2D(0, y));
                TestMapChunk.TrySetBlockDefinition(TestModels.TestBlock.ID, new Vector2D(TestMapChunk.DimensionsInParquets.X - 1, y));
            }
            for (var x = 0; x < TestMapChunk.DimensionsInParquets.X; x++)
            {
                TestMapChunk.TrySetBlockDefinition(TestModels.TestBlock.ID, new Vector2D(x, 0));
                TestMapChunk.TrySetBlockDefinition(TestModels.TestBlock.ID, new Vector2D(x, TestMapChunk.DimensionsInParquets.Y - 1));
            }
            TestMapChunk.TrySetFurnishingDefinition(TestModels.TestFurnishing.ID, new Vector2D(1, 2));
            TestMapChunk.TrySetCollectibleDefinition(TestModels.TestCollectible.ID, new Vector2D(3, 3));
            #endregion
            #endregion

            #region Initialize All
            Beings = new List<BeingModel> { TestCritter, TestNPC, TestPlayer };
            Biomes = new List<BiomeModel> { TestBiome };
            CraftingRecipes = new List<CraftingRecipe> { TestCraftingRecipe };
            Interactions = new List<InteractionModel> { TestDialogue, TestQuest };
            Maps = new List<MapModel> { TestMapChunk, TestMapRegion };
            Parquets = new List<ParquetModel> { TestFloor, TestBlock, TestLiquid, TestFurnishing, TestCollectible };
            RoomRecipes = new List<RoomRecipe> { TestRoomRecipe };
            Items = new List<ItemModel> { TestItem1, TestItem2, TestItem3, TestItem4 };

            // TODO Replace this null with pronouns.
            All.InitializeCollections(Beings, Biomes, CraftingRecipes, Interactions, Maps, Parquets, RoomRecipes, Items, null);
            #endregion
        }
    }
    #endregion

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
            #region Set the working directory depending on build.
            Serializer.SearchPath =
#if DEBUG
            $"{Directory.GetCurrentDirectory()}/../../../../";
#else
            Directory.GetCurrentDirectory().FullName;
#endif
            #endregion

            #region Local Variables
            /// <summary>All <see cref="BeingModel"/>s defined in the CSV files.</summary>
            var Beings = new HashSet<BeingModel>();
            /// <summary>All <see cref="BiomeModel"/>s defined in the CSV files.</summary>
            var Biomes = new HashSet<BiomeModel>();
            /// <summary>All <see cref="CraftingRecipe"/>s defined in the CSV files.</summary>
            var CraftingRecipes = new HashSet<CraftingRecipe>();
            /// <summary>All <see cref="InteractionModel"/>s defined in the CSV files.</summary>
            var Interactions = new HashSet<InteractionModel>();
            /// <summary>All <see cref="MapModel"/>s defined in the CSV files.</summary>
            var Maps = new HashSet<MapModel>();
            /// <summary>All parquets defined in the CSV files.</summary>
            var Parquets = new HashSet<ParquetModel>();
            /// <summary>All <see cref="RoomRecipe"/>s defined in the CSV files.</summary>
            var RoomRecipes = new HashSet<RoomRecipe>();
            /// <summary>All <see cref="ItemModel"/>s defined in the CSV files.</summary>
            var Items = new HashSet<ItemModel>();

            var PronounGroups = new HashSet<PronounGroup>();
            #endregion

            #region Deserialize from CSV
            PronounGroups.UnionWith(Serializer.GetRecordsForPronounGroup());
            Beings.UnionWith(Serializer.GetRecordsForType<CritterModel>());
            Beings.UnionWith(Serializer.GetRecordsForType<NPCModel>());
            Beings.UnionWith(Serializer.GetRecordsForType<PlayerCharacterModel>());
            Biomes.UnionWith(Serializer.GetRecordsForType<BiomeModel>());
            // TODO Needs PanelPaternConverter --> CraftingRecipes.UnionWith(Serializer.GetRecordsForType<CraftingRecipe>());
            Interactions.UnionWith(Serializer.GetRecordsForType<DialogueModel>());
            Interactions.UnionWith(Serializer.GetRecordsForType<QuestModel>());
            // TODO Maps.UnionWith(Serializer.GetRecordsForType<MapChunk>());
            // TODO Maps.UnionWith(Serializer.GetRecordsForType<MapRegion>());
            Parquets.UnionWith(Serializer.GetRecordsForType<FloorModel>());
            Parquets.UnionWith(Serializer.GetRecordsForType<BlockModel>());
            Parquets.UnionWith(Serializer.GetRecordsForType<FurnishingModel>());
            Parquets.UnionWith(Serializer.GetRecordsForType<CollectibleModel>());
            RoomRecipes.UnionWith(Serializer.GetRecordsForType<RoomRecipe>());
            Items.UnionWith(Serializer.GetRecordsForType<ItemModel>());
            #endregion

            All.InitializeCollections(Beings, Biomes, CraftingRecipes, Interactions, Maps, Parquets, RoomRecipes, Items, PronounGroups);

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
            Console.WriteLine($"PronounGroups.Count = {All.PronounGroups.Count}");
        }
    }
}
