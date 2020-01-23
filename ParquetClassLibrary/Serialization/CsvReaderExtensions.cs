using System;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using ParquetClassLibrary.Beings;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Crafts;
using ParquetClassLibrary.Interactions;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Rooms;
using ParquetClassLibrary.Serialization.Shims;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Serialization
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
        /// <typeparam name="TRecord">The type to deserialize.</typeparam>
        /// <returns>The records.</returns>
        /// <exception cref="ArgumentException">When there is no shim matching the requested type.</exception>
        public static IEnumerable<TRecord> GetRecordsViaShim<TRecord>(this CsvReader inCSV)
            where TRecord : EntityModel
        {
            Precondition.IsNotNull(inCSV, nameof(inCSV));

            var models = new List<TRecord>();
            IEnumerable<EntityShim> shims;

            shims = inCSV.GetRecords(Serializer.ShimMapper[typeof(TRecord)]).Cast<EntityShim>();
            foreach (var shim in shims)
            {
                models.Add(shim.ToEntity<TRecord>());
            }

            return models;
        }
    }
}
