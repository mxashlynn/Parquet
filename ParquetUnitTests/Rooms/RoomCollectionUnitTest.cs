using System.Collections.Generic;
using ParquetClassLibrary;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Rooms;
using Xunit;

namespace ParquetUnitTests.Rooms
{
    public class RoomCollectionUnitTest
    {
        #region Test Values
        private static readonly ParquetStack TVoid = ParquetStack.Empty;
        private static readonly ParquetStack TWall = new ParquetStack(TestModels.TestFloor.ID, TestModels.TestBlock.ID, ModelID.None, ModelID.None);
        private static readonly ParquetStack TDoor = new ParquetStack(TestModels.TestFloor.ID, TestModels.TestBlock.ID, TestModels.TestFurnishing.ID, ModelID.None);
        private static readonly ParquetStack TTile = new ParquetStack(TestModels.TestFloor.ID, ModelID.None, ModelID.None, ModelID.None);
        private static readonly ParquetStack TStep = new ParquetStack(TestModels.TestFloor.ID, ModelID.None, TestModels.TestFurnishing.ID, ModelID.None);
        private static readonly ParquetStack TWell = new ParquetStack(TestModels.TestFloor.ID, TestModels.TestLiquid.ID, ModelID.None, ModelID.None);

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

        private static readonly IReadOnlyCollection<Room> TestCollection = new ParquetStackGrid(TestRoomMap).CreateRoomCollectionFromSubregion();

        private static readonly IReadOnlySet<MapSpace> ExtantPerimeter = (IReadOnlySet<MapSpace>)new HashSet<MapSpace>
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
        private static readonly IReadOnlySet<MapSpace> ExtantWalkableArea = (IReadOnlySet<MapSpace>)new HashSet<MapSpace>
        {
            new MapSpace(1, 1, TTile, null),
            new MapSpace(2, 1, TTile, null),
            new MapSpace(1, 2, TTile, null),
            new MapSpace(2, 2, TTile, null),
        };
        private static readonly Room ExtantRoom = new Room(ExtantWalkableArea, ExtantPerimeter);

        private static readonly IReadOnlySet<MapSpace> NonextantPerimeter = (IReadOnlySet<MapSpace>)new HashSet<MapSpace>
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
        private static readonly IReadOnlySet<MapSpace> NonextantWalkableArea = (IReadOnlySet<MapSpace>)new HashSet<MapSpace>
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
            var collection = new ParquetStackGrid(TwoSimpleRoomsMap).CreateRoomCollectionFromSubregion();

            var walkableArea1 = collection.GetRoomAt(new Vector2D(2, 2)).WalkableArea;
            var walkableArea2 = collection.GetRoomAt(new Vector2D(8, 2)).WalkableArea;

            Assert.False(walkableArea1.SetEquals(walkableArea2));
        }

        [Fact]
        internal void DistinctRoomsHaveDistinctPerimetersTest()
        {
            var collection = new ParquetStackGrid(TwoSimpleRoomsMap).CreateRoomCollectionFromSubregion();

            var perimeter1 = collection.GetRoomAt(new Vector2D(2, 2)).Perimeter;
            var perimeter2 = collection.GetRoomAt(new Vector2D(8, 2)).Perimeter;

            Assert.False(perimeter1.SetEquals(perimeter2));
        }
        #endregion

