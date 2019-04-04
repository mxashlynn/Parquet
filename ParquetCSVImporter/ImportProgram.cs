using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using CsvHelper;
using CsvHelper.TypeConversion;
using ParquetClassLibrary;
using ParquetClassLibrary.Sandbox.Parquets;
using ParquetCSVImporter.ClassMaps;

namespace ParquetCSVImporter
{
    /// <summary>
    /// A program that reads in parquet definitions from CSV files, and outputs them as JSON.
    /// </summary>
    internal class MainClass
    {
        /// <summary>The location of the Designer files.</summary>
        public static readonly string SearchPath =
#if DEBUG
            Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
#else
            Directory.GetCurrentDirectory().FullName;
#endif

        /// <summary>All parquets defined in the CSV files.</summary>
        public static readonly HashSet<ParquetParent> Parquets = new HashSet<ParquetParent>();

        /// <summary>Instructions for handling integer type conversion when reading in parquet identifiers.</summary>
        public static readonly TypeConverterOptions IdentifierOptions = new TypeConverterOptions
        {
            NumberStyle = NumberStyles.AllowLeadingSign &
                          NumberStyles.Integer
        };

        /// <summary>
        /// The entry point of the ParquetCVSImporter program, where the program control starts and ends.
        /// </summary>
        public static void Main()
        {
            var recordsFromCSV = new List<ParquetParent>();
            recordsFromCSV.AddRange(GetRecordsForType<Floor>());
            recordsFromCSV.AddRange(GetRecordsForType<Block>());
            recordsFromCSV.AddRange(GetRecordsForType<Furnishing>());
            recordsFromCSV.AddRange(GetRecordsForType<Collectible>());

            Parquets.Clear();
            Parquets.UnionWith(recordsFromCSV);

            AllParquets.AddRange(Parquets);

            var recordsToJSON = AllParquets.SerializeToString();

            OutputRecords(recordsToJSON);
        }

        /// <summary>
        /// Writes all JSON records to the appropriate file.
        /// </summary>
        /// <param name="in_jsonRecords">In JSON records to write.</param>
        private static void OutputRecords(string in_jsonRecords)
        {
            var filenameAndPath = Path.Combine(SearchPath, "Designer/Parquets.json");
            using (var writer = new StreamWriter(filenameAndPath, false, Encoding.UTF8))
            {
                writer.Write(in_jsonRecords);
            }
        }

        /// <summary>
        /// Reads all records of the given type from the appropriate file.
        /// </summary>
        /// <typeparam name="T">The type of records to read.</typeparam>
        /// <returns>The records read.</returns>
        private static IEnumerable<T> GetRecordsForType<T>()
            where T : ParquetParent
        {
            IEnumerable<T> records;
            var filenameAndPath = Path.Combine(SearchPath, $"Designer/{typeof(T).Name}.csv");
            using (var reader = new StreamReader(filenameAndPath))
            {
                using (var csv = new CsvReader(reader))
                {
                    csv.Configuration.TypeConverterCache.AddConverter(typeof(EntityID), new EntityIDConverter());
                    csv.Configuration.TypeConverterOptionsCache.AddOptions(typeof(EntityID), IdentifierOptions);
                    csv.Configuration.RegisterClassMapFor<T>();
                    records = csv.GetRecordsViaShim<T>();
                }
            }

            return records;
        }
    }
}
