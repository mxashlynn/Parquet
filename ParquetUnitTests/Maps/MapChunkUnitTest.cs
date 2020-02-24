using System;
using System.Collections.Generic;
using System.Reflection;
using ParquetClassLibrary;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Parquets;
using Xunit;

namespace ParquetUnitTests.Maps
{
    public class MapChunkUnitTest
    {
        #region Values for Tests
        private static readonly Vector2D invalidPosition = new Vector2D(-1, -1);
        #endregion

        #region Initialization
        [Fact]
        public void NewDefaultMapChunkTest()
        {
            Assert.Equal(0, new MapChunk(ModelID.None, "Throwaway Chunk", "", "", AssemblyInfo.SupportedMapDataVersion).Revision);
        }
        #endregion

        #region Parquets Replacement
        [Fact]
        public void TrySetFloorFailsOnInvalidPositionTest()
        {
            var parquetID = TestModels.TestFloor.ID;

            var result = TestModels.TestMapChunk.TrySetFloorDefinition(parquetID, invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFloorSucceedsOnDefaultParquetAndPositionTest()
        {
            var parquetID = TestModels.TestFloor.ID;

            var result = TestModels.TestMapChunk.TrySetFloorDefinition(parquetID, Vector2D.Zero);

            Assert.True(result);
        }

        [Fact]
        public void TrySetBlockFailsOnInvalidPositionTest()
        {
            var chunk = new MapChunk(ModelID.None, "Local Chunk", "Test", "Test", AssemblyInfo.SupportedMapDataVersion);
            var parquetID = TestModels.TestBlock.ID;

            var result = chunk.TrySetBlockDefinition(parquetID, invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetBlockSucceedsOnDefaultParquetAndPositionTest()
        {
            var chunk = new MapChunk(ModelID.None, "Local Chunk", "Test", "Test", AssemblyInfo.SupportedMapDataVersion);
            var parquetID = TestModels.TestBlock.ID;

            var result = chunk.TrySetBlockDefinition(parquetID, Vector2D.Zero);

            Assert.True(result);
        }

        [Fact]
        public void TrySetFurnishingFailsOnInvalidPositionTest()
        {
            var chunk = new MapChunk(ModelID.None, "Local Chunk", "Test", "Test", AssemblyInfo.SupportedMapDataVersion);
            var parquetID = TestModels.TestFurnishing.ID;

            var result = chunk.TrySetFurnishingDefinition(parquetID, invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFurnishingSucceedsOnDefaultParquetAndPositionTest()
        {
            var chunk = new MapChunk(ModelID.None, "Local Chunk", "Test", "Test", AssemblyInfo.SupportedMapDataVersion);
            var parquetID = TestModels.TestFurnishing.ID;

            var result = chunk.TrySetFurnishingDefinition(parquetID, Vector2D.Zero);

            Assert.True(result);
        }

        [Fact]
        public void TrySetCollectibleFailsOnInvalidPositionTest()
        {
            var chunk = new MapChunk(ModelID.None, "Local Chunk", "Test", "Test", AssemblyInfo.SupportedMapDataVersion);
            var parquetID = TestModels.TestCollectible.ID;

            var result = chunk.TrySetCollectibleDefinition(parquetID, invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetCollectibleSucceedsOnDefaultParquetAndPositionTest()
        {
            var chunk = new MapChunk(ModelID.None, "Local Chunk", "Test", "Test", AssemblyInfo.SupportedMapDataVersion);
            var parquetID = TestModels.TestCollectible.ID;

            var result = chunk.TrySetCollectibleDefinition(parquetID, Vector2D.Zero);

            Assert.True(result);
        }
        #endregion

        #region Special Locations
        [Fact]
        public void TrySetExitPointSucceedsOnValidPositionTest()
        {
            var chunk = new MapChunk(ModelID.None, "Local Chunk", "Test", "Test", AssemblyInfo.SupportedMapDataVersion);
            var point = new ExitPoint(Vector2D.Zero, TestModels.TestMapRegion.ID);

            var result = chunk.TrySetExitPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveExitPointFailsOnInvalidPositionTest()
        {
            var chunk = new MapChunk(ModelID.None, "Local Chunk", "Test", "Test", AssemblyInfo.SupportedMapDataVersion);
            var point = new ExitPoint(invalidPosition, TestModels.TestMapRegion.ID);

            var result = chunk.TryRemoveExitPoint(point);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveExitPointFailsOnExitPointMissingTest()
        {
            var chunk = new MapChunk(ModelID.None, "Local Chunk", "Test", "Test", AssemblyInfo.SupportedMapDataVersion);
            var point = new ExitPoint(Vector2D.Zero, TestModels.TestMapRegion.ID);

            var result = chunk.TryRemoveExitPoint(point);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveExitPointSucceedsOnExitPointExistsTest()
        {
            var chunk = new MapChunk(ModelID.None, "Local Chunk", "Test", "Test", AssemblyInfo.SupportedMapDataVersion);
            var point = new ExitPoint(Vector2D.Zero, TestModels.TestMapRegion.ID);
            chunk.TrySetExitPoint(point);

            var result = chunk.TryRemoveExitPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void GetExitsReturnsNullsOnInvalidPositionTest()
        {
            var chunk = new MapChunk(ModelID.None, "Local Chunk", "Test", "Test", AssemblyInfo.SupportedMapDataVersion);

            IReadOnlyList<ExitPoint> specialData = chunk.GetExitsAtPosition(invalidPosition);

            Assert.Empty(specialData);
        }
        #endregion

        #region State Queries
        [Fact]
        public void GetDefinitionReturnsNoneOnInvalidPositionTest()
        {
            void TestCode()
            {
                var _ = TestModels.TestMapChunk.GetDefinitionAtPosition(invalidPosition);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }

        [Fact]
        public void GetDefinitionReturnsNoneOnEmptyMapTest()
        {
            var chunk = new MapChunk(ModelID.None, "Local Chunk", "Test", "Test", AssemblyInfo.SupportedMapDataVersion);

            ParquetStack result = chunk.GetDefinitionAtPosition(Vector2D.Zero);

            Assert.Equal(ModelID.None, result.Floor);
            Assert.Equal(ModelID.None, result.Block);
            Assert.Equal(ModelID.None, result.Furnishing);
            Assert.Equal(ModelID.None, result.Collectible);
        }
        #endregion

        #region Subregions
        [Fact]
        public void GetSubregionThrowsOnInvalidUpperLeftTest()
        {
            var invalidUpperLeft = invalidPosition;
            var validLowerRight = new Vector2D(TestModels.TestMapChunk.DimensionsInParquets.X - 1,
                                               TestModels.TestMapChunk.DimensionsInParquets.Y - 1);

            void InvalidSubregion()
            {
                var _ = TestModels.TestMapChunk.GetSubregion(invalidUpperLeft, validLowerRight);
            }

            Assert.Throws<ArgumentOutOfRangeException>(InvalidSubregion);
        }

        [Fact]
        public void GetSubregionThrowsOnInvalidLowerRightTest()
        {
            var validUpperLeft = Vector2D.Zero;
            var invalidLowerRight = TestModels.TestMapChunk.DimensionsInParquets;

            void InvalidSubregion()
            {
                var _ = TestModels.TestMapChunk.GetSubregion(validUpperLeft, invalidLowerRight);
            }

            Assert.Throws<ArgumentOutOfRangeException>(InvalidSubregion);
        }

        [Fact]
        public void GetSubregionThrowsOnInvalidOrderingTest()
        {
            var validUpperLeft = Vector2D.Zero;
            var validLowerRight = new Vector2D(TestModels.TestMapChunk.DimensionsInParquets.X - 1,
                                               TestModels.TestMapChunk.DimensionsInParquets.Y - 1);

            void InvalidSubregion()
            {
                var _ = TestModels.TestMapChunk.GetSubregion(validLowerRight, validUpperLeft);
            }

            Assert.Throws<ArgumentException>(InvalidSubregion);
        }

        [Fact]
        public void GetSubregionMatchesPattern()
        {
            var originalChunk = typeof(MapChunk)
                                .GetProperty("ParquetDefinitions", BindingFlags.Public | BindingFlags.Instance)
                                ?.GetValue(TestModels.TestMapChunk) as ParquetStackGrid;
            var validUpperLeft = new Vector2D(1, 4);
            var validLowerRight = new Vector2D(10, 14);

            ParquetStackGrid subregion = TestModels.TestMapChunk.GetSubregion();

            for (var x = validUpperLeft.X; x < validLowerRight.X; x++)
            {
                for (var y = validUpperLeft.Y; y < validLowerRight.Y; y++)
                {
                    Assert.Equal(originalChunk[y, x], subregion[y, x]);
                }
            }
        }

        [Fact]
        public void GetSubregionOnWholeSubregionMatchesPattern()
        {
            var originalChunk = typeof(MapChunk)
                                .GetProperty("ParquetDefinitions", BindingFlags.Public | BindingFlags.Instance)
                                ?.GetValue(TestModels.TestMapChunk) as ParquetStackGrid;

            ParquetStackGrid subregion = TestModels.TestMapChunk.GetSubregion();

            for (var x = 0; x < TestModels.TestMapChunk.DimensionsInParquets.X; x++)
            {
                for (var y = 0; y < TestModels.TestMapChunk.DimensionsInParquets.Y; y++)
                {
                    Assert.Equal(originalChunk[y, x], subregion[y, x]);
                }
            }
        }
        #endregion
    }
}
