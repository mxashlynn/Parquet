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
        #region Inner Types
        internal struct PotentialRoom
        {
            /// <summary>The subregion within which this <see cref="PotentialRoom"/> resides.</summary>
            public readonly ParquetStack[,] subregion;

            /// <summary>A valid walkable area.</summary>
            public readonly HashSet<Space> WalkableArea;

            /// <summary>A valid enclosing perimeter.</summary>
            public readonly HashSet<Space> Perimeter;

            /// <summary>
            /// A <see cref="PotentialRoom"/> is Valid iff:
            /// 1, together, its Walkable Area and its Perimeter contain at least one Entry Space; and,
            /// 2, every <see cref="Space"/> in its Walkable Area is surrounded by it's Enclosing Perimeter.
            /// </summary>
            /// <returns><c>true</c>, if valid, <c>false</c> otherwise.</returns>
            public bool IsValid()
                => WalkableArea.Concat(Perimeter).Any(space => space.Content.IsEntry())
                && Perimeter.Surrounds(WalkableArea, subregion);
        }
        #endregion

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

        #region Algorithm Helper Methods
        /// <summary>
        /// Turns a 2D subregion into a 1D collection of <see cref="Space"/>s.
        /// </summary>
        /// <param name="in_subregion">The subregion to consider.</param>
        /// <returns>A list of all Spaces contained in the subregion.</returns>
        private static HashSet<Space> CollectAllSpaces(ParquetStack[,] in_subregion)
        {
            Precondition.IsNotNull(in_subregion, nameof(in_subregion));

            var spaces = new HashSet<Space>();

            var subregionRows = in_subregion.GetLength(0);
            var subregionCols = in_subregion.GetLength(1);
            for (var y = 0; y < subregionRows; y++)
            {
                for (var x = 0; x < subregionCols; x++)
                {
                    spaces.Add(new Space(new Vector2Int(x, y), in_subregion[y, x]));
                }
            }

            return spaces;
        }
        #endregion

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

        /// <summary>
        /// A Potential Walkable Area is Valid iff:
        /// 1, there are at least the minimum number of Walkable Spaces; and
        /// 2, there are no more than the maximum number of Walkable Spaces; and
        /// 3, given an arbitrary Walkable Space within the PWA it is possible to reach every other
        /// Walkable Space in the PWA using only 4-connected movements to only other Walkable Spaces.
        /// (That is, without ever "stepping on" a non-Walkable Space.)
        /// </summary>
        /// <param name="in_potentialWalkableArea">The potential walkable area.</param>
        /// <param name="in_subregion">The subregion within which the walkable area resides.</param>
        /// <returns><c>true</c>, if valid, <c>false</c> otherwise.</returns>
        internal static bool IsValidWalkableArea(this HashSet<Space> in_potentialWalkableArea,
                                                 ParquetStack[,] in_subregion)
            => in_potentialWalkableArea.Count >= All.Recipes.Rooms.MinWalkableSpaces
            && in_potentialWalkableArea.Count <= All.Recipes.Rooms.MaxWalkableSpaces
            && in_potentialWalkableArea.AllSpacesAreReachable(in_subregion);

        /// <summary>
        /// A Potential Perimiter is Valid iff:
        /// 1, given an arbitrary Enclosing Space within the PWA it is possible to reach every other
        /// Enclosing Space in the PWA using only 4-connected movements to only other Enclosing Spaces.
        /// (That is, without ever "stepping on" a non-Enclosing Space.)
        /// </summary>
        /// <param name="in_potentialPerimiter">The potential perimiter.</param>
        /// <param name="in_subregion">The subregion within which the perimiter resides.</param>
        /// <returns><c>true</c>, if valid, <c>false</c> otherwise.</returns>
        internal static bool IsValidPerimiter(this HashSet<Space> in_potentialPerimiter,
                                              ParquetStack[,] in_subregion)
            => in_potentialPerimiter.AllSpacesAreReachable(in_subregion);

        /// <summary>
        /// Determines if it is possible to reach every location in the subregion using only 4-connected
        /// movements, beginning at an arbitrary <see cref="Space"/>.
        /// </summary>
        /// <param name="in_spaces">The potential perimiter.</param>
        /// <param name="in_subregion">The subregion within which these <see cref="Space"/>s reside.</param>
        /// <returns><c>true</c>, if valid, <c>false</c> otherwise.</returns>
        internal static bool AllSpacesAreReachable(this HashSet<Space> in_spaces, ParquetStack[,] in_subregion)
            => true;  // TODO: Implement connectedness search-test here.

        /// <summary>
        /// Determines if it is possible to reach every location in the subregion using only 4-connected
        /// movements, beginning at an arbitrary <see cref="Space"/>.
        /// </summary>
        /// <param name="in_perimiterSpaces">The perimiter.</param>
        /// <param name="in_internalSpaces">The <see cref="Space"/>s that the perimiter should enclose.</param>
        /// <param name="in_subregion">The subregion within which these <see cref="Space"/>s reside.</param>
        /// <returns><c>true</c>, if valid, <c>false</c> otherwise.</returns>
        internal static bool Surrounds(this HashSet<Space> in_perimiterSpaces,
                                       HashSet<Space> in_internalSpaces, ParquetStack[,] in_subregion)
            => true;  // TODO: Implement surroundedness search-test here.
    }
}
