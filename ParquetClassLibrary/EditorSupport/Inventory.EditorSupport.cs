#if DESIGN
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using ParquetClassLibrary.EditorSupport;
using ParquetClassLibrary.Properties;

namespace ParquetClassLibrary.Items
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1710:Identifiers should have correct suffix",
                                                     Justification = "Inventory implies InventorySlotCollection.")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
                                                     Justification = "By design, Inventory should never itself use IMutableInventory to access its own members.  This interface is for external types that require read/write access.")]
    public partial class Inventory : IMutableInventory
    {
        #region IMutableInventory Implementation
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
        {
            // In testing we want to alert the developer if they try to give "nothing",
            // but in production this should probably just silently succeed.
            // TODO Is Debug.Assert fine here or do we need to use #if DESIGN ?
            Debug.Assert(inItemID != ModelID.None, string.Format(CultureInfo.CurrentCulture, Resources.WarningTriedToGiveNothing,
                                                   nameof(ModelID.None), nameof(Inventory)));
            if (inItemID == ModelID.None)
            {
                return 0;
            }
            Precondition.MustBePositive(inHowMany, nameof(inHowMany));

            var remainder = inHowMany;
            // If this is happening during deserialization, assume the stack max was respected during serialization.
            var stackMax = All.CollectionsHaveBeenInitialized
                ? All.Items.Get<ItemModel>(inItemID).StackMax
                : ItemModel.DefaultStackMax;

            while (remainder > 0)
            {
                var slotToAddTo = Slots.Find(slot => slot.ItemID == inItemID
                                                  && slot.Count < stackMax);
                if (null == slotToAddTo)
                {
                    // If there are no slots of the item type with room, try to make a new one.
                    if (Slots.Count < Capacity)
                    {
                        // If there is room for another slot, make one and add it.
                        slotToAddTo = new InventorySlot(inItemID, 1);
                        Slots.Add(slotToAddTo);
                        remainder--;
                    }
                    else
                    {
                        // If there is no room left, return the remainder.
                        break;
                    }
                }
                else
                {
                    remainder = slotToAddTo.Give(remainder);
                }
            }

            return remainder;
        }

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
            => Give(inSlot);

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
            => Take(inSlot) == 0;
        #endregion
    }
}
#endif
