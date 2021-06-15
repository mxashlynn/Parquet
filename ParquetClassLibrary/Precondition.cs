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
        /// <param name="integerToTest">The integer to test.</param>
        /// <param name="bounds">The range it must fall within.</param>
        /// <param name="argumentName">The name of the argument to use in error reporting.</param>
        [Conditional("DEBUG")]
        public static void IsInRange(int integerToTest, Range<int> bounds, string argumentName)
        {
            if (!bounds.ContainsValue(integerToTest))
            {
                if (string.IsNullOrEmpty(argumentName))
                {
                    argumentName = DefaultArgumentName;
                }
                Logger.Log(LogLevel.Debug, string.Format(CultureInfo.CurrentCulture, Resources.ErrorOutOfBounds,
                                                         argumentName, integerToTest, bounds));
            }
        }

        /// <summary>
        /// Checks if the given <see cref="ModelID"/> falls within the given <see cref="Range{ModelID}"/>, inclusive.
        /// </summary>
        /// <param name="id">The identifier to test.</param>
        /// <param name="bounds">The range it must fall within.</param>
        /// <param name="argumentName">The name of the argument to use in error reporting.</param>
        [Conditional("DEBUG")]
        public static void IsInRange(ModelID id, Range<ModelID> bounds, string argumentName)
        {
            if (!id.IsValidForRange(bounds))
            {
                if (string.IsNullOrEmpty(argumentName))
                {
                    argumentName = DefaultArgumentName;
                }
                Logger.Log(LogLevel.Debug, string.Format(CultureInfo.CurrentCulture, Resources.ErrorOutOfBounds,
                                                         argumentName, id, bounds));
            }
        }

        /// <summary>
        /// Checks if the first given <see cref="Range{ModelID}"/> falls within the second given <see cref="Range{ModelID}"/>, inclusive.
        /// </summary>
        /// <param name="innerBounds">The range to test.</param>
        /// <param name="outerBounds">The range it must fall within.</param>
        /// <param name="argumentName">The name of the argument to use in error reporting.</param>
        [Conditional("DEBUG")]
        public static void IsInRange(Range<ModelID> innerBounds, Range<ModelID> outerBounds, string argumentName)
        {
            if (!outerBounds.ContainsRange(innerBounds))
            {
                if (string.IsNullOrEmpty(argumentName))
                {
                    argumentName = DefaultArgumentName;
                }
                Logger.Log(LogLevel.Debug, string.Format(CultureInfo.CurrentCulture, Resources.ErrorOutOfBounds,
                                                         argumentName, innerBounds, outerBounds));
            }
        }

        /// <summary>
        /// Checks if the first given <see cref="ModelID"/> falls within at least one of the
        /// given collection of <see cref="Range{ModelID}"/>s, inclusive.
        /// </summary>
        /// <param name="id">The identifier to test.</param>
        /// <param name="boundsCollection">The collection of ranges it must fall within.</param>
        /// <param name="argumentName">The name of the argument to use in error reporting.</param>
        [Conditional("DEBUG")]
        public static void IsInRange(ModelID id, IEnumerable<Range<ModelID>> boundsCollection, string argumentName)
        {
            IsNotNull(boundsCollection, nameof(boundsCollection));

            if (!id.IsValidForRange(boundsCollection))
            {
                var allBounds = new System.Text.StringBuilder();
                foreach (var range in boundsCollection)
                {
                    allBounds.Append(range);
                    allBounds.Append(' ');
                }
                if (string.IsNullOrEmpty(argumentName))
                {
                    argumentName = DefaultArgumentName;
                }
                Logger.Log(LogLevel.Debug, string.Format(CultureInfo.CurrentCulture, Resources.ErrorOutOfBounds,
                                                         argumentName, id, allBounds));
            }
        }

        /// <summary>
        /// Checks if the given <see cref="Range{ModelID}"/> falls within at least one of the
        /// given collection of <see cref="Range{ModelID}"/>s, inclusive.
        /// </summary>
        /// <param name="innerBounds">The range to test.</param>
        /// <param name="boundsCollection">The collection of ranges it must fall within.</param>
        /// <param name="argumentName">The name of the argument to use in error reporting.</param>
        [Conditional("DEBUG")]
        public static void IsInRange(Range<ModelID> innerBounds, IEnumerable<Range<ModelID>> boundsCollection, string argumentName)
        {
            if (!boundsCollection.ContainsRange(innerBounds))
            {
                if (string.IsNullOrEmpty(argumentName))
                {
                    argumentName = DefaultArgumentName;
                }
                Logger.Log(LogLevel.Debug, string.Format(CultureInfo.CurrentCulture, Resources.ErrorOutOfBounds,
                                                         argumentName, innerBounds, boundsCollection));
            }
        }

        /// <summary>
        /// Verifies that the first given class is or is derived from the second given class.
        /// </summary>
        /// <param name="argumentName">The name of the argument to use in error reporting.</param>
        /// <typeparam name="TToCheck">The type to check.</typeparam>
        /// <typeparam name="TTarget">The type of which it must be a subtype.</typeparam>
        [Conditional("DEBUG")]
        public static void IsOfType<TToCheck, TTarget>(string argumentName = DefaultArgumentName)
        {
            if (!typeof(TToCheck).IsSubclassOf(typeof(TTarget))
                && typeof(TToCheck) != typeof(TTarget))
            {
                Logger.Log(LogLevel.Debug, string.Format(CultureInfo.CurrentCulture, Resources.ErrorInvalidCast,
                                                         argumentName, typeof(TToCheck), typeof(TTarget)));
            }
        }

        /// <summary>
        /// Verifies that all of the given <see cref="ModelID"/>s fall within the given
        /// <see cref="Range{ModelID}"/>, inclusive.
        /// </summary>
        /// <param name="enumerable">The identifiers to test.</param>
        /// <param name="bounds">The range they must fall within.</param>
        /// <param name="argumentName">The name of the argument to use in error reporting.</param>
        [Conditional("DEBUG")]
        public static void AreInRange(IEnumerable<ModelID> enumerable, Range<ModelID> bounds, string argumentName)
        {
            foreach (var id in enumerable ?? Enumerable.Empty<ModelID>())
            {
                if (string.IsNullOrEmpty(argumentName))
                {
                    argumentName = DefaultArgumentName;
                }
                if (!id.IsValidForRange(bounds))
                {
                    Logger.Log(LogLevel.Debug, string.Format(CultureInfo.CurrentCulture, Resources.ErrorOutOfBounds,
                                                             argumentName, id, bounds));
                }
            }
        }

        /// <summary>
        /// Verifies that all of the given <see cref="ModelID"/>s fall within the given 
        /// collection of <see cref="Range{ModelID}"/>s, inclusive.
        /// </summary>
        /// <param name="enumerable">The identifiers to test.</param>
        /// <param name="boundsCollection">The collection of ranges they must fall within.</param>
        /// <param name="argumentName">The name of the argument to use in error reporting.</param>
        [Conditional("DEBUG")]
        public static void AreInRange(IEnumerable<ModelID> enumerable, IEnumerable<Range<ModelID>> boundsCollection,
                                      string argumentName)
        {
            foreach (var id in enumerable ?? Enumerable.Empty<ModelID>())
            {
                if (!id.IsValidForRange(boundsCollection))
                {
                    if (string.IsNullOrEmpty(argumentName))
                    {
                        argumentName = DefaultArgumentName;
                    }
                    Logger.Log(LogLevel.Debug, string.Format(CultureInfo.CurrentCulture, Resources.ErrorOutOfBounds,
                                                             argumentName, id, boundsCollection));
                }
            }
        }

        /// <summary>
        /// Verifies that the given <see cref="ModelID"/> is not <see cref="ModelID.None"/>.
        /// </summary>
        /// <param name="id">The number to test.</param>
        /// <param name="argumentName">The name of the argument to use in error reporting.</param>
        [Conditional("DEBUG")]
        public static void IsNotNone(ModelID id, string argumentName = DefaultArgumentName)
        {
            if (id == ModelID.None)
            {
                Logger.Log(LogLevel.Debug, string.Format(CultureInfo.CurrentCulture, Resources.ErrorMustNotBeNone,
                                                         argumentName));
            }
        }

        /// <summary>
        /// Verifies that the given number is zero or positive.
        /// </summary>
        /// <param name="number">The number to test.</param>
        /// <param name="argumentName">The name of the argument to use in error reporting.</param>
        [Conditional("DEBUG")]
        public static void MustBeNonNegative(int number, string argumentName = DefaultArgumentName)
        {
            if (number < 0)
            {
                Logger.Log(LogLevel.Debug, string.Format(CultureInfo.CurrentCulture, Resources.ErrorMustBeNonNegative,
                                                         argumentName));
            }
        }

        /// <summary>
        /// Verifies that the given number is positive.
        /// </summary>
        /// <param name="number">The number to test.</param>
        /// <param name="argumentName">The name of the argument to use in error reporting.</param>
        [Conditional("DEBUG")]
        public static void MustBePositive(int number, string argumentName = DefaultArgumentName)
        {
            if (number < 1)
            {
                Logger.Log(LogLevel.Debug, string.Format(CultureInfo.CurrentCulture, Resources.ErrorMustBePositive,
                                                         argumentName));
            }
        }

        /// <summary>
        /// Verifies that the given <see cref="string"/> is not empty.
        /// </summary>
        /// <param name="stringToTest">The string to test.</param>
        /// <param name="argumentName">The name of the argument to use in error reporting.</param>
        [Conditional("DEBUG")]
        public static void IsNotNullOrEmpty(string stringToTest, string argumentName)
        {
            if (string.IsNullOrEmpty(stringToTest))
            {
                if (string.IsNullOrEmpty(argumentName))
                {
                    argumentName = DefaultArgumentName;
                }
                Logger.Log(LogLevel.Debug, string.Format(CultureInfo.CurrentCulture, Resources.ErrorMustNotBeNullEmpty,
                                                         argumentName));
            }
        }

        /// <summary>
        /// Verifies that the given <see cref="IEnumerable{TElement}"/> is not empty.
        /// </summary>
        /// <param name="enumerable">The collection to test.</param>
        /// <param name="argumentName">The name of the argument to use in error reporting.</param>
        [Conditional("DEBUG")]
        public static void IsNotNullOrEmpty<TElement>(IEnumerable<TElement> enumerable, string argumentName)
        {
            if (enumerable is null)
            {
                if (string.IsNullOrEmpty(argumentName))
                {
                    argumentName = DefaultArgumentName;
                }
                Logger.Log(LogLevel.Debug, string.Format(CultureInfo.CurrentCulture, Resources.ErrorMustNotBeNull,
                                                         argumentName));
            }
            else if (!enumerable.Any())
            {
                if (string.IsNullOrEmpty(argumentName))
                {
                    argumentName = DefaultArgumentName;
                }
                Logger.Log(LogLevel.Debug, string.Format(CultureInfo.CurrentCulture, Resources.ErrorMustNotBeEmpty,
                                                         argumentName));
            }
        }

        /// <summary>
        /// Verifies that the given reference is not <c>null</c>.
        /// </summary>
        /// <param name="reference">The reference to test.</param>
        /// <param name="argumentName">The name of the argument to use in error reporting.</param>
        [Conditional("DEBUG")]
        public static void IsNotNull(object reference, string argumentName = DefaultArgumentName)
        {
            if (reference is null)
            {
                Logger.Log(LogLevel.Debug, string.Format(CultureInfo.CurrentCulture, Resources.ErrorMustNotBeNull,
                                                         argumentName));
            }
        }
    }
}
