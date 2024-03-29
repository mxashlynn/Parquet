using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Parquet.Properties;

namespace Parquet
{
    /// <summary>
    /// Stores the endpoints for a set of values specifying an inclusive range over the given type.
    /// Instances have value semantics.
    /// </summary>
    /// <typeparam name="TElement">The type over which the range is spread.</typeparam>
    public readonly struct Range<TElement> : IEquatable<Range<TElement>>, ITypeConverter
        where TElement : IComparable<TElement>, IEquatable<TElement>
    {
        #region Class Defaults
        /// <summary>Represents the empty range.</summary>
        public static readonly Range<TElement> None = new(default, default);
        #endregion

        #region Characteristics
        /// <summary>Minimum value of the range.</summary>
        public TElement Minimum { get; }

        /// <summary>Maximum value of the range.</summary>
        public TElement Maximum { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="Range{TElement}"/> struct.
        /// </summary>
        /// <param name="minimum">The lower end of the range.</param>
        /// <param name="maximum">The upper end of the range.</param>
        public Range(TElement minimum, TElement maximum)
        {
            Minimum = minimum;
            Maximum = maximum;

            if (!IsValid())
            {
                Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.ErrorOutOfOrderLTE,
                                                           nameof(minimum), minimum, nameof(maximum)));
                // Swap the two values so that execution can continue.
                (Minimum, Maximum) = (Maximum, Minimum);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Range{TElement}"/> struct.
        /// </summary>
        /// <param name="extema">The extremes of the Range.</param>
        public Range((TElement Minimum, TElement Maximum) extema)
            : this(extema.Minimum, extema.Maximum)
        { }
        #endregion

        #region State Queries
        /// <summary>
        /// Determines if the <see cref="Range{TTElement}"/> is well defined; that is, if Minimum is less than or equal to Maximum.
        /// </summary>
        /// <returns><c>true</c>, if the range is valid, <c>false</c> otherwise.</returns>
        public bool IsValid()
            => Minimum.CompareTo(Maximum) <= 0;

        /// <summary>Determines if the given <see cref="Range{TElement}"/> is equal to or entirely contained within the current Range.</summary>
        /// <param name="range">The <see cref="Range{TElement}"/> to test.</param>
        /// <returns><c>true</c>, if the given range is within the current range, <c>false</c> otherwise.</returns>
        public bool ContainsRange(Range<TElement> range)
            => ContainsValue(range.Minimum) && ContainsValue(range.Maximum);

        /// <summary>Determines if the given value is within the range, inclusive.</summary>
        /// <param name="value">The value to test.</param>
        /// <returns><c>true</c>, if the value is in range, <c>false</c> otherwise.</returns>
        public bool ContainsValue(TElement value)
            => Minimum.CompareTo(value) <= 0 && Maximum.CompareTo(value) >= 0;
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static Range<TElement> ConverterFactory { get; }

        /// <summary>Allows deserialization of <typeparamref name="TElement"/>s that are interchangeable with <see cref="long"/>.</summary>
        internal static Int32Converter Int32ConverterFactory { get; } = new Int32Converter();

        /// <summary>Allows deserialization of <typeparamref name="TElement"/>s that are interchangeable with <see cref="double"/>.</summary>
        internal static SingleConverter SingleConverterFactory { get; } = new SingleConverter();

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="value">The instance to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
            => value is Range<TElement> range
                ? $"{range.Minimum}{Delimiters.ElementDelimiter}" +
                  $"{range.Maximum}"
                : Logger.DefaultWithConvertLog(value?.ToString() ?? "null", nameof(Range<TElement>),
                                               $"{default(TElement)}{Delimiters.ElementDelimiter}{default(TElement)}");

        /// <summary>
        /// Converts the given <see cref="string"/> to an <see cref="object"/> as deserialization.
        /// </summary>
        /// <param name="text">The instance to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrEmpty(text))
            {
                return Logger.DefaultWithConvertLog(text, nameof(Range<TElement>), None);
            }

            var parameterText = text.Split(Delimiters.ElementDelimiter);

            return IsIntConvertible(default)
                ? new Range<TElement>((TElement)Int32ConverterFactory.ConvertFromString(parameterText[0], row, memberMapData),
                                      (TElement)Int32ConverterFactory.ConvertFromString(parameterText[1], row, memberMapData))
                : IsSingleConvertible(default)
                    ? new Range<TElement>((TElement)SingleConverterFactory.ConvertFromString(parameterText[0], row, memberMapData),
                                          (TElement)SingleConverterFactory.ConvertFromString(parameterText[1], row, memberMapData))
                    : Logger.DefaultWithUnsupportedSerializationLog(nameof(Range<TElement>), None);

            // Determines if the given variable may be deserialized as an integer.
            // Returns true if TElement may be deserialized via Int32Converter.
            static bool IsIntConvertible(TElement element)
                => element switch
                {
                    sbyte _ => true,
                    short _ => true,
                    int _ => true,
                    ModelID _ => true,
                    _ => false
                };

            // Determines if the given variable may be deserialized as a single-precision floating point number.
            // Returns true if TElement may be deserialized via SingleConverter.
            static bool IsSingleConvertible(TElement element)
                => element switch
                {
                    float _ => true,
                    _ => false
                };
        }
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="Range{TElement}"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public override int GetHashCode()
            => (Minimum, Maximum).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="Range{TElement}"/> is equal to the current <see cref="Range{TElement}"/>.
        /// </summary>
        /// <param name="other">The <see cref="Range{TElement}"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(Range<TElement> other)
            => Minimum.Equals(other.Minimum)
            && Maximum.Equals(other.Maximum);

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="Range{TElement}"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="Range{TElement}"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is Range<TElement> rangel && Equals(rangel);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Range{TElement}"/>
        /// is equal to another specified instance of <see cref="Range{TElement}"/>.
        /// </summary>
        /// <param name="range1">The first <see cref="Range{TElement}"/> to compare.</param>
        /// <param name="range2">The second <see cref="Range{TElement}"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Range<TElement> range1, Range<TElement> range2)
            => range1.Equals(range2);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Range{TElement}"/>
        /// is not equal to another specified instance of <see cref="Range{TElement}"/>.
        /// </summary>
        /// <param name="range1">The first <see cref="Range{TElement}"/> to compare.</param>
        /// <param name="range2">The second <see cref="Range{TElement}"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Range<TElement> range1, Range<TElement> range2)
            => !range1.Equals(range2);
        #endregion

        #region Utilities
        /// <summary>
        /// Deconstructs the current <see cref="Range{TElement}"/> into its constituent extrema.
        /// </summary>
        /// <param name="minimum">The minimum.</param>
        /// <param name="maximum">The maximum.</param>
        public void Deconstruct(out TElement minimum, out TElement maximum)
            => (minimum, maximum) = (Minimum, Maximum);

        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="Range{TElement}"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"[{Minimum} - {Maximum}]";
        #endregion
    }

