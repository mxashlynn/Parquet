using System;
using ParquetClassLibrary;
using Xunit;

namespace ParquetUnitTests
{
    public class RecipeElementUnitTest
    {
        [Fact]
        public void ZeroAmountsFailTest()
        {
            void TestCodeZero()
            {
                var _ = new RecipeElement("test", 0);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCodeZero);
        }

        [Fact]
        public void NegativeeAountsFailTest()
        {
            void TestCodeNegative()
            {
                var _ = new RecipeElement("test", -1);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCodeNegative);
        }
    }
}
