using System;
using System.Collections.Generic;
using System.Linq;

namespace ParquetClassLibrary.Utilities
{
    /// <summary>
    /// Provides constructors and initialization routines with concise arugment boilerplate.
    /// </summary>
    public static class Precondition
    {
        #region Class Defaults
        /// <summary>Text to use when no argument name is provided.</summary>
        private const string DefaultArgumentName = "Argument";
        #endregion

        /// <summary>
        /// Checks if the given <see langword="int"/> falls within the given <see cref="Range{int}"/>, inclusive.
        /// </summary>
        /// <param name="inInt">The integer to test.</param>
        /// <param name="inBounds">The range it must fall within.</param>
        /// <param name="inArgumentName">The name of the argument to use in error reporting.</param>
        /// <exception cref="ArgumentOutOfRangeException">When the integer is not in range.</exception>
        public static void IsInRange(int inInt, Range<int> inBounds,
                                     string inArgumentName = DefaultArgumentName)
        {
            if (!inBounds.ContainsValue(inInt))
            {
                throw new ArgumentOutOfRangeException($"{inArgumentName}: {inInt} is not within {inBounds}.");
            }
        }

        /// <summary>
        /// Checks if the given <see cref="EntityID"/> falls within the given <see cref="Range{T}"/>, inclusive.
        /// </summary>
        /// <param name="inID">The identifier to test.</param>
        /// <param name="inBounds">The range it must fall within.</param>
        /// <param name="inArgumentName">The name of the argument to use in error reporting.</param>
        /// <exception cref="ArgumentOutOfRangeException">When the identifier is not in range.</exception>
        public static void IsInRange(EntityID inID, Range<EntityID> inBounds,
                                     string inArgumentName = DefaultArgumentName)
        {
            if (!inID.IsValidForRange(inBounds))
            {
                throw new ArgumentOutOfRangeException($"{inArgumentName}: {inID} is not within {inBounds}.");
            }
        }

        /// <summary>
        /// Checks if the first given <see cref="Range{T}"/> falls within the second given <see cref="Range{T}"/>, inclusive.
        /// </summary>
        /// <param name="inInnerBounds">The range to test.</param>
        /// <param name="inOuterBounds">The range it must fall within.</param>
        /// <param name="inArgumentName">The name of the argument to use in error reporting.</param>
        /// <exception cref="ArgumentOutOfRangeException">When the first range is not in the second range.</exception>
        public static void IsInRange(Range<EntityID> inInnerBounds, Range<EntityID> inOuterBounds,
                                     string inArgumentName = DefaultArgumentName)
        {
            if (!inOuterBounds.ContainsRange(inInnerBounds))
            {
                throw new ArgumentOutOfRangeException(
                    $"{inArgumentName}: {inInnerBounds} is not within {inOuterBounds}.");
            }
        }

        /// <summary>
        /// Checks if the first given <see cref="EntityID"/> falls within at least one of the
        /// given collection of <see cref="Range{T}"/>s, inclusive.
        /// </summary>
        /// <param name="inID">The identifier to test.</param>
        /// <param name="inBoundsCollection">The collection of ranges it must fall within.</param>
        /// <param name="inArgumentName">The name of the argument to use in error reporting.</param>
        /// <exception cref="ArgumentOutOfRangeException">When the identifier is not in any of the ranges.</exception>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="inBoundsCollection"/> is null.</exception>
        public static void IsInRange(EntityID inID, List<Range<EntityID>> inBoundsCollection,
                                     string inArgumentName = DefaultArgumentName)
        {
            IsNotNull(inBoundsCollection, nameof(inBoundsCollection));

            if (!inID.IsValidForRange(inBoundsCollection))
            {
                var allBounds = "";
                foreach (var range in inBoundsCollection)
                {
                    allBounds += range + " ";
                }
                throw new ArgumentOutOfRangeException(
                    $"{inArgumentName}: {inID} is not within {allBounds}.");
            }
        }

        /// <summary>
        /// Checks if the given <see cref="Range{T}"/> falls within at least one of the
        /// given collection of <see cref="Range{T}"/>s, inclusive.
        /// </summary>
        /// <param name="inInnerBounds">The range to test.</param>
        /// <param name="inBoundsCollection">The collection of ranges it must fall within.</param>
        /// <param name="inArgumentName">The name of the argument to use in error reporting.</param>
        /// <exception cref="ArgumentOutOfRangeException">When the first range is not in the second range.</exception>
        public static void IsInRange(Range<EntityID> inInnerBounds, List<Range<EntityID>> inBoundsCollection,
                                     string inArgumentName = DefaultArgumentName)
        {
            if (!inBoundsCollection.ContainsRange(inInnerBounds))
            {
                throw new ArgumentOutOfRangeException(
                    $"{inArgumentName}: {inInnerBounds} is not within {inBoundsCollection}.");
            }
        }

        /// <summary>
        /// Verifies that the first given <see langword="class"/> is or is derived from
        /// the second given <see langword="class"/>.
        /// </summary>
        /// <param name="inArgumentName">The name of the argument to use in error reporting.</param>
        /// <typeparam name="TToCheck">The type to check.</typeparam>
        /// <typeparam name="TTarget">The type of which it must be a subtype.</typeparam>
        /// <exception cref="System.InvalidOperationException">
        /// Thrown when <typeparamref name="TToCheck"/> does not correspond to <typeparamref name="TTarget"/>.
        /// </exception>
        public static void IsOfType<TToCheck, TTarget>(string inArgumentName = DefaultArgumentName)
        {
            if (!typeof(TToCheck).IsSubclassOf(typeof(TTarget))
                && typeof(TToCheck) != typeof(TTarget))
            {
                throw new InvalidCastException(
                    $"{inArgumentName} is of type {typeof(TToCheck)} but must be of type {typeof(TTarget)}.");
            }
        }

