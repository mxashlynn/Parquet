using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Crafts;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Serialization
{
    /// <summary>
    /// Provides access to the filesystem in a fashion tailed for the Parquet library.
    /// </summary>
    public static class Serializer
    {
        /// <summary>Used to separate objects within collections.</summary>
        public const string SecondaryDelimiter = ";";

        /// <summary>Instructions for handling integer type conversion when reading in identifiers.</summary>
        private static TypeConverterOptions IdentifierOptions { get; } = new TypeConverterOptions
        {
            NumberStyle = NumberStyles.AllowLeadingSign &
                          NumberStyles.Integer
        };

        /// <summary>
        /// The location of the designer CSV files, set to either the working directory
        /// or a predefined designer directory, depending on build type.
        /// </summary>
        public static string SearchPath { get; set; } =
#if DEBUG
            $"{Directory.GetCurrentDirectory()}/../../../../Designer";
#else
            Directory.GetCurrentDirectory();
#endif

        /// <summary>
        /// Reads all records of the given type from the appropriate file.
        /// </summary>
        /// <typeparam name="TRecord">The type to deserialize.</typeparam>
        /// <returns>The records read.</returns>
        public static IEnumerable<TRecord> GetRecordsForType<TRecord>()
            where TRecord : ITypeConverter
        {
            using var reader = new StreamReader($"{SearchPath}/{typeof(TRecord).Name}s.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Configuration.TypeConverterOptionsCache.AddOptions(typeof(EntityID), IdentifierOptions);
            csv.Configuration.TypeConverterCache.AddConverter(typeof(EntityID), new EntityID());
            csv.Configuration.TypeConverterCache.AddConverter(typeof(EntityTag), new EntityTag());
            csv.Configuration.TypeConverterCache.AddConverter(typeof(RecipeElement), new RecipeElement());
            csv.Configuration.TypeConverterCache.AddConverter(typeof(IReadOnlyList<EntityID>), new SeriesConverter<EntityID, List<EntityID>>());
            csv.Configuration.TypeConverterCache.AddConverter(typeof(IReadOnlyList<EntityTag>), new SeriesConverter<EntityTag, List<EntityTag>>());
            csv.Configuration.TypeConverterCache.AddConverter(typeof(IReadOnlyList<RecipeElement>), new SeriesConverter<RecipeElement, List<RecipeElement>>());
            csv.Configuration.TypeConverterCache.AddConverter(typeof(StrikePanelGrid), new GridConverter<StrikePanel, StrikePanelGrid>());
            csv.Configuration.RegisterClassMap(typeof(Range<EntityID>.RangeClassMap<EntityID>));
            csv.Configuration.RegisterClassMap(typeof(Range<int>.RangeClassMap<int>));
            return csv.GetRecords<TRecord>();
        }

        /// <summary>
        /// Writes all of the given type to records in the appropriate file.
        /// </summary>
        /// <typeparam name="TRecord">The type to serialize.</typeparam>
        internal static void PutRecordsForType<TRecord>(IEnumerable<TRecord> inInstances)
            where TRecord : ITypeConverter
        {
            using var writer = new StreamWriter($"{SearchPath}/{typeof(TRecord).Name}s.csv");
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.Configuration.TypeConverterOptionsCache.AddOptions(typeof(EntityID), IdentifierOptions);
            csv.Configuration.TypeConverterCache.AddConverter(typeof(EntityID), new EntityID());
            csv.Configuration.TypeConverterCache.AddConverter(typeof(EntityTag), new EntityTag());
            csv.Configuration.TypeConverterCache.AddConverter(typeof(RecipeElement), new RecipeElement());
            csv.Configuration.TypeConverterCache.AddConverter(typeof(IReadOnlyList<EntityID>), new SeriesConverter<EntityID, List<EntityID>>());
            csv.Configuration.TypeConverterCache.AddConverter(typeof(IReadOnlyList<EntityTag>), new SeriesConverter<EntityTag, List<EntityTag>>());
            csv.Configuration.TypeConverterCache.AddConverter(typeof(IReadOnlyList<RecipeElement>), new SeriesConverter<RecipeElement, List<RecipeElement>>());
            csv.Configuration.TypeConverterCache.AddConverter(typeof(StrikePanelGrid), new GridConverter<StrikePanel, StrikePanelGrid>());
            csv.Configuration.RegisterClassMap(typeof(Range<EntityID>.RangeClassMap<EntityID>));
            csv.Configuration.RegisterClassMap(typeof(Range<int>.RangeClassMap<int>));
            csv.WriteHeader<TRecord>();
            csv.NextRecord();
            csv.WriteRecords(inInstances);
        }
    }
}
