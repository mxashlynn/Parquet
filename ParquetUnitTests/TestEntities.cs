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
    /// Stores <see cref="Entity"/> and <see cref="EntityID"/> for use in unit testing.
    /// </summary>
    public static class TestEntities
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
        public static Biome TestBiome { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static CraftingRecipe TestCraftingRecipe { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static Dialogue TestDialogue { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static MapChunk TestMapChunk { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static MapRegion TestMapRegion { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static Floor TestFloor { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static Block TestBlock { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static Block TestLiquid { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static Furnishing TestFurnishing { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static Collectible TestCollectible { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static Quest TestQuest { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static RoomRecipe TestRoomRecipe { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static Item TestItem { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static List<Being> Beings { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static List<Biome> Biomes { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static List<CraftingRecipe> CraftingRecipes { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static List<Dialogue> Dialogues { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static List<MapParent> Maps { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static List<ParquetParent> Parquets { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static List<Quest> Quests { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static List<RoomRecipe> RoomRecipes { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static List<Item> Items { get; }
        #endregion

        /// <summary>
        /// Initializes unit test example entities.
        /// Sets up <see cref="All"/> so that bounds can be checked in various constructors.
        /// </summary>
        static TestEntities()
        {
            #region Initialize Entities
            TestPlayer = new PlayerCharacter(-All.PlayerCharacterIDs.Minimum, "0", "Test Player", "Test", "Test");
            TestCritter = new Critter(-All.CritterIDs.Minimum, "1 Test Critter", "Test", "Test",
                                      All.BiomeIDs.Minimum, Behavior.Still);
            TestNPC = new NPC(-All.NpcIDs.Minimum, "2", "Test NPC", "Test", "Test",
                              All.BiomeIDs.Minimum, Behavior.Still);
            TestBiome = new Biome(-All.BiomeIDs.Minimum, "3 Test Biome", "Test", "Test",
                                  1, Elevation.LevelGround, false, null, null);
            TestCraftingRecipe = new CraftingRecipe(-All.CraftingRecipeIDs.Minimum, "4 Test Crafting Recipe",
                                                    "Test", "Test",
                                                    TestRecipeElementList, TestRecipeElementList,
                                                    new StrikePanelGrid(Rules.Dimensions.PanelsPerPatternHeight,
                                                                        Rules.Dimensions.PanelsPerPatternWidth));
            // TODO Update this once Dialogue is implemented.
            TestDialogue = new Dialogue(-All.DialogueIDs.Minimum, "5 Test Dialogue", "Test", "Test");
            TestMapChunk = new MapChunk(-All.MapChunkIDs.Minimum, "11 Test Map Chunk", "Test", "Test");
            TestMapRegion = new MapRegion(-All.MapRegionIDs.Minimum, "12 Test Map Region", "Test", "Test");
            TestFloor = new Floor(-All.FloorIDs.Minimum, "3 Test Floor", "Test", "Test", inAddsToRoom: TestTag);
            TestBlock = new Block(-All.BlockIDs.Minimum, "4 Test Block", "Test", "Test", inAddsToRoom: TestTag);
            TestLiquid = new Block(-All.BlockIDs.Minimum - 1, "L Test Liquid Block", "Test", "Test", inIsLiquid: true, inAddsToRoom: TestTag);
            TestFurnishing = new Furnishing(-All.FurnishingIDs.Minimum, "5 Test Furnishing", "Test", "Test",
                                            inIsEntry: true, inAddsToRoom: TestTag);
            TestCollectible = new Collectible(-All.CollectibleIDs.Minimum, "6 Test Collectible", "Test", "Test",
                                              inAddsToRoom: TestTag);
            // TODO Update this once Quests are implemented.
            TestQuest = new Quest(-All.QuestIDs.Minimum, "9 Test Quest", "Test", "Test", TestQuestRequirementsList);
            TestRoomRecipe = new RoomRecipe(-All.RoomRecipeIDs.Minimum - 1, "7 Test Room Recipe", "Test", "Test",
                                            TestRecipeElementList, Rules.Recipes.Room.MinWalkableSpaces + 1,
                                            TestRecipeElementList, TestRecipeElementList);
            TestItem = new Item(-All.ItemIDs.Minimum, "11 Test Item", "Test", "Test", ItemType.Other,
                                1, 0, 99, 1, 1, -All.BlockIDs.Minimum);

            #region Initialize TestMapChunk
            for (var y = 0; y < TestMapChunk.DimensionsInParquets.Y; y++)
            {
                for (var x = 0; x < TestMapChunk.DimensionsInParquets.X; x++)
                {
                    TestMapChunk.TrySetFloorDefinition(TestEntities.TestFloor.ID, new Vector2D(x, y));
                }

                TestMapChunk.TrySetBlockDefinition(TestEntities.TestBlock.ID, new Vector2D(0, y));
                TestMapChunk.TrySetBlockDefinition(TestEntities.TestBlock.ID, new Vector2D(TestMapChunk.DimensionsInParquets.X - 1, y));
            }
            for (var x = 0; x < TestMapChunk.DimensionsInParquets.X; x++)
            {
                TestMapChunk.TrySetBlockDefinition(TestEntities.TestBlock.ID, new Vector2D(x, 0));
                TestMapChunk.TrySetBlockDefinition(TestEntities.TestBlock.ID, new Vector2D(x, TestMapChunk.DimensionsInParquets.Y - 1));
            }
            TestMapChunk.TrySetFurnishingDefinition(TestEntities.TestFurnishing.ID, new Vector2D(1, 2));
            TestMapChunk.TrySetCollectibleDefinition(TestEntities.TestCollectible.ID, new Vector2D(3, 3));
            #endregion
            #endregion

            #region Initialize All
            Beings = new List<Being> { TestCritter, TestNPC, TestPlayer };
            Biomes = new List<Biome> { TestBiome };
            CraftingRecipes = new List<CraftingRecipe> { TestCraftingRecipe };
            Dialogues = new List<Dialogue> { TestDialogue };
            Maps = new List<MapParent> { TestMapChunk, TestMapRegion };
            Parquets = new List<ParquetParent> { TestFloor, TestBlock, TestLiquid, TestFurnishing, TestCollectible };
            Quests = new List<Quest> { TestQuest };
            RoomRecipes = new List<RoomRecipe> { TestRoomRecipe };
            Items = new List<Item> { TestItem };

            All.InitializeCollections(Beings, Biomes, CraftingRecipes, Dialogues, Maps, Parquets, Quests, RoomRecipes, Items);
            #endregion
        }
    }
}