        /// <summary>
        /// Verifies that all of the given <see cref="EntityID"/>s fall within the given
        /// <see cref="Range{T}"/>, inclusive.
        /// </summary>
        /// <param name="inEnumerable">The identifiers to test.</param>
        /// <param name="inBounds">The range they must fall within.</param>
        /// <param name="inArgumentName">The name of the argument to use in error reporting.</param>
        /// <exception cref="ArgumentOutOfRangeException">When the identifier is not in range.</exception>
        public static void AreInRange(IEnumerable<EntityID> inEnumerable, Range<EntityID> inBounds,
                                      string inArgumentName = DefaultArgumentName)
        {
            foreach (var id in inEnumerable ?? Enumerable.Empty<EntityID>())
            {
                if (!id.IsValidForRange(inBounds))
                {
                    throw new ArgumentOutOfRangeException($"{inArgumentName}: {id} is not within {inBounds}.");
                }
            }
        }

        /// <summary>
        /// Verifies that all of the given <see cref="EntityID"/>s fall within the given 
        /// collection of <see cref="Range{T}"/>s, inclusive.
        /// </summary>
        /// <param name="inEnumerable">The identifiers to test.</param>
        /// <param name="inBoundsCollection">The collection of ranges they must fall within.</param>
        /// <param name="inArgumentName">The name of the argument to use in error reporting.</param>
        /// <exception cref="ArgumentOutOfRangeException">When the identifier is not in range.</exception>
        public static void AreInRange(IEnumerable<EntityID> inEnumerable, List<Range<EntityID>> inBoundsCollection,
                                      string inArgumentName = DefaultArgumentName)
        {
            foreach (var id in inEnumerable ?? Enumerable.Empty<EntityID>())
            {
                if (!id.IsValidForRange(inBoundsCollection))
                {
                    throw new ArgumentOutOfRangeException($"{inArgumentName}: {id} is not within {inBoundsCollection}.");
                }
            }
        }
        
        /// <summary>
        /// Verifies that the given <see cref="EntityID"/> is not <see cref="EntityID.None"/>.
        /// </summary>
        /// <param name="inID">The number to test.</param>
        /// <param name="inArgumentName">The name of the argument to use in error reporting.</param>
        /// <exception cref="ArgumentOutOfRangeException">When the number is -1 or less.</exception>
        public static void IsNotNone(EntityID inID, string inArgumentName = DefaultArgumentName)
        {
            if (inID == EntityID.None)
            {
                throw new ArgumentOutOfRangeException($"{inArgumentName} cannot be None.");
            }
        }

        /// <summary>
        /// Verifies that the given number is zero or positive.
        /// </summary>
        /// <param name="inNumber">The number to test.</param>
        /// <param name="inArgumentName">The name of the argument to use in error reporting.</param>
        /// <exception cref="ArgumentOutOfRangeException">When the number is -1 or less.</exception>
        public static void MustBeNonNegative(int inNumber, string inArgumentName = DefaultArgumentName)
        {
            if (inNumber < 0)
            {
                throw new ArgumentOutOfRangeException($"{inArgumentName} must be a non-negative number.");
            }
        }

        /// <summary>
        /// Verifies that the given number is positive.
        /// </summary>
        /// <param name="inNumber">The number to test.</param>
        /// <param name="inArgumentName">The name of the argument to use in error reporting.</param>
        /// <exception cref="ArgumentOutOfRangeException">When the number is zero or less.</exception>
        public static void MustBePositive(int inNumber, string inArgumentName = DefaultArgumentName)
        {
            if (inNumber < 1)
            {
                throw new ArgumentOutOfRangeException($"{inArgumentName} must be a positive number.");
            }
        }

        /// <summary>
        /// Verifies that the given <see langword="string"/> is not empty.
        /// </summary>
        /// <param name="inString">The string to test.</param>
        /// <param name="inArgumentName">The name of the argument to use in error reporting.</param>
        /// <exception cref="IndexOutOfRangeException">When <paramref name="inString"/> is null or empty.</exception>
        public static void IsNotNullOrEmpty(string inString, string inArgumentName = DefaultArgumentName)
        {
            if (string.IsNullOrEmpty(inString))
            {
                throw new IndexOutOfRangeException($"{inArgumentName} is null or empty.");
            }
        }

        /// <summary>
        /// Verifies that the given <see cref="IEnumerable{T}"/> is not empty.
        /// </summary>
        /// <param name="inEnumerable">The collection to test.</param>
        /// <param name="inArgumentName">The name of the argument to use in error reporting.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="inEnumerable"/> is null.</exception>
        /// <exception cref="IndexOutOfRangeException">Thrown when <paramref name="inEnumerable"/> is empty.</exception>
        public static void IsNotNullOrEmpty<T>(IEnumerable<T> inEnumerable, string inArgumentName = DefaultArgumentName)
        {
            if (null == inEnumerable)
            {
                throw new ArgumentNullException($"{inArgumentName} is null.");
            }
            else if (!inEnumerable.Any())
            {
                throw new IndexOutOfRangeException($"{inArgumentName} is empty.");
            }
        }

        /// <summary>
        /// Verifies that the given reference is not <c>null</c>.
        /// </summary>
        /// <param name="inReference">The reference to test.</param>
        /// <param name="inArgumentName">The name of the argument to use in error reporting.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="inReference"/> is null.</exception>
        public static void IsNotNull(object inReference, string inArgumentName = DefaultArgumentName)
        {
            if (null == inReference)
            {
                throw new ArgumentNullException($"{inArgumentName} is null.");
            }
        }
    }
}
