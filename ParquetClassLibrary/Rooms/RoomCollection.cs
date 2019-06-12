using System.Collections.Generic;
using System.Linq;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Stubs;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Rooms
{
    /// <summary>
    /// Stores a <see cref="Room"/> collection.
    /// Analysises subregions of <see cref="ParquetStack"/>s to find all valid rooms in them.
    /// </summary>
    /// <remarks>
    /// For a complete explanation of the algorithm implemented here, see:
    /// <a href="https://github.com/mxashlynn/Parquet/wiki/Room-Detection-and-Type-Assignment"/>
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
        private RoomCollection(IEnumerable<Room> in_rooms)
        {
            Rooms = in_rooms.ToList();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomCollection"/> class.
        /// </summary>
        /// <param name="in_subregion">The collection of parquets to search for <see cref="Room"/>s.</param>
        /// <returns>An initialized <see cref="RoomCollection"/>.</returns>
        public static RoomCollection CreateFromSubregion(ParquetStack[,] in_subregion)
        {
            Precondition.IsNotNull(in_subregion, nameof(in_subregion));

            var walkableAreas = FindAllWalkableAreas(in_subregion);
            var rooms = walkableAreas
                        .Where(walkableArea => null != walkableArea.GetPerimeter(in_subregion))
                        .Where(walkableArea => walkableArea.Concat(walkableArea.GetPerimeter(in_subregion))
                                               .Any(space => space.Content.IsEntry()))
                        .Select(walkableArea => new Room(walkableArea, walkableArea.GetPerimeter(in_subregion));
            // TODO Clear the perimiter cache

            return new RoomCollection(rooms);
        }

        #region Algorithm Helper Methods
        /// <summary>
        /// Finds all valid Walkable Areas in a given subregion.
        /// </summary>
        /// <param name="in_subregion">The collection of <see cref="ParquetStack"/>s to search.</param>
        /// <returns>The list of vallid Walkable Areas.</returns>
        private static List<HashSet<Space>> FindAllWalkableAreas(ParquetStack[,] in_subregion)
        {
            var PWAs = new List<HashSet<Space>>();

            var subregionRows = in_subregion.GetLength(0);
            var subregionCols = in_subregion.GetLength(1);
            for (var y = 0; y < subregionRows; y++)
            {
                for (var x = 0; x < subregionCols; x++)
                {
                    if (in_subregion[y, x].IsWalkable())
                    {
                        var currentSpace = new Space(x, y, in_subregion[x, y]);

                        var northSpace = y > 0 && in_subregion[y - 1, x].IsWalkable()
                            ? new Space(x, y - 1, in_subregion[x, y - 1])
                            : (Space?)null;
                        var westSpace = x > 0 && in_subregion[y, x - 1].IsWalkable()
                            ? new Space(x - 1, y, in_subregion[x - 1, y])
                            : (Space?)null;

                        if (null == northSpace && null == westSpace)
                        {
                            var newPWA = new HashSet<Space> { currentSpace };
                            PWAs.Add(newPWA);
                        }
                        else if (null != northSpace && null != westSpace)
                        {
                            var northPWA = PWAs.Find(pwa => pwa.Contains((Space)northSpace));
                            var westPWA = PWAs.Find(pwa => pwa.Contains((Space)westSpace));
                            if (northPWA == westPWA)
                            {
                                northPWA.Add(currentSpace);
                            }
                            else
                            {
                                var combinedPWA = new HashSet<Space>(northPWA.Union(westPWA)) { currentSpace };
                                PWAs.Remove(northPWA);
                                PWAs.Remove(westPWA);
                                PWAs.Add(combinedPWA);
                            }
                        }
                        else if (null == northSpace)
                        {
                            PWAs.Find(pwa => pwa.Contains((Space)westSpace)).Add(currentSpace);
                        }
                        else if (null == westSpace)
                        {
                            PWAs.Where(pwa => pwa.Contains((Space)northSpace)).Add(currentSpace);
                        }
                    }
                }
            }

            var PWAsTooSmall = new HashSet<HashSet<Space>>(PWAs.Where(pwa => pwa.Count < All.Recipes.Rooms.MinWalkableSpaces));
            var PWAsTooLarge = new HashSet<HashSet<Space>>(PWAs.Where(pwa => pwa.Count > All.Recipes.Rooms.MaxWalkableSpaces));
            var PWAsDiscontinuous = new HashSet<HashSet<Space>>(PWAs.Where(pwa => !pwa.AllSpacesAreReachable(in_subregion)));

            return new List<HashSet<Space>>(PWAs
                                            .Except(PWAsTooSmall)
                                            .Except(PWAsTooLarge)
                                            .Except(PWAsDiscontinuous));
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
    internal static class RoomAnalysisExtensions
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
        /// Finds a walkable area's perimiter in a given subregion.
        /// </summary>
        /// <param name="in_subregion">The collection of <see cref="ParquetStack"/>s to search.</param>
        /// <param name="in_walkableArea">The walkable area whose perimeter is sought.</param>
        /// <param name="in_subregion">The subregion containing the walkable area and the perimiter.</param>
        /// <returns>The walkable area's valid perimiter, if it exists; otherwise, null.</returns>
        internal static HashSet<Space> GetPerimeter(this HashSet<Space> in_walkableArea,
                                                     ParquetStack[,] in_subregion)
            => new HashSet<Space>();
        // TODO Implement this.
        // TODO This needs to be cached (use hash value) since it is called repeatedly for each set of arguments.
        // && potentialPerimiter.AllSpacesAreReachable(in_subregion)
        // && .Surrounds(walkableArea, in_subregion)

        /// <summary>
        /// Determines if it is possible to reach every location in the subregion using only 4-connected
        /// movements, beginning at an arbitrary <see cref="Space"/>.
        /// </summary>
        /// <param name="in_spaces">The potential perimiter.</param>
        /// <param name="in_subregion">The subregion within which these <see cref="Space"/>s reside.</param>
        /// <returns><c>true</c>, if valid, <c>false</c> otherwise.</returns>
        internal static bool AllSpacesAreReachable(this HashSet<Space> in_spaces, ParquetStack[,] in_subregion)
            => true;    // TODO: Implement connectedness search-test here.
                        // if DFS-ID(maxDepth: in_spaces.Count) == in_spaces.Count, then it is valid

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
