using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Parquet.Properties;

namespace Parquet
{
    /// <summary>
    /// Uniquely identifies every <see cref="Model"/>.
    /// Instances have value semantics.
    /// </summary>
    /// <remarks>
    /// <see cref="ModelID"/>s provide a means for the library
    /// to track and rapidly update large numbers of equivalent
    /// game objects.
    /// <para />
    /// For example, multiple identical parquet IDs may be assigned
    /// to <see cref="Regions.MapChunk"/>s or <see cref="Regions.RegionModel"/>s,
    /// and multiple duplicate <see cref="Items.ItemModel"/> IDs may exist in
    /// across various <see cref="Beings.CharacterModel"/> inventories.
    /// <para />
    /// Using ModelID the library looks up the game object definitions
    /// for each of these when other game elements interact with them,
    /// without filling RAM with numerous duplicate Models.<para />
    /// <para />
    /// There are multiple <see cref="Model"/> subtypes
    /// (<see cref="Parquets.ParquetModel"/>, <see cref="Beings.BeingModel"/>,
    /// etc.), and each of these subtypes has multiple definitions.
    /// The definitions are purely data-driven, read in from file,
    /// and not type-checked by the compiler.
    /// <para />
    /// Although the compiler does not provide type-checking for IDs,
    /// the library defines valid ranges for all ID subtypes (<see cref="All"/>)
    /// and these are checked by library code.
    /// <para />
    /// A note on implementation as of January 21st, 2021.
    /// <para />
    /// ModelID is implemented as a mutable struct because, under the hood,
    /// it is simply an <see cref="int"/>.  ModelID is designed to be implicitly
    /// interoperable with and implicitly castable to and from integer types.
    /// <para />
    /// Since the entire point of this ID system is to provide a way for the
    /// library to rapidly track changes in large arrays of identical game
    /// objects, it must be a light-weight mutable value type.  This is
    /// analogous to the use case for C# 7 tuples, which are also light-weight
    /// mutable value types.
    /// <para />
    /// If the implementation were ever to become more complex, ModelID
    /// would need to become a class.
    /// </remarks>
    public struct ModelID : IComparable<ModelID>, IEquatable<ModelID>, ITypeConverter
    {
        #region Class Defaults
        /// <summary>Indicates the lack of a <see cref="Model"/>.</summary>
        public static readonly ModelID None = 0;
        #endregion

        #region Characteristics
        /// <summary>Backing type for the <see cref="ModelID"/>.</summary>
        /// <remarks>
        /// This is implemented as an <see cref="int"/> rather than a <see cref="Guid"/>
        /// to support human-readable design documents and <see cref="Range{ModelID}"/> validation.
        /// </remarks>
        private int InternalID;
        #endregion

        #region Implicit Conversion To/From Underlying Type
        /// <summary>
        /// Enables <see cref="ModelID"/>s to be treated as their backing type.
        /// </summary>
        /// <param name="value">Any valid identifier value.</param>
        /// <returns>The given identifier value.</returns>
        public static implicit operator ModelID(int value)
            => new() { InternalID = value };

        /// <summary>
        /// Enables <see cref="ModelID"/> to be treated as their backing type.
        /// </summary>
        /// <param name="id">Any identifier.</param>
        /// <returns>The identifier's value.</returns>
        public static implicit operator int(ModelID id)
            => id.InternalID;
        #endregion

        #region IComparable Implementation
        /// <summary>
        /// Enables <see cref="ModelID"/> to be compared to one another.
        /// </summary>
        /// <param name="other">Any <see cref="ModelID"/>.</param>
        /// <returns>
        /// A value indicating the relative ordering of the <see cref="ModelID"/>s being compared.
        /// The return value has these meanings:
        ///     Less than zero indicates that the current instance precedes the given <see cref="ModelID"/> in the sort order.
        ///     Zero indicates that the current instance occurs in the same position in the sort order as the given <see cref="ModelID"/>.
        ///     Greater than zero indicates that the current instance follows the given <see cref="ModelID"/> in the sort order.
        /// </returns>
        public readonly int CompareTo(ModelID other)
            => InternalID.CompareTo(other.InternalID);

        /// <summary>
        /// Determines whether a specified instance of <see cref="ModelID"/> strictly precedes another specified instance of <see cref="ModelID"/>.
        /// </summary>
        /// <param name="id1">The first <see cref="ModelID"/> to compare.</param>
        /// <param name="id2">The second <see cref="ModelID"/> to compare.</param>
        /// <returns><c>true</c> if the first identifier strictly precedes the second; otherwise, <c>false</c>.</returns>
        public static bool operator <(ModelID id1, ModelID id2)
            => id1.InternalID < id2.InternalID;

