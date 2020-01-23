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
        /// <typeparam name="TRecord">The type to deserialize.</typeparam>
        /// <returns>The records.</returns>
        /// <exception cref="ArgumentException">When there is no shim matching the requested type.</exception>
        public static IEnumerable<TRecord> GetRecordsViaShim<TRecord>(this CsvReader inCSV)
            where TRecord : EntityModel
        {
            Precondition.IsNotNull(inCSV, nameof(inCSV));

            var models = new List<TRecord>();
            IEnumerable<EntityShim> shims;

            // This is a wonky faux static dispatch, as C# does not provide a clean way to associate two types.
            // IDEA It would be nice to replace this with CRTP if that doesn't overly complicate the EntityModel class hierarchy.
            if (typeof(TRecord) == typeof(PlayerCharacterModel))
            {
                shims = inCSV.GetRecords<PlayerCharacterShim>();
            }
            else if (typeof(TRecord) == typeof(NPCModel))
            {
                shims = inCSV.GetRecords<NPCShim>();
            }
            else if (typeof(TRecord) == typeof(CritterModel))
            {
                shims = inCSV.GetRecords<CritterShim>();
            }
            else if (typeof(TRecord) == typeof(BiomeModel))
            {
                shims = inCSV.GetRecords(BiomeModel.GetShimType()).Cast<EntityShim>();
            }
            else if (typeof(TRecord) == typeof(CraftingRecipe))
            {
                shims = inCSV.GetRecords<CraftingRecipeShim>();
            }
            else if (typeof(TRecord) == typeof(DialogueModel))
            {
                shims = inCSV.GetRecords<DialogueShim>();
            }
            else if (typeof(TRecord) == typeof(MapChunk))
            {
                shims = inCSV.GetRecords<MapChunkShim>();
            }
            else if (typeof(TRecord) == typeof(MapRegion))
            {
                shims = inCSV.GetRecords<MapRegionShim>();
            }
            else if (typeof(TRecord) == typeof(FloorModel))
            {
                shims = inCSV.GetRecords<FloorShim>();
            }
            else if (typeof(TRecord) == typeof(BlockModel))
            {
                shims = inCSV.GetRecords<BlockShim>();
            }
            else if (typeof(TRecord) == typeof(FurnishingModel))
            {
                shims = inCSV.GetRecords<FurnishingShim>();
            }
            else if (typeof(TRecord) == typeof(CollectibleModel))
            {
                shims = inCSV.GetRecords<CollectibleShim>();
            }
            else if (typeof(TRecord) == typeof(QuestModel))
            {
                shims = inCSV.GetRecords<QuestShim>();
            }
            else if (typeof(TRecord) == typeof(RoomRecipe))
            {
                shims = inCSV.GetRecords<RoomRecipeShim>();
            }
            else if (typeof(TRecord) == typeof(ItemModel))
            {
                shims = inCSV.GetRecords<ItemShim>();
            }
            else
            {
                throw new ArgumentException($"No shim exists for {typeof(TRecord)}");
            }

            foreach (var shim in shims)
            {
                models.Add(shim.ToEntity<TRecord>());
            }

            return models;
        }
    }
}
