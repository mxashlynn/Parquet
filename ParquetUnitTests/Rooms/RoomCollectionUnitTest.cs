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
        private static readonly ParquetModelPack TVoid = ParquetModelPack.Empty;
        private static readonly ParquetModelPack TWall = new ParquetModelPack(TestModels.TestFloor.ID, TestModels.TestBlock.ID, ModelID.None, ModelID.None);
        private static readonly ParquetModelPack TDoor = new ParquetModelPack(TestModels.TestFloor.ID, TestModels.TestBlock.ID, TestModels.TestFurnishing.ID, ModelID.None);
        private static readonly ParquetModelPack TTile = new ParquetModelPack(TestModels.TestFloor.ID, ModelID.None, ModelID.None, ModelID.None);
        private static readonly ParquetModelPack TStep = new ParquetModelPack(TestModels.TestFloor.ID, ModelID.None, TestModels.TestFurnishing.ID, ModelID.None);
        private static readonly ParquetModelPack TWell = new ParquetModelPack(TestModels.TestFloor.ID, TestModels.TestLiquid.ID, ModelID.None, ModelID.None);

        #region Valid Subregions
        private static readonly ParquetModelPack[,] OneMinimalRoomMap =
        {
            { TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), },
            { TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), },
            { TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), },
            { TWall.DeepClone(), TWall.DeepClone(), TDoor.DeepClone(), TWall.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] TestRoomMap =
        {
            { TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TDoor.DeepClone(), TTile.DeepClone(), },
            { TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] OneSimpleRoomMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TDoor.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] OneRoomCentralPillarMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TDoor.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] OneRoomCentralWellMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TWell.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TDoor.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] OneRoomCentralVoidMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TDoor.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] OneRoomCornerLakeMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TDoor.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] OneRoomIntrusionMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TDoor.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] OneRoomExtrusionMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TDoor.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] OneRoomCrossMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TDoor.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] OneRoomInnerMoatMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWell.DeepClone(), TTile.DeepClone(), TStep.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWell.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] OneRoomInaccessibleFloorMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TStep.DeepClone(), TTile.DeepClone(), TWell.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] OneRoomUShapeMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TDoor.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] OneRoomDonoughtShapeMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TDoor.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] OneRoomThickWallsMap =
        {
            { TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), },
            { TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), },
            { TWall.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), },
            { TWall.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), },
            { TWall.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), },
            { TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TDoor.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), },
            { TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] TwoSimpleRoomsMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TStep.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TDoor.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] TwoJoinedRoomsMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TStep.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TDoor.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] SixSimpleRoomsMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TStep.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TDoor.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TDoor.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TDoor.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TDoor.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TStep.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        #endregion

        #region Invalid Subregions
        private static readonly ParquetModelPack[,] RoomTooSmallMap =
        {
            { TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TWall.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), },
            { TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), },
            { TWall.DeepClone(), TWall.DeepClone(), TDoor.DeepClone(), TWall.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] NoDoorMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] NoFloorMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TDoor.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] FloodedMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TDoor.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] NoWallsMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TStep.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] IncompletePerimeterMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TDoor.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] WrongEntryMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TStep.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] MoatInsteadOfWallsMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWell.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWell.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWell.DeepClone(), TTile.DeepClone(), TStep.DeepClone(), TTile.DeepClone(), TWell.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWell.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWell.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] MissingWallMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TDoor.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] MoatWallMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TDoor.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] PerforatedWallMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TStep.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] InvertedMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TDoor.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] IncompleteMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), },
            { TTile.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), },
            { TTile.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TStep.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), },
            { TTile.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), },
            { TTile.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), },
            { TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] IslandStepMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWell.DeepClone(), TStep.DeepClone(), TWell.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TWell.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };

        private static readonly ParquetModelPack[,] BlockedEntryMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TDoor.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] FloodedDoorMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TWell.DeepClone(), TDoor.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] DisconectedEntryMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TDoor.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] DisconectedFloorMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWell.DeepClone(), TTile.DeepClone(), TWell.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWell.DeepClone(), TTile.DeepClone(), TWell.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TDoor.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] AllFloorMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] AllWallsMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TDoor.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TDoor.DeepClone(), TWall.DeepClone(), TDoor.DeepClone(), TWall.DeepClone(), TDoor.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TDoor.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] AllVoidMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] LoopNotEnclosingMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TDoor.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TWell.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWell.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] InaccessibleExitMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TStep.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] DoughnutNotEnclosingMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TStep.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] DoorUsedAsStepMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TDoor.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        private static readonly ParquetModelPack[,] StepUsedAsDoorMap =
        {
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TTile.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TStep.DeepClone(), TWall.DeepClone(), TWall.DeepClone(), TVoid.DeepClone(), },
            { TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), TVoid.DeepClone(), },
        };
        #endregion

        private static readonly IReadOnlyCollection<Room> TestCollection = new ParquetModelPackGrid(TestRoomMap).CreateRoomCollectionFromSubregion();

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
            var collection = new ParquetModelPackGrid(TwoSimpleRoomsMap).CreateRoomCollectionFromSubregion();

            var walkableArea1 = collection.GetRoomAt(new Vector2D(2, 2)).WalkableArea;
            var walkableArea2 = collection.GetRoomAt(new Vector2D(8, 2)).WalkableArea;

            Assert.False(walkableArea1.SetEquals(walkableArea2));
        }

        [Fact]
        internal void DistinctRoomsHaveDistinctPerimetersTest()
        {
            var collection = new ParquetModelPackGrid(TwoSimpleRoomsMap).CreateRoomCollectionFromSubregion();

            var perimeter1 = collection.GetRoomAt(new Vector2D(2, 2)).Perimeter;
            var perimeter2 = collection.GetRoomAt(new Vector2D(8, 2)).Perimeter;

            Assert.False(perimeter1.SetEquals(perimeter2));
        }
        #endregion

        #region Finding Valid Rooms
        [Fact]
        internal void OneMinimalRoomFoundTest()
        {
            var collection = new ParquetModelPackGrid(OneMinimalRoomMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneSimpleRoomFoundTest()
        {
            var collection = new ParquetModelPackGrid(OneSimpleRoomMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomCentralPillarFoundTest()
        {
            var collection = new ParquetModelPackGrid(OneRoomCentralPillarMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomCentralVoidFoundTest()
        {
            var collection = new ParquetModelPackGrid(OneRoomCentralVoidMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomCentralWellFoundTest()
        {
            var collection = new ParquetModelPackGrid(OneRoomCentralWellMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomCornerLakeFoundTest()
        {
            var collection = new ParquetModelPackGrid(OneRoomCornerLakeMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomCrossFoundTest()
        {
            var collection = new ParquetModelPackGrid(OneRoomCrossMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomDonoughtShapeFoundTest()
        {
            var collection = new ParquetModelPackGrid(OneRoomDonoughtShapeMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomExtrusionFoundTest()
        {
            var collection = new ParquetModelPackGrid(OneRoomExtrusionMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomInaccessibleFloorFoundTest()
        {
            var collection = new ParquetModelPackGrid(OneRoomInaccessibleFloorMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomInnerMoatFoundTest()
        {
            var collection = new ParquetModelPackGrid(OneRoomInnerMoatMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomIntrusionFoundTest()
        {
            var collection = new ParquetModelPackGrid(OneRoomIntrusionMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomThickWalsFoundTest()
        {
            var collection = new ParquetModelPackGrid(OneRoomThickWallsMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void OneRoomUShapeFoundTest()
        {
            var collection = new ParquetModelPackGrid(OneRoomUShapeMap).CreateRoomCollectionFromSubregion();

            Assert.Single(collection);
        }

        [Fact]
        internal void TwoJoinedRoomsFoundTest()
        {
            var collection = new ParquetModelPackGrid(TwoJoinedRoomsMap).CreateRoomCollectionFromSubregion();

            Assert.Equal(2, collection.Count);
        }

        [Fact]
        internal void TwoSimpleRoomsFoundTest()
        {
            var collection = new ParquetModelPackGrid(TwoSimpleRoomsMap).CreateRoomCollectionFromSubregion();

            Assert.Equal(2, collection.Count);
        }

        [Fact]
        internal void SixSimpleRoomsFoundTest()
        {
            var collection = new ParquetModelPackGrid(SixSimpleRoomsMap).CreateRoomCollectionFromSubregion();

            Assert.Equal(6, collection.Count);
        }
        #endregion

        #region Not Finding Invalid Rooms
        [Fact]
        internal void AllFloorYieldsNoRoomsTest()
        {
            var collection = new ParquetModelPackGrid(AllFloorMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void AllVoidYieldsNoRoomsTest()
        {
            var collection = new ParquetModelPackGrid(AllVoidMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void AllWallsYieldsNoRoomsTest()
        {
            var collection = new ParquetModelPackGrid(AllWallsMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void BlockedEntryYieldsNoRoomsTest()
        {
            var collection = new ParquetModelPackGrid(BlockedEntryMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void DisconectedEntryYieldsNoRoomsTest()
        {
            var collection = new ParquetModelPackGrid(DisconectedEntryMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void DisconectedFloorYieldsNoRoomsTest()
        {
            var collection = new ParquetModelPackGrid(DisconectedFloorMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void FloodedDoorYieldsNoRoomsTest()
        {
            var collection = new ParquetModelPackGrid(FloodedDoorMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void FloodedYieldsNoRoomsTest()
        {
            var collection = new ParquetModelPackGrid(FloodedMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void IncompletePerimeterYieldsNoRoomsTest()
        {
            var collection = new ParquetModelPackGrid(IncompletePerimeterMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void IslandStepYieldsNoRoomsTest()
        {
            var collection = new ParquetModelPackGrid(IslandStepMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void MissingWallYieldsNoRoomsTest()
        {
            var collection = new ParquetModelPackGrid(MissingWallMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void MoatInsteadOfWallsYieldsNoRoomsTest()
        {
            var collection = new ParquetModelPackGrid(MoatInsteadOfWallsMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void NoDoorYieldsNoRoomsTest()
        {
            var collection = new ParquetModelPackGrid(NoDoorMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void NoFloorYieldsNoRoomsTest()
        {
            var collection = new ParquetModelPackGrid(NoFloorMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void NoWallsYieldsNoRoomsTest()
        {
            var collection = new ParquetModelPackGrid(NoWallsMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void RoomTooSmallYieldsNoRoomsTest()
        {
            var collection = new ParquetModelPackGrid(RoomTooSmallMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void WrongEntryYieldsNoRoomsTest()
        {
            var collection = new ParquetModelPackGrid(WrongEntryMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void MoatWallYieldsNoRoomsTest()
        {
            var collection = new ParquetModelPackGrid(MoatWallMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void PerforatedWallYieldsNoRoomsTest()
        {
            var collection = new ParquetModelPackGrid(PerforatedWallMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void InvertedMapYieldsNoRoomsTest()
        {
            var collection = new ParquetModelPackGrid(InvertedMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void IncompleteMapYieldsNoRoomsTest()
        {
            var collection = new ParquetModelPackGrid(IncompleteMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void LoopNotEnclosingMapYieldsNoRoomsTest()
        {
            var collection = new ParquetModelPackGrid(LoopNotEnclosingMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void InaccessibleExitMapYieldsNoRoomsTest()
        {
            var collection = new ParquetModelPackGrid(InaccessibleExitMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void DoughnutNotEnclosingMapYieldsNoRoomsTest()
        {
            var collection = new ParquetModelPackGrid(DoughnutNotEnclosingMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void DoorUsedAsStepMapYieldsNoRoomsTest()
        {
            var collection = new ParquetModelPackGrid(DoorUsedAsStepMap).CreateRoomCollectionFromSubregion();

            Assert.Empty(collection);
        }

        [Fact]
        internal void StepUsedAsDoorMapYieldsNoRoomsTest()
        {
            var collection = new ParquetModelPackGrid(StepUsedAsDoorMap).CreateRoomCollectionFromSubregion();

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

            Assert.Equal(ExtantRoom, TestCollection.GetRoomAtOrNull(correctPosition));
        }

        [Fact]
        internal void GetRoomAtFailsOnIncorrectPositionTest()
        {
            var incorrectPosition = new Vector2D(0, 4);

            Assert.Null(TestCollection.GetRoomAtOrNull(incorrectPosition));
        }
        #endregion
    }
}
