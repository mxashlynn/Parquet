using System;
using System.Collections.Generic;
using System.Linq;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Stubs;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Rooms
{
    // Local extension methods allow fluent algorithm expression.  See bottom of this file for definitions.
    using ParquetClassLibrary.Rooms.RegionAnalysis;

    /// <summary>
    /// Stores a <see cref="Room"/> collection.
    /// Analyzes subregions of <see cref="ParquetStack"/>s to find all valid rooms in them.
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
            => Rooms.FirstOrDefault(room => room.ContainsPosition(in_position));

        #region Initialization
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

            var walkableAreas = in_subregion.GetWalkableAreas();
            HashSet<Space> perimeter = null;
            var rooms = walkableAreas
                        .Where(walkableArea => walkableArea.TryGetPerimeter(in_subregion, out perimeter))
                        .Where(walkableArea => walkableArea.EntryIsReachable(in_subregion,
                                                                             space => walkableArea.Contains(space)))
                        .Select(walkableArea => new Room(walkableArea, perimeter));

            RegionAnalysisExtensions.ClearCaches();

            return new RoomCollection(rooms);
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
}

namespace ParquetClassLibrary.Rooms.RegionAnalysis
{
    /// <summary>
    /// Extension methods used in analyzing subregions.
    /// </summary>
    internal static class RegionAnalysisExtensions
    {
        #region Constraints
        /// <summary>Maximum Y value for current subregion.</summary>
        private static int subregionRows;

        /// <summary>Maximum X value for current subregion.</summary>
        private static int subregionCols;

        /// <summary>Maximum possible count of <see cref="Space"/>s in this subregion.</summary>
        private static int maxPerimeterCount;

        /// <summary>
        /// Initializes constraints on the search routines.
        /// </summary>
        /// <param name="in_subregion">The subregion under consideration.</param>
        private static void InitConstraints(ParquetStack[,] in_subregion)
        {
            subregionRows = in_subregion.GetLength(0);
            subregionCols = in_subregion.GetLength(1);
            maxPerimeterCount = subregionCols* subregionRows - All.Recipes.Rooms.MinWalkableSpaces;
        }
        #endregion

        #region Cache
        /// <summary>Cached results from finding potential perimiters.</summary>
        private static readonly Dictionary<int, HashSet<Space>> potentialPerimeters = new Dictionary<int, HashSet<Space>>();

        /// <summary>Cached results from determining if perimiters are connected.</summary>
        private static readonly Dictionary<int, bool> potentiallyConnectedCollections = new Dictionary<int, bool>();
        #endregion

        /// <summary>
        /// Clears all caches.
        /// </summary>
        public static void ClearCaches()
        {
            potentialPerimeters.Clear();
            potentiallyConnectedCollections.Clear();
        }

        /// <summary>
        /// Determines if the given position corresponds to a point in the subregion.
        /// </summary>
        /// <param name="in_position">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        private static bool IsValidPosition(Vector2Int in_position)
            => in_position.X > -1
            && in_position.Y > -1
            && in_position.X < subregionCols
            && in_position.Y < subregionRows;

        /// <summary>Finds the <see cref="Space"/> to the west of the given space, if any.</summary>
        /// <param name="in_space">The <see cref="Space"/> to move west from.</param>
        /// <param name="in_subregion">The subregion containing the <see cref="Space"/>s.</param>
        /// <returns>A <see cref="Space"/> if it exists, or <see cref="Space.Empty"/> otherwise.</returns>
        private static Space ToWest(Space in_space, ParquetStack[,] in_subregion)
        {
            var westPosition = new Vector2Int(in_space.Position.X - 1, in_space.Position.Y);
            return IsValidPosition(westPosition)
                ? new Space(westPosition, in_subregion[westPosition.Y, westPosition.X])
                : Space.Empty;
        }

        /// <summary>
        /// Finds all valid Walkable Areas in a given subregion.
        /// </summary>
        /// <param name="in_subregion">The collection of <see cref="ParquetStack"/>s to search.</param>
        /// <returns>The list of vallid Walkable Areas.</returns>
        internal static List<HashSet<Space>> GetWalkableAreas(this ParquetStack[,] in_subregion)
        {
            var PWAs = new List<HashSet<Space>>();
            InitConstraints(in_subregion);

            for (var y = 0; y < subregionRows; y++)
            {
                for (var x = 0; x < subregionCols; x++)
                {
                    if (in_subregion[y, x].IsWalkable)
                    {
                        var currentSpace = new Space(x, y, in_subregion[y, x]);

                        var northSpace = y > 0 && in_subregion[y - 1, x].IsWalkable
                            ? new Space(x, y - 1, in_subregion[y - 1, x])
                            : (Space?)null;
                        var westSpace = x > 0 && in_subregion[y, x - 1].IsWalkable
                            ? new Space(x - 1, y, in_subregion[y, x - 1])
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
                            PWAs.Find(pwa => pwa.Contains((Space)northSpace)).Add(currentSpace);
                        }
                    }
                }
            }

