using System.Collections.Generic;
using System.Linq;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Stubs;

namespace ParquetClassLibrary.Rooms
{
    /// <summary>
    /// Stores an <see cref="Entity"/> collection.
    /// Provides bounds-checking and type-checking against <typeparamref name="ParentType"/>.
    /// </summary>
    /// <remarks>
    /// This generic version is intended to support <see cref="All.Parquets"/> allowing
    /// the collection to store all parquet types but return only the requested subtype.
    /// </remarks>
    public class RoomCollection
    {
        /// <summary>The internal collection mechanism.</summary>
        private IReadOnlyList<Room> Rooms { get; }

        /// <summary>The number of <see cref="Entity"/>s in the <see cref="RoomCollection"/>.</summary>
        public int Count
            => Rooms.Count;

        /// <summary>
        /// Determines whether the <see cref="RoomCollection"/> contains the specified <see cref="Room"/>.
        /// </summary>
        /// <param name="in_room">The <see cref="Room"/> to find.</param>
        /// <returns><c>true</c> if the <see cref="Room"/> was found; <c>false</c> otherwise.</returns>
        public bool Contains(Room in_room)
            => Rooms.Contains(in_room);

        /// <summary>
        /// Returns the <see cref="Room"/> at the given position, if there is one.
        /// </summary>
        /// <param name="in_position">An in-bonds position to search for a <see cref="Room"/>.</param>
        /// <returns>The specified <see cref="Room"/> if found; otherwise, null.</returns>
        public Room GetRoomAt(Vector2Int in_position)
            => Rooms.First(room => room.ContainsPosition(in_position));

        #region Initialization from Map Analysis
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomCollection"/> class.
        /// </summary>
        /// <remarks>Private so that empty <see cref="RoomCollection"/>s are not made in client code.</remarks>
        private RoomCollection(List<Room> in_rooms)
        {
            Rooms = in_rooms;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomCollection"/> class.
        /// </summary>
        public static RoomCollection CreateFromSubregion(ParquetStack[,] in_subregion)
        {
            return new RoomCollection();
        }
        #endregion

        #region Utility Methods
        /// <summary>
        /// Retrieves an enumerator for the <see cref="RoomCollection"/>.
        /// </summary>
        /// <returns>An enumerator that iterates through the collection.</returns>
        public IEnumerator<Room> GetEnumerator()
            => Rooms.GetEnumerator();

        /// <summary>
        /// Returns a <see langword="string"/> that represents the current <see cref="RoomCollection"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"{Rooms.Count} Rooms";
        #endregion
    }

    /// <summary>
    /// Extension methods used in room analysis.
    /// </summary>
    internal static class ParquetStackExtensions
    {
        /// <summary>
        /// A <see cref="ParquetStack"/> is Walkable iff:
        /// 1, It has a <see cref="Floor"/>;
        /// 2, It does not have a <see cref="Block"/>;
        /// 3, It does not have a <see cref="Furnishing"/> that is not <see cref="Furnishing.IsEnclosing"/>.
        /// </summary>
        /// <param name="in_stack">The <see cref="ParquetStack"/> to consider.</param>
        /// <returns><c>true</c>, if the given <see cref="ParquetStack"/> is walkable, <c>false</c> otherwise.</returns>
        internal static bool IsWalkable(this ParquetStack in_stack)
            => in_stack.Floor != EntityID.None
            && in_stack.Block == EntityID.None
            && (!All.Parquets.Get<Furnishing>(in_stack.Furnishing)?.IsEnclosing ?? true);

        /// <summary>
        /// A <see cref="ParquetStack"/> is Enclosing iff:
        /// 1, It has a <see cref="Block"/> that is not <see cref="Block.IsLiquid"/>; or,
        /// 2, It has a <see cref="Furnishing"/> that is <see cref="Furnishing.IsEnclosing"/>.
        /// </summary>
        /// <param name="in_stack">The <see cref="ParquetStack"/> to consider.</param>
        /// <returns><c>true</c>, if the given <see cref="ParquetStack"/> is walkable, <c>false</c> otherwise.</returns>
        internal static bool IsEnclosing(this ParquetStack in_stack)
            => (!All.Parquets.Get<Block>(in_stack.Block)?.IsLiquid ?? false)
            || (All.Parquets.Get<Furnishing>(in_stack.Furnishing)?.IsEnclosing ?? false);

        /// <summary>
        /// A <see cref="ParquetStack"/> is Entry iff:
        /// 1, It is either Walkable or Enclosing; and,
        /// 2, It has a <see cref="Furnishing"/> that is <see cref="Furnishing.IsEntry"/>.
        /// </summary>
        /// <param name="in_stack">The <see cref="ParquetStack"/> to consider.</param>
        /// <returns><c>true</c>, if the given <see cref="ParquetStack"/> is walkable, <c>false</c> otherwise.</returns>
        internal static bool IsEntry(this ParquetStack in_stack)
            => All.Parquets.Get<Furnishing>(in_stack.Furnishing)?.IsEntry ?? false
            && (in_stack.IsWalkable() || in_stack.IsEnclosing());
    }
}
