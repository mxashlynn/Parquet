using Xunit;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Rooms;
using ParquetClassLibrary;
using System.Collections.Generic;
using ParquetClassLibrary.Stubs;

namespace ParquetUnitTests.Rooms
{
    public class RoomCollectionUnitTest
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
            { TWall, TTile, TTile, TWall, TVoid, },
            { TWall, TWall, TDoor, TWall, TVoid, },
        };
        private const int TestWidth = 10;
        private const int TestHeight = 7;
        private static readonly ParquetStack[,] OneSimpleRoomMap = new ParquetStack[TestHeight, TestWidth]
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
            { TVoid, TVoid, TWall, TStep, TWell, TWell, TTile, TWall, TVoid, TVoid, },
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
        private static readonly ParquetStack[,] FloodedStepMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TWall, TWell, TWell, TTile, TWall, TVoid, },
            { TVoid, TWall, TWell, FStep, TTile, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, },
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
        #endregion

        private static readonly RoomCollection TestCollection = RoomCollection.CreateFromSubregion(TestRoomMap);

        private static readonly HashSet<Space> ExistantPerimeter = new HashSet<Space>
        {
            new Space(0, 0, TWall),
            new Space(1, 0, TWall),
            new Space(2, 0, TWall),
            new Space(3, 0, TWall),
            new Space(0, 1, TWall),
            new Space(3, 1, TWall),
            new Space(0, 2, TWall),
            new Space(3, 2, TDoor),
            new Space(0, 3, TWall),
            new Space(1, 3, TWall),
            new Space(2, 3, TWall),
            new Space(3, 3, TWall),
        };
        private static readonly HashSet<Space> ExistantWalkableArea = new HashSet<Space>
        {
            new Space(1, 1, TTile),
            new Space(2, 1, TTile),
            new Space(1, 2, TTile),
            new Space(2, 2, TTile),
        };
        private static readonly Room ExistantRoom = new Room(ExistantWalkableArea, ExistantPerimeter);

        private static readonly HashSet<Space> NonexistantPerimeter = new HashSet<Space>
        {
            new Space(10, 10, TWall),
            new Space(11, 10, TWall),
            new Space(12, 10, TWall),
            new Space(13, 10, TWall),
            new Space(10, 11, TWall),
            new Space(13, 11, TWall),
            new Space(10, 12, TWall),
            new Space(13, 12, TDoor),
            new Space(10, 13, TWall),
            new Space(11, 13, TWall),
            new Space(12, 13, TWall),
            new Space(13, 13, TWall),
        };
        private static readonly HashSet<Space> NonexistantWalkableArea = new HashSet<Space>
        {
            new Space(11, 11, TTile),
            new Space(12, 11, TTile),
            new Space(11, 12, TTile),
            new Space(12, 12, TTile),
        };
        private static readonly Room NonexistantRoom = new Room(NonexistantWalkableArea, NonexistantPerimeter);
        #endregion

        #region Finding Valid Rooms
        [Fact]
        internal void OneMinimalRoomFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(OneMinimalRoomMap);

            Assert.Equal(1, collection.Count);
        }

        [Fact]
        internal void OneRoomCentralPillarFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(OneRoomCentralPillarMap);

            Assert.Equal(1, collection.Count);
        }

        [Fact]
        internal void OneRoomCentralVoidFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(OneRoomCentralVoidMap);

            Assert.Equal(1, collection.Count);
        }

        [Fact]
        internal void OneRoomCentralWellFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(OneRoomCentralWellMap);

            Assert.Equal(1, collection.Count);
        }

        [Fact]
        internal void OneRoomCornerLakeFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(OneRoomCornerLakeMap);

            Assert.Equal(1, collection.Count);
        }

        [Fact]
        internal void OneRoomCrossFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(OneRoomCrossMap);

            Assert.Equal(1, collection.Count);
        }

        [Fact]
        internal void OneRoomDonoughtShapeFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(OneRoomDonoughtShapeMap);

            Assert.Equal(1, collection.Count);
        }

        [Fact]
        internal void OneRoomExtrusionFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(OneRoomExtrusionMap);

            Assert.Equal(1, collection.Count);
        }

        [Fact]
        internal void OneRoomInaccessibleFloorFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(OneRoomInaccessibleFloorMap);

            Assert.Equal(1, collection.Count);
        }

        [Fact]
        internal void OneRoomInnerMoatFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(OneRoomInnerMoatMap);

            Assert.Equal(1, collection.Count);
        }

        [Fact]
        internal void OneRoomIntrusionFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(OneRoomIntrusionMap);

            Assert.Equal(1, collection.Count);
        }

        [Fact]
        internal void OneRoomThickWalsFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(OneRoomThickWallsMap);

            Assert.Equal(1, collection.Count);
        }

        [Fact]
        internal void OneRoomUShapeFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(OneRoomUShapeMap);

            Assert.Equal(1, collection.Count);
        }

        [Fact]
        internal void OneSimpleRoomFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(OneSimpleRoomMap);

            Assert.Equal(1, collection.Count);
        }

        [Fact]
        internal void TwoJoinedRoomsFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(TwoJoinedRoomsMap);

            Assert.Equal(2, collection.Count);
        }

        [Fact]
        internal void TwoSimpleRoomsFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(TwoSimpleRoomsMap);

            Assert.Equal(2, collection.Count);
        }

        [Fact]
        internal void SixSimpleRoomsFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(SixSimpleRoomsMap);

            Assert.Equal(6, collection.Count);
        }
        #endregion

        #region Not Finding Invalid Rooms
        [Fact]
        internal void AllFloorYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(AllFloorMap);

            Assert.Equal(0, collection.Count);
        }

        [Fact]
        internal void AllVoidYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(AllVoidMap);

            Assert.Equal(0, collection.Count);
        }

        [Fact]
        internal void AllWallsYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(AllWallsMap);

            Assert.Equal(0, collection.Count);
        }

        [Fact]
        internal void BlockedEntryYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(BlockedEntryMap);

            Assert.Equal(0, collection.Count);
        }

        [Fact]
        internal void DisconectedEntryYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(DisconectedEntryMap);

            Assert.Equal(0, collection.Count);
        }

        [Fact]
        internal void DisconectedFloorYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(DisconectedFloorMap);

            Assert.Equal(0, collection.Count);
        }

        [Fact]
        internal void FloodedDoorYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(FloodedDoorMap);

            Assert.Equal(0, collection.Count);
        }

        [Fact]
        internal void FloodedYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(FloodedMap);

            Assert.Equal(0, collection.Count);
        }

        [Fact]
        internal void FloodedStepYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(FloodedStepMap);

            Assert.Equal(0, collection.Count);
        }

        [Fact]
        internal void IncompletePerimeterYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(IncompletePerimeterMap);

            Assert.Equal(0, collection.Count);
        }

        [Fact]
        internal void IslandStepYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(IslandStepMap);

            Assert.Equal(0, collection.Count);
        }

        [Fact]
        internal void MissingWallYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(MissingWallMap);

            Assert.Equal(0, collection.Count);
        }

        [Fact]
        internal void MoatInsteadOfWallsYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(MoatInsteadOfWallsMap);

            Assert.Equal(0, collection.Count);
        }

        [Fact]
        internal void NoDoorYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(NoDoorMap);

            Assert.Equal(0, collection.Count);
        }

        [Fact]
        internal void NoFloorYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(NoFloorMap);

            Assert.Equal(0, collection.Count);
        }

        [Fact]
        internal void NoWallsYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(NoWallsMap);

            Assert.Equal(0, collection.Count);
        }

        [Fact]
        internal void RoomTooSmallYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(RoomTooSmallMap);

            Assert.Equal(0, collection.Count);
        }

        [Fact]
        internal void WrongEntryYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(WrongEntryMap);

            Assert.Equal(0, collection.Count);
        }

        [Fact]
        internal void MoatWallYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(MoatWallMap);

            Assert.Equal(0, collection.Count);
        }

        [Fact]
        internal void PerforatedWallYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(PerforatedWallMap);

            Assert.Equal(0, collection.Count);
        }

        [Fact]
        internal void InvertedMapYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(InvertedMap);

            Assert.Equal(0, collection.Count);
        }

        [Fact]
        internal void IncompleteMapYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(IncompleteMap);

            Assert.Equal(0, collection.Count);
        }
        #endregion

        #region Individual Room Access
        [Fact]
        internal void ContainsFindsExistantRoomTest()
        {
            Assert.True(TestCollection.Contains(ExistantRoom));
        }

        [Fact]
        internal void ContainsDoesNotFindNonexistantRoomTest()
        {
            Assert.False(TestCollection.Contains(NonexistantRoom));
        }

        [Fact]
        internal void GetRoomAtSucceedsOnCorrectPositionTest()
        {
            var correctPosition = new Vector2Int(1, 1);

            Assert.Equal(ExistantRoom, TestCollection.GetRoomAt(correctPosition));
        }

        [Fact]
        internal void GetRoomAtFailsOnIncorrectPositionTest()
        {
            var incorrectPosition = new Vector2Int(0, 4);

            Assert.Null(TestCollection.GetRoomAt(incorrectPosition));
        }
        #endregion

    }
}
