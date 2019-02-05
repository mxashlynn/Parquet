using System;

namespace ParquetClassLibrary
{
    /// <summary>
    /// Error handling routines for the application.
    /// </summary>
    public static class Error
    {
        /// <summary>
        /// Logs the given error and alerts the user.
        /// </summary>
        /// <param name="in_errorMessage">User-facing error message.</param>
        public static void Handle(string in_errorMessage)
        {
            // TODO Implement a better error-handling and logging mechanism.
            Console.WriteLine(in_errorMessage);
        }
    }
}
