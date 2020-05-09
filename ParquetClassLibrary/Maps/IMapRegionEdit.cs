using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using ParquetClassLibrary.Properties;

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
        /// <summary>
        /// Given the name of a directional property, finds the name of the property for the opposite direction.
        /// </summary>
        /// <param name="inPropertyName">
        /// One of:
        /// - <see cref="RegionToTheNorth"/>
        /// - <see cref="RegionToTheEast"/>
        /// - <see cref="RegionToTheSouth"/>
        /// - <see cref="RegionToTheWest"/>
        /// - <see cref="RegionAbove"/>
        /// - <see cref="RegionBelow"/>
        /// </param>
        /// <returns>The name of the property in the opposite direction.</returns>
        /// <remarks>
        /// Provided to support optional consistency checks for region exits.
        /// <seealso cref="CheckExitConsistency"/>
        /// </remarks>
        private static string GetDual(string inPropertyName)
            => inPropertyName switch
            {
                nameof(RegionToTheNorth) => nameof(RegionToTheSouth),
                nameof(RegionToTheEast) => nameof(RegionToTheWest),
                nameof(RegionToTheSouth) => nameof(RegionToTheNorth),
                nameof(RegionToTheWest) => nameof(RegionToTheEast),
                nameof(RegionAbove) => nameof(RegionBelow),
                nameof(RegionBelow) => nameof(RegionAbove),
                _ => throw new ArgumentException(string.Format(CultureInfo.CurrentCulture,
                                                               Resources.ErrorUndefinedDirection,
                                                               nameof(inPropertyName)))
            };

        /// <summary>
        /// Given the name of a directional property, finds the value of the property for the opposite direction.
        /// </summary>
        /// <param name="inMap">The instance whose property's value is sought.</param>
        /// <param name="inPropertyName">
        /// One of:
        /// - <see cref="RegionToTheNorth"/>
        /// - <see cref="RegionToTheEast"/>
        /// - <see cref="RegionToTheSouth"/>
        /// - <see cref="RegionToTheWest"/>
        /// - <see cref="RegionAbove"/>
        /// - <see cref="RegionBelow"/>
        /// </param>
        /// <returns>The value of the property in the opposite direction.</returns>
        /// <remarks>
        /// Provided to support optional consistency checks for region exits.
        /// <seealso cref="CheckExitConsistency"/>
        /// </remarks>
        public static ModelID GetDualValue(IMapRegionEdit inMap, string inPropertyName)
            => (ModelID)typeof(IMapRegionEdit).GetProperty(GetDual(inPropertyName)).GetValue(inMap);

        /// <summary>
        /// Detemines if the region connection to the given region in the given direction itself connects back to the given region
        /// in the opposite direction.
        ///
        /// For example, if the player leaves Region 1 by going North and finds themselves in Region 2,
        /// they should be able to return to Region 1 by going South from Region 2.  If this is not possible, that is inconsistent.
        /// </summary>
        /// <typeparam name="TMapType">A type derived from <see cref="MapModel"/> that implements <see cref="IMapRegionEdit"/>.</typeparam>
        /// <param name="inMap">The origination and destination region.</param>
        /// <param name="inPropertyName">The direction to inspect from which the given region may be exited.</param>
        /// <returns><c>true</c> if the exits are consistent, <c>false</c> otherwise.</returns>
        public static bool CheckExitConsistencyForDirection<TMapType>(TMapType inMap, string inPropertyName)
            where TMapType : MapModel, IMapRegionEdit
        {
            // The ID of the region that inMap connects to.
            var adjacentRegionID = (ModelID)typeof(IMapRegionEdit).GetProperty(inPropertyName).GetValue(inMap);

            // The region that inMap connects to.
            var adjacentRegion = All.Maps.Get<TMapType>(adjacentRegionID);

            // The ID of the region that adjacentRegion connects back to.
            // If the connection is consistent, this is the ID for inMap.
            var adjacentRegionsAdjacentRegionID = GetDualValue(adjacentRegion, inPropertyName);

            return adjacentRegionsAdjacentRegionID != inMap.ID;
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
        public static List<string> CheckExitConsistency<TMapType>(TMapType inMap)
            where TMapType : MapModel, IMapRegionEdit
        {
            var inconsistentExitDirections = new List<string>();
            if(!CheckExitConsistencyForDirection(inMap, nameof(inMap.RegionToTheNorth)))
            {
                inconsistentExitDirections.Add(nameof(inMap.RegionToTheNorth));
            }
            if (!CheckExitConsistencyForDirection(inMap, nameof(inMap.RegionToTheEast)))
            {
                inconsistentExitDirections.Add(nameof(inMap.RegionToTheEast));
            }
            if (!CheckExitConsistencyForDirection(inMap, nameof(inMap.RegionToTheSouth)))
            {
                inconsistentExitDirections.Add(nameof(inMap.RegionToTheSouth));
            }
            if (!CheckExitConsistencyForDirection(inMap, nameof(inMap.RegionToTheWest)))
            {
                inconsistentExitDirections.Add(nameof(inMap.RegionToTheWest));
            }
            if (!CheckExitConsistencyForDirection(inMap, nameof(inMap.RegionAbove)))
            {
                inconsistentExitDirections.Add(nameof(inMap.RegionAbove));
            }
            if (!CheckExitConsistencyForDirection(inMap, nameof(inMap.RegionBelow)))
            {
                inconsistentExitDirections.Add(nameof(inMap.RegionBelow));
            }

            return inconsistentExitDirections;
        }
        #endregion
    }
}
