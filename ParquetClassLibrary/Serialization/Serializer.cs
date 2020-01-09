using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.TypeConversion;

namespace ParquetClassLibrary.Serialization
{
    /// <summary>
    /// Provides access to the filesystem in a fashion tailed for the Parquet library.
    /// </summary>
    public static class Serializer
    {
        /// <summary>Instructions for handling integer type conversion when reading in identifiers.</summary>
        internal static readonly TypeConverterOptions IdentifierOptions = new TypeConverterOptions
        {
            NumberStyle = NumberStyles.AllowLeadingSign &
                          NumberStyles.Integer
        };

        /// <summary>The location of the designer CSV files.</summary>
        public static string SearchPath { get; set; }

        /// <summary>
        /// Reads all records of the given type from the appropriate file.
        /// </summary>
        /// <typeparam name="T">The type of records to read.</typeparam>
        /// <returns>The records read.</returns>
        public static IEnumerable<T> GetRecordsForType<T>()
            where T : EntityModel
        {
            IEnumerable<T> records;
            var filenameAndPath = Path.Combine(SearchPath, $"Designer/{typeof(T).Name}.csv");
            using (var reader = new StreamReader(filenameAndPath))
            {
                using var csv = new CsvReader(reader);
                csv.Configuration.TypeConverterCache.AddConverter(typeof(EntityTag), new EntityTagConverter());
                csv.Configuration.TypeConverterCache.AddConverter(typeof(EntityID), new EntityIDConverter());
                csv.Configuration.TypeConverterOptionsCache.AddOptions(typeof(EntityID), IdentifierOptions);
                csv.Configuration.RegisterClassMapFor<T>();
                records = csv.GetRecordsViaShim<T>();
            }

            return records;
        }
    }
}
