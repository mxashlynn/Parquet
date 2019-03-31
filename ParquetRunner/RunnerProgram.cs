using System;
using ParquetClassLibrary.Sandbox;

namespace ParquetRunner
{
    /// <summary>
    /// A simple progream used to run some basic features of the <see cref="ParquetClassLibrary"/>.
    /// </summary>
    internal class MainClass
    {
        /// <summary>
        /// Entry point for the program.
        /// </summary>
        public static void Main()
        {
            var region = new MapRegion();
            Console.WriteLine(region);
        }
    }
}
