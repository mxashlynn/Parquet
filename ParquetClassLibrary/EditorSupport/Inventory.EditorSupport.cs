#if DESIGN
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.EditorSupport;

namespace ParquetClassLibrary.Items
{
    [SuppressMessage("Naming", "CA1710:Identifiers should have correct suffix",
                     Justification = "Inventory implies InventorySlotCollection.")]
    [SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
                     Justification = "By design, Inventory should never itself use IMutableInventory to access its own members.  This interface is for external types that require read/write access.")]
    public partial class Inventory : IMutableInventory
    {
        #region IMutableInventory Implementation
        /// <summary>How many <see cref="InventorySlot"/>s can be stored.</summary>
        [Ignore]
        int IMutableInventory.Capacity { get => Capacity; set => Capacity = value; }

        /// <summary>
        /// Stores the given <see cref="InventorySlot"/> if possible.
        /// </summary>
        /// <param name="inSlot">The slot to give.</param>
        /// <returns>
        /// If everything was stored successfully, <c>0</c>;
        /// otherwise, the number of items that could not be stored because the <see cref="Inventory"/> is full.
        /// </returns>
        int IMutableInventory.Give(InventorySlot inSlot)
            => ((IMutableInventory)this).Give(inSlot?.ItemID ?? ModelID.None, inSlot?.Count ?? 1);

        /// <summary>
        /// Stores the given number of the given item, if possible.
        /// </summary>
        /// <param name="inItemID">What kind of item to give.</param>
        /// <param name="inHowMany">How many of the item to give.  Must be positive.</param>
        /// <returns>
        /// If everything was stored successfully, <c>0</c>;
        /// otherwise, the number of items that could not be stored because the <see cref="Inventory"/> is full.
        /// </returns>
        int IMutableInventory.Give(ModelID inItemID, int inHowMany)
            // NOTE That the implementation is found in Inventory.cs so that the constructors can leverage this logic.
            => PrivateGive(inItemID, inHowMany);

        /// <summary>
        /// Removes the given <see cref="InventorySlot"/>, if possible.
        /// </summary>
        /// <param name="inSlot">The slot to take.</param>
        /// <returns>
        /// If everything was removed successfully, <c>0</c>;
        /// otherwise, the number of items that could not be removed because the <see cref="Inventory"/> did not have any more.
        /// </returns>
        int IMutableInventory.Take(InventorySlot inSlot)
        {
            Precondition.IsNotNull(inSlot);
            return ((IMutableInventory)this).Take(inSlot.ItemID, inSlot.Count);
        }

        /// <summary>
        /// Removes the given number of the given item, if possible.
        /// </summary>
        /// <param name="inItemID">What kind of item to take.</param>
        /// <param name="inHowMany">How many of the item to take.  Must be positive.</param>
        /// <returns>
        /// If everything was removed successfully, <c>0</c>;
        /// otherwise, the number of items that could not be removed because the <see cref="Inventory"/> did not have any more.
        /// </returns>
        int IMutableInventory.Take(ModelID inItemID, int inHowMany)
        {
            Precondition.MustBePositive(inHowMany, nameof(inHowMany));

            var remainder = inHowMany;

            while (remainder > 0)
            {
                var slotToTakeFrom = Slots.Find(slot => slot.ItemID == inItemID);
                if (null != slotToTakeFrom)
                {
                    remainder = slotToTakeFrom.Take(remainder);
                    if (slotToTakeFrom.Count == 0)
                    {
                        Slots.Remove(slotToTakeFrom);
                    }
                }
                else
                {
                    // If there are no slots of the item type, return the remainder.
                    break;
                }
            }

            return remainder;
        }
        #endregion

        #region ICollection Implementation
        /// <summary>If <c>true</c> the <see cref="Inventory"/> is read-only; if false, it may be mutated.</summary>
        bool ICollection<InventorySlot>.IsReadOnly => false;

        /// <summary>
        /// Adds the given <see cref="InventorySlot"/> to the <see cref="Inventory"/>.
        /// </summary>
        /// <remarks>This method should only be used by <see cref="SeriesConverter{TElement, TCollection}"/>.</remarks>
        /// <param name="inSlot">The slot to add.</param>
        [Obsolete("Use Inventory.Give() instead.")]
        void ICollection<InventorySlot>.Add(InventorySlot inSlot)
            => ((IMutableInventory)this).Give(inSlot);

        /// <summary>
        /// Removes all <see cref="InventorySlot"/>s from the <see cref="Inventory"/>.
        /// <remarks>This method does not respect gameplay rules, but forcibly empties the collection.</remarks>
        /// </summary>
        void ICollection<InventorySlot>.Clear()
            => Slots.Clear();

        /// <summary>
        /// Copies the elements of the <see cref="Inventory"/> to an <see cref="System.Array"/>, starting at the given index.
        /// </summary>
        /// <param name="inArray">The array to copy to.</param>
        /// <param name="inArrayIndex">The index at which to begin copying.</param>
        void ICollection<InventorySlot>.CopyTo(InventorySlot[] inArray, int inArrayIndex)
            => Slots.CopyTo(inArray, inArrayIndex);

        /// <summary>
        /// Removes the first occurrence of the given <see cref="InventorySlot"/> from the <see cref="Inventory"/>.
        /// </summary>
        /// <param name="inSlot">The slot to remove.</param>
        /// <returns><c>False</c> if slot was found but could not be removed; otherwise, <c>true</c>.</returns>
        [Obsolete("Use Inventory.Take() instead.", true)]
        bool ICollection<InventorySlot>.Remove(InventorySlot inSlot)
            => ((IMutableInventory)this).Take(inSlot) == 0;
        #endregion
    }
}
#endif
