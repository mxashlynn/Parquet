using System.Collections.Generic;
using System.Linq;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Rooms
{
    // Local extension methods allow fluent algorithm expression.  See bottom of this file for definitions.
    using ParquetClassLibrary.Rooms.RegionAnalysis;

    /// <summary>
    /// Stores a <see cref="Room"/> collection.
    /// Analyzes subregions of <see cref="ParquetStack"/>s to find all valid rooms within them.
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
        /// <param name="in_position">An in-bounds position to search for a <see cref="Room"/>.</param>
        /// <returns>The specified <see cref="Room"/> if found; otherwise, null.</returns>
        public Room GetRoomAt(Vector2D in_position)
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
            // TODO Double check that correct perimeters are being attached to walkable areas.
            MapSpaceCollection perimeter = null;
            var rooms = walkableAreas
                        .Where(walkableArea => walkableArea.TryGetPerimeter(in_subregion, out perimeter))
                        .Where(walkableArea => walkableArea.Any(space => space.IsWalkableEntry
                                                                      || space.Neighbors(in_subregion).Any(neighbor => neighbor.IsEnclosingEntry(in_subregion, walkableArea))))
                        .Select(walkableArea => new Room(walkableArea, perimeter));

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
        internal static List<MapSpaceCollection> GetWalkableAreas(this ParquetStack[,] in_subregion)
        {
            var PWAs = new List<HashSet<MapSpace>>();
            var subregionRows = in_subregion.GetLength(0);
            var subregionCols = in_subregion.GetLength(1);

            for (var y = 0; y < subregionRows; y++)
            {
                for (var x = 0; x < subregionCols; x++)
                {
                    if (in_subregion[y, x].IsWalkable)
                    {
                        var currentSpace = new MapSpace(x, y, in_subregion[y, x]);

                        var northSpace = y > 0 && in_subregion[y - 1, x].IsWalkable
                            ? new MapSpace(x, y - 1, in_subregion[y - 1, x])
                            : (MapSpace?)null;
                        var westSpace = x > 0 && in_subregion[y, x - 1].IsWalkable
                            ? new MapSpace(x - 1, y, in_subregion[y, x - 1])
                            : (MapSpace?)null;

                        if (null == northSpace && null == westSpace)
                        {
                            var newPWA = new HashSet<MapSpace> { currentSpace };
                            PWAs.Add(newPWA);
                        }
                        else if (null != northSpace && null != westSpace)
                        {
                            var northPWA = PWAs.Find(pwa => pwa.Contains((MapSpace)northSpace));
                            var westPWA = PWAs.Find(pwa => pwa.Contains((MapSpace)westSpace));
                            if (northPWA == westPWA)
                            {
                                northPWA.Add(currentSpace);
                            }
                            else
                            {
                                var combinedPWA = new HashSet<MapSpace>(northPWA.Union(westPWA)) { currentSpace };
                                PWAs.Remove(northPWA);
                                PWAs.Remove(westPWA);
                                PWAs.Add(combinedPWA);
                            }
                        }
                        else if (null == northSpace)
                        {
                            PWAs.Find(pwa => pwa.Contains((MapSpace)westSpace)).Add(currentSpace);
                        }
                        else if (null == westSpace)
                        {
                            PWAs.Find(pwa => pwa.Contains((MapSpace)northSpace)).Add(currentSpace);
                        }
                    }
                }
            }

            var PWAsTooSmall = new HashSet<HashSet<MapSpace>>(PWAs.Where(pwa => pwa.Count < Rules.Recipes.Room.MinWalkableSpaces));
            var PWAsTooLarge = new HashSet<HashSet<MapSpace>>(PWAs.Where(pwa => pwa.Count > Rules.Recipes.Room.MaxWalkableSpaces));
            var PWAsDiscontinuous = new HashSet<HashSet<MapSpace>>(PWAs.Where(pwa => !new MapSpaceCollection(pwa).AllSpacesAreReachable(in_subregion, space => space.Content.IsWalkable)));
            var results = new List<HashSet<MapSpace>>(PWAs.Except(PWAsTooSmall).Except(PWAsTooLarge).Except(PWAsDiscontinuous));

            return results.ConvertAll(hashOfSpaces => new MapSpaceCollection(hashOfSpaces));
        }
    }
}
