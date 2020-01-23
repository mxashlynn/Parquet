using System;
using System.Collections.Generic;
using CsvHelper.Configuration;

namespace ParquetClassLibrary.Utilities
{
    /// <summary>
    /// Stores the endpoints for a set of values specifying an inclusive range over the given type.
    /// </summary>
    /// <typeparam name="TElement">The type over which the range is spread.</typeparam>
    public readonly struct Range<TElement> : IEquatable<Range<TElement>> where TElement : IComparable<TElement>, IEquatable<TElement>
    {
        #region Characteristics
        /// <summary>Minimum value of the range.</summary>
        public TElement Minimum { get; }

        /// <summary>Maximum value of the range.</summary>
        public TElement Maximum { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="Range{T}"/> struct.
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
        /// Determines if the <see cref="Range{T}"/> is well defined; that is, if Minimum is less than or equal to Maximum.
        /// </summary>
        /// <returns><c>true</c>, if the range is valid, <c>false</c> otherwise.</returns>
        public bool IsValid()
            => Minimum.CompareTo(Maximum) <= 0;

        /// <summary>Determines if the given <see cref="Range{T}"/> is equal to or entirely contained within the current Range.</summary>
        /// <param name="inRange">The <see cref="Range{T}"/> to test.</param>
        /// <returns><c>true</c>, if the given range is within the current range, <c>false</c> otherwise.</returns>
        public bool ContainsRange(Range<TElement> inRange)
            => ContainsValue(inRange.Minimum) && ContainsValue(inRange.Maximum);

        /// <summary>Determines if the given value is within the range, inclusive.</summary>
        /// <param name="inValue">The value to test.</param>
        /// <returns><c>true</c>, if the value is in range, <c>false</c> otherwise.</returns>
        public bool ContainsValue(TElement inValue)
            => Minimum.CompareTo(inValue) <= 0 && Maximum.CompareTo(inValue) >= 0;
        #endregion

        #region Serialization
        /// <summary>
        /// Maps the values in a <see cref="Range{TComparable}"/> to records that CSVHelper recognizes.
        /// </summary>
        internal sealed class RangeClassMap<TComparable> : ClassMap<Range<TComparable>>
            where TComparable : IComparable<TComparable>, IEquatable<TComparable>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="RangeClassMap{T}"/> class.
            /// </summary>
            public RangeClassMap()
            {
                Map(m => m.Maximum);
                Map(m => m.Minimum);
            }
        }
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="Range{T}"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public override int GetHashCode()
            => (Minimum, Maximum).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="Range{T}"/> is equal to the current <see cref="Range{T}"/>.
        /// </summary>
        /// <param name="inRange">The <see cref="Range{T}"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(Range<TElement> inRange)
            => Minimum.Equals(inRange.Minimum)
            && Maximum.Equals(inRange.Maximum);

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="Range{T}"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="Range{T}"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is Range<TElement> rangel && Equals(rangel);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Range{T}"/> is equal to another specified instance of <see cref="Range{T}"/>.
        /// </summary>
        /// <param name="inRange1">The first <see cref="Range{T}"/> to compare.</param>
        /// <param name="inRange2">The second <see cref="Range{T}"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Range<TElement> inRange1, Range<TElement> inRange2)
            => inRange1.Equals(inRange2);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Range{T}"/> is not equal to another specified instance of <see cref="Range{T}"/>.
        /// </summary>
        /// <param name="inRange1">The first <see cref="Range{T}"/> to compare.</param>
        /// <param name="inRange2">The second <see cref="Range{T}"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Range<TElement> inRange1, Range<TElement> inRange2)
            => !inRange1.Equals(inRange2);
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see langword="string"/> that represents the current <see cref="Range{T}"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"[{Minimum} - {Maximum}]";
        #endregion
    }

    /// <summary>
    /// Provides extension methods to <see cref="IEnumerable{T}"/> collections of <see cref="Range{T}"/>.
    /// </summary>
    public static class RangeCollectionExtensions
    {
        /// <summary>
        /// Determines if all of the given <see cref="Range{T}"/>s are well defined; that is, if Minima are less than or equal to Maxima.
        /// </summary>
        /// <returns><c>true</c>, if the range is valid, <c>false</c> otherwise.</returns>
        public static bool IsValid<T>(this IEnumerable<Range<T>> inRangeCollection)
            where T : IComparable<T>, IEquatable<T>
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
        /// Determines if the given <paramref name="inValue"/> is contained by any of the <see cref="Range{T}"/>s
        /// in the current <see cref="IEnumerable{Range{Type}}"/>.
        /// </summary>
        /// <param name="inRangeCollection">The range collection in which to search.</param>
        /// <param name="inValue">The value to search for.</param>
        /// <typeparam name="T">The type over which the Ranges are defined.</typeparam>
        /// <returns>
        /// <c>true</c>, if the <paramref name="inValue"/> was containsed in <paramref name="inRangeCollection"/>,
        /// <c>false</c> otherwise.
        /// </returns>
        public static bool ContainsValue<T>(this IEnumerable<Range<T>> inRangeCollection, T inValue)
            where T : IComparable<T>, IEquatable<T>
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
        /// Determines if the given <see cref="Range{T}"/> is contained by any of the ranges
        /// in the current <see cref="IEnumerable{Range{Type}}"/>.
        /// </summary>
        /// <param name="inRangeCollection">The range collection in which to search.</param>
        /// <param name="inRange">The range to search for.</param>
        /// <typeparam name="T">The type over which the Ranges are defined.</typeparam>
        /// <returns><c>true</c>, if the given range was containsed in the list, <c>false</c> otherwise.</returns>
        public static bool ContainsRange<T>(this IEnumerable<Range<T>> inRangeCollection, Range<T> inRange)
            where T : IComparable<T>, IEquatable<T>
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
