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
        public void NewSolidColorTest(int inR, int inG, int inB)
        {
            var testVector = new PCLColor(inR, inG, inB);
            Assert.Equal(inR, testVector.R);
            Assert.Equal(inG, testVector.G);
            Assert.Equal(inB, testVector.B);
            Assert.Equal(255, testVector.A);
        }

        [Theory]
        [InlineData(255, 255, 255, 0)]
        [InlineData(255, 255, 255, 85)]
        [InlineData(255, 255, 255, 170)]
        [InlineData(255, 255, 255, 255)]
        public void NewTranslucentColorTest(int inR, int inG, int inB, int inA)
        {
            var testVector = new PCLColor(inR, inG, inB, inA);
            Assert.Equal(inR, testVector.R);
            Assert.Equal(inG, testVector.G);
            Assert.Equal(inB, testVector.B);
            Assert.Equal(inA, testVector.A);
        }
    }
}
