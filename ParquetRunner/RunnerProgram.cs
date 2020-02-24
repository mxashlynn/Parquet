using System;
using System.Collections.Generic;
using ParquetClassLibrary;
using ParquetClassLibrary.Beings;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Crafts;
using ParquetClassLibrary.Interactions;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Rooms;

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
        public static readonly IReadOnlyList<RecipeElement> TestRecipeElementList = new List<RecipeElement> { new RecipeElement(1, TestTag) };
        public static readonly IReadOnlyList<EntityTag> TestQuestRequirementsList = new List<EntityTag> { TestTag };
        #endregion

        #region Test Values
        /// <summary>Used in test patterns in QA routines.</summary>
        public static PronounGroup TestPronounGroup { get; }

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
        public static IReadOnlyList<PronounGroup> PronounGroups { get; }

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
            #region Initialize Instances
            TestPronounGroup = new PronounGroup("thon", "thon", "thons", "thons", "thonself");
            TestPlayer = new PlayerCharacterModel(-All.PlayerCharacterIDs.Minimum, "0 Test Player", "Test", "Test",
                                                  All.BiomeIDs.Minimum, Behavior.PlayerControlled);
            TestCritter = new CritterModel(-All.CritterIDs.Minimum, "1 Test Critter", "Test", "Test", All.BiomeIDs.Minimum, Behavior.Still);
            TestNPC = new NPCModel(-All.NpcIDs.Minimum, "2 Test NPC", "Test", "Test", All.BiomeIDs.Minimum, Behavior.Still);
            TestBiome = new BiomeModel(-All.BiomeIDs.Minimum, "3 Test Biome", "Test", "Test", 1, Elevation.LevelGround, false, null, null);
            TestCraftingRecipe = new CraftingRecipe(-All.CraftingRecipeIDs.Minimum, "4 Test Crafting Recipe", "Test", "Test",
                                                    TestRecipeElementList, TestRecipeElementList,
                                                    new StrikePanelGrid(Rules.Dimensions.PanelsPerPatternHeight,
                                                                        Rules.Dimensions.PanelsPerPatternWidth));
            // TODO Update this once Dialogue is implemented.
            TestDialogue = new DialogueModel(-All.DialogueIDs.Minimum, "5 Test Dialogue", "Test", "Test", null, null, null);
            TestMapChunk = new MapChunk(-All.MapChunkIDs.Minimum, "11 Test Map Chunk", "Test", "Test", AssemblyInfo.SupportedMapDataVersion);
            TestMapRegion = new MapRegion(-All.MapRegionIDs.Minimum, "12 Test Map Region", "Test", "Test");
            TestFloor = new FloorModel(-All.FloorIDs.Minimum, "3 Test Floor", "Test", "Test", inAddsToRoom: TestTag);
            TestBlock = new BlockModel(-All.BlockIDs.Minimum, "4 Test Block", "Test", "Test", inAddsToRoom: TestTag);
            TestLiquid = new BlockModel(-All.BlockIDs.Minimum - 1, "L Test Liquid Block", "Test", "Test", inIsLiquid: true, inAddsToRoom: TestTag);
            TestFurnishing = new FurnishingModel(-All.FurnishingIDs.Minimum, "5 Test Furnishing", "Test", "Test",
                                                 inIsEntry: true, inAddsToRoom: TestTag);
            TestCollectible = new CollectibleModel(-All.CollectibleIDs.Minimum, "6 Test Collectible", "Test", "Test", inAddsToRoom: TestTag);
            // TODO Update this once Quests are implemented.
            TestQuest = new QuestModel(-All.QuestIDs.Minimum, "9 Test Quest", "Test", "Test", TestQuestRequirementsList, null, null, null);
            TestRoomRecipe = new RoomRecipe(-All.RoomRecipeIDs.Minimum - 1, "7 Test Room Recipe", "Test", "Test",
                                            Rules.Recipes.Room.MinWalkableSpaces + 1, TestRecipeElementList,
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
            PronounGroups = new List<PronounGroup> { TestPronounGroup };
            Beings = new List<BeingModel> { TestCritter, TestNPC, TestPlayer };
            Biomes = new List<BiomeModel> { TestBiome };
            CraftingRecipes = new List<CraftingRecipe> { TestCraftingRecipe };
            Interactions = new List<InteractionModel> { TestDialogue, TestQuest };
            Maps = new List<MapModel> { TestMapChunk, TestMapRegion };
            Parquets = new List<ParquetModel> { TestFloor, TestBlock, TestLiquid, TestFurnishing, TestCollectible };
            RoomRecipes = new List<RoomRecipe> { TestRoomRecipe };
            Items = new List<ItemModel> { TestItem1, TestItem2, TestItem3, TestItem4 };

            All.InitializeCollections(PronounGroups, Beings, Biomes, CraftingRecipes, Interactions, Maps, Parquets, RoomRecipes, Items);
            #endregion
        }
    }
    #endregion

    /// <summary>
    /// A simple program used to run some basic features of the <see cref="ParquetClassLibrary"/>.
    /// </summary>
    internal class MainClass
    {
        #region Room Collection Test Values
        private static readonly ParquetStack TVoid = ParquetStack.Empty;
        private static readonly ParquetStack TWall = new ParquetStack(TestModels.TestFloor.ID, TestModels.TestBlock.ID, EntityID.None, EntityID.None);
        private static readonly ParquetStack TDoor = new ParquetStack(TestModels.TestFloor.ID, TestModels.TestBlock.ID, TestModels.TestFurnishing.ID, EntityID.None);
        private static readonly ParquetStack TTile = new ParquetStack(TestModels.TestFloor.ID, EntityID.None, EntityID.None, EntityID.None);
        private static readonly ParquetStack TStep = new ParquetStack(TestModels.TestFloor.ID, EntityID.None, TestModels.TestFurnishing.ID, EntityID.None);
        private static readonly ParquetStack TWell = new ParquetStack(TestModels.TestFloor.ID, TestModels.TestLiquid.ID, EntityID.None, EntityID.None);

        #region Valid Subregions
        private static readonly ParquetStack[,] OneMinimalRoomMap =
        {
            { TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), },
            { TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), },
            { TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), },
            { TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TTile.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] TestRoomMap =
        {
            { TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TWall.Clone(), TTile.Clone(), TTile.Clone(), TDoor.Clone(), TTile.Clone(), },
            { TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] OneSimpleRoomMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TTile.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] OneRoomCentralPillarMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TTile.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] OneRoomCentralWellMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWell.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TTile.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] OneRoomCentralVoidMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TVoid.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TTile.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] OneRoomCornerLakeMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWell.Clone(), TWell.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWell.Clone(), TWell.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TTile.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] OneRoomIntrusionMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TTile.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] OneRoomExtrusionMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TTile.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] OneRoomCrossMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TTile.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] OneRoomInnerMoatMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWell.Clone(), TTile.Clone(), TStep.Clone(), TTile.Clone(), TTile.Clone(), TWell.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] OneRoomInaccessibleFloorMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWell.Clone(), TWell.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TWall.Clone(), TStep.Clone(), TTile.Clone(), TWell.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWell.Clone(), TWell.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] OneRoomUShapeMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TTile.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] OneRoomDonoughtShapeMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TTile.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] OneRoomThickWallsMap =
        {
            { TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), },
            { TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), },
            { TWall.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), },
            { TWall.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), },
            { TWall.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), },
            { TWall.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), },
            { TWall.Clone(), TWall.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), },
        };
        private static readonly ParquetStack[,] TwoSimpleRoomsMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TTile.Clone(), TStep.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TTile.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] TwoJoinedRoomsMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TTile.Clone(), TStep.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TTile.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] SixSimpleRoomsMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TTile.Clone(), TStep.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TTile.Clone(), TDoor.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TWall.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TTile.Clone(), TStep.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TWall.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        #endregion

        #region Invalid Subregions
        private static readonly ParquetStack[,] RoomTooSmallMap =
        {
            { TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TWall.Clone(), TTile.Clone(), TWall.Clone(), TWall.Clone(), },
            { TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), },
            { TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), },
        };
        private static readonly ParquetStack[,] NoDoorMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] NoFloorMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] FloodedMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] NoWallsMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TTile.Clone(), TStep.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] IncompletePerimeterMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] WrongEntryMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TStep.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] MoatInsteadOfWallsMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWell.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWell.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWell.Clone(), TTile.Clone(), TStep.Clone(), TTile.Clone(), TWell.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWell.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWell.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] MissingWallMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] MoatWallMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] PerforatedWallMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TStep.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] InvertedMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] IncompleteMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), },
            { TTile.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TTile.Clone(), },
            { TTile.Clone(), TWall.Clone(), TTile.Clone(), TStep.Clone(), TTile.Clone(), TWall.Clone(), TTile.Clone(), },
            { TTile.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TTile.Clone(), },
            { TTile.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TTile.Clone(), },
            { TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), },
        };
        private static readonly ParquetStack[,] IslandStepMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWell.Clone(), TStep.Clone(), TWell.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };

        private static readonly ParquetStack[,] BlockedEntryMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TDoor.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] FloodedDoorMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWell.Clone(), TDoor.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] DisconectedEntryMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TDoor.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] DisconectedFloorMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWell.Clone(), TTile.Clone(), TWell.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWell.Clone(), TTile.Clone(), TWell.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] AllFloorMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] AllWallsMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TDoor.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TDoor.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] AllVoidMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] LoopNotEnclosingMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TDoor.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TWell.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWell.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] InaccessibleExitMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TStep.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] DoughnutNotEnclosingMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TStep.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] DoorUsedAsStepMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TDoor.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetStack[,] StepUsedAsDoorMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TStep.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        #endregion

        private static readonly ParquetStackGrid TestMapSubregion = new ParquetStackGrid(TestRoomMap);

        private static readonly RoomCollection TestCollection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(TestRoomMap));

        private static readonly HashSet<MapSpace> ExtantPerimeter = new HashSet<MapSpace>
        {
            new MapSpace(0, 0, TWall, TestMapSubregion),
            new MapSpace(1, 0, TWall, TestMapSubregion),
            new MapSpace(2, 0, TWall, TestMapSubregion),
            new MapSpace(3, 0, TWall, TestMapSubregion),
            new MapSpace(0, 1, TWall, TestMapSubregion),
            new MapSpace(3, 1, TWall, TestMapSubregion),
            new MapSpace(0, 2, TWall, TestMapSubregion),
            new MapSpace(3, 2, TDoor, TestMapSubregion),
            new MapSpace(0, 3, TWall, TestMapSubregion),
            new MapSpace(1, 3, TWall, TestMapSubregion),
            new MapSpace(2, 3, TWall, TestMapSubregion),
            new MapSpace(3, 3, TWall, TestMapSubregion),
        };
        private static readonly HashSet<MapSpace> ExtantWalkableArea = new HashSet<MapSpace>
        {
            new MapSpace(1, 1, TTile, TestMapSubregion),
            new MapSpace(2, 1, TTile, TestMapSubregion),
            new MapSpace(1, 2, TTile, TestMapSubregion),
            new MapSpace(2, 2, TTile, TestMapSubregion),
        };
        private static readonly Room ExtantRoom = new Room(ExtantWalkableArea, ExtantPerimeter);

        private static readonly HashSet<MapSpace> NonextantPerimeter = new HashSet<MapSpace>
        {
            new MapSpace(10, 10, TWall, null),
            new MapSpace(11, 10, TWall, null),
            new MapSpace(12, 10, TWall, null),
            new MapSpace(13, 10, TWall, null),
            new MapSpace(10, 11, TWall, null),
            new MapSpace(13, 11, TWall, null),
            new MapSpace(10, 12, TWall, null),
            new MapSpace(13, 12, TDoor, null),
            new MapSpace(10, 13, TWall, null),
            new MapSpace(11, 13, TWall, null),
            new MapSpace(12, 13, TWall, null),
            new MapSpace(13, 13, TWall, null),
        };
        private static readonly HashSet<MapSpace> NonextantWalkableArea = new HashSet<MapSpace>
        {
            new MapSpace(11, 11, TTile, null),
            new MapSpace(12, 11, TTile, null),
            new MapSpace(11, 12, TTile, null),
            new MapSpace(12, 12, TTile, null),
        };
        private static readonly Room NonextantRoom = new Room(NonextantWalkableArea, NonextantPerimeter);
        #endregion

        /// <summary>
        /// A simple program used to run some basic features of the <see cref="ParquetClassLibrary"/>.
        /// </summary>
        public static void Main()
        {
            //All.LoadFromCSV();

            //var region = new MapRegion(All.MapRegionIDs.Minimum, "Sample Region");
            //Console.WriteLine(region);
            //Console.WriteLine($"Item range = {All.ItemIDs}");

            //All.SaveToCSV();

            Console.WriteLine(TestCollection.Contains(ExtantRoom));
        }
    }
}
