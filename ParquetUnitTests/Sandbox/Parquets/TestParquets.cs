﻿using System.Collections.Generic;
using ParquetClassLibrary;
using ParquetClassLibrary.Sandbox.Parquets;
using ParquetClassLibrary.Sandbox.ID;

namespace ParquetUnitTests.Sandbox.Parquets
{
    /// <summary>
    /// Stores all defined test parquet models for use in unit testing.
    /// </summary>
    public static class TestParquets
    {
        #region Test Values
        /// <summary>Used in test patterns in QA routines.</summary>
        public static readonly Floor TestFloor = new Floor(-Assembly.FloorIDs.Minimum, "1 Floor Test Parquet");

        /// <summary>Used in test patterns in QA routines.</summary>
        public static readonly Block TestBlock = new Block(-Assembly.BlockIDs.Minimum, "2 Block Test Parquet");

        /// <summary>Used in test patterns in QA routines.</summary>
        public static readonly Furnishing TestFurnishing = new Furnishing(-Assembly.FurnishingIDs.Minimum, "3 Furnishing Test Parquet");

        /// <summary>Used in test patterns in QA routines.</summary>
        public static readonly Collectable TestCollectable = new Collectable(-Assembly.CollectableIDs.Minimum, "4 Collectable Test Parquet");
        #endregion

        /// <summary>A collection of all test parquets of all subtypes.</summary>
        private static readonly Dictionary<EnitityID, ParquetParent> _parquetDefinitions = new Dictionary<EnitityID, ParquetParent>
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
        public static T Get<T>(EnitityID in_ID) where T : ParquetParent
        {
            return (T)_parquetDefinitions[in_ID];
        }
    }
}
