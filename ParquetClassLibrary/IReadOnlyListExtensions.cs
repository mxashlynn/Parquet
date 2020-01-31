using System.Collections.Generic;
using ParquetClassLibrary.Serialization;

namespace ParquetClassLibrary
{
    /// <summary>
    /// Provides extension methods to <see cref="IReadOnlyList"/>s of <see cref="EntityTag"/>.
    /// </summary>
    // TODO Make this internal after runner test.
    public static class IReadOnlyListExtensions
    {
        /// <summary>Concatenates all contained <see cref="EntityTag"/>s into a single <see langword="string"/>.</summary>
        /// <param name="inList">The list to concatenate.</param>
        /// <returns>The concatendated list.</returns>
        public static string JoinAll(this IReadOnlyList<EntityTag> inList)
            => string.Join(Serializer.SecondaryDelimiter, inList);

        /// <summary>Concatenates all contained <see cref="EntityID"/>s into a single <see langword="string"/>.</summary>
        /// <param name="inList">The list to concatenate.</param>
        /// <returns>The concatendated list.</returns>
        public static string JoinAll(this IReadOnlyList<EntityID> inList)
            => string.Join(Serializer.SecondaryDelimiter, inList);
    }
}