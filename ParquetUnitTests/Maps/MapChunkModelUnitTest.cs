using System;
using System.Reflection;
using ParquetClassLibrary;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Parquets;
using Xunit;

namespace ParquetUnitTests.Maps
{
    public class MapChunkModelUnitTest
    {
        #region Values for Tests
        private static readonly Vector2D invalidPosition = new Vector2D(-1, -1);
        #endregion

        #region Subregions
        [Fact]
        public void GetSubregionThrowsOnInvalidUpperLeftTest()
        {
            var invalidUpperLeft = invalidPosition;
            var validLowerRight = new Vector2D(TestModels.TestMapChunkModel.DimensionsInParquets.X - 1,
                                               TestModels.TestMapChunkModel.DimensionsInParquets.Y - 1);

            void InvalidSubregion()
            {
                var _ = TestModels.TestMapChunkModel.GetSubregion(invalidUpperLeft, validLowerRight);
            }

            Assert.Throws<ArgumentOutOfRangeException>(InvalidSubregion);
        }

        [Fact]
        public void GetSubregionThrowsOnInvalidLowerRightTest()
        {
            var validUpperLeft = Vector2D.Zero;
            var invalidLowerRight = TestModels.TestMapChunkModel.DimensionsInParquets;

            void InvalidSubregion()
            {
                var _ = TestModels.TestMapChunkModel.GetSubregion(validUpperLeft, invalidLowerRight);
            }

            Assert.Throws<ArgumentOutOfRangeException>(InvalidSubregion);
        }

        [Fact]
        public void GetSubregionThrowsOnInvalidOrderingTest()
        {
            var validUpperLeft = Vector2D.Zero;
            var validLowerRight = new Vector2D(TestModels.TestMapChunkModel.DimensionsInParquets.X - 1,
                                               TestModels.TestMapChunkModel.DimensionsInParquets.Y - 1);

            void InvalidSubregion()
            {
                var _ = TestModels.TestMapChunkModel.GetSubregion(validLowerRight, validUpperLeft);
            }

            Assert.Throws<ArgumentException>(InvalidSubregion);
        }

        [Fact]
        public void GetSubregionMatchesPattern()
        {
            var originalChunk = (ParquetStackGrid)(typeof(MapChunkModel)
                                .GetProperty("ParquetDefinitions", BindingFlags.Public | BindingFlags.Instance)
                                ?.GetValue(TestModels.TestMapChunkModel));
            var validUpperLeft = new Vector2D(1, 4);
            var validLowerRight = new Vector2D(10, 14);

            var subregion = TestModels.TestMapChunkModel.GetSubregion();

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
            var originalChunk = (ParquetStackGrid)(typeof(MapChunkModel)
                                .GetProperty("ParquetDefinitions", BindingFlags.Public | BindingFlags.Instance)
                                ?.GetValue(TestModels.TestMapChunkModel));

            var subregion = TestModels.TestMapChunkModel.GetSubregion();

            for (var x = 0; x < TestModels.TestMapChunkModel.DimensionsInParquets.X; x++)
            {
                for (var y = 0; y < TestModels.TestMapChunkModel.DimensionsInParquets.Y; y++)
                {
                    Assert.Equal(originalChunk[y, x], subregion[y, x]);
                }
            }
        }
        #endregion
    }
}
