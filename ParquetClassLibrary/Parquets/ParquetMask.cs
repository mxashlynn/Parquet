using System;

namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// Models which, if any, parquet layers have been selected (for instance in the map editor).
    /// </summary>
    [Flags]
    internal enum ParquetMask
    {
        None = 0,
        Floor = 1,
        Block = 2,
        Furnishing = 4,
        Collectible = 8,
    }

    /// <summary>
    /// Convenience extension methods for concise coding when working with <see cref="ParquetMask"/> instances.
    /// </summary>
    internal static class ParquetSelectionExtensions
    {
        /// <summary>
        /// Sets the given flag in the specified variable.
        /// </summary>
        /// <param name="refEnumVariable">The enum variable under consideration.</param>
        /// <param name="inFlagToSet">The flag to set.</param>
        /// <returns>The variable with the flag set.</returns>
        public static ParquetMask Set(this ref ParquetMask refEnumVariable, ParquetMask inFlagToSet)
            => refEnumVariable |= inFlagToSet;

        /// <summary>
        /// Clears the given flag in the specified variable.
        /// </summary>
        /// <param name="refEnumVariable">The enum variable under consideration.</param>
        /// <param name="inFlagToClear">The flag to clear.</param>
        /// <returns>The variable with the flag cleared.</returns>
        public static ParquetMask Clear(this ref ParquetMask refEnumVariable, ParquetMask inFlagToClear)
            => refEnumVariable &= ~inFlagToClear;

        /// <summary>
        /// Checks if the given flag is set.
        /// </summary>
        /// <param name="inEnumVariable">The enum variable under consideration.</param>
        /// <param name="inFlagToTest">The flag to test.</param>
        /// <returns><c>true</c>, if at least this flag is set, <c>false</c> otherwise.</returns>
        public static bool IsSet(this ParquetMask inEnumVariable, ParquetMask inFlagToTest)
            => (inEnumVariable & inFlagToTest) == inFlagToTest;

        /// <summary>
        /// Sets or clears the given flag in the specified variable, depending on the given boolean.
        /// </summary>
        /// <param name="refEnumVariable">The enum variable under consideration.</param>
        /// <param name="inFlagToTest">The flag to set or clear.</param>
        /// <param name="inState">If <c>true</c>, the flag will be set; otherwise it will be cleared.</param>
        /// <returns>The variable with the flag modified.</returns>
        public static ParquetMask SetTo(this ref ParquetMask refEnumVariable, ParquetMask inFlagToTest, bool inState)
            => inState
                ? refEnumVariable.Set(inFlagToTest)
                : refEnumVariable.Clear(inFlagToTest);
    }
}
