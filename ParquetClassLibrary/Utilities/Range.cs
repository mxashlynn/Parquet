using System;
using System.Collections.Generic;

namespace ParquetClassLibrary.Utilities
{
    /// <summary>
    /// Stores the endpoints for a set of values specifying an inclusive range over the given type.
    /// </summary>
    /// <typeparam name="T">The type over which the range is spread.</typeparam>
    public struct Range<T> where T : IComparable<T>
    {
        /// <summary>Minimum value of the range.</summary>
        public T Minimum { get; set; }

        /// <summary>Maximum value of the range.</summary>
        public T Maximum { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ParquetClassLibrary.Utilities.Range`1"/> struct.
        /// </summary>
        /// <param name="in_minimum">The lower end of the range.</param>
        /// <param name="in_maximum">The upper end of the range.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when the range is not well-defined.  See <see cref="T:ParquetClassLibrary.Utilities.Range.IsValid"/>.
        /// </exception>
        public Range(T in_minimum, T in_maximum)
        {
            Minimum = in_minimum;
            Maximum = in_maximum;

            if (!IsValid())
            {
                throw new ArgumentException($"{nameof(in_minimum)} and {nameof(in_maximum)}");
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

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:ParquetClassLibrary.Utilities.Range`1"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
        {
            return string.Format($"[{Minimum} - {Maximum}]");
        }
    }

    /// <summary>
    /// Provides extension methods to <see cref="IEquatable{T}"/> collections of <see cref="Range{T}"/>.
    /// </summary>
    public static class RangeCollectionExtensions
    {
        /// <summary>
        /// Determines if all of the given <see cref="Range{T}"/>s are well defined; that is, if Minima are less than or equal to Maxima.
        /// </summary>
        /// <returns><c>true</c>, if the range is valid, <c>false</c> otherwise.</returns>
        public static bool IsValid<T>(this IEnumerable<Range<T>> in_rangeCollection) where T : IComparable<T>
        {
            var isValid = true;

            foreach (var range in in_rangeCollection)
            {
                isValid &= range.IsValid();
            }

            return isValid;
        }

        /// <summary>
        /// Determines if the given <paramref name="in_value"/> is contained by any of the <see cref="Range{T}"/>s
        /// in the current <see cref="List{Range{Type}}"/>.
        /// </summary>
        /// <param name="in_rangeCollection">The range collection in which to search.</param>
        /// <param name="in_value">The value to search for.</param>
        /// <typeparam name="T">The type over which the Ranges are defined.</typeparam>
        /// <returns>
        /// <c>true</c>, if the <paramref name="in_value"/> was containsed in <paramref name="in_rangeCollection"/>,
        /// <c>false</c> otherwise.
        /// </returns>
        public static bool ContainsValue<T>(this IEnumerable<Range<T>> in_rangeCollection, T in_value)
            where T : IComparable<T>
        {
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
        /// in the current <see cref="List{Range{Type}}"/>.
        /// </summary>
        /// <param name="in_rangeCollection">The range collection in which to search.</param>
        /// <param name="in_range">The range to search for.</param>
        /// <typeparam name="T">The type over which the Ranges are defined.</typeparam>
        /// <returns><c>true</c>, if the given range was containsed in the list, <c>false</c> otherwise.</returns>
        public static bool ContainsRange<T>(this IEnumerable<Range<T>> in_rangeCollection, Range<T> in_range)
            where T : IComparable<T>
        {
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