            var PWAsTooSmall = new HashSet<HashSet<Space>>(PWAs.Where(pwa => pwa.Count < All.Recipes.Rooms.MinWalkableSpaces));
            var PWAsTooLarge = new HashSet<HashSet<Space>>(PWAs.Where(pwa => pwa.Count > All.Recipes.Rooms.MaxWalkableSpaces));
            var PWAsDiscontinuous = new HashSet<HashSet<Space>>(PWAs.Where(pwa => !pwa.AllSpacesAreReachable(in_subregion, parquetStack => parquetStack.IsWalkable)));

            return new List<HashSet<Space>>(PWAs
                                            .Except(PWAsTooSmall)
                                            .Except(PWAsTooLarge)
                                            .Except(PWAsDiscontinuous));
        }

        /// <summary>
        /// Finds a walkable area's perimiter in a given subregion.
        /// </summary>
        /// <param name="in_walkableArea">The walkable area whose perimeter is sought.</param>
        /// <param name="in_subregion">The subregion containing the walkable area and the perimiter.</param>
        /// <param name="out_perimeter">The walkable area's valid perimiter, if it exists.</param>
        /// <returns><c>true</c> if a valid perimeter was found; otherwise, <c>false</c>.</returns>
        internal static bool TryGetPerimeter(this HashSet<Space> in_walkableArea, ParquetStack[,] in_subregion,
                                             out HashSet<Space> out_perimeter)
        {
            InitConstraints(in_subregion);

            var stepCount = 0;
            HashSet<Space> potentialPerimeter = null;
            out_perimeter = null;

            #region Find Extreme Coordinate of Walkable Extrema
            var greatestXValue = in_walkableArea
                                 .Select(space => space.Position.X)
                                 .Max();
            var greatestYValue = in_walkableArea
                                 .Select(space => space.Position.Y)
                                 .Max();
            var leastXValue = in_walkableArea
                              .Select(space => space.Position.X)
                              .Min();
            var leastYValue = in_walkableArea
                              .Select(space => space.Position.Y)
                              .Min();
            #endregion

            // Only continue if perimeter is within the subregion.
            if (leastXValue > 0 && leastYValue > 0)
            {
                #region Find Positions of Walkable Extrema
                var northWalkableExtreme = in_walkableArea.First(space => space.Position.Y == leastYValue).Position;
                var southWalkableExtreme = in_walkableArea.First(space => space.Position.Y == greatestYValue).Position;
                var eastWalkableExtreme = in_walkableArea.First(space => space.Position.X == greatestXValue).Position;
                var westWalkableExtreme = in_walkableArea.First(space => space.Position.X == leastXValue).Position;
                #endregion

                // Only continue if all four extrema are found.
                var perimiterSeeds = new List<Vector2Int>();
                if (TryGetSeed(northWalkableExtreme, position => new Vector2Int(position.X, position.Y - 1), out var northSeed)
                    && TryGetSeed(southWalkableExtreme, position => new Vector2Int(position.X, position.Y + 1), out var southSeed)
                    && TryGetSeed(eastWalkableExtreme, position => new Vector2Int(position.X + 1, position.Y), out var eastSeed)
                    && TryGetSeed(westWalkableExtreme, position => new Vector2Int(position.X - 1, position.Y), out var westSeed))
                {
                    perimiterSeeds.Add(northSeed);
                    perimiterSeeds.Add(southSeed);
                    perimiterSeeds.Add(eastSeed);
                    perimiterSeeds.Add(westSeed);

                    // Find the perimeter.
                    potentialPerimeter = GetPotentialPerimeter(northSeed);

                    // TODO Probably remove this check and this variable after debugging.
                    if (potentialPerimeter.Count > maxPerimeterCount)
                    {
                        throw new Exception("Perimeter is larger than it should be.");
                    }

                    // Validate the perimeter.
                    out_perimeter = potentialPerimeter.AllSpacesAreReachable(in_subregion, parquetStack => parquetStack.IsEnclosing)
                                    && perimiterSeeds.All(position => potentialPerimeter.Any(space => space.Position == position))
                        ? potentialPerimeter
                        : null;
                }
            }

            return (out_perimeter?.Count ?? 0) >= All.Recipes.Rooms.MinPerimeterSpaces;

            #region TryGetSeed Helper Method
            /// <summary>
            /// Finds the a <see cref="Space"/> that can be used to search for the perimeter.
            /// </summary>
            /// <param name="in_start">Where to begin looking.</param>
            /// <param name="in_adjust">How to adjust the position at each step if a seed has not been found.</param>
            /// <param name="out_final">The position of the perimeter seed.</param>
            /// <returns><c>true</c> if a seed was found, <c>false</c> otherwise.</returns>
            bool TryGetSeed(Vector2Int in_start, Func<Vector2Int, Vector2Int> in_adjust, out Vector2Int out_final)
            {
                var found = false;
                var position = in_start;

                while (!found)
                {
                    position = in_adjust(position);
                    if (!IsValidPosition(position))
                    {
                        break;
                    }
                    stepCount++;
                    if (stepCount + in_walkableArea.Count > All.Recipes.Rooms.MaxWalkableSpaces)
                    {
                        break;
                    }
                    found = in_subregion[position.Y, position.X].IsEnclosing;
                }

                out_final = found
                    ? position
                    : Vector2Int.ZeroVector;

                return found;
            }
            #endregion

            #region GetPotentialPerimeter Helper Method
            /// <summary>
            /// Finds all 4-connected <see cref="Space"/>s in the given subregion whose <see cref="Space.Content"/>
            /// <see cref="ParquetStack.IsEnclosing"/> beginning at the given <see cref="Space.Position"/>.
            /// </summary>
            /// <param name="in_start">Where to begin the perimeter search.</param>
            /// <returns>The potential perimeter.</returns>
            HashSet<Space> GetPotentialPerimeter(Vector2Int in_start)
            {
                var key = in_start.GetHashCode();
                if (!potentialPerimeters.ContainsKey(key))
                {
                    var found = new HashSet<Space>();

                    if (IsValidPosition(in_start))
                    {
                        var start = new Space(in_start, in_subregion[in_start.Y, in_start.X]);

                        InOrderDepthFirstTraversal(start);

                        /// <summary>
                        /// Traverses the given 4-connected grid in a preorder, depth-first fashion.
                        /// </summary>
                        /// <param name="in_space">The <see cref="Space"/> under consideration.</param>
                        void InOrderDepthFirstTraversal(Space in_space)
                        {
                            if (in_space.Content.IsEnclosing
                                && !found.Contains(in_space))
                            {
                                // Mark "Traversed".
                                found.Add(in_space);

                                // And continue, examining all children in order.
                                InOrderDepthFirstTraversal(in_space.NorthNeighbor(in_subregion, IsValidPosition));
                                InOrderDepthFirstTraversal(in_space.SouthNeighbor(in_subregion, IsValidPosition));
                                InOrderDepthFirstTraversal(in_space.EastNeighbor(in_subregion, IsValidPosition));
                                InOrderDepthFirstTraversal(in_space.WestNeighbor(in_subregion, IsValidPosition));
                            }
                        }
                    }

                    potentialPerimeters.Add(key, found);
                }

                return potentialPerimeters[key];
            }
            #endregion
        }

