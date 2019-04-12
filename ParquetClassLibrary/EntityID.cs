using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Newtonsoft.Json;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary
{
    /// <summary>
    /// Uniquely identifies every <see cref="Entity"/>.
    /// </summary>
    /// <remarks>
    /// Multiple identicle parquet IDs may be assigned to MapChunks
    /// or MapRegions, and multiple duplicate item IDs may exist in
    /// the Inventory.  These IDs provide a means for the library to
    /// look up the game entity definition when other game elements
    /// interact with it.
    /// 
    /// To be clear: there are multiple entity subtypes (<see cref="Sandbox.Parquets.ParquetParent"/>,
    /// <see cref="Items.Item"/>, etc.), and each of these subtypes
    /// has multiple definitions.  The definitions are purely data-driven,
    /// read in from JSON or CSV files, and not type-checked by the compiler.
    /// 
    /// Although the compiler does not provide type-checking for
    /// IDs, within the scope of their usage the library defines
    /// valid ranges for and these are checked by library code.
    /// <see cref="ParquetClassLibrary.AssemblyInfo"/>
    /// </remarks>
    /// TODO: Include this explanation in the Wiki.
    public struct EntityID : IComparable<EntityID>
    {
        /// <summary>Indicates the lack of a game entity associated with this identifier (e.g., parquet).</summary>
        public static readonly EntityID None = 0;

        /// <summary>Backing type for the identifier.</summary>
        // Currently this is implemented as an int rather than a GUID in order
        // to aid in range validation and human-readability of design documents.
        [JsonProperty]
        private int _id;

        #region IComparable Methods
        /// <summary>
        /// Enables identifiers to be treated as their backing type.
        /// </summary>
        /// <param name="in_value">Any valid identifier value.</param>
        /// <returns>The given identifier value.</returns>
        public static implicit operator EntityID(int in_value)
        {
            return new EntityID { _id = in_value };
        }

        /// <summary>
        /// Enables identifiers to be treated as their backing type.
        /// </summary>
        /// <param name="in_identifier">Any valid identifier value.</param>
        /// <returns>The given identifier value.</returns>
        public static implicit operator int(EntityID in_identifier)
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
        public int CompareTo(EntityID in_identifier)
        {
            return _id.CompareTo(in_identifier._id);
        }
        #endregion

        #region Utility Methods
        /// <summary>
        /// Validates the current ID.  An ID is valid if:
        /// 1) it is <see cref="ParquetClassLibrary.Sandbox.ID.EntityID.None"/>
        /// 2) it is defined within the given range, regardless of sign.
        /// </summary>
        /// <returns><c>true</c>, if the identifier is valid given the range, <c>false</c> otherwise.</returns>
        /// <param name="in_range">The range within which the absolute value of the ID must fall.</param>
        [Pure]
        public bool IsValidForRange(Range<EntityID> in_range)
        {
            return _id == None || in_range.ContainsValue(Math.Abs(_id));
        }

        /// <summary>
        /// Validates the current ID over a collection of <see cref="Utilities.Range{EntityID}"/>s.
        /// An ID is valid if:
        /// 1) it is <see cref="None"/>
        /// 2) it is defined within the given range, regardless of sign.
        /// </summary>
        /// <returns><c>true</c>, if the identifier is valid given any of the given ranges, <c>false</c> otherwise.</returns>
        /// <param name="in_ranges">The range within which the absolute value of the ID must fall.</param>
        [Pure]
        public bool IsValidForRange(IEnumerable<Range<EntityID>> in_ranges)
        {
            bool result = false;

            foreach (var idRange in in_ranges)
            {
                result |= IsValidForRange(idRange);
            }

            return result;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current
        /// <see cref="T:ParquetClassLibrary.Sandbox.ID.EntityID"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
        {
            return _id.ToString();
        }
        #endregion
    }
}
