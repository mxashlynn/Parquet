using System;

namespace ParquetClassLibrary.Sandbox
{
    /// <summary>
    /// Indicates the requirements for a player character to safely enter a <see cref="Biome"/>.
    /// </summary>
    [Flags]
    public enum BiomeKey
    {
        None = 0,
        Knapsack,
        Sunscreen,
        Boots,
        Canteen,
        BugSpray,
        WarmGear,
        Lantern,
        Rope,
        ClimbingKit,
        GasMask,
        Charm,
        PearlyFeather,
        CharredMask,
    }

    /// <summary>
    /// Convenience extension methods for concise coding when working with <see cref="BiomeKey"/> instances.
    /// </summary>
    internal static class BiomeKeyExtensions
    {
        /// <summary>
        /// Sets the given flag in the specified variable.
        /// </summary>
        /// <param name="in_enumVariable">The enum variable under consideration.</param>
        /// <param name="in_flagToTest">The flag to set.</param>
        /// <returns>The variable with the flag set.</returns>
        public static BiomeKey Set(this ref BiomeKey in_enumVariable, BiomeKey in_flagToTest)
        {
            return in_enumVariable = in_enumVariable | in_flagToTest;
        }

        /// <summary>
        /// Clears the given flag in the specified variable.
        /// </summary>
        /// <param name="in_enumVariable">The enum variable under consideration.</param>
        /// <param name="in_flagToTest">The flag to clear.</param>
        /// <returns>The variable with the flag cleared.</returns>
        public static BiomeKey Clear(this ref BiomeKey in_enumVariable, BiomeKey in_flagToTest)
        {
            return in_enumVariable = in_enumVariable & ~in_flagToTest;
        }

        /// <summary>
        /// Checks if the given flag is set.
        /// </summary>
        /// <param name="in_enumVariable">The enum variable under consideration.</param>
        /// <param name="in_flagToTest">The flag to test.</param>
        /// <returns><c>true</c>, if at least this flag is set, <c>false</c> otherwise.</returns>
        public static bool IsSet(this BiomeKey in_enumVariable, BiomeKey in_flagToTest)
        {
            return (in_enumVariable & in_flagToTest) == in_flagToTest;
        }

        /// <summary>
        /// Checks if the given flag is unset.
        /// </summary>
        /// <param name="in_enumVariable">The enum variable under consideration.</param>
        /// <param name="in_flagToTest">The flag to test.</param>
        /// <returns><c>true</c>, if at least this flag is unset, <c>false</c> otherwise.</returns>
        public static bool IsNotSet(this BiomeKey in_enumVariable, BiomeKey in_flagToTest)
        {
            return (in_enumVariable & ~in_flagToTest) == BiomeKey.None;
        }

        /// <summary>
        /// Sets or clears the given flag in the specified variable, depending on the given boolean.
        /// </summary>
        /// <param name="in_enumVariable">The enum variable under consideration.</param>
        /// <param name="in_flagToTest">The flag to set or clear.</param>
        /// <param name="in_state">If <c>true</c>, the flag will be set; otherwise it will be cleared.</param>
        /// <returns>The variable with the flag modified.</returns>
        public static BiomeKey SetTo(this ref BiomeKey in_enumVariable, BiomeKey in_flagToTest, bool in_state)
        {
            return in_enumVariable = in_state
                ? in_enumVariable.Set(in_flagToTest)
                : in_enumVariable.Clear(in_flagToTest);
        }
    }
}
