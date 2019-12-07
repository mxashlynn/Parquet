using ParquetClassLibrary.Utilities;
using Xunit;

namespace ParquetUnitTests.Utilities
{
    public class ColorUnitTest
    {
        [Fact]
        public void WhiteTest()
        {
            Assert.Equal(255, PCLColor.White.R);
            Assert.Equal(255, PCLColor.White.G);
            Assert.Equal(255, PCLColor.White.B);
            Assert.Equal(255, PCLColor.White.A);
        }

        [Fact]
        public void BlackTest()
        {
            Assert.Equal(0, PCLColor.Black.R);
            Assert.Equal(0, PCLColor.Black.G);
            Assert.Equal(0, PCLColor.Black.B);
            Assert.Equal(255, PCLColor.Black.A);
        }

        [Fact]
        public void TransparentTest()
        {
            Assert.Equal(0, PCLColor.Transparent.A);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(64, 64, 64)]
        [InlineData(128, 128, 128)]
        [InlineData(192, 192, 192)]
        [InlineData(255, 255, 255)]
        public void NewSolidColorTest(int in_r, int in_g, int in_b)
        {
            var testVector = new PCLColor(in_r, in_g, in_b);
            Assert.Equal(in_r, testVector.R);
            Assert.Equal(in_g, testVector.G);
            Assert.Equal(in_b, testVector.B);
            Assert.Equal(255, testVector.A);
        }

        [Theory]
        [InlineData(255, 255, 255, 0)]
        [InlineData(255, 255, 255, 85)]
        [InlineData(255, 255, 255, 170)]
        [InlineData(255, 255, 255, 255)]
        public void NewTranslucentColorTest(int in_r, int in_g, int in_b, int in_a)
        {
            var testVector = new PCLColor(in_r, in_g, in_b, in_a);
            Assert.Equal(in_r, testVector.R);
            Assert.Equal(in_g, testVector.G);
            Assert.Equal(in_b, testVector.B);
            Assert.Equal(in_a, testVector.A);
        }
    }
}
