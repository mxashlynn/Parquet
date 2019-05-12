using System;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary
{
    /// <summary>
    /// Models the category and amount of an <see cref="Entity"/> from a recipe, e.g. <see cref="Crafting.CraftingRecipe"/>
    /// or <see cref="Rooms.RoomRecipe"/>.  The <see cref="RecipeElement"/> may either be consumed as an ingredient
    /// or returned as the final product.
    /// </summary>
    public struct RecipeElement : IEquatable<RecipeElement>
    {
        /// <summary>Indicates the lack of any <see cref="RecipeElement"/>s.</summary>
        public static readonly RecipeElement None = new RecipeElement(EntityTag.None, 1);

        /// <summary>An <see cref="EntityTag"/> describing the <see cref="Item"/>.</summary>
        public EntityTag ItemTag { get; }

        /// <summary>The number of <see cref="Item"/>s.</summary>
        public int ItemAmount { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeElement"/> struct.
        /// </summary>
        /// <param name="in_itemTag">An <see cref="EntityTag"/> describing the <see cref="Item"/>.</param>
        /// <param name="in_itemAmount">In amount of the <see cref="Item"/>.  Must be positive.</param>
        public RecipeElement(EntityTag in_itemTag, int in_itemAmount)
        {
            Precondition.MustBePositive(in_itemAmount, nameof(in_itemAmount));

            ItemTag = in_itemTag;
            ItemAmount = in_itemAmount;
        }

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for an <see cref="RecipeElement"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public override int GetHashCode()
            => (ItemTag, ItemAmount).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="RecipeElement"/> is equal to the current <see cref="RecipeElement"/>.
        /// </summary>
        /// <param name="in_element">The <see cref="RecipeElement"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(RecipeElement in_element)
            => in_element.ItemTag == ItemTag && in_element.ItemAmount == ItemAmount;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="RecipeElement"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="RecipeElement"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        // ReSharper disable once InconsistentNaming
        public override bool Equals(object obj)
            => obj is RecipeElement element && Equals(element);

        /// <summary>
        /// Determines whether a specified instance of <see cref="RecipeElement"/> is equal to another specified instance of <see cref="Entity"/>.
        /// </summary>
        /// <param name="in_element1">The first <see cref="RecipeElement"/> to compare.</param>
        /// <param name="in_element2">The second <see cref="RecipeElement"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(RecipeElement in_element1, RecipeElement in_element2)
            => in_element1.ItemTag == in_element2.ItemTag && in_element1.ItemAmount == in_element2.ItemAmount;

        /// <summary>
        /// Determines whether a specified instance of <see cref="RecipeElement"/> is not equal to another specified instance of <see cref="RecipeElement"/>.
        /// </summary>
        /// <param name="in_element1">The first <see cref="RecipeElement"/> to compare.</param>
        /// <param name="in_element2">The second <see cref="RecipeElement"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(RecipeElement in_element1, RecipeElement in_element2)
            => in_element1.ItemTag != in_element2.ItemTag || in_element1.ItemAmount != in_element2.ItemAmount;
        #endregion

        #region Utility Methods
        /// <summary>
        /// Returns a <see langword="string"/> that represents the current <see cref="RecipeElement"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"{ItemAmount} of {ItemTag}";
        #endregion
    }
}
