#if DESIGN
using System.Collections.Generic;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Properties;

namespace ParquetClassLibrary.EditorSupport
{
    /// <summary>
    /// Provides optional analysis for compatible <see cref="MapModel"/>s.
    /// </summary>
    internal static class MapAnalysis<TMapType>
        where TMapType : MapModel, IMutableMapRegion
    {
        /// <summary>
        /// Models a method that takes a map and returns the <see cref="ModelID" /> for an adjacent map.
        /// </summary>
        internal delegate ModelID IDByDirection(TMapType inMap);

        /// <summary>
        /// A database of directions and their opposites, together with the properties needed to inspect both.
        /// </summary>
        internal static List<(IDByDirection GetLeavingRegionID,
                              string LeavingDirection,
                              IDByDirection GetReturningRegionID,
                              string ReturningDirection)> Directions =
            new List<(IDByDirection, string, IDByDirection, string)>
            {
                { ((TMapType map) => map.RegionToTheNorthID, Resources.DirectionNorth,
                   (TMapType map) => map.RegionToTheSouthID, Resources.DirectionSouth) },
                { ((TMapType map) => map.RegionToTheEastID, Resources.DirectionEast,
                   (TMapType map) => map.RegionToTheWestID, Resources.DirectionWest) },
                { ((TMapType map) => map.RegionToTheSouthID, Resources.DirectionSouth,
                   (TMapType map) => map.RegionToTheNorthID, Resources.DirectionNorth) },
                { ((TMapType map) => map.RegionToTheWestID, Resources.DirectionWest,
                   (TMapType map) => map.RegionToTheEastID, Resources.DirectionEast) },
                { ((TMapType map) => map.RegionAboveID, Resources.DirectionAbove,
                   (TMapType map) => map.RegionBelowID, Resources.DirectionBelow) },
                { ((TMapType map) => map.RegionBelowID, Resources.DirectionBelow,
                   (TMapType map) => map.RegionAboveID, Resources.DirectionAbove) },
            };
    }

    /// <summary>
    /// Provides optional analysis for compatible <see cref="MapModel"/>s.
    /// </summary>
    public static class MapAnalysis
    {
        /// <summary>
        /// Finds adjacent maps from which the given map is not adjacent in the expected direction.
        ///
        /// That is, if the player leaves Region 1 by going North and cannot then return to Region 1 by going south,
        /// that is considered inconsistent and will be reported.
        /// </summary>
        /// <typeparam name="TMapType">A type derived from <see cref="MapModel"/> that implements <see cref="IMutableMapRegion"/>.</typeparam>
        /// <param name="inRegionID">The <see cref="ModelID"/> of the origination and destination map.</param>
        /// <returns>A report of all exit directions leading to regions whose own exits are inconsistent.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0042:Deconstruct variable declaration",
            Justification = "In this instance deconstruction makes the code harder to read.")]
        public static List<string> CheckExitConsistency<TMapType>(ModelID inRegionID)
            where TMapType : MapModel, IMutableMapRegion
        {
            var inconsistentExitDirections = new List<string>();

            if (inRegionID == ModelID.None)
            {
                return inconsistentExitDirections;
            }

            var currentRegion = All.Maps.Get<TMapType>(inRegionID);
            foreach (var directionPair in MapAnalysis<TMapType>.Directions)
            {
                var adjacentRegionID = directionPair.GetLeavingRegionID(currentRegion);
                if (adjacentRegionID == ModelID.None)
                {
                    continue;
                }

                var adjacentRegion = All.Maps.Get<TMapType>(adjacentRegionID);
                if (directionPair.GetReturningRegionID(adjacentRegion) != inRegionID)
                {
                    inconsistentExitDirections.Add(
                        $"{adjacentRegion.Name} is {directionPair.LeavingDirection} of {currentRegion.Name} but " +
                        $"{currentRegion.Name} is not {directionPair.ReturningDirection} of {adjacentRegion.Name}.\n");
                }
            }

            return inconsistentExitDirections;
        }
    }
}
#endif
