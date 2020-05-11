using System.Collections.Generic;

namespace ParquetClassLibrary.Maps
{
    /// <summary>
    /// Provides optional analysis for compatible <see cref="MapModel"/>s.
    /// </summary>
    internal static class MapAnalysis<TMapType>
        where TMapType : MapModel, IMapRegionEdit
    {
        /// <summary>
        /// Models a method that takes a map and returns the <see cref="ModelID" /> for an adjacent map.
        /// </summary>
        internal delegate ModelID IDByDirection(TMapType inMap);

        /// <summary>
        /// A direction and its opposite, together with the properties needed to inspect both.
        /// </summary>
        internal class DualDirections<TMapType2>
            where TMapType2 : MapModel, IMapRegionEdit
        {
            ///<summary>The property identifying the adjacent map if one leaves the original map.</summary>
            public IDByDirection GetAdjecentRegionID;

            ///<summary>The direction in with the to leave.</summary>
            public string LeavingDirection;

            ///<summary>The property identifying the map one would find when attempting to return to the the original map.</summary>
            public IDByDirection GetAdjecentRegionsAdjacentRegionID;

            ///<summary>The direction one would expect to take in order to return.</summary>
            public string ReturningDirection;

            ///<summary>Initializes an instance of <see cref="DualDirections{TMapType}"/>.</summary>
            public DualDirections(IDByDirection inGetAdjecentRegionID,
                                  string inLeavingDirection,
                                  IDByDirection inGetAdjecentRegionsAdjacentRegionID,
                                  string inReturningDirection)
            {
                GetAdjecentRegionID = inGetAdjecentRegionID;
                LeavingDirection = inLeavingDirection;
                GetAdjecentRegionsAdjacentRegionID = inGetAdjecentRegionsAdjacentRegionID;
                ReturningDirection = inReturningDirection;
            }
        }

        /// <summary>
        /// A database of directions and their opposites, together with the properties needed to inspect both.
        /// </summary>
        internal static List<DualDirections<TMapType>> Directions = new List<DualDirections<TMapType>>
            {
                { new DualDirections<TMapType>( (TMapType map) => map.RegionToTheNorth, "north",
                                                (TMapType map) => map.RegionToTheSouth, "south" ) },

                { new DualDirections<TMapType>( (TMapType map) => map.RegionToTheEast, "east",
                                                (TMapType map) => map.RegionToTheWest, "west" ) },

                { new DualDirections<TMapType>( (TMapType map) => map.RegionToTheSouth, "south",
                                                (TMapType map) => map.RegionToTheNorth, "north" ) },

                { new DualDirections<TMapType>( (TMapType map) => map.RegionToTheWest, "west",
                                                (TMapType map) => map.RegionToTheEast, "east" ) },

                { new DualDirections<TMapType>( (TMapType map) => map.RegionAbove, "above",
                                                (TMapType map) => map.RegionBelow, "below" ) },

                { new DualDirections<TMapType>( (TMapType map) => map.RegionBelow, "below",
                                                (TMapType map) => map.RegionAbove, "above" ) },
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
        /// <typeparam name="TMapType">A type derived from <see cref="MapModel"/> that implements <see cref="IMapRegionEdit"/>.</typeparam>
        /// <param name="inRegionID">The <see cref="ModelID"/> of the origination and destination map.</param>
        /// <returns>A report of all exit directions leading to regions whose own exits are inconsistent.</returns>
        public static List<string> CheckExitConsistency<TMapType>(ModelID inRegionID)
            where TMapType : MapModel, IMapRegionEdit
        {
            var inconsistentExitDirections = new List<string>();

            var currentRegion = All.Maps.Get<TMapType>(inRegionID);
            foreach (var directionPair in MapAnalysis<TMapType>.Directions)
            {
                var adjacentRegionID = directionPair.GetAdjecentRegionID(currentRegion);
                var adjacentRegion = All.Maps.Get<TMapType>(adjacentRegionID);
                if (directionPair.GetAdjecentRegionsAdjacentRegionID(adjacentRegion) != inRegionID)
                {
                    inconsistentExitDirections.Add(
                        $"{adjacentRegion.Name} is {directionPair.LeavingDirection} of {currentRegion.Name} but " +
                        $"{currentRegion.Name} is not {directionPair.ReturningDirection} of {adjacentRegion.Name}.");
                }
            }

            return inconsistentExitDirections;
        }
    }
}
