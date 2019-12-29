using System;
using System.Reflection;
using ParquetClassLibrary;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Utilities;
using Xunit;

namespace ParquetUnitTests.Map
{
    public class MapChunkUnitTest
    {
        #region Values for Tests
        private static readonly Vector2D invalidPosition = new Vector2D(-1, -1);
        private static readonly MapChunk defaultChunk = new MapChunk().FillTestPattern();
        #endregion

        #region Initialization
        [Fact]
        public void NewDefaultMapChunkTest()
        {
            Assert.Equal(0, defaultChunk.Revision);
        }
        #endregion

        #region Parquets Replacement
        [Fact]
        public void TrySetFloorFailsOnInvalidPositionTest()
        {
            var chunk = new MapChunk();
            var parquetID = TestEntities.TestFloor.ID;

            var result = chunk.TrySetFloorDefinition(parquetID, invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFloorSucceedsOnDefaultParquetAndPositionTest()
        {
            var chunk = new MapChunk();
            var parquetID = TestEntities.TestFloor.ID;

            var result = chunk.TrySetFloorDefinition(parquetID, Vector2D.Zero);

            Assert.True(result);
        }

        [Fact]
        public void TrySetBlockFailsOnInvalidPositionTest()
        {
            var chunk = new MapChunk();
            var parquetID = TestEntities.TestBlock.ID;

            var result = chunk.TrySetBlockDefinition(parquetID, invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetBlockSucceedsOnDefaultParquetAndPositionTest()
        {
            var chunk = new MapChunk();
            var parquetID = TestEntities.TestBlock.ID;

            var result = chunk.TrySetBlockDefinition(parquetID, Vector2D.Zero);

            Assert.True(result);
        }

        [Fact]
        public void TrySetFurnishingFailsOnInvalidPositionTest()
        {
            var chunk = new MapChunk();
            var parquetID = TestEntities.TestFurnishing.ID;

            var result = chunk.TrySetFurnishingDefinition(parquetID, invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFurnishingSucceedsOnDefaultParquetAndPositionTest()
        {
            var chunk = new MapChunk();
            var parquetID = TestEntities.TestFurnishing.ID;

            var result = chunk.TrySetFurnishingDefinition(parquetID, Vector2D.Zero);

            Assert.True(result);
        }

        [Fact]
        public void TrySetCollectibleFailsOnInvalidPositionTest()
        {
            var chunk = new MapChunk();
            var parquetID = TestEntities.TestCollectible.ID;

            var result = chunk.TrySetCollectibleDefinition(parquetID, invalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetCollectibleSucceedsOnDefaultParquetAndPositionTest()
        {
            var chunk = new MapChunk();
            var parquetID = TestEntities.TestCollectible.ID;

            var result = chunk.TrySetCollectibleDefinition(parquetID, Vector2D.Zero);

            Assert.True(result);
        }
        #endregion

        #region Special Locations
        [Fact]
        public void TrySetExitPointSucceedsOnValidPositionTest()
        {
            var chunk = new MapChunk();
            var point = new ExitPoint(Vector2D.Zero, new Guid());

            var result = chunk.TrySetExitPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveExitPointFailsOnInvalidPositionTest()
        {
            var chunk = new MapChunk();
            var point = new ExitPoint(invalidPosition, new Guid());

            var result = chunk.TryRemoveExitPoint(point);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveExitPointFailsOnExitPointMissingTest()
        {
            var chunk = new MapChunk();
            var point = new ExitPoint(Vector2D.Zero, new Guid());

            var result = chunk.TryRemoveExitPoint(point);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveExitPointSucceedsOnExitPointExistsTest()
        {
            var chunk = new MapChunk();
            var point = new ExitPoint(Vector2D.Zero, new Guid());
            chunk.TrySetExitPoint(point);

            var result = chunk.TryRemoveExitPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void GetExitsReturnsNullsOnInvalidPositionTest()
        {
            var chunk = new MapChunk();

            var specialData = chunk.GetExitsAtPosition(invalidPosition);

            Assert.Empty(specialData);
        }
        #endregion

        #region State Queries
        [Fact]
        public void GetDefinitionReturnsNoneOnInvalidPositionTest()
        {
            var chunk = new MapChunk().FillTestPattern();

            void TestCode()
            {
                var _ = chunk.GetDefinitionAtPosition(invalidPosition);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }

        [Fact]
        public void GetDefinitionReturnsNoneOnEmptyMapTest()
        {
            var chunk = new MapChunk();

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
            var validLowerRight = new Vector2D(defaultChunk.DimensionsInParquets.X - 1,
                                                 defaultChunk.DimensionsInParquets.Y - 1);

            void InvalidSubregion()
            {
                var _ = defaultChunk.GetSubregion(invalidUpperLeft, validLowerRight);
            }

            Assert.Throws<ArgumentOutOfRangeException>(InvalidSubregion);
        }

        [Fact]
        public void GetSubregionThrowsOnInvalidLowerRightTest()
        {
            var validUpperLeft = Vector2D.Zero;
            var invalidLowerRight = defaultChunk.DimensionsInParquets;

            void InvalidSubregion()
            {
                var _ = defaultChunk.GetSubregion(validUpperLeft, invalidLowerRight);
            }

            Assert.Throws<ArgumentOutOfRangeException>(InvalidSubregion);
        }

        [Fact]
        public void GetSubregionThrowsOnInvalidOrderingTest()
        {
            var validUpperLeft = Vector2D.Zero;
            var validLowerRight = new Vector2D(defaultChunk.DimensionsInParquets.X - 1,
                                                 defaultChunk.DimensionsInParquets.Y - 1);

            void InvalidSubregion()
            {
                var _ = defaultChunk.GetSubregion(validLowerRight, validUpperLeft);
            }

            Assert.Throws<ArgumentException>(InvalidSubregion);
        }

        [Fact]
        public void GetSubregionMatchesPattern()
        {
            var originalChunk = typeof(MapChunk)
                                .GetProperty("ParquetDefintion", BindingFlags.NonPublic | BindingFlags.Instance)
                                ?.GetValue(defaultChunk) as ParquetStack2DCollection;
            var validUpperLeft = new Vector2D(1, 4);
            var validLowerRight = new Vector2D(10, 14);

            var subregion = defaultChunk.GetSubregion();

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
                                ?.GetValue(defaultChunk) as ParquetStack2DCollection;

            var subregion = defaultChunk.GetSubregion();

            for (var x = 0; x < defaultChunk.DimensionsInParquets.X; x++)
            {
                for (var y = 0; y < defaultChunk.DimensionsInParquets.Y; y++)
                {
                    Assert.Equal(originalChunk[y, x], subregion[y, x]);
                }
            }
        }
        #endregion
    }
}
