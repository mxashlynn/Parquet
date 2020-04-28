using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary
{
    /// <summary>
    /// Uniquely identifies every <see cref="Model"/>.
    /// </summary>
    /// <remarks>
    /// <see cref="ModelID"/>s provide a means for the library
    /// to track and rapidly update large numbers of equivalent
    /// game objects.<para />
    /// <para />
    /// For example, multiple identical parquet IDs may be assigned
    /// to <see cref="Maps.MapChunk"/>s or <see cref="Maps.MapRegion"/>s,
    /// and multiple duplicate <see cref="Items.ItemModel"/> IDs may exist in
    /// accross various <see cref="Beings.CharacterModel"/> inventories.<para />
    /// <para />
    /// Using ModelID the library looks up the game object definitions
    /// for each of these when other game elements interact with them,
    /// without filling RAM with numerous duplicate Models.<para />
    /// <para />
    /// There are multiple <see cref="Model"/> subtypes
    /// (<see cref="Parquets.ParquetModel"/>, <see cref="Beings.BeingModel"/>,
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
    /// ModelID is implemented as a mutable struct because, under the hood,
    /// it is simply an Int32.  ModelID is designed to be implicitly
    /// interoperable with and implcity castable to and from integer types.<para />
    /// <para />
    /// Since the entire point of this ID system is to provide a way for the
    /// library to rapidly track changes in large arrays of identical game
    /// objects, it must be a light-weight mutable value type.  This is
    /// analagous to the use case for C# 7 tuples, which are also light-weight
    /// mutable value types.<para />
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
        /// This is implemented as an <see cref="int"/> rather than a <see cref="System.Guid"/>
        /// to support human-readable design documents and <see cref="Range{ModelID}"/> validation.
        /// </remarks>
        private int id;
        #endregion

        #region Implicit Conversion To/From Underlying Type
        /// <summary>
        /// Enables <see cref="ModelID"/>s to be treated as their backing type.
        /// </summary>
        /// <param name="inValue">Any valid identifier value.</param>
        /// <returns>The given identifier value.</returns>
        public static implicit operator ModelID(int inValue)
            => new ModelID { id = inValue };

        /// <summary>
        /// Enables <see cref="ModelID"/> to be treated as their backing type.
        /// </summary>
        /// <param name="inIDentifier">Any identifier.</param>
        /// <returns>The identifier's value.</returns>
        public static implicit operator int(ModelID inIDentifier)
            => inIDentifier.id;
        #endregion

        #region IComparable Implementation
        /// <summary>
        /// Enables <see cref="ModelID"/> to be compared to one another.
        /// </summary>
        /// <param name="inIDentifier">Any <see cref="ModelID"/>.</param>
        /// <returns>
        /// A value indicating the relative ordering of the <see cref="ModelID"/>s being compared.
        /// The return value has these meanings:
        ///     Less than zero indicates that the current instance precedes the given <see cref="ModelID"/> in the sort order.
        ///     Zero indicates that the current instance occurs in the same position in the sort order as the given <see cref="ModelID"/>.
        ///     Greater than zero indicates that the current instance follows the given <see cref="ModelID"/> in the sort order.
        /// </returns>
        public readonly int CompareTo(ModelID inIDentifier)
            => id.CompareTo(inIDentifier.id);

        /// <summary>
        /// Determines whether a specified instance of <see cref="ModelID"/> strictly precedes another specified instance of <see cref="ModelID"/>.
        /// </summary>
        /// <param name="inIDentifier1">The first <see cref="ModelID"/> to compare.</param>
        /// <param name="inIDentifier2">The second <see cref="ModelID"/> to compare.</param>
        /// <returns><c>true</c> if the first identifier strictly precedes the second; otherwise, <c>false</c>.</returns>
        public static bool operator <(ModelID inIDentifier1, ModelID inIDentifier2)
            => inIDentifier1.id < inIDentifier2.id;

        /// <summary>
        /// Determines whether a specified instance of <see cref="ModelID"/> precedes or is ordinally equivalent with
        /// another specified instance of <see cref="ModelID"/>.
        /// </summary>
        /// <param name="inIDentifier1">The first <see cref="ModelID"/> to compare.</param>
        /// <param name="inIDentifier2">The second <see cref="ModelID"/> to compare.</param>
        /// <returns><c>true</c> if the first identifier precedes or is ordinally equivalent with the second; otherwise, <c>false</c>.</returns>
        public static bool operator <=(ModelID inIDentifier1, ModelID inIDentifier2)
            => inIDentifier1.id <= inIDentifier2.id;

        /// <summary>
        /// Determines whether a specified instance of <see cref="ModelID"/> strictly follows another specified instance of <see cref="ModelID"/>.
        /// </summary>
        /// <param name="inIDentifier1">The first <see cref="ModelID"/> to compare.</param>
        /// <param name="inIDentifier2">The second <see cref="ModelID"/> to compare.</param>
        /// <returns><c>true</c> if the first identifier strictly followa the second; otherwise, <c>false</c>.</returns>
        public static bool operator >(ModelID inIDentifier1, ModelID inIDentifier2)
            => inIDentifier1.id > inIDentifier2.id;

        /// <summary>
        /// Determines whether a specified instance of <see cref="ModelID"/> follows or is ordinally equivalent with
        /// another specified instance of <see cref="ModelID"/>.
        /// </summary>
        /// <param name="inIDentifier1">The first <see cref="ModelID"/> to compare.</param>
        /// <param name="inIDentifier2">The second <see cref="ModelID"/> to compare.</param>
        /// <returns><c>true</c> if the first identifier follows or is ordinally equivalent with the second; otherwise, <c>false</c>.</returns>
        public static bool operator >=(ModelID inIDentifier1, ModelID inIDentifier2)
            => inIDentifier1.id >= inIDentifier2.id;
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="ModelID"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public override readonly int GetHashCode()
            => id.GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="ModelID"/> is equal to the current <see cref="ModelID"/>.
        /// </summary>
        /// <param name="inIDentifier">The <see cref="ModelID"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public readonly bool Equals(ModelID inIDentifier)
            => id == inIDentifier.id;

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
        /// <param name="inIDentifier1">The first <see cref="ModelID"/> to compare.</param>
        /// <param name="inIDentifier2">The second <see cref="ModelID"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(ModelID inIDentifier1, ModelID inIDentifier2)
            => inIDentifier1.id == inIDentifier2.id;

        /// <summary>
        /// Determines whether a specified instance of <see cref="ModelID"/> is not equal to another specified instance of <see cref="ModelID"/>.
        /// </summary>
        /// <param name="inIDentifier1">The first <see cref="ModelID"/> to compare.</param>
        /// <param name="inIDentifier2">The second <see cref="ModelID"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(ModelID inIDentifier1, ModelID inIDentifier2)
            => inIDentifier1.id != inIDentifier2.id;
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static ModelID ConverterFactory { get; } =
            None;

        /// <summary>A collection of records that need to have <see cref="ModelID"/>s assigned to them before deserialization.</summary>
        internal static readonly List<string> RecordsWithMissingIDs =
            new List<string>();

        /// <summary>
        /// Registers the given record as a <see cref="Model"/> in need of a <see cref="ModelID"/>.
        /// </summary>
        /// <param name="inRawRecord">The record to regiseter.</param>
        /// <remarks>Used during deserialization to allow the library to generate appropriate IDs.</remarks>
        private static void RegisterMissingID(string inRawRecord)
            => RecordsWithMissingIDs.Add(inRawRecord);

        /// <summary>
        /// Converts the given record column to <see cref="ModelID"/>.
        /// </summary>
        /// <param name="inText">The record column to convert to an object.</param>
        /// <param name="inRow">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="inMemberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
        /// <returns>The <see cref="ModelID"/> created from the record column.</returns>
        public object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            if (string.IsNullOrEmpty(inText)
                || string.Compare(nameof(None), inText, StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                if (inRow?.Context.CurrentIndex == 0)
                {
                    RegisterMissingID(inRow.Context.RawRecord);
                }
                return None;
            }

            var numberStyle = inMemberMapData?.TypeConverterOptions?.NumberStyle ?? All.SerializedNumberStyle;
            var cultureInfo = inMemberMapData?.TypeConverterOptions?.CultureInfo ?? All.SerializedCultureInfo;
            if (int.TryParse(inText, numberStyle, cultureInfo, out var id))
            {
                return (ModelID)id;
            }
            else
            {
                throw new FormatException($"Could not parse {nameof(ModelID)} '{inText}'.");
            }
        }

        /// <summary>
        /// Converts the given <see cref="ModelID"/> to a record column.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="inMemberMapData">The <see cref="MemberMapData"/> for the member being serialized.</param>
        /// <returns>The <see cref="ModelID"/> as a CSV record.</returns>
        public string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => inValue is ModelID id
                ? null != id
                && None != id
                    ? id.ToString()
                    : nameof(None)
                : throw new ArgumentException($"Cannot convert {inValue} to {nameof(ModelID)}.");
        #endregion

        #region Utilities
        /// <summary>
        /// Validates the current <see cref="ModelID"/> over a <see cref="Range{ModelID}"/>.
        /// 1. It is <see cref="None"/>.
        /// 2. It is defined within the given <see cref="Range{ModelID}"/>, inclusive, regardless of sign.
        /// </summary>
        /// <param name="inRange">The <see cref="Range{ModelID}"/> within which the absolute value of the <see cref="ModelID"/> must fall.</param>
        /// <returns>
        /// <c>true</c>, if the <see cref="ModelID"/> is valid given the <see cref="Range{ModelID}"/>, <c>false</c> otherwise.
        /// </returns>
        [Pure]
        public readonly bool IsValidForRange(Range<ModelID> inRange)
            => id == None
            || inRange.ContainsValue(Math.Abs(id));

        /// <summary>
        /// Validates the current <see cref="ModelID"/> over a <see cref="IEnumerable{T}"/>.
        /// A <see cref="ModelID"/> is valid iff:
        /// 1. It is <see cref="None"/>.
        /// 2. It is defined within any of the <see cref="Range{ModelID}"/>a in the given <see cref="IEnumerable{ModelID}"/>, inclusive, regardless of sign.
        /// </summary>
        /// <param name="inRanges">
        /// The <see cref="IEnumerable{T}"/> within which the <see cref="ModelID"/> must fall.
        /// </param>
        /// <returns>
        /// <c>true</c>, if the <see cref="ModelID"/> is valid given the <see cref="IEnumerable{T}"/>, <c>false</c> otherwise.
        /// </returns>
        [Pure]
        public readonly bool IsValidForRange(IEnumerable<Range<ModelID>> inRanges)
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
        /// Returns a <see cref="string"/> that represents the current <see cref="ModelID"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override readonly string ToString()
            => id.ToString(CultureInfo.InvariantCulture);
        #endregion
    }
}
