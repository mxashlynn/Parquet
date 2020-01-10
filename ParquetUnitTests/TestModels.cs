using System.Collections.Generic;
using ParquetClassLibrary;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Beings;
using ParquetClassLibrary.Crafting;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Rooms;
using ParquetClassLibrary.Quests;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Utilities;
using ParquetClassLibrary.Dialogues;

namespace ParquetUnitTests
{
    /// <summary>
    /// Stores <see cref="EntityModel"/>s for use in unit testing.
    /// </summary>
    public static class TestModels
    {
        #region Test Value Components
        public static readonly EntityTag TestTag = "Test Tag";
        public static readonly List<RecipeElement> TestRecipeElementList = new List<RecipeElement> { new RecipeElement(TestTag, 1) };
        public static readonly List<EntityTag> TestQuestRequirementsList = new List<EntityTag> { TestTag };
        #endregion

        #region Test Values
        /// <summary>Used in test patterns in QA routines.</summary>
        public static PlayerCharacter TestPlayer { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static Critter TestCritter { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static NPC TestNPC { get; }

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
        public static List<BeingModel> Beings { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static List<BiomeModel> Biomes { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static List<CraftingRecipe> CraftingRecipes { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static List<DialogueModel> Dialogues { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static List<MapModel> Maps { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static List<ParquetModel> Parquets { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static List<QuestModel> Quests { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static List<RoomRecipe> RoomRecipes { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static List<ItemModel> Items { get; }
        #endregion

        /// <summary>
        /// Initializes unit test example models.
        /// Sets up <see cref="All"/> so that bounds can be checked in various constructors.
        /// </summary>
        static TestModels()
        {
            #region Initialize EntityModels
            TestPlayer = new PlayerCharacter(-All.PlayerCharacterIDs.Minimum, "0", "Test Player", "Test", "Test");
            TestCritter = new Critter(-All.CritterIDs.Minimum, "1 Test Critter", "Test", "Test",
                                      All.BiomeIDs.Minimum, Behavior.Still);
            TestNPC = new NPC(-All.NpcIDs.Minimum, "2", "Test NPC", "Test", "Test",
                              All.BiomeIDs.Minimum, Behavior.Still);
            TestBiome = new BiomeModel(-All.BiomeIDs.Minimum, "3 Test Biome", "Test", "Test",
                                  1, Elevation.LevelGround, false, null, null);
            TestCraftingRecipe = new CraftingRecipe(-All.CraftingRecipeIDs.Minimum, "4 Test Crafting Recipe",
                                                    "Test", "Test",
                                                    TestRecipeElementList, TestRecipeElementList,
                                                    new StrikePanelGrid(Rules.Dimensions.PanelsPerPatternHeight,
                                                                        Rules.Dimensions.PanelsPerPatternWidth));
            // TODO Update this once Dialogue is implemented.
            TestDialogue = new DialogueModel(-All.DialogueIDs.Minimum, "5 Test Dialogue", "Test", "Test");
            TestMapChunk = new MapChunk(-All.MapChunkIDs.Minimum, "11 Test Map Chunk", "Test", "Test");
            TestMapRegion = new MapRegion(-All.MapRegionIDs.Minimum, "12 Test Map Region", "Test", "Test");
            TestFloor = new FloorModel(-All.FloorIDs.Minimum, "3 Test Floor", "Test", "Test", inAddsToRoom: TestTag);
            TestBlock = new BlockModel(-All.BlockIDs.Minimum, "4 Test Block", "Test", "Test", inAddsToRoom: TestTag);
            TestLiquid = new BlockModel(-All.BlockIDs.Minimum - 1, "L Test Liquid Block", "Test", "Test", inIsLiquid: true, inAddsToRoom: TestTag);
            TestFurnishing = new FurnishingModel(-All.FurnishingIDs.Minimum, "5 Test Furnishing", "Test", "Test",
                                            inIsEntry: true, inAddsToRoom: TestTag);
            TestCollectible = new CollectibleModel(-All.CollectibleIDs.Minimum, "6 Test Collectible", "Test", "Test",
                                              inAddsToRoom: TestTag);
            // TODO Update this once Quests are implemented.
            TestQuest = new QuestModel(-All.QuestIDs.Minimum, "9 Test Quest", "Test", "Test", TestQuestRequirementsList);
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
            Dialogues = new List<DialogueModel> { TestDialogue };
            Maps = new List<MapModel> { TestMapChunk, TestMapRegion };
            Parquets = new List<ParquetModel> { TestFloor, TestBlock, TestLiquid, TestFurnishing, TestCollectible };
            Quests = new List<QuestModel> { TestQuest };
            RoomRecipes = new List<RoomRecipe> { TestRoomRecipe };
            Items = new List<ItemModel> { TestItem1, TestItem2, TestItem3, TestItem4 };

            All.InitializeCollections(Beings, Biomes, CraftingRecipes, Dialogues, Maps, Parquets, Quests, RoomRecipes, Items);
            #endregion
        }
    }
}
