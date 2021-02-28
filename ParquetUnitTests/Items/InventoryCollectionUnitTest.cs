using Parquet.Items;
using Xunit;

namespace ParquetUnitTests.Items
{
    /// <summary>
    /// Unit tests <see cref="InventoryCollection"/>.
    /// </summary>
    public class InventoryCollectionUnitTest
    {
        #region Test Values
        private const int TestCapacity = 30;
        #endregion

        [Fact]
        internal void NewInventoryHasGivenCapacityTest()
        {
            var inventory = new InventoryCollection(TestCapacity);

            Assert.Equal(TestCapacity, inventory.Capacity);
        }

        /* TODO [TESTING] Introduce mutable unit tests!
        [Fact]
        internal void NewInventoryContainsOneSlotsForEachItemTest()
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
        internal void InventoryContainsGivenNumbersOfItemsTest()
        {
            var inventory = new Inventory(TestCapacity);
            var numberOfItems = 6;
            inventory.Give(TestModels.TestItem1.ID, numberOfItems);

            Assert.Equal(numberOfItems, inventory.Contains(TestModels.TestItem1.ID));
        }

        [Fact]
        internal void InventoryHasGivenItemsTest()
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
        internal void InventoryReturnsCorrectRemainderAfterTakingItemsTest()
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
        internal void InventoryMergesItemsTest()
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
        internal void InventoryDoesNotContainItemsNotGivenTest()
        {
            var inventory = new Inventory(TestCapacity);
            inventory.Give(TestModels.TestItem1.ID, 4);
            var notInInventoryID = TestModels.TestItem1.ID + 10;

            Assert.Equal(0, inventory.Contains(notInInventoryID));
        }
        */
    }
}
