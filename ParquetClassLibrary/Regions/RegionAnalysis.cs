using System.Collections.Generic;
using Parquet.Properties;

namespace Parquet.Regions
{
    /// <summary>
    /// Provides optional analysis for compatible <see cref="RegionModel"/>s.
    /// </summary>
    internal static class RegionAnalysis
    {
        /// <summary>
        /// Models a method that takes a map and returns the <see cref="ModelID" /> for an adjacent map.
        /// </summary>
        internal delegate ModelID IDByDirection(RegionModel inRegion);

        /// <summary>
        /// A database of directions and their opposites, together with the properties needed to inspect both.
        /// </summary>
        internal static readonly IReadOnlyCollection<(IDByDirection GetLeavingRegionID,
                                                      string LeavingDirection,
                                                      IDByDirection GetReturningRegionID,
                                                      string ReturningDirection)>
            Directions = new List<(IDByDirection, string, IDByDirection, string)>
            {
                { (map => map.RegionToTheNorth, Resources.DirectionNorth,
                   map => map.RegionToTheSouth, Resources.DirectionSouth) },
                { (map => map.RegionToTheEast, Resources.DirectionEast,
                   map => map.RegionToTheWest, Resources.DirectionWest) },
                { (map => map.RegionToTheSouth, Resources.DirectionSouth,
                   map => map.RegionToTheNorth, Resources.DirectionNorth) },
                { (map => map.RegionToTheWest, Resources.DirectionWest,
                   map => map.RegionToTheEast, Resources.DirectionEast) },
                { (map => map.RegionAbove, Resources.DirectionAbove,
                   map => map.RegionBelow, Resources.DirectionBelow) },
                { (map => map.RegionBelow, Resources.DirectionBelow,
                   map => map.RegionAbove, Resources.DirectionAbove) },
            };
    }

    /// <summary>
    /// Provides optional analysis for compatible <see cref="RegionModel"/>s.
    /// </summary>
    public static class MapAnalysis
    {
        /// <summary>
        /// Finds adjacent maps from which the given map is not adjacent in the expected direction.
        ///
        /// That is, if the player leaves Region 1 by going North and cannot then return to Region 1 by going south,
        /// that is considered inconsistent and will be reported.
        /// </summary>
        /// <param name="inRegionID">The <see cref="ModelID"/> of the origination and destination map.</param>
        /// <returns>A report of all exit directions leading to regions whose own exits are inconsistent.</returns>
        public static ICollection<string> CheckExitConsistency(ModelID inRegionID)
        {
            var inconsistentExitDirections = new List<string>();

            if (inRegionID == ModelID.None)
            {
                return inconsistentExitDirections;
            }

            var currentRegion = All.RegionModels.GetOrNull<RegionModel>(inRegionID);

            if (currentRegion is null)
            {
                return inconsistentExitDirections;
            }

            foreach (var directionPair in RegionAnalysis.Directions)
            {
                var adjacentRegionID = directionPair.GetLeavingRegionID(currentRegion);
                if (adjacentRegionID == ModelID.None)
                {
                    continue;
                }

                var adjacentRegion = All.RegionModels.GetOrNull<RegionModel>(adjacentRegionID);
                if (adjacentRegion is not null)
                {
                    continue;
                }

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
