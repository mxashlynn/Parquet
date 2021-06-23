using System.Collections.Generic;
using Parquet;
using Parquet.Beings;
using Parquet.Biomes;
using Parquet.Crafts;
using Parquet.Games;
using Parquet.Items;
using Parquet.Parquets;
using Parquet.Regions;
using Parquet.Rooms;
using Parquet.Scripts;

namespace ParquetRunner
{
    #region Test Stuff
    /// <summary>
    /// Stores <see cref="Model"/>s for use in unit testing.
    /// </summary>
    public static class TestModels
    {
        #region Test Value Components
        /// <summary>Used in test patterns in QA routines.</summary>
        public static readonly ModelTag TestTag = "Test-Tag";
        /// <summary>Used in test patterns in QA routines.</summary>
        public static readonly ScriptNode TestNode = $"A{Delimiters.InternalDelimiter}{Delimiters.InternalDelimiter}Test Alert";
        /// <summary>Used in test patterns in QA routines.</summary>
        public static readonly IReadOnlyList<RecipeElement> TestRecipeElementList = new List<RecipeElement> { new RecipeElement(1, TestTag) };
        /// <summary>Used in test patterns in QA routines.</summary>
        public static readonly IReadOnlyList<ModelTag> TestTagList = new List<ModelTag> { TestTag };
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
        public static RegionModel TestRegionModel { get; }

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

