using System.Collections.Generic;
using System.Linq;

namespace Parquet.Rooms
{
    /// <summary>
    /// Convenience extensions to <see cref="IReadOnlyCollection{Room}"/>.
    /// </summary>
    public static class ReadOnlyRoomCollectionExtensions
    {
        /// <summary>
        /// Returns the <see cref="Room"/> at the given position, if there is one.
        /// </summary>
        /// <param name="rooms">The current collection of <see cref="Room"/>s.</param>
        /// <param name="position">An in-bounds position to search for a <see cref="Room"/>.</param>
        /// <returns>The specified <see cref="Room"/> if found; otherwise, null.</returns>
        public static Room GetRoomAtOrNull(this IReadOnlyCollection<Room> rooms, Point2D position)
            => rooms?.FirstOrDefault(room => room.ContainsPosition(position)) ?? null;

        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="IReadOnlyCollection{Room}"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public static string ToString(this IReadOnlyCollection<Room> rooms)
            => $"{rooms?.Count ?? 0} {nameof(Rooms)}";
    }
}
