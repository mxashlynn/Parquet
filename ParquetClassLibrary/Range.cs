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
        public static readonly Range<TElement> None = new Range<TElement>(default, default);
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
        /// <param name="inMinimum">The lower end of the range.</param>
        /// <param name="inMaximum">The upper end of the range.</param>
        public Range(TElement inMinimum, TElement inMaximum)
        {
            Minimum = inMinimum;
            Maximum = inMaximum;

            if (!IsValid())
            {
                Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.ErrorOutOfOrderLTE,
                                                           nameof(inMinimum), inMinimum, nameof(inMaximum)));
                // Swap the two values so that execution can continue.
                (Minimum, Maximum) = (Maximum, Minimum);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Range{TElement}"/> struct.
        /// </summary>
        /// <param name="inExtema">The extremes of the Range.</param>
        public Range((TElement Minimum, TElement Maximum) inExtema)
            : this(inExtema.Minimum, inExtema.Maximum)
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
        /// <param name="inRange">The <see cref="Range{TElement}"/> to test.</param>
        /// <returns><c>true</c>, if the given range is within the current range, <c>false</c> otherwise.</returns>
        public bool ContainsRange(Range<TElement> inRange)
            => ContainsValue(inRange.Minimum) && ContainsValue(inRange.Maximum);

        /// <summary>Determines if the given value is within the range, inclusive.</summary>
        /// <param name="inValue">The value to test.</param>
        /// <returns><c>true</c>, if the value is in range, <c>false</c> otherwise.</returns>
        public bool ContainsValue(TElement inValue)
            => Minimum.CompareTo(inValue) <= 0 && Maximum.CompareTo(inValue) >= 0;
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
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => inValue is Range<TElement> range
                ? $"{range.Minimum}{Delimiters.ElementDelimiter}" +
                  $"{range.Maximum}"
                : Logger.DefaultWithConvertLog(inValue?.ToString() ?? "null", nameof(Range<TElement>),
                                               $"{default(TElement)}{Delimiters.ElementDelimiter}{default(TElement)}");

        /// <summary>
        /// Converts the given <see cref="string"/> to an <see cref="object"/> as deserialization.
        /// </summary>
        /// <param name="inText">The instance to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            if (string.IsNullOrEmpty(inText))
            {
                return Logger.DefaultWithConvertLog(inText, nameof(Range<TElement>), None);
            }

            var parameterText = inText.Split(Delimiters.ElementDelimiter);

            return IsIntConvertible(default)
                ? new Range<TElement>((TElement)Int32ConverterFactory.ConvertFromString(parameterText[0], inRow, inMemberMapData),
                                      (TElement)Int32ConverterFactory.ConvertFromString(parameterText[1], inRow, inMemberMapData))
                : IsSingleConvertible(default)
                    ? new Range<TElement>((TElement)SingleConverterFactory.ConvertFromString(parameterText[0], inRow, inMemberMapData),
                                          (TElement)SingleConverterFactory.ConvertFromString(parameterText[1], inRow, inMemberMapData))
                    : Logger.DefaultWithUnsupportedSerializationLog(nameof(Range<TElement>), None);

            // Determines if the given variable may be deserialized as an integer.
            // Returns true if TElement may be deserialized via Int32Converter.
            static bool IsIntConvertible(TElement inElement)
                => inElement switch
                {
                    sbyte _ => true,
                    short _ => true,
                    int _ => true,
                    ModelID _ => true,
                    _ => false
                };

            // Determines if the given variable may be deserialized as a single-precision floating point number.
            // Returns true if TElement may be deserialized via SingleConverter.
            static bool IsSingleConvertible(TElement inElement)
                => inElement switch
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
        /// <param name="inRange">The <see cref="Range{TElement}"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(Range<TElement> inRange)
            => Minimum.Equals(inRange.Minimum)
            && Maximum.Equals(inRange.Maximum);

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
        /// <param name="inRange1">The first <see cref="Range{TElement}"/> to compare.</param>
        /// <param name="inRange2">The second <see cref="Range{TElement}"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Range<TElement> inRange1, Range<TElement> inRange2)
            => inRange1.Equals(inRange2);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Range{TElement}"/>
        /// is not equal to another specified instance of <see cref="Range{TElement}"/>.
        /// </summary>
        /// <param name="inRange1">The first <see cref="Range{TElement}"/> to compare.</param>
        /// <param name="inRange2">The second <see cref="Range{TElement}"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Range<TElement> inRange1, Range<TElement> inRange2)
            => !inRange1.Equals(inRange2);
        #endregion

        #region Utilities
        /// <summary>
        /// Deconstructs the current <see cref="Range{TElement}"/> into its constituent extrema.
        /// </summary>
        /// <param name="outMinimum">The minimum.</param>
        /// <param name="outMaximum">The maximum.</param>
        public void Deconstruct(out TElement outMinimum, out TElement outMaximum)
            => (outMinimum, outMaximum) = (Minimum, Maximum);

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
        public static bool IsValid<TElement>(this IEnumerable<Range<TElement>> inRangeCollection)
            where TElement : IComparable<TElement>, IEquatable<TElement>
        {
            Precondition.IsNotNull(inRangeCollection, nameof(inRangeCollection));

            var isValid = true;
            foreach (var range in inRangeCollection ?? Enumerable.Empty<Range<TElement>>())
            {
                isValid &= range.IsValid();
            }
            return isValid;
        }

        /// <summary>
        /// Determines if the given <paramref name="inValue"/> is contained by any of the <see cref="Range{TElement}"/>s
        /// in the current <see cref="IEnumerable{Range}"/>.
        /// </summary>
        /// <param name="inRangeCollection">The range collection in which to search.</param>
        /// <param name="inValue">The value to search for.</param>
        /// <typeparam name="TElement">The type over which the Ranges are defined.</typeparam>
        /// <returns>
        /// <c>true</c>, if <paramref name="inRangeCollection"/> contains the <paramref name="inValue"/>,
        /// <c>false</c> otherwise.
        /// </returns>
        public static bool ContainsValue<TElement>(this IEnumerable<Range<TElement>> inRangeCollection, TElement inValue)
            where TElement : IComparable<TElement>, IEquatable<TElement>
        {
            Precondition.IsNotNull(inRangeCollection, nameof(inRangeCollection));

            var foundRange = false;
            foreach (var range in inRangeCollection ?? Enumerable.Empty<Range<TElement>>())
            {
                if (range.ContainsValue(inValue))
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
        /// <param name="inRangeCollection">The range collection in which to search.</param>
        /// <param name="inRange">The range to search for.</param>
        /// <typeparam name="TElement">The type over which the Ranges are defined.</typeparam>
        /// <returns><c>true</c>, if the list contains the given range, <c>false</c> otherwise.</returns>
        public static bool ContainsRange<TElement>(this IEnumerable<Range<TElement>> inRangeCollection, Range<TElement> inRange)
            where TElement : IComparable<TElement>, IEquatable<TElement>
        {
            Precondition.IsNotNull(inRangeCollection, nameof(inRangeCollection));

            var foundRange = false;
            foreach (var range in inRangeCollection ?? Enumerable.Empty<Range<TElement>>())
            {
                if (range.ContainsRange(inRange))
                {
                    foundRange = true;
                    break;
                }
            }
            return foundRange;
        }
    }
}
