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
        /// Registers the ClassMap that corresponds to the given Class.
        /// </summary>
        /// <param name="inConfiguration">The CSV Reader Configuration.</param>
        /// <typeparam name="T">The class to map.</typeparam>
        /// <returns>The class map for the given type.</returns>
        /// <exception cref="ArgumentException">When there is no <see cref="ClassMap"/> matching the requested type.</exception>
        public static void RegisterClassMapFor<T>(this IReaderConfiguration inConfiguration) where T : EntityModel
        {
            Precondition.IsNotNull(inConfiguration, nameof(inConfiguration));

            // This is a wonky faux static dispatch, as C# does not provide a clean way to associate two types.
            // IDEA It would be nice to replace this with CRTP if that doesn't overly complicate the EntityModel class hierarchy.
            if (typeof(T) == typeof(PlayerCharacterModel))
            {
                inConfiguration.RegisterClassMap<PlayerCharacterClassMap>();
            }
            else if (typeof(T) == typeof(NPCModel))
            {
                inConfiguration.RegisterClassMap<NPCClassMap>();
            }
            else if (typeof(T) == typeof(CritterModel))
            {
                inConfiguration.RegisterClassMap<CritterClassMap>();
            }
            else if (typeof(T) == typeof(BiomeModel))
            {
                inConfiguration.RegisterClassMap<BiomeClassMap>();
            }
            else if (typeof(T) == typeof(CraftingRecipe))
            {
                inConfiguration.RegisterClassMap<CraftingRecipeClassMap>();
            }
            else if (typeof(T) == typeof(DialogueModel))
            {
                inConfiguration.RegisterClassMap<DialogueClassMap>();
            }
            else if (typeof(T) == typeof(MapChunk))
            {
                inConfiguration.RegisterClassMap<MapChunkClassMap>();
            }
            else if (typeof(T) == typeof(MapRegion))
            {
                inConfiguration.RegisterClassMap<MapRegionClassMap>();
            }
            else if (typeof(T) == typeof(FloorModel))
            {
                inConfiguration.RegisterClassMap<FloorClassMap>();
            }
            else if (typeof(T) == typeof(BlockModel))
            {
                inConfiguration.RegisterClassMap<BlockClassMap>();
            }
            else if (typeof(T) == typeof(FurnishingModel))
            {
                inConfiguration.RegisterClassMap<FurnishingClassMap>();
            }
            else if (typeof(T) == typeof(CollectibleModel))
            {
                inConfiguration.RegisterClassMap<CollectibleClassMap>();
            }
            else if (typeof(T) == typeof(QuestModel))
            {
                inConfiguration.RegisterClassMap<QuestClassMap>();
            }
            else if (typeof(T) == typeof(RoomRecipe))
            {
                inConfiguration.RegisterClassMap<RoomRecipeClassMap>();
            }
            else if (typeof(T) == typeof(ItemModel))
            {
                inConfiguration.RegisterClassMap<ItemClassMap>();
            }
            else
            {
                throw new ArgumentException($"No class map exists for {typeof(T)}");
            }
        }
    }
}
