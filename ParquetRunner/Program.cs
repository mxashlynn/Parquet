﻿using System;
using ParquetClassLibrary.Sandbox;

namespace ParquetRunner
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var myMap = new RegionMap();
            myMap.FillTestPattern();
            Console.WriteLine(myMap);
            //Console.WriteLine(myMap.SerializeToString());
        }
    }
}
