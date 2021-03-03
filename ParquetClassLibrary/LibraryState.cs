namespace Parquet
{
    /// <summary>
    /// Represents how the library was built and how it is currently being used.
    /// </summary>
    public static class LibraryState
    {
#pragma warning disable IDE0079 // Remove unnecessary suppression -- conditional compilation.
#pragma warning disable RS0016 // Add public types and members to the declared API -- conditional compilation.
        /// <summary>
        /// <c>true</c> if the library was built with the symbol DEBUG defined; <c>false</c> otherwise.
        /// </summary>
        public const bool IsDebugMode =
#if DEBUG
            true;
#else
            false;
#endif
#pragma warning restore RS0016 // Add public types and members to the declared API -- conditional compilation.
#pragma warning restore IDE0079 // Remove unnecessary suppression -- conditional compilation.

        /// <summary>
        /// Set this to <c>true</c> if the library is being used by a game;
        /// set it to <c>false</c> if it is being used by an editor or tool.
        /// </summary>
        /// <remarks>
        /// <see cref="Model"/>s are designed to be immutable during play
        /// but mutable at design time.<br />
        /// By preventing model mutation when this is set to <c>true</c>, Parquet
        /// removes some of the responsibility to respect this distinction from the
        /// game developer.
        /// </remarks>
        public static bool IsPlayMode { get; set; }
    }
}
