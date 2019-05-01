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
        /// <summary>Text to use when no argument name is provided.</summary>
        private const string DefaultArgumentName = "Argument";

        // TODO: XML comment these methods.
        // TODO: Ensure that this is the only file that documents what it throws.


        internal static void IsInRange(EntityID in_id, Range<EntityID> in_bounds,
                                       string in_argumentName = DefaultArgumentName)
        {
            if (!in_id.IsValidForRange(in_bounds))
            {
                throw new ArgumentOutOfRangeException($"{in_argumentName}: {in_id} is not within {in_bounds}.");
            }
        }

        internal static void IsInRange(Range<EntityID> in_innerBounds, Range<EntityID> in_outerBounds,
                                       string in_argumentName = DefaultArgumentName)
        {
            if (!in_outerBounds.ContainsRange(in_innerBounds))
            {
                throw new ArgumentOutOfRangeException(
                    $"{in_argumentName}: {in_innerBounds} is not within {in_outerBounds}.");
            }
        }

        internal static void IsInRange(EntityID in_id, List<Range<EntityID>> in_boundsCollection,
                                       string in_argumentName = DefaultArgumentName)
        {
            if (!in_id.IsValidForRange(in_boundsCollection))
            {
                throw new ArgumentOutOfRangeException(
                    $"{in_argumentName}: {in_id} is not within {in_boundsCollection}.");
            }
        }

        internal static void IsInRange(Range<EntityID> in_innerBounds, List<Range<EntityID>> in_boundsCollection,
                                       string in_argumentName = DefaultArgumentName)
        {
            if (!in_boundsCollection.ContainsRange(in_innerBounds))
            {
                throw new ArgumentOutOfRangeException(
                    $"{in_argumentName}: {in_innerBounds} is not within {in_boundsCollection}.");
            }
        }

        internal static void AreInRange(IEnumerable<EntityID> in_enumerable, List<Range<EntityID>> in_bounds,
                                        string in_argumentName = DefaultArgumentName)
        {
            foreach (var id in in_enumerable ?? Enumerable.Empty<EntityID>())
            {
                if (!id.IsValidForRange(in_bounds))
                {
                    throw new ArgumentOutOfRangeException(
                        $"{in_argumentName}: {id} is not within {in_bounds}.");
                }
            }
        }

        internal static void AreInRange(IEnumerable<EntityID> in_enumerable, Range<EntityID> in_bounds,
                                        string in_argumentName = DefaultArgumentName)
        {
            foreach (var id in in_enumerable ?? Enumerable.Empty<EntityID>())
            {
                if (!id.IsValidForRange(in_bounds))
                {
                    throw new ArgumentOutOfRangeException(
                        $"{in_argumentName}: {id} is not within {in_bounds}.");
                }
            }
        }

        internal static void IsNotEmpty(string in_string, string in_argumentName = DefaultArgumentName)
        {
            if (string.IsNullOrEmpty(in_string))
            {
                throw new ArgumentNullException($"{in_argumentName} is null or empty.");
            }
        }

        internal static void IsNotEmpty<T>(IEnumerable<T> in_enumerable, string in_argumentName = DefaultArgumentName)
        {
            if (!in_enumerable?.Any() ?? false)
            {
                throw new IndexOutOfRangeException($"{in_argumentName} is empty.");
            }
        }

        internal static void IsNotNull(object in_reference, string in_argumentName = DefaultArgumentName)
        {
            if (null == in_reference)
            {
                throw new ArgumentNullException($"{in_argumentName} is null.");
            }
        }
    }
}
