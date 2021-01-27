using System;
using System.Globalization;
using System.IO;
using System.Text;
using Parquet.Properties;

namespace Parquet.Crafts
{
    /// <summary>
    /// Provides parameters for <see cref="CraftingRecipe"/>s.
    /// </summary>
    public static class CraftConfiguration
    {
        #region Class Defaults
        /// <summary>A fall-back number of ingredient categories per recipe.</summary>
        private static Range<int> DefaultIngredientCount { get; } = new Range<int>(1, 5);

        /// <summary>A fall-back number of product categories per recipe.</summary>
        private static Range<int> DefaultProductCount { get; } = new Range<int>(1, 5);
        #endregion

        #region Characteristics
        /// <summary>Number of ingredient categories per recipe.</summary>
        public static Range<int> IngredientCount { get; set; } = DefaultIngredientCount;

        /// <summary>Number of product categories per recipe.</summary>
        public static Range<int> ProductCount { get; set; } = DefaultProductCount;
        #endregion

        #region Self Serialization
        /// <summary>
        /// Reads <see cref="CraftConfiguration"/> data from the appropriate file.
        /// </summary>
        /// <returns>The instances read.</returns>
        public static void GetRecord()
        {
            using var reader = new StreamReader(FilePath);

            // Skip the header.
            reader.ReadLine();
            // Read in the values.
            var valueLine = reader.ReadLine();
            var serializedRanges = valueLine.Split(Delimiters.PrimaryDelimiter);
            var ingredientValues = serializedRanges[0].Split(Delimiters.ElementDelimiter);
            var productValues = serializedRanges[1].Split(Delimiters.ElementDelimiter);

            // Parse.
            IngredientCount = int.TryParse(ingredientValues[0], out var tempMin)
                            && int.TryParse(ingredientValues[1], out var tempMax)
                ? new Range<int>(tempMin, tempMax)
                : Logger.DefaultWithParseLog(serializedRanges[0], nameof(IngredientCount), DefaultIngredientCount);
            ProductCount = int.TryParse(productValues[0], out tempMin)
                         && int.TryParse(productValues[1], out tempMax)
                ? new Range<int>(tempMin, tempMax)
                : Logger.DefaultWithParseLog(serializedRanges[1], nameof(ProductCount), DefaultProductCount);

        /// <summary>
        /// Writes <see cref="CraftConfiguration"/> data to the appropriate file.
        /// </summary>
        public static void PutRecord()
        {
            using var writer = new StreamWriter(FilePath, false, new UTF8Encoding(true, true));
            writer.Write($"{nameof(IngredientCount)}{Delimiters.PrimaryDelimiter}{nameof(ProductCount)}\n");
            writer.Write($"{IngredientCount.Minimum}{Delimiters.ElementDelimiter}" +
                         $"{IngredientCount.Maximum}{Delimiters.PrimaryDelimiter}" +
                         $"{ProductCount.Minimum}{Delimiters.ElementDelimiter}" +
                         $"{ProductCount.Maximum}\n");
        }

        /// <summary>
        /// Returns the filename and path associated with <see cref="CraftConfiguration"/>'s definition file.
        /// </summary>
        /// <returns>A full path to the associated file.</returns>
        public static string FilePath
            => $"{All.ProjectDirectory}/{nameof(CraftConfiguration)}.csv";
        #endregion
    }
}
