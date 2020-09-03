using System.Collections.Generic;
using ParquetClassLibrary;
using ParquetClassLibrary.Beings;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Crafts;
using ParquetClassLibrary.Games;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Rooms;
using ParquetClassLibrary.Scripts;

namespace ParquetUnitTests
{
    /// <summary>
    /// Stores <see cref="Model"/>s for use in unit testing.
    /// </summary>
    public static class TestModels
    {
        #region Test Value Components
        /// <summary>Used in test patterns in QA routines.</summary>
        public static readonly ModelTag TestTag = "Test Tag";
        /// <summary>Used in test patterns in QA routines.</summary>
        public static readonly ScriptNode TestNode = $"A{Delimiters.InternalDelimiter}{Delimiters.InternalDelimiter}Test Alert";
        /// <summary>Used in test patterns in QA routines.</summary>
        public static readonly IReadOnlyList<RecipeElement> TestRecipeElementList = new List<RecipeElement> { new RecipeElement(1, TestTag) };
        /// <summary>Used in test patterns in QA routines.</summary>
        public static readonly IReadOnlyList<ModelTag> TestQuestRequirementsList = new List<ModelTag> { TestTag };
        /// <summary>Used in test patterns in QA routines.</summary>
        public static readonly IReadOnlyList<ScriptNode> TestNodeList = new List<ScriptNode> { TestNode };
        #endregion

