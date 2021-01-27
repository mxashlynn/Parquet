using System;
using System.Globalization;
using System.IO;
using System.Text;
using Parquet.Properties;

namespace Parquet.Rooms
{
    /// <summary>
    /// Provides parameters for <see cref="Room"/>s.
    /// </summary>
    public static class RoomConfiguration
    {
        #region Class Defaults
        /// <summary>Minimum walkable spaces to use if the configuration cannot be read.</summary>
        private const int DefaultMinWalkableSpaces = 4;

        /// <summary>Maximum walkable spaces to use if the configuration cannot be read.</summary>
        private const int DefaultMaxWalkableSpaces = 121;
        #endregion

        #region Characteristics
        /// <summary>Minimum number of open walkable spaces needed for any room to register.</summary>
        public static int MinWalkableSpaces { get; set; } = DefaultMinWalkableSpaces;

        /// <summary>Maximum number of open walkable spaces needed for any room to register.</summary>
        public static int MaxWalkableSpaces { get; set; } = DefaultMaxWalkableSpaces;

        /// <summary>Minimum number of enclosing spaces needed for any room to register.</summary>
        public static int MinPerimeterSpaces => MinWalkableSpaces * 3;
        #endregion

        #region Self Serialization
        /// <summary>
        /// Reads <see cref="RoomConfiguration"/> data from the appropriate file.
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
            MinWalkableSpaces = int.TryParse(values[0], All.SerializedNumberStyle, CultureInfo.InvariantCulture, out var temp1)
                ? temp1
                : Logger.DefaultWithParseLog(values[0], nameof(MinWalkableSpaces), DefaultMinWalkableSpaces);
            MaxWalkableSpaces = int.TryParse(values[1], All.SerializedNumberStyle, CultureInfo.InvariantCulture, out var temp2)
                ? temp2
                : Logger.DefaultWithParseLog(values[1], nameof(MaxWalkableSpaces), DefaultMinWalkableSpaces);
        }

        /// <summary>
        /// Writes <see cref="RoomConfiguration"/> data to the appropriate file.
        /// </summary>
        public static void PutRecord()
        {
            using var writer = new StreamWriter(FilePath, false, new UTF8Encoding(true, true));
            writer.WriteLine($"{nameof(MinWalkableSpaces)}{Delimiters.PrimaryDelimiter}{nameof(MaxWalkableSpaces)}");
            writer.WriteLine($"{MinWalkableSpaces}{Delimiters.PrimaryDelimiter}{MaxWalkableSpaces}");
        }

        /// <summary>
        /// Returns the filename and path associated with <see cref="RoomConfiguration"/>'s definition file.
        /// </summary>
        /// <returns>A full path to the associated file.</returns>
        public static string FilePath
            => $"{All.ProjectDirectory}/{nameof(RoomConfiguration)}.csv";
        #endregion
    }
}
