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
        /// <param name="inLogLevel">The severity of the event being logged.</param>
        /// <param name="inMessage">A message summarizing the event being logged.</param>
        /// <param name="inException">The exception related to this event, if any.</param>
        public void Log(LogLevel inLogLevel, string inMessage = null, Exception inException = null)
        {
            if (inLogLevel == LogLevel.Debug && !LibraryState.IsDebugMode)
            {
                // Ignore debug logs when not running in debug mode.
                return;
            }

            var destination = inLogLevel == LogLevel.Info
                ? Console.Out
                : Console.Error;
            var message = !string.IsNullOrEmpty(inMessage)
                ? inMessage
                : inException is not null
                    ? inException.Message
                    : $"Parquet {nameof(LoggerDefault)} Trace at {DateTime.Now}.";

            destination.WriteLine(message);
        }
    }
}
