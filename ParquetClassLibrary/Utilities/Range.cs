using System;

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
        /// Determines if the range is well defined; that is, if Minimum is less than or equal to Maximum.
        /// </summary>
        /// <returns><c>true</c>, if the range is valid, <c>false</c> otherwise.</returns>
        public bool IsValid()
        {
            return Minimum.CompareTo(Maximum) <= 0;
        }

        /// <summary>Determines if the given value is within the range, inclusive.</summary>
        /// <param name="in_value">The value to test</param>
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
}
