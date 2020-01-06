using System;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using ParquetClassLibrary.Beings;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Crafting;
using ParquetClassLibrary.Dialogues;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Quests;
using ParquetClassLibrary.Rooms;
using ParquetClassLibrary.Serialization.Shims;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Serialization
{
    /// <summary>
    /// Provides extensions to the <see cref="CsvReader"/>.
    /// </summary>
    public static class CsvReaderExtensions
    {
        /// <summary>
        /// Gets a set of records from the CSV Reader using the shim class that corresponds to the given type.
        /// </summary>
        /// <param name="inCSV">In CSV Reader.</param>
        /// <typeparam name="T">The type of the record.</typeparam>
        /// <returns>The records.</returns>
        public static IEnumerable<T> GetRecordsViaShim<T>(this CsvReader inCSV) where T : Entity
        {
            Precondition.IsNotNull(inCSV, nameof(inCSV));

            var result = new List<T>();
            IEnumerable<EntityShim> shims;

            if (typeof(T) == typeof(PlayerCharacter))
            {
                shims = inCSV.GetRecords<PlayerCharacterShim>();
            }
            else if (typeof(T) == typeof(NPC))
            {
                shims = inCSV.GetRecords<NPCShim>();
            }
            else if (typeof(T) == typeof(Critter))
            {
                shims = inCSV.GetRecords<CritterShim>();
            }
            else if (typeof(T) == typeof(Biome))
            {
                shims = inCSV.GetRecords<BiomeShim>();
            }
            else if (typeof(T) == typeof(CraftingRecipe))
            {
                shims = inCSV.GetRecords<CraftingRecipeShim>();
            }
            else if (typeof(T) == typeof(Dialogue))
            {
                shims = inCSV.GetRecords<DialogueShim>();
            }
            else if (typeof(T) == typeof(MapChunk))
            {
                shims = inCSV.GetRecords<MapChunkShim>();
            }
            else if (typeof(T) == typeof(MapRegion))
            {
                shims = inCSV.GetRecords<MapRegionShim>();
            }
            else if (typeof(T) == typeof(Floor))
            {
                shims = inCSV.GetRecords<FloorShim>();
            }
            else if (typeof(T) == typeof(Block))
            {
                shims = inCSV.GetRecords<BlockShim>();
            }
            else if (typeof(T) == typeof(Furnishing))
            {
                shims = inCSV.GetRecords<FurnishingShim>();
            }
            else if (typeof(T) == typeof(Collectible))
            {
                shims = inCSV.GetRecords<CollectibleShim>();
            }
            else if (typeof(T) == typeof(Quest))
            {
                shims = inCSV.GetRecords<QuestShim>();
            }
            else if (typeof(T) == typeof(RoomRecipe))
            {
                shims = inCSV.GetRecords<RoomRecipeShim>();
            }
            else if (typeof(T) == typeof(Item))
            {
                shims = inCSV.GetRecords<ItemShim>();
            }
            else
            {
                shims = Enumerable.Empty<EntityShim>();
                Console.WriteLine($"No shim exists for {typeof(T)}");
            }

            foreach (var shim in shims)
            {
                result.Add(shim.ToEntity<T>());
            }

            return result;
        }
    }
}
