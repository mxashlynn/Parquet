using System.IO;

namespace ParquetClassLibrary.Utilities
{
    /// <summary>
    /// Error handling routines for the application.
    /// </summary>
    public static class Error
    {
        /// <summary>The path and name of the log file.</summary>
        private const string logFile = "ParquetLogFile.txt";

        /// <summary>
        /// Logs the given error and alerts the user.
        /// </summary>
        /// <param name="in_errorMessage">User-facing error message.</param>
        public static void Handle(string in_errorMessage)
        {
            // TODO Convert this to use multiplatform utils.
            using (var log = File.AppendText(logFile))
            {
                log.WriteLine(in_errorMessage);
            }
        }
    }
}
