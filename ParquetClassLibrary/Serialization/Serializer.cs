using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Beings;
using ParquetClassLibrary.Serialization.ClassMaps;
using ParquetClassLibrary.Serialization.Converters;
using ParquetClassLibrary.Serialization.Shims;

namespace ParquetClassLibrary.Serialization
{
    /// <summary>
    /// Provides access to the filesystem in a fashion tailed for the Parquet library.
    /// </summary>
    public static class Serializer
    {
        /// <summary>Used to separate fields.</summary>
        public const string PrimaryDelimiter = ",";

        /// <summary>Used to separate objects within collections.</summary>
        public const string SecondaryDelimiter = ";";

        /// <summary>Instructions for handling integer type conversion when reading in identifiers.</summary>
        internal static readonly TypeConverterOptions IdentifierOptions = new TypeConverterOptions
        {
            NumberStyle = NumberStyles.AllowLeadingSign &
                          NumberStyles.Integer
        };

        /// <summary>Mappings for all serializable classes.</summary>
        internal static Dictionary<Type, ClassMap> Mapper = new Dictionary<Type, ClassMap>
        {
            { typeof(Biomes.BiomeModel), Biomes.BiomeModel.GetClassMap() },
        };

        /// <summary>The location of the designer CSV files.</summary>
        public static string SearchPath { get; set; }

        /// <summary>
        /// Reads all records of the given type from the appropriate file.
        /// </summary>
        /// <typeparam name="TRecord">The type to deserialize.</typeparam>
        /// <returns>The records read.</returns>
        public static IEnumerable<TRecord> GetRecordsForType<TRecord>()
            where TRecord : EntityModel, ISerialMapper
        {
            IEnumerable<TRecord> records;
            var filenameAndPath = Path.Combine(SearchPath, $"Designer/{typeof(TRecord).Name}s.csv");
            using (var reader = new StreamReader(filenameAndPath))
            {
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                csv.Configuration.TypeConverterCache.AddConverter(typeof(RecipeElement), new RecipeElementConverter());
                csv.Configuration.TypeConverterCache.AddConverter(typeof(EntityTag), new EntityTagConverter());
                csv.Configuration.TypeConverterCache.AddConverter(typeof(IEnumerable<EntityTag>), new EntityTagEnumerableConverter());
                csv.Configuration.TypeConverterCache.AddConverter(typeof(EntityID), new EntityIDConverter());
                csv.Configuration.TypeConverterCache.AddConverter(typeof(IEnumerable<EntityID>), new EntityIDEnumerableConverter());
                csv.Configuration.TypeConverterCache.AddConverter(typeof(IEnumerable<string>), new StringEnumerableConverter());
                csv.Configuration.TypeConverterOptionsCache.AddOptions(typeof(EntityID), IdentifierOptions);
                csv.Configuration.RegisterClassMapFor<TRecord>();
                records = csv.GetRecordsViaShim<TRecord>();
            }

            return records ?? Enumerable.Empty<TRecord>();
        }

        /// <summary>
        /// Reads all records of <see cref="PronounGroup"/>s from the appropriate file.
        /// </summary>
        /// <returns>The records read.</returns>
        public static HashSet<PronounGroup> GetRecordsForPronounGroup()
        {
            var records = new HashSet<PronounGroup>();
            var filenameAndPath = Path.Combine(SearchPath, $"Designer/PronounGroups.csv");
            using (var reader = new StreamReader(filenameAndPath))
            {
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                csv.Configuration.RegisterClassMap<PronounGroupClassMap>();
                var shims = csv.GetRecords<PronounGroupShim>();
                foreach (var shim in shims)
                {
                    records.Add(shim.ToPronounGroup());
                }
            }

            return records;
        }
    }
}
