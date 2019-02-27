using System;
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
        public static void Main(string[] args)
        {
            var region = new MapRegion();
            //var serialized = region.SerializeToString();
            Console.WriteLine(region);
            //Console.WriteLine(serialized);
        }
    }
}
