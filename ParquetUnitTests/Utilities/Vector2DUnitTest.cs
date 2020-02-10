using System;
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
        [InlineData(-4096, -4096)]
        [InlineData(-1, 1)]
        [InlineData(0, 0)]
        [InlineData(1, -1)]
        [InlineData(4096, 4096)]
        public void NewVectorTest(int inX, int inY)
        {
            var testVector = new Vector2D(inX, inY);
            var magnitude = Convert.ToInt32(Math.Floor(Math.Sqrt(inX * inX + inY * inY)));

            Assert.Equal(inX, testVector.X);
            Assert.Equal(inY, testVector.Y);
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
