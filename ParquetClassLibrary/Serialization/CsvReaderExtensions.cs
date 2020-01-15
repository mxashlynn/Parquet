using System;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using ParquetClassLibrary.Beings;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Crafts;
using ParquetClassLibrary.Interactions;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Parquets;
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
        /// <exception cref="ArgumentException">When there is no shim matching the requested type.</exception>
        public static IEnumerable<T> GetRecordsViaShim<T>(this CsvReader inCSV) where T : EntityModel
        {
            Precondition.IsNotNull(inCSV, nameof(inCSV));

            var models = new List<T>();
            IEnumerable<EntityShim> shims;

            // This is a wonky faux static dispatch, as C# does not provide a clean way to associate two types.
            // IDEA It would be nice to replace this with CRTP if that doesn't overly complicate the EntityModel class hierarchy.
            if (typeof(T) == typeof(PlayerCharacterModel))
            {
                shims = inCSV.GetRecords<PlayerCharacterShim>();
            }
            else if (typeof(T) == typeof(NPCModel))
            {
                shims = inCSV.GetRecords<NPCShim>();
            }
            else if (typeof(T) == typeof(CritterModel))
            {
                shims = inCSV.GetRecords<CritterShim>();
            }
            else if (typeof(T) == typeof(BiomeModel))
            {
                shims = inCSV.GetRecords<BiomeShim>();
            }
            else if (typeof(T) == typeof(CraftingRecipe))
            {
                shims = inCSV.GetRecords<CraftingRecipeShim>();
            }
            else if (typeof(T) == typeof(DialogueModel))
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
            else if (typeof(T) == typeof(FloorModel))
            {
                shims = inCSV.GetRecords<FloorShim>();
            }
            else if (typeof(T) == typeof(BlockModel))
            {
                shims = inCSV.GetRecords<BlockShim>();
            }
            else if (typeof(T) == typeof(FurnishingModel))
            {
                shims = inCSV.GetRecords<FurnishingShim>();
            }
            else if (typeof(T) == typeof(CollectibleModel))
            {
                shims = inCSV.GetRecords<CollectibleShim>();
            }
            else if (typeof(T) == typeof(QuestModel))
            {
                shims = inCSV.GetRecords<QuestShim>();
            }
            else if (typeof(T) == typeof(RoomRecipe))
            {
                shims = inCSV.GetRecords<RoomRecipeShim>();
            }
            else if (typeof(T) == typeof(ItemModel))
            {
                shims = inCSV.GetRecords<ItemShim>();
            }
            else
            {
                throw new ArgumentException($"No shim exists for {typeof(T)}");
            }

            foreach (var shim in shims)
            {
                models.Add(shim.ToEntity<T>());
            }

            return models;
        }
    }
}
