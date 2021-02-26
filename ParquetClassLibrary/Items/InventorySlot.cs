using System;
using System.Diagnostics;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Parquet.Properties;

namespace Parquet.Items
{
    /// <summary>
    /// Allows multiple copies of a given <see cref="ItemModel"/> to be grouped together in an <see cref="InventoryCollection"/>.
    /// Instances of this class are mutable during play.
    /// </summary>
    public class InventorySlot : Status<ItemModel>
    {
        #region Class Defaults
        /// <summary>A value to use in place of an uninitialized <see cref="InventoryCollection"/>.</summary>
        public static InventorySlot Empty { get; } = new InventorySlot();
        #endregion

        #region Characteristics
        /// <summary>What <see cref="ItemModel"/>s are stored in this slot.</summary>
        public ModelID ItemID { get; }

        /// <summary>How many instances of the items are stores in this slot.</summary>
        public int Count { get; private set; }

        /// <summary>How many of the item may share this slot, cached.</summary>
        private int StackMax
            => All.CollectionsHaveBeenInitialized
                ? All.Items?.GetOrNull<ItemModel>(ItemID)?.StackMax ?? ItemModel.DefaultStackMax
                : ItemModel.DefaultStackMax;
        #endregion

        #region Initialization
        /// <summary>
        /// Creates a sham slot for serialization purposes.
        /// </summary>
        public InventorySlot()
        {
            ItemID = ModelID.None;
            Count = 1;
        }

        /// <summary>
        /// Creates a new slot to store the given item type.
        /// </summary>
        /// <param name="inItemToStore">
        /// The <see cref="ModelID"/> corresponding to the item being stored here.
        /// Must be in-range and not <see cref="ModelID.None"/>.
        /// </param>
        /// <param name="inHowMany">How many of the item to store initially.  Must be positive.</param>
        public InventorySlot(ModelID inItemToStore, int inHowMany = 1)
        {
            Precondition.IsNotNone(inItemToStore, nameof(inItemToStore));
            Precondition.IsInRange(inItemToStore, All.ItemIDs, nameof(inItemToStore));
            Precondition.MustBePositive(inHowMany, nameof(inHowMany));
            Debug.Assert(inItemToStore != ModelID.None, string.Format(CultureInfo.CurrentCulture, Resources.WarningTriedToStoreNothing,
                                                                      nameof(inItemToStore), nameof(InventorySlot)));


            ItemID = inItemToStore;
            Count = inHowMany;
        }
        #endregion

        #region Access
        /// <summary>
        /// Increases the number of items stored by the given amount.
        /// </summary>
        /// <param name="inHowMany">How many of the item to give.  Must be positive.</param>
        /// <returns>The number of items still needing to be stored if this stack is full.</returns>
        public int Give(int inHowMany = 1)
        {
            Precondition.MustBePositive(inHowMany, nameof(inHowMany));

            var remainder = 0;
            var total = Count + inHowMany;
            if (total > StackMax)
            {
                Count = StackMax;
                remainder = total - StackMax;
            }
            else
            {
                Count += inHowMany;
            }

            return remainder;
        }

        /// <summary>
        /// Decreases the number of items stored by the given amount.
        /// </summary>
        /// <param name="inHowMany">How many of the item to take.  Must be positive.</param>
        /// <returns>
        /// The number of items still needing to be removed from another
        /// <see cref="InventorySlot"/> once this one is emptied.
        /// </returns>
        public int Take(int inHowMany = 1)
        {
            Precondition.MustBePositive(inHowMany, nameof(inHowMany));

            var remainder = 0;
            var needed = Count - inHowMany;
            if (needed < 0)
            {
                Count = 0;
                // Return the remainder as a positive number.
                remainder = needed * -1;
            }
            else
            {
                Count -= inHowMany;
            }

            return remainder;
        }
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="InventorySlot"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public override int GetHashCode()
            => (ItemID, Count).GetHashCode();

        /// <summary>
        /// Determines whether the specified status is equal to the current status.
        /// </summary>
        /// <param name="inStatus">The status to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals<T>(T inStatus)
            => inStatus is InventorySlot slot
            && ItemID == slot.ItemID
            && Count == slot.Count;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="InventorySlot"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="InventorySlot"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is InventorySlot slot
            && Equals(slot);

        /// <summary>
        /// Determines whether a specified instance of <see cref="InventorySlot"/> is equal to another specified instance of <see cref="InventorySlot"/>.
        /// </summary>
        /// <param name="inStatus1">The first <see cref="InventorySlot"/> to compare.</param>
        /// <param name="inStatus2">The second <see cref="InventorySlot"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(InventorySlot inStatus1, InventorySlot inStatus2)
            => inStatus1?.Equals(inStatus2) ?? inStatus2?.Equals(inStatus1) ?? true;

        /// <summary>
        /// Determines whether a specified instance of <see cref="InventorySlot"/> is not equal to another specified instance of <see cref="InventorySlot"/>.
        /// </summary>
        /// <param name="inStatus1">The first <see cref="InventorySlot"/> to compare.</param>
        /// <param name="inStatus2">The second <see cref="InventorySlot"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(InventorySlot inStatus1, InventorySlot inStatus2)
            => !(inStatus1 == inStatus2);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static InventorySlot ConverterFactory { get; } = new InventorySlot();

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public override string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => inValue is InventorySlot slot
                ? $"{slot.ItemID}{Delimiters.InternalDelimiter}" +
                  $"{slot.Count}"
                : Logger.DefaultWithConvertLog(inValue?.ToString() ?? "null", nameof(InventorySlot), nameof(Empty));

        /// <summary>
        /// Converts the given <see cref="string"/> to an <see cref="object"/> as deserialization.
        /// </summary>
        /// <param name="inText">The text to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public override object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            if (string.IsNullOrEmpty(inText)
                || string.Compare(nameof(Empty), inText, StringComparison.OrdinalIgnoreCase) == 0
                || string.Compare(nameof(ModelID.None), inText, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return Logger.DefaultWithConvertLog(inText, nameof(InventorySlot), Empty);
            }

            var parameterText = inText.Split(Delimiters.InternalDelimiter);

            var id = (ModelID)ModelID.ConverterFactory.ConvertFromString(parameterText[0], inRow, inMemberMapData);
            var count = int.TryParse(parameterText[1], All.SerializedNumberStyle, CultureInfo.InvariantCulture, out var temp)
                ? temp
                : Logger.DefaultWithParseLog(parameterText[1], nameof(InventorySlot), 1);

            return new InventorySlot(id, count);
        }
        #endregion

        #region IDeeplyCloneable Implementation
        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same characteristics as the current instance.</returns>
        public override T DeepClone<T>()
            => new InventorySlot(ItemID, Count) as T;
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="InventorySlot"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"{Count} {ItemID}";
        #endregion
    }
}
