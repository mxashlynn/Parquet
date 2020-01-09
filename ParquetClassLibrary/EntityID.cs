using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary
{
    /// <summary>
    /// Uniquely identifies every <see cref="EntityModel"/>.
    /// </summary>
    /// <remarks>
    /// <see cref="EntityID"/>s provide a means for the library
    /// to track and rapidly update large numbers of equivalent
    /// game objects.<para />
    /// <para />
    /// For example, multiple identical parquet IDs may be assigned
    /// to <see cref="Maps.MapChunk"/>s or <see cref="Maps.MapRegions"/>,
    /// and multiple duplicate <see cref="Item"/> IDs may exist in
    /// accross various <see cref="Beings.Character"/> inventories.<para />
    /// <para />
    /// Using EntityID the library looks up the game object definitions
    /// for each of these when other game elements interact with them,
    /// without filling RAM with numerous duplicate EntityModels.<para />
    /// <para />
    /// There are multiple <see cref="EntityModel"/> subtypes
    /// (<see cref="Parquets.ParquetParent"/>, <see cref="Beings.Being"/>,
    /// etc.), and each of these subtypes has multiple definitions.
    /// The definitions are purely data-driven, read in from CSV or
    /// other files, and not type-checked by the compiler.<para />
    /// <para />
    /// Although the compiler does not provide type-checking for IDs,
    /// the library defines valid ranges for all ID subtypes (<see cref="All"/>)
    /// and these are checked by library code.<para />
    /// <para />
    /// A note on implementation as of January 1st, 2020.<para />
    /// <para />
    /// EntityID is implemented as a mutable struct because, under the hood,
    /// it is simply an Int32.  EntityID is designed to be implicitly
    /// interoperable with and implcity castable to and from integer types.<para />
    /// <para />
    /// Since the entire point of this ID system is to provide a way for the
    /// library to rapidly track changes in large arrays of identical game
    /// objects, it must be a light-weight mutable value type.  This is
    /// analagous to the use case for C# 7 tuples, which are also light-weight
    /// mutable value types.<para />
    /// <para />
    /// If the implementation were ever to become more complex, EntityID
    /// would need to become a class.
    /// </remarks>
    public struct EntityID : IComparable<EntityID>, IEquatable<EntityID>
    {
        /// <summary>Indicates the lack of an <see cref="EntityModel"/>.</summary>
        public static readonly EntityID None = 0;

        /// <summary>Backing type for the <see cref="EntityID"/>.</summary>
        /// <remarks>
        /// This is implemented as an <see langword="int"/> rather than a <see cref="System.Guid"/>
        /// to support human-readable design documents and <see cref="Range{T}"/> validation.
        /// </remarks>
        private int id;

        #region Implicit Conversion To/From Underlying Type
        /// <summary>
        /// Enables <see cref="EntityID"/>s to be treated as their backing type.
        /// </summary>
        /// <param name="inValue">Any valid identifier value.</param>
        /// <returns>The given identifier value.</returns>
        public static implicit operator EntityID(int inValue)
            => new EntityID { id = inValue };

        /// <summary>
        /// Enables <see cref="EntityID"/> to be treated as their backing type.
        /// </summary>
        /// <param name="inIDentifier">Any identifier.</param>
        /// <returns>The identifier's value.</returns>
        public static implicit operator int(EntityID inIDentifier)
            => inIDentifier.id;
        #endregion

        #region IComparable Implementation
        /// <summary>
        /// Enables <see cref="EntityID"/> to be compared to one another.
        /// </summary>
        /// <param name="inIDentifier">Any <see cref="EntityID"/>.</param>
        /// <returns>
        /// A value indicating the relative ordering of the <see cref="EntityID"/>s being compared.
        /// The return value has these meanings:
        ///     Less than zero indicates that the current instance precedes the given <see cref="EntityID"/> in the sort order.
        ///     Zero indicates that the current instance occurs in the same position in the sort order as the given <see cref="EntityID"/>.
        ///     Greater than zero indicates that the current instance follows the given <see cref="EntityID"/> in the sort order.
        /// </returns>
        public readonly int CompareTo(EntityID inIDentifier)
            => id.CompareTo(inIDentifier.id);

        /// <summary>
        /// Determines whether a specified instance of <see cref="EntityID"/> strictly precedes another specified instance of <see cref="EntityID"/>.
        /// </summary>
        /// <param name="inIDentifier1">The first <see cref="EntityID"/> to compare.</param>
        /// <param name="inIDentifier2">The second <see cref="EntityID"/> to compare.</param>
        /// <returns><c>true</c> if the first identifier strictly precedes the second; otherwise, <c>false</c>.</returns>
        public static bool operator <(EntityID inIDentifier1, EntityID inIDentifier2)
            => inIDentifier1.id < inIDentifier2.id;

        /// <summary>
        /// Determines whether a specified instance of <see cref="EntityID"/> precedes or is ordinally equivalent with
        /// another specified instance of <see cref="EntityID"/>.
        /// </summary>
        /// <param name="inIDentifier1">The first <see cref="EntityID"/> to compare.</param>
        /// <param name="inIDentifier2">The second <see cref="EntityID"/> to compare.</param>
        /// <returns><c>true</c> if the first identifier precedes or is ordinally equivalent with the second; otherwise, <c>false</c>.</returns>
        public static bool operator <=(EntityID inIDentifier1, EntityID inIDentifier2)
            => inIDentifier1.id <= inIDentifier2.id;

        /// <summary>
        /// Determines whether a specified instance of <see cref="EntityID"/> strictly follows another specified instance of <see cref="EntityID"/>.
        /// </summary>
        /// <param name="inIDentifier1">The first <see cref="EntityID"/> to compare.</param>
        /// <param name="inIDentifier2">The second <see cref="EntityID"/> to compare.</param>
        /// <returns><c>true</c> if the first identifier strictly followa the second; otherwise, <c>false</c>.</returns>
        public static bool operator >(EntityID inIDentifier1, EntityID inIDentifier2)
            => inIDentifier1.id > inIDentifier2.id;

        /// <summary>
        /// Determines whether a specified instance of <see cref="EntityID"/> follows or is ordinally equivalent with
        /// another specified instance of <see cref="EntityID"/>.
        /// </summary>
        /// <param name="inIDentifier1">The first <see cref="EntityID"/> to compare.</param>
        /// <param name="inIDentifier2">The second <see cref="EntityID"/> to compare.</param>
        /// <returns><c>true</c> if the first identifier follows or is ordinally equivalent with the second; otherwise, <c>false</c>.</returns>
        public static bool operator >=(EntityID inIDentifier1, EntityID inIDentifier2)
            => inIDentifier1.id >= inIDentifier2.id;
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="EntityID"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public override readonly int GetHashCode()
            => id.GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="EntityID"/> is equal to the current <see cref="EntityID"/>.
        /// </summary>
        /// <param name="inIDentifier">The <see cref="EntityID"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public readonly bool Equals(EntityID inIDentifier)
            => id == inIDentifier.id;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="EntityID"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="EntityID"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public readonly override bool Equals(object obj)
            => obj is EntityID entityID && Equals(entityID);

        /// <summary>
        /// Determines whether a specified instance of <see cref="EntityID"/> is equal to another specified instance of <see cref="EntityID"/>.
        /// </summary>
        /// <param name="inIDentifier1">The first <see cref="EntityID"/> to compare.</param>
        /// <param name="inIDentifier2">The second <see cref="EntityID"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(EntityID inIDentifier1, EntityID inIDentifier2)
            => inIDentifier1.id == inIDentifier2.id;

        /// <summary>
        /// Determines whether a specified instance of <see cref="EntityID"/> is not equal to another specified instance of <see cref="EntityID"/>.
        /// </summary>
        /// <param name="inIDentifier1">The first <see cref="EntityID"/> to compare.</param>
        /// <param name="inIDentifier2">The second <see cref="EntityID"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(EntityID inIDentifier1, EntityID inIDentifier2)
            => inIDentifier1.id != inIDentifier2.id;
        #endregion

        #region Utilities
        /// <summary>
        /// Validates the current <see cref="EntityID"/> over a <see cref="Range{EntityID}"/>.
        /// An <see cref="EntityID"/> is valid if:
        ///     1) it is <see cref="None"/>
        ///     2) it is defined within the given <see cref="Range{T}"/>, regardless of sign.
        /// </summary>
        /// <param name="inRange">The <see cref="Range{T}"/> within which the absolute value of the <see cref="EntityID"/> must fall.</param>
        /// <returns>
        /// <c>true</c>, if the <see cref="EntityID"/> is valid given the <see cref="Range{T}"/>, <c>false</c> otherwise.
        /// </returns>
        [Pure]
        public readonly bool IsValidForRange(Range<EntityID> inRange)
            => id == None || inRange.ContainsValue(Math.Abs(id));

        /// <summary>
        /// Validates the current <see cref="EntityID"/> over a <see cref="IEnumerable{Range{EntityID}}"/>.
        /// An <see cref="EntityID"/> is valid if:
        ///     1) it is <see cref="None"/>
        ///     2) it is defined within any of the <see cref="Range{T}"/> in the given <see cref="IEnumerable{T}"/>, regardless of sign.
        /// </summary>
        /// <param name="inRanges">
        /// The <see cref="IEnumerable{Range{T}}"/> within which the <see cref="EntityID"/> must fall.
        /// </param>
        /// <returns>
        /// <c>true</c>, if the <see cref="EntityID"/> is valid given the <see cref="IEnumerable{Range{T}}"/>, <c>false</c> otherwise.
        /// </returns>
        [Pure]
        public readonly bool IsValidForRange(IEnumerable<Range<EntityID>> inRanges)
        {
            Precondition.IsNotNull(inRanges, nameof(inRanges));
            var result = false;

            foreach (var idRange in inRanges)
            {
                if (IsValidForRange(idRange))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Returns a <see langword="string"/> that represents the current <see cref="EntityID"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override readonly string ToString()
            => id.ToString(CultureInfo.InvariantCulture);
        #endregion
    }
}
