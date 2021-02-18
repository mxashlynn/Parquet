namespace Parquet
{
    /// <summary>
    /// Represents how the library was built and the state it is currently running in.
    /// </summary>
    public static class GameMode
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
        /// Set this to <c>true</c> if the library is being used by an editor tool; set it to <c>false</c> otherwise.
        /// </summary>
        public static bool IsEditMode { get; set; }
    }
}
