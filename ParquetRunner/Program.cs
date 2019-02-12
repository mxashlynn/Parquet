using System;
using ParquetClassLibrary.Utilities;
using ParquetClassLibrary.Sandbox;

namespace ParquetRunner
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var myMap = new RegionMap();
            myMap.FillTestPattern();

            Console.BackgroundColor = myMap.Background;
            Console.WriteLine(myMap);
            // Console.WriteLine(myMap.SerializeToString());
        }
    }
}