    /// <summary>
    /// Provides extension methods to <see cref="IEnumerable{TElement}"/> collections of <see cref="Range{TElement}"/>.
    /// </summary>
    public static class RangeCollectionExtensions
    {
        /// <summary>
        /// Determines if all of the given <see cref="Range{TElement}"/>s are well defined;
        /// that is, if Minima are less than or equal to Maxima.
        /// </summary>
        /// <returns><c>true</c>, if the range is valid, <c>false</c> otherwise.</returns>
        public static bool IsValid<TElement>(this IEnumerable<Range<TElement>> rangeCollection)
            where TElement : IComparable<TElement>, IEquatable<TElement>
        {
            Precondition.IsNotNull(rangeCollection, nameof(rangeCollection));

            var isValid = true;
            foreach (var range in rangeCollection ?? Enumerable.Empty<Range<TElement>>())
            {
                isValid &= range.IsValid();
            }
            return isValid;
        }

        /// <summary>
        /// Determines if the given <paramref name="value"/> is contained by any of the <see cref="Range{TElement}"/>s
        /// in the current <see cref="IEnumerable{Range}"/>.
        /// </summary>
        /// <param name="rangeCollection">The range collection in which to search.</param>
        /// <param name="value">The value to search for.</param>
        /// <typeparam name="TElement">The type over which the Ranges are defined.</typeparam>
        /// <returns>
        /// <c>true</c>, if <paramref name="rangeCollection"/> contains the <paramref name="value"/>,
        /// <c>false</c> otherwise.
        /// </returns>
        public static bool ContainsValue<TElement>(this IEnumerable<Range<TElement>> rangeCollection, TElement value)
            where TElement : IComparable<TElement>, IEquatable<TElement>
        {
            Precondition.IsNotNull(rangeCollection, nameof(rangeCollection));

            var foundRange = false;
            foreach (var range in rangeCollection ?? Enumerable.Empty<Range<TElement>>())
            {
                if (range.ContainsValue(value))
                {
                    foundRange = true;
                    break;
                }
            }
            return foundRange;
        }

        /// <summary>
        /// Determines if the given <see cref="Range{TElement}"/> is contained by any of the ranges
        /// in the current <see cref="IEnumerable{Range}"/>.
        /// </summary>
        /// <param name="rangeCollection">The range collection in which to search.</param>
        /// <param name="rangeSought">The range to search for.</param>
        /// <typeparam name="TElement">The type over which the Ranges are defined.</typeparam>
        /// <returns><c>true</c>, if the list contains the given range, <c>false</c> otherwise.</returns>
        public static bool ContainsRange<TElement>(this IEnumerable<Range<TElement>> rangeCollection, Range<TElement> rangeSought)
            where TElement : IComparable<TElement>, IEquatable<TElement>
        {
            Precondition.IsNotNull(rangeCollection, nameof(rangeCollection));

            var foundRange = false;
            foreach (var range in rangeCollection ?? Enumerable.Empty<Range<TElement>>())
            {
                if (range.ContainsRange(rangeSought))
                {
                    foundRange = true;
                    break;
                }
            }
            return foundRange;
        }
    }
}
