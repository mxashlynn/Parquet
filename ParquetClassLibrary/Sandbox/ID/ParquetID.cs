using System;
using Newtonsoft.Json;

namespace ParquetClassLibrary.Sandbox.ID
{
    /// <summary>
    /// Uniquely identifies every defined parquet.
    /// 
    /// To be clear: there are multiple parquet subtypes, and
    /// each of these subtypes has multiple definitions.
    /// The definitions are purely data-driven, read in from
    /// JSON or CSV files, and not type-checked by the compiler.
    /// 
    /// Multiple identicle parquet IDs may be assigned to MapChunks or
    /// MapRegions.  The IDs provide a means for the library to
    /// look up information about the parqut definition when
    /// other game elements interact with it.
    /// 
    /// TODO: Move this explanation into the Wiki and expand it.
    /// </summary>
    public struct ParquetID : IComparable<ParquetID>
    {
        /// <summary>Backing type for the identifier.</summary>
        [JsonProperty]
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

        /// <summary>
        /// Enables identifiers to be compared with other identifiers.
        /// </summary>
        /// <param name="in_identifier">Any valid identifier value.</param>
        /// <returns>
        /// A value indicating the relative ordering of the objects being compared.
        /// The return value has these meanings:
        /// Less than zero indicates that the current instance precedes the given identifier in the sort order.
        /// Zero indicates that the current instance occurs in the same position in the sort order as the given identifier.
        /// Greater than zero indicates that the current instance follows the given identifier in the sort order.
        /// </returns>
        public int CompareTo(ParquetID in_identifier)
        {
            return _id.CompareTo(in_identifier._id);
        }
    }
}
