using System;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using ParquetClassLibrary;
using ParquetClassLibrary.Parquets;
using ParquetCSVImporter.Shims;

namespace ParquetCSVImporter.ClassMaps
{
    /// <summary>
    /// Provides extensions to the <see cref="CsvReader"/>.
    /// </summary>
    public static class CsvReaderExtensions
    {
        /// <summary>
        /// Gets a set of records from the CSV Reader using the shim class that corresponds to the given type.
        /// </summary>
        /// <param name="inCSV">In CSV Reader.</param>
        /// <typeparam name="T">The type of the record.</typeparam>
        /// <returns>The records.</returns>
        public static IEnumerable<T> GetRecordsViaShim<T>(this CsvReader inCSV) where T : Entity
        {
            var result = new List<T>();
            IEnumerable<ParquetParentShim> shims;
            /*
            if (typeof(T) == typeof(PlayerCharacter))
            {
                shims = inCSV.GetRecords<PlayerCharacterShim>();
            }
            else if (typeof(T) == typeof(NPC))
            {
                shims = inCSV.GetRecords<PNCShim>();
            }
            else if (typeof(T) == typeof(Critter))
            {
                shims = inCSV.GetRecords<CritterShim>();
            }
            else */
            if (typeof(T) == typeof(Floor))
            {
                shims = inCSV.GetRecords<FloorShim>();
            }
            else if (typeof(T) == typeof(Block))
            {
                shims = inCSV.GetRecords<BlockShim>();
            }
            else if (typeof(T) == typeof(Furnishing))
            {
                shims = inCSV.GetRecords<FurnishingShim>();
            }
            else if (typeof(T) == typeof(Collectible))
            {
                shims = inCSV.GetRecords<CollectibleShim>();
            }
            else
            {
                shims = Enumerable.Empty<ParquetParentShim>();
                Console.WriteLine($"No shim exists for {typeof(T)}");
            }

            foreach (var shim in shims)
            {
                result.Add(shim.To<T>());
            }

            return result;
        }
    }
}
