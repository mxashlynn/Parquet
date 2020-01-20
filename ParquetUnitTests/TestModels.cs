using System.Collections.Generic;
using ParquetClassLibrary;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Beings;
using ParquetClassLibrary.Crafts;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Rooms;
using ParquetClassLibrary.Interactions;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Utilities;

namespace ParquetUnitTests
{
    /// <summary>
    /// Stores <see cref="EntityModel"/>s for use in unit testing.
    /// </summary>
    public static class TestModels
    {
        #region Test Value Components
        public static readonly EntityTag TestTag = "Test Tag";
        public static readonly IReadOnlyList<RecipeElement> TestRecipeElementList = new List<RecipeElement> { new RecipeElement(TestTag, 1) };
        public static readonly IReadOnlyList<EntityTag> TestQuestRequirementsList = new List<EntityTag> { TestTag };
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
        public static IReadOnlyList<QuestModel> Quests { get; }

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
            // TODO Update this once Dialogue is implemented.
            TestDialogue = new DialogueModel(-All.DialogueIDs.Minimum, "5 Test Dialogue", "Test", "Test", null, null, null);
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
            TestQuest = new QuestModel(-All.QuestIDs.Minimum, "9 Test Quest", "Test", "Test", TestQuestRequirementsList, null, null, null);
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
}
