using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Properties;

namespace ParquetClassLibrary.Rooms
{
    // Local extension methods allow fluent algorithm expression.  See bottom of this file for definitions.
    using ParquetClassLibrary.Rooms.RegionAnalysis;

    /// <summary>
    /// Extension methods to <see cref="IReadOnlyCollection{MapSpace}"/>, providing bounds-checking and
    /// various routines useful when dealing with <see cref="Room"/>s.
    /// </summary>
    public class MapSpaceCollection : IReadOnlyCollection<MapSpace>
    {
        // TODO IDEA -- A potential simplification is to replace this class with a set of extension methods to  HashSet<MapSpace>.

        /// <summary>The canonical empty collection.</summary>
        public static MapSpaceCollection Empty { get; } = new HashSet<MapSpace>();

        /// <summary>The internal collection mechanism.</summary>
        private HashSet<MapSpace> Spaces { get; }

        /// <summary>The first <see cref="MapSpace"/> in the sequence, if any.</summary>
        public MapSpace First
            => Spaces?.First() ?? MapSpace.Empty;

        /// <summary>The number of <see cref="MapSpace"/>s in the <see cref="MapSpaceCollection"/>.</summary>
        public int Count
            => Spaces?.Count ?? 0;

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="MapSpaceCollection"/> class.
        /// </summary>
        /// <param name="inSpaces">The <see cref="MapSpace"/>s to collect.  Cannot be null.</param>
        public MapSpaceCollection(IEnumerable<MapSpace> inSpaces)
        {
            Precondition.IsNotNull(inSpaces, nameof(inSpaces));

            Spaces = new HashSet<MapSpace>(inSpaces);
        }
        #endregion

        #region Collection Access
        /// <summary>
        /// Determines whether the <see cref="MapSpaceCollection"/> contains the specified <see cref="MapSpace"/>.
        /// </summary>
        /// <param name="inSpace">The <see cref="MapSpace"/> to find.</param>
        /// <returns><c>true</c> if the <see cref="MapSpace"/> was found; <c>false</c> otherwise.</returns>
        public bool Contains(MapSpace inSpace)
            => Spaces.Contains(inSpace);

        /// <summary>
        /// Determines whether the <see cref="MapSpaceCollection"/> is set-equal to the given MapSpaceCollection.
        /// </summary>
        /// <param name="inEqualTo">The collection to compare against this collection. Cannot be null.</param>
        /// <returns><c>true</c> if the <see cref="MapSpaceCollection"/>s are set-equal; <c>false</c> otherwise.</returns>
        public bool SetEquals(MapSpaceCollection inEqualTo)
        {
            Precondition.IsNotNull(inEqualTo, nameof(inEqualTo));
            return Spaces.SetEquals(inEqualTo.Spaces);
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
        /// <param name="inSpaces">The collection to convert.</param>
        public static implicit operator HashSet<MapSpace>(MapSpaceCollection inSpaces)
        {
            Precondition.IsNotNull(inSpaces, nameof(inSpaces));
            return inSpaces.Spaces;
        }

        /// <summary>
        /// Converts the given <see cref="HashSet{MapSpace}"/> to a full <see cref="MapSpaceCollection"/>.
        /// </summary>
        /// <param name="inSpaces">The collection to convert.</param>
        public static implicit operator MapSpaceCollection(HashSet<MapSpace> inSpaces)
            => new MapSpaceCollection(inSpaces);
        #endregion

        #region Room Analysis
        /// <summary>
        /// Finds a walkable area's perimiter in a given subregion.
        /// </summary>
        /// <param name="outPerimeter">The walkable area's valid perimiter, if it exists.</param>
        /// <returns><c>true</c> if a valid perimeter was found; otherwise, <c>false</c>.</returns>
        internal bool TryGetPerimeter(out MapSpaceCollection outPerimeter)
        {
            var subregion = First.Subregion;
            Precondition.IsNotNull(subregion);

            var stepCount = 0;
            var potentialPerimeter = Empty;
            outPerimeter = Empty;

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
            if (leastXValue > 0
                && leastYValue > 0
                && greatestXValue < subregion.Columns
                && greatestYValue < subregion.Rows)
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
                    potentialPerimeter = GetPotentialPerimeter(new MapSpace(northSeed, subregion[northSeed.Y, northSeed.X], subregion));

                    // Design-time sanity checks.
                    Debug.Assert(potentialPerimeter.Count <= (subregion.Rows * subregion.Columns) - RoomConfiguration.MinWalkableSpaces,
                                 string.Format(CultureInfo.CurrentCulture, Resources.ErrorOutOfOrderLTE,
                                               nameof(potentialPerimeter.Count), potentialPerimeter.Count,
                                               (subregion.Rows * subregion.Columns) - RoomConfiguration.MinWalkableSpaces));
                    Debug.Assert(potentialPerimeter.Count >= RoomConfiguration.MinPerimeterSpaces,
                                 string.Format(CultureInfo.CurrentCulture, Resources.ErrorOutOfOrderGTE,
                                               nameof(potentialPerimeter.Count),
                                               potentialPerimeter.Count, RoomConfiguration.MinPerimeterSpaces));
                    
                    // Validate the perimeter.
                    outPerimeter = potentialPerimeter.AllSpacesAreReachableAndCycleExists(space => space.Content.IsEnclosing)
                                    && perimiterSeeds.All(position => potentialPerimeter.Any(space => space.Position == position))
                        ? potentialPerimeter
                        : Empty;
                }
            }

