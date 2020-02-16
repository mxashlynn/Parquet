using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ParquetClassLibrary;
using ParquetClassLibrary.Beings;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Crafts;
using ParquetClassLibrary.Interactions;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Rooms;

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
            All.LoadFromCSV();
            //Serializer.WorkingDirectory += "/Output";
            //All.SaveToCSV();

            // Display
            //var region = new MapRegion(All.MapRegionIDs.Minimum, "Sample Region");
            //Console.WriteLine(region);
            //Console.WriteLine($"Item range = {All.ItemIDs}");

            Console.WriteLine($"PronounGroups.Count = {All.PronounGroups.Count}");
            Console.WriteLine($"Beings.Count = {All.Beings.Count}");
            Console.WriteLine($"Biomes.Count = {All.Biomes.Count}");
            Console.WriteLine($"CraftingRecipes.Count = {All.CraftingRecipes.Count}");
            Console.WriteLine($"Interactions.Count = {All.Interactions.Count}");
            Console.WriteLine($"Parquets.Count = {All.Parquets.Count}");
            Console.WriteLine($"RoomRecipes.Count = {All.RoomRecipes.Count}");
            Console.WriteLine($"Items.Count = {All.Items.Count}");

            Console.WriteLine($"Maps.Count = {All.Maps.Count}");
            foreach (MapModel model in All.Maps)
            {
                Console.WriteLine($" > Map: {model}");
            }
        }
    }
}
