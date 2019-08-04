using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Stubs;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Rooms
{
    /// <summary>
    /// Stores a collection of <see cref="Space"/>s.
    /// Provides bounds-checking and various routines useful when dealing with <see cref="Room"/>s.
    /// </summary>
    public class SpaceCollection : IEnumerable<Space>
    {
        /// <summary>The internal collection mechanism.</summary>
        private HashSet<Space> Spaces { get; }

        /// <summary>The number of <see cref="Space"/>s in the <see cref="SpaceCollection"/>.</summary>
        public int Count => Spaces.Count;

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="SpaceCollection"/> class.
        /// </summary>
        /// <param name="in_spaces">The <see cref="Space"/>s to collect.  Cannot be null.</param>
        public SpaceCollection(IEnumerable<Space> in_spaces)
        {
            Precondition.IsNotNull(in_spaces, nameof(in_spaces));

            Spaces = new HashSet<Space>(in_spaces);
        }
        #endregion

        #region Collection Access
        /// <summary>
        /// Determines whether the <see cref="SpaceCollection"/> contains the specified <see cref="Space"/>.
        /// </summary>
        /// <param name="in_space">The <see cref="Space"/> to find.</param>
        /// <returns><c>true</c> if the <see cref="Space"/> was found; <c>false</c> otherwise.</returns>
        public bool Contains(Space in_space)
            => Spaces.Contains(in_space);

        /// <summary>
        /// Determines whether the <see cref="SpaceCollection"/> is set-equal to the given SpaceCollection.
        /// </summary>
        /// <param name="in_equalTo">The collection to compare against this collection.</param>
        /// <returns><c>true</c> if the <see cref="SpaceCollection"/>s are set-equal; <c>false</c> otherwise.</returns>
        public bool SetEquals(SpaceCollection in_equalTo)
            => Spaces.SetEquals(in_equalTo.Spaces);

        /// <summary>
        /// Exposes an <see cref="IEnumerator{Space}"/>, which supports simple iteration.
        /// </summary>
        /// <returns>An enumerator.</returns>
        IEnumerator<Space> IEnumerable<Space>.GetEnumerator()
            => ((IEnumerable<Space>)Spaces).GetEnumerator();

        /// <summary>
        /// Exposes an enumerator for the <see cref="SpaceCollection"/>, which supports simple iteration.
        /// </summary>
        /// <returns>An enumerator.</returns>
        public IEnumerator GetEnumerator()
            => ((IEnumerable<Space>)Spaces).GetEnumerator();
        #endregion

        #region Conversion Operators
        /// <summary>
        /// Converts the given <see cref="SpaceCollection"/> to a plain <see cref="HashSet{Space}"/>.
        /// </summary>
        /// <param name="in_spaces">The collection to convert.</param>
        public static implicit operator HashSet<Space>(SpaceCollection in_spaces)
            => in_spaces.Spaces;

        /// <summary>
        /// Converts the given <see cref="HashSet{Space}"/> to a full <see cref="SpaceCollection"/>.
        /// </summary>
        /// <param name="in_spaces">The collection to convert.</param>
        public static implicit operator SpaceCollection(HashSet<Space> in_spaces)
            => new SpaceCollection(in_spaces);
        #endregion

        #region Room Analysis Methods
        /// <summary>
        /// Finds a walkable area's perimiter in a given subregion.
        /// </summary>
        /// <param name="in_walkableArea">The walkable area whose perimeter is sought.</param>
        /// <param name="in_subregion">The subregion containing the walkable area and the perimiter.</param>
        /// <param name="out_perimeter">The walkable area's valid perimiter, if it exists.</param>
        /// <returns><c>true</c> if a valid perimeter was found; otherwise, <c>false</c>.</returns>
        public bool TryGetPerimeter(ParquetStack[,] in_subregion, out SpaceCollection out_perimeter)
        {
            var stepCount = 0;
            SpaceCollection potentialPerimeter = null;
            out_perimeter = null;

            #region Find Extreme Coordinate of Walkable Extrema
            var greatestXValue = Spaces
                                 .Select(space => space.Position.X)
                                 .Max();
            var greatestYValue = Spaces
                                 .Select(space => space.Position.Y)
                                 .Max();
            var leastXValue = Spaces
                              .Select(space => space.Position.X)
                              .Min();
            var leastYValue = Spaces
                              .Select(space => space.Position.Y)
                              .Min();
            #endregion

            // Only continue if perimeter is within the subregion.
            if (leastXValue > 0 && leastYValue > 0)
            {
                #region Find Positions of Walkable Extrema
                var northWalkableExtreme = Spaces.First(space => space.Position.Y == leastYValue).Position;
                var southWalkableExtreme = Spaces.First(space => space.Position.Y == greatestYValue).Position;
                var eastWalkableExtreme = Spaces.First(space => space.Position.X == greatestXValue).Position;
                var westWalkableExtreme = Spaces.First(space => space.Position.X == leastXValue).Position;
                #endregion

                // Only continue if all four extrema are found.
                var perimiterSeeds = new List<Vector2Int>();
                if (TryGetSeed(northWalkableExtreme, position => position + Vector2Int.North, out var northSeed)
                    && TryGetSeed(southWalkableExtreme, position => position + Vector2Int.South, out var southSeed)
                    && TryGetSeed(eastWalkableExtreme, position => position + Vector2Int.East, out var eastSeed)
                    && TryGetSeed(westWalkableExtreme, position => position + Vector2Int.West, out var westSeed))
                {
                    perimiterSeeds.Add(northSeed);
                    perimiterSeeds.Add(southSeed);
                    perimiterSeeds.Add(eastSeed);
                    perimiterSeeds.Add(westSeed);

                    // Find the perimeter.
                    potentialPerimeter = GetPotentialPerimeter(new Space(northSeed, in_subregion[northSeed.Y, northSeed.X]));

                    // TODO Probably remove this check and this variable after debugging.
                    var maxPerimeterCount = in_subregion.GetLength(0) * in_subregion.GetLength(1) - Rules.Recipes.Rooms.MinWalkableSpaces;
                    if (potentialPerimeter.Count > maxPerimeterCount)
                    {
                        throw new Exception("Perimeter is larger than it should be.");
                    }

                    // TODO Probably remove this check after debugging.
                    if (potentialPerimeter.Count < Rules.Recipes.Rooms.MinPerimeterSpaces)
                    {
                        throw new Exception("Perimeter is smaller than it should be.");
                    }

                    // Validate the perimeter.
                    out_perimeter = potentialPerimeter.AllSpacesAreReachableAndCycleExists(in_subregion, space => space.Content.IsEnclosing)
                                    && perimiterSeeds.All(position => potentialPerimeter.Any(space => space.Position == position))
                        ? potentialPerimeter
                        : null;
                }
            }

            return (out_perimeter?.Count ?? 0) >= Rules.Recipes.Rooms.MinPerimeterSpaces;

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
                    if (!in_subregion.IsValidPosition(position))
                    {
                        break;
                    }
                    stepCount++;
                    if (stepCount + Spaces.Count > Rules.Recipes.Rooms.MaxWalkableSpaces)
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
            SpaceCollection GetPotentialPerimeter(Space in_start)
                => in_subregion.GetSpaces().Search(in_start,
                                                   in_subregion,
                                                   space => space.Content.IsEnclosing,
                                                   space => false).Visited;
            #endregion
        }

        /// <summary>
        /// Determines if it is possible to reach every <see cref="Space"/> in the given subregion
        /// whose <see cref="Space.Content"/> conforms to the given predicate using only
        /// 4-connected movements, beginning at an arbitrary <see cref="Space"/>.
        /// </summary>
        /// <param name="in_subregion">The grid on which the set exists.</param>
        /// <param name="in_isApplicable">Determines if a <see cref="Space"/> is a target Space.</param>
        /// <returns><c>true</c> if all members of the given set are reachable from all other members of the given set.</returns>
        internal bool AllSpacesAreReachable(ParquetStack[,] in_subregion, Predicate<Space> in_isApplicable)
            => Search(Spaces.First(), in_subregion, in_isApplicable, space => false)
               .Visited.Count == Spaces.Count;

        /// <summary>
        /// Determines if it is possible to reach every <see cref="Space"/> in the given subregion
        /// whose <see cref="Space.Content"/> conforms to the given predicate using only
        /// 4-connected movements, beginning at an arbitrary <see cref="Space"/>.
        /// </summary>
        /// <param name="in_subregion">The grid on which the set exists.</param>
        /// <param name="in_isApplicable">Determines if a <see cref="Space"/> is a target Space.</param>
        /// <returns><c>true</c> if all members of the given set are reachable from all other members of the given set.</returns>
        internal bool AllSpacesAreReachableAndCycleExists(ParquetStack[,] in_subregion, Predicate<Space> in_isApplicable)
        {
            var results = Search(Spaces.First(), in_subregion, in_isApplicable, space => false);
            return results.CycleFound
                && results.Visited.Count == Spaces.Count;
        }

        /// <summary>
        /// Determines if it is possible to reach <see cref="Space"/> whose
        /// <see cref="Furnishing.IsEntry"/> and whose <see cref="Space.Content"/>
        /// conforms to the given predicate using only 4-connected movements,
        /// beginning at an arbitrary space.
        /// </summary>
        /// <param name="in_subregion">The grid on which the set exists.</param>
        /// <param name="in_isApplicable">Determines if a <see cref="Space"/> is a target Space.</param>
        /// <returns><c>true</c> is any entry was reached, <c>false</c> otherwise.</returns>
        internal bool EntryIsReachable(ParquetStack[,] in_subregion, Predicate<Space> in_isApplicable)
            => Search(Spaces.First(), in_subregion, in_isApplicable,
                      space => space.Content.IsEntry
                            || space.NorthNeighbor(in_subregion).Content.IsEntry
                            || space.SouthNeighbor(in_subregion).Content.IsEntry
                            || space.EastNeighbor(in_subregion).Content.IsEntry
                            || space.WestNeighbor(in_subregion).Content.IsEntry).GoalFound;

        /// <summary>
        /// Searches the given set of <see cref="Space"/>s using only 4-connected movements,
        /// considering all spaces that conform to the given applicability predicate,
        /// beginning at an arbitrary space and continuing until the given goal predicate is satisfied.
        /// </summary>
        /// <remarks>
        /// Searches in a preorder, depth-first fashion.
        /// </remarks>
        /// <param name="in_subregion">The grid on which the set is defined.</param>
        /// <param name="in_isApplicable"><c>true</c> if a <see cref="Space"/> ought to be considered.</param>
        /// <param name="in_isGoal"><c>true</c> if a the search goal has been satisfied.</param>
        /// <returns>
        /// First value is <c>true</c> if the goal was reached, <c>false</c> otherwise.
        /// Second valye is a list of all <see cref="Space"/>s that were visited during the search.
        /// </returns>
        private SearchResults Search(Space in_start, ParquetStack[,] in_subregion,
                                      Predicate<Space> in_isApplicable, Predicate<Space> in_isGoal)
        {
            Precondition.IsNotEmpty(Spaces);

            var visited = new HashSet<Space>();
            var cycleFound = false;

            return new SearchResults(DepthFirstSearch(in_start), cycleFound, new SpaceCollection(visited));

            /// <summary>Traverses the given 4-connected grid in a preorder, depth-first fashion.</summary>
            /// <param name="in_space">The <see cref="Space"/> under consideration this stack frame.</param>
            bool DepthFirstSearch(Space in_space)
            {
                bool result = false;

                if (in_isApplicable(in_space))
                {
                    if (visited.Contains(in_space))
                    {
                        cycleFound = true;
                    }
                    else {
                        if (in_isGoal(in_space))
                        {
                            result = true;
                        }
                        else
                        {
                            // Log as "Visited".
                            visited.Add(in_space);

                            // Continue, examining all children in order.
                            result = DepthFirstSearch(in_space.NorthNeighbor(in_subregion))
                                || DepthFirstSearch(in_space.SouthNeighbor(in_subregion))
                                || DepthFirstSearch(in_space.EastNeighbor(in_subregion))
                                || DepthFirstSearch(in_space.WestNeighbor(in_subregion));
                        }
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Encapsulates the results of a graph search.
        /// </summary>
        private struct SearchResults
        {
            /// <summary><c>true</c> if the goal condition was met, <c>false</c> otherwise.</summary>
            public bool GoalFound;

            /// <summary><c>true</c> if a cycle was met during the search, <c>false</c> otherwise.</summary>
            public bool CycleFound;

            /// <summary>A collection of all the <see cref="Space"/>s visited during the search.</summary>
            public SpaceCollection Visited;

            public SearchResults(bool in_goalFound, bool in_cycleFound, SpaceCollection in_visited)
            {
                GoalFound = in_goalFound;
                CycleFound = in_cycleFound;
                Visited = in_visited;
            }
        }
        #endregion

        #region Utility Methods
        /// <summary>
        /// Returns a <see langword="string"/> that represents the current <see cref="SpaceCollection"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"{Spaces.Count} spaces";
        #endregion
    }
}
