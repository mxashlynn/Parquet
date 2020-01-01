using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ParquetClassLibrary.Maps;
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
    public class RoomCollection : IReadOnlyCollection<Room>
    {
        /// <summary>The internal collection mechanism.</summary>
        private IReadOnlyList<Room> Rooms { get; }

        /// <summary>The number of <see cref="Entity"/>s in the <see cref="RoomCollection"/>.</summary>
        public int Count => Rooms?.Count ?? 0;

        /// <summary>
        /// Determines whether the <see cref="RoomCollection"/> contains the specified <see cref="Room"/>.
        /// </summary>
        /// <param name="inRoom">The <see cref="Room"/> to find.</param>
        /// <returns><c>true</c> if the <see cref="Room"/> was found; <c>false</c> otherwise.</returns>
        public bool Contains(Room inRoom)
            => Rooms.Contains(inRoom);

        /// <summary>
        /// Returns the <see cref="Room"/> at the given position, if there is one.
        /// </summary>
        /// <param name="inPosition">An in-bounds position to search for a <see cref="Room"/>.</param>
        /// <returns>The specified <see cref="Room"/> if found; otherwise, null.</returns>
        public Room GetRoomAt(Vector2D inPosition)
            => Rooms.FirstOrDefault(room => room.ContainsPosition(inPosition));

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomCollection"/> class.
        /// </summary>
        /// <remarks>Private so that empty <see cref="RoomCollection"/>s are not made in client code.</remarks>
        private RoomCollection(IEnumerable<Room> inRooms)
        {
            Rooms = inRooms.ToList();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomCollection"/> class.
        /// </summary>
        /// <param name="inSubregion">The collection of parquets to search for <see cref="Room"/>s.</param>
        /// <returns>An initialized <see cref="RoomCollection"/>.</returns>
        public static RoomCollection CreateFromSubregion(ParquetStackGrid inSubregion)
        {
            Precondition.IsNotNull(inSubregion, nameof(inSubregion));

            var walkableAreas = inSubregion.GetWalkableAreas();
            MapSpaceCollection perimeter = MapSpaceCollection.Empty;

            var rooms = walkableAreas
                        .Where(walkableArea => walkableArea.TryGetPerimeter(out perimeter)
                                            && walkableArea.Concat(perimeter).Any(space => All.Parquets.Get<Furnishing>(space.Content.Furnishing)?.IsEntry ?? false)
                                            && walkableArea.Any(space => space.IsWalkableEntry
                                                                      || space.Neighbors().Any(neighbor => neighbor.IsEnclosingEntry(walkableArea))))
                        .Select(walkableArea => new Room(walkableArea, perimeter));

            return new RoomCollection(rooms);
        }
        #endregion

        #region Collection Access
        /// <summary>
        /// Exposes an <see cref="IEnumerator"/>, which supports simple iteration.
        /// </summary>
        /// <returns>An enumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
            => Rooms.GetEnumerator();

        /// <summary>
        /// Retrieves an enumerator for the <see cref="RoomCollection"/>.
        /// </summary>
        /// <returns>An enumerator that iterates through the collection.</returns>
        public IEnumerator<Room> GetEnumerator()
            => Rooms.GetEnumerator();
        #endregion

        #region Utilities
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
    /// Extension methods used only by <see cref="RoomCollection"/> when analyzing subregions of <see cref="MapSpace"/>s.
    /// </summary>
    internal static class ParquetStackExtensions
    {
        /// <summary>
        /// Finds all valid Walkable Areas in a given subregion.
        /// </summary>
        /// <param name="inSubregion">The <see cref="ParquetStackGrid"/>s to search.</param>
        /// <returns>The list of vallid Walkable Areas.</returns>
        internal static List<MapSpaceCollection> GetWalkableAreas(this ParquetStackGrid inSubregion)
        {
            var PWAs = new List<HashSet<MapSpace>>();
            var subregionRows = inSubregion.Rows;
            var subregionCols = inSubregion.Columns;

            for (var y = 0; y < subregionRows; y++)
            {
                for (var x = 0; x < subregionCols; x++)
                {
                    if (inSubregion[y, x].IsWalkable)
                    {
                        var currentSpace = new MapSpace(x, y, inSubregion[y, x], inSubregion);

                        var northSpace = y > 0 && inSubregion[y - 1, x].IsWalkable
                            ? new MapSpace(x, y - 1, inSubregion[y - 1, x], inSubregion)
                            : MapSpace.Empty;
                        var westSpace = x > 0 && inSubregion[y, x - 1].IsWalkable
                            ? new MapSpace(x - 1, y, inSubregion[y, x - 1], inSubregion)
                            : MapSpace.Empty;

                        if (MapSpace.Empty == northSpace && MapSpace.Empty == westSpace)
                        {
                            var newPWA = new HashSet<MapSpace> { currentSpace };
                            PWAs.Add(newPWA);
                        }
                        else if (MapSpace.Empty != northSpace && MapSpace.Empty != westSpace)
                        {
                            var northPWA = PWAs.Find(pwa => pwa.Contains(northSpace));
                            var westPWA = PWAs.Find(pwa => pwa.Contains(westSpace));
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
                        else if (MapSpace.Empty != westSpace)
                        {
                            PWAs.Find(pwa => pwa.Contains(westSpace)).Add(currentSpace);
                        }
                        else if (MapSpace.Empty != northSpace)
                        {
                            PWAs.Find(pwa => pwa.Contains(northSpace)).Add(currentSpace);
                        }
                    }
                }
            }

            var PWAsTooSmall = new HashSet<HashSet<MapSpace>>(PWAs.Where(pwa => pwa.Count < Rules.Recipes.Room.MinWalkableSpaces));
            var PWAsTooLarge = new HashSet<HashSet<MapSpace>>(PWAs.Where(pwa => pwa.Count > Rules.Recipes.Room.MaxWalkableSpaces));
            var PWAsDiscontinuous = new HashSet<HashSet<MapSpace>>(PWAs.Where(pwa => !new MapSpaceCollection(pwa).AllSpacesAreReachable(space => space.Content.IsWalkable)));
            var results = new List<HashSet<MapSpace>>(PWAs.Except(PWAsTooSmall).Except(PWAsTooLarge).Except(PWAsDiscontinuous));

            return results.ConvertAll(hashOfSpaces => new MapSpaceCollection(hashOfSpaces));
        }
    }
}
