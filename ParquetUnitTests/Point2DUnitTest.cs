using System;
using Parquet;
using Xunit;

namespace ParquetUnitTests
{
    /// <summary>
    /// Unit tests <see cref="Point2D"/>.
    /// </summary>
    public class Point2DUnitTest
    {
        #region Test Values
        private readonly Point2D PointTwoTwo = new Point2D(2, 2);
        private readonly Point2D PointNegativeUnit = new Point2D(-1, -1);
        #endregion

        [Fact]
        internal void ZeroPointTest()
        {
            Assert.Equal(0, Point2D.Origin.X);
            Assert.Equal(0, Point2D.Origin.Y);
            Assert.Equal(0, Point2D.Origin.Magnitude);
        }

        [Fact]
        internal void UnitPointTest()
        {
            Assert.Equal(1, Point2D.Unit.X);
            Assert.Equal(1, Point2D.Unit.Y);
            Assert.Equal(1, Point2D.Unit.Magnitude);
        }

        [Theory]
        [InlineData(-4096, -4096)]
        [InlineData(-1, 1)]
        [InlineData(0, 0)]
        [InlineData(1, -1)]
        [InlineData(4096, 4096)]
        internal void NewPointTest(int inX, int inY)
        {
            var testPoint = new Point2D(inX, inY);
            var magnitude = Convert.ToInt32(Math.Floor(Math.Sqrt((inX * inX) + (inY * inY))));

            Assert.Equal(inX, testPoint.X);
            Assert.Equal(inY, testPoint.Y);
            Assert.Equal(magnitude, testPoint.Magnitude);
        }

        [Fact]
        internal void PointSumTest()
        {
            Assert.Equal(PointTwoTwo, Point2D.Unit + Point2D.Unit);
            Assert.Equal(Point2D.Origin, Point2D.Unit + PointNegativeUnit);
        }

        [Fact]
        internal void PointDifferenceTest()
        {
            Assert.Equal(Point2D.Origin, Point2D.Unit - Point2D.Unit);
            Assert.Equal(Point2D.Origin, PointNegativeUnit - PointNegativeUnit);
        }

        [Fact]
        internal void ScalarMultiplicationTest()
        {
            Assert.Equal(PointTwoTwo, 2 * Point2D.Unit);
            Assert.Equal(Point2D.Unit, -1 * PointNegativeUnit);
        }
    }
}
