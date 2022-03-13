using System;
using System.Diagnostics.CodeAnalysis;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace Parquet
{
    /// <summary>
    /// Identifies functional characteristics of <see cref="Model"/>s,
    /// such as their role in <see cref="Crafts.CraftingRecipe"/>s or
    /// <see cref="Biomes.BiomeRecipe"/>s.
    /// </summary>
    /// <remarks>
    /// The intent is that definitional narrative and mechanical features
    /// of each game <see cref="Model"/> be taggable.
    /// <para />
    /// This means that more than one <see cref="ModelTag"/> can coexist
    /// on a specific <see cref="Model"/> within the same model
    /// category (parquets, beings, etc.).
    /// <para />
    /// This allows for flexible definition of Models such that a loose
    /// category of models may answer a particular functional need; e.g.,
    /// "any parquet that has the Volcanic tag" or "any item that is a Key".
    /// </remarks>
    /// <seealso cref="ModelID"/>
    /// <seealso cref="All"/>
    [SuppressMessage("Design", "CA1036:Override methods on comparable types",
                     Justification = "Implementing these operators would prevent ModelTag from operating like a string.")]
    public class ModelTag : IComparable<ModelTag>, ITypeConverter
    {
        #region Class Defaults
        /// <summary>Indicates the lack of any <see cref="ModelTag"/>s.</summary>
        public static readonly ModelTag None = "";
        #endregion

        #region Characteristics
        /// <summary>Backing type for the <see cref="ModelTag"/>.</summary>
        private string tagContent = "";
        #endregion

        #region Implicit Conversion To/From Underlying Type
        /// <summary>
        /// Enables <see cref="ModelTag"/>s to be treated as their backing type.
        /// </summary>
        /// <param name="value">Any valid tag value.  Invalid values will be sanitized.</param>
        /// <returns>The given value as a tag.</returns>
        public static implicit operator ModelTag(string value)
            => new() { tagContent = value };

        /// <summary>
        /// Enables <see cref="ModelTag"/>s to be treated as their backing type.
        /// </summary>
        /// <param name="tag">Any tag.</param>
        /// <returns>The tag's value.</returns>
        public static implicit operator string(ModelTag tag)
            => tag?.tagContent ?? "";
        #endregion

        #region IComparable Implementation
        /// <summary>
        /// Enables <see cref="ModelTag"/>s to be compared one another.
        /// </summary>
        /// <param name="other">Any valid <see cref="ModelTag"/>.</param>
        /// <returns>
        /// A value indicating the relative ordering of the <see cref="ModelTag"/>s being compared.
        /// The return value has these meanings:
        ///     Less than zero indicates that the current instance precedes the given <see cref="ModelTag"/> in the sort order.
        ///     Zero indicates that the current instance occurs in the same position in the sort order as the given <see cref="ModelTag"/>.
        ///     Greater than zero indicates that the current instance follows the given <see cref="ModelTag"/> in the sort order.
        /// </returns>
        public int CompareTo(ModelTag other)
            => string.Compare(tagContent, other?.tagContent ?? "", StringComparison.Ordinal);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static ModelTag ConverterFactory { get; } =
            None;

        /// <summary>
        /// Converts the given <see cref="string"/> to a <see cref="ModelTag"/>.
        /// </summary>
        /// <param name="text">The <see cref="string"/> to convert to an object.</param>
        /// <param name="row">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="memberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
        /// <returns>The <see cref="ModelTag"/> created from the <see cref="string"/>.</returns>
        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
            => string.Equals(nameof(None), text, StringComparison.OrdinalIgnoreCase)
                ? (ModelTag)""
                : (ModelTag)text;

        /// <summary>
        /// Converts the given <see cref="ModelTag"/> to a record column.
        /// </summary>
        /// <param name="value">The instance to convert.</param>
        /// <param name="row">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="memberMapData">The <see cref="MemberMapData"/> for the member being serialized.</param>
        /// <returns>The <see cref="ModelTag"/> as a CSV record.</returns>
        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
            => value is ModelTag tag
                ? string.IsNullOrEmpty(tag)
                    ? nameof(None)
                    : (string)tag
                : Logger.DefaultWithConvertLog(value?.ToString() ?? "null", nameof(ModelTag), "");
        #endregion

        #region Utilities
        /// <summary>
        /// Determines whether the beginning of this <see cref="ModelTag"/> instance matches the given ModelTag.
        /// </summary>
        /// <param name="prefix">The <see cref="ModelTag"/> to check against the beginning of the current ModelTag.</param>
        /// <returns><c>true</c> if this instance begins with the given prefix; otherwise, <c>false</c>.</returns>
        public bool StartsWithOrdinalIgnoreCase(ModelTag prefix)
            => tagContent.StartsWith(prefix, StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Determines whether the this <see cref="ModelTag"/> instance matches the given ModelTag.
        /// </summary>
        /// <param name="tag">The <see cref="ModelTag"/> to check against the current ModelTag.</param>
        /// <returns><c>true</c> if this and the given instance are identical, ignoring case; otherwise, <c>false</c>.</returns>
        public bool EqualsOrdinalIgnoreCase(ModelTag tag)
            => string.Equals(tagContent, tag?.tagContent ?? "", StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="ModelTag"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => tagContent;
        #endregion
    }
}
