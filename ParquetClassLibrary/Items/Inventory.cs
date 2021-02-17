using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Parquet.Properties;

namespace Parquet.Items
{
    /// <summary>
    /// Models a set of items carried by a character.
    /// Instances of this class are mutable during play.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1710:Identifiers should have correct suffix",
                                                     Justification = "Inventory implies InventorySlotCollection.")]
    public class Inventory : ICollection<InventorySlot>
    {
        #region Class Defaults
        /// <summary>A value to use in place of an uninitialized <see cref="Inventory"/>.</summary>
        public static Inventory Empty { get; } = new Inventory();
        #endregion

        #region Characteristics
        /// <summary>The internal collection mechanism.</summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists",
                                                         Justification = "Slots is not exposed; I suspect this is a bug in .Net 5.")]
        private List<InventorySlot> Slots { get; set; }

        /// <summary>Backing value for <see cref="Capacity"/>.</summary>
        private int backingCapacity;

        /// <summary>How many <see cref="InventorySlot"/>s can be stored.</summary>
        /// <remarks>
        /// If <see cref="Capacity"/> is set to a value smaller than the current <see cref="Count"/>,
        /// then <see cref="InventorySlot"/>s will be discarded until <see cref="Capacity"/> is not exceeded.
        /// </remarks>
        public int Capacity
        {
            get => backingCapacity;
            set
            {
                Precondition.MustBeNonNegative(value, nameof(Capacity));
                backingCapacity = value;
                while (backingCapacity < (Slots?.Count ?? 0))
                {
                    Slots.RemoveAt(Slots.Count - 1);
                }
            }
        }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes an empty <see cref="Inventory"/> with unusable capacity.
        /// </summary>
        /// <remarks>
        /// This version of the constructor exists to make the generic new() constraint happy
        /// and is used in the library in a context where its limitations are understood.
        /// You probably don't want to use this constructor in your own code.
        ///</remarks>
        public Inventory()
            : this(InventoryConfiguration.DefaultCapacity) { }

        /// <summary>
        /// Initializes a new empty instance of the <see cref="Inventory"/> class.
        /// </summary>
        /// <param name="inCapacity">How many inventory slots exist.  Must be positive</param>
        public Inventory(int inCapacity)
        {
            Precondition.MustBePositive(inCapacity, nameof(inCapacity));

            Capacity = inCapacity;
            Slots = new List<InventorySlot>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Inventory"/> class from a collection of <see cref="InventorySlot"/>s.
        /// </summary>
        /// <param name="inSlots">The <see cref="InventorySlot"/>s to collect.  Cannot be null.</param>
        /// <param name="inCapacity">How many inventory slots exist.  Must be positive</param>
        public Inventory(IEnumerable<InventorySlot> inSlots, int inCapacity)
        {
            Precondition.IsNotNull(inSlots, nameof(inSlots));
            Precondition.MustBePositive(inCapacity, nameof(inCapacity));

            Capacity = inCapacity;
            Slots = new List<InventorySlot>();
            foreach (var slot in inSlots ?? Enumerable.Empty<InventorySlot>())
            {
                Give(slot.ItemID, slot.Count);
            }
        }
        #endregion

        #region Slot Access
        /// <summary>
        /// Determines how many of given type of item is contained in the <see cref="Inventory"/>.
        /// </summary>
        /// <param name="inItemID">The item type to check for.  Cannot be <see cref="ModelID.None"/>.</param>
        /// <returns>The number of items of the given type contained.</returns>
        public int Contains(ModelID inItemID)
            => Slots.Where(slot => slot.ItemID == inItemID)
                    .Sum(slot => slot.Count);

        /// <summary>
        /// Determines if the <see cref="Inventory"/> contains the given items in the given quantities.
        /// </summary>
        /// <param name="inItems">The items to check for.  Cannot be null or empty.</param>
        /// <returns><c>true</c> if everything was found; otherwise, <c>false</c>.</returns>
        public bool Has(IEnumerable<(ModelID, int)> inItems)
        {
            Precondition.IsNotNullOrEmpty(inItems, nameof(inItems));

            var result = true;
            foreach (var slot in inItems ?? Enumerable.Empty<(ModelID, int)>())
            {
                result &= Has(slot.Item1, slot.Item2);
            }
            return result;
        }

        /// <summary>
        /// Determines if the <see cref="Inventory"/> contains the given <see cref="InventorySlot"/>s.
        /// </summary>
        /// <param name="inSlots">The slots to check for.  Cannot be null or empty.</param>
        /// <returns><c>true</c> if everything was found; otherwise, <c>false</c>.</returns>
        public bool Has(IEnumerable<InventorySlot> inSlots)
        {
            Precondition.IsNotNullOrEmpty(inSlots, nameof(inSlots));

            var result = true;
            foreach (var slot in inSlots ?? Enumerable.Empty< InventorySlot>())
            {
                result &= Has(slot.ItemID, slot.Count);
            }
            return result;
        }

        /// <summary>
        /// Determines if the <see cref="Inventory"/> contains the given <see cref="InventorySlot"/>.
        /// </summary>
        /// <param name="inSlot">The slot to check for.</param>
        /// <returns><c>true</c> if everything was found; otherwise, <c>false</c>.</returns>
        /// <remarks>A <c>null</c> slot is never found and will result in a return value of <c>false</c>.</remarks>
        public bool Has(InventorySlot inSlot)
            => inSlot is not null
            && Has(inSlot.ItemID, inSlot.Count);

        /// <summary>
        /// Determines if the <see cref="Inventory"/> contains the given number of the given item.
        /// </summary>
        /// <param name="inItemID">What kind of item to check for.</param>
        /// <param name="inHowMany">How many of the item to check for.  Must be positive.</param>
        /// <returns><c>true</c> if everything was found; otherwise, <c>false</c>.</returns>
        public bool Has(ModelID inItemID, int inHowMany = 1)
        {
            Precondition.MustBePositive(inHowMany, nameof(inHowMany));
            return Contains(inItemID) >= inHowMany;
        }

        /// <summary>
        /// Stores the given <see cref="InventorySlot"/> if possible.
        /// </summary>
        /// <param name="inSlot">The slot to give.</param>
        /// <returns>
        /// If everything was stored successfully, <c>0</c>;
        /// otherwise, the number of items that could not be stored because the <see cref="Inventory"/> is full.
        /// </returns>
        public int Give(InventorySlot inSlot)
            => Give(inSlot?.ItemID ?? ModelID.None, inSlot?.Count ?? 0);

        /// <summary>
        /// Stores the given number of the given item, if possible.
        /// </summary>
        /// <param name="inItemID">What kind of item to give.</param>
        /// <param name="inHowMany">How many of the item to give.  Must be positive.</param>
        /// <returns>
        /// If everything was stored successfully, <c>0</c>;
        /// otherwise, the number of items that could not be stored because the <see cref="Inventory"/> is full.
        /// </returns>
        public int Give(ModelID inItemID, int inHowMany)
        {
            // In testing we want to alert the developer if they try to give "nothing",
            // but in production this should probably just silently succeed.
            Debug.Assert(inItemID != ModelID.None,
                         string.Format(CultureInfo.CurrentCulture, Resources.WarningTriedToGiveNothing,
                         nameof(ModelID.None),
                         nameof(Inventory)));
            if (inItemID == ModelID.None)
            {
                return 0;
            }
            Precondition.MustBePositive(inHowMany, nameof(inHowMany));

            var remainder = inHowMany;
            // If this is happening during deserialization, assume the stack max was respected during serialization.
            var stackMax = All.CollectionsHaveBeenInitialized
                ? All.Items?.GetOrNull<ItemModel>(inItemID)?.StackMax ?? ItemModel.DefaultStackMax
                : ItemModel.DefaultStackMax;

            while (remainder > 0)
            {
                var slotToAddTo = Slots.Find(slot => slot.ItemID == inItemID
                                                  && slot.Count < stackMax);
                if (slotToAddTo is null)
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
        public int Take(InventorySlot inSlot)
            => Take(inSlot?.ItemID ?? ModelID.None, inSlot?.Count ?? 0);

        /// <summary>
        /// Removes the given number of the given item, if possible.
        /// </summary>
        /// <param name="inItemID">What kind of item to take.</param>
        /// <param name="inHowMany">How many of the item to take.  Must be positive.</param>
        /// <returns>
        /// If everything was removed successfully, <c>0</c>;
        /// otherwise, the number of items that could not be removed because the <see cref="Inventory"/> did not have any more.
        /// </returns>
        public int Take(ModelID inItemID, int inHowMany)
        {
            Precondition.MustBePositive(inHowMany, nameof(inHowMany));

            var remainder = inHowMany;

            while (remainder > 0)
            {
                var slotToTakeFrom = Slots.Find(slot => slot.ItemID == inItemID);
                if (slotToTakeFrom is not null)
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
        public bool IsReadOnly => false;

        /// <summary>How many <see cref="InventorySlot"/>s are currently occupied.</summary>
        public int Count
            => Slots.Count;

        /// <summary>
        /// Determines whether the <see cref="Inventory"/> contains the given <see cref="InventorySlot"/>.
        /// </summary>
        /// <param name="inSlot">The slot to search for.</param>
        /// <returns><c>true</c> if the slot is found; otherwise, <c>false</c>.</returns>
        [Obsolete("Use Inventory.Has() instead.", true)]
        public bool Contains(InventorySlot inSlot)
            => Has(inSlot);

        /// <summary>
        /// Adds the given <see cref="InventorySlot"/> to the <see cref="Inventory"/>.
        /// </summary>
        /// <remarks>This method should only be used by <see cref="SeriesConverter{TElement, TCollection}"/>.</remarks>
        /// <param name="inSlot">The slot to add.</param>
        [Obsolete("Use Inventory.Give() instead.")]
        public void Add(InventorySlot inSlot)
            => Give(inSlot);

        /// <summary>
        /// Removes all <see cref="InventorySlot"/>s from the <see cref="Inventory"/>.
        /// <remarks>This method does not respect gameplay rules, but forcibly empties the collection.</remarks>
        /// </summary>
        public void Clear()
            => Slots.Clear();

        /// <summary>
        /// Copies the elements of the <see cref="Inventory"/> to an <see cref="System.Array"/>, starting at the given index.
        /// </summary>
        /// <param name="inArray">The array to copy to.</param>
        /// <param name="inArrayIndex">The index at which to begin copying.</param>
        public void CopyTo(InventorySlot[] inArray, int inArrayIndex)
            => Slots.CopyTo(inArray, inArrayIndex);

        /// <summary>
        /// Removes the first occurrence of the given <see cref="InventorySlot"/> from the <see cref="Inventory"/>.
        /// </summary>
        /// <param name="inSlot">The slot to remove.</param>
        /// <returns><c>False</c> if slot was found but could not be removed; otherwise, <c>true</c>.</returns>
        [Obsolete("Use Inventory.Take() instead.", true)]
        public bool Remove(InventorySlot inSlot)
            => Take(inSlot) == 0;

        /// <summary>
        /// Exposes an <see cref="IEnumerator"/> to support simple iteration.
        /// </summary>
        /// <returns>An enumerator.</returns>
        // Used by LINQ. No accessibility modifiers are valid in this context.
        IEnumerator IEnumerable.GetEnumerator()
            => Slots.GetEnumerator();

        /// <summary>
        /// Retrieves an enumerator for the <see cref="IEnumerable{InventorySlot}"/>.
        /// </summary>
        /// <returns>An enumerator that iterates through the inventory.</returns>
        public IEnumerator<InventorySlot> GetEnumerator()
            => Slots.GetEnumerator();
        #endregion

        #region Utilities
        /// <summary>How many individual <see cref="ItemModel"/>s are contained.</summary>
        public int ItemCount
            => Slots.Select(slot => slot.Count).Sum();

        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same characteristics as the current instance.</returns>
        public Inventory DeepClone()
            => new Inventory(Slots, Capacity);

        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="Inventory"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"{Count} / {Capacity} Items";
        #endregion
    }
}
