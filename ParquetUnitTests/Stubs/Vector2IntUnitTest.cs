using System;
using ParquetClassLibrary.Stubs;
using Xunit;

namespace ParquetUnitTests.Stubs
{
    public class Vector2IntUnitTest
    {
        #region Test Values
        private Vector2Int VectorTwoTwo = new Vector2Int(2, 2);
        private Vector2Int VectorNegativeUnit = new Vector2Int(-1, -1);
        #endregion

        [Fact]
        public void ZeroVectorTest()
        {
            Assert.Equal(0, Vector2Int.Zero.X);
            Assert.Equal(0, Vector2Int.Zero.Y);
            Assert.Equal(0, Vector2Int.Zero.Magnitude);
        }

        [Fact]
        public void UnitVectorTest()
        {
            Assert.Equal(1, Vector2Int.Unit.X);
            Assert.Equal(1, Vector2Int.Unit.Y);
            Assert.Equal(1, Vector2Int.Unit.Magnitude);
        }

        [Theory]
        [InlineData(int.MinValue, int.MinValue)]
        [InlineData(-1, 1)]
        [InlineData(0,  0)]
        [InlineData(1, -1)]
        [InlineData(int.MaxValue, int.MaxValue)]
        public void NewVectorTest(int in_x, int in_y)
        {
            var testVector = new Vector2Int(in_x, in_y);

            Assert.Equal(in_x, testVector.X);
            Assert.Equal(in_y, testVector.Y);
            var magnitude = Convert.ToInt32(Math.Floor(Math.Sqrt(in_x * in_x + in_y * in_y)));
            Assert.Equal(magnitude, testVector.Magnitude);
        }

        [Fact]
        public void VectorSumTest()
        {
            Assert.Equal(VectorTwoTwo, Vector2Int.Unit + Vector2Int.Unit);
            Assert.Equal(Vector2Int.Zero, Vector2Int.Unit + VectorNegativeUnit);
        }

        [Fact]
        public void VectorDifferenceTest()
        {
            Assert.Equal(Vector2Int.Zero, Vector2Int.Unit - Vector2Int.Unit);
            Assert.Equal(Vector2Int.Zero, VectorNegativeUnit - VectorNegativeUnit);
        }

        [Fact]
        public void ScalarMultiplicationTest()
        {
            Assert.Equal(VectorTwoTwo, 2 * Vector2Int.Unit);
            Assert.Equal(Vector2Int.Unit, -1 * VectorNegativeUnit);
        }
    }
}
