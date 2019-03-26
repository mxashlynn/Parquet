using System.Collections.Generic;
using CsvHelper;
using CsvHelper.Configuration;
using ParquetClassLibrary.Utilities;
using ParquetClassLibrary.Sandbox.Parquets;

namespace ParquetCSVImporter.ClassMaps
{
    /// <summary>
    /// Provides extensions to the CSV Reader Configuration.
    /// </summary>
    public static class IReaderConfigurationExtensions
    {
        /// <summary>
        /// Registers the ClassMap that corresponds to the given Class.
        /// </summary>
        /// <param name="in_configuration">The CSV Reader Configuration.</param>
        /// <typeparam name="T">The class to map.</typeparam>
        /// <returns>The class map for the given type.</returns>
        public static void RegisterClassMapFor<T>(this IReaderConfiguration in_configuration) where T : ParquetParent
        {
            if (typeof(T) == typeof(Floor))
            {
                in_configuration.RegisterClassMap<FloorClassMap>();
            }
            else if (typeof(T) == typeof(Block))
            {
                in_configuration.RegisterClassMap<BlockClassMap>();
            }
            else if (typeof(T) == typeof(Furnishing))
            {
                in_configuration.RegisterClassMap<FurnishingClassMap>();
            }
            else if (typeof(T) == typeof(Collectable))
            {
                in_configuration.RegisterClassMap<CollectableClassMap>();
            }
            else
            {
                Error.Handle($"No class map exists for {typeof(T).ToString()}");
            }
        }
    }
}
