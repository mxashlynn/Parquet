using System.Collections.Generic;
using ParquetClassLibrary.Sandbox.ID;

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
        private static readonly Dictionary<ParquetID, ParquetParent> _parquetDefinitions = new Dictionary<ParquetID, ParquetParent>();

        /// <summary>
        /// Returns the specified parquet.
        /// </summary>
        /// <param name="in_ID">A valid, defined parquet identifier.</param>
        /// <typeparam name="T">The type of parquet sought.  Must correspond to the given ID.</typeparam>
        /// <returns>The specified parquet.</returns>
        /// <exception cref="System.InvalidCastException">
        /// Thrown when the specified type does not correspond to the given ID.
        /// </exception>
        public static T Get<T>(ParquetID in_ID) where T : ParquetParent
        {
            return (T)_parquetDefinitions[in_ID];
        }

        /// <summary>
        /// Loads all parquets definitions.
        /// </summary>
        public static void DeserializeAllParquets()
        {
            /* TODO: Ensure we have no duplicate values.
                if (KnownIDs.Contains(value))
                {
                    Error.Handle($"Tried to create duplicate parquet with ID {value}.");
                }
                else
                {
                    KnownIDs.Add(value);
                    _id = value;
                }
             */
            // TODO Implement me!
            // IDEA Use CSV serializer.
        }

        /// <summary>
        /// Saves all current parquets definitions.
        /// </summary>
        public static void SerializeAllParquets()
        {
            // TODO Implement me!
        }
    }
}
