using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Parquet.Parquets;
using Parquet.Properties;

namespace Parquet.Rooms
{
    /// <summary>
    /// Extension methods to <see cref="IReadOnlySet{MapSpace}"/>, providing bounds-checking and
    /// various routines useful when dealing with <see cref="Room"/>s.
    /// </summary>
    public static class MapSpaceSetExtensions
    {
        /// <summary>The canonical empty collection.</summary>
        internal static IReadOnlySet<MapSpace> Empty { get; } = new HashSet<MapSpace>();

        #region Room Analysis
        /// <summary>
        /// Finds a walkable area's perimeter in a given subgrid.
        /// </summary>
        /// <param name="inSpaces">The walkable area under consideration.</param>
        /// <param name="outPerimeter">The walkable area's valid perimeter, if it exists.</param>
        /// <returns><c>true</c> if a valid perimeter was found; otherwise, <c>false</c>.</returns>
        internal static bool TryGetPerimeter(this IReadOnlySet<MapSpace> inSpaces, out IReadOnlySet<MapSpace> outPerimeter)
        {
            var subgrid = inSpaces.First().Grid;
            var stepCount = 0;
            var potentialPerimeter = Empty;
            outPerimeter = Empty;

            Precondition.IsNotNull(subgrid);
            if (subgrid is null)
            {
                return false;
            }

            #region Find Extreme Coordinate of Walkable Extrema
            var greatestXValue = inSpaces
                                 .Select(space => space.Position.X)
                                 .Max();
            var greatestYValue = inSpaces
                                 .Select(space => space.Position.Y)
                                 .Max();
            var leastXValue = inSpaces
                              .Select(space => space.Position.X)
                              .Min();
            var leastYValue = inSpaces
                              .Select(space => space.Position.Y)
                              .Min();
            #endregion

            // Only continue if perimeter is within the subgrid.
            if (leastXValue > 0
                && leastYValue > 0
                && greatestXValue < subgrid.Columns
                && greatestYValue < subgrid.Rows)
            {
                #region Find Positions of Walkable Extrema
                var northWalkableExtreme = inSpaces.First(space => space.Position.Y == leastYValue).Position;
                var southWalkableExtreme = inSpaces.First(space => space.Position.Y == greatestYValue).Position;
                var eastWalkableExtreme = inSpaces.First(space => space.Position.X == greatestXValue).Position;
                var westWalkableExtreme = inSpaces.First(space => space.Position.X == leastXValue).Position;
                #endregion

                // Only continue if all four seeds are found.
                var perimiterSeeds = new List<Point2D>();
                if (TryGetSeed(northWalkableExtreme, position => position + Point2D.North, out var northSeed)
                    && TryGetSeed(southWalkableExtreme, position => position + Point2D.South, out var southSeed)
                    && TryGetSeed(eastWalkableExtreme, position => position + Point2D.East, out var eastSeed)
                    && TryGetSeed(westWalkableExtreme, position => position + Point2D.West, out var westSeed))
                {
                    perimiterSeeds.Add(northSeed);
                    perimiterSeeds.Add(southSeed);
                    perimiterSeeds.Add(eastSeed);
                    perimiterSeeds.Add(westSeed);

                    // Find the perimeter.
                    potentialPerimeter = GetPotentialPerimeter(new MapSpace(northSeed, subgrid[northSeed.Y, northSeed.X], subgrid));

                    // Design-time sanity checks.
                    // NOTE that there is no need to check LibraryState.IsPlayMode as Debug.Assertions are removed in release builds.
                    Debug.Assert(potentialPerimeter.Count <= (subgrid.Rows * subgrid.Columns) - RoomConfiguration.MinWalkableSpaces,
                                 string.Format(CultureInfo.CurrentCulture, Resources.ErrorOutOfOrderLTE,
                                               nameof(potentialPerimeter.Count), potentialPerimeter.Count,
                                               (subgrid.Rows * subgrid.Columns) - RoomConfiguration.MinWalkableSpaces));
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
            // Returns true if it finds a MapSpace that can be used to search for the perimeter.
            //     inStart indicates where to begin looking.
            //     inAdjust indicates how to adjust the position at each step if a perimeter seed has not been found.
            //     outFinal indicates the position of the perimeter seed, if one was found.
            // If it cannot find such a MapSpace, returns false.
            bool TryGetSeed(Point2D inStart, Func<Point2D, Point2D> inAdjust, out Point2D outFinal)
            {
                var found = false;
                var position = inStart;
                var subgrid = inSpaces.First().Grid;

                Precondition.IsNotNull(subgrid, nameof(subgrid));

                while (!found)
                {
                    position = inAdjust(position);
                    if (!subgrid.IsValidPosition(position))
                    {
                        break;
                    }
                    stepCount++;
                    if (stepCount + inSpaces.Count > RoomConfiguration.MaxWalkableSpaces)
                    {
                        break;
                    }
                    found = subgrid[position.Y, position.X].IsEnclosing;
                }

                outFinal = found
                    ? position
                    : Point2D.Origin;

                return found;
            }

            // Returns the potential perimeter by finding all 4-connected MapSpaces in the given subgrid
            // whose Content is Enclosing, beginning at the Position given by inStart.
            IReadOnlySet<MapSpace> GetPotentialPerimeter(MapSpace inStart)
                => GetSpaces(inSpaces.First().Grid).Search(inStart,
                                                                space => space.Content.IsEnclosing,
                                                                space => false).Visited;

            // Returns a Set of MapSpaces corresponding to the ParquetPackGrid.
            static IReadOnlySet<MapSpace> GetSpaces(ParquetModelPackGrid inParquetPacks)
            {
                Precondition.IsNotNull(inParquetPacks, nameof(inParquetPacks));

                var uniqueResults = new HashSet<MapSpace>();
                for (var y = 0; y < inParquetPacks.Rows; y++)
                {
                    for (var x = 0; x < inParquetPacks.Columns; x++)
                    {
                        var currentSpace = new MapSpace(x, y, inParquetPacks[y, x], inParquetPacks);
                        uniqueResults.Add(currentSpace);
                    }
                }

                return new HashSet<MapSpace>(uniqueResults);
            }
            #endregion
        }

        /// <summary>
        /// Determines if it is possible to reach every <see cref="MapSpace"/> in the given subgrid
        /// whose <see cref="MapSpace.Content"/> conforms to the given predicate using only
        /// 4-connected movements, beginning at an arbitrary <see cref="MapSpace"/>.
        /// </summary>
        /// <param name="inSpaces">The group of spaces under consideration.</param>
        /// <param name="inIsApplicable">Determines if a <see cref="MapSpace"/> is a target MapSpace.</param>
        /// <returns><c>true</c> if all members of the given set are reachable from all other members of the given set.</returns>
        internal static bool AllSpacesAreReachable(this HashSet<MapSpace> inSpaces, Predicate<MapSpace> inIsApplicable)
            => ((IReadOnlySet<MapSpace>)inSpaces).Search(inSpaces.First(), inIsApplicable, space => false)
               .Visited.Count == inSpaces.Count;

        /// <summary>
        /// Determines if it is possible to reach every <see cref="MapSpace"/> in the given subgrid
        /// whose <see cref="MapSpace.Content"/> conforms to the given predicate using only 4-connected
        /// movements, beginning at an arbitrary <see cref="MapSpace"/>, while encountering at least one cycle.
        /// </summary>
        /// <param name="inSpaces">The group of spaces under consideration.</param>
        /// <param name="inIsApplicable">Determines if a <see cref="MapSpace"/> is a target MapSpace.</param>
        /// <returns><c>true</c> if all members of the given set are reachable from all other members of the given set.</returns>
        internal static bool AllSpacesAreReachableAndCycleExists(this IReadOnlySet<MapSpace> inSpaces, Predicate<MapSpace> inIsApplicable)
        {
            var results = inSpaces.Search(inSpaces.First(), inIsApplicable, space => false);
            return results.CycleFound
                && results.Visited.Count == inSpaces.Count;
        }

        /// <summary>
        /// Searches the given set of <see cref="MapSpace"/>s using only 4-connected movements,
        /// considering all spaces that conform to the given applicability predicate,
        /// beginning at an arbitrary space and continuing until the given goal predicate is satisfied.
        /// </summary>
        /// <remarks>
        /// Searches in a preorder, depth-first fashion.
        /// </remarks>
        /// <param name="inSpaces">The group of spaces under consideration.</param>
        /// <param name="inStart">The <see cref="MapSpace"/> to begin searching from.</param>
        /// <param name="inIsApplicable"><c>true</c> if a <see cref="MapSpace"/> ought to be considered.</param>
        /// <param name="inIsGoal"><c>true</c> if a the search goal has been satisfied.</param>
        /// <returns>Information about the results of the search procedure.</returns>
        private static SearchResults Search(this IReadOnlySet<MapSpace> inSpaces, MapSpace inStart, Predicate<MapSpace> inIsApplicable, Predicate<MapSpace> inIsGoal)
        {
            Precondition.IsNotNullOrEmpty(inSpaces, nameof(inSpaces));
            var visited = new HashSet<MapSpace>();
            var cycleFound = false;

            return new SearchResults(DepthFirstSearch(inStart), cycleFound, new HashSet<MapSpace>(visited));

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
            internal bool GoalFound { get; private set; }

            /// <summary><c>true</c> if a cycle was met during the search, <c>false</c> otherwise.</summary>
            internal bool CycleFound { get; private set; }

            /// <summary>A collection of all the <see cref="MapSpace"/>s visited during the search.</summary>
            internal IReadOnlySet<MapSpace> Visited { get; private set; }

            internal SearchResults(bool inGoalFound, bool inCycleFound, IReadOnlySet<MapSpace> inVisited)
            {
                GoalFound = inGoalFound;
                CycleFound = inCycleFound;
                Visited = inVisited;
            }
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="IReadOnlySet{MapSpace}"/>.
        /// </summary>
        /// <param name="inSpaces">The group of spaces under consideration.</param>
        /// <returns>The representation.</returns>
        internal static string ToString(this IReadOnlySet<MapSpace> inSpaces)
            => $"{inSpaces?.Count ?? 0} spaces";
        #endregion
    }
}
