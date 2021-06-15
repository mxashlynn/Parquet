using System;

namespace Parquet
{
    /// <summary>
    /// Represents a type used to perform logging.
    /// Typically this type is provided by the game or tool that uses Parquet.
    /// </summary>
    /// <remarks>
    /// Inspired by Microsoft.Extensions.Logging.ILogger but simpler.
    /// </remarks>
    public interface ILogger
    {
        /// <summary>
        /// Writes a log entry.
        /// </summary>
        /// <param name="logLevel">The severity of the event being logged.</param>
        /// <param name="message">A message summarizing the event being logged.</param>
        /// <param name="exception">The exception related to this event, if any.</param>
        void Log(LogLevel logLevel, string message, Exception exception);
    }
}
