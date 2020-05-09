using System;
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
        /// <seealso cref="???"/>
        /// </remarks>
        string GetDual(string inPropertyName)
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
        /// <seealso cref="???"/>
        /// </remarks>
        public ModelID GetDualValue(IMapRegionEdit inMap, string inPropertyName)
            => (ModelID)typeof(IMapRegionEdit).GetProperty(inPropertyName).GetValue(inMap);
        /*
        public ModelID GetDualValue<T>(T inInstance, string inPropertyName)
            where T : IMapRegionEdit
            => (ModelID)typeof(IMapRegionEdit).GetProperty(inPropertyName).GetValue(inInstance);
        */
        #endregion
    }
}
