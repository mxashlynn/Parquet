using System;

namespace ParquetClassLibrary.Sandbox
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
    /// Convenience extension methods for concise coding when working with ParquetSelection instances.
    /// </summary>
    internal static class ParquetSelectionExtensions
    {
        /// <summary>
        /// Sets the given flag in the specified variable.
        /// </summary>
        /// <param name="in_enumVariable">The enum variable under consideration.</param>
        /// <param name="in_flagToTest">The flag to set.</param>
        /// <returns>The variable with the flag set.</returns>
        public static ParquetMask Set(this ref ParquetMask in_enumVariable, ParquetMask in_flagToTest)
        {
            return in_enumVariable = in_enumVariable | in_flagToTest;
        }

        /// <summary>
        /// Clears the given flag in the specified variable.
        /// </summary>
        /// <param name="in_enumVariable">The enum variable under consideration.</param>
        /// <param name="in_flagToTest">The flag to clear.</param>
        /// <returns>The variable with the flag cleared.</returns>
        public static ParquetMask Clear(this ref ParquetMask in_enumVariable, ParquetMask in_flagToTest)
        {
            return in_enumVariable = in_enumVariable & ~in_flagToTest;
        }

        /// <summary>
        /// Checks if the given flag is set.
        /// </summary>
        /// <param name="in_enumVariable">The enum variable under consideration.</param>
        /// <param name="in_flagToTest">The flag to test.</param>
        /// <returns><c>true</c>, if at least this flag is set, <c>false</c> otherwise.</returns>
        public static bool IsSet(this ParquetMask in_enumVariable, ParquetMask in_flagToTest)
        {
            return (in_enumVariable & in_flagToTest) == in_flagToTest;
        }

        /// <summary>
        /// Checks if the given flag is unset.
        /// </summary>
        /// <param name="in_enumVariable">The enum variable under consideration.</param>
        /// <param name="in_flagToTest">The flag to test.</param>
        /// <returns><c>true</c>, if at least this flag is unset, <c>false</c> otherwise.</returns>
        public static bool IsNotSet(this ParquetMask in_enumVariable, ParquetMask in_flagToTest)
        {
            return (in_enumVariable & ~in_flagToTest) == ParquetMask.None;
        }

        /// <summary>
        /// Sets or clears the given flag in the specified variable, depending on the given boolean.
        /// </summary>
        /// <param name="in_enumVariable">The enum variable under consideration.</param>
        /// <param name="in_flagToTest">The flag to set or clear.</param>
        /// <param name="in_state">If <c>true</c>, the flag will be set; otherwise it will be cleared.</param>
        /// <returns>The variable with the flag modified.</returns>
        public static ParquetMask SetTo(this ref ParquetMask in_enumVariable, ParquetMask in_flagToTest, bool in_state)
        {
            return in_enumVariable = in_state
                ? in_enumVariable.Set(in_flagToTest)
                : in_enumVariable.Clear(in_flagToTest);
        }
    }
}
