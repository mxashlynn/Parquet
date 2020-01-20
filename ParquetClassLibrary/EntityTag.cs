using System;
using System.Collections.Generic;
using ParquetClassLibrary.Serialization;
using ParquetClassLibrary.Utilities;

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
    public class EntityTag : IComparable<EntityTag>
    {
        /// <summary>Indicates the lack of any <see cref="EntityTag"/>s.</summary>
        public static readonly EntityTag None = string.Empty;

        /// <summary>Backing type for the <see cref="EntityTag"/>.</summary>
        private string tagName = "";

        /// <summary>Text elements that are not permitted in an <see cref="EntityTag"/>.</summary>
        private static List<string> Delimiters = new List<string> { Serializer.PrimaryDelimiter, Serializer.SecondaryDelimiter };

        #region Implicit Conversion To/From Underlying Type
        /// <summary>
        /// Enables <see cref="EntityTag"/>s to be treated as their backing type.
        /// </summary>
        /// <param name="inValue">
        /// Any valid tag value.
        /// A string containing <see cref="Serializer.PrimaryDelimiter"/> or <see cref=Serializer.SecondaryDelimiter"/> is not a valid tag value.
        /// </param>
        /// <returns>The given value as a tag.</returns>
        public static implicit operator EntityTag(string inValue)
        {
            Precondition.DoesNotContain(inValue, Delimiters, nameof(EntityTag));
            return new EntityTag { tagName = inValue };
        }

        /// <summary>
        /// Enables <see cref="EntityTag"/>s to be treated as their backing type.
        /// </summary>
        /// <param name="inTag">Any tag.</param>
        /// <returns>The tag's value.</returns>
        public static implicit operator string(EntityTag inTag)
            => inTag?.tagName ?? "";
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
            => string.Compare(tagName, inTag?.tagName ?? "", StringComparison.Ordinal);
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see langword="string"/> that represents the current <see cref="EntityTag"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => tagName;
        #endregion
    }
}