        /// <summary>
        /// Determines if it is possible to reach every <see cref="Space"/> in the given subregion
        /// whose <see cref="Space.Content"/> conforms to the given predicate using only
        /// 4-connected movements, beginning at an arbitrary <see cref="Space"/>.
        /// </summary>
        /// <param name="in_spaceSet">The collection under consideration.</param>
        /// <param name="in_subregion">The grid on which the set exists.</param>
        /// <param name="in_isTarget">Determines if a <see cref="Space"/> is a target Space.</param>
        /// <returns><c>true</c> if all members of the given set are reachable from all other members of the given set.</returns>
        internal static bool AllSpacesAreReachable(this HashSet<Space> in_spaceSet, ParquetStack[,] in_subregion,
                                                   Predicate<ParquetStack> in_isTarget)
        {
            var key = (in_spaceSet, in_isTarget).GetHashCode();

            if (!potentiallyConnectedCollections.ContainsKey(key))
            {
                potentiallyConnectedCollections.Add(key, CheckIfAllSpacesAreReachable(in_spaceSet,
                                                                                      in_subregion,
                                                                                      in_isTarget));
            }

            return potentiallyConnectedCollections[key];
        }

        /// <summary>
        /// Determines if it is possible to reach every <see cref="Space"/> in the given subregion
        /// whose <see cref="Space.Content"/> conforms to the given predicate using only
        /// 4-connected movements, beginning at an arbitrary <see cref="Space"/>.
        /// </summary>
        /// <param name="in_spaceSet">The collection under consideration.</param>
        /// <param name="in_subregion">The grid on which the set exists.</param>
        /// <param name="in_isTarget">Determines if a <see cref="Space"/> is a target Space.</param>
        /// <returns><c>true</c> if all members of the given set are reachable from all other members of the given set.</returns>
        internal static bool CheckIfAllSpacesAreReachable(this HashSet<Space> in_spaceSet,
                                                          ParquetStack[,] in_subregion,
                                                          Predicate<ParquetStack> in_isTarget)
        {
            var visited = new HashSet<int>();
            var start = in_spaceSet.FirstOrDefault();
            var consistent = IsValidPosition(start.Position);

            ConditionalDepthFirstTraversal(start);

            return consistent && visited.Count == in_spaceSet.Count;

            /// <summary>Traverses the given 4-connected grid in a preorder, depth-first fashion.</summary>
            /// <param name="in_space">The <see cref="Space"/> under consideration.</param>
            void ConditionalDepthFirstTraversal(Space in_space)
            {
                if (consistent
                    && in_isTarget(in_space.Content)
                    && !visited.Contains(in_space.GetHashCode()))
                {
                    if (in_spaceSet.Contains(in_space))
                    {
                        // Mark "Traversed".
                        visited.Add(in_space.GetHashCode());

                        // And continue, examining all children in order.
                        ConditionalDepthFirstTraversal(in_space.NorthNeighbor(in_subregion, IsValidPosition));
                        ConditionalDepthFirstTraversal(in_space.SouthNeighbor(in_subregion, IsValidPosition));
                        ConditionalDepthFirstTraversal(in_space.EastNeighbor(in_subregion, IsValidPosition));
                        ConditionalDepthFirstTraversal(in_space.WestNeighbor(in_subregion, IsValidPosition));
                    }
                    else
                    {
                        // Unless a valid target Space is not in the original
                        // set of Spaces, in which case fail.
                        consistent = false;
                    }
                }
            }
        }


