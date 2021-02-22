using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Parquet.Properties;

namespace Parquet.Regions
{
    /// <summary>
    /// Provides optional analysis for compatible <see cref="MapModel"/>s.
    /// </summary>
    internal static class MapAnalysis<TMapType>
        where TMapType : RegionModel, IMapConnections
    {
        /// <summary>
        /// Models a method that takes a map and returns the <see cref="ModelID" /> for an adjacent map.
        /// </summary>
        internal delegate ModelID IDByDirection(TMapType inMap);

        /// <summary>
        /// A database of directions and their opposites, together with the properties needed to inspect both.
        /// </summary>
        internal static readonly IReadOnlyCollection<(IDByDirection GetLeavingRegionID,
                                                      string LeavingDirection,
                                                      IDByDirection GetReturningRegionID,
                                                      string ReturningDirection)>
            Directions = new List<(IDByDirection, string, IDByDirection, string)>
            {
                { ((TMapType map) => map.RegionToTheNorth, Resources.DirectionNorth,
                   (TMapType map) => map.RegionToTheSouth, Resources.DirectionSouth) },
                { ((TMapType map) => map.RegionToTheEast, Resources.DirectionEast,
                   (TMapType map) => map.RegionToTheWest, Resources.DirectionWest) },
                { ((TMapType map) => map.RegionToTheSouth, Resources.DirectionSouth,
                   (TMapType map) => map.RegionToTheNorth, Resources.DirectionNorth) },
                { ((TMapType map) => map.RegionToTheWest, Resources.DirectionWest,
                   (TMapType map) => map.RegionToTheEast, Resources.DirectionEast) },
                { ((TMapType map) => map.RegionAbove, Resources.DirectionAbove,
                   (TMapType map) => map.RegionBelow, Resources.DirectionBelow) },
                { ((TMapType map) => map.RegionBelow, Resources.DirectionBelow,
                   (TMapType map) => map.RegionAbove, Resources.DirectionAbove) },
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
        [SuppressMessage("Style", "IDE0042:Deconstruct variable declaration",
                         Justification = "In this instance deconstruction makes the code harder to read.")]
        public static ICollection<string> CheckExitConsistency<TMapType>(ModelID inRegionID)
            where TMapType : RegionModel, IMapConnections
        {
            var inconsistentExitDirections = new List<string>();

            if (inRegionID == ModelID.None)
            {
                return inconsistentExitDirections;
            }

            var currentRegion = All.RegionModels.GetOrNull<TMapType>(inRegionID);

            if (currentRegion is null)
            {
                return inconsistentExitDirections;
            }

            foreach (var directionPair in MapAnalysis<TMapType>.Directions)
            {
                var adjacentRegionID = directionPair.GetLeavingRegionID(currentRegion);
                if (adjacentRegionID == ModelID.None)
                {
                    continue;
                }

                var adjacentRegion = All.RegionModels.GetOrNull<TMapType>(adjacentRegionID);
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
