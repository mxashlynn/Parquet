using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ParquetClassLibrary;
using ParquetClassLibrary.Utilities;
using ParquetClassLibrary.Sandbox;
using ParquetClassLibrary.Sandbox.Parquets;
using ParquetClassLibrary.Sandbox.ID;
using ParquetClassLibrary.Stubs;

namespace ParquetRunner
{
    class MainClass
    {
        public static readonly Floor TestFloor = new Floor(-Assembly.FloorIDs.Minimum, "Grass Floor Test Parquet");
        public static readonly Block TestBlock = new Block(-Assembly.BlockIDs.Minimum, "Brick Block Test Parquet");
        public static readonly Furnishing TestFurnishing = new Furnishing(-Assembly.FurnishingIDs.Minimum, "Chair Furnishing Test Parquet");
        public static readonly Collectable TestCollectable = new Collectable(-Assembly.CollectableIDs.Minimum, "Flowers Collectable Test Parquet");

        public static void Main(string[] args)
        {
            var region = new MapRegion();
            Console.WriteLine(region);

        }
    }
}
