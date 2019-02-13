using System.IO;

namespace ParquetClassLibrary.Utilities
{
    /// <summary>
    /// Error handling routines for the application.
    /// </summary>
    public static class Error
    {
        private const string _logFile = "ParquetLogFile.txt";

        /// <summary>
        /// Logs the given error and alerts the user.
        /// </summary>
        /// <param name="in_errorMessage">User-facing error message.</param>
        public static void Handle(string in_errorMessage)
        {
            // TODO Convert this to use multiplatform utils.
            using (StreamWriter log = File.AppendText(_logFile))
            {
                log.WriteLine(in_errorMessage);
            }
        }
    }
}
