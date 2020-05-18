using System;
using System.Collections.Generic;
using System.Linq;
using ParquetClassLibrary;
using ParquetClassLibrary.Beings;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Crafts;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Rooms;
using ParquetClassLibrary.Scripts;

namespace ParquetRunner
{
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

            /*
            var region = new MapRegion(All.MapRegionIDs.Minimum, "Sample Region");
            Console.WriteLine(region);
            Console.WriteLine($"Item range = {All.ItemIDs}");
            */

            var procGenChunk = 70001;
            var chunks = new ModelIDGrid(MapRegionSketch.ChunksPerRegionDimension, MapRegionSketch.ChunksPerRegionDimension);
            for (var x = 0; x < MapRegionSketch.ChunksPerRegionDimension; x++)
            {
                for (var y = 0; y < MapRegionSketch.ChunksPerRegionDimension; y++)
                {
                    chunks[y, x] = procGenChunk;
                }
            }
            var sketch = new MapRegionSketch(All.MapRegionIDs.Minimum, ": Region Composition Proof-of-Concept", "", "", 1, "#AAAAAAFF",
                                             ModelID.None, ModelID.None, ModelID.None, ModelID.None, ModelID.None, ModelID.None,
                                             chunks);

            Console.WriteLine(sketch);
            var region = sketch.Stitch();
            Console.WriteLine(region);

            All.SaveToCSVs();
        }
    }
}
