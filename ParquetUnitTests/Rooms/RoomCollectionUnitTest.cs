using System.Collections.Generic;
using Parquet;
using Parquet.Parquets;
using Parquet.Rooms;
using Xunit;

namespace ParquetUnitTests.Rooms
{
    public class RoomCollectionUnitTest
    {
        #region Test Values
        private static readonly ParquetPack TVoid = ParquetPack.Empty;
        private static readonly ParquetPack TWall = new ParquetPack(TestModels.TestFloor.ID, TestModels.TestBlock.ID, ModelID.None, ModelID.None);
        private static readonly ParquetPack TDoor = new ParquetPack(TestModels.TestFloor.ID, TestModels.TestBlock.ID, TestModels.TestFurnishing.ID, ModelID.None);
        private static readonly ParquetPack TTile = new ParquetPack(TestModels.TestFloor.ID, ModelID.None, ModelID.None, ModelID.None);
        private static readonly ParquetPack TStep = new ParquetPack(TestModels.TestFloor.ID, ModelID.None, TestModels.TestFurnishing.ID, ModelID.None);
        private static readonly ParquetPack TWell = new ParquetPack(TestModels.TestFloor.ID, TestModels.TestLiquid.ID, ModelID.None, ModelID.None);

        #region Valid Subregions
        private static readonly ParquetPack[,] OneMinimalRoomMap =
        {
            { TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), },
            { TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), },
            { TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), },
            { TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TTile.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] TestRoomMap =
        {
            { TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TWall.Clone(), TTile.Clone(), TTile.Clone(), TDoor.Clone(), TTile.Clone(), },
            { TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] OneSimpleRoomMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TTile.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] OneRoomCentralPillarMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TTile.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] OneRoomCentralWellMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWell.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TTile.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] OneRoomCentralVoidMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TVoid.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TTile.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] OneRoomCornerLakeMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWell.Clone(), TWell.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWell.Clone(), TWell.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TTile.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] OneRoomIntrusionMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TTile.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] OneRoomExtrusionMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TTile.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] OneRoomCrossMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TTile.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] OneRoomInnerMoatMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWell.Clone(), TTile.Clone(), TStep.Clone(), TTile.Clone(), TTile.Clone(), TWell.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] OneRoomInaccessibleFloorMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWell.Clone(), TWell.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TWall.Clone(), TStep.Clone(), TTile.Clone(), TWell.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWell.Clone(), TWell.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] OneRoomUShapeMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TTile.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] OneRoomDonoughtShapeMap =
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
        private static readonly ParquetPack[,] OneRoomThickWallsMap =
        {
            { TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), },
            { TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), },
            { TWall.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), },
            { TWall.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), },
            { TWall.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), },
            { TWall.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), },
            { TWall.Clone(), TWall.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), },
        };
        private static readonly ParquetPack[,] TwoSimpleRoomsMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TTile.Clone(), TStep.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TTile.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] TwoJoinedRoomsMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TTile.Clone(), TStep.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TTile.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] SixSimpleRoomsMap =
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
        private static readonly ParquetPack[,] RoomTooSmallMap =
        {
            { TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TWall.Clone(), TTile.Clone(), TWall.Clone(), TWall.Clone(), },
            { TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), },
            { TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), },
        };
        private static readonly ParquetPack[,] NoDoorMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] NoFloorMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] FloodedMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] NoWallsMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TTile.Clone(), TStep.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] IncompletePerimeterMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] WrongEntryMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TStep.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] MoatInsteadOfWallsMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWell.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWell.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWell.Clone(), TTile.Clone(), TStep.Clone(), TTile.Clone(), TWell.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWell.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWell.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] MissingWallMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] MoatWallMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] PerforatedWallMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TStep.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] InvertedMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] IncompleteMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), },
            { TTile.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TTile.Clone(), },
            { TTile.Clone(), TWall.Clone(), TTile.Clone(), TStep.Clone(), TTile.Clone(), TWall.Clone(), TTile.Clone(), },
            { TTile.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TTile.Clone(), },
            { TTile.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TTile.Clone(), },
            { TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), },
        };
        private static readonly ParquetPack[,] IslandStepMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWell.Clone(), TStep.Clone(), TWell.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWell.Clone(), TWell.Clone(), TWell.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };

        private static readonly ParquetPack[,] BlockedEntryMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TDoor.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] FloodedDoorMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWell.Clone(), TDoor.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] DisconectedEntryMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TDoor.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] DisconectedFloorMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWell.Clone(), TTile.Clone(), TWell.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWell.Clone(), TTile.Clone(), TWell.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] AllFloorMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] AllWallsMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TDoor.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TDoor.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TDoor.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] AllVoidMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] LoopNotEnclosingMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TDoor.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TWell.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWell.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] InaccessibleExitMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TWall.Clone(), TStep.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] DoughnutNotEnclosingMap =
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
        private static readonly ParquetPack[,] DoorUsedAsStepMap =
        {
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TDoor.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TTile.Clone(), TTile.Clone(), TTile.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TWall.Clone(), TVoid.Clone(), },
            { TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), TVoid.Clone(), },
        };
        private static readonly ParquetPack[,] StepUsedAsDoorMap =
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

        private static readonly IReadOnlyCollection<Room> TestCollection = new ParquetPackGrid(TestRoomMap).CreateRoomCollectionFromSubregion();

        private static readonly IReadOnlySet<MapSpace> ExtantPerimeter = new HashSet<MapSpace>
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
        private static readonly IReadOnlySet<MapSpace> ExtantWalkableArea = new HashSet<MapSpace>
        {
            new MapSpace(1, 1, TTile, null),
            new MapSpace(2, 1, TTile, null),
            new MapSpace(1, 2, TTile, null),
            new MapSpace(2, 2, TTile, null),
        };
        private static readonly Room ExtantRoom = new Room(ExtantWalkableArea, ExtantPerimeter);

        private static readonly IReadOnlySet<MapSpace> NonextantPerimeter = new HashSet<MapSpace>
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
        private static readonly IReadOnlySet<MapSpace> NonextantWalkableArea = new HashSet<MapSpace>
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
            var collection = new ParquetPackGrid(TwoSimpleRoomsMap).CreateRoomCollectionFromSubregion();

            var walkableArea1 = collection.GetRoomAt(new Vector2D(2, 2)).WalkableArea;
            var walkableArea2 = collection.GetRoomAt(new Vector2D(8, 2)).WalkableArea;

            Assert.False(walkableArea1.SetEquals(walkableArea2));
        }

        [Fact]
        internal void DistinctRoomsHaveDistinctPerimetersTest()
        {
            var collection = new ParquetPackGrid(TwoSimpleRoomsMap).CreateRoomCollectionFromSubregion();

            var perimeter1 = collection.GetRoomAt(new Vector2D(2, 2)).Perimeter;
            var perimeter2 = collection.GetRoomAt(new Vector2D(8, 2)).Perimeter;

            Assert.False(perimeter1.SetEquals(perimeter2));
        }
        #endregion

        #region Finding Valid Rooms
        [Fact]
        internal void OneMinimalRoomFoundTest()
        {
            var collection = new ParquetPackGrid(OneMinimalRoomMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneSimpleRoomFoundTest()
        {
            var collection = new ParquetPackGrid(OneSimpleRoomMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomCentralPillarFoundTest()
        {
            var collection = new ParquetPackGrid(OneRoomCentralPillarMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomCentralVoidFoundTest()
        {
            var collection = new ParquetPackGrid(OneRoomCentralVoidMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomCentralWellFoundTest()
        {
            var collection = new ParquetPackGrid(OneRoomCentralWellMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomCornerLakeFoundTest()
        {
            var collection = new ParquetPackGrid(OneRoomCornerLakeMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomCrossFoundTest()
        {
            var collection = new ParquetPackGrid(OneRoomCrossMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomDonoughtShapeFoundTest()
        {
            var collection = new ParquetPackGrid(OneRoomDonoughtShapeMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomExtrusionFoundTest()
        {
            var collection = new ParquetPackGrid(OneRoomExtrusionMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomInaccessibleFloorFoundTest()
        {
            var collection = new ParquetPackGrid(OneRoomInaccessibleFloorMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomInnerMoatFoundTest()
        {
            var collection = new ParquetPackGrid(OneRoomInnerMoatMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomIntrusionFoundTest()
        {
            var collection = new ParquetPackGrid(OneRoomIntrusionMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomThickWalsFoundTest()
        {
            var collection = new ParquetPackGrid(OneRoomThickWallsMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomUShapeFoundTest()
        {
            var collection = new ParquetPackGrid(OneRoomUShapeMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void TwoJoinedRoomsFoundTest()
        {
            var collection = new ParquetPackGrid(TwoJoinedRoomsMap).CreateRoomCollectionFromSubregion();

            Assert.Equal(2, collection.Count);
        }

        [Fact]
        internal void TwoSimpleRoomsFoundTest()
        {
            var collection = new ParquetPackGrid(TwoSimpleRoomsMap).CreateRoomCollectionFromSubregion();

            Assert.Equal(2, collection.Count);
        }

        [Fact]
        internal void SixSimpleRoomsFoundTest()
        {
            var collection = new ParquetPackGrid(SixSimpleRoomsMap).CreateRoomCollectionFromSubregion();

            Assert.Equal(6, collection.Count);
        }
        #endregion

        #region Not Finding Invalid Rooms
        [Fact]
        internal void AllFloorYieldsNoRoomsTest()
        {
            var collection = new ParquetPackGrid(AllFloorMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void AllVoidYieldsNoRoomsTest()
        {
            var collection = new ParquetPackGrid(AllVoidMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void AllWallsYieldsNoRoomsTest()
        {
            var collection = new ParquetPackGrid(AllWallsMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void BlockedEntryYieldsNoRoomsTest()
        {
            var collection = new ParquetPackGrid(BlockedEntryMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void DisconectedEntryYieldsNoRoomsTest()
        {
            var collection = new ParquetPackGrid(DisconectedEntryMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void DisconectedFloorYieldsNoRoomsTest()
        {
            var collection = new ParquetPackGrid(DisconectedFloorMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void FloodedDoorYieldsNoRoomsTest()
        {
            var collection = new ParquetPackGrid(FloodedDoorMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void FloodedYieldsNoRoomsTest()
        {
            var collection = new ParquetPackGrid(FloodedMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void IncompletePerimeterYieldsNoRoomsTest()
        {
            var collection = new ParquetPackGrid(IncompletePerimeterMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void IslandStepYieldsNoRoomsTest()
        {
            var collection = new ParquetPackGrid(IslandStepMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void MissingWallYieldsNoRoomsTest()
        {
            var collection = new ParquetPackGrid(MissingWallMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void MoatInsteadOfWallsYieldsNoRoomsTest()
        {
            var collection = new ParquetPackGrid(MoatInsteadOfWallsMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void NoDoorYieldsNoRoomsTest()
        {
            var collection = new ParquetPackGrid(NoDoorMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void NoFloorYieldsNoRoomsTest()
        {
            var collection = new ParquetPackGrid(NoFloorMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void NoWallsYieldsNoRoomsTest()
        {
            var collection = new ParquetPackGrid(NoWallsMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void RoomTooSmallYieldsNoRoomsTest()
        {
            var collection = new ParquetPackGrid(RoomTooSmallMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void WrongEntryYieldsNoRoomsTest()
        {
            var collection = new ParquetPackGrid(WrongEntryMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void MoatWallYieldsNoRoomsTest()
        {
            var collection = new ParquetPackGrid(MoatWallMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void PerforatedWallYieldsNoRoomsTest()
        {
            var collection = new ParquetPackGrid(PerforatedWallMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void InvertedMapYieldsNoRoomsTest()
        {
            var collection = new ParquetPackGrid(InvertedMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void IncompleteMapYieldsNoRoomsTest()
        {
            var collection = new ParquetPackGrid(IncompleteMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void LoopNotEnclosingMapYieldsNoRoomsTest()
        {
            var collection = new ParquetPackGrid(LoopNotEnclosingMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void InaccessibleExitMapYieldsNoRoomsTest()
        {
            var collection = new ParquetPackGrid(InaccessibleExitMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void DoughnutNotEnclosingMapYieldsNoRoomsTest()
        {
            var collection = new ParquetPackGrid(DoughnutNotEnclosingMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void DoorUsedAsStepMapYieldsNoRoomsTest()
        {
            var collection = new ParquetPackGrid(DoorUsedAsStepMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void StepUsedAsDoorMapYieldsNoRoomsTest()
        {
            var collection = new ParquetPackGrid(StepUsedAsDoorMap).CreateRoomCollectionFromSubregion();

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
