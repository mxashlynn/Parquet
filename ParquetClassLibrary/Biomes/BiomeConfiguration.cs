using System;
using System.Globalization;
using System.IO;
using System.Text;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Properties;

namespace ParquetClassLibrary.Biomes
{
    /// <summary>
    /// Provides rules for determining a <see cref="MapRegion"/>'s <see cref="BiomeModel"/>.
    /// </summary>
    public static class BiomeConfiguration
    {
        #region Class Defaults
        /// <summary>Used in computing thresholds.</summary>
        private const int ParquetsPerLayer = MapRegion.ParquetsPerRegionDimension * MapRegion.ParquetsPerRegionDimension;
        #endregion

        /// <summary>
        /// There must be at least this percentage of non-liquid <see cref="Parquets.ParquetModel"/>s in a given
        /// <see cref="MapRegion"/> to generate the <see cref="BiomeModel"/> associated with them.
        /// </summary>
        internal static float LandThresholdFactor { get; private set; }

        /// <summary>1 and 1/4th of a layers' worth of parquets must contribute to a land-based <see cref="BiomeModel"/>.</summary>
        internal static float LandThreshold => ParquetsPerLayer * LandThresholdFactor;

        /// <summary>
        /// There must be at least this percentage of liquid <see cref="Parquets.ParquetModel"/>s in a given
        /// <see cref="MapRegion"/> to generate the <see cref="BiomeModel"/> associated with them.
        /// </summary>
        internal static float LiquidThresholdFactor { get; private set; }

        /// <summary>3/4ths of a layers' worth of parquets must contribute to a fluid-based <see cref="BiomeModel"/>.</summary>
        internal static float FluidThreshold => ParquetsPerLayer * LiquidThresholdFactor;

        #region Self Serialization
        /// <summary>
        /// Reads <see cref="BiomeConfiguration"/> data from the appropriate file.
        /// </summary>
        /// <returns>The instances read.</returns>
        public static void GetRecord()
        {
            using var reader = new StreamReader(GetFilePath());

            // Skip the header.
            reader.ReadLine();
            // Read in the values.
            var valueLine = reader.ReadLine();
            var values = valueLine.Split(Delimiters.PrimaryDelimiter);

            // Parse.
            if (float.TryParse(values[0], out var temp))
            {
                LandThresholdFactor = temp;
            }
            else
            {
                throw new FormatException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotParse,
                                                        values[0], nameof(LandThresholdFactor)));
            }
            if (float.TryParse(values[1], out temp))
            {
                LiquidThresholdFactor = temp;
            }
            else
            {
                throw new FormatException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotParse,
                                                        values[1], nameof(LiquidThresholdFactor)));
            }
        }

        /// <summary>
        /// Writes <see cref="BiomeConfiguration"/> data to the appropriate file.
        /// </summary>
        public static void PutRecord()
        {
            using var writer = new StreamWriter(GetFilePath(), false, new UTF8Encoding(true, true));
            writer.Write($"{nameof(LandThresholdFactor)}{Delimiters.PrimaryDelimiter}{nameof(LiquidThresholdFactor)}\n");
            writer.Write($"{LandThresholdFactor}{Delimiters.PrimaryDelimiter}{LiquidThresholdFactor}\n");
        }

        /// <summary>
        /// Returns the filename and path associated with <see cref="BiomeConfiguration"/>'s designer file.
        /// </summary>
        /// <returns>A full path to the associated designer file.</returns>
        public static string GetFilePath()
            => $"{All.WorkingDirectory}/{nameof(BiomeConfiguration)}.csv";
        #endregion
    }
}