        /// <summary>
        /// Determines whether a specified instance of <see cref="ModelID"/> precedes or is ordinally equivalent with
        /// another specified instance of <see cref="ModelID"/>.
        /// </summary>
        /// <param name="id1">The first <see cref="ModelID"/> to compare.</param>
        /// <param name="id2">The second <see cref="ModelID"/> to compare.</param>
        /// <returns><c>true</c> if the first identifier precedes or is ordinally equivalent with the second; otherwise, <c>false</c>.</returns>
        public static bool operator <=(ModelID id1, ModelID id2)
            => id1.InternalID <= id2.InternalID;

        /// <summary>
        /// Determines whether a specified instance of <see cref="ModelID"/> strictly follows another specified instance of <see cref="ModelID"/>.
        /// </summary>
        /// <param name="id1">The first <see cref="ModelID"/> to compare.</param>
        /// <param name="id2">The second <see cref="ModelID"/> to compare.</param>
        /// <returns><c>true</c> if the first identifier strictly follows the second; otherwise, <c>false</c>.</returns>
        public static bool operator >(ModelID id1, ModelID id2)
            => id1.InternalID > id2.InternalID;

        /// <summary>
        /// Determines whether a specified instance of <see cref="ModelID"/> follows or is ordinally equivalent with
        /// another specified instance of <see cref="ModelID"/>.
        /// </summary>
        /// <param name="id1">The first <see cref="ModelID"/> to compare.</param>
        /// <param name="id2">The second <see cref="ModelID"/> to compare.</param>
        /// <returns><c>true</c> if the first identifier follows or is ordinally equivalent with the second; otherwise, <c>false</c>.</returns>
        public static bool operator >=(ModelID id1, ModelID id2)
            => id1.InternalID >= id2.InternalID;
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="ModelID"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        /// <remarks>
        /// If a <see cref="ModelID"/> is stored in a <see cref="HashSet{T}"/> or used as a key in
        /// a <see cref="Dictionary{K,V}"/> it must not be mutated.  It is safe to mutate it again
        /// once it is removed from all such collections.
        /// </remarks>
        public override readonly int GetHashCode()
            // NOTE: This implementation is a potential source of error.  If the identity of a ModelID is changed while the
            // corresponding Model is stored in a hash-based collection it might invalidate the collection.  However,
            // this should never happen in normal Parquet usage.  The reason the hash code is derived from mutable
            // data is similar to the reason .Net's own ValueTuple derives its hash code from mutable data.
            // See:
            // https://github.com/dotnet/coreclr/blob/master/src/System.Private.CoreLib/shared/System/ValueTuple.cs
            // https://ericlippert.com/2011/02/28/guidelines-and-rules-for-gethashcode/
            => InternalID.GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="ModelID"/> is equal to the current <see cref="ModelID"/>.
        /// </summary>
        /// <param name="other">The <see cref="ModelID"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public readonly bool Equals(ModelID other)
            => InternalID == other.InternalID;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="ModelID"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="ModelID"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override readonly bool Equals(object obj)
            => obj is ModelID modelID
            && Equals(modelID);

        /// <summary>
        /// Determines whether a specified instance of <see cref="ModelID"/> is equal to another specified instance of <see cref="ModelID"/>.
        /// </summary>
        /// <param name="id1">The first <see cref="ModelID"/> to compare.</param>
        /// <param name="id2">The second <see cref="ModelID"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(ModelID id1, ModelID id2)
            => id1.InternalID == id2.InternalID;

        /// <summary>
        /// Determines whether a specified instance of <see cref="ModelID"/> is not equal to another specified instance of <see cref="ModelID"/>.
        /// </summary>
        /// <param name="id1">The first <see cref="ModelID"/> to compare.</param>
        /// <param name="id2">The second <see cref="ModelID"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(ModelID id1, ModelID id2)
            => id1.InternalID != id2.InternalID;
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static ModelID ConverterFactory { get; } =
            None;

        /// <summary>A collection of records that need to have <see cref="ModelID"/>s assigned to them before deserialization.</summary>
        internal static readonly ICollection<string> RecordsWithMissingIDs =
            new List<string>();

        /// <summary>
        /// Registers the given record as a <see cref="Model"/> in need of a <see cref="ModelID"/>.
        /// </summary>
        /// <param name="rawRecord">The record to register.</param>
        /// <remarks>Used during deserialization to allow the library to generate appropriate IDs.</remarks>
        private static void RegisterMissingID(string rawRecord)
            => RecordsWithMissingIDs.Add(rawRecord);

