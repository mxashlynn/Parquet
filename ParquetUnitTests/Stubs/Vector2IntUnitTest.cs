using ParquetClassLibrary.Stubs;
using Xunit;

namespace ParquetUnitTests.Stubs
{
    public class Vector2IntUnitTest
    {
        [Fact]
        public void ZeroVectorTest()
        {
            Assert.Equal(0, Vector2Int.ZeroVector.x);
            Assert.Equal(0, Vector2Int.ZeroVector.y);
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
            Assert.Equal(testVector.x, in_x);
            Assert.Equal(testVector.y, in_y);
        }
    }
}
