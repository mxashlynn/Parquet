using System;
using ParquetClassLibrary;
using ParquetClassLibrary.Maps;

namespace ParquetRunner
{
    /// <summary>
    /// A simple program used to run some basic features of the <see cref="ParquetClassLibrary"/>.
    /// </summary>
    internal class MainClass
    {
        /// <summary>
        /// Entry point for the program.
        /// </summary>
        public static void Main()
        {
            var region = new MapRegion(All.MapRegionIDs.Minimum, "Sample Region");
            Console.WriteLine(region);
            Console.WriteLine($"Item range = {All.ItemIDs}");
        }
    }
}
