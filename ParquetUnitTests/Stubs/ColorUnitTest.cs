using ParquetClassLibrary.Stubs;
using Xunit;

namespace ParquetUnitTests.Stubs
{
    public class ColorUnitTest
    {
        [Fact]
        public void WhiteTest()
        {
            Assert.Equal(255, Color.White.r);
            Assert.Equal(255, Color.White.g);
            Assert.Equal(255, Color.White.b);
            Assert.Equal(255, Color.White.a);
        }

        [Fact]
        public void BlackTest()
        {
            Assert.Equal(0, Color.Black.r);
            Assert.Equal(0, Color.Black.g);
            Assert.Equal(0, Color.Black.b);
            Assert.Equal(255, Color.Black.a);
        }

        [Fact]
        public void TransparentTest()
        {
            Assert.Equal(0, Color.Transparent.a);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(64, 64, 64)]
        [InlineData(128, 128, 128)]
        [InlineData(192, 192, 192)]
        [InlineData(255, 255, 255)]
        public void NewSolidColorTest(int in_r, int in_g, int in_b)
        {
            var testVector = new Color(in_r, in_g, in_b);
            Assert.Equal(in_r, testVector.r);
            Assert.Equal(in_g, testVector.g);
            Assert.Equal(in_b, testVector.b);
            Assert.Equal(255, testVector.a);
        }

        [Theory]
        [InlineData(255, 255, 255, 0)]
        [InlineData(255, 255, 255, 85)]
        [InlineData(255, 255, 255, 170)]
        [InlineData(255, 255, 255, 255)]
        public void NewTranslucentColorTest(int in_r, int in_g, int in_b, int in_a)
        {
            var testVector = new Color(in_r, in_g, in_b, in_a);
            Assert.Equal(in_r, testVector.r);
            Assert.Equal(in_g, testVector.g);
            Assert.Equal(in_b, testVector.b);
            Assert.Equal(in_a, testVector.a);
        }
    }
}
