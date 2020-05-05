using System;
using ParquetClassLibrary;
using ParquetClassLibrary.Maps;

namespace ParquetRunner
{
    #region Test Stuff
    #endregion

    /// <summary>
    /// A simple program used to run some basic features of the <see cref="ParquetClassLibrary"/>.
    /// </summary>
    internal class MainClass
    {
        /// <summary>
        /// A simple program used to run some basic features of the <see cref="ParquetClassLibrary"/>.
        /// </summary>
        public static void Main()
        {
            All.LoadFromCSVs();

            var region = new MapRegion(All.MapRegionIDs.Minimum, "Sample Region");
            Console.WriteLine(region);
            Console.WriteLine($"Item range = {All.ItemIDs}");

            All.SaveToCSVs();
        }
    }
}
