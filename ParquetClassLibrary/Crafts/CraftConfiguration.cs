using System;
using System.Globalization;
using System.IO;
using System.Text;
using CsvHelper;
using ParquetClassLibrary.Properties;

namespace ParquetClassLibrary.Crafts
{
    /// <summary>
    /// Provides parameters for <see cref="CraftingRecipe"/>s.
    /// </summary>
    public static class CraftConfiguration
    {
        /// <summary>Number of ingredient categories per recipe.</summary>
        internal static Range<int> IngredientCount { get; private set; }

        /// <summary>Number of product categories per recipe.</summary>
        internal static Range<int> ProductCount { get; private set; }

        #region Self Serialization
        /// <summary>
        /// Reads <see cref="CraftConfiguration"/> data from the appropriate file.
        /// </summary>
        /// <returns>The instances read.</returns>
        public static void GetRecord()
        {
            using var reader = new StreamReader(GetFilePath());

            // Skip the header.
            reader.ReadLine();
            // Read in the values.
            var valueLine = reader.ReadLine();
            var serializedRanges = valueLine.Split(Delimiters.PrimaryDelimiter);
            var ingredientValues = serializedRanges[0].Split(Delimiters.ElementDelimiter);
            var productValues = serializedRanges[1].Split(Delimiters.ElementDelimiter);

            // Parse.
            if (int.TryParse(ingredientValues[0], out var tempMin)
                && int.TryParse(ingredientValues[1], out var tempMax))
            {
                IngredientCount = new Range<int>(tempMin, tempMax);
            }
            else
            {
                throw new FormatException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotParse,
                                                        serializedRanges[0], nameof(IngredientCount)));
            }
            if (int.TryParse(ingredientValues[0], out tempMin)
                && int.TryParse(ingredientValues[1], out tempMax))
            {
                ProductCount = new Range<int>(tempMin, tempMax);
            }
            else
            {
                throw new FormatException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotParse,
                                                        serializedRanges[1], nameof(ProductCount)));
            }
        }

        /// <summary>
        /// Writes <see cref="CraftConfiguration"/> data to the appropriate file.
        /// </summary>
        public static void PutRecord()
        {
            using var writer = new StreamWriter(GetFilePath(), false, new UTF8Encoding(true, true));
            writer.WriteLine($"{nameof(IngredientCount)}{Delimiters.PrimaryDelimiter}{nameof(ProductCount)}");
            writer.WriteLine($"{IngredientCount.Minimum}{Delimiters.ElementDelimiter}" +
                             $"{IngredientCount.Maximum}{Delimiters.PrimaryDelimiter}" +
                             $"{ProductCount.Minimum}{Delimiters.ElementDelimiter}" +
                             $"{ProductCount.Maximum}");
        }

        /// <summary>
        /// Returns the filename and path associated with <see cref="CraftConfiguration"/>'s designer file.
        /// </summary>
        /// <returns>A full path to the associated designer file.</returns>
        public static string GetFilePath()
            => $"{All.WorkingDirectory}/{nameof(CraftConfiguration)}.csv";
        #endregion
    }
}
