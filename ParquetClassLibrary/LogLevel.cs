namespace Parquet
{
    /// <summary>
    /// Defines logging severity levels.
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Events of interest during development only.
        /// Used while implementing and testing.
        /// Library developers should see these events.
        /// </summary>
        Debug = 0,

        /// <summary>
        /// Normal and expected events that track application flow.
        /// Used to diagnose issues after release.
        /// Game developers should see these events.
        /// </summary>
        Info = 1,

        /// <summary>
        /// Unexpected events that do not interrupt normal operation.
        /// Used to diagnose issues after release.
        /// Game developers should see these events.
        /// </summary>
        Warning = 2,

        /// <summary>
        /// Abnormal events that interrupt operation, but from which the application can recover.
        /// Used to report a failure in the current activity, not an application-wide failure.
        /// Game players should see these events.
        /// </summary>
        Error = 3,

        /// <summary>
        /// Fatal events from which the application cannot recover.
        /// Used to report an application or system failures that requires immediate attention.
        /// Game players should see these events.
        /// These events typically require that the game and library be restarted.
        /// </summary>
        Fatal = 4,
    }
}
