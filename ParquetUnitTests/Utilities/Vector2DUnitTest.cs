using System;
using ParquetClassLibrary.Utilities;
using Xunit;

namespace ParquetUnitTests.Utilities
{
    public class Vector2DUnitTest
    {
        #region Test Values
        private Vector2D VectorTwoTwo = new Vector2D(2, 2);
        private Vector2D VectorNegativeUnit = new Vector2D(-1, -1);
        #endregion

        [Fact]
        public void ZeroVectorTest()
        {
            Assert.Equal(0, Vector2D.Zero.X);
            Assert.Equal(0, Vector2D.Zero.Y);
            Assert.Equal(0, Vector2D.Zero.Magnitude);
        }

        [Fact]
        public void UnitVectorTest()
        {
            Assert.Equal(1, Vector2D.Unit.X);
            Assert.Equal(1, Vector2D.Unit.Y);
            Assert.Equal(1, Vector2D.Unit.Magnitude);
        }

        [Theory]
        [InlineData(int.MinValue, int.MinValue)]
        [InlineData(-1, 1)]
        [InlineData(0,  0)]
        [InlineData(1, -1)]
        [InlineData(int.MaxValue, int.MaxValue)]
        public void NewVectorTest(int in_x, int in_y)
        {
            var testVector = new Vector2D(in_x, in_y);

            Assert.Equal(in_x, testVector.X);
            Assert.Equal(in_y, testVector.Y);
            var magnitude = Convert.ToInt32(Math.Floor(Math.Sqrt(in_x * in_x + in_y * in_y)));
            Assert.Equal(magnitude, testVector.Magnitude);
        }

        [Fact]
        public void VectorSumTest()
        {
            Assert.Equal(VectorTwoTwo, Vector2D.Unit + Vector2D.Unit);
            Assert.Equal(Vector2D.Zero, Vector2D.Unit + VectorNegativeUnit);
        }

        [Fact]
        public void VectorDifferenceTest()
        {
            Assert.Equal(Vector2D.Zero, Vector2D.Unit - Vector2D.Unit);
            Assert.Equal(Vector2D.Zero, VectorNegativeUnit - VectorNegativeUnit);
        }

        [Fact]
        public void ScalarMultiplicationTest()
        {
            Assert.Equal(VectorTwoTwo, 2 * Vector2D.Unit);
            Assert.Equal(Vector2D.Unit, -1 * VectorNegativeUnit);
        }
    }
}
