using System.Collections.Generic;
using ParquetClassLibrary.Serialization;

namespace ParquetClassLibrary
{
    /// <summary>
    /// Provides extension methods to <see cref="IReadOnlyList"/>s of <see cref="EntityTag"/>.
    /// </summary>
    internal static class IReadOnlyListEntityTagExtensions
    {
        /// <summary>Concatenates all contained <see cref="EntityTag"/>s into a single <see langword="string"/>.</summary>
        /// <param name="inInt">Integer to normalize.</param>
        /// <param name="inLowerBound">The lowest valid value for the integer.</param>
        /// <param name="inUpperBound">The highest valid value for the integer.</param>
        /// <returns>The integer, normalized.</returns>
        public static string JoinAll(this IReadOnlyList<EntityTag> inList)
            => string.Join(Serializer.SecondaryDelimiter, inList);
    }
}
