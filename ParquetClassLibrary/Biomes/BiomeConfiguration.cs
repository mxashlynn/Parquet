using ParquetClassLibrary.Maps;

namespace ParquetClassLibrary.Biomes
{
    /// <summary>
    /// Provides rules for determining a <see cref="MapRegion"/>'s <see cref="BiomeModel"/>.
    /// </summary>
    // TODO Make this configurable via CSV.
    public static class BiomeConfiguration
    {
        #region Class Defaults
        /// <summary>Used in computing thresholds.</summary>
        private const int ParquetsPerLayer = MapRegion.ParquetsPerRegionDimension * MapRegion.ParquetsPerRegionDimension;
        #endregion

        // TODO This should be read from a file.
        /// <summary>
        /// There must be at least this percentage of non-liquid <see cref="Parquets.ParquetModel"/>s in a given
        /// <see cref="MapRegion"/> to generate the <see cref="BiomeModel"/> associated with them.
        /// </summary>
        internal static int LandThresholdFactor = 5 / 4;

        /// <summary>1 and 1/4th of a layers' worth of parquets must contribute to a land-based <see cref="BiomeModel"/>.</summary>
        internal static int LandThreshold = ParquetsPerLayer * LandThresholdFactor;

        // TODO This should be read from a file.
        /// <summary>
        /// There must be at least this percentage of liquid <see cref="Parquets.ParquetModel"/>s in a given
        /// <see cref="MapRegion"/> to generate the <see cref="BiomeModel"/> associated with them.
        /// </summary>
        internal static int LiquidThresholdFactor = 1 / 4;

        /// <summary>3/4ths of a layers' worth of parquets must contribute to a fluid-based <see cref="BiomeModel"/>.</summary>
        internal static int FluidThreshold => ParquetsPerLayer * LiquidThresholdFactor;
    }
}
