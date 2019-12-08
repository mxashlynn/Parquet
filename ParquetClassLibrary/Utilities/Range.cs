using System;
using System.Collections.Generic;

namespace ParquetClassLibrary.Utilities
{
    /// <summary>
    /// Stores the endpoints for a set of values specifying an inclusive range over the given type.
    /// </summary>
    /// <typeparam name="T">The type over which the range is spread.</typeparam>
    public struct Range<T> : IEquatable<Range<T>> where T : IComparable<T>, IEquatable<T>
    {
        /// <summary>Minimum value of the range.</summary>
        public T Minimum { get; set; }

        /// <summary>Maximum value of the range.</summary>
        public T Maximum { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Range{T}"/> struct.
        /// </summary>
        /// <param name="in_minimum">The lower end of the range.</param>
        /// <param name="in_maximum">The upper end of the range.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when the range is not well-defined.  <seealso cref="IsValid"/>.
        /// </exception>
        public Range(T in_minimum, T in_maximum)
        {
            Minimum = in_minimum;
            Maximum = in_maximum;

            if (!IsValid())
            {
                throw new InvalidOperationException($"{nameof(in_minimum)} must be less than or equal to {nameof(in_maximum)}.");
            }
        }

        /// <summary>
        /// Determines if the <see cref="Range{T}"/> is well defined; that is, if Minimum is less than or equal to Maximum.
        /// </summary>
        /// <returns><c>true</c>, if the range is valid, <c>false</c> otherwise.</returns>
        public bool IsValid()
        {
            return Minimum.CompareTo(Maximum) <= 0;
        }

        /// <summary>Determines if the given <see cref="Range{T}"/> is equal to or entirely contained within the current Range.</summary>
        /// <param name="in_range">The <see cref="Range{T}"/> to test.</param>
        /// <returns><c>true</c>, if the given range is within the current range, <c>false</c> otherwise.</returns>
        public bool ContainsRange(Range<T> in_range)
        {
            return ContainsValue(in_range.Minimum) && ContainsValue(in_range.Maximum);
        }

        /// <summary>Determines if the given value is within the range, inclusive.</summary>
        /// <param name="in_value">The value to test.</param>
        /// <returns><c>true</c>, if the value is in range, <c>false</c> otherwise.</returns>
        public bool ContainsValue(T in_value)
        {
            return Minimum.CompareTo(in_value) <= 0 && Maximum.CompareTo(in_value) >= 0;
        }

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
        /// <param name="in_range">The <see cref="Range{T}"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(Range<T> in_range)
            => Minimum.Equals(in_range.Minimum)
            && Maximum.Equals(in_range.Maximum);

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="Range{T}"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="Range{T}"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is Range<T> rangel && Equals(rangel);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Range{T}"/> is equal to another specified instance of <see cref="Range{T}"/>.
        /// </summary>
        /// <param name="in_range1">The first <see cref="Range{T}"/> to compare.</param>
        /// <param name="in_range2">The second <see cref="Range{T}"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Range<T> in_range1, Range<T> in_range2)
            => in_range1.Equals(in_range2);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Range{T}"/> is not equal to another specified instance of <see cref="Range{T}"/>.
        /// </summary>
        /// <param name="in_range1">The first <see cref="Range{T}"/> to compare.</param>
        /// <param name="in_range2">The second <see cref="Range{T}"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Range<T> in_range1, Range<T> in_range2)
            => !in_range1.Equals(in_range2);
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
        public static bool IsValid<T>(this IEnumerable<Range<T>> in_rangeCollection)
            where T : IComparable<T>, IEquatable<T>
        {
            Precondition.IsNotNull(in_rangeCollection, nameof(in_rangeCollection));

            var isValid = true;
            foreach (var range in in_rangeCollection)
            {
                isValid &= range.IsValid();
            }
            return isValid;
        }

        /// <summary>
        /// Determines if the given <paramref name="in_value"/> is contained by any of the <see cref="Range{T}"/>s
        /// in the current <see cref="IEnumerable{Range{Type}}"/>.
        /// </summary>
        /// <param name="in_rangeCollection">The range collection in which to search.</param>
        /// <param name="in_value">The value to search for.</param>
        /// <typeparam name="T">The type over which the Ranges are defined.</typeparam>
        /// <returns>
        /// <c>true</c>, if the <paramref name="in_value"/> was containsed in <paramref name="in_rangeCollection"/>,
        /// <c>false</c> otherwise.
        /// </returns>
        public static bool ContainsValue<T>(this IEnumerable<Range<T>> in_rangeCollection, T in_value)
            where T : IComparable<T>, IEquatable<T>
        {
            Precondition.IsNotNull(in_rangeCollection, nameof(in_rangeCollection));

            var foundRange = false;
            foreach (var range in in_rangeCollection)
            {
                if (range.ContainsValue(in_value))
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
        /// <param name="in_rangeCollection">The range collection in which to search.</param>
        /// <param name="in_range">The range to search for.</param>
        /// <typeparam name="T">The type over which the Ranges are defined.</typeparam>
        /// <returns><c>true</c>, if the given range was containsed in the list, <c>false</c> otherwise.</returns>
        public static bool ContainsRange<T>(this IEnumerable<Range<T>> in_rangeCollection, Range<T> in_range)
            where T : IComparable<T>, IEquatable<T>
        {
            Precondition.IsNotNull(in_rangeCollection, nameof(in_rangeCollection));

            var foundRange = false;
            foreach (var range in in_rangeCollection)
            {
                if (range.ContainsRange(in_range))
                {
                    foundRange = true;
                    break;
                }
            }
            return foundRange;
        }
    }
}
