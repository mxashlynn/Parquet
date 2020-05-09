using System.Collections.Generic;

namespace ParquetClassLibrary.Maps
{
    /// <summary>
    /// Facilitates editing of <see cref="MapRegion"/> characteristics from design tools while maintaining a read-only face for use during play.
    /// </summary>
    internal interface IMapRegionEdit
    {
        /// <summary>What the region is called in-game.</summary>
        string Name { get; set; }

        /// <summary>A color to display in any empty areas of the region.</summary>
        string BackgroundColor { get; set; }

        /// <summary>The <see cref="ModelID"/> of the region to the north of this one.</summary>
        ModelID RegionToTheNorth { get; set; }

        /// <summary>The <see cref="ModelID"/> of the region to the east of this one.</summary>
        ModelID RegionToTheEast { get; set; }

        /// <summary>The <see cref="ModelID"/> of the region to the south of this one.</summary>
        ModelID RegionToTheSouth { get; set; }

        /// <summary>The <see cref="ModelID"/> of the region to the west of this one.</summary>
        ModelID RegionToTheWest { get; set; }

        /// <summary>The <see cref="ModelID"/> of the region above this one.</summary>
        ModelID RegionAbove { get; set; }

        /// <summary>The <see cref="ModelID"/> of the region below this one.</summary>
        ModelID RegionBelow { get; set; }

        #region Map Analysis
        internal delegate ModelID IDByDirection<TMapType>(TMapType inMap)
            where TMapType : MapModel, IMapRegionEdit;

        internal class DualDirections<TMapType>
            where TMapType : MapModel, IMapRegionEdit
        {
            public IDByDirection<TMapType> GetAdjecentRegionID;
            public string LeavingDirection;
            public IDByDirection<TMapType> GetAdjecentRegionsAdjacentRegionID;
            public string ReturningDirection;

            public DualDirections(IDByDirection<TMapType> inGetAdjecentRegionID,
                                  string inLeavingDirection,
                                  IDByDirection<TMapType> inGetAdjecentRegionsAdjacentRegionID,
                                  string inReturningDirection)
            {
                GetAdjecentRegionID = inGetAdjecentRegionID;
                LeavingDirection = inLeavingDirection;
                GetAdjecentRegionsAdjacentRegionID = inGetAdjecentRegionsAdjacentRegionID;
                ReturningDirection = inReturningDirection;
            }
        }

        private static class DirectionDB<TMapType>
            where TMapType : MapModel, IMapRegionEdit
        {
            public static List<DualDirections<TMapType>>
                Directions = new List<DualDirections<TMapType>>
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
                                                    (TMapType map) => map.RegionAbove, "anove" ) },
                };
        }

        /// <summary>
        /// Finds exit directions leading to any regions adjacent to the given region for which the given region is not adjacent.
        ///
        /// That is, if the player leaves Region 1 by going North and cannot return to Region 1 by going then south,
        /// that is considered inconsistent and will be reported.
        /// </summary>
        /// <typeparam name="TMapType">A type derived from <see cref="MapModel"/> that implements <see cref="IMapRegionEdit"/>.</typeparam>
        /// <param name="inMap">The origination and destination region.</param>
        /// <returns>A collection of the names of all exit directions leading to regions whose own exits are inconsistent.</returns>
        public static List<string> CheckExitConsistency<TMapType>(ModelID inRegionID)
            where TMapType : MapModel, IMapRegionEdit
        {
            var inconsistentExitDirections = new List<string>();
            var currentRegion = All.Maps.Get<TMapType>(inRegionID);
            foreach (var directionPair in DirectionDB<TMapType>.Directions)
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
        #endregion
    }
}