            return outPerimeter.Count >= RoomConfiguration.MinPerimeterSpaces;

            #region Algorithm Helper Methods
            // Finds a MapSpace that can be used to search for the perimeter.
            // inStart indicates where to begin looking.
            // inAdjust indicates how to adjust the position at each step if a seed has not been found.
            // outFinal indicates the position of the perimeter seed.
            // Returns true if a seed was found, false otherwise.
            bool TryGetSeed(Vector2D inStart, Func<Vector2D, Vector2D> inAdjust, out Vector2D outFinal)
            {
                var found = false;
                var position = inStart;
                var subregion = First.Subregion;

                Precondition.IsNotNull(subregion, nameof(subregion));

                while (!found)
                {
                    position = inAdjust(position);
                    if (!subregion.IsValidPosition(position))
                    {
                        break;
                    }
                    stepCount++;
                    if (stepCount + Spaces.Count > RoomConfiguration.MaxWalkableSpaces)
                    {
                        break;
                    }
                    found = subregion[position.Y, position.X].IsEnclosing;
                }

                outFinal = found
                    ? position
                    : Vector2D.Zero;

                return found;
            }

            // Finds all 4-connected MapSpaces in the given subregion whose Content is Enclosing,
            // beginning at the given Position.
            // inStart indicates where to begin the perimeter search.
            // Returns the potential perimeter.
            MapSpaceCollection GetPotentialPerimeter(MapSpace inStart)
                => First.Subregion.GetSpaces().Search(inStart,
                                                      space => space.Content.IsEnclosing,
                                                      space => false).Visited;
            #endregion
        }

        /// <summary>
        /// Determines if it is possible to reach every <see cref="MapSpace"/> in the given subregion
        /// whose <see cref="MapSpace.Content"/> conforms to the given predicate using only
        /// 4-connected movements, beginning at an arbitrary <see cref="MapSpace"/>.
        /// </summary>
        /// <param name="inIsApplicable">Determines if a <see cref="MapSpace"/> is a target MapSpace.</param>
        /// <returns><c>true</c> if all members of the given set are reachable from all other members of the given set.</returns>
        internal bool AllSpacesAreReachable(Predicate<MapSpace> inIsApplicable)
            => Search(Spaces.First(), inIsApplicable, space => false)
               .Visited.Count == Spaces.Count;

