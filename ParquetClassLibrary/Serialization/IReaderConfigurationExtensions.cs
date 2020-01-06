using System;
using CsvHelper.Configuration;
using ParquetClassLibrary.Beings;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Crafting;
using ParquetClassLibrary.Dialogues;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Quests;
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
        public static void RegisterClassMapFor<T>(this IReaderConfiguration inConfiguration) where T : Entity
        {
            Precondition.IsNotNull(inConfiguration, nameof(inConfiguration));

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
            else if (typeof(T) == typeof(Biome))
            {
                inConfiguration.RegisterClassMap<BiomeClassMap>();
            }
            else if (typeof(T) == typeof(CraftingRecipe))
            {
                inConfiguration.RegisterClassMap<CraftingRecipeClassMap>();
            }
            else if (typeof(T) == typeof(Dialogue))
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
            else if (typeof(T) == typeof(Floor))
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
            else if (typeof(T) == typeof(Quest))
            {
                inConfiguration.RegisterClassMap<QuestClassMap>();
            }
            else if (typeof(T) == typeof(RoomRecipe))
            {
                inConfiguration.RegisterClassMap<RoomRecipeClassMap>();
            }
            else if (typeof(T) == typeof(Item))
            {
                inConfiguration.RegisterClassMap<ItemClassMap>();
            }
            else
            {
                Console.WriteLine($"No class map exists for {typeof(T)}");
            }
        }
    }
}
