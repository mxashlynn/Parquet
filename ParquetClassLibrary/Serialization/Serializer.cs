using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Beings;
using ParquetClassLibrary.Crafts;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Maps;
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

        /// <summary>Mappings for all classes serialized via <see cref="ITypeConverter"/>.</summary>
        private static Dictionary<Type, ITypeConverter> ConversionMapper { get; } = new Dictionary<Type, ITypeConverter>
        {
            // TODO Question -- should this functionality be split between All and ModelCollection??

            #region ITypeConverters
            { typeof(EntityID), EntityID.ConverterFactory },
            { typeof(EntityTag), EntityTag.ConverterFactory },
            { typeof(RecipeElement), RecipeElement.ConverterFactory },
            { typeof(PronounGroup), PronounGroup.ConverterFactory },
            { typeof(InventorySlot), InventorySlot.ConverterFactory },
            { typeof(NPCModel), NPCModel.ConverterFactory },
            // TODO Finish these
            #endregion

            #region Linear Series Types
            { typeof(IReadOnlyList<EntityID>), new SeriesConverter<EntityID, List<EntityID>>() },
            { typeof(IReadOnlyList<EntityTag>), new SeriesConverter<EntityTag, List<EntityTag>>() },
            { typeof(IReadOnlyList<RecipeElement>), new SeriesConverter<RecipeElement, List<RecipeElement>>() },
            { typeof(IReadOnlyList<ExitPoint>), new SeriesConverter<ExitPoint, List<ExitPoint>>() },
            { typeof(Inventory), new SeriesConverter<InventorySlot, Inventory>() },
            // TODO Finish these
            #endregion

            #region 2D Grid Types
            { typeof(StrikePanelGrid), new GridConverter<StrikePanel, StrikePanelGrid>() },
            { typeof(ChunkTypeGrid), new GridConverter<ChunkType, ChunkTypeGrid>() },
            // TODO Finish these
            #endregion
        };

        /// <summary>Mappings for all classes serialized via <see cref="ClassMap"/>.</summary>
        private static List<ClassMap> ClassMapper { get; } = new List<ClassMap>
        {
            new Range<EntityID>.RangeClassMap<EntityID>(),
            new Range<int>.RangeClassMap<int>(),
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
            foreach (var kvp in ConversionMapper)
            {
                csv.Configuration.TypeConverterCache.AddConverter(kvp.Key, kvp.Value);
            }
            foreach (var map in ClassMapper)
            {
                csv.Configuration.RegisterClassMap(map);
            }

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
            foreach (var kvp in ConversionMapper)
            {
                csv.Configuration.TypeConverterCache.AddConverter(kvp.Key, kvp.Value);
            }
            foreach (var map in ClassMapper)
            {
                csv.Configuration.RegisterClassMap(map);
            }

            csv.WriteHeader<TRecord>();
            csv.NextRecord();
            csv.WriteRecords(inInstances);
        }
    }
}