        /// <summary>
        /// Determines if it is possible to reach <see cref="Space"/> whose
        /// <see cref="Furnishing.IsEntry"/> and whose <see cref="Space.Content"/>
        /// conforms to the given predicate using only 4-connected movements,
        /// beginning at an arbitrary space.
        /// </summary>
        /// <param name="in_spaceSet">The collection under consideration.</param>
        /// <param name="in_subregion">The grid on which the set exists.</param>
        /// <param name="in_isTarget">Determines if a <see cref="Space"/> is a target Space.</param>
        /// <returns><c>true</c> is any entry was reached, <c>false</c> otherwise.</returns>
        internal static bool EntryIsReachable(this HashSet<Space> in_spaceSet, ParquetStack[,] in_subregion,
                                              Predicate<Space> in_isTarget)
        {
            Precondition.IsNotEmpty(in_spaceSet);

            var visited = new HashSet<int>();
            var start = in_spaceSet.First();
            var consistent = IsValidPosition(start.Position);

            return consistent && ConditionalDepthFirstSearch(start, parquetStack => parquetStack.IsEntry);

            /// <summary>Traverses the given 4-connected grid in a preorder, depth-first fashion.</summary>
            /// <param name="in_space">The <see cref="Space"/> under consideration.</param>
            /// <param name="in_isGoal"><c>true</c> when the goal has been found.</param>
            bool ConditionalDepthFirstSearch(Space in_space, Predicate<ParquetStack> in_isGoal)
            {
                bool result = false;

                if (consistent
                    && in_isTarget(in_space)
                    && !visited.Contains(in_space.GetHashCode()))
                {
                    if (in_spaceSet.Contains(in_space))
                    {
                        if (in_isGoal(in_space.Content)
                            || in_isGoal(in_space.NorthNeighbor(in_subregion, IsValidPosition).Content)
                            || in_isGoal(in_space.SouthNeighbor(in_subregion, IsValidPosition).Content)
                            || in_isGoal(in_space.EastNeighbor(in_subregion, IsValidPosition).Content)
                            || in_isGoal(in_space.WestNeighbor(in_subregion, IsValidPosition).Content))
                        {
                            result = true;
                        }
                        else
                        {
                            // Mark "Traversed".
                            visited.Add(in_space.GetHashCode());

                            // And continue, examining all children in order.
                            result = ConditionalDepthFirstSearch(in_space.NorthNeighbor(in_subregion, IsValidPosition), in_isGoal)
                                || ConditionalDepthFirstSearch(in_space.SouthNeighbor(in_subregion, IsValidPosition), in_isGoal)
                                || ConditionalDepthFirstSearch(in_space.EastNeighbor(in_subregion, IsValidPosition), in_isGoal)
                                || ConditionalDepthFirstSearch(in_space.WestNeighbor(in_subregion, IsValidPosition), in_isGoal);
                        }
                    }
                    else
                    {
                        // Unless a valid target Space is not in the original
                        // set of Spaces, in which case fail.
                        consistent = false;
                    }
                }

                return result;
            }
        }
    }
}
