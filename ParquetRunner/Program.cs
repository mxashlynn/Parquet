using System;
using ParquetClassLibrary.Utilities;
using ParquetClassLibrary.Sandbox;
using ParquetClassLibrary.Stubs;

namespace ParquetRunner
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var myMap = new MapRegion("Moria", Color.Grey);
            //Console.BackgroundColor = myMap.Background;
            Console.WriteLine(myMap);
            //Console.WriteLine(myMap.SerializeToString());
        }
    }
}
