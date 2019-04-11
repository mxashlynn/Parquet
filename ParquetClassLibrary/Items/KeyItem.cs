using System;

namespace ParquetClassLibrary.Items
{
    /// <summary>
    /// Represents the subtype of <see cref="Items.ItemType.KeyItem"/> that grants safe access to 
    /// the a <see cref="Biome"/>.  Indicates requirements a player character must meet to enter.
    /// </summary>
    // TODO: This needs revision to represent all Key Item types.
    [Flags]
    public enum KeyItem
    {
        None = 0,
        /// <summary>E.g., knapsack.</summary>
        ForestKey,
        /// <summary>E.g., sunscreen.</summary>
        SeasideKey,
        /// <summary>E.g., boots.</summary>
        Tier2Key,
        /// <summary>E.g., canteen.</summary>
        DesertKey,
        /// <summary>E.g., bug spray.</summary>
        SwampKey,
        /// <summary>E.g., snowpants.</summary>
        TundraKey,
        /// <summary>E.g., lantern.</summary>
        CavernKey,
        /// <summary>E.g., rope.</summary>
        Tier3Key,
        /// <summary>E.g., climbing gear.</summary>
        AlpineKey,
        /// <summary>E.g., GasMask.</summary>
        VolcanoKey,
        /// <summary>E.g., warding charm.</summary>
        RuinsKey,
        /// <summary>E.g., pearlescent feather.</summary>
        HeavenlyKey,
        /// <summary>E.g., charred mask.</summary>
        InfernalKey,
    }

    /// <summary>
    /// Convenience extension methods for concise coding when working with <see cref="KeyItem"/> instances.
    /// </summary>
    internal static class KeyItemExtensions
    {
        /// <summary>
        /// Sets the given flag in the specified variable.
        /// </summary>
        /// <param name="in_enumVariable">The enum variable under consideration.</param>
        /// <param name="in_flagToTest">The flag to set.</param>
        /// <returns>The variable with the flag set.</returns>
        public static KeyItem Set(this ref KeyItem in_enumVariable, KeyItem in_flagToTest)
        {
            return in_enumVariable = in_enumVariable | in_flagToTest;
        }

        /// <summary>
        /// Clears the given flag in the specified variable.
        /// </summary>
        /// <param name="in_enumVariable">The enum variable under consideration.</param>
        /// <param name="in_flagToTest">The flag to clear.</param>
        /// <returns>The variable with the flag cleared.</returns>
        public static KeyItem Clear(this ref KeyItem in_enumVariable, KeyItem in_flagToTest)
        {
            return in_enumVariable = in_enumVariable & ~in_flagToTest;
        }

        /// <summary>
        /// Checks if the given flag is set.
        /// </summary>
        /// <param name="in_enumVariable">The enum variable under consideration.</param>
        /// <param name="in_flagToTest">The flag to test.</param>
        /// <returns><c>true</c>, if at least this flag is set, <c>false</c> otherwise.</returns>
        public static bool IsSet(this KeyItem in_enumVariable, KeyItem in_flagToTest)
        {
            return (in_enumVariable & in_flagToTest) == in_flagToTest;
        }

        /// <summary>
        /// Checks if the given flag is unset.
        /// </summary>
        /// <param name="in_enumVariable">The enum variable under consideration.</param>
        /// <param name="in_flagToTest">The flag to test.</param>
        /// <returns><c>true</c>, if at least this flag is unset, <c>false</c> otherwise.</returns>
        public static bool IsNotSet(this KeyItem in_enumVariable, KeyItem in_flagToTest)
        {
            return (in_enumVariable & ~in_flagToTest) == KeyItem.None;
        }

        /// <summary>
        /// Sets or clears the given flag in the specified variable, depending on the given boolean.
        /// </summary>
        /// <param name="in_enumVariable">The enum variable under consideration.</param>
        /// <param name="in_flagToTest">The flag to set or clear.</param>
        /// <param name="in_state">If <c>true</c>, the flag will be set; otherwise it will be cleared.</param>
        /// <returns>The variable with the flag modified.</returns>
        public static KeyItem SetTo(this ref KeyItem in_enumVariable, KeyItem in_flagToTest, bool in_state)
        {
            return in_enumVariable = in_state
                ? in_enumVariable.Set(in_flagToTest)
                : in_enumVariable.Clear(in_flagToTest);
        }
    }
}
