using System;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Crafting
{
    /// <summary>
    /// Models the identity and amount of an <see cref="Item"/> from a <see cref="CraftingRecipe"/>.
    /// The <see cref="CraftingElement"/> may be either used as an ingredient or produced as the final product.
    /// </summary>
    public struct CraftingElement : IEquatable<CraftingElement>
    {
        public static readonly CraftingElement None = new CraftingElement(EntityID.None, 1);

        /// <summary>The type of <see cref="Item"/>.</summary>
        public EntityID ItemID { get; }

        /// <summary>The number of <see cref="Item"/>s.</summary>
        public int ItemAmount { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CraftingElement"/> struct.
        /// </summary>
        /// <param name="in_itemID">The <see cref="EntityID"/> representing the <see cref="Item"/>.  Must be a valid, defined <see cref="All.ItemIDs"/>.</param>
        /// <param name="in_itemAmount">In amount of the <see cref="Item"/>.  Must be positive.</param>
        public CraftingElement(EntityID in_itemID, int in_itemAmount)
        {
            Precondition.IsInRange(in_itemID, All.ItemIDs, nameof(in_itemID));
            Precondition.MustBePositive(in_itemAmount, nameof(in_itemAmount));

            ItemID = in_itemID;
            ItemAmount = in_itemAmount;
        }

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for an <see cref="CraftingElement"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public override int GetHashCode()
            => (ItemID, ItemAmount).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="CraftingElement"/> is equal to the current <see cref="CraftingElement"/>.
        /// </summary>
        /// <param name="in_element">The <see cref="CraftingElement"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(CraftingElement in_element)
            => in_element.ItemID == ItemID && in_element.ItemAmount == ItemAmount;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="CraftingElement"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="CraftingElement"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        // ReSharper disable once InconsistentNaming
        public override bool Equals(object obj)
            => obj is CraftingElement element && Equals(element);

        /// <summary>
        /// Determines whether a specified instance of <see cref="CraftingElement"/> is equal to another specified instance of <see cref="Entity"/>.
        /// </summary>
        /// <param name="in_element1">The first <see cref="CraftingElement"/> to compare.</param>
        /// <param name="in_element2">The second <see cref="CraftingElement"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(CraftingElement in_element1, CraftingElement in_element2)
            => in_element1.ItemID == in_element2.ItemID && in_element1.ItemAmount == in_element2.ItemAmount;

        /// <summary>
        /// Determines whether a specified instance of <see cref="CraftingElement"/> is not equal to another specified instance of <see cref="CraftingElement"/>.
        /// </summary>
        /// <param name="in_element1">The first <see cref="CraftingElement"/> to compare.</param>
        /// <param name="in_element2">The second <see cref="CraftingElement"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(CraftingElement in_element1, CraftingElement in_element2)
            => in_element1.ItemID != in_element2.ItemID || in_element1.ItemAmount != in_element2.ItemAmount;
        #endregion

        #region Utility Methods
        /// <summary>
        /// Returns a <see langword="string"/> that represents the current <see cref="CraftingElement"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"{ItemAmount} of {(All.Items.Contains(ItemID) ? All.Items.Get(ItemID).Name : ItemID.ToString())}.";
        #endregion
    }
}
