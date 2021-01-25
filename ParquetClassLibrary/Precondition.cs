using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Parquet.Properties;

namespace Parquet
{
    /// <summary>
    /// Provides constructors and initialization routines with concise argument boilerplate.
    /// </summary>
    public static class Precondition
    {
        #region Class Defaults
        /// <summary>Text to use when no argument name is provided.</summary>
        private const string DefaultArgumentName = "Argument";
        #endregion

        /// <summary>
        /// Checks if the given <see cref="int"/> falls within the given <see cref="Range{T}"/>, inclusive.
        /// </summary>
        /// <param name="inInt">The integer to test.</param>
        /// <param name="inBounds">The range it must fall within.</param>
        /// <param name="inArgumentName">The name of the argument to use in error reporting.</param>
        /// <exception cref="ArgumentOutOfRangeException">When the integer is not in range.</exception>
        [Conditional("DEBUG"), Conditional("DESIGN")]
        public static void IsInRange(int inInt, Range<int> inBounds, string inArgumentName)
        {
            if (!inBounds.ContainsValue(inInt))
            {
                if (string.IsNullOrEmpty(inArgumentName))
                {
                    inArgumentName = DefaultArgumentName;
                }
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorOutOfBounds,
                                                                    inArgumentName, inInt, inBounds));
            }
        }

        /// <summary>
        /// Checks if the given <see cref="ModelID"/> falls within the given <see cref="Range{ModelID}"/>, inclusive.
        /// </summary>
        /// <param name="inID">The identifier to test.</param>
        /// <param name="inBounds">The range it must fall within.</param>
        /// <param name="inArgumentName">The name of the argument to use in error reporting.</param>
        /// <exception cref="ArgumentOutOfRangeException">When the identifier is not in range.</exception>
        [Conditional("DEBUG"), Conditional("DESIGN")]
        public static void IsInRange(ModelID inID, Range<ModelID> inBounds, string inArgumentName)
        {
            if (!inID.IsValidForRange(inBounds))
            {
                if (string.IsNullOrEmpty(inArgumentName))
                {
                    inArgumentName = DefaultArgumentName;
                }
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorOutOfBounds,
                                                                    inArgumentName, inID, inBounds));
            }
        }

        /// <summary>
        /// Checks if the first given <see cref="Range{ModelID}"/> falls within the second given <see cref="Range{ModelID}"/>, inclusive.
        /// </summary>
        /// <param name="inInnerBounds">The range to test.</param>
        /// <param name="inOuterBounds">The range it must fall within.</param>
        /// <param name="inArgumentName">The name of the argument to use in error reporting.</param>
        /// <exception cref="ArgumentOutOfRangeException">When the first range is not in the second range.</exception>
        [Conditional("DEBUG"), Conditional("DESIGN")]
        public static void IsInRange(Range<ModelID> inInnerBounds, Range<ModelID> inOuterBounds, string inArgumentName)
        {
            if (!inOuterBounds.ContainsRange(inInnerBounds))
            {
                if (string.IsNullOrEmpty(inArgumentName))
                {
                    inArgumentName = DefaultArgumentName;
                }
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorOutOfBounds,
                                                                    inArgumentName, inInnerBounds, inOuterBounds));
            }
        }

        /// <summary>
        /// Checks if the first given <see cref="ModelID"/> falls within at least one of the
        /// given collection of <see cref="Range{ModelID}"/>s, inclusive.
        /// </summary>
        /// <param name="inID">The identifier to test.</param>
        /// <param name="inBoundsCollection">The collection of ranges it must fall within.</param>
        /// <param name="inArgumentName">The name of the argument to use in error reporting.</param>
        /// <exception cref="ArgumentOutOfRangeException">When the identifier is not in any of the ranges.</exception>
        /// <exception cref="ArgumentNullException">When <paramref name="inBoundsCollection"/> is null.</exception>
        [Conditional("DEBUG"), Conditional("DESIGN")]
        public static void IsInRange(ModelID inID, IEnumerable<Range<ModelID>> inBoundsCollection, string inArgumentName)
        {
            IsNotNull(inBoundsCollection, nameof(inBoundsCollection));

            if (!inID.IsValidForRange(inBoundsCollection))
            {
                var allBounds = new System.Text.StringBuilder();
                foreach (var range in inBoundsCollection)
                {
                    allBounds.Append(range);
                    allBounds.Append(' ');
                }
                if (string.IsNullOrEmpty(inArgumentName))
                {
                    inArgumentName = DefaultArgumentName;
                }
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorOutOfBounds,
                                                                    inArgumentName, inID, allBounds));
            }
        }

        /// <summary>
        /// Checks if the given <see cref="Range{ModelID}"/> falls within at least one of the
        /// given collection of <see cref="Range{ModelID}"/>s, inclusive.
        /// </summary>
        /// <param name="inInnerBounds">The range to test.</param>
        /// <param name="inBoundsCollection">The collection of ranges it must fall within.</param>
        /// <param name="inArgumentName">The name of the argument to use in error reporting.</param>
        /// <exception cref="ArgumentOutOfRangeException">When the first range is not in the second range.</exception>
        [Conditional("DEBUG"), Conditional("DESIGN")]
        public static void IsInRange(Range<ModelID> inInnerBounds, IEnumerable<Range<ModelID>> inBoundsCollection, string inArgumentName)
        {
            if (!inBoundsCollection.ContainsRange(inInnerBounds))
            {
                if (string.IsNullOrEmpty(inArgumentName))
                {
                    inArgumentName = DefaultArgumentName;
                }
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorOutOfBounds,
                                                                    inArgumentName, inInnerBounds, inBoundsCollection));
            }
        }

        /// <summary>
        /// Verifies that the first given class is or is derived from the second given class.
        /// </summary>
        /// <param name="inArgumentName">The name of the argument to use in error reporting.</param>
        /// <typeparam name="TToCheck">The type to check.</typeparam>
        /// <typeparam name="TTarget">The type of which it must be a subtype.</typeparam>
        /// <exception cref="InvalidOperationException">
        /// When <typeparamref name="TToCheck"/> does not correspond to <typeparamref name="TTarget"/>.
        /// </exception>
        [Conditional("DEBUG"), Conditional("DESIGN")]
        public static void IsOfType<TToCheck, TTarget>(string inArgumentName = DefaultArgumentName)
        {
            if (!typeof(TToCheck).IsSubclassOf(typeof(TTarget))
                && typeof(TToCheck) != typeof(TTarget))
            {
                throw new InvalidCastException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorInvalidCast,
                                                             inArgumentName, typeof(TToCheck), typeof(TTarget)));
            }
        }

        /// <summary>
        /// Verifies that all of the given <see cref="ModelID"/>s fall within the given
        /// <see cref="Range{ModelID}"/>, inclusive.
        /// </summary>
        /// <param name="inEnumerable">The identifiers to test.</param>
        /// <param name="inBounds">The range they must fall within.</param>
        /// <param name="inArgumentName">The name of the argument to use in error reporting.</param>
        /// <exception cref="ArgumentOutOfRangeException">When the identifier is not in range.</exception>
        [Conditional("DEBUG"), Conditional("DESIGN")]
        public static void AreInRange(IEnumerable<ModelID> inEnumerable, Range<ModelID> inBounds, string inArgumentName)
        {
            foreach (var id in inEnumerable ?? Enumerable.Empty<ModelID>())
            {
                if (string.IsNullOrEmpty(inArgumentName))
                {
                    inArgumentName = DefaultArgumentName;
                }
                if (!id.IsValidForRange(inBounds))
                {
                    throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorOutOfBounds,
                                                                        inArgumentName, id, inBounds));
                }
            }
        }

        /// <summary>
        /// Verifies that all of the given <see cref="ModelID"/>s fall within the given 
        /// collection of <see cref="Range{ModelID}"/>s, inclusive.
        /// </summary>
        /// <param name="inEnumerable">The identifiers to test.</param>
        /// <param name="inBoundsCollection">The collection of ranges they must fall within.</param>
        /// <param name="inArgumentName">The name of the argument to use in error reporting.</param>
        /// <exception cref="ArgumentOutOfRangeException">When the identifier is not in range.</exception>
        [Conditional("DEBUG"), Conditional("DESIGN")]
        public static void AreInRange(IEnumerable<ModelID> inEnumerable, IEnumerable<Range<ModelID>> inBoundsCollection,
                                      string inArgumentName)
        {
            foreach (var id in inEnumerable ?? Enumerable.Empty<ModelID>())
            {
                if (!id.IsValidForRange(inBoundsCollection))
                {
                    if (string.IsNullOrEmpty(inArgumentName))
                    {
                        inArgumentName = DefaultArgumentName;
                    }
                    throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorOutOfBounds,
                                                                        inArgumentName, id, inBoundsCollection));
                }
            }
        }

        /// <summary>
        /// Verifies that the given <see cref="ModelID"/> is not <see cref="ModelID.None"/>.
        /// </summary>
        /// <param name="inID">The number to test.</param>
        /// <param name="inArgumentName">The name of the argument to use in error reporting.</param>
        /// <exception cref="ArgumentOutOfRangeException">When the number is -1 or less.</exception>
        [Conditional("DEBUG"), Conditional("DESIGN")]
        public static void IsNotNone(ModelID inID, string inArgumentName = DefaultArgumentName)
        {
            if (inID == ModelID.None)
            {
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorMustNotBeNone,
                                                                    inArgumentName));
            }
        }

        /// <summary>
        /// Verifies that the given number is zero or positive.
        /// </summary>
        /// <param name="inNumber">The number to test.</param>
        /// <param name="inArgumentName">The name of the argument to use in error reporting.</param>
        /// <exception cref="ArgumentOutOfRangeException">When the number is -1 or less.</exception>
        [Conditional("DEBUG"), Conditional("DESIGN")]
        public static void MustBeNonNegative(int inNumber, string inArgumentName = DefaultArgumentName)
        {
            if (inNumber < 0)
            {
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorMustBeNonNegative,
                                                                    inArgumentName));
            }
        }

        /// <summary>
        /// Verifies that the given number is positive.
        /// </summary>
        /// <param name="inNumber">The number to test.</param>
        /// <param name="inArgumentName">The name of the argument to use in error reporting.</param>
        /// <exception cref="ArgumentOutOfRangeException">When the number is zero or less.</exception>
        [Conditional("DEBUG"), Conditional("DESIGN")]
        public static void MustBePositive(int inNumber, string inArgumentName = DefaultArgumentName)
        {
            if (inNumber < 1)
            {
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorMustBePositive,
                                                                    inArgumentName));
            }
        }

        /// <summary>
        /// Verifies that the given <see cref="string"/> is not empty.
        /// </summary>
        /// <param name="inString">The string to test.</param>
        /// <param name="inArgumentName">The name of the argument to use in error reporting.</param>
        /// <exception cref="IndexOutOfRangeException">When <paramref name="inString"/> is null or empty.</exception>
        [Conditional("DEBUG"), Conditional("DESIGN")]
        public static void IsNotNullOrEmpty(string inString, string inArgumentName)
        {
            if (string.IsNullOrEmpty(inString))
            {
                if (string.IsNullOrEmpty(inArgumentName))
                {
                    inArgumentName = DefaultArgumentName;
                }
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorMustNotBeNullEmpty,
                                                                    inArgumentName));
            }
        }

        /// <summary>
        /// Verifies that the given <see cref="IEnumerable{TElement}"/> is not empty.
        /// </summary>
        /// <param name="inEnumerable">The collection to test.</param>
        /// <param name="inArgumentName">The name of the argument to use in error reporting.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="inEnumerable"/> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">When <paramref name="inEnumerable"/> is empty.</exception>
        [Conditional("DEBUG"), Conditional("DESIGN")]
        public static void IsNotNullOrEmpty<TElement>(IEnumerable<TElement> inEnumerable, string inArgumentName)
        {
            if (null == inEnumerable)
            {
                if (string.IsNullOrEmpty(inArgumentName))
                {
                    inArgumentName = DefaultArgumentName;
                }
                throw new ArgumentNullException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorMustNotBeNull,
                                                              inArgumentName));
            }
            else if (!inEnumerable.Any())
            {
                if (string.IsNullOrEmpty(inArgumentName))
                {
                    inArgumentName = DefaultArgumentName;
                }
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorMustNotBeEmpty,
                                                                    inArgumentName));
            }
        }

        /// <summary>
        /// Verifies that the given reference is not <c>null</c>.
        /// </summary>
        /// <param name="inReference">The reference to test.</param>
        /// <param name="inArgumentName">The name of the argument to use in error reporting.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="inReference"/> is null.</exception>
        [Conditional("DEBUG"), Conditional("DESIGN")]
        public static void IsNotNull(object inReference, string inArgumentName = DefaultArgumentName)
        {
            if (null == inReference)
            {
                throw new ArgumentNullException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorMustNotBeNull,
                                                              inArgumentName));
            }
        }
    }
}
