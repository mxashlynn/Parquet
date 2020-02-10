using System;
using System.Collections.Generic;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary
{
    /// <summary>
    /// Stores the endpoints for a set of values specifying an inclusive range over the given type.
    /// </summary>
    /// <typeparam name="TElement">The type over which the range is spread.</typeparam>
    public readonly struct Range<TElement> : IEquatable<Range<TElement>>, ITypeConverter
        where TElement : IComparable<TElement>, IEquatable<TElement>
    {
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
        /// <exception cref="ArgumentException">
        /// Thrown when the range is not well-defined.  <seealso cref="IsValid"/>.
        /// </exception>
        public Range(TElement inMinimum, TElement inMaximum)
        {
            Minimum = inMinimum;
            Maximum = inMaximum;

            if (!IsValid())
            {
                throw new InvalidOperationException($"{nameof(inMinimum)} must be less than or equal to {nameof(inMaximum)}.");
            }
        }
        #endregion

        #region State Queries
        /// <summary>
        /// Determines if the <see cref="Range{TTElement"/> is well defined; that is, if Minimum is less than or equal to Maximum.
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
        internal static readonly Range<TElement> ConverterFactory = new Range<TElement>();

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => null != inValue
            && inValue is Vector2D vector
                ? $"{vector.X}{Rules.Delimiters.ElementDelimiter}" +
                  $"{vector.Y}"
            : throw new ArgumentException($"Could not serialize {inValue} as {nameof(Vector2D)}.");

        /// <summary>
        /// Converts the given <see cref="string"/> to an <see cref="object"/> as deserialization.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            if (string.IsNullOrEmpty(inText))
            {
                throw new ArgumentException($"Could not convert '{inText}' to {nameof(Range<TElement>)}.");
            }

            var numberStyle = inMemberMapData?.TypeConverterOptions?.NumberStyle ?? All.SerializedNumberStyle;
            var cultureInfo = inMemberMapData?.TypeConverterOptions?.CultureInfo ?? All.SerializedCultureInfo;
            var parameterText = inText.Split(Rules.Delimiters.ElementDelimiter);

            if (int.TryParse(parameterText[0], numberStyle, cultureInfo, out var x)
                && int.TryParse(parameterText[1], numberStyle, cultureInfo, out var y))
            {
                // TODO Find a generic way to handle Range deserialization.
                var implementingType = typeof(TElement);
                if (implementingType == typeof(int))
                {
                    return new Range<int>(x, y);
                }
                else if (implementingType == typeof(EntityID))
                {
                    return new Range<EntityID>(x, y);
                }
                else
                {
                    throw new NotImplementedException($"Cannot deserialize {nameof(Range<TElement>)} yet.");
                }
            }
            else
            {
                throw new FormatException($"Could not parse '{inText}' as {nameof(Range<TElement>)}.");
            }
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
        /// Returns a <see langword="string"/> that represents the current <see cref="Range{TElement}"/>.
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
            foreach (var range in inRangeCollection)
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
        /// <c>true</c>, if the <paramref name="inValue"/> was containsed in <paramref name="inRangeCollection"/>,
        /// <c>false</c> otherwise.
        /// </returns>
        public static bool ContainsValue<TElement>(this IEnumerable<Range<TElement>> inRangeCollection, TElement inValue)
            where TElement : IComparable<TElement>, IEquatable<TElement>
        {
            Precondition.IsNotNull(inRangeCollection, nameof(inRangeCollection));

            var foundRange = false;
            foreach (var range in inRangeCollection)
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
        /// <returns><c>true</c>, if the given range was containsed in the list, <c>false</c> otherwise.</returns>
        public static bool ContainsRange<TElement>(this IEnumerable<Range<TElement>> inRangeCollection, Range<TElement> inRange)
            where TElement : IComparable<TElement>, IEquatable<TElement>
        {
            Precondition.IsNotNull(inRangeCollection, nameof(inRangeCollection));

            var foundRange = false;
            foreach (var range in inRangeCollection)
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
