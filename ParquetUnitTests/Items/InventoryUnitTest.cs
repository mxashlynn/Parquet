using Parquet.Items;
using Xunit;

namespace ParquetUnitTests.Items
{
    public class InventoryUnitTest
    {
        #region Test Values
        private const int TestCapacity = 30;
        #endregion

        [Fact]
        public void NewInventoryHasGivenCapacityTest()
        {
            var inventory = new Inventory(TestCapacity);

            Assert.Equal(TestCapacity, inventory.Capacity);
        }

        /* TODO [TESTING] Introduce EditorSupport unit tests!
        [Fact]
        public void NewInventoryContainsOneSlotsForEachItemTest()
        {
            var inventory = new Inventory(TestCapacity);
            inventory.Give(TestModels.TestItem1.ID);
            inventory.Give(TestModels.TestItem2.ID);
            inventory.Give(TestModels.TestItem3.ID);
            inventory.Give(TestModels.TestItem4.ID);
            var numberOfItemTypes = 4;

            Assert.Equal(numberOfItemTypes, inventory.Count);
        }

        [Fact]
        public void InventoryContainsGivenNumbersOfItemsTest()
        {
            var inventory = new Inventory(TestCapacity);
            var numberOfItems = 6;
            inventory.Give(TestModels.TestItem1.ID, numberOfItems);

            Assert.Equal(numberOfItems, inventory.Contains(TestModels.TestItem1.ID));
        }

        [Fact]
        public void InventoryHasGivenItemsTest()
        {
            var inventory = new Inventory(TestCapacity);
            var slots = new List<InventorySlot>
            {
                new InventorySlot(TestModels.TestItem2.ID,   4),
                new InventorySlot(TestModels.TestItem3.ID,  40),
                new InventorySlot(TestModels.TestItem4.ID, 400),
            };
            foreach (var slot in slots)
            {
                inventory.Give(slot);
            }

            Assert.True(inventory.Has(slots));
        }

        [Fact]
        public void InventoryReturnsCorrectRemainderAfterTakingItemsTest()
        {
            var inventory = new Inventory(TestCapacity);
            var slots = new List<InventorySlot>
            {
                new InventorySlot(TestModels.TestItem2.ID,   4),
                new InventorySlot(TestModels.TestItem3.ID,  40),
                new InventorySlot(TestModels.TestItem4.ID, 400),
            };
            var amountToTake = 10;

            foreach (var slot in slots)
            {
                inventory.Give(slot);
                var expectedRemainder = slot.Count > amountToTake
                    ? 0
                    : amountToTake - slot.Count;
                Assert.Equal(expectedRemainder, inventory.Take(slot.ItemID, amountToTake));
            }
        }

        [Fact]
        public void InventoryMergesItemsTest()
        {
            var inventory = new Inventory(TestCapacity);
            var slots = new List<InventorySlot>
            {
                new InventorySlot(TestModels.TestItem1.ID, 4),
                new InventorySlot(TestModels.TestItem1.ID, 40),
                new InventorySlot(TestModels.TestItem1.ID, 400),
            };
            var total = 444;
            foreach (var slot in slots)
            {
                inventory.Give(slot);
            }

            Assert.Equal(total, inventory.Contains(TestModels.TestItem1.ID));
        }

        [Fact]
        public void InventoryDoesNotContainItemsNotGivenTest()
        {
            var inventory = new Inventory(TestCapacity);
            inventory.Give(TestModels.TestItem1.ID, 4);
            var notInInventoryID = TestModels.TestItem1.ID + 10;

            Assert.Equal(0, inventory.Contains(notInInventoryID));
        }
        */
    }
}