        /// <summary>
        /// Determines if it is possible to reach every <see cref="MapSpace"/> in the given subregion
        /// whose <see cref="MapSpace.Content"/> conforms to the given predicate using only
        /// 4-connected movements, beginning at an arbitrary <see cref="MapSpace"/>, while encountering
        /// at least one cycle.
        /// </summary>
        /// <param name="inIsApplicable">Determines if a <see cref="MapSpace"/> is a target MapSpace.</param>
        /// <returns><c>true</c> if all members of the given set are reachable from all other members of the given set.</returns>
        internal bool AllSpacesAreReachableAndCycleExists(Predicate<MapSpace> inIsApplicable)
        {
            var results = Search(Spaces.First(), inIsApplicable, space => false);
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
        /// <param name="inStart">The <see cref="MapSpace"/> to begin searching from.</param>
        /// <param name="inIsApplicable"><c>true</c> if a <see cref="MapSpace"/> ought to be considered.</param>
        /// <param name="inIsGoal"><c>true</c> if a the search goal has been satisfied.</param>
        /// <returns>Information about the results of the search procedure.</returns>
        private SearchResults Search(MapSpace inStart, Predicate<MapSpace> inIsApplicable, Predicate<MapSpace> inIsGoal)
        {
            Precondition.IsNotNullOrEmpty(Spaces, nameof(Spaces));
            var visited = new HashSet<MapSpace>();
            var cycleFound = false;

            return new SearchResults(DepthFirstSearch(inStart), cycleFound, new MapSpaceCollection(visited));

            // Traverses the given 4-connected grid in a preorder, depth-first fashion.
            // inSpace indicates the MapSpace under consideration this stack frame.
            // Returns true is the goal was found, false otherwise.
            bool DepthFirstSearch(MapSpace inSpace)
            {
                var goalFound = false;

                if (inIsApplicable(inSpace))
                {
                    if (visited.Contains(inSpace))
                    {
                        cycleFound = true;
                    }
                    else
                    {
                        visited.Add(inSpace);

                        if (inIsGoal(inSpace))
                        {
                            goalFound = true;
                        }
                        else
                        {
                            // Continue, examining all neighbors in order.
                            goalFound = DepthFirstSearch(inSpace.NorthNeighbor())
                                || DepthFirstSearch(inSpace.SouthNeighbor())
                                || DepthFirstSearch(inSpace.EastNeighbor())
                                || DepthFirstSearch(inSpace.WestNeighbor());
                        }
                    }
                }

                return goalFound;
            }
        }

        /// <summary>
        /// Encapsulates the results of a graph search.
        /// </summary>
        private class SearchResults
        {
            /// <summary><c>true</c> if the goal condition was met, <c>false</c> otherwise.</summary>
            public bool GoalFound;

            /// <summary><c>true</c> if a cycle was met during the search, <c>false</c> otherwise.</summary>
            public bool CycleFound;

            /// <summary>A collection of all the <see cref="MapSpace"/>s visited during the search.</summary>
            public MapSpaceCollection Visited;

            public SearchResults(bool inGoalFound, bool inCycleFound, MapSpaceCollection inVisited)
            {
                GoalFound = inGoalFound;
                CycleFound = inCycleFound;
                Visited = inVisited;
            }
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="MapSpaceCollection"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"{Spaces.Count} spaces";
        #endregion
    }
}

namespace ParquetClassLibrary.Rooms.RegionAnalysis
{
    /// <summary>
    /// Provides extension methods for deriving <see cref="MapSpaceCollection"/>s from <see cref="ParquetStackGrid"/>s.
    /// </summary>
    internal static class ParquetStackGridExtensions
    {
        /// <summary>
        /// Returns the <see cref="MapSpaceCollection"/> corresponding to the <see cref="ParquetStackGrid"/>.
        /// </summary>
        /// <returns>A collection of <see cref="MapSpace"/>s.</returns>
        internal static MapSpaceCollection GetSpaces(this ParquetStackGrid inParquetStacks)
        {
            Precondition.IsNotNull(inParquetStacks, nameof(inParquetStacks));

            var uniqueResults = new HashSet<MapSpace>();
            for (var y = 0; y < inParquetStacks.Rows; y++)
            {
                for (var x = 0; x < inParquetStacks.Columns; x++)
                {
                    var currentSpace = new MapSpace(x, y, inParquetStacks[y, x], inParquetStacks);
                    uniqueResults.Add(currentSpace);
                }
            }

            return new MapSpaceCollection(uniqueResults);
        }
    }
}