        #region Finding Valid Rooms
        [Fact]
        internal void OneMinimalRoomFoundTest()
        {
            var collection = new ParquetStackGrid(OneMinimalRoomMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneSimpleRoomFoundTest()
        {
            var collection = new ParquetStackGrid(OneSimpleRoomMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomCentralPillarFoundTest()
        {
            var collection = new ParquetStackGrid(OneRoomCentralPillarMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomCentralVoidFoundTest()
        {
            var collection = new ParquetStackGrid(OneRoomCentralVoidMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomCentralWellFoundTest()
        {
            var collection = new ParquetStackGrid(OneRoomCentralWellMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomCornerLakeFoundTest()
        {
            var collection = new ParquetStackGrid(OneRoomCornerLakeMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomCrossFoundTest()
        {
            var collection = new ParquetStackGrid(OneRoomCrossMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomDonoughtShapeFoundTest()
        {
            var collection = new ParquetStackGrid(OneRoomDonoughtShapeMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomExtrusionFoundTest()
        {
            var collection = new ParquetStackGrid(OneRoomExtrusionMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomInaccessibleFloorFoundTest()
        {
            var collection = new ParquetStackGrid(OneRoomInaccessibleFloorMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomInnerMoatFoundTest()
        {
            var collection = new ParquetStackGrid(OneRoomInnerMoatMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomIntrusionFoundTest()
        {
            var collection = new ParquetStackGrid(OneRoomIntrusionMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomThickWalsFoundTest()
        {
            var collection = new ParquetStackGrid(OneRoomThickWallsMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomUShapeFoundTest()
        {
            var collection = new ParquetStackGrid(OneRoomUShapeMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void TwoJoinedRoomsFoundTest()
        {
            var collection = new ParquetStackGrid(TwoJoinedRoomsMap).CreateRoomCollectionFromSubregion();

            Assert.Equal(2, collection.Count);
        }

        [Fact]
        internal void TwoSimpleRoomsFoundTest()
        {
            var collection = new ParquetStackGrid(TwoSimpleRoomsMap).CreateRoomCollectionFromSubregion();

            Assert.Equal(2, collection.Count);
        }

        [Fact]
        internal void SixSimpleRoomsFoundTest()
        {
            var collection = new ParquetStackGrid(SixSimpleRoomsMap).CreateRoomCollectionFromSubregion();

            Assert.Equal(6, collection.Count);
        }
        #endregion

        #region Not Finding Invalid Rooms
        [Fact]
        internal void AllFloorYieldsNoRoomsTest()
        {
            var collection = new ParquetStackGrid(AllFloorMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void AllVoidYieldsNoRoomsTest()
        {
            var collection = new ParquetStackGrid(AllVoidMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void AllWallsYieldsNoRoomsTest()
        {
            var collection = new ParquetStackGrid(AllWallsMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void BlockedEntryYieldsNoRoomsTest()
        {
            var collection = new ParquetStackGrid(BlockedEntryMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void DisconectedEntryYieldsNoRoomsTest()
        {
            var collection = new ParquetStackGrid(DisconectedEntryMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void DisconectedFloorYieldsNoRoomsTest()
        {
            var collection = new ParquetStackGrid(DisconectedFloorMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void FloodedDoorYieldsNoRoomsTest()
        {
            var collection = new ParquetStackGrid(FloodedDoorMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void FloodedYieldsNoRoomsTest()
        {
            var collection = new ParquetStackGrid(FloodedMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void IncompletePerimeterYieldsNoRoomsTest()
        {
            var collection = new ParquetStackGrid(IncompletePerimeterMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void IslandStepYieldsNoRoomsTest()
        {
            var collection = new ParquetStackGrid(IslandStepMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void MissingWallYieldsNoRoomsTest()
        {
            var collection = new ParquetStackGrid(MissingWallMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void MoatInsteadOfWallsYieldsNoRoomsTest()
        {
            var collection = new ParquetStackGrid(MoatInsteadOfWallsMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void NoDoorYieldsNoRoomsTest()
        {
            var collection = new ParquetStackGrid(NoDoorMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void NoFloorYieldsNoRoomsTest()
        {
            var collection = new ParquetStackGrid(NoFloorMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void NoWallsYieldsNoRoomsTest()
        {
            var collection = new ParquetStackGrid(NoWallsMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void RoomTooSmallYieldsNoRoomsTest()
        {
            var collection = new ParquetStackGrid(RoomTooSmallMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void WrongEntryYieldsNoRoomsTest()
        {
            var collection = new ParquetStackGrid(WrongEntryMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void MoatWallYieldsNoRoomsTest()
        {
            var collection = new ParquetStackGrid(MoatWallMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void PerforatedWallYieldsNoRoomsTest()
        {
            var collection = new ParquetStackGrid(PerforatedWallMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void InvertedMapYieldsNoRoomsTest()
        {
            var collection = new ParquetStackGrid(InvertedMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void IncompleteMapYieldsNoRoomsTest()
        {
            var collection = new ParquetStackGrid(IncompleteMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void LoopNotEnclosingMapYieldsNoRoomsTest()
        {
            var collection = new ParquetStackGrid(LoopNotEnclosingMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void InaccessibleExitMapYieldsNoRoomsTest()
        {
            var collection = new ParquetStackGrid(InaccessibleExitMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void DoughnutNotEnclosingMapYieldsNoRoomsTest()
        {
            var collection = new ParquetStackGrid(DoughnutNotEnclosingMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void DoorUsedAsStepMapYieldsNoRoomsTest()
        {
            var collection = new ParquetStackGrid(DoorUsedAsStepMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void StepUsedAsDoorMapYieldsNoRoomsTest()
        {
            var collection = new ParquetStackGrid(StepUsedAsDoorMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }
        #endregion

        #region Individual Room Access
        [Fact]
        internal void ContainsFindsExtantRoomTest()
        {
            Assert.Contains(ExtantRoom, TestCollection);
        }

        [Fact]
        internal void ContainsDoesNotFindNonextantRoomTest()
        {
            Assert.DoesNotContain(NonextantRoom, TestCollection);
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
