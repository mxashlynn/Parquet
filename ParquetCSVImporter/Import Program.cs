using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using CsvHelper;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Sandbox;
using ParquetClassLibrary.Sandbox.ID;
using ParquetClassLibrary.Sandbox.Parquets;
using ParquetCSVImporter.ClassMaps;

namespace ParquetCSVImporter
{
    /// <summary>
    /// A program that reads in Parquet definitions from CSV files, and outputs them as JSON.
    /// TODO Add ability to output them as JSON!
    /// </summary>
    class MainClass
    {
        /// <summary>The location of the Designer files.</summary>
        public static readonly string SearchPath =
#if DEBUG
            Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
#else
            Environment.CurrentDirectory;
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
            var records = new List<ParquetParent>();
            records.AddRange(GetRecordsForType<Floor>());
            records.AddRange(GetRecordsForType<Block>());
            records.AddRange(GetRecordsForType<Furnishing>());
            records.AddRange(GetRecordsForType<Collectable>());

            Parquets.UnionWith(records);

            foreach (var p in Parquets)
            {
                Console.WriteLine(p);
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
                    csv.Configuration.TypeConverterCache.AddConverter(typeof(ParquetID), new ParquetIDConverter());
                    csv.Configuration.TypeConverterOptionsCache.AddOptions(typeof(ParquetID), IdentifierOptions);
                    csv.Configuration.RegisterClassMapFor<T>();
                    records = csv.GetRecordsViaShim<T>();
                }
            }

            return records;
        }
    }
}
