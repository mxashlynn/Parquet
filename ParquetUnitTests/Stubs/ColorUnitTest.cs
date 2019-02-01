using ParquetClassLibrary.Stubs;
using Xunit;

namespace ParquetUnitTests.Stubs
{
    public class ColorUnitTest
    {
        [Fact]
        public void WhiteTest()
        {
            Assert.Equal(1f, Color.White.r);
            Assert.Equal(1f, Color.White.g);
            Assert.Equal(1f, Color.White.b);
            Assert.Equal(1f, Color.White.a);
        }

        [Theory]
        [InlineData(0f, 0f, 0f)]
        [InlineData(0.25f, 0.25f, 0.25f)]
        [InlineData(0.5f, 0.5f, 0.5f)]
        [InlineData(0.75f, 0.75f, 0.75f)]
        [InlineData(1f, 1f, 1f)]
        public void NewSolidColorTest(float in_r, float in_g, float in_b)
        {
            var testVector = new Color(in_r, in_g, in_b);
            Assert.Equal(in_r, testVector.r);
            Assert.Equal(in_g, testVector.g);
            Assert.Equal(in_b, testVector.b);
            Assert.Equal(1f, testVector.a);
        }

        [Theory]
        [InlineData(1f, 1f, 1f, 0f)]
        [InlineData(1f, 1f, 1f, 0.33333f)]
        [InlineData(1f, 1f, 1f, 0.66667f)]
        [InlineData(1f, 1f, 1f, 1f)]
        public void NewTranslucentColorTest(float in_r, float in_g, float in_b, float in_a)
        {
            var testVector = new Color(in_r, in_g, in_b, in_a);
            Assert.Equal(in_r, testVector.r);
            Assert.Equal(in_g, testVector.g);
            Assert.Equal(in_b, testVector.b);
            Assert.Equal(in_a, testVector.a);
        }
    }
}
