using System;
using System.Globalization;
using System.IO;
using System.Text;
using Parquet.Properties;

namespace Parquet.Items
{
    /// <summary>
    /// Provides rules for working with an <see cref="Inventory"/>.
    /// </summary>
    public static class InventoryConfiguration
    {
        /// <summary>The capacity to use for an <see cref="Inventory"/> when none is specified.</summary>
        public static int DefaultCapacity { get; set; } = 16;

        #region Self Serialization
        /// <summary>
        /// Reads <see cref="InventoryConfiguration"/> data from the appropriate file.
        /// </summary>
        /// <returns>The instances read.</returns>
        public static void GetRecord()
        {
            using var reader = new StreamReader(FilePath);

            // Skip the header.
            reader.ReadLine();

            // Read in the value.
            var value = reader.ReadLine();

            // Parse.
            DefaultCapacity = int.TryParse(value, out var outInt)
                ? outInt
                : throw new FormatException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotParse,
                                                          value, nameof(DefaultCapacity)));
        }

        /// <summary>
        /// Writes <see cref="InventoryConfiguration"/> data to the appropriate file.
        /// </summary>
        public static void PutRecord()
        {
            using var writer = new StreamWriter(FilePath, false, new UTF8Encoding(true, true));
            writer.Write($"{nameof(DefaultCapacity)}\n");
            writer.Write($"{DefaultCapacity}\n");
        }

        /// <summary>
        /// Returns the filename and path associated with <see cref="InventoryConfiguration"/>'s definition file.
        /// </summary>
        /// <returns>A full path to the associated file.</returns>
        public static string FilePath
            => $"{All.ProjectDirectory}/{nameof(InventoryConfiguration)}.csv";
        #endregion
    }
}