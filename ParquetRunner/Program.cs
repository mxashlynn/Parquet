using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
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
        public static void Main(string[] args)
        {
            var region = new MapRegion();
            Console.WriteLine(region);

            /*
            public class TestClassMap : ClassMap<TestClass>
            {
                public TestClassMap()
                {
                    Map(m => m.Id).Index(0).Name("ID");
                    Map(m => m.Name).Index(1);
                }
            }

            var records = new List<TestClass>
            {
                new TestClass { Id = 1, Name = "one" },
                new TestClass { Id = 2, Name = "two" },
            };

            using (var writer = new StreamWriter(@"./../../../Parquet Designer.csv"))
            {
                using (var csv = new CsvWriter(writer))
                {
                    csv.Configuration.RegisterClassMap<TestClassMap>();
                    csv.WriteRecords(records);
                }
            }           
             */
        }
    }
}
