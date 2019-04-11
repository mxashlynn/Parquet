using System.Collections.Generic;
using ParquetClassLibrary;
using ParquetClassLibrary.Sandbox.Parquets;

namespace ParquetUnitTests.Sandbox.Parquets
{
    /// <summary>
    /// Stores all defined test parquet models for use in unit testing.
    /// </summary>
    public static class TestParquets
    {
        #region Test Values
        /// <summary>Used in test patterns in QA routines.</summary>
        public static readonly Floor TestFloor = new Floor(-AssemblyInfo.FloorIDs.Minimum, "1 Floor Test Parquet");

        /// <summary>Used in test patterns in QA routines.</summary>
        public static readonly Block TestBlock = new Block(-AssemblyInfo.BlockIDs.Minimum, "2 Block Test Parquet");

        /// <summary>Used in test patterns in QA routines.</summary>
        public static readonly Furnishing TestFurnishing = new Furnishing(-AssemblyInfo.FurnishingIDs.Minimum, "3 Furnishing Test Parquet");

        /// <summary>Used in test patterns in QA routines.</summary>
        public static readonly Collectible TestCollectible = new Collectible(-AssemblyInfo.CollectibleIDs.Minimum, "4 Collectible Test Parquet");
        #endregion

        /// <summary>A collection of all test parquets of all subtypes.</summary>
        private static readonly Dictionary<EntityID, ParquetParent> parquetDefinitions = new Dictionary<EntityID, ParquetParent>
        {
            { TestFloor.ID, TestFloor },
            { TestBlock.ID, TestBlock },
            { TestFurnishing.ID, TestFurnishing },
            { TestCollectible.ID, TestCollectible },
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
        public static T Get<T>(EntityID in_ID) where T : ParquetParent
        {
            return (T)parquetDefinitions[in_ID];
        }
    }
}
