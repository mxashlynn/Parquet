using System;

namespace Parquet
{
    /// <summary>
    /// Global access to the logging mechanism.
    /// </summary>
    /// <seealso cref="ILogger"/>
    public static class Logger
    {
        /// <summary>The instance currently being used to log events.</summary>
        private static ILogger currentLogger = new LoggerDefault();

        /// <summary>
        /// Represents a type used to perform logging.
        /// </summary>
        /// <remarks>
        /// Inspired by <see cref="Microsoft.Extensions.Logging.ILogger"/> but simpler.
        /// </remarks>
        public static void SetLogger(ILogger inLoggerToUse)
            => currentLogger = inLoggerToUse is not null
                ? inLoggerToUse
                : currentLogger;

        /// <summary>
        /// Writes a log entry.
        /// </summary>
        /// <param name="inLogLevel">The severity of the event being logged.</param>
        /// <param name="inMessage">A message summarizing the event being logged.</param>
        /// <param name="inException">The exception related to this event, if any.</param>
        public static void Log(LogLevel inLogLevel, string inMessage = null, Exception inException = null)
            => currentLogger.Log(inLogLevel, inMessage, inException);

        /// <summary>
        /// Writes a log entry.
        /// </summary>
        /// <param name="inLogLevel">The severity of the event being logged.</param>
        /// <param name="inObject">An object related to the event being logged.  This will be converted to a string.</param>
        public static void Log(LogLevel inLogLevel, object inObject)
            => currentLogger.Log(inLogLevel, inObject?.ToString() ?? "", null);
    }
}
