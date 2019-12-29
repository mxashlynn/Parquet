using System;

namespace ParquetClassLibrary.Biomes
{
    /// <summary>
    /// Indicates the level of a MapChunk or MapRegion.
    /// </summary>
    [Flags]
    internal enum ElevationMask
    {
        None,
        BelowGround,
        LevelGround,
        AboveGround
    }

    /// <summary>
    /// Convenience extension methods for concise coding when working with <see cref="ElevationMask"/> instances.
    /// </summary>
    internal static class ElevationMaskSelectionExtensions
    {
        /// <summary>
        /// Sets the given flag in the specified variable.
        /// </summary>
        /// <param name="refEnumVariable">The enum variable under consideration.</param>
        /// <param name="inFlagToSet">The flag to set.</param>
        /// <returns>The variable with the flag set.</returns>
        public static ElevationMask Set(this ref ElevationMask refEnumVariable, ElevationMask inFlagToSet)
            => refEnumVariable |= inFlagToSet;

        /// <summary>
        /// Clears the given flag in the specified variable.
        /// </summary>
        /// <param name="refEnumVariable">The enum variable under consideration.</param>
        /// <param name="inFlagToClear">The flag to clear.</param>
        /// <returns>The variable with the flag cleared.</returns>
        public static ElevationMask Clear(this ref ElevationMask refEnumVariable, ElevationMask inFlagToClear)
            => refEnumVariable &= ~inFlagToClear;

        /// <summary>
        /// Checks if the given flag is set.
        /// </summary>
        /// <param name="inEnumVariable">The enum variable under consideration.</param>
        /// <param name="inFlagToTest">The flag to test.</param>
        /// <returns><c>true</c>, if at least this flag is set, <c>false</c> otherwise.</returns>
        public static bool IsSet(this ElevationMask inEnumVariable, ElevationMask inFlagToTest)
            => (inEnumVariable & inFlagToTest) == inFlagToTest;

        /// <summary>
        /// Sets or clears the given flag in the specified variable, depending on the given boolean.
        /// </summary>
        /// <param name="refEnumVariable">The enum variable under consideration.</param>
        /// <param name="inFlagToTest">The flag to set or clear.</param>
        /// <param name="inState">If <c>true</c>, the flag will be set; otherwise it will be cleared.</param>
        /// <returns>The variable with the flag modified.</returns>
        public static ElevationMask SetTo(this ref ElevationMask refEnumVariable, ElevationMask inFlagToTest, bool inState)
            => inState
                ? refEnumVariable.Set(inFlagToTest)
                : refEnumVariable.Clear(inFlagToTest);
    }
}
