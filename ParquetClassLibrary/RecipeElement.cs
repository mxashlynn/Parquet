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
    /// <remarks>
    /// The pairing of ElementTag with an ElementAmount achieves two ends:
    ///     1) It allows multiple instances of an element to be required without having to store and count multiple objects representing that element.
    ///     2) It allows various Entities to be used interchangably for the same recipe purpose; see <see cref="EntityTag"/>.
    /// </remarks>
    public readonly struct RecipeElement : IEquatable<RecipeElement>
    {
        /// <summary>Indicates the lack of any <see cref="RecipeElement"/>s.</summary>
        public static readonly RecipeElement None = new RecipeElement(EntityTag.None, 1);

        /// <summary>An <see cref="EntityTag"/> describing the <see cref="Item"/>.</summary>
        public EntityTag ElementTag { get; }

        /// <summary>The number of <see cref="Item"/>s.</summary>
        public int ElementAmount { get; }

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeElement"/> struct.
        /// </summary>
        /// <param name="inElementTag">An <see cref="EntityTag"/> describing the element.</param>
        /// <param name="inElementAmount">The amount of the element.  Must be positive.</param>
        public RecipeElement(EntityTag inElementTag, int inElementAmount)
        {
            Precondition.MustBePositive(inElementAmount, nameof(inElementAmount));

            ElementTag = inElementTag;
            ElementAmount = inElementAmount;
        }
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="RecipeElement"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public override int GetHashCode()
            => (ElementTag, ElementAmount).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="RecipeElement"/> is equal to the current <see cref="RecipeElement"/>.
        /// </summary>
        /// <param name="inElement">The <see cref="RecipeElement"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(RecipeElement inElement)
            => inElement.ElementTag == ElementTag && inElement.ElementAmount == ElementAmount;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="RecipeElement"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="RecipeElement"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is RecipeElement element && Equals(element);

        /// <summary>
        /// Determines whether a specified instance of <see cref="RecipeElement"/> is equal to another specified instance of <see cref="RecipeElement"/>.
        /// </summary>
        /// <param name="inElement1">The first <see cref="RecipeElement"/> to compare.</param>
        /// <param name="inElement2">The second <see cref="RecipeElement"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(RecipeElement inElement1, RecipeElement inElement2)
            => inElement1.ElementTag == inElement2.ElementTag && inElement1.ElementAmount == inElement2.ElementAmount;

        /// <summary>
        /// Determines whether a specified instance of <see cref="RecipeElement"/> is not equal to another specified instance of <see cref="RecipeElement"/>.
        /// </summary>
        /// <param name="inElement1">The first <see cref="RecipeElement"/> to compare.</param>
        /// <param name="inElement2">The second <see cref="RecipeElement"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(RecipeElement inElement1, RecipeElement inElement2)
            => inElement1.ElementTag != inElement2.ElementTag || inElement1.ElementAmount != inElement2.ElementAmount;
        #endregion

        #region Utility Methods
        /// <summary>
        /// Returns a <see langword="string"/> that represents the current <see cref="RecipeElement"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"{ElementAmount} of {ElementTag}";
        #endregion
    }
}