        /// <summary>Used in test patterns in QA routines.</summary>
        public static ParquetModelPackGrid TestParquetModelPackGrid { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static ParquetStatusPackGrid TestParquetStatusPackGrid { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static RegionStatus TestRegionStatus { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<PronounGroup> PronounGroups { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<CharacterModel> Characters { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<CritterModel> Critters { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<BiomeRecipe> BiomeRecipes { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<CraftingRecipe> CraftingRecipes { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<GameModel> Games { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<InteractionModel> Interactions { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<RegionModel> Regions { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<FloorModel> Floors { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<BlockModel> Blocks { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<FurnishingModel> Furnishings { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<CollectibleModel> Collectibles { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<RoomRecipe> RoomRecipes { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<ScriptModel> Scripts { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyList<ItemModel> Items { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static IReadOnlyDictionary<ModelID, RegionStatus> RegionStatuses { get; }

        #endregion

        /// <summary>
        /// Initializes unit test example models.
        /// Sets up <see cref="All"/> so that bounds can be checked in various constructors.
        /// </summary>
        static TestModels()
        {
            #region Initialize Instances
            TestPronounGroup = new PronounGroup("thon", "thon", "thons", "thons", "thonself");
            TestCritter = new CritterModel(-All.CritterIDs.Minimum, "1 Test Critter", "Test", "Test", null, All.BiomeRecipeIDs.Minimum, All.ScriptIDs.Minimum);
            TestCharacter = new CharacterModel(-All.CharacterIDs.Minimum, "2 Test Character", "Test", "Test", null, All.BiomeRecipeIDs.Minimum, All.ScriptIDs.Minimum);
            TestBiome = new BiomeRecipe(-All.BiomeRecipeIDs.Minimum, "3 Test Biome", "Test", "Test", null, 1, false, false, null, null);
            TestCraftingRecipe = new CraftingRecipe(-All.CraftingRecipeIDs.Minimum, "4 Test Crafting Recipe", "Test", "Test",
                                                    null, TestRecipeElementList, TestRecipeElementList);
            TestInteraction = new InteractionModel(-All.InteractionIDs.Minimum, "5 Test Interaction", "Test", "Test", null, null, null, null);
            TestRegionModel = new RegionModel(-All.RegionIDs.Minimum, "7 Test Map Region", "Test", "Test");
            TestFloor = new FloorModel(-All.FloorIDs.Minimum, "8 Test Floor", "Test", "Test", addsToRoom: new List<ModelTag> { TestTag });
            TestBlock = new BlockModel(-All.BlockIDs.Minimum, "9 Test Block", "Test", "Test", addsToRoom: new List<ModelTag> { TestTag });
            TestLiquid = new BlockModel(-All.BlockIDs.Minimum - 1, "L Test Liquid Block", "Test", "Test", isLiquid: true, addsToRoom: new List<ModelTag> { TestTag });
            TestFurnishing = new FurnishingModel(-All.FurnishingIDs.Minimum, "10 Test Furnishing", "Test", "Test",
                                                 entry: EntryType.Room, addsToRoom: new List<ModelTag> { TestTag });
            TestCollectible = new CollectibleModel(-All.CollectibleIDs.Minimum, "11 Test Collectible", "Test", "Test", addsToRoom: new List<ModelTag> { TestTag });
            TestRoomRecipe = new RoomRecipe(-All.RoomRecipeIDs.Minimum - 1, "12 Test Room Recipe", "Test", "Test", null,
                                            RoomConfiguration.MinWalkableSpaces + 1, TestRecipeElementList,
                                            TestRecipeElementList, TestRecipeElementList);
            TestScript = new ScriptModel(-All.ScriptIDs.Minimum, "13 Test Script", "Test", "Test", null, TestNodeList);
            TestItem1 = new ItemModel(-All.ItemIDs.Minimum, "14 Test Item 1", "Test", "Test", TestTagList, ItemType.Other,
                                      1, 0, 99, All.ScriptIDs.Minimum, All.ScriptIDs.Minimum, -All.BlockIDs.Minimum);
            TestItem2 = new ItemModel(-All.ItemIDs.Minimum - 1, "14 Test Item 2", "Test", "Test", TestTagList, ItemType.Other,
                                      1, 0, 999, All.ScriptIDs.Minimum, All.ScriptIDs.Minimum, -All.BlockIDs.Minimum - 1);
            TestItem3 = new ItemModel(-All.ItemIDs.Minimum - 2, "14 Test Item 3", "Test", "Test", TestTagList, ItemType.Other,
                                      1, 0, 999, All.ScriptIDs.Minimum, All.ScriptIDs.Minimum, -All.BlockIDs.Minimum - 2);
            TestItem4 = new ItemModel(-All.ItemIDs.Minimum - 3, "14 Test Item 4", "Test", "Test", TestTagList, ItemType.Other,
                                      1, 0, 999, All.ScriptIDs.Minimum, All.ScriptIDs.Minimum, -All.BlockIDs.Minimum - 3);
            // TODO [MAPS] Fill this in.
            TestParquetModelPackGrid = null;
            // TODO [MAPS] Fill this in.
            TestParquetStatusPackGrid = null;
            TestRegionStatus = new RegionStatus(TestParquetModelPackGrid, TestParquetStatusPackGrid);
            TestGame = new GameModel(-All.GameIDs.Minimum, "4.5 Test Game", "Test", "Test", null, false, "Not an episode", -1, TestCharacter.ID, TestScript.ID);
            #endregion

            #region Initialize All
            PronounGroups = new List<PronounGroup> { TestPronounGroup };
            Characters = new List<CharacterModel> { TestCharacter };
            Critters = new List<CritterModel> { TestCritter };
            BiomeRecipes = new List<BiomeRecipe> { TestBiome };
            CraftingRecipes = new List<CraftingRecipe> { TestCraftingRecipe };
            Games = new List<GameModel> { TestGame };
            Interactions = new List<InteractionModel> { TestInteraction };
            Regions = new List<RegionModel> { TestRegionModel };
            RegionStatuses = new Dictionary<ModelID, RegionStatus> { { TestRegionModel.ID, TestRegionStatus } };
            Floors = new List<FloorModel> { TestFloor };
            Blocks = new List<BlockModel> { TestBlock, TestLiquid };
            Furnishings = new List<FurnishingModel> { TestFurnishing };
            Collectibles = new List<CollectibleModel> { TestCollectible };
            RoomRecipes = new List<RoomRecipe> { TestRoomRecipe };
            Items = new List<ItemModel> { TestItem1, TestItem2, TestItem3, TestItem4 };
            Scripts = new List<ScriptModel> { TestScript };

            All.InitializeModelCollections(PronounGroups, Games, Floors, Blocks, Furnishings, Collectibles, Critters, Characters,
                                           BiomeRecipes, CraftingRecipes, RoomRecipes, Regions, RegionStatuses, Scripts, Interactions,
                                           Items);
            #endregion
        }
    }
    #endregion

    /// <summary>
    /// A simple program used to run some basic features of <see cref="Parquet"/>.
    /// </summary>
    internal static class RunnerProgram
    {
        /// <summary>
        /// A simple program used to run some basic features of the <see cref="Parquet"/>.
        /// </summary>
        internal static void Main()
        {
            Logger.Log(LogLevel.Info, LibraryState.IsDebugMode ? "Debug Mode" : "Release Mode");
            LibraryState.IsPlayMode = true;

            Logger.Log(LogLevel.Info, All.TryLoadModels() ? "Loaded." : "Failed to load!");

            var game = new GameModel(All.GameIDs.Minimum + 1, "Sample Game", "", "", null, false, "", -1, All.CharacterIDs.Minimum, All.ScriptIDs.Minimum);
            var episode = new GameModel(All.GameIDs.Minimum + 2, "Sample Episode", "", "", null, true, "In Which A Library Is Tested", 1, All.CharacterIDs.Minimum, All.ScriptIDs.Minimum);
            Logger.Log(LogLevel.Info, game);
            Logger.Log(LogLevel.Info, episode);
            Logger.Log(LogLevel.Info, $"Item range = {All.ItemIDs}");

            Logger.Log(LogLevel.Info, All.TrySaveModels() ? "Saved." : "Failed to save!");
        }
    }
}
