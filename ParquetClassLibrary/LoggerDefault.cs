using System;

namespace Parquet
{
    /// <summary>
    /// Performs logging.
    /// </summary>
    /// <remarks>
    /// This is very bare bones and is intended to be replaced by a more appropriate logger provided by the application.
    /// <seealso cref="Logger"/>
    /// </remarks>
    internal class LoggerDefault : ILogger
    {
        /// <summary>
        /// Writes a log entry.
        /// </summary>
        /// <param name="logLevel">The severity of the event being logged.</param>
        /// <param name="message">A message summarizing the event being logged.</param>
        /// <param name="exception">The exception related to this event, if any.</param>
        public void Log(LogLevel logLevel, string message = null, Exception exception = null)
        {
            if (logLevel == LogLevel.Debug && !LibraryState.IsDebugMode)
            {
                // Ignore debug logs when not running in debug mode.
                return;
            }

            var destination = logLevel == LogLevel.Info
                ? Console.Out
                : Console.Error;
            var nonNullMessage = !string.IsNullOrEmpty(message)
                ? message
                : exception is not null
                    ? exception.Message
                    : $"Parquet {nameof(LoggerDefault)} Trace at {DateTime.Now}.";

            destination.WriteLine(nonNullMessage);
        }
    }
}
