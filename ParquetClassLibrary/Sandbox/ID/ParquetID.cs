using System;

namespace ParquetClassLibrary.Sandbox.ID
{
    /// <summary>
    /// Uniquely identifies every defined parquet.
    /// </summary>
    public struct ParquetID
    {
        /// <summary>Backing type for the identifier.</summary>
        private int _id;

        /// <summary>
        /// Enables identifiers to be treated as their backing type.
        /// </summary>
        /// <param name="in_value">Any valid identifier value.</param>
        /// <returns>The given identifier value.</returns>
        public static implicit operator ParquetID(int in_value)
        {
            return new ParquetID { _id = in_value };
        }

        /// <summary>
        /// Enables identifiers to be treated as their backing type.
        /// </summary>
        /// <param name="in_identifier">Any valid identifier value.</param>
        /// <returns>The given identifier value.</returns>
        public static implicit operator int(ParquetID in_identifier)
        {
            return in_identifier._id;
        }
    }
}
