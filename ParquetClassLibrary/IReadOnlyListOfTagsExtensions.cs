using System.Collections.Generic;
using System.Linq;

namespace Parquet
{
    /// <summary>
    /// Extensions to the <see cref="IReadOnlyCollection{T}"/> interface for working with <see cref="ModelTag"/>s.
    /// </summary>
    public static class IReadOnlyListOfTagsExtensions
    {
        /// <summary>
        /// Determines whether this <see cref="IReadOnlyCollection{ModelTag}"/> contains a <see cref="ModelTag"/>
        /// beginning with the given prefix.
        /// </summary>
        /// <param name="inList">The <see cref="IReadOnlyCollection{ModelTag}"/> to search.</param>
        /// <param name="inPrefix">The <see cref="ModelTag"/> prefix to search for.</param>
        /// <returns><c>true</c> if this and the given instance are identical, ignoring case; otherwise, <c>false</c>.</returns>
        /// <remarks>This is a convenience for client code and not used by the library itself.</remarks>
        public static bool ContainsPrefixOrdinalIgnoreCase(this IReadOnlyList<ModelTag> inList, ModelTag inPrefix)
            => inList.Any(tag => tag.StartsWithOrdinalIgnoreCase(inPrefix));

        /// <summary>
        /// Determines whether this <see cref="IReadOnlyCollection{ModelTag}"/> contains the given <see cref="ModelTag"/>.
        /// </summary>
        /// <param name="inList">The <see cref="IReadOnlyCollection{ModelTag}"/> to search.</param>
        /// <param name="inTag">The <see cref="ModelTag"/> to search for.</param>
        /// <returns><c>true</c> if this and the given instance are identical, ignoring case; otherwise, <c>false</c>.</returns>
        /// <remarks>This is a convenience for client code and not used by the library itself.</remarks>
        public static bool ContainsOrdinalIgnoreCase(this IReadOnlyList<ModelTag> inList, ModelTag inTag)
            => inList.Any(tag => tag.EqualsOrdinalIgnoreCase(inTag));
    }
}
