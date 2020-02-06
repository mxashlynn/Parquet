using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Beings;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Crafts;
using ParquetClassLibrary.Interactions;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Rooms;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Serialization
{
    /// <summary>
    /// Provides access to the filesystem in a fashion tailed for the Parquet library.
    /// </summary>
    public static class Serializer
    {
        #region Class Defaults
        /// <summary>Instructions for integer parsing.</summary>
        public const NumberStyles SerializedNumberStyle = NumberStyles.AllowLeadingSign & NumberStyles.Integer;

        /// <summary>Instructions for handling type conversion when reading identifiers.</summary>
        private static TypeConverterOptions IdentifierOptions { get; } = new TypeConverterOptions
        {
            NumberStyle = SerializedNumberStyle
        };

        /// <summary>Mappings for all classes serialized via <see cref="ITypeConverter"/>.</summary>
        private static Dictionary<Type, ITypeConverter> ConversionMapper { get; } = new Dictionary<Type, ITypeConverter>
        {
            // TODO This functionality should be split between All and ModelCollection.

            #region ITypeConverters
            { typeof(Range<int>), Range<int>.ConverterFactory },
            { typeof(Vector2D), Vector2D.ConverterFactory },
            { typeof(EntityID), EntityID.ConverterFactory },
            { typeof(Range<EntityID>), Range<EntityID>.ConverterFactory },
            { typeof(EntityTag), EntityTag.ConverterFactory },
            { typeof(RecipeElement), RecipeElement.ConverterFactory },
            { typeof(PronounGroup), PronounGroup.ConverterFactory },
            { typeof(BiomeModel), BiomeModel.ConverterFactory },
            { typeof(CritterModel), CritterModel.ConverterFactory },
            { typeof(NPCModel), NPCModel.ConverterFactory },
            { typeof(PlayerCharacterModel), PlayerCharacterModel.ConverterFactory },
            { typeof(StrikePanel), StrikePanel.ConverterFactory },
            { typeof(CraftingRecipe), CraftingRecipe.ConverterFactory },
            { typeof(DialogueModel), DialogueModel.ConverterFactory },
            { typeof(QuestModel), QuestModel.ConverterFactory },
            { typeof(InventorySlot), InventorySlot.ConverterFactory },
            { typeof(ItemModel), ItemModel.ConverterFactory },
            { typeof(ChunkType), ChunkType.ConverterFactory },
            { typeof(ExitPoint), ExitPoint.ConverterFactory },
            { typeof(MapChunk), MapChunk.ConverterFactory },
            { typeof(MapRegion), MapRegion.ConverterFactory },
            { typeof(FloorModel), FloorModel.ConverterFactory },
            { typeof(BlockModel), BlockModel.ConverterFactory },
            { typeof(FurnishingModel), FurnishingModel.ConverterFactory },
            { typeof(CollectibleModel), CollectibleModel.ConverterFactory },
            { typeof(ParquetStack), ParquetStack.ConverterFactory },
            { typeof(ParquetStatus), ParquetStatus.ConverterFactory },
            { typeof(RoomRecipe), RoomRecipe.ConverterFactory },
            #endregion

            #region Linear Series Types
            { typeof(IReadOnlyList<EntityID>), SeriesConverter<EntityID, List<EntityID>>.ConverterFactory },
            { typeof(IReadOnlyList<EntityTag>), SeriesConverter<EntityTag, List<EntityTag>>.ConverterFactory },
            { typeof(IReadOnlyList<RecipeElement>), SeriesConverter<RecipeElement, List<RecipeElement>>.ConverterFactory },
            { typeof(IReadOnlyList<ExitPoint>), SeriesConverter<ExitPoint, List<ExitPoint>>.ConverterFactory },
            { typeof(Inventory), SeriesConverter<InventorySlot, Inventory>.ConverterFactory },
            // TODO Finish these
            #endregion

            #region 2D Grid Types
            { typeof(StrikePanelGrid), GridConverter<StrikePanel, StrikePanelGrid>.ConverterFactory },
            { typeof(ChunkTypeGrid), GridConverter<ChunkType, ChunkTypeGrid>.ConverterFactory },
            { typeof(ParquetStackGrid), GridConverter<ParquetStack, ParquetStackGrid>.ConverterFactory },
            { typeof(ParquetStatusGrid), GridConverter<ParquetStatus, ParquetStatusGrid>.ConverterFactory },
            #endregion
        };

        /// <summary>
        /// The location of the designer CSV files, set to either the working directory
        /// or a predefined designer directory, depending on build type.
        /// </summary>
        public static string SearchPath { get; set; } =
#if DEBUG
            $"{Directory.GetCurrentDirectory()}/../../../../Designer";
#else
            Directory.GetCurrentDirectory();
#endif
        #endregion

        #region Serialization
        /// <summary>
        /// Reads all records of the given type from the appropriate file.
        /// </summary>
        /// <typeparam name="TRecord">The type to deserialize.</typeparam>
        /// <returns>The records read.</returns>
        public static IEnumerable<TRecord> GetRecordsForType<TRecord>()
            where TRecord : ITypeConverter
        {
            using var reader = new StreamReader($"{SearchPath}/{typeof(TRecord).Name}s.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Configuration.TypeConverterOptionsCache.AddOptions(typeof(EntityID), IdentifierOptions);
            foreach (var kvp in ConversionMapper)
            {
                csv.Configuration.TypeConverterCache.AddConverter(kvp.Key, kvp.Value);
            }

            return csv.GetRecords<TRecord>();
        }

        /// <summary>
        /// Writes all of the given type to records in the appropriate file.
        /// </summary>
        /// <typeparam name="TRecord">The type to serialize.</typeparam>
        internal static void PutRecordsForType<TRecord>(IEnumerable<TRecord> inInstances)
            where TRecord : ITypeConverter
        {
            using var writer = new StreamWriter($"{SearchPath}/{typeof(TRecord).Name}s.csv");
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.Configuration.TypeConverterOptionsCache.AddOptions(typeof(EntityID), IdentifierOptions);
            foreach (var kvp in ConversionMapper)
            {
                csv.Configuration.TypeConverterCache.AddConverter(kvp.Key, kvp.Value);
            }

            csv.WriteHeader<TRecord>();
            csv.NextRecord();
            csv.WriteRecords(inInstances);
        }
        #endregion
    }
}
