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
        /// Represents a type used to perform logging.
        /// </summary>
        /// <remarks>
        /// Inspired by <see cref="Microsoft.Extensions.Logging.ILogger"/> but simpler.
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
        /// Convenience method that logs a parsing error and returns the given default value.
        /// </summary>
        /// <typeparam name="T">The type of value to return.</typeparam>
        /// <param name="inValue">The value of the item that failed to parse.</param>
        /// <param name="inName">The name of the item that failed to parse.</param>
        /// <param name="inDefaultValue">The default value to return.</param>
        /// <returns>The default value given.</returns>
        internal static T DefaultWithParseLog<T>(string inValue, string inName, T inDefaultValue)
        {
            currentLogger.Log(LogLevel.Error, string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotParse,
                                                            inValue, inName), null);
            return inDefaultValue;
        }

        /// <summary>
        /// Convenience method that logs a conversion error and returns the given default value.
        /// </summary>
        /// <typeparam name="T">The type of value to return.</typeparam>
        /// <param name="inValue">The value of the item that failed to convert.</param>
        /// <param name="inName">The name of the item that failed to convert.</param>
        /// <param name="inDefaultValue">The default value to return.</param>
        /// <returns>The default value given.</returns>
        internal static T DefaultWithConvertLog<T>(string inValue, string inName, T inDefaultValue)
        {
            currentLogger.Log(LogLevel.Error, string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotConvert,
                                                            inValue, inName), null);

            return inDefaultValue;
        }

        /// <summary>
        /// Convenience method that logs an unsupported command error and returns the given default value.
        /// </summary>
        /// <typeparam name="T">The type of value to return.</typeparam>
        /// <param name="inName">The name of the command type.</param>
        /// <param name="inCommandText">The text version of the unsupported command.</param>
        /// <param name="inDefaultValue">The default value to return.</param>
        /// <returns>The default value given.</returns>
        internal static T DefaultWithUnsupportedNodeLog<T>(string inName, string inCommandText, T inDefaultValue)
        {
            currentLogger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture,
                                                                Resources.ErrorUnsupportedNode,
                                                                inName, inCommandText), null);

            return inDefaultValue;
        }
        #endregion
    }
}
