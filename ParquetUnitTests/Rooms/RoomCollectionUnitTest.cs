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
        private static readonly ParquetStack TWall = new ParquetStack(TestModels.TestFloor.ID, TestModels.TestBlock.ID, EntityID.None, EntityID.None);
        private static readonly ParquetStack TDoor = new ParquetStack(TestModels.TestFloor.ID, TestModels.TestBlock.ID, TestModels.TestFurnishing.ID, EntityID.None);
        private static readonly ParquetStack TTile = new ParquetStack(TestModels.TestFloor.ID, EntityID.None, EntityID.None, EntityID.None);
        private static readonly ParquetStack TStep = new ParquetStack(TestModels.TestFloor.ID, EntityID.None, TestModels.TestFurnishing.ID, EntityID.None);
        private static readonly ParquetStack TWell = new ParquetStack(TestModels.TestFloor.ID, TestModels.TestLiquid.ID, EntityID.None, EntityID.None);

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

        private static readonly RoomCollection TestCollection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(TestRoomMap));

        private static readonly HashSet<MapSpace> ExtantPerimeter = new HashSet<MapSpace>
        {
            new MapSpace(0, 0, TWall, null),
            new MapSpace(1, 0, TWall, null),
            new MapSpace(2, 0, TWall, null),
            new MapSpace(3, 0, TWall, null),
            new MapSpace(0, 1, TWall, null),
            new MapSpace(3, 1, TWall, null),
            new MapSpace(0, 2, TWall, null),
            new MapSpace(3, 2, TDoor, null),
            new MapSpace(0, 3, TWall, null),
            new MapSpace(1, 3, TWall, null),
            new MapSpace(2, 3, TWall, null),
            new MapSpace(3, 3, TWall, null),
        };
        private static readonly HashSet<MapSpace> ExtantWalkableArea = new HashSet<MapSpace>
        {
            new MapSpace(1, 1, TTile, null),
            new MapSpace(2, 1, TTile, null),
            new MapSpace(1, 2, TTile, null),
            new MapSpace(2, 2, TTile, null),
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

        #region Correctly Constructing Rooms
        [Fact]
        internal void DistinctRoomsHaveDistinctWalkableAreasTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(TwoSimpleRoomsMap));

            var walkableArea1 = collection.GetRoomAt(new Vector2D(2, 2)).WalkableArea;
            var walkableArea2 = collection.GetRoomAt(new Vector2D(8, 2)).WalkableArea;

            Assert.False(walkableArea1.SetEquals(walkableArea2));
        }

        [Fact]
        internal void DistinctRoomsHaveDistinctPerimetersTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(TwoSimpleRoomsMap));

            var perimeter1 = collection.GetRoomAt(new Vector2D(2, 2)).Perimeter;
            var perimeter2 = collection.GetRoomAt(new Vector2D(8, 2)).Perimeter;

            Assert.False(perimeter1.SetEquals(perimeter2));
        }
        #endregion

        #region Finding Valid Rooms
        [Fact]
        internal void OneMinimalRoomFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(OneMinimalRoomMap));

            Assert.Single(collection);
        }

        [Fact]
        internal void OneSimpleRoomFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(OneSimpleRoomMap));

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomCentralPillarFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(OneRoomCentralPillarMap));

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomCentralVoidFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(OneRoomCentralVoidMap));

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomCentralWellFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(OneRoomCentralWellMap));

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomCornerLakeFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(OneRoomCornerLakeMap));

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomCrossFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(OneRoomCrossMap));

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomDonoughtShapeFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(OneRoomDonoughtShapeMap));

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomExtrusionFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(OneRoomExtrusionMap));

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomInaccessibleFloorFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(OneRoomInaccessibleFloorMap));

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomInnerMoatFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(OneRoomInnerMoatMap));

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomIntrusionFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(OneRoomIntrusionMap));

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomThickWalsFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(OneRoomThickWallsMap));

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomUShapeFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(OneRoomUShapeMap));

            Assert.Single(collection);
        }

        [Fact]
        internal void TwoJoinedRoomsFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(TwoJoinedRoomsMap));

            Assert.Equal(2, collection.Count);
        }

        [Fact]
        internal void TwoSimpleRoomsFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(TwoSimpleRoomsMap));

            Assert.Equal(2, collection.Count);
        }

        [Fact]
        internal void SixSimpleRoomsFoundTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(SixSimpleRoomsMap));

            Assert.Equal(6, collection.Count);
        }
        #endregion

        #region Not Finding Invalid Rooms
        [Fact]
        internal void AllFloorYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(AllFloorMap));

            Assert.Empty(collection);
        }

        [Fact]
        internal void AllVoidYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(AllVoidMap));

            Assert.Empty(collection);
        }

        [Fact]
        internal void AllWallsYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(AllWallsMap));

            Assert.Empty(collection);
        }

        [Fact]
        internal void BlockedEntryYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(BlockedEntryMap));

            Assert.Empty(collection);
        }

        [Fact]
        internal void DisconectedEntryYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(DisconectedEntryMap));

            Assert.Empty(collection);
        }

        [Fact]
        internal void DisconectedFloorYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(DisconectedFloorMap));

            Assert.Empty(collection);
        }

        [Fact]
        internal void FloodedDoorYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(FloodedDoorMap));

            Assert.Empty(collection);
        }

        [Fact]
        internal void FloodedYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(FloodedMap));

            Assert.Empty(collection);
        }

        [Fact]
        internal void IncompletePerimeterYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(IncompletePerimeterMap));

            Assert.Empty(collection);
        }

        [Fact]
        internal void IslandStepYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(IslandStepMap));

            Assert.Empty(collection);
        }

        [Fact]
        internal void MissingWallYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(MissingWallMap));

            Assert.Empty(collection);
        }

        [Fact]
        internal void MoatInsteadOfWallsYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(MoatInsteadOfWallsMap));

            Assert.Empty(collection);
        }

        [Fact]
        internal void NoDoorYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(NoDoorMap));

            Assert.Empty(collection);
        }

        [Fact]
        internal void NoFloorYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(NoFloorMap));

            Assert.Empty(collection);
        }

        [Fact]
        internal void NoWallsYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(NoWallsMap));

            Assert.Empty(collection);
        }

        [Fact]
        internal void RoomTooSmallYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(RoomTooSmallMap));

            Assert.Empty(collection);
        }

        [Fact]
        internal void WrongEntryYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(WrongEntryMap));

            Assert.Empty(collection);
        }

        [Fact]
        internal void MoatWallYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(MoatWallMap));

            Assert.Empty(collection);
        }

        [Fact]
        internal void PerforatedWallYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(PerforatedWallMap));

            Assert.Empty(collection);
        }

        [Fact]
        internal void InvertedMapYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(InvertedMap));

            Assert.Empty(collection);
        }

        [Fact]
        internal void IncompleteMapYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(IncompleteMap));

            Assert.Empty(collection);
        }

        [Fact]
        internal void LoopNotEnclosingMapYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(LoopNotEnclosingMap));

            Assert.Empty(collection);
        }

        [Fact]
        internal void InaccessibleExitMapYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(InaccessibleExitMap));

            Assert.Empty(collection);
        }

        [Fact]
        internal void DoughnutNotEnclosingMapYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(DoughnutNotEnclosingMap));

            Assert.Empty(collection);
        }

        [Fact]
        internal void DoorUsedAsStepMapYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(DoorUsedAsStepMap));

            Assert.Empty(collection);
        }

        [Fact]
        internal void StepUsedAsDoorMapYieldsNoRoomsTest()
        {
            var collection = RoomCollection.CreateFromSubregion(new ParquetStackGrid(StepUsedAsDoorMap));

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
