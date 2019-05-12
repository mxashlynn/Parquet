using System;
using ParquetClassLibrary.Crafting;
using Xunit;

namespace ParquetUnitTests
{
    public class CraftingElementUnitTest
    {
        [Fact]
        public void ZeroAmountsFailTest()
        {
            void TestCodeZero()
            {
                var _ = new CraftingElement("test", 0);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCodeZero);
        }

        [Fact]
        public void NegativeeAountsFailTest()
        {
            void TestCodeNegative()
            {
                var _ = new CraftingElement("test", -1);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCodeNegative);
        }
    }
}
