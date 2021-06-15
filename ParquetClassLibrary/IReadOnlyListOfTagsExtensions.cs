using System.Collections.Generic;
using System.Linq;

namespace Parquet
{
    /// <summary>
    /// Extensions to the <see cref="IReadOnlyList{T}"/> interface for working with <see cref="ModelTag"/>s.
    /// </summary>
    public static class IReadOnlyListOfTagsExtensions
    {
        /// <summary>
        /// Determines whether this <see cref="IReadOnlyList{ModelTag}"/> contains a <see cref="ModelTag"/>
        /// beginning with the given prefix.
        /// </summary>
        /// <param name="collection">The <see cref="IReadOnlyList{ModelTag}"/> to search.</param>
        /// <param name="prefix">The <see cref="ModelTag"/> prefix to search for.</param>
        /// <returns><c>true</c> if this and the given instance are identical, ignoring case; otherwise, <c>false</c>.</returns>
        /// <remarks>This is a convenience for client code and not used by the library itself.</remarks>
        public static bool ContainsPrefixOrdinalIgnoreCase(this IReadOnlyList<ModelTag> collection, ModelTag prefix)
            => collection.Any(tag => tag.StartsWithOrdinalIgnoreCase(prefix));

        /// <summary>
        /// Determines whether this <see cref="IReadOnlyList{ModelTag}"/> contains the given <see cref="ModelTag"/>.
        /// </summary>
        /// <param name="collection">The <see cref="IReadOnlyList{ModelTag}"/> to search.</param>
        /// <param name="tag">The <see cref="ModelTag"/> to search for.</param>
        /// <returns><c>true</c> if this and the given instance are identical, ignoring case; otherwise, <c>false</c>.</returns>
        /// <remarks>This is a convenience for client code and not used by the library itself.</remarks>
        public static bool ContainsOrdinalIgnoreCase(this IReadOnlyList<ModelTag> collection, ModelTag tag)
            => collection.Any(aTag => aTag.EqualsOrdinalIgnoreCase(tag));
    }
}
