using System;
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
            Assert.Equal(0, new MapChunk(ModelID.None, "Throwaway Chunk", "", "").Revision);
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

            var subregion = TestModels.TestMapChunk.GetSubregion();

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

            var subregion = TestModels.TestMapChunk.GetSubregion();

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
