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
        #region Test Values
        private static readonly ParquetStack TVoid = ParquetStack.Empty;
        private static readonly ParquetStack TWall = new ParquetStack(TestEntities.TestFloor.ID, TestEntities.TestBlock.ID, EntityID.None, EntityID.None);
        private static readonly ParquetStack TDoor = new ParquetStack(TestEntities.TestFloor.ID, TestEntities.TestBlock.ID, TestEntities.TestFurnishing.ID, EntityID.None);
        private static readonly ParquetStack TTile = new ParquetStack(TestEntities.TestFloor.ID, EntityID.None, EntityID.None, EntityID.None);
        private static readonly ParquetStack TStep = new ParquetStack(TestEntities.TestFloor.ID, EntityID.None, TestEntities.TestFurnishing.ID, EntityID.None);
        private static readonly ParquetStack TWell = new ParquetStack(TestEntities.TestFloor.ID, TestEntities.TestLiquid.ID, EntityID.None, EntityID.None);
        private static readonly ParquetStack FStep = new ParquetStack(TestEntities.TestFloor.ID, TestEntities.TestLiquid.ID, TestEntities.TestFurnishing.ID, EntityID.None);

        #region Valid Subregions
        private static readonly ParquetStack[,] OneMinimalRoomMap =
        {
            { TWall, TWall, TWall, TWall, },
            { TWall, TTile, TTile, TWall, },
            { TWall, TTile, TTile, TWall, },
            { TWall, TWall, TDoor, TWall, },
        };
        private static readonly ParquetStack[,] TestRoomMap =
        {
            { TWall, TWall, TWall, TWall, TVoid, },
            { TWall, TTile, TTile, TWall, TVoid, },
            { TWall, TTile, TTile, TDoor, TVoid, },
            { TWall, TWall, TWall, TWall, TVoid, },
        };
        private static readonly ParquetStack[,] OneSimpleRoomMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] OneRoomCentralPillarMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TWall, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] OneRoomCentralWellMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TWell, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] OneRoomCentralVoidMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TVoid, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] OneRoomCornerLakeMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWell, TWell, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWell, TWell, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] OneRoomIntrusionMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TWall, TWall, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] OneRoomExtrusionMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] OneRoomCrossMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TWall, TWall, TWall, TWall, TWall, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] OneRoomInnerMoatMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TWall, TWell, TWell, TWell, TWell, TWell, TWell, TWall, TVoid, },
            { TVoid, TWall, TWell, TTile, TStep, TTile, TTile, TWell, TWall, TVoid, },
            { TVoid, TWall, TWell, TWell, TWell, TWell, TWell, TWell, TWall, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] OneRoomInaccessibleFloorMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TVoid, TWall, TWall, TWall, TWall, TWall, TWall, TVoid, TVoid, },
            { TVoid, TVoid, TWall, TTile, TWell, TWell, TTile, TWall, TVoid, TVoid, },
            { TVoid, TVoid, TWall, TStep, TTile, TWell, TTile, TWall, TVoid, TVoid, },
            { TVoid, TVoid, TWall, TTile, TWell, TWell, TTile, TWall, TVoid, TVoid, },
            { TVoid, TVoid, TWall, TWall, TWall, TWall, TWall, TWall, TVoid, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] OneRoomUShapeMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TVoid, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TWall, TTile, TWall, TVoid, TWall, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TTile, TWall, TWall, TWall, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TTile, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] OneRoomDonoughtShapeMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TWall, TWall, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TTile, TTile, TWall, TVoid, TVoid, },
            { TVoid, TWall, TTile, TWall, TWall, TWall, TTile, TWall, TVoid, TVoid, },
            { TVoid, TWall, TTile, TWall, TVoid, TWall, TTile, TWall, TVoid, TVoid, },
            { TVoid, TWall, TTile, TWall, TWall, TWall, TTile, TWall, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TTile, TTile, TWall, TVoid, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TWall, TWall, TWall, TVoid, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] OneRoomThickWallsMap =
        {
            { TWall, TWall, TWall, TWall, TWall, TWall, TWall, TWall, TWall, TWall, },
            { TWall, TWall, TWall, TWall, TWall, TWall, TWall, TWall, TWall, TWall, },
            { TWall, TWall, TTile, TTile, TTile, TWall, TWall, TWall, TWall, TWall, },
            { TWall, TWall, TTile, TTile, TTile, TWall, TWall, TWall, TWall, TWall, },
            { TWall, TWall, TTile, TTile, TTile, TWall, TWall, TWall, TWall, TWall, },
            { TWall, TWall, TWall, TDoor, TWall, TWall, TWall, TWall, TWall, TWall, },
            { TWall, TWall, TWall, TWall, TWall, TWall, TWall, TWall, TWall, TWall, },
        };
        private static readonly ParquetStack[,] TwoSimpleRoomsMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TWall, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TWall, TTile, TStep, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TWall, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TWall, TVoid, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] TwoJoinedRoomsMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TTile, TStep, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] SixSimpleRoomsMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TWall, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TWall, TTile, TStep, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TWall, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TWall, TVoid, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TVoid, TWall, TWall, TWall, TWall, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TWall, TVoid, TDoor, TTile, TTile, TWall, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TWall, TVoid, TWall, TTile, TTile, TWall, TVoid, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TVoid, TWall, TWall, TWall, TWall, TVoid, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TWall, TWall, TWall, TWall, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TTile, TTile, TWall, TVoid, TWall, TWall, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TTile, TStep, TWall, TVoid, TWall, TWall, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TTile, TTile, TWall, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TWall, TWall, TWall, TVoid, TVoid, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        #endregion

        #region Invalid Subregions
        private static readonly ParquetStack[,] RoomTooSmallMap =
        {
            { TWall, TWall, TWall, TVoid, },
            { TWall, TTile, TWall, TWall, },
            { TWall, TTile, TTile, TWall, },
            { TWall, TWall, TDoor, TWall, },
        };
        private static readonly ParquetStack[,] NoDoorMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] NoFloorMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TWall, TVoid, TVoid, TVoid, TWall, TVoid, },
            { TVoid, TWall, TVoid, TVoid, TVoid, TWall, TVoid, },
            { TVoid, TWall, TVoid, TVoid, TVoid, TWall, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TWall, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] FloodedMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TWall, TWell, TWell, TWell, TWall, TVoid, },
            { TVoid, TWall, TWell, TWell, TWell, TWall, TVoid, },
            { TVoid, TWall, TWell, TWell, TWell, TWall, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TWall, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] NoWallsMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TTile, TTile, TTile, TTile, TTile, TVoid, },
            { TVoid, TTile, TTile, TTile, TTile, TTile, TVoid, },
            { TVoid, TTile, TTile, TStep, TTile, TTile, TVoid, },
            { TVoid, TTile, TTile, TTile, TTile, TTile, TVoid, },
            { TVoid, TTile, TTile, TTile, TTile, TTile, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] IncompletePerimeterMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TTile, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TWall, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] WrongEntryMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TWall, TStep, TWall, TWall, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] MoatInsteadOfWallsMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWell, TWell, TWell, TWell, TWell, TVoid, },
            { TVoid, TWell, TTile, TTile, TTile, TWell, TVoid, },
            { TVoid, TWell, TTile, TStep, TTile, TWell, TVoid, },
            { TVoid, TWell, TTile, TTile, TTile, TWell, TVoid, },
            { TVoid, TWell, TWell, TWell, TWell, TWell, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] MissingWallMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TTile, TTile, TTile, TTile, TTile, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TWall, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] MoatWallMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWell, TWell, TWell, TWell, TWell, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TWall, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] PerforatedWallMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TWall, TTile, TWall, TVoid, },
            { TVoid, TTile, TTile, TTile, TTile, TTile, TVoid, },
            { TVoid, TWall, TTile, TStep, TTile, TWall, TVoid, },
            { TVoid, TTile, TTile, TTile, TTile, TTile, TVoid, },
            { TVoid, TWall, TTile, TWall, TTile, TWall, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] InvertedMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TTile, TTile, TTile, TTile, TTile, TVoid, },
            { TVoid, TTile, TWall, TWall, TWall, TTile, TVoid, },
            { TVoid, TTile, TWall, TWall, TWall, TTile, TVoid, },
            { TVoid, TTile, TWall, TDoor, TWall, TTile, TVoid, },
            { TVoid, TTile, TTile, TTile, TTile, TTile, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] IncompleteMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TTile, TTile, TTile, TTile, TTile, TTile, TTile, },
            { TTile, TWall, TTile, TTile, TTile, TWall, TTile, },
            { TTile, TWall, TTile, TStep, TTile, TWall, TTile, },
            { TTile, TWall, TTile, TTile, TTile, TWall, TTile, },
            { TTile, TWall, TWall, TWall, TWall, TWall, TTile, },
            { TTile, TTile, TTile, TTile, TTile, TTile, TTile, },
        };
        private static readonly ParquetStack[,] IslandStepMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TWall, TWell, TWell, TWell, TWall, TVoid, },
            { TVoid, TWall, TWell, TStep, TWell, TWall, TVoid, },
            { TVoid, TWall, TWell, TWell, TWell, TWall, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };

        private static readonly ParquetStack[,] BlockedEntryMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TWall, TVoid, TVoid, },
            { TVoid, TWall, TTile, TWall, TDoor, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TWall, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TVoid, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] FloodedDoorMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TWall, TVoid, TVoid, },
            { TVoid, TWall, TTile, TWell, TDoor, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TWall, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TVoid, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] DisconectedEntryMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TWall, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TWall, TVoid, TDoor, },
            { TVoid, TWall, TTile, TTile, TWall, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TVoid, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] DisconectedFloorMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TWall, TWell, TTile, TWell, TWall, TVoid, },
            { TVoid, TWall, TTile, TWall, TTile, TWall, TVoid, },
            { TVoid, TWall, TWell, TTile, TWell, TWall, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TWall, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] AllFloorMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TTile, TTile, TTile, TTile, TTile, TVoid, },
            { TVoid, TTile, TTile, TTile, TTile, TTile, TVoid, },
            { TVoid, TTile, TTile, TTile, TTile, TTile, TVoid, },
            { TVoid, TTile, TTile, TTile, TTile, TTile, TVoid, },
            { TVoid, TTile, TTile, TTile, TTile, TTile, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] AllWallsMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TWall, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TDoor, TWall, TDoor, TWall, TDoor, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TWall, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] AllVoidMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] LoopNotEnclosingMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TDoor, TVoid, },
            { TVoid, TWall, TTile, TWall, TWall, TWall, TVoid, },
            { TVoid, TWall, TTile, TWall, TWell, TWall, TVoid, },
            { TVoid, TWall, TWell, TWall, TWall, TWall, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] InaccessibleExitMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TTile, TWall, TWall, TWall, TVoid, },
            { TVoid, TWall, TTile, TWall, TStep, TWall, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] DoughnutNotEnclosingMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TWall, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TWall, TVoid, },
            { TVoid, TWall, TVoid, TWall, TWall, TWall, TWall, TVoid, TWall, TVoid, },
            { TVoid, TWall, TVoid, TWall, TStep, TTile, TWall, TVoid, TWall, TVoid, },
            { TVoid, TWall, TVoid, TWall, TTile, TTile, TWall, TVoid, TWall, TVoid, },
            { TVoid, TWall, TVoid, TWall, TVoid, TWall, TWall, TVoid, TWall, TVoid, },
            { TVoid, TWall, TVoid, TWall, TVoid, TWall, TVoid, TVoid, TWall, TVoid, },
            { TVoid, TWall, TWall, TWall, TVoid, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        #endregion
        #endregion

        /// <summary>
        /// Entry point for the program.
        /// </summary>
        public static void Main()
        {
            /*
            var region = new MapRegion();
            Console.WriteLine(region);
            Console.WriteLine($"Item range = {All.ItemIDs}");
            */

            #region Finding Valid Rooms
            var
            collection = RoomCollection.CreateFromSubregion(OneMinimalRoomMap);
            Console.WriteLine($"01: {1 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(OneRoomCentralPillarMap);
            Console.WriteLine($"02: {1 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(OneRoomCentralVoidMap);
            Console.WriteLine($"03: {1 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(OneRoomCentralWellMap);
            Console.WriteLine($"04: {1 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(OneRoomCornerLakeMap);
            Console.WriteLine($"05: {1 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(OneRoomCrossMap);
            Console.WriteLine($"06: {1 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(OneRoomDonoughtShapeMap);
            Console.WriteLine($"07: {1 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(OneRoomExtrusionMap);
            Console.WriteLine($"08: {1 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(OneRoomInaccessibleFloorMap);
            Console.WriteLine($"09: {1 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(OneRoomInnerMoatMap);
            Console.WriteLine($"10: {1 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(OneRoomIntrusionMap);
            Console.WriteLine($"11: {1 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(OneRoomThickWallsMap);
            Console.WriteLine($"12: {1 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(OneRoomUShapeMap);
            Console.WriteLine($"13: {1 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(OneSimpleRoomMap);
            Console.WriteLine($"14: {1 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(TwoJoinedRoomsMap);
            Console.WriteLine($"15: {2 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(TwoSimpleRoomsMap);
            Console.WriteLine($"16: {2 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(SixSimpleRoomsMap);
            Console.WriteLine($"17: {6 == collection.Count}");
            #endregion

            #region Not Finding Invalid Rooms
            collection = RoomCollection.CreateFromSubregion(AllFloorMap);
            Console.WriteLine($"18: {0 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(AllVoidMap);
            Console.WriteLine($"19: {0 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(AllWallsMap);
            Console.WriteLine($"20: {0 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(BlockedEntryMap);
            Console.WriteLine($"21: {0 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(DisconectedEntryMap);
            Console.WriteLine($"22: {0 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(DisconectedFloorMap);
            Console.WriteLine($"23: {0 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(FloodedDoorMap);
            Console.WriteLine($"24: {0 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(FloodedMap);
            Console.WriteLine($"25: {0 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(IncompletePerimeterMap);
            Console.WriteLine($"26: {0 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(IslandStepMap);
            Console.WriteLine($"27: {0 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(MissingWallMap);
            Console.WriteLine($"28: {0 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(MoatInsteadOfWallsMap);
            Console.WriteLine($"30: {0 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(NoDoorMap);
            Console.WriteLine($"31: {0 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(NoFloorMap);
            Console.WriteLine($"32: {0 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(NoWallsMap);
            Console.WriteLine($"33: {0 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(RoomTooSmallMap);
            Console.WriteLine($"34: {0 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(WrongEntryMap);
            Console.WriteLine($"35: {0 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(MoatWallMap);
            Console.WriteLine($"36: {0 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(PerforatedWallMap);
            Console.WriteLine($"37: {0 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(InvertedMap);
            Console.WriteLine($"38: {0 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(IncompleteMap);
            Console.WriteLine($"39: {0 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(LoopNotEnclosingMap);
            Console.WriteLine($"40: {0 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(InaccessibleExitMap);
            Console.WriteLine($"41: {0 == collection.Count}");

            collection = RoomCollection.CreateFromSubregion(DoughnutNotEnclosingMap);
            Console.WriteLine($"42: {0 == collection.Count}");
            #endregion
        }
    }
}