        /// <summary>
        /// Converts the given record column to <see cref="ModelID"/>.
        /// </summary>
        /// <param name="text">The record column to convert to an object.</param>
        /// <param name="row">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="memberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
        /// <returns>The <see cref="ModelID"/> created from the record column.</returns>
        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrEmpty(text)
                || string.Equals(nameof(None), text, StringComparison.OrdinalIgnoreCase))
            {
                if (row?.Context.CurrentIndex == 0)
                {
                    RegisterMissingID(row.Context.RawRecord);
                }
                return None;
            }

            var id = int.TryParse(text, All.SerializedNumberStyle, CultureInfo.InvariantCulture, out var temp)
                ? (ModelID)temp
                : DefaultWithFatalParseLog(text, nameof(ModelID), None);

            return id;

            // Convenience method that logs a fatal parsing error and returns the given default value.
            // This is a fatal error as the library is unlikely to be able to accommodate a corrupted ModelID.
            static ModelID DefaultWithFatalParseLog(string value, string name, ModelID defaultValue)
            {
                Logger.Log(LogLevel.Fatal, string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotParse,
                                                         value, name), null);
                return defaultValue;
            }
        }

        /// <summary>
        /// Converts the given <see cref="ModelID"/> to a record column.
        /// </summary>
        /// <param name="value">The instance to convert.</param>
        /// <param name="row">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="memberMapData">The <see cref="MemberMapData"/> for the member being serialized.</param>
        /// <returns>The <see cref="ModelID"/> as a CSV record.</returns>
        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
            => value is ModelID id
                ? None != id
                    ? id.ToString()
                    : nameof(None)
                : Logger.DefaultWithConvertLog(value?.ToString() ?? "null", nameof(ModelID), nameof(None));
        #endregion

        #region Utilities
        /// <summary>
        /// Validates the current <see cref="ModelID"/> over a <see cref="Range{ModelID}"/>.
        /// 1. It is <see cref="None"/>.
        /// 2. It is defined within the given <see cref="Range{ModelID}"/>, inclusive, regardless of sign.
        /// </summary>
        /// <param name="range">The <see cref="Range{ModelID}"/> within which the absolute value of the <see cref="ModelID"/> must fall.</param>
        /// <returns>
        /// <c>true</c>, if the <see cref="ModelID"/> is valid given the <see cref="Range{ModelID}"/>, <c>false</c> otherwise.
        /// </returns>
        [Pure]
        public readonly bool IsValidForRange(Range<ModelID> range)
            => InternalID == None
            || range.ContainsValue(Math.Abs(InternalID));

        /// <summary>
        /// Validates the current <see cref="ModelID"/> over a <see cref="IEnumerable{T}"/>.
        /// A <see cref="ModelID"/> is valid iff:
        /// 1. It is <see cref="None"/>.
        /// 2. It is defined within any of the <see cref="Range{ModelID}"/>a in the given <see cref="IEnumerable{ModelID}"/>, inclusive, regardless of sign.
        /// </summary>
        /// <param name="ranges">
        /// The <see cref="IEnumerable{T}"/> within which the <see cref="ModelID"/> must fall.
        /// </param>
        /// <returns>
        /// <c>true</c>, if the <see cref="ModelID"/> is valid given the <see cref="IEnumerable{T}"/>, <c>false</c> otherwise.
        /// </returns>
        [Pure]
        public readonly bool IsValidForRange(IEnumerable<Range<ModelID>> ranges)
        {
            Precondition.IsNotNull(ranges, nameof(ranges));
            var result = false;

            foreach (var idRange in ranges ?? Enumerable.Empty<Range<ModelID>>())
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
        /// Returns a <see cref="string"/> that represents the current <see cref="ModelID"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override readonly string ToString()
            => InternalID.ToString(CultureInfo.InvariantCulture);
        #endregion
    }

    /// <summary>
    /// Convenience extension methods for concise coding when working with <see cref="ModelID"/> instances.
    /// </summary>
    internal static class ModelIDArrayExtensions
    {
        /// <summary>
        /// Determines if the given position corresponds to a point within the current array.
        /// </summary>
        /// <param name="idArray">The <see cref="ModelID"/> array to validate against.</param>
        /// <param name="position">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public static bool IsValidPosition(this ModelID[,] idArray, Point2D position)
            => position.X > -1
            && position.Y > -1
            && position.X < idArray.GetLength(1)
            && position.Y < idArray.GetLength(0);
    }
}
