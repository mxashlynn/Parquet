using System;
using ParquetClassLibrary;

namespace ParquetRoller
{
    /// <summary>
    /// A command line tool that reads in game definitions from CSV files, verifies, modifies, and writes them out.
    /// </summary>
    internal static class Roller
    {
        #region Console Messages
        private static readonly string DefaultMessage = "Hi.";

        private static readonly string VersionMessage = $"Version:\n    Roller      {AssemblyInfo.LibraryVersion.Remove(AssemblyInfo.LibraryVersion.Length - 2)}\n    Parquet     {AssemblyInfo.LibraryVersion}\n    Map Data    {AssemblyInfo.SupportedMapDataVersion}\n    Being Data  {AssemblyInfo.SupportedBeingDataVersion}";
        #endregion

        /// <summary>
        /// A command line tool for working with Parquet configuration files.
        /// </summary>
        /// <param name="args">Command line arguments passed in to the tool.</param>
        internal static int Main(string[] args)
        {
            Console.WriteLine(VersionMessage);
            return 0;
        }
    }
}
