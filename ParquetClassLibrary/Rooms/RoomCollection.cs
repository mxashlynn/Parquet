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

            // TODO: We need a test case that is a looping set of enclosing spaces that contain all
            // extrema but fail to completely surround the walkable area.

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
    internal static class ParquetStackExtensions
    {
        /// <summary>
        /// Finds all valid Walkable Areas in a given subregion.
        /// </summary>
        /// <param name="in_subregion">The collection of <see cref="ParquetStack"/>s to search.</param>
        /// <returns>The list of vallid Walkable Areas.</returns>
        internal static List<HashSet<Space>> GetWalkableAreas(this ParquetStack[,] in_subregion)
        {
            var PWAs = new List<HashSet<Space>>();
            var subregionRows = in_subregion.GetLength(0);
            var subregionCols = in_subregion.GetLength(1);

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
            var PWAsDiscontinuous = new HashSet<HashSet<Space>>(PWAs.Where(pwa => !pwa.AllSpacesAreReachable(in_subregion, space => space.Content.IsWalkable)));

            return new List<HashSet<Space>>(PWAs
                                            .Except(PWAsTooSmall)
                                            .Except(PWAsTooLarge)
                                            .Except(PWAsDiscontinuous));
        }

        /// <summary>
        /// Returns the set of <see cref="Space"/>s corresponding to the subregion.
        /// </summary>
        /// <param name="in_subregion">The collection of <see cref="ParquetStack"/>s to consider.</param>
        /// <returns>The <see cref="Space"/>s defined by this subregion.</returns>
        internal static HashSet<Space> GetSpaces(this ParquetStack[,] in_subregion)
        {
            var result = new HashSet<Space>();
            var subregionRows = in_subregion.GetLength(0);
            var subregionCols = in_subregion.GetLength(1);

            for (var y = 0; y < subregionRows; y++)
            {
                for (var x = 0; x < subregionCols; x++)
                {
                   var currentSpace = new Space(x, y, in_subregion[y, x]);
                   result.Add(currentSpace);
                }
            }

            return result;
        }
    }
}
