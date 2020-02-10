using System;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace ParquetClassLibrary
{
    /// <summary>
    /// Identifies functional characteristics of <see cref="EntityModel"/>s,
    /// such as their role in <see cref="Crafts.CraftingRecipe"/>s or
    /// <see cref="Biomes.BiomeModel"/>s.
    /// </summary>
    /// <remarks>
    /// The intent is that definitional narrative and mechanical features
    /// of each game <see cref="EntityModel"/> be taggable.
    /// <para />
    /// This means that more than one <see cref="EntityTag"/> can coexist
    /// on a specific <see cref="EntityModel"/> within the same entity
    /// category (parquets, beings, etc.).
    /// <para />
    /// This allows for flexible definition of EntityModels such that a loose
    /// category of models may answer a particular functional need; e.g.,
    /// "any parquet that has the Volcanic tag" or "any item that is a Key".
    /// </remarks>
    /// <seealso cref="EntityID"/>
    /// <seealso cref="All"/>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design",
        "CA1036:Override methods on comparable types",
        Justification = "EntityTag is designed to operate like a string, and string does not implement these operators.")]
    public class EntityTag : IComparable<EntityTag>, ITypeConverter
    {
        #region Class Defaults
        /// <summary>Indicates the lack of any <see cref="EntityTag"/>s.</summary>
        public static readonly EntityTag None = string.Empty;

        /// <summary>Replaces any <see cref="Rules.Delimiters"/> in <see cref="EntityTag"/>s.</summary>
        public const string SanitarySeparator = "/";
        #endregion

        #region Characteristics
        /// <summary>Backing type for the <see cref="EntityTag"/>.</summary>
        private string tagContent = "";
        #endregion

        #region Implicit Conversion To/From Underlying Type
        /// <summary>
        /// Enables <see cref="EntityTag"/>s to be treated as their backing type.
        /// </summary>
        /// <param name="inValue">Any valid tag value.  Invalid values will be sanitized.</param>
        /// <returns>The given value as a tag.</returns>
        /// <seealso cref="Sanitize(string)"/>
        public static implicit operator EntityTag(string inValue)
            => new EntityTag { tagContent = Sanitize(inValue) };

        /// <summary>
        /// Enables <see cref="EntityTag"/>s to be treated as their backing type.
        /// </summary>
        /// <param name="inTag">Any tag.</param>
        /// <returns>The tag's value.</returns>
        public static implicit operator string(EntityTag inTag)
            => inTag?.tagContent ?? "";
        #endregion

        #region Validation
        /// <summary>
        /// Sanitizes a <see langword="string"/> to be used as an <see cref="EntityTag"/>.
        /// </summary>
        /// <remarks>
        /// Instances of any <see cref="Rules.Delimiters"/> will be replaced with <see cref="SanitarySeparator"/>.
        /// </remarks>
        /// <param name="inValue">The string to sanitize.</param>
        /// <returns>The sanitized version.</returns>
        public static string Sanitize(string inValue)
            => string.IsNullOrEmpty(inValue)
                ? ""
                : inValue.Replace(Rules.Delimiters.SecondaryDelimiter, SanitarySeparator, StringComparison.InvariantCultureIgnoreCase)
                         .Replace(Rules.Delimiters.InternalDelimiter, SanitarySeparator, StringComparison.InvariantCultureIgnoreCase)
                         .Replace(Rules.Delimiters.ElementDelimiter, SanitarySeparator, StringComparison.InvariantCultureIgnoreCase);
        #endregion

        #region IComparable Implementation
        /// <summary>
        /// Enables <see cref="EntityTag"/>s to be compared one another.
        /// </summary>
        /// <param name="inTag">Any valid <see cref="EntityTag"/>.</param>
        /// <returns>
        /// A value indicating the relative ordering of the <see cref="EntityTag"/>s being compared.
        /// The return value has these meanings:
        ///     Less than zero indicates that the current instance precedes the given <see cref="EntityTag"/> in the sort order.
        ///     Zero indicates that the current instance occurs in the same position in the sort order as the given <see cref="EntityTag"/>.
        ///     Greater than zero indicates that the current instance follows the given <see cref="EntityTag"/> in the sort order.
        /// </returns>
        public int CompareTo(EntityTag inTag)
            => string.Compare(tagContent, inTag?.tagContent ?? "", StringComparison.Ordinal);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static readonly EntityTag ConverterFactory =
            None;

        /// <summary>
        /// Converts the given <see langword="string"/> to a <see cref="StrikePanel"/>.
        /// </summary>
        /// <param name="inText">The <see langword="string"/> to convert to an object.</param>
        /// <param name="inRow">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="inMemberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
        /// <returns>The <see cref="StrikePanel"/> created from the <see langword="string"/>.</returns>
        public object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            if (string.IsNullOrEmpty(inText)
                || string.Compare(nameof(None), inText, StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                return None;
            }

            return (EntityTag)inText;
        }

        /// <summary>
        /// Converts the given <see cref="EntityTag"/> to a record column.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="inMemberMapData">The <see cref="MemberMapData"/> for the member being serialized.</param>
        /// <returns>The <see cref="StrikePanel"/> as a CSV record.</returns>
        public string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => inValue == None || string.IsNullOrEmpty((string)inValue)
                ? nameof(None)
                : (string)inValue;
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see langword="string"/> that represents the current <see cref="EntityTag"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => tagContent;
        #endregion
    }
}
