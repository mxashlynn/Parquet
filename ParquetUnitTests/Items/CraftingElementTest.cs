using System;
using ParquetClassLibrary.Crafting;
using Xunit;

namespace ParquetUnitTests
{
    public class CraftingElementTest
    {
        [Fact]
        public void InvalidItemIDsFailTest()
        {
            var badItemID = TestEntities.TestBlock.ID - 1;

            void TestCode()
            {
                var _ = new CraftingElement(badItemID, 1);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }

        [Fact]
        public void NonPositiveAmountsFailTest()
        {
            void TestCodeZero()
            {
                var _ = new CraftingElement(TestEntities.TestItem.ID, 0);
            }

            void TestCodeNegative()
            {
                var _ = new CraftingElement(TestEntities.TestItem.ID, -1);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCodeZero);
            Assert.Throws<ArgumentOutOfRangeException>(TestCodeNegative);
        }
    }
}
