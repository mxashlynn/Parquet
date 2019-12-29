using System;
using CsvHelper.Configuration;
using ParquetClassLibrary;
using ParquetClassLibrary.Parquets;

namespace ParquetCSVImporter.ClassMaps
{
    /// <summary>
    /// Provides extensions to the <see cref="CsvHelper.Configuration.IReaderConfigurationExtension"/>.
    /// </summary>
    public static class IReaderConfigurationExtensions
    {
        /// <summary>
        /// Registers the ClassMap that corresponds to the given Class.
        /// </summary>
        /// <param name="inConfiguration">The CSV Reader Configuration.</param>
        /// <typeparam name="T">The class to map.</typeparam>
        /// <returns>The class map for the given type.</returns>
        public static void RegisterClassMapFor<T>(this IReaderConfiguration inConfiguration) where T : Entity
        {
            /*
            if (typeof(T) == typeof(PlayerCharacter))
            {
                inConfiguration.RegisterClassMap<PlayerCharacterClassMap>();
            }
            else if (typeof(T) == typeof(NPC))
            {
                inConfiguration.RegisterClassMap<NPCClassMap>();
            }
            else if (typeof(T) == typeof(Critter))
            {
                inConfiguration.RegisterClassMap<CritterClassMap>();
            }
            else */
            if (typeof(T) == typeof(Floor))
            {
                inConfiguration.RegisterClassMap<FloorClassMap>();
            }
            else if (typeof(T) == typeof(Block))
            {
                inConfiguration.RegisterClassMap<BlockClassMap>();
            }
            else if (typeof(T) == typeof(Furnishing))
            {
                inConfiguration.RegisterClassMap<FurnishingClassMap>();
            }
            else if (typeof(T) == typeof(Collectible))
            {
                inConfiguration.RegisterClassMap<CollectibleClassMap>();
            }
            else
            {
                Console.WriteLine($"No class map exists for {typeof(T)}");
            }
        }
    }
}
