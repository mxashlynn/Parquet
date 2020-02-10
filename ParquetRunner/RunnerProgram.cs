using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CsvHelper.TypeConversion;
using ParquetClassLibrary;
using ParquetClassLibrary.Beings;
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
            // Serialization
            //All.LoadFromCSV();
            //Serializer.WorkingDirectory += "/Output";
            //All.SaveToCSV();

            // Display
            var region = new MapRegion(All.MapRegionIDs.Minimum, "Sample Region");
            Console.WriteLine(region);
            Console.WriteLine($"Item range = {All.ItemIDs}");
            Console.WriteLine($"PronounGroups.Count = {All.PronounGroups.Count}");
        }
    }
}