        #region Test Values
        /// <summary>Used in test patterns in QA routines.</summary>
        public static PronounGroup TestPronounGroup { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static CharacterModel TestCharacter { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static CritterModel TestCritter { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static BiomeRecipe TestBiome { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static CraftingRecipe TestCraftingRecipe { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static GameModel TestGame { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static InteractionModel TestInteraction { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static MapChunkModel TestMapChunkModel { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static MapRegionModel TestMapRegionModel { get; }

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
        public static RoomRecipe TestRoomRecipe { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static ScriptModel TestScript { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static ItemModel TestItem1 { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static ItemModel TestItem2 { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static ItemModel TestItem3 { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static ItemModel TestItem4 { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<PronounGroup> PronounGroups { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<CharacterModel> Characters { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<CritterModel> Critters { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<BiomeRecipe> Biomes { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<CraftingRecipe> CraftingRecipes { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<GameModel> Games { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<InteractionModel> Interactions { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<MapModel> Maps { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<ParquetModel> Parquets { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<RoomRecipe> RoomRecipes { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<ScriptModel> Scripts { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<ItemModel> Items { get; }
        #endregion

        /// <summary>
        /// Initializes unit test example models.
        /// Sets up <see cref="All"/> so that bounds can be checked in various constructors.
        /// </summary>
        static TestModels()
        {
            #region Initialize Instances
            TestPronounGroup = new PronounGroup("thon", "thon", "thons", "thons", "thonself");
            TestCritter = new CritterModel(-All.CritterIDs.Minimum, "1 Test Critter", "Test", "Test", All.BiomeIDs.Minimum, All.ScriptIDs.Minimum);
            TestCharacter = new CharacterModel(-All.CharacterIDs.Minimum, "2 Test Character", "Test", "Test", All.BiomeIDs.Minimum, All.ScriptIDs.Minimum);
            TestBiome = new BiomeRecipe(-All.BiomeIDs.Minimum, "3 Test Biome", "Test", "Test", 1, false, false, null, null);
            TestCraftingRecipe = new CraftingRecipe(-All.CraftingRecipeIDs.Minimum, "4 Test Crafting Recipe", "Test", "Test",
                                                    TestRecipeElementList, TestRecipeElementList,
                                                    new StrikePanelGrid(StrikePanelGrid.PanelsPerPatternHeight, StrikePanelGrid.PanelsPerPatternWidth));
            TestInteraction = new InteractionModel(-All.InteractionIDs.Minimum, "5 Test Interaction", "Test", "Test", null, null, null);
            TestMapChunkModel = new MapChunkModel(-All.MapChunkIDs.Minimum, "6 Test Map Chunk", "Test", "Test", 0, true);
            TestMapRegionModel = new MapRegionModel(-All.MapRegionIDs.Minimum, "7 Test Map Region", "Test", "Test");
            TestFloor = new FloorModel(-All.FloorIDs.Minimum, "8 Test Floor", "Test", "Test", inAddsToRoom: new List<ModelTag> { TestTag });
            TestBlock = new BlockModel(-All.BlockIDs.Minimum, "9 Test Block", "Test", "Test", inAddsToRoom: new List<ModelTag> { TestTag });
            TestLiquid = new BlockModel(-All.BlockIDs.Minimum - 1, "L Test Liquid Block", "Test", "Test", inIsLiquid: true, inAddsToRoom: new List<ModelTag> { TestTag });
            TestFurnishing = new FurnishingModel(-All.FurnishingIDs.Minimum, "10 Test Furnishing", "Test", "Test",
                                                 inEntry: EntryType.Room, inAddsToRoom: new List<ModelTag> { TestTag });
            TestCollectible = new CollectibleModel(-All.CollectibleIDs.Minimum, "11 Test Collectible", "Test", "Test", inAddsToRoom: new List<ModelTag> { TestTag });
            TestRoomRecipe = new RoomRecipe(-All.RoomRecipeIDs.Minimum - 1, "12 Test Room Recipe", "Test", "Test",
                                            RoomConfiguration.MinWalkableSpaces + 1, TestRecipeElementList,
                                            TestRecipeElementList, TestRecipeElementList);
            TestScript = new ScriptModel(-All.ScriptIDs.Minimum, "13 Test Script", "Test", "Test", TestNodeList);
            TestItem1 = new ItemModel(-All.ItemIDs.Minimum, "14 Test Item 1", "Test", "Test", ItemType.Other,
                                      1, 0, 99, All.ScriptIDs.Minimum, All.ScriptIDs.Minimum, -All.BlockIDs.Minimum);
            TestItem2 = new ItemModel(-All.ItemIDs.Minimum - 1, "14 Test Item 2", "Test", "Test", ItemType.Other,
                                      1, 0, 999, All.ScriptIDs.Minimum, All.ScriptIDs.Minimum, -All.BlockIDs.Minimum - 1);
            TestItem3 = new ItemModel(-All.ItemIDs.Minimum - 2, "14 Test Item 3", "Test", "Test", ItemType.Other,
                                      1, 0, 999, All.ScriptIDs.Minimum, All.ScriptIDs.Minimum, -All.BlockIDs.Minimum - 2);
            TestItem4 = new ItemModel(-All.ItemIDs.Minimum - 3, "14 Test Item 4", "Test", "Test", ItemType.Other,
                                      1, 0, 999, All.ScriptIDs.Minimum, All.ScriptIDs.Minimum, -All.BlockIDs.Minimum - 3);
            TestGame = new GameModel(-All.GameIDs.Minimum, "4.5 Test Game", "Test", "Test", false, "Not an episode", -1, TestCharacter.ID, TestScript.ID);

            #region Initialize TestMapChunkModel
            for (var y = 0; y < TestMapChunkModel.DimensionsInParquets.Y; y++)
            {
                for (var x = 0; x < TestMapChunkModel.DimensionsInParquets.X; x++)
                {
                    TestMapChunkModel.ParquetDefinitions[y, x].FloorID = TestFloor.ID;
                }

                TestMapChunkModel.ParquetDefinitions[y, 0].BlockID = TestBlock.ID;
                TestMapChunkModel.ParquetDefinitions[y, TestMapChunkModel.DimensionsInParquets.X - 1].BlockID = TestBlock.ID;
            }
            for (var x = 0; x < TestMapChunkModel.DimensionsInParquets.X; x++)
            {
                TestMapChunkModel.ParquetDefinitions[0, x].BlockID = TestBlock.ID;
                TestMapChunkModel.ParquetDefinitions[TestMapChunkModel.DimensionsInParquets.Y - 1, x].BlockID = TestBlock.ID;
            }
            TestMapChunkModel.ParquetDefinitions[2, 1].FurnishingID = TestFurnishing.ID;
            TestMapChunkModel.ParquetDefinitions[3, 3].CollectibleID = TestCollectible.ID;
            #endregion
            #endregion

            #region Initialize All
            PronounGroups = new List<PronounGroup> { TestPronounGroup };
            Characters = new List<CharacterModel> { TestCharacter };
            Critters = new List<CritterModel> { TestCritter };
            Biomes = new List<BiomeRecipe> { TestBiome };
            CraftingRecipes = new List<CraftingRecipe> { TestCraftingRecipe };
            Games = new List<GameModel> { TestGame };
            Interactions = new List<InteractionModel> { TestInteraction };
            Maps = new List<MapModel> { TestMapChunkModel, TestMapRegionModel };
            Parquets = new List<ParquetModel> { TestFloor, TestBlock, TestLiquid, TestFurnishing, TestCollectible };
            RoomRecipes = new List<RoomRecipe> { TestRoomRecipe };
            Items = new List<ItemModel> { TestItem1, TestItem2, TestItem3, TestItem4 };
            Scripts = new List<ScriptModel> { TestScript };

            All.InitializeCollections(PronounGroups, Characters, Critters, Biomes, CraftingRecipes, Games, Interactions, Maps, Parquets, RoomRecipes, Scripts, Items);
            #endregion
        }
    }
}
