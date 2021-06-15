using System;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Parquet.Items;

namespace Parquet
{
    /// <summary>
    /// Models the category and amount of a <see cref="Model"/> from a recipe, e.g. <see cref="Crafts.CraftingRecipe"/>
    /// or <see cref="Rooms.RoomRecipe"/>.  The <see cref="RecipeElement"/> may either be consumed as an ingredient
    /// or returned as the final product.
    /// </summary>
    /// <remarks>
    /// The pairing of ElementTag with an ElementAmount achieves two ends:
    /// - It allows multiple element instances to be required without storing and counting multiple objects representing that element.
    /// - It allows various Models to be used interchangeably for the same recipe purpose; see <see cref="ModelTag"/>.
    /// </remarks>
    public sealed class RecipeElement : IEquatable<RecipeElement>, ITypeConverter
    {
        #region Class Defaults
        /// <summary>Indicates the lack of any <see cref="RecipeElement"/>s.</summary>
        public static readonly RecipeElement None = new();
        #endregion

        #region Characteristics
        /// <summary>The number of <see cref="ItemModel"/>s.</summary>
        public int ElementAmount { get; }

        /// <summary>A <see cref="ModelTag"/> describing the <see cref="ItemModel"/>.</summary>
        public ModelTag ElementTag { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes an empty instance of <see cref="RecipeElement"/> with default values.
        /// </summary>
        /// <remarks>
        /// Useful primarily in the context of serialization.
        /// </remarks>
        public RecipeElement()
        : this(1, ModelTag.None) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecipeElement"/> class.
        /// </summary>
        /// <param name="elementAmount">The amount of the element.  Must be positive.</param>
        /// <param name="elementTag">A <see cref="ModelTag"/> describing the element.</param>
        public RecipeElement(int elementAmount, ModelTag elementTag)
        {
            Precondition.MustBePositive(elementAmount, nameof(elementAmount));

            ElementAmount = elementAmount;
            ElementTag = elementTag;
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
        /// <param name="other">The <see cref="RecipeElement"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(RecipeElement other)
            => other?.ElementTag == ElementTag
            && other?.ElementAmount == ElementAmount;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="RecipeElement"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="RecipeElement"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is RecipeElement element
            && Equals(element);

        /// <summary>
        /// Determines whether a specified instance of <see cref="RecipeElement"/> is equal to another specified instance of <see cref="RecipeElement"/>.
        /// </summary>
        /// <param name="element1">The first <see cref="RecipeElement"/> to compare.</param>
        /// <param name="element2">The second <see cref="RecipeElement"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(RecipeElement element1, RecipeElement element2)
            => element1?.Equals(element2) ?? element2?.Equals(element1) ?? true;

        /// <summary>
        /// Determines whether a specified instance of <see cref="RecipeElement"/> is not equal to another specified instance of <see cref="RecipeElement"/>.
        /// </summary>
        /// <param name="element1">The first <see cref="RecipeElement"/> to compare.</param>
        /// <param name="element2">The second <see cref="RecipeElement"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(RecipeElement element1, RecipeElement element2)
            => !(element1 == element2);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static RecipeElement ConverterFactory { get; } = None;

        /// <summary>
        /// Converts the given record column to <see cref="RecipeElement"/>.
        /// </summary>
        /// <param name="text">The record column to convert to an object.</param>
        /// <param name="row">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="memberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
        /// <returns>The <see cref="ModelTag"/> created from the record column.</returns>
        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrEmpty(text)
                || string.Compare(nameof(None), text, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return None;
            }

            var elementSplitText = text.Split(Delimiters.InternalDelimiter);

            var elementAmountText = elementSplitText[0];
            var elementTagText = elementSplitText[1];

            var amount = int.TryParse(elementAmountText, All.SerializedNumberStyle, CultureInfo.InvariantCulture, out var temp)
                ? temp
                : Logger.DefaultWithParseLog(elementAmountText, nameof(ElementAmount), 0);
            var tag = (ModelTag)ModelTag.None.ConvertFromString(elementTagText, row, memberMapData);

            return new RecipeElement(amount, tag);
        }

        /// <summary>
        /// Converts the given <see cref="RecipeElement"/> to a record column.
        /// </summary>
        /// <param name="value">The instance to convert.</param>
        /// <param name="row">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="memberMapData">The <see cref="MemberMapData"/> for the member being serialized.</param>
        /// <returns>The <see cref="RecipeElement"/> as a CSV record.</returns>
        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
            => value is RecipeElement recipeElement
                ? recipeElement == None
                    ? nameof(None)
                    : $"{recipeElement.ElementAmount}{Delimiters.InternalDelimiter}" +
                      $"{recipeElement.ElementTag}"
                : Logger.DefaultWithConvertLog(value?.ToString() ?? "null", nameof(RecipeElement), nameof(None));
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="RecipeElement"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"{ElementAmount} of {ElementTag}";
        #endregion
    }
}
