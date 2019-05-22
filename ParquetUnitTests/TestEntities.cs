using System.Collections.Generic;
using ParquetClassLibrary;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Characters;
using ParquetClassLibrary.Crafting;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Rooms;

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
        #endregion

        #region Test Values
        /// <summary>Used in test patterns in QA routines.</summary>
        public static PlayerCharacter TestPlayer { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static Critter TestCritter { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static NPC TestNPC { get; }

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
        public static RoomRecipe TestRoomRecipe { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static CraftingRecipe TestCraftingRecipe { get; }

        // TODO Update this once Quests are implemented.  Also update type initializer.
        /// <summary>Used in test patterns in QA routines.</summary>
        //public static Quest TestQuest { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static Biome TestBiome { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static Item TestItem { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static List<ParquetParent> Parquets { get; }
        #endregion

        static TestEntities()
        {
            TestPlayer = new PlayerCharacter(-All.PlayerCharacterIDs.Minimum, "0", "Test Player", "Test", "Test");
            TestCritter = new Critter(-All.CritterIDs.Minimum, "1 Test Critter", "Test", "Test",
                                      All.BiomeIDs.Minimum, Behavior.Still);
            TestNPC = new NPC(-All.NpcIDs.Minimum, "2", "Test NPC", "Test", "Test",
                              All.BiomeIDs.Minimum, Behavior.Still);
            TestFloor = new Floor(-All.FloorIDs.Minimum, "3 Test Floor", "Test", "Test", in_addsToRoom: TestTag);
            TestBlock = new Block(-All.BlockIDs.Minimum, "4 Test Block", "Test", "Test", in_addsToRoom: TestTag);
            TestLiquid = new Block(-All.BlockIDs.Minimum, "L Test Liquid Block", "Test", "Test", in_isLiquid: true, in_addsToRoom: TestTag);
            TestFurnishing = new Furnishing(-All.FurnishingIDs.Minimum, "5 Test Furnishing", "Test", "Test",
                                            in_isEntry: true, in_addsToRoom: TestTag);
            TestCollectible = new Collectible(-All.CollectibleIDs.Minimum, "6 Test Collectible", "Test", "Test",
                                              in_addsToRoom: TestTag);
            TestRoomRecipe = new RoomRecipe(-All.RoomRecipeIDs.Minimum - 1, "7 Test Room Recipe", "Test", "Test",
                                            TestRecipeElementList, All.Recipes.Rooms.MinWalkableSpaces + 1,
                                            TestRecipeElementList, TestRecipeElementList);
            TestCraftingRecipe = new CraftingRecipe(-All.CraftingRecipeIDs.Minimum, "8 Test Crafting Recipe",
                                                    "Test", "Test",
                                                    TestRecipeElementList, TestRecipeElementList,
                                                    new StrikePanel[All.Dimensions.PanelsPerPatternWidth,
                                                                    All.Dimensions.PanelsPerPatternHeight]);
            //TestQuest = new Quest(-All.QuestIDs.Minimum, "9 Test Quest", "Test", "Test");
            TestBiome = new Biome(-All.BiomeIDs.Minimum, "10 Test Biome", "Test", "Test",
                                  1, Elevation.LevelGround, false, null, null);
            TestItem = new Item(-All.ItemIDs.Minimum, ItemType.Other, "11 Test Item", "Test", "Test",
                                1, 0, 99, 1, 1, -All.BlockIDs.Minimum);

            // Sets up All so that bounds can be checked in various constructors.
            Parquets = new List<ParquetParent> { TestFloor, TestBlock, TestFurnishing, TestCollectible };
            All.InitializeCollections(Parquets);
        }
    }
}
