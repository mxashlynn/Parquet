using System;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace ParquetClassLibrary
{
    /// <summary>
    /// Identifies functional characteristics of <see cref="Model"/>s,
    /// such as their role in <see cref="Crafts.CraftingRecipe"/>s or
    /// <see cref="Biomes.BiomeModel"/>s.
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
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design",
        "CA1036:Override methods on comparable types",
        Justification = "{ModelTag is designed to operate like a string, and string does not implement these operators.")]
    public class ModelTag : IComparable<ModelTag>, ITypeConverter
    {
        #region Class Defaults
        /// <summary>Indicates the lack of any <see cref="ModelTag"/>s.</summary>
        public static readonly ModelTag None = string.Empty;
        #endregion

        #region Characteristics
        /// <summary>Backing type for the <see cref="ModelTag"/>.</summary>
        private string tagContent = "";
        #endregion

        #region Implicit Conversion To/From Underlying Type
        /// <summary>
        /// Enables <see cref="ModelTag"/>s to be treated as their backing type.
        /// </summary>
        /// <param name="inValue">Any valid tag value.  Invalid values will be sanitized.</param>
        /// <returns>The given value as a tag.</returns>
        /// <seealso cref="Sanitize(string)"/>
        public static implicit operator ModelTag(string inValue)
            => new ModelTag { tagContent = inValue };

        /// <summary>
        /// Enables <see cref="ModelTag"/>s to be treated as their backing type.
        /// </summary>
        /// <param name="inTag">Any tag.</param>
        /// <returns>The tag's value.</returns>
        public static implicit operator string(ModelTag inTag)
            => inTag?.tagContent ?? "";
        #endregion

        #region IComparable Implementation
        /// <summary>
        /// Enables <see cref="ModelTag"/>s to be compared one another.
        /// </summary>
        /// <param name="inTag">Any valid <see cref="ModelTag"/>.</param>
        /// <returns>
        /// A value indicating the relative ordering of the <see cref="ModelTag"/>s being compared.
        /// The return value has these meanings:
        ///     Less than zero indicates that the current instance precedes the given <see cref="ModelTag"/> in the sort order.
        ///     Zero indicates that the current instance occurs in the same position in the sort order as the given <see cref="ModelTag"/>.
        ///     Greater than zero indicates that the current instance follows the given <see cref="ModelTag"/> in the sort order.
        /// </returns>
        public int CompareTo(ModelTag inTag)
            => string.Compare(tagContent, inTag?.tagContent ?? "", StringComparison.Ordinal);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static ModelTag ConverterFactory { get; } =
            None;

        /// <summary>
        /// Converts the given <see langword="string"/> to a <see cref="StrikePanel"/>.
        /// </summary>
        /// <param name="inText">The <see langword="string"/> to convert to an object.</param>
        /// <param name="inRow">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="inMemberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
        /// <returns>The <see cref="StrikePanel"/> created from the <see langword="string"/>.</returns>
        public object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
            => (ModelTag)inText?.Trim(inRow?.Configuration.Escape ?? '"');

        /// <summary>
        /// Converts the given <see cref="ModelTag"/> to a record column.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="inMemberMapData">The <see cref="MemberMapData"/> for the member being serialized.</param>
        /// <returns>The <see cref="StrikePanel"/> as a CSV record.</returns>
        public string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => inValue is ModelTag tag
                ? $"{inRow?.Configuration.Escape ?? '"'}{(string)tag}{inRow?.Configuration.Escape ?? '"'}"
                : throw new ArgumentException($"Could not serialize '{inValue}' as {nameof(ModelTag)}.");
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see langword="string"/> that represents the current <see cref="ModelTag"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => tagContent;
        #endregion
    }
}
