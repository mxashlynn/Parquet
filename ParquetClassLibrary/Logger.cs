using System;
using System.Globalization;
using Parquet.Properties;

namespace Parquet
{
    /// <summary>
    /// Global access to the logging mechanism.
    /// </summary>
    /// <seealso cref="ILogger"/>
    public static class Logger
    {
        #region Characteristics
        /// <summary>The instance currently being used to log events.</summary>
        private static ILogger currentLogger = new LoggerDefault();
        #endregion

        #region Initialization
        /// <summary>
        /// Sets up the logging system to use the provided instance when logging.
        /// </summary>
        /// <remarks>
        /// Inspired by Microsoft.Extensions.Logging.ILogger but simpler.
        /// </remarks>
        public static void SetLogger(ILogger inLoggerToUse)
            => currentLogger = inLoggerToUse is not null
                ? inLoggerToUse
                : currentLogger;
        #endregion

        #region Log Access
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
        #endregion

        #region Convenience Routines
        /// <summary>
        /// Convenience method that logs a <see cref="LibraryState"/> error and returns the given default value.
        /// </summary>
        /// <typeparam name="T">The type of value to return.</typeparam>
        /// <param name="name">The name of the item that cannot be used during play.</param>
        /// <param name="inDefaultValue">The default value to return.</param>
        /// <returns>The default value given.</returns>
        internal static T DefaultWithImmutableInPlayLog<T>(string name, T inDefaultValue)
        {
            currentLogger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.WarningImmutableDuringPlay,
                                                              name), null);
            return inDefaultValue;
        }

        /// <summary>
        /// Convenience method that logs a conversion error and returns the given default value.
        /// </summary>
        /// <typeparam name="T">The type of value to return.</typeparam>
        /// <param name="value">The value of the item that failed to convert.</param>
        /// <param name="name">The name of the item that failed to convert.</param>
        /// <param name="inDefaultValue">The default value to return.</param>
        /// <returns>The default value given.</returns>
        internal static T DefaultWithConvertLog<T>(string value, string name, T inDefaultValue)
        {
            currentLogger.Log(LogLevel.Error, string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotConvert,
                                                            value, name), null);
            return inDefaultValue;
        }

        /// <summary>
        /// Convenience method that logs a parsing error and returns the given default value.
        /// </summary>
        /// <typeparam name="T">The type of value to return.</typeparam>
        /// <param name="value">The value of the item that failed to parse.</param>
        /// <param name="name">The name of the item that failed to parse.</param>
        /// <param name="inDefaultValue">The default value to return.</param>
        /// <returns>The default value given.</returns>
        internal static T DefaultWithParseLog<T>(string value, string name, T inDefaultValue)
        {
            currentLogger.Log(LogLevel.Error, string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotParse,
                                                            value, name), null);
            return inDefaultValue;
        }

        /// <summary>
        /// Convenience method that logs an unsupported command error and returns the given default value.
        /// </summary>
        /// <typeparam name="T">The type of value to return.</typeparam>
        /// <param name="name">The name of the command type.</param>
        /// <param name="inCommandText">The text version of the unsupported command.</param>
        /// <param name="inDefaultValue">The default value to return.</param>
        /// <returns>The default value given.</returns>
        internal static T DefaultWithUnsupportedNodeLog<T>(string name, string inCommandText, T inDefaultValue)
        {
            currentLogger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture,
                                                              Resources.ErrorUnsupportedNode,
                                                              name, inCommandText), null);
            return inDefaultValue;
        }

        /// <summary>
        /// Convenience method that logs a serialization error and returns the given default value.
        /// </summary>
        /// <typeparam name="T">The type of value to return.</typeparam>
        /// <param name="name">The name of the item that failed to serialize.</param>
        /// <param name="inDefaultValue">The default value to return.</param>
        /// <returns>The default value given.</returns>
        internal static T DefaultWithUnsupportedSerializationLog<T>(string name, T inDefaultValue)
        {
            currentLogger.Log(LogLevel.Error, string.Format(CultureInfo.CurrentCulture, Resources.ErrorUnsupportedSerialization,
                                                            name), null);
            return inDefaultValue;
        }
        #endregion
    }
}
