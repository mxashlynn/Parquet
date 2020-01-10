using System;
using System.Collections.Generic;
using ParquetClassLibrary;
using ParquetClassLibrary.Items;
using Xunit;

namespace ParquetUnitTests
{
    public class InventoryUnitTest
    {
        #region Test Values
        private int TestCapacity = 30;
        #endregion

        [Fact]
        public void NewInventoryHasGivenCapacityTest()
        {
            var inventory = new Inventory(TestCapacity);

            Assert.Equal(TestCapacity, inventory.Capacity);
        }

        [Fact]
        public void NewInventoryContainsOneSlotsForEachItemTest()
        {
            var inventory = new Inventory(TestCapacity);
            var numberOfItemTypes = 4;
            // TODO ERROR The IDs used here need to actually be in All.
            for (var i = 0; i < numberOfItemTypes; i++)
            {
                inventory.Give(All.ItemIDs.Minimum + i);
            }

            Assert.Equal(numberOfItemTypes, inventory.Count);
        }

        [Fact]
        public void InventoryContainsGivenNumbersOfItemsTest()
        {
            var inventory = new Inventory(TestCapacity);
            var numberOfItems = 6;
            var numberOfItemTypes = 4;
            // TODO ERROR The IDs used here need to actually be in All.
            for (var i = 0; i < numberOfItemTypes; i++)
            {
                inventory.Give(All.ItemIDs.Minimum + i, numberOfItems);
            }

            for (var i = 0; i < numberOfItemTypes; i++)
            {
                Assert.Equal(numberOfItems, inventory.Contains(All.ItemIDs.Minimum + i));
            }
        }

        [Fact]
        public void InventoryHasGivenItemsTest()
        {
            var inventory = new Inventory(TestCapacity);
            // TODO ERROR The IDs used here need to actually be in All.
            var slots = new List<InventorySlot>
            {
                new InventorySlot(All.ItemIDs.Minimum + 1,   4),
                new InventorySlot(All.ItemIDs.Minimum + 10,  40),
                new InventorySlot(All.ItemIDs.Minimum + 100, 400),
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
            // TODO ERROR The IDs used here need to actually be in All.
            var slots = new List<InventorySlot>
            {
                new InventorySlot(All.ItemIDs.Minimum + 1,   4),
                new InventorySlot(All.ItemIDs.Minimum + 10,  40),
                new InventorySlot(All.ItemIDs.Minimum + 100, 400),
            };
            var amountToTake = 10;

            foreach (var slot in slots)
            {
                inventory.Give(slot);
                Assert.Equal(Math.Abs(amountToTake - slot.Count), inventory.Take(slot.ItemID, amountToTake));
            }
        }

        [Fact]
        public void InventoryMergesItemsTest()
        {
            var inventory = new Inventory(TestCapacity);
            var slots = new List<InventorySlot>
            {
                new InventorySlot(TestModels.TestItem.ID, 4),
                new InventorySlot(TestModels.TestItem.ID, 40),
                new InventorySlot(TestModels.TestItem.ID, 400),
            };
            var total = 444;
            foreach (var slot in slots)
            {
                inventory.Give(slot);
            }

            Assert.Equal(total, inventory.Contains(TestModels.TestItem.ID));
        }

        [Fact]
        public void InventoryDoesNotContainItemsNotGivenTest()
        {
            var inventory = new Inventory(TestCapacity);
            inventory.Give(TestModels.TestItem.ID, 4);
            var notInInventoryID = TestModels.TestItem.ID + 10;

            Assert.Equal(0, inventory.Contains(notInInventoryID));
        }
    }
}
