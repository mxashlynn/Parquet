using System;
using System.Globalization;
using System.IO;
using System.Text;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Properties;

namespace ParquetClassLibrary.Biomes
{
    /// <summary>
    /// Provides rules for determining a <see cref="MapRegionModel"/>'s <see cref="BiomeRecipe"/>.
    /// </summary>
    public static class BiomeConfiguration
    {
        #region Class Defaults
        /// <summary>Used in computing thresholds.</summary>
        private const int ParquetsPerLayer = MapRegionModel.ParquetsPerRegionDimension * MapRegionModel.ParquetsPerRegionDimension;
        #endregion

        /// <summary>
        /// There must be at least this percentage of non-liquid <see cref="Parquets.ParquetModel"/>s in a given
        /// <see cref="MapRegionModel"/> to generate the <see cref="BiomeRecipe"/> associated with them.
        /// </summary>
        public static double LandThresholdFactor { get; set; } = 1.25;

        /// <summary>How many of a layers' worth of parquets must contribute to a land-based <see cref="BiomeRecipe"/>.</summary>
        public static int LandThreshold
            => (int)Math.Round(ParquetsPerLayer * LandThresholdFactor, 0, MidpointRounding.AwayFromZero);

        /// <summary>
        /// There must be at least this percentage of liquid <see cref="Parquets.ParquetModel"/>s in a given
        /// <see cref="MapRegionModel"/> to generate the <see cref="BiomeRecipe"/> associated with them.
        /// </summary>
        public static double LiquidThresholdFactor { get; set; } = 0.25;

        /// <summary>How many of a layers' worth of parquets must contribute to a Liquid-based <see cref="BiomeRecipe"/>.</summary>
        public static int LiquidThreshold
            => (int)Math.Round(ParquetsPerLayer * LiquidThresholdFactor, 0, MidpointRounding.AwayFromZero);

        /// <summary>
        /// There must be at least this percentage of <see cref="Parquets.ParquetModel"/>s included in rooms in a given
        /// <see cref="MapRegionModel"/> to generate the <see cref="BiomeRecipe"/> associated with them.
        /// </summary>
        public static double RoomThresholdFactor { get; set; } = 0.67;

        /// <summary>How many of a layers' worth of parquets must contribute to a room-based <see cref="BiomeRecipe"/>.</summary>
        public static int RoomThreshold
            => (int)Math.Round(ParquetsPerLayer * RoomThresholdFactor, 0, MidpointRounding.AwayFromZero);

        #region Self Serialization
        /// <summary>
        /// Reads <see cref="BiomeConfiguration"/> data from the appropriate file.
        /// </summary>
        /// <returns>The instances read.</returns>
        public static void GetRecord()
        {
            using var reader = new StreamReader(FilePath);

            // Skip the header.
            reader.ReadLine();
            // Read in the values.
            var valueLine = reader.ReadLine();
            var values = valueLine.Split(Delimiters.PrimaryDelimiter);

            // Parse.
            LandThresholdFactor = double.TryParse(values[0], out var temp)
                ? temp
                : throw new FormatException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotParse,
                                                          values[0], nameof(LandThresholdFactor)));
            LiquidThresholdFactor = double.TryParse(values[1], out temp)
                ? temp
                : throw new FormatException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotParse,
                                                          values[1], nameof(LiquidThresholdFactor)));
            RoomThresholdFactor = double.TryParse(values[2], out temp)
                ? temp
                : throw new FormatException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotParse,
                                                          values[2], nameof(RoomThresholdFactor)));
        }

        /// <summary>
        /// Writes <see cref="BiomeConfiguration"/> data to the appropriate file.
        /// </summary>
        public static void PutRecord()
        {
            using var writer = new StreamWriter(FilePath, false, new UTF8Encoding(true, true));
            writer.Write($"{nameof(LandThresholdFactor)}{Delimiters.PrimaryDelimiter}{nameof(LiquidThresholdFactor)}{Delimiters.PrimaryDelimiter}{nameof(RoomThresholdFactor)}\n");
            writer.Write($"{LandThresholdFactor}{Delimiters.PrimaryDelimiter}{LiquidThresholdFactor}{Delimiters.PrimaryDelimiter}{RoomThresholdFactor}\n");
        }

        /// <summary>
        /// Returns the filename and path associated with <see cref="BiomeConfiguration"/>'s definition file.
        /// </summary>
        /// <returns>A full path to the associated file.</returns>
        public static string FilePath
            => $"{All.ProjectDirectory}/{nameof(BiomeConfiguration)}.csv";
        #endregion
    }
}
