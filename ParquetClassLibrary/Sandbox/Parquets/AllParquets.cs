using System.Collections.Generic;
using ParquetClassLibrary.Sandbox.ID;

namespace ParquetClassLibrary.Sandbox.Parquets
{
    /// <summary>
    /// Stores all defined parquet models for sandbox-mode.
    /// </summary>
    public static class AllParquets
    {
        /// <summary>A collection of all defined parquets of all subtypes.</summary>
        private static readonly Dictionary<ParquetID, ParquetParent> _table = new Dictionary<ParquetID, ParquetParent>
        {
            { TestFloor.ID, TestFloor },
            { TestBlock.ID, TestBlock },
            { TestFurnishing.ID, TestFurnishing },
            { TestCollectable.ID, TestCollectable },
        };

        /// <summary>Used in test patterns.</summary>
        public static readonly Floor TestFloor = new Floor(-1, "Floor Test Parquet");

        /// <summary>Used in test patterns.</summary>
        public static readonly Block TestBlock = new Block(-2, "Block Test Parquet");

        /// <summary>Used in test patterns.</summary>
        public static readonly Furnishing TestFurnishing = new Furnishing(-3, "Furnishing Test Parquet");

        /// <summary>Used in test patterns.</summary>
        public static readonly Collectable TestCollectable = new Collectable(-4, "Collectable Test Parquet");

        /// <summary>
        /// Returns the specified parquet.
        /// </summary>
        /// <param name="in_ID">A valid, defined parquet identifier.</param>
        /// <typeparam name="T">The type of parquet sought.  Must correspond to the given ID.</typeparam>
        /// <returns>The specified parquet.</returns>
        /// <exception cref="System.InvalidCastException">If the specified type does not correspond to the given ID.</exception>
        public static T Get<T>(ParquetID in_ID) where T : ParquetParent
        {
            return (T)_table[in_ID];
        }

        /// <summary>
        /// Loads all parquets definitions.
        /// </summary>
        public static void DeserializeAllParquets()
        {
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
