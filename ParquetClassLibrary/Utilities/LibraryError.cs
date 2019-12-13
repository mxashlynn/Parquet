using System.IO;

namespace ParquetClassLibrary.Utilities
{
    /// <summary>
    /// Error handling routines for the application.
    /// </summary>
    public static class LibraryError
    {
        /// <summary>The path and name of the log file.</summary>
        private const string logFile = "ParquetLogFile.txt";
        // TODO Is it okay to ship with a call to Diagnostics?

        /// <summary>
        /// Logs the given error and alerts the user.
        /// </summary>
        /// <param name="in_errorMessage">User-facing error message.</param>
        public static void Handle(string in_errorMessage)
        {
            // TODO Convert this to use multiplatform utils.
            try
            {
                using var log = File.AppendText(logFile);
                log.WriteLine($"[{in_errorMessage}]");
            }
            catch { /* TODO Eliminate this, this is just a stop-gap for unit testing conflicts. */ }
        }
    }
}
