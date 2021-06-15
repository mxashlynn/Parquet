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
    public class InventoryCollection : ICollection<InventorySlot>, IDeeplyCloneable<InventoryCollection>
    {
        #region Class Defaults
        /// <summary>A value to use in place of an uninitialized <see cref="InventoryCollection"/>.</summary>
        public static InventoryCollection Empty { get; } = new InventoryCollection();
        #endregion

        #region Characteristics
        /// <summary>The internal collection mechanism.</summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1002:Do not expose generic lists",
                                                         Justification = "Slots is not exposed; I suspect this is a bug in .Net 5.")]
        private List<InventorySlot> Slots { get; set; }

        /// <summary>Backing field for <see cref="Capacity"/>.</summary>
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
        /// Initializes an empty <see cref="InventoryCollection"/> with unusable capacity.
        /// </summary>
        /// <remarks>
        /// This version of the constructor exists to make the generic new() constraint happy
        /// and is used in the library in a context where its limitations are understood.
        /// You probably don't want to use this constructor in your own code.
        ///</remarks>
        public InventoryCollection()
            : this(InventoryConfiguration.DefaultCapacity) { }

        /// <summary>
        /// Initializes a new empty instance of the <see cref="InventoryCollection"/> class.
        /// </summary>
        /// <param name="capacity">How many inventory slots exist.  Must be positive</param>
        public InventoryCollection(int capacity)
        {
            Precondition.MustBePositive(capacity, nameof(capacity));

            Capacity = capacity;
            Slots = new List<InventorySlot>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryCollection"/> class from a collection of <see cref="InventorySlot"/>s.
        /// </summary>
        /// <param name="slots">The <see cref="InventorySlot"/>s to collect.  Cannot be null.</param>
        /// <param name="capacity">How many inventory slots exist.  Must be positive</param>
        public InventoryCollection(IEnumerable<InventorySlot> slots, int capacity)
        {
            Precondition.IsNotNull(slots, nameof(slots));
            Precondition.MustBePositive(capacity, nameof(capacity));

            Capacity = capacity;
            Slots = new List<InventorySlot>();
            foreach (var slot in slots ?? Enumerable.Empty<InventorySlot>())
            {
                Give(slot.ItemID, slot.Count);
            }
        }
        #endregion

        #region Slot Access
        /// <summary>
        /// Determines how many of given type of item is contained in the <see cref="InventoryCollection"/>.
        /// </summary>
        /// <param name="itemID">The item type to check for.  Cannot be <see cref="ModelID.None"/>.</param>
        /// <returns>The number of items of the given type contained.</returns>
        public int Contains(ModelID itemID)
            => Slots.Where(slot => slot.ItemID == itemID)
                    .Sum(slot => slot.Count);

        /// <summary>
        /// Determines if the <see cref="InventoryCollection"/> contains the given items in the given quantities.
        /// </summary>
        /// <param name="items">The items to check for.  Cannot be null or empty.</param>
        /// <returns><c>true</c> if everything was found; otherwise, <c>false</c>.</returns>
        public bool Has(IEnumerable<(ModelID, int)> items)
        {
            Precondition.IsNotNullOrEmpty(items, nameof(items));

            var result = true;
            foreach (var slot in items ?? Enumerable.Empty<(ModelID, int)>())
            {
                result &= Has(slot.Item1, slot.Item2);
            }
            return result;
        }

        /// <summary>
        /// Determines if the <see cref="InventoryCollection"/> contains the given <see cref="InventorySlot"/>s.
        /// </summary>
        /// <param name="slots">The slots to check for.  Cannot be null or empty.</param>
        /// <returns><c>true</c> if everything was found; otherwise, <c>false</c>.</returns>
        public bool Has(IEnumerable<InventorySlot> slots)
        {
            Precondition.IsNotNullOrEmpty(slots, nameof(slots));

            var result = true;
            foreach (var slot in slots ?? Enumerable.Empty<InventorySlot>())
            {
                result &= Has(slot.ItemID, slot.Count);
            }
            return result;
        }

        /// <summary>
        /// Determines if the <see cref="InventoryCollection"/> contains the given <see cref="InventorySlot"/>.
        /// </summary>
        /// <param name="slot">The slot to check for.</param>
        /// <returns><c>true</c> if everything was found; otherwise, <c>false</c>.</returns>
        /// <remarks>A <c>null</c> slot is never found and will result in a return value of <c>false</c>.</remarks>
        public bool Has(InventorySlot slot)
            => slot is not null
            && Has(slot.ItemID, slot.Count);

        /// <summary>
        /// Determines if the <see cref="InventoryCollection"/> contains the given number of the given item.
        /// </summary>
        /// <param name="itemID">What kind of item to check for.</param>
        /// <param name="howMany">How many of the item to check for.  Must be positive.</param>
        /// <returns><c>true</c> if everything was found; otherwise, <c>false</c>.</returns>
        public bool Has(ModelID itemID, int howMany = 1)
        {
            Precondition.MustBePositive(howMany, nameof(howMany));
            return Contains(itemID) >= howMany;
        }

        /// <summary>
        /// Stores the given <see cref="InventorySlot"/> if possible.
        /// </summary>
        /// <param name="slot">The slot to give.</param>
        /// <returns>
        /// If everything was stored successfully, <c>0</c>;
        /// otherwise, the number of items that could not be stored because the <see cref="InventoryCollection"/> is full.
        /// </returns>
        public int Give(InventorySlot slot)
            => Give(slot?.ItemID ?? ModelID.None, slot?.Count ?? 0);

        /// <summary>
        /// Stores the given number of the given item, if possible.
        /// </summary>
        /// <param name="itemID">What kind of item to give.</param>
        /// <param name="howMany">How many of the item to give.  Must be positive.</param>
        /// <returns>
        /// If everything was stored successfully, <c>0</c>;
        /// otherwise, the number of items that could not be stored because the <see cref="InventoryCollection"/> is full.
        /// </returns>
        public int Give(ModelID itemID, int howMany)
        {
            // In testing we want to alert the developer if they try to give "nothing",
            // but in production this should probably just silently succeed.
            Debug.Assert(itemID != ModelID.None,
                         string.Format(CultureInfo.CurrentCulture, Resources.WarningTriedToGiveNothing,
                         nameof(ModelID.None),
                         nameof(InventoryCollection)));
            if (itemID == ModelID.None)
            {
                return 0;
            }
            Precondition.MustBePositive(howMany, nameof(howMany));

            var remainder = howMany;
            // If this is happening during deserialization, assume the stack max was respected during serialization.
            var stackMax = All.CollectionsHaveBeenInitialized
                ? All.Items?.GetOrNull<ItemModel>(itemID)?.StackMax ?? ItemModel.DefaultStackMax
                : ItemModel.DefaultStackMax;

            while (remainder > 0)
            {
                var slotToAddTo = Slots.Find(slot => slot.ItemID == itemID
                                                  && slot.Count < stackMax);
                if (slotToAddTo is null)
                {
                    // If there are no slots of the item type with room, try to make a new one.
                    if (Slots.Count < Capacity)
                    {
                        // If there is room for another slot, make one and add it.
                        slotToAddTo = new InventorySlot(itemID, 1);
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
        /// <param name="slot">The slot to take.</param>
        /// <returns>
        /// If everything was removed successfully, <c>0</c>;
        /// otherwise, the number of items that could not be removed because the <see cref="InventoryCollection"/> did not have any more.
        /// </returns>
        public int Take(InventorySlot slot)
            => Take(slot?.ItemID ?? ModelID.None, slot?.Count ?? 0);

        /// <summary>
        /// Removes the given number of the given item, if possible.
        /// </summary>
        /// <param name="itemID">What kind of item to take.</param>
        /// <param name="howMany">How many of the item to take.  Must be positive.</param>
        /// <returns>
        /// If everything was removed successfully, <c>0</c>;
        /// otherwise, the number of items that could not be removed because the <see cref="InventoryCollection"/> did not have any more.
        /// </returns>
        public int Take(ModelID itemID, int howMany)
        {
            Precondition.MustBePositive(howMany, nameof(howMany));

            var remainder = howMany;

            while (remainder > 0)
            {
                var slotToTakeFrom = Slots.Find(slot => slot.ItemID == itemID);
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
        /// <summary>If <c>true</c> the <see cref="InventoryCollection"/> is read-only; if false, it may be mutated.</summary>
        public bool IsReadOnly => false;

        /// <summary>How many <see cref="InventorySlot"/>s are currently occupied.</summary>
        public int Count
            => Slots.Count;

        /// <summary>
        /// Determines whether the <see cref="InventoryCollection"/> contains the given <see cref="InventorySlot"/>.
        /// </summary>
        /// <param name="other">The slot to search for.</param>
        /// <returns><c>true</c> if the slot is found; otherwise, <c>false</c>.</returns>
        [Obsolete("Use InventoryCollection.Has() instead.", true)]
        public bool Contains(InventorySlot other)
            => Has(other);

        /// <summary>
        /// Adds the given <see cref="InventorySlot"/> to the <see cref="InventoryCollection"/>.
        /// </summary>
        /// <remarks>This method should only be used by <see cref="SeriesConverter{TElement, TCollection}"/>.</remarks>
        /// <param name="slot">The slot to add.</param>
        [Obsolete("Use InventoryCollection.Give() instead.")]
        public void Add(InventorySlot slot)
            => Give(slot);

        /// <summary>
        /// Removes all <see cref="InventorySlot"/>s from the <see cref="InventoryCollection"/>.
        /// <remarks>This method does not respect gameplay rules, but forcibly empties the collection.</remarks>
        /// </summary>
        public void Clear()
            => Slots.Clear();

        /// <summary>
        /// Copies the elements of the <see cref="InventoryCollection"/> to an <see cref="System.Array"/>, starting at the given index.
        /// </summary>
        /// <param name="array">The array to copy to.</param>
        /// <param name="arrayIndex">The index at which to begin copying.</param>
        public void CopyTo(InventorySlot[] array, int arrayIndex)
            => Slots.CopyTo(array, arrayIndex);

        /// <summary>
        /// Removes the first occurrence of the given <see cref="InventorySlot"/> from the <see cref="InventoryCollection"/>.
        /// </summary>
        /// <param name="slot">The slot to remove.</param>
        /// <returns><c>False</c> if slot was found but could not be removed; otherwise, <c>true</c>.</returns>
        [Obsolete("Use InventoryCollection.Take() instead.", true)]
        public bool Remove(InventorySlot slot)
            => Take(slot) == 0;

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
        /// <returns>An enumerator that iterates through the inventory collection.</returns>
        public IEnumerator<InventorySlot> GetEnumerator()
            => Slots.GetEnumerator();
        #endregion

        #region IDeeplyCloneable Implementation
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public InventoryCollection DeepClone()
            => new(Slots.ConvertAll(slot => (InventorySlot)slot.DeepClone()), Capacity);
        #endregion

        #region Utilities
        /// <summary>How many individual <see cref="ItemModel"/>s are contained.</summary>
        public int ItemCount
            => Slots.Select(slot => slot.Count).Sum();

        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="InventoryCollection"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"{Count} / {Capacity} Items";
        #endregion
    }
}
