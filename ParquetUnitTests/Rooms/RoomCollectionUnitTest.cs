using Xunit;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Rooms;
using ParquetClassLibrary;
using System.Collections.Generic;
using ParquetClassLibrary.Utilities;

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
            { TVoid, TVoid, TTile, TVoid, },
        };
        private static readonly ParquetStack[,] TestRoomMap =
        {
            { TWall, TWall, TWall, TWall, TVoid, },
            { TWall, TTile, TTile, TWall, TVoid, },
            { TWall, TTile, TTile, TDoor, TTile, },
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
            { TVoid, TVoid, TVoid, TTile, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] OneRoomCentralPillarMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TWall, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TVoid, TVoid, TTile, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] OneRoomCentralWellMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TWell, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TVoid, TVoid, TTile, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] OneRoomCentralVoidMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TVoid, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TVoid, TVoid, TTile, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] OneRoomCornerLakeMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWell, TWell, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWell, TWell, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TVoid, TVoid, TTile, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] OneRoomIntrusionMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TWall, TWall, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TVoid, TVoid, TTile, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] OneRoomExtrusionMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TVoid, TVoid, TTile, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] OneRoomCrossMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TTile, TWall, TWall, TWall, TWall, TWall, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TWall, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TVoid, TVoid, TTile, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
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
            { TVoid, TVoid, TVoid, TTile, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
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
            { TVoid, TVoid, TVoid, TTile, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] OneRoomThickWallsMap =
        {
            { TWall, TWall, TWall, TWall, TWall, TWall, TWall, TWall, TWall, TWall, },
            { TWall, TWall, TWall, TWall, TWall, TWall, TWall, TWall, TWall, TWall, },
            { TWall, TWall, TTile, TTile, TTile, TWall, TWall, TWall, TWall, TWall, },
            { TWall, TWall, TTile, TTile, TTile, TWall, TWall, TWall, TWall, TWall, },
            { TWall, TWall, TTile, TTile, TTile, TWall, TWall, TWall, TWall, TWall, },
            { TWall, TWall, TWall, TDoor, TWall, TWall, TWall, TWall, TWall, TWall, },
            { TWall, TWall, TWall, TTile, TWall, TWall, TWall, TWall, TWall, TWall, },
        };
        private static readonly ParquetStack[,] TwoSimpleRoomsMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TWall, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TWall, TTile, TStep, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TWall, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TWall, TVoid, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TVoid, TVoid, TTile, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] TwoJoinedRoomsMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TTile, TStep, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TVoid, TVoid, TTile, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] SixSimpleRoomsMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TWall, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TWall, TTile, TStep, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, TWall, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TWall, TVoid, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TVoid, TVoid, TTile, TTile, TTile, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TTile, TWall, TWall, TWall, TWall, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TWall, TTile, TDoor, TTile, TTile, TWall, TVoid, TVoid, },
            { TVoid, TWall, TTile, TTile, TWall, TTile, TWall, TTile, TTile, TWall, TVoid, TVoid, },
            { TVoid, TWall, TWall, TDoor, TWall, TTile, TWall, TWall, TWall, TWall, TVoid, TVoid, },
            { TVoid, TVoid, TVoid, TTile, TTile, TTile, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
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
        // IDEA: If flooded entries become a problem, uncomment this test.
        /*
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
        */
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
        private static readonly ParquetStack[,] DoorUsedAsStepMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TTile, TDoor, TTile, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        private static readonly ParquetStack[,] StepUsedAsDoorMap =
        {
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
            { TVoid, TWall, TWall, TWall, TWall, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TTile, TTile, TTile, TWall, TVoid, },
            { TVoid, TWall, TWall, TStep, TWall, TWall, TVoid, },
            { TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, TVoid, },
        };
        #endregion

        private static readonly RoomCollection TestCollection = RoomCollection.CreateFromSubregion(TestRoomMap);

        private static readonly HashSet<MapSpace> ExtantPerimeter = new HashSet<MapSpace>
        {
            new MapSpace(0, 0, TWall),
            new MapSpace(1, 0, TWall),
            new MapSpace(2, 0, TWall),
            new MapSpace(3, 0, TWall),
            new MapSpace(0, 1, TWall),
            new MapSpace(3, 1, TWall),
            new MapSpace(0, 2, TWall),
            new MapSpace(3, 2, TDoor),
            new MapSpace(0, 3, TWall),
            new MapSpace(1, 3, TWall),
            new MapSpace(2, 3, TWall),
            new MapSpace(3, 3, TWall),
        };
        private static readonly HashSet<MapSpace> ExtantWalkableArea = new HashSet<MapSpace>
        {
            new MapSpace(1, 1, TTile),
            new MapSpace(2, 1, TTile),
            new MapSpace(1, 2, TTile),
            new MapSpace(2, 2, TTile),
        };
        private static readonly Room ExtantRoom = new Room(ExtantWalkableArea, ExtantPerimeter);

        private static readonly HashSet<MapSpace> NonextantPerimeter = new HashSet<MapSpace>
        {
            new MapSpace(10, 10, TWall),
            new MapSpace(11, 10, TWall),
            new MapSpace(12, 10, TWall),
            new MapSpace(13, 10, TWall),
            new MapSpace(10, 11, TWall),
            new MapSpace(13, 11, TWall),
            new MapSpace(10, 12, TWall),
            new MapSpace(13, 12, TDoor),
            new MapSpace(10, 13, TWall),
            new MapSpace(11, 13, TWall),
            new MapSpace(12, 13, TWall),
            new MapSpace(13, 13, TWall),
        };
        private static readonly HashSet<MapSpace> NonextantWalkableArea = new HashSet<MapSpace>
        {
            new MapSpace(11, 11, TTile),
            new MapSpace(12, 11, TTile),
            new MapSpace(11, 12, TTile),
            new MapSpace(12, 12, TTile),
        };
        private static readonly Room NonextantRoom = new Room(NonextantWalkableArea, NonextantPerimeter);
        #endregion

        #region Correctly Constructing Rooms
        [Fact]
        internal void DistinctRoomsHaveDistinctWalkableAreasTest()
        {
            var collection = RoomCollection.CreateFromSubregion(TwoSimpleRoomsMap);

            var walkableArea1 = collection.GetRoomAt(new Vector2D(2, 2)).WalkableArea;
            var walkableArea2 = collection.GetRoomAt(new Vector2D(8, 2)).WalkableArea;

            Assert.False(walkableArea1.SetEquals(walkableArea2));
        }

        [Fact]
        internal void DistinctRoomsHaveDistinctPerimetersTest()
        {
            var collection = RoomCollection.CreateFromSubregion(TwoSimpleRoomsMap);

            var perimeter1 = collection.GetRoomAt(new Vector2D(2, 2)).Perimeter;
            var perimeter2 = collection.GetRoomAt(new Vector2D(8, 2)).Perimeter;

            Assert.False(perimeter1.SetEquals(perimeter2));
        }
        #endregion

        #region Finding Valid Rooms
        [Fact]
        internal void OneMinimalRoomFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(OneMinimalRoomMap);

            Assert.Single(collection);
        }

        [Fact]
        internal void OneSimpleRoomFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(OneSimpleRoomMap);

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomCentralPillarFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(OneRoomCentralPillarMap);

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomCentralVoidFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(OneRoomCentralVoidMap);

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomCentralWellFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(OneRoomCentralWellMap);

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomCornerLakeFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(OneRoomCornerLakeMap);

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomCrossFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(OneRoomCrossMap);

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomDonoughtShapeFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(OneRoomDonoughtShapeMap);

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomExtrusionFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(OneRoomExtrusionMap);

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomInaccessibleFloorFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(OneRoomInaccessibleFloorMap);

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomInnerMoatFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(OneRoomInnerMoatMap);

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomIntrusionFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(OneRoomIntrusionMap);

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomThickWalsFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(OneRoomThickWallsMap);

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomUShapeFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(OneRoomUShapeMap);

            Assert.Single(collection);
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

            Assert.Empty(collection);
        }

        [Fact]
        internal void AllVoidYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(AllVoidMap);

            Assert.Empty(collection);
        }

        [Fact]
        internal void AllWallsYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(AllWallsMap);

            Assert.Empty(collection);
        }

        [Fact]
        internal void BlockedEntryYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(BlockedEntryMap);

            Assert.Empty(collection);
        }

        [Fact]
        internal void DisconectedEntryYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(DisconectedEntryMap);

            Assert.Empty(collection);
        }

        [Fact]
        internal void DisconectedFloorYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(DisconectedFloorMap);

            Assert.Empty(collection);
        }

        [Fact]
        internal void FloodedDoorYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(FloodedDoorMap);

            Assert.Empty(collection);
        }

        [Fact]
        internal void FloodedYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(FloodedMap);

            Assert.Empty(collection);
        }

        // IDEA If flooded entries become a problem, uncomment this test.
        /*
        [Fact]
        internal void FloodedStepYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(FloodedStepMap);

            Assert.Equal(0, collection.Count);
        }
        */

        [Fact]
        internal void IncompletePerimeterYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(IncompletePerimeterMap);

            Assert.Empty(collection);
        }

        [Fact]
        internal void IslandStepYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(IslandStepMap);

            Assert.Empty(collection);
        }

        [Fact]
        internal void MissingWallYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(MissingWallMap);

            Assert.Empty(collection);
        }

        [Fact]
        internal void MoatInsteadOfWallsYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(MoatInsteadOfWallsMap);

            Assert.Empty(collection);
        }

        [Fact]
        internal void NoDoorYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(NoDoorMap);

            Assert.Empty(collection);
        }

        [Fact]
        internal void NoFloorYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(NoFloorMap);

            Assert.Empty(collection);
        }

        [Fact]
        internal void NoWallsYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(NoWallsMap);

            Assert.Empty(collection);
        }

        [Fact]
        internal void RoomTooSmallYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(RoomTooSmallMap);

            Assert.Empty(collection);
        }

        [Fact]
        internal void WrongEntryYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(WrongEntryMap);

            Assert.Empty(collection);
        }

        [Fact]
        internal void MoatWallYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(MoatWallMap);

            Assert.Empty(collection);
        }

        [Fact]
        internal void PerforatedWallYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(PerforatedWallMap);

            Assert.Empty(collection);
        }

        [Fact]
        internal void InvertedMapYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(InvertedMap);

            Assert.Empty(collection);
        }

        [Fact]
        internal void IncompleteMapYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(IncompleteMap);

            Assert.Empty(collection);
        }

        [Fact]
        internal void LoopNotEnclosingMapYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(LoopNotEnclosingMap);

            Assert.Empty(collection);
        }

        [Fact]
        internal void InaccessibleExitMapYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(InaccessibleExitMap);

            Assert.Empty(collection);
        }

        [Fact]
        internal void DoughnutNotEnclosingMapYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(DoughnutNotEnclosingMap);

            Assert.Empty(collection);
        }

        [Fact]
        internal void DoorUsedAsStepMapYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(DoorUsedAsStepMap);

            Assert.Empty(collection);
        }

        [Fact]
        internal void StepUsedAsDoorMapYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(StepUsedAsDoorMap);

            Assert.Empty(collection);
        }
        #endregion

        #region Individual Room Access
        [Fact]
        internal void ContainsFindsExtantRoomTest()
        {
            Assert.True(TestCollection.Contains(ExtantRoom));
        }

        [Fact]
        internal void ContainsDoesNotFindNonextantRoomTest()
        {
            Assert.False(TestCollection.Contains(NonextantRoom));
        }

        [Fact]
        internal void GetRoomAtSucceedsOnCorrectPositionTest()
        {
            var correctPosition = new Vector2D(1, 1);

            Assert.Equal(ExtantRoom, TestCollection.GetRoomAt(correctPosition));
        }

        [Fact]
        internal void GetRoomAtFailsOnIncorrectPositionTest()
        {
            var incorrectPosition = new Vector2D(0, 4);

            Assert.Null(TestCollection.GetRoomAt(incorrectPosition));
        }
        #endregion

    }
}
