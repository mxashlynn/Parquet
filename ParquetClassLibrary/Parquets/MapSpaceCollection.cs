using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// Stores a collection of <see cref="MapSpace"/>s.
    /// Provides bounds-checking and various routines useful when dealing with <see cref="Room"/>s.
    /// </summary>
    public class MapSpaceCollection : IEnumerable<MapSpace>
    {
        /// <summary>The internal collection mechanism.</summary>
        private HashSet<MapSpace> Spaces { get; }

        /// <summary>The number of <see cref="MapSpace"/>s in the <see cref="MapSpaceCollection"/>.</summary>
        public int Count => Spaces.Count;

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="MapSpaceCollection"/> class.
        /// </summary>
        /// <param name="in_spaces">The <see cref="MapSpace"/>s to collect.  Cannot be null.</param>
        public MapSpaceCollection(IEnumerable<MapSpace> in_spaces)
        {
            Precondition.IsNotNull(in_spaces, nameof(in_spaces));

            Spaces = new HashSet<MapSpace>(in_spaces);
        }
        #endregion

        #region Collection Access
        /// <summary>
        /// Determines whether the <see cref="MapSpaceCollection"/> contains the specified <see cref="MapSpace"/>.
        /// </summary>
        /// <param name="in_space">The <see cref="MapSpace"/> to find.</param>
        /// <returns><c>true</c> if the <see cref="MapSpace"/> was found; <c>false</c> otherwise.</returns>
        public bool Contains(MapSpace in_space)
            => Spaces.Contains(in_space);

        /// <summary>
        /// Determines whether the <see cref="MapSpaceCollection"/> is set-equal to the given MapSpaceCollection.
        /// </summary>
        /// <param name="in_equalTo">The collection to compare against this collection. Cannot be null.</param>
        /// <returns><c>true</c> if the <see cref="MapSpaceCollection"/>s are set-equal; <c>false</c> otherwise.</returns>
        public bool SetEquals(MapSpaceCollection in_equalTo)
        {
            Precondition.IsNotNull(in_equalTo, nameof(in_equalTo));
            return Spaces.SetEquals(in_equalTo.Spaces);
        }

        /// <summary>
        /// Exposes an <see cref="IEnumerator{MapSpace}"/>, which supports simple iteration.
        /// </summary>
        /// <returns>An enumerator.</returns>
        IEnumerator<MapSpace> IEnumerable<MapSpace>.GetEnumerator()
            => ((IEnumerable<MapSpace>)Spaces).GetEnumerator();

        /// <summary>
        /// Exposes an enumerator for the <see cref="MapSpaceCollection"/>, which supports simple iteration.
        /// </summary>
        /// <returns>An enumerator.</returns>
        public IEnumerator GetEnumerator()
            => ((IEnumerable<MapSpace>)Spaces).GetEnumerator();
        #endregion

        #region Implicit Conversion Operators
        /// <summary>
        /// Converts the given <see cref="MapSpaceCollection"/> to a plain <see cref="HashSet{MapSpace}"/>.
        /// </summary>
        /// <param name="in_spaces">The collection to convert.</param>
        public static implicit operator HashSet<MapSpace>(MapSpaceCollection in_spaces)
        {
            Precondition.IsNotNull(in_spaces, nameof(in_spaces));
            return in_spaces.Spaces;
        }

        /// <summary>
        /// Converts the given <see cref="HashSet{MapSpace}"/> to a full <see cref="MapSpaceCollection"/>.
        /// </summary>
        /// <param name="in_spaces">The collection to convert.</param>
        public static implicit operator MapSpaceCollection(HashSet<MapSpace> in_spaces)
            => new MapSpaceCollection(in_spaces);
        #endregion

        #region Room Analysis Methods
        /// <summary>
        /// Finds a walkable area's perimiter in a given subregion.
        /// </summary>
        /// <param name="in_subregion">The subregion containing the walkable area and the potential perimiter.</param>
        /// <param name="out_perimeter">The walkable area's valid perimiter, if it exists.</param>
        /// <returns><c>true</c> if a valid perimeter was found; otherwise, <c>false</c>.</returns>
        public bool TryGetPerimeter(ParquetStack[,] in_subregion, out MapSpaceCollection out_perimeter)
        {
            Precondition.IsNotNull(in_subregion);

            var stepCount = 0;
            MapSpaceCollection potentialPerimeter = null;
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
            // TODO Why do we not need to check max values here as well?
            if (leastXValue > 0 && leastYValue > 0)
            {
                #region Find Positions of Walkable Extrema
                var northWalkableExtreme = Spaces.First(space => space.Position.Y == leastYValue).Position;
                var southWalkableExtreme = Spaces.First(space => space.Position.Y == greatestYValue).Position;
                var eastWalkableExtreme = Spaces.First(space => space.Position.X == greatestXValue).Position;
                var westWalkableExtreme = Spaces.First(space => space.Position.X == leastXValue).Position;
                #endregion

                // Only continue if all four seeds are found.
                var perimiterSeeds = new List<Vector2D>();
                if (TryGetSeed(northWalkableExtreme, position => position + Vector2D.North, out var northSeed)
                    && TryGetSeed(southWalkableExtreme, position => position + Vector2D.South, out var southSeed)
                    && TryGetSeed(eastWalkableExtreme, position => position + Vector2D.East, out var eastSeed)
                    && TryGetSeed(westWalkableExtreme, position => position + Vector2D.West, out var westSeed))
                {
                    perimiterSeeds.Add(northSeed);
                    perimiterSeeds.Add(southSeed);
                    perimiterSeeds.Add(eastSeed);
                    perimiterSeeds.Add(westSeed);

                    // Find the perimeter.
                    potentialPerimeter = GetPotentialPerimeter(new MapSpace(northSeed, in_subregion[northSeed.Y, northSeed.X]));

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
            /// Finds a <see cref="MapSpace"/> that can be used to search for the perimeter.
            /// </summary>
            /// <param name="in_start">Where to begin looking.</param>
            /// <param name="in_adjust">How to adjust the position at each step if a seed has not been found.</param>
            /// <param name="out_final">The position of the perimeter seed.</param>
            /// <returns><c>true</c> if a seed was found, <c>false</c> otherwise.</returns>
            bool TryGetSeed(Vector2D in_start, Func<Vector2D, Vector2D> in_adjust, out Vector2D out_final)
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
                    : Vector2D.Zero;

                return found;
            }
            #endregion

            #region GetPotentialPerimeter Helper Method
            /// <summary>
            /// Finds all 4-connected <see cref="MapSpace"/>s in the given subregion whose <see cref="MapSpace.Content"/>
            /// <see cref="ParquetStack.IsEnclosing"/> beginning at the given <see cref="MapSpace.Position"/>.
            /// </summary>
            /// <param name="in_start">Where to begin the perimeter search.</param>
            /// <returns>The potential perimeter.</returns>
            MapSpaceCollection GetPotentialPerimeter(MapSpace in_start)
                => in_subregion.GetSpaces().Search(in_start,
                                                   in_subregion,
                                                   space => space.Content.IsEnclosing,
                                                   space => false).Visited;
            #endregion
        }

        /// <summary>
        /// Determines if it is possible to reach every <see cref="MapSpace"/> in the given subregion
        /// whose <see cref="MapSpace.Content"/> conforms to the given predicate using only
        /// 4-connected movements, beginning at an arbitrary <see cref="MapSpace"/>.
        /// </summary>
        /// <param name="in_subregion">The grid on which the set exists.</param>
        /// <param name="in_isApplicable">Determines if a <see cref="MapSpace"/> is a target MapSpace.</param>
        /// <returns><c>true</c> if all members of the given set are reachable from all other members of the given set.</returns>
        internal bool AllSpacesAreReachable(ParquetStack[,] in_subregion, Predicate<MapSpace> in_isApplicable)
            => Search(Spaces.First(), in_subregion, in_isApplicable, space => false)
               .Visited.Count == Spaces.Count;

        /// <summary>
        /// Determines if it is possible to reach every <see cref="MapSpace"/> in the given subregion
        /// whose <see cref="MapSpace.Content"/> conforms to the given predicate using only
        /// 4-connected movements, beginning at an arbitrary <see cref="MapSpace"/>, while encountering
        /// at least one cycle.
        /// </summary>
        /// <param name="in_subregion">The grid on which the set exists.</param>
        /// <param name="in_isApplicable">Determines if a <see cref="MapSpace"/> is a target MapSpace.</param>
        /// <returns><c>true</c> if all members of the given set are reachable from all other members of the given set.</returns>
        internal bool AllSpacesAreReachableAndCycleExists(ParquetStack[,] in_subregion, Predicate<MapSpace> in_isApplicable)
        {
            var results = Search(Spaces.First(), in_subregion, in_isApplicable, space => false);
            return results.CycleFound
                && results.Visited.Count == Spaces.Count;
        }

        /// <summary>
        /// Searches the given set of <see cref="MapSpace"/>s using only 4-connected movements,
        /// considering all spaces that conform to the given applicability predicate,
        /// beginning at an arbitrary space and continuing until the given goal predicate is satisfied.
        /// </summary>
        /// <remarks>
        /// Searches in a preorder, depth-first fashion.
        /// </remarks>
        /// <param name="in_subregion">The grid on which the set is defined.</param>
        /// <param name="in_isApplicable"><c>true</c> if a <see cref="MapSpace"/> ought to be considered.</param>
        /// <param name="in_isGoal"><c>true</c> if a the search goal has been satisfied.</param>
        /// <returns>Information about the results of the search procedure.</returns>
        private SearchResults Search(MapSpace in_start, ParquetStack[,] in_subregion,
                                     Predicate<MapSpace> in_isApplicable, Predicate<MapSpace> in_isGoal)
        {
            Precondition.IsNotNullOrEmpty(Spaces);

            // TODO Either goalFound should be outside with the other results, or all three results should be returned as part of the method.
            // It's confusing otherwise.
            var visited = new HashSet<MapSpace>();
            var cycleFound = false;

            return new SearchResults(DepthFirstSearch(in_start), cycleFound, new MapSpaceCollection(visited));

            /// <summary>Traverses the given 4-connected grid in a preorder, depth-first fashion.</summary>
            /// <param name="in_space">The <see cref="MapSpace"/> under consideration this stack frame.</param>
            bool DepthFirstSearch(MapSpace in_space)
            {
                bool goalFound = false;

                if (in_isApplicable(in_space))
                {
                    if (visited.Contains(in_space))
                    {
                        cycleFound = true;
                    }
                    else
                    {
                        visited.Add(in_space);

                        if (in_isGoal(in_space))
                        {
                            goalFound = true;
                        }
                        else
                        {
                            // Continue, examining all children in order.
                            goalFound = DepthFirstSearch(in_space.NorthNeighbor(in_subregion))
                                || DepthFirstSearch(in_space.SouthNeighbor(in_subregion))
                                || DepthFirstSearch(in_space.EastNeighbor(in_subregion))
                                || DepthFirstSearch(in_space.WestNeighbor(in_subregion));
                        }
                    }
                }

                return goalFound;
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

            /// <summary>A collection of all the <see cref="MapSpace"/>s visited during the search.</summary>
            public MapSpaceCollection Visited;

            public SearchResults(bool in_goalFound, bool in_cycleFound, MapSpaceCollection in_visited)
            {
                GoalFound = in_goalFound;
                CycleFound = in_cycleFound;
                Visited = in_visited;
            }
        }
        #endregion

        #region Utility Methods
        /// <summary>
        /// Returns a <see langword="string"/> that represents the current <see cref="MapSpaceCollection"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"{Spaces.Count} spaces";
        #endregion
    }
}
