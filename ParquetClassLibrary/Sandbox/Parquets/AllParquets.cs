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
        // TODO: Move test values into the unit test framework.
        #region Test Values
        /// <summary>Used in test patterns in QA routines.</summary>
        public static readonly Floor TestFloor = new Floor(-Assembly.FloorIDs.Minimum, "Grass Floor Test Parquet");

        /// <summary>Used in test patterns in QA routines.</summary>
        public static readonly Block TestBlock = new Block(-Assembly.BlockIDs.Minimum, "Brick Block Test Parquet");

        /// <summary>Used in test patterns in QA routines.</summary>
        public static readonly Furnishing TestFurnishing = new Furnishing(-Assembly.FurnishingIDs.Minimum, "Chair Furnishing Test Parquet");

        /// <summary>Used in test patterns in QA routines.</summary>
        public static readonly Collectable TestCollectable = new Collectable(-Assembly.CollectableIDs.Minimum, "Flowers Collectable Test Parquet");
        #endregion

        /// <summary>A collection of all defined parquets of all subtypes.</summary>
        private static readonly Dictionary<ParquetID, ParquetParent> _parquetDefinitions = new Dictionary<ParquetID, ParquetParent>
        {
            { TestFloor.ID, TestFloor },
            { TestBlock.ID, TestBlock },
            { TestFurnishing.ID, TestFurnishing },
            { TestCollectable.ID, TestCollectable },
        };

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
