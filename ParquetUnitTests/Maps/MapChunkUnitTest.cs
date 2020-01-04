using System;
using System.Reflection;
using ParquetClassLibrary;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Utilities;
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
            Assert.Equal(0, new MapChunk(EntityID.None, "Throwaway Chunk").Revision);
        }
        #endregion

        #region Parquets Replacement
        [Fact]
        public void TrySetFloorFailsOnInvalidPositionTest()
        {
            var parquetID = TestEntities.TestFloor.ID;

            var result = TestEntities.TestMapChunk.TrySetFloorDefinition(parquetID, invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFloorSucceedsOnDefaultParquetAndPositionTest()
        {
            var parquetID = TestEntities.TestFloor.ID;

            var result = TestEntities.TestMapChunk.TrySetFloorDefinition(parquetID, Vector2D.Zero);

            Assert.True(result);
        }

        [Fact]
        public void TrySetBlockFailsOnInvalidPositionTest()
        {
            var chunk = new MapChunk(EntityID.None, "Local Chunk");
            var parquetID = TestEntities.TestBlock.ID;

            var result = chunk.TrySetBlockDefinition(parquetID, invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetBlockSucceedsOnDefaultParquetAndPositionTest()
        {
            var chunk = new MapChunk(EntityID.None, "Local Chunk");
            var parquetID = TestEntities.TestBlock.ID;

            var result = chunk.TrySetBlockDefinition(parquetID, Vector2D.Zero);

            Assert.True(result);
        }

        [Fact]
        public void TrySetFurnishingFailsOnInvalidPositionTest()
        {
            var chunk = new MapChunk(EntityID.None, "Local Chunk");
            var parquetID = TestEntities.TestFurnishing.ID;

            var result = chunk.TrySetFurnishingDefinition(parquetID, invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFurnishingSucceedsOnDefaultParquetAndPositionTest()
        {
            var chunk = new MapChunk(EntityID.None, "Local Chunk");
            var parquetID = TestEntities.TestFurnishing.ID;

            var result = chunk.TrySetFurnishingDefinition(parquetID, Vector2D.Zero);

            Assert.True(result);
        }

        [Fact]
        public void TrySetCollectibleFailsOnInvalidPositionTest()
        {
            var chunk = new MapChunk(EntityID.None, "Local Chunk");
            var parquetID = TestEntities.TestCollectible.ID;

            var result = chunk.TrySetCollectibleDefinition(parquetID, invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetCollectibleSucceedsOnDefaultParquetAndPositionTest()
        {
            var chunk = new MapChunk(EntityID.None, "Local Chunk");
            var parquetID = TestEntities.TestCollectible.ID;

            var result = chunk.TrySetCollectibleDefinition(parquetID, Vector2D.Zero);

            Assert.True(result);
        }
        #endregion

        #region Special Locations
        [Fact]
        public void TrySetExitPointSucceedsOnValidPositionTest()
        {
            var chunk = new MapChunk(EntityID.None, "Local Chunk");
            var point = new ExitPoint(Vector2D.Zero, TestEntities.TestMapRegion.ID);

            var result = chunk.TrySetExitPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveExitPointFailsOnInvalidPositionTest()
        {
            var chunk = new MapChunk(EntityID.None, "Local Chunk");
            var point = new ExitPoint(invalidPosition, TestEntities.TestMapRegion.ID);

            var result = chunk.TryRemoveExitPoint(point);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveExitPointFailsOnExitPointMissingTest()
        {
            var chunk = new MapChunk(EntityID.None, "Local Chunk");
            var point = new ExitPoint(Vector2D.Zero, TestEntities.TestMapRegion.ID);

            var result = chunk.TryRemoveExitPoint(point);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveExitPointSucceedsOnExitPointExistsTest()
        {
            var chunk = new MapChunk(EntityID.None, "Local Chunk");
            var point = new ExitPoint(Vector2D.Zero, TestEntities.TestMapRegion.ID);
            chunk.TrySetExitPoint(point);

            var result = chunk.TryRemoveExitPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void GetExitsReturnsNullsOnInvalidPositionTest()
        {
            var chunk = new MapChunk(EntityID.None, "Local Chunk");

            var specialData = chunk.GetExitsAtPosition(invalidPosition);

            Assert.Empty(specialData);
        }
        #endregion

        #region State Queries
        [Fact]
        public void GetDefinitionReturnsNoneOnInvalidPositionTest()
        {
            void TestCode()
            {
                var _ = TestEntities.TestMapChunk.GetDefinitionAtPosition(invalidPosition);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }

        [Fact]
        public void GetDefinitionReturnsNoneOnEmptyMapTest()
        {
            var chunk = new MapChunk(EntityID.None, "Local Chunk");

            var result = chunk.GetDefinitionAtPosition(Vector2D.Zero);

            Assert.Equal(EntityID.None, result.Floor);
            Assert.Equal(EntityID.None, result.Block);
            Assert.Equal(EntityID.None, result.Furnishing);
            Assert.Equal(EntityID.None, result.Collectible);
        }
        #endregion

        #region Subregions
        [Fact]
        public void GetSubregionThrowsOnInvalidUpperLeftTest()
        {
            var invalidUpperLeft = invalidPosition;
            var validLowerRight = new Vector2D(TestEntities.TestMapChunk.DimensionsInParquets.X - 1,
                                               TestEntities.TestMapChunk.DimensionsInParquets.Y - 1);

            void InvalidSubregion()
            {
                var _ = TestEntities.TestMapChunk.GetSubregion(invalidUpperLeft, validLowerRight);
            }

            Assert.Throws<ArgumentOutOfRangeException>(InvalidSubregion);
        }

        [Fact]
        public void GetSubregionThrowsOnInvalidLowerRightTest()
        {
            var validUpperLeft = Vector2D.Zero;
            var invalidLowerRight = TestEntities.TestMapChunk.DimensionsInParquets;

            void InvalidSubregion()
            {
                var _ = TestEntities.TestMapChunk.GetSubregion(validUpperLeft, invalidLowerRight);
            }

            Assert.Throws<ArgumentOutOfRangeException>(InvalidSubregion);
        }

        [Fact]
        public void GetSubregionThrowsOnInvalidOrderingTest()
        {
            var validUpperLeft = Vector2D.Zero;
            var validLowerRight = new Vector2D(TestEntities.TestMapChunk.DimensionsInParquets.X - 1,
                                               TestEntities.TestMapChunk.DimensionsInParquets.Y - 1);

            void InvalidSubregion()
            {
                var _ = TestEntities.TestMapChunk.GetSubregion(validLowerRight, validUpperLeft);
            }

            Assert.Throws<ArgumentException>(InvalidSubregion);
        }

        [Fact]
        public void GetSubregionMatchesPattern()
        {
            var originalChunk = typeof(MapChunk)
                                .GetProperty("ParquetDefintion", BindingFlags.NonPublic | BindingFlags.Instance)
                                ?.GetValue(TestEntities.TestMapChunk) as ParquetStackGrid;
            var validUpperLeft = new Vector2D(1, 4);
            var validLowerRight = new Vector2D(10, 14);

            var subregion = TestEntities.TestMapChunk.GetSubregion();

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
                                .GetProperty("ParquetDefintion", BindingFlags.NonPublic | BindingFlags.Instance)
                                ?.GetValue(TestEntities.TestMapChunk) as ParquetStackGrid;

            var subregion = TestEntities.TestMapChunk.GetSubregion();

            for (var x = 0; x < TestEntities.TestMapChunk.DimensionsInParquets.X; x++)
            {
                for (var y = 0; y < TestEntities.TestMapChunk.DimensionsInParquets.Y; y++)
                {
                    Assert.Equal(originalChunk[y, x], subregion[y, x]);
                }
            }
        }
        #endregion
    }
}