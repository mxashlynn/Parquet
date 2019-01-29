using System;
using Queertet.Sandbox;

namespace ParquetCLTester
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var myMap = new RegionMap();
            myMap.FillTextPattern();
            Console.WriteLine("Region Map ~~~ \n" + myMap);
        }
    }
}

