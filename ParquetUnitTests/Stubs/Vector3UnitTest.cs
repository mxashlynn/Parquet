using ParquetClassLibrary.Stubs;
using Xunit;

namespace ParquetUnitTests.Stubs
{
    public class Vector3UnitTest
    {
        [Fact]
        public void ZeroVectorTest()
        {
            Assert.Equal(0f, Vector3.zeroVector.x);
            Assert.Equal(0f, Vector3.zeroVector.y);
            Assert.Equal(0f, Vector3.zeroVector.z);
        }

        [Theory]
        [InlineData(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity)]
        [InlineData(-1f, -1f, -1f)]
        [InlineData(0.5f, 0.05f, 0.01f)]
        [InlineData(0f, 0f, 0f)]
        [InlineData(1f, 1f, 1f)]
        [InlineData(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity)]
        public void NewVectorTest(float in_x, float in_y, float in_z)
        {
            var testVector = new Vector3(in_x, in_y, in_z);
            Assert.Equal(testVector.x, in_x);
            Assert.Equal(testVector.y, in_y);
            Assert.Equal(testVector.z, in_z);
        }
    }
}
