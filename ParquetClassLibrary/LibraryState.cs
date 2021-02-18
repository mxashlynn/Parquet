namespace Parquet
{
    /// <summary>
    /// Represents how the library was built and the state it is currently running in.
    /// </summary>
    public static class LibraryState
    {
        /// <summary>
        /// <c>true</c> if the library was built with the symbol DEBUG defined; <c>false</c> otherwise.
        /// </summary>
        public const bool IsDebugMode =
#if DEBUG
            true;
#else
            false;
#endif

        /// <summary>
        /// Set this to <c>true</c> if the library is being used by a game;
        /// set it to <c>false</c> if it is being used by an editor or tool.
        /// </summary>
        /// <remarks>
        /// This is optional.  When set to <c>true</c>, Parquet prevents editing
        /// the properties of <see cref="Model"/>s, which are not designed to be
        /// mutated during play, but which must be mutated during game design.
        /// </remarks>
        public static bool IsPlayMode { get; set; }
    }
}
