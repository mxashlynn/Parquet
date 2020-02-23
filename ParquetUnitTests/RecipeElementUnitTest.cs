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
                var _ = new RecipeElement(0, "test");
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCodeZero);
        }

        [Fact]
        public void NegativeeAountsFailTest()
        {
            void TestCodeNegative()
            {
                var _ = new RecipeElement(-1, "test");
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCodeNegative);
        }
    }
}
