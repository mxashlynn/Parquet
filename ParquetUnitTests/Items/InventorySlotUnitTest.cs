using System;
using ParquetClassLibrary;
using ParquetClassLibrary.Items;
using Xunit;

namespace ParquetUnitTests
{
    public class InventorySlotUnitTest
    {
        #region Test Values
        private int None = 0;
        private int One = 1;
        private int Some = 10;
        #endregion

        [Fact]
        public void CannotStoreSomeOfNothingTest()
        {
            void TestCode()
            {
                var _ = new InventorySlot(EntityID.None, Some);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }

        [Fact]
        public void CannotStoreNoneOfSomethingTest()
        {
            void TestCode()
            {
                var _ = new InventorySlot(TestModels.TestItem.ID, None);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }

        [Fact]
        public void CannotStoreNonItemTest()
        {
            void TestCode()
            {
                var _ = new InventorySlot(TestModels.TestBlock.ID, Some);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }


        [Fact]
        public void CountMatchesItemsStoredTest()
        {
            var slot = new InventorySlot(TestModels.TestItem.ID, Some);

            Assert.Equal(Some, slot.Count);
        }

        [Fact]
        public void SlotAddTest()
        {
            var slot = new InventorySlot(TestModels.TestItem.ID, One);
            var remainder1 = 0;
            var remainder2 = One + Some;

            Assert.Equal(remainder1, slot.Add(Some));
            Assert.Equal(remainder2, slot.Add(TestModels.TestItem.StackMax));
        }

        [Fact]
        public void SlotRemoveTest()
        {
            var slot = new InventorySlot(TestModels.TestItem.ID, Some);
            var remainder1 = 0;
            var remainder2 = TestModels.TestItem.StackMax - (Some - One);

            Assert.Equal(remainder1, slot.Remove(One));
            Assert.Equal(remainder2, slot.Remove(TestModels.TestItem.StackMax));
        }
    }
}
