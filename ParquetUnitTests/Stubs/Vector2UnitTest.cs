using ParquetClassLibrary.Stubs;
using Xunit;

namespace ParquetUnitTests.Stubs
{
    public class Vector2UnitTest
    {
        [Fact]
        public void ZeroVectorTest()
        {
            Assert.Equal(0f, Vector2Int.zeroVector.x);
            Assert.Equal(0f, Vector2Int.zeroVector.y);
        }

        [Theory]
        [InlineData(float.NegativeInfinity, float.NegativeInfinity)]
        [InlineData(-1f, 1f)]
        [InlineData(0.5f, 0.05f)]
        [InlineData(0f, 0f)]
        [InlineData(1f, -1f)]
        [InlineData(float.PositiveInfinity, float.PositiveInfinity)]
        public void NewVectorTest(float in_x, float in_y)
        {
            var testVector = new Vector2(in_x, in_y);
            Assert.Equal(testVector.x, in_x);
            Assert.Equal(testVector.y, in_y);
        }
    }
}
