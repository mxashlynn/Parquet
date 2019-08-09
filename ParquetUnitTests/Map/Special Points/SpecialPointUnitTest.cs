using ParquetClassLibrary.Map.SpecialPoints;
using ParquetClassLibrary.Utilities;
using Xunit;

namespace ParquetUnitTests.Map.SpecialPoints
{
    public class SpecialPointUnitTest
    {
        private static readonly Vector2D testPosition = new Vector2D(2, 2);

        [Fact]
        public void SpecialPointsEquateIfTheirPositionsEquateTest()
        {
            var point1 = new SpecialPoint(testPosition);
            var point2 = new SpecialPoint(testPosition);

            Assert.Equal(point1, point2);
        }

        [Fact]
        public void SpecialPointsDoNotEquateIfTheirPositionsDoNotEquateTest()
        {
            var point1 = new SpecialPoint(testPosition);
            var point2 = new SpecialPoint(Vector2D.Zero);

            Assert.NotEqual(point1, point2);
        }
    }
}
