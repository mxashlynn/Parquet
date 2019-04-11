using System.Collections.Generic;
using Newtonsoft.Json;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Sandbox.Parquets
{
    /// <summary>
    /// Stores all defined parquet models for use in sandbox-mode.
    /// This collection is the source of truth about parquets for the rest of the library,
    /// something like a color palette that other classes can paint with.
    /// </summary>
    public static class AllParquets
    {
        /// <summary>A collection of all defined parquets of all subtypes.  All IDs must be unique.</summary>
        private static Dictionary<EntityID, ParquetParent> ParquetDefinitions { get; set; } = new Dictionary<EntityID, ParquetParent>
        {
            { EntityID.None, null }
        };

        /// <summary>
        /// Returns the specified parquet.
        /// </summary>
        /// <param name="in_id">A valid, defined parquet identifier.</param>
        /// <typeparam name="T">The type of parquet sought.  Must correspond to the given ID.</typeparam>
        /// <returns>The specified parquet.</returns>
        /// <exception cref="System.InvalidCastException">
        /// Thrown when the specified type does not correspond to the given ID.
        /// </exception>
        public static T Get<T>(EntityID in_id) where T : ParquetParent
        {
            return (T)ParquetDefinitions[in_id];
        }

        /// <summary>
        /// Adds the given parquet to the collection of cannonical parquets.
        /// This allows parquets to be created at run-time.
        /// </summary>
        /// <param name="in_parquet">The parquet being defined.</param>
        /// <returns><c>true</c> if the parquet was added successfully; <c>false</c> otherwise.</returns>
        public static bool Put(ParquetParent in_parquet)
        {
            var isNew = !ParquetDefinitions.ContainsKey(in_parquet.ID);

            if (isNew)
            {
                ParquetDefinitions[in_parquet.ID] = in_parquet;
            }
            else
            {
                Error.Handle($"Tried to create duplicate parquet ID {in_parquet.ID}.");
            }

            return isNew;
        }

        /// <summary>
        /// Adds a collection of parquets to the cannonical definitions.
        /// This supports adding parquets via alternative serialization mechanisms.
        /// </summary>
        /// <returns><c>true</c>, if range was added, <c>false</c> otherwise.</returns>
        /// <param name="in_parquets">In parquets.</param>
        public static bool AddRange(IEnumerable<ParquetParent> in_parquets)
        {
            var succeeded = true;

            foreach (var parquet in in_parquets)
            {
                succeeded &= Put(parquet);
            }

            return succeeded;
        }

        /// <summary>
        /// Serializes to the all defined parquets to a string.
        /// </summary>
        /// <returns>The serialized parquets.</returns>
        public static string SerializeToString()
        {
            return JsonConvert.SerializeObject(ParquetDefinitions, Formatting.None);
        }

        /// <summary>
        /// Tries to deserialize a collection of parquets from the given string.
        /// </summary>
        /// <param name="in_serializedParquets">The serialized parquets.</param>
        /// <returns><c>true</c>, if deserialization was successful, <c>false</c> otherwise.</returns>
        public static bool TryDeserializeFromString(string in_serializedParquets)
        {
            // TODO: Ensure this is working as intended.  See:
            // https://stackoverflow.com/questions/6348215/how-to-deserialize-json-into-ienumerablebasetype-with-newtonsoft-json-net
            // https://www.newtonsoft.com/json/help/html/SerializeTypeNameHandling.htm
            var result = false;

            if (string.IsNullOrEmpty(in_serializedParquets))
            {
                Error.Handle("Error deserializing a MapRegion.");
            }
            else
            {
                try
                {
                    ParquetDefinitions = JsonConvert.DeserializeObject<Dictionary<EntityID, ParquetParent>>(in_serializedParquets);
                    result = true;
                }
                catch (JsonReaderException exception)
                {
                    Error.Handle($"Error reading string while deserializing parquets: {exception}");
                }
            }

            return result;
        }
    }
}
