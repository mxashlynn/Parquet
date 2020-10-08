using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using ParquetClassLibrary.Properties;

namespace ParquetClassLibrary.Items
{
    /// <summary>
    /// Models an item that characters may carry, use, equip, trade, and/or build with.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1710:Identifiers should have correct suffix",
                                                     Justification = "Inventory implies InventorySlotCollection.")]
    public partial class Inventory : IReadOnlyCollection<InventorySlot>
    {
        #region Class Defaults
        /// <summary>A value to use in place of an uninitialized <see cref="Inventory"/>.</summary>
        public static Inventory Empty { get; } = new Inventory();
        #endregion

        #region Characteristics
        /// <summary>The internal collection mechanism.</summary>
        private List<InventorySlot> Slots { get; set; }

        /// <summary>How many <see cref="InventorySlot"/>s exits.</summary>
        public int Capacity { get; private set; }
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
            : this(1) { }

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
            foreach (var slot in inSlots)
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
            foreach (var slot in inItems)
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
            foreach (var slot in inSlots)
            {
                result &= Has(slot.ItemID, slot.Count);
            }
            return result;
        }

        /// <summary>
        /// Determines if the <see cref="Inventory"/> contains the given <see cref="InventorySlot"/>.
        /// </summary>
        /// <param name="inSlot">The slot to check for.  Cannot be null.</param>
        /// <returns><c>true</c> if everything was found; otherwise, <c>false</c>.</returns>
        public bool Has(InventorySlot inSlot)
        {
            Precondition.IsNotNull(inSlot, nameof(inSlot));
            return Has(inSlot.ItemID, inSlot.Count);
        }

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
        #endregion

        #region IReadOnlyCollection Implementation
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
        /// Exposes an <see cref="IEnumerator"/> to support simple iteration.
        /// </summary>
        /// <remarks>Used by LINQ. No accessibility modifiers are valid in this context.</remarks>
        /// <returns>An enumerator.</returns>
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
        /// Creates a new instance with the same characteristics as the current instance.
        /// </summary>
        /// <returns>That newly allocated instance.</returns>
        public Inventory Clone()
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
