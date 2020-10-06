using System;
using System.Collections.Generic;
using System.Linq;
using ParquetClassLibrary.Parquets;

namespace ParquetClassLibrary.Rooms
{
    /// <summary>
    /// Extensions to <see cref="ParquetStackGrid"/> for analyzing subregions of <see cref="ParquetStack"/>s
    /// to find all valid <see cref="Room"/>s within them.
    /// </summary>
    /// <remarks>
    /// For a complete explanation of the algorithm implemented here, see:
    /// <a href="https://github.com/mxashlynn/Parquet/blob/master/Documentation/4.-Room_Detection_and_Type_Assignment.md"/>
    /// </remarks>
    public static class ParquetStackGridExtensions
    {
        /// <summary>
        /// Initializes a new <see cref="IReadOnlyCollection{Room}"/> from the current <see cref="ParquetStackGrid"/>.
        /// </summary>
        /// <param name="inSubregion">The current collection of parquets to search for <see cref="Room"/>s.</param>
        /// <returns>An initialized collection of rooms.</returns>
        public static IReadOnlyCollection<Room> CreateRoomCollectionFromSubregion(this ParquetStackGrid inSubregion)
        {
            Precondition.IsNotNull(inSubregion, nameof(inSubregion));

            var walkableAreas = GetWalkableAreas(inSubregion);
            var perimeter = MapSpaceSetExtensions.Empty;
            var rooms =
                walkableAreas
                .Where(walkableArea => walkableArea.TryGetPerimeter(out perimeter)
                                    && walkableArea.Any(space => space.IsWalkableEntry
                                                              || space.Neighbors()
                                                                      .Any(neighbor => neighbor.IsEnclosingEntry(walkableArea))))
                .Select(walkableArea => new Room(walkableArea, perimeter))
                .ToList();
            return rooms;
        }

        /// <summary>
        /// Finds all valid Walkable Areas in a given subregion.
        /// </summary>
        /// <param name="inSubregion">The <see cref="ParquetStackGrid"/>s to search.</param>
        /// <returns>The list of vallid Walkable Areas.</returns>
        private static IReadOnlyList<ISet<MapSpace>> GetWalkableAreas(ParquetStackGrid inSubregion)
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

            var PWAsTooSmall = new HashSet<HashSet<MapSpace>>(PWAs.Where(pwa => pwa.Count < RoomConfiguration.MinWalkableSpaces));
            var PWAsTooLarge = new HashSet<HashSet<MapSpace>>(PWAs.Where(pwa => pwa.Count > RoomConfiguration.MaxWalkableSpaces));
            var PWAsDiscontinuous = new HashSet<HashSet<MapSpace>>(PWAs.Where(pwa => !pwa.AllSpacesAreReachable(space => space.Content.IsWalkable)));
            var results = new List<HashSet<MapSpace>>(PWAs.Except(PWAsTooSmall).Except(PWAsTooLarge).Except(PWAsDiscontinuous));

            return results.Cast<ISet<MapSpace>>().ToList();
        }
    }
}
