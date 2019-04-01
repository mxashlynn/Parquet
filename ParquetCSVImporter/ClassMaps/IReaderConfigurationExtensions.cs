using CsvHelper.Configuration;
using ParquetClassLibrary.Sandbox.Parquets;
using ParquetClassLibrary.Utilities;

namespace ParquetCSVImporter.ClassMaps
{
    /// <summary>
    /// Provides extensions to the <see cref="T:CsvHelper.Configuration.IReaderConfigurationExtension"/>.
    /// </summary>
    // ReSharper disable once InconsistentNaming
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
            else if (typeof(T) == typeof(Collectible))
            {
                in_configuration.RegisterClassMap<CollectibleClassMap>();
            }
            else
            {
                Error.Handle($"No class map exists for {typeof(T)}");
            }
        }
    }
}
