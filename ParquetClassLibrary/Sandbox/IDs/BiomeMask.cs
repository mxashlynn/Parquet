using System;

namespace ParquetClassLibrary.Sandbox.IDs
{
    /// <summary>
    /// Indicates that a parquet contributes to the formation of one or more
    /// <see cref="T:ParquetClassLibrary.Sandbox.Biome"/>.
    /// </summary>
    [Flags]
    public enum BiomeMask
    {
        None = 0,
        Mountainous,
        Cavernous,
        Deserted,
        Forested,
        Heavenly,
        Infernal,
        Ruinous,
        Coastal,
        Swampy,
        Frozen,
        Volcanic,
    }

    /// <summary>
    /// Convenience extension methods for concise coding when working with <see cref="BiomeMask"/> instances.
    /// </summary>
    internal static class BiomeMaskSelectionExtensions
    {
        /// <summary>Checks if the Deserted flag is set.</summary>
        /// <returns><c>true</c>, if the Deserted flag is set, <c>false</c> otherwise.</returns>
        public static bool IsDeserted(this BiomeMask in_enumVariable)
            => in_enumVariable.HasFlag(BiomeMask.Deserted);

        /// <summary>Checks if the Forested flag is set.</summary>
        /// <returns><c>true</c>, if the Forested flag is set, <c>false</c> otherwise.</returns>
        public static bool IsForested(this BiomeMask in_enumVariable)
            => in_enumVariable.HasFlag(BiomeMask.Forested);

        /// <summary>Checks if the Heavenly flag is set.</summary>
        /// <returns><c>true</c>, if the Heavenly flag is set, <c>false</c> otherwise.</returns>
        public static bool IsHeavenly(this BiomeMask in_enumVariable)
            => in_enumVariable.HasFlag(BiomeMask.Heavenly);

        /// <summary>Checks if the Coastal flag is set.</summary>
        /// <returns><c>true</c>, if the Coastal flag is set, <c>false</c> otherwise.</returns>
        public static bool IsCoastal(this BiomeMask in_enumVariable)
            => in_enumVariable.HasFlag(BiomeMask.Coastal);

        /// <summary>Checks if the Swampy flag is set.</summary>
        /// <returns><c>true</c>, if the Swampy flag is set, <c>false</c> otherwise.</returns>
        public static bool IsSwampy(this BiomeMask in_enumVariable)
            => in_enumVariable.HasFlag(BiomeMask.Swampy);

        /// <summary>Checks if the Frozen flag is set.</summary>
        /// <returns><c>true</c>, if the Frozen flag is set, <c>false</c> otherwise.</returns>
        public static bool IsFrozen(this BiomeMask in_enumVariable)
            => in_enumVariable.HasFlag(BiomeMask.Frozen);

        /// <summary>Checks if the Volcanic flag is set.</summary>
        /// <returns><c>true</c>, if the Volcanic flag is set, <c>false</c> otherwise.</returns>
        public static bool IsVolcanic(this BiomeMask in_enumVariable)
            => in_enumVariable.HasFlag(BiomeMask.Volcanic);

        /// <summary>
        /// Sets the given flag in the specified variable.
        /// </summary>
        /// <param name="in_enumVariable">The enum variable under consideration.</param>
        /// <param name="in_flagToTest">The flag to set.</param>
        /// <returns>The variable with the flag set.</returns>
        public static BiomeMask Set(this ref BiomeMask in_enumVariable, BiomeMask in_flagToTest)
        {
            return in_enumVariable = in_enumVariable | in_flagToTest;
        }

        /// <summary>
        /// Clears the given flag in the specified variable.
        /// </summary>
        /// <param name="in_enumVariable">The enum variable under consideration.</param>
        /// <param name="in_flagToTest">The flag to clear.</param>
        /// <returns>The variable with the flag cleared.</returns>
        public static BiomeMask Clear(this ref BiomeMask in_enumVariable, BiomeMask in_flagToTest)
        {
            return in_enumVariable = in_enumVariable & ~in_flagToTest;
        }

        /// <summary>
        /// Checks if the given flag is set.
        /// </summary>
        /// <param name="in_enumVariable">The enum variable under consideration.</param>
        /// <param name="in_flagToTest">The flag to test.</param>
        /// <returns><c>true</c>, if at least this flag is set, <c>false</c> otherwise.</returns>
        public static bool IsSet(this BiomeMask in_enumVariable, BiomeMask in_flagToTest)
        {
            return (in_enumVariable & in_flagToTest) == in_flagToTest;
        }

        /// <summary>
        /// Checks if the given flag is unset.
        /// </summary>
        /// <param name="in_enumVariable">The enum variable under consideration.</param>
        /// <param name="in_flagToTest">The flag to test.</param>
        /// <returns><c>true</c>, if at least this flag is unset, <c>false</c> otherwise.</returns>
        public static bool IsNotSet(this BiomeMask in_enumVariable, BiomeMask in_flagToTest)
        {
            return (in_enumVariable & ~in_flagToTest) == BiomeMask.None;
        }

        /// <summary>
        /// Sets or clears the given flag in the specified variable, depending on the given boolean.
        /// </summary>
        /// <param name="in_enumVariable">The enum variable under consideration.</param>
        /// <param name="in_flagToTest">The flag to set or clear.</param>
        /// <param name="in_state">If <c>true</c>, the flag will be set; otherwise it will be cleared.</param>
        /// <returns>The variable with the flag modified.</returns>
        public static BiomeMask SetTo(this ref BiomeMask in_enumVariable, BiomeMask in_flagToTest, bool in_state)
        {
            return in_enumVariable = in_state
                ? in_enumVariable.Set(in_flagToTest)
                : in_enumVariable.Clear(in_flagToTest);
        }
    }
}
