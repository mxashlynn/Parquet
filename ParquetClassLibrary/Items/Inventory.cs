using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Items
{
    /// <summary>
    /// Models an item that characters may carry, use, equip, trade, and/or build with.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming",
        "CA1710:Identifiers should have correct suffix",
        Justification = "Inventory imples Collection.")]
    public sealed class Inventory : IReadOnlyCollection<InventorySlot>, ITypeConverter
    {
        #region Characteristics
        /// <summary>The internal collection mechanism.</summary>
        private List<InventorySlot> Slots { get; }

        /// <summary>How many <see cref="InventorySlot"/>s exits.</summary>
        public int Capacity { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new empty instance of the <see cref="Inventory"/> class.
        /// </summary>
        /// <param name="inSlots">The <see cref="InventorySlot"/>s to collect.  Cannot be null.</param>
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
        // TODO We might need to make versions of these accessors that work with RecipeElements.

        /// <summary>How many <see cref="InventorySlot"/>s are currently occupied.</summary>
        public int Count { get => Slots.Count; }

        /// <summary>
        /// Determines how many of given type of item is contained in the <see cref="Inventory"/>.
        /// </summary>
        /// <param name="inItems">The item type to check for.  Cannot be <see cref="EntityID.None"/>.</param>
        /// <returns>The number of items of the given type contained.</returns>
        public int Contains(EntityID inItemID)
        {
            Precondition.IsNotNone(inItemID);

            return Slots
                   .Where(slot => slot.ItemID == inItemID)
                   .Sum(slot => slot.Count);
        }

        /// <summary>
        /// Determines if the <see cref="Inventory"/> contains the given items in the given quantities.
        /// </summary>
        /// <param name="inItems">The items to check for.  Cannot be null or empty.</param>
        /// <returns><c>true</c> if everything was found; otherwise, <c>false</c>.</returns>
        public bool Has(IEnumerable<(EntityID, int)> inItems)
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
        /// <param name="inSlot">The slots to check for.  Cannot be null or empty.</param>
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
        public bool Has(EntityID inItemID, int inHowMany = 1)
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
        {
            Precondition.IsNotNull(inSlot);
            return Give(inSlot.ItemID, inSlot.Count);
        }

        /// <summary>
        /// Stores the given number of the given item, if possible.
        /// </summary>
        /// <param name="inItemID">What kind of item to give.</param>
        /// <param name="inHowMany">How many of the item to give.  Must be positive.</param>
        /// <returns>
        /// If everything was stored successfully, <c>0</c>;
        /// otherwise, the number of items that could not be stored because the <see cref="Inventory"/> is full.
        /// </returns>
        public int Give(EntityID inItemID, int inHowMany = 1)
        {
            Precondition.MustBePositive(inHowMany, nameof(inHowMany));

            var stackMax = All.Items.Get<ItemModel>(inItemID).StackMax;
            var remainder = inHowMany;

            while (remainder > 0)
            {
                var slotToAddTo = Slots.Find(slot => slot.ItemID == inItemID && slot.Count < stackMax);
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
        public int Take(InventorySlot inSlot)
        {
            Precondition.IsNotNull(inSlot);
            return Take(inSlot.ItemID, inSlot.Count);
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
        public int Take(EntityID inItemID, int inHowMany = 1)
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

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static Inventory ConverterFactory { get; } = new Inventory(1);

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => null != inValue
            && inValue is Inventory inventory
                ? $"{inventory.Capacity}{Rules.Delimiters.InternalDelimiter}" +
                  $"{SeriesConverter<InventorySlot, List<InventorySlot>>.ConverterFactory.ConvertToString(inventory.Slots, Rules.Delimiters.ElementDelimiter)}"
                : throw new ArgumentException($"Could not serialize {inValue} as {nameof(Inventory)}.");

        /// <summary>
        /// Converts the given <see cref="string"/> to an <see cref="object"/> as deserialization.
        /// </summary>
        /// <param name="text">The text to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            if (string.IsNullOrEmpty(inText)
                || string.Compare(nameof(EntityID.None), inText, StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                throw new ArgumentException($"Could not convert '{inText}' to {nameof(Inventory)}.");
            }

            try
            {
                var numberStyle = inMemberMapData?.TypeConverterOptions?.NumberStyle ?? All.SerializedNumberStyle;
                var cultureInfo = inMemberMapData?.TypeConverterOptions?.CultureInfo ?? All.SerializedCultureInfo;
                var parameterText = inText.Split(Rules.Delimiters.InternalDelimiter);

                var capacity = int.Parse(parameterText[12], numberStyle, cultureInfo);
                var slots = (List<InventorySlot>)SeriesConverter<InventorySlot, List<InventorySlot>>
                    .ConverterFactory.ConvertFromString(parameterText[1], inRow, inMemberMapData, Rules.Delimiters.ElementDelimiter);

                return new Inventory(slots, capacity);
            }
            catch (Exception e)
            {
                throw new FormatException($"Could not parse '{inText}' as {nameof(Inventory)}: {e}");
            }
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see langword="string"/> that represents the current <see cref="Inventory"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"{Count} / {Capacity} Items";
        #endregion
    }
}
