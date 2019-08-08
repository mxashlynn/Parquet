using System;
using System.Collections.Generic;
using ParquetClassLibrary;
using ParquetClassLibrary.Map;
using ParquetClassLibrary.Stubs;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Rooms;

namespace ParquetRunner
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

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static List<ParquetParent> Parquets { get; }

        /// <summary>Used in initializing <see cref="All"/>.</summary>
        public static List<RoomRecipe> RoomRecipes { get; }
        #endregion

        static TestEntities()
        {
            TestFloor = new Floor(-All.FloorIDs.Minimum, "3 Test Floor", "Test", "Test", in_addsToRoom: TestTag);
            TestBlock = new Block(-All.BlockIDs.Minimum, "4 Test Block", "Test", "Test", in_addsToRoom: TestTag);
            TestLiquid = new Block(-All.BlockIDs.Minimum - 1, "L Test Liquid Block", "Test", "Test", in_isLiquid: true, in_addsToRoom: TestTag);
            TestFurnishing = new Furnishing(-All.FurnishingIDs.Minimum, "5 Test Furnishing", "Test", "Test",
                                            in_isEntry: true, in_addsToRoom: TestTag);
            TestCollectible = new Collectible(-All.CollectibleIDs.Minimum, "6 Test Collectible", "Test", "Test",
                                              in_addsToRoom: TestTag);
            TestRoomRecipe = new RoomRecipe(-All.RoomRecipeIDs.Minimum - 1, "7 Test Room Recipe", "Test", "Test",
                                            TestRecipeElementList, Rules.Recipes.Rooms.MinWalkableSpaces + 1,
                                            TestRecipeElementList, TestRecipeElementList);

            // Sets up All so that bounds can be checked in various constructors.
            Parquets = new List<ParquetParent> { TestFloor, TestBlock, TestLiquid, TestFurnishing, TestCollectible };
            RoomRecipes = new List<RoomRecipe> { TestRoomRecipe };
            All.InitializeCollections(Parquets, RoomRecipes);
        }
    }

    /// <summary>
    /// A simple program used to run some basic features of the <see cref="ParquetClassLibrary"/>.
    /// </summary>
    internal class MainClass
    {
        /// <summary>
        /// Entry point for the program.
        /// </summary>
        public static void Main()
        {
            var region = new MapRegion();
            Console.WriteLine(region);
            Console.WriteLine($"Item range = {All.ItemIDs}");
        }
    }
}
