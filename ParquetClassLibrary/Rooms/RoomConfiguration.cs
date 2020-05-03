using System;
using System.Globalization;
using System.IO;
using System.Text;
using ParquetClassLibrary.Properties;

namespace ParquetClassLibrary.Rooms
{
    /// <summary>
    /// Provides parameters for <see cref="Room"/>s.
    /// </summary>
    public static class RoomConfiguration
    {
        /// <summary>Minimum number of open walkable spaces needed for any room to register.</summary>
        public static int MinWalkableSpaces { get; private set; }

        /// <summary>Maximum number of open walkable spaces needed for any room to register.</summary>
        public static int MaxWalkableSpaces { get; private set; }

        /// <summary>Minimum number of enclosing spaces needed for any room to register.</summary>
        public static int MinPerimeterSpaces => MinWalkableSpaces * 3;

        #region Self Serialization
        /// <summary>
        /// Reads <see cref="RoomConfiguration"/> data from the appropriate file.
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
            if (int.TryParse(values[0], out var temp))
            {
                MinWalkableSpaces = temp;
            }
            else
            {
                throw new FormatException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotParse,
                                                        values[0], nameof(MinWalkableSpaces)));
            }
            if (int.TryParse(values[1], out temp))
            {
                MaxWalkableSpaces = temp;
            }
            else
            {
                throw new FormatException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotParse,
                                                        values[1], nameof(MaxWalkableSpaces)));
            }
        }

        /// <summary>
        /// Writes <see cref="RoomConfiguration"/> data to the appropriate file.
        /// </summary>
        public static void PutRecord()
        {
            using var writer = new StreamWriter(GetFilePath(), false, new UTF8Encoding(true, true));
            writer.WriteLine($"{nameof(MinWalkableSpaces)}{Delimiters.PrimaryDelimiter}{nameof(MaxWalkableSpaces)}");
            writer.WriteLine($"{MinWalkableSpaces}{Delimiters.PrimaryDelimiter}{MaxWalkableSpaces}");
        }

        /// <summary>
        /// Returns the filename and path associated with <see cref="RoomConfiguration"/>'s designer file.
        /// </summary>
        /// <returns>A full path to the associated designer file.</returns>
        public static string GetFilePath()
            => $"{All.WorkingDirectory}/{nameof(RoomConfiguration)}.csv";
        #endregion
    }
}
