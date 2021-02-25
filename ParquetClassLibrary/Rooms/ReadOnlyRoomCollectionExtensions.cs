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
        /// <param name="inRooms">The current collection of <see cref="Room"/>s.</param>
        /// <param name="inPosition">An in-bounds position to search for a <see cref="Room"/>.</param>
        /// <returns>The specified <see cref="Room"/> if found; otherwise, null.</returns>
        public static Room GetRoomAtOrNull(this IReadOnlyCollection<Room> inRooms, Point2D inPosition)
            => inRooms?.FirstOrDefault(room => room.ContainsPosition(inPosition)) ?? null;

        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="IReadOnlyCollection{Room}"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public static string ToString(this IReadOnlyCollection<Room> inRooms)
            => $"{inRooms?.Count ?? 0} {nameof(Rooms)}";
    }
}
