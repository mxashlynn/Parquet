using System;
using CsvHelper.Configuration;
using ParquetClassLibrary.Beings;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Crafts;
using ParquetClassLibrary.Interactions;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Rooms;
using ParquetClassLibrary.Serialization.ClassMaps;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Serialization
{
    /// <summary>
    /// Provides extensions to the <see cref="CsvHelper.Configuration.IReaderConfigurationExtension"/>.
    /// </summary>
    public static class IReaderConfigurationExtensions
    {
        /// <summary>
        /// Registers the <see cref="ClassMap"/> that corresponds to the given <typeparamref name="TClass"/>.
        /// </summary>
        /// <param name="inConfiguration">The CSV Reader Configuration.</param>
        /// <typeparam name="TClass">The class to map.</typeparam>
        /// <returns>The class map for the given type.</returns>
        /// <exception cref="ArgumentException">When there is no <see cref="ClassMap"/> matching the requested type.</exception>
        public static void RegisterClassMapFor<TClass>(this IReaderConfiguration inConfiguration)
            where TClass : EntityModel, ISerialMapper
        {
            Precondition.IsNotNull(inConfiguration, nameof(inConfiguration));

            inConfiguration.RegisterClassMap(Serializer.Mapper[typeof(TClass)]);
        }
    }
}
