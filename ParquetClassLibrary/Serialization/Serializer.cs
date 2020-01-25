using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Beings;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Crafts;
using ParquetClassLibrary.Interactions;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Rooms;

namespace ParquetClassLibrary.Serialization
{
    /// <summary>
    /// Provides access to the filesystem in a fashion tailed for the Parquet library.
    /// </summary>
    public static class Serializer
    {
        /// <summary>Used to separate objects within collections.</summary>
        public const string SecondaryDelimiter = ";";

        /// <summary>Instructions for handling integer type conversion when reading in identifiers.</summary>
        private static TypeConverterOptions IdentifierOptions { get; } = new TypeConverterOptions
        {
            NumberStyle = NumberStyles.AllowLeadingSign &
                          NumberStyles.Integer
        };

        /// <summary>Mappings for all serializable classes.</summary>
        private static Dictionary<Type, ClassMap> ClassMapper { get; } = new Dictionary<Type, ClassMap>
        {
            { typeof(PronounGroup), PronounGroup.GetClassMap() },
            { typeof(CritterModel), CritterModel.GetClassMap() },
            { typeof(NPCModel), NPCModel.GetClassMap() },
            { typeof(PlayerCharacterModel), PlayerCharacterModel.GetClassMap() },
            { typeof(BiomeModel), BiomeModel.GetClassMap() },
            { typeof(CraftingRecipe), CraftingRecipe.GetClassMap() },
            { typeof(DialogueModel), DialogueModel.GetClassMap() },
            { typeof(QuestModel), QuestModel.GetClassMap() },
            { typeof(MapChunk), MapChunk.GetClassMap() },
            { typeof(MapRegion), MapRegion.GetClassMap() },
            { typeof(FloorModel), FloorModel.GetClassMap() },
            { typeof(BlockModel), BlockModel.GetClassMap() },
            { typeof(FurnishingModel), FurnishingModel.GetClassMap() },
            { typeof(CollectibleModel), CollectibleModel.GetClassMap() },
            { typeof(RoomRecipe), RoomRecipe.GetClassMap() },
            { typeof(ItemModel), ItemModel.GetClassMap() },
        };

        /// <summary>Mappings for all serialization shims.</summary>
        private static Dictionary<Type, Type> ShimMapper { get; } = new Dictionary<Type, Type>
        {
            { typeof(PronounGroup), PronounGroup.GetShimType() },
            { typeof(CritterModel), CritterModel.GetShimType() },
            { typeof(NPCModel), NPCModel.GetShimType() },
            { typeof(PlayerCharacterModel), PlayerCharacterModel.GetShimType() },
            { typeof(BiomeModel), BiomeModel.GetShimType() },
            { typeof(CraftingRecipe), CraftingRecipe.GetShimType() },
            { typeof(DialogueModel), DialogueModel.GetShimType() },
            { typeof(QuestModel), QuestModel.GetShimType() },
            { typeof(MapChunk), MapChunk.GetShimType() },
            { typeof(MapRegion), MapRegion.GetShimType() },
            { typeof(FloorModel), FloorModel.GetShimType() },
            { typeof(BlockModel), BlockModel.GetShimType() },
            { typeof(FurnishingModel), FurnishingModel.GetShimType() },
            { typeof(CollectibleModel), CollectibleModel.GetShimType() },
            { typeof(RoomRecipe), RoomRecipe.GetShimType() },
            { typeof(ItemModel), ItemModel.GetShimType() },
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


        /// <summary>
        /// Reads all records of the given type from the appropriate file.
        /// </summary>
        /// <typeparam name="TRecord">The type to deserialize.</typeparam>
        /// <returns>The records read.</returns>
        public static IEnumerable<TRecord> GetRecordsForType<TRecord>()
            where TRecord : ShimProvider
        {
            var records = new HashSet<TRecord>();
            using (var reader = new StreamReader($"{SearchPath}/{typeof(TRecord).Name}s.csv"))
            {
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                csv.Configuration.TypeConverterCache.AddConverter(typeof(EntityID), new EntityID());
                csv.Configuration.TypeConverterCache.AddConverter(typeof(EntityTag), new EntityTag());
                csv.Configuration.TypeConverterCache.AddConverter(typeof(RecipeElement), new RecipeElement());
                csv.Configuration.TypeConverterCache.AddConverter(typeof(IReadOnlyList<EntityID>), new SeriesConverter<EntityID, List<EntityID>>());
                csv.Configuration.TypeConverterCache.AddConverter(typeof(IReadOnlyList<EntityTag>), new SeriesConverter<EntityTag, List<EntityTag>>());
                csv.Configuration.TypeConverterCache.AddConverter(typeof(IReadOnlyList<RecipeElement>), new SeriesConverter<RecipeElement, List<RecipeElement>>());
                csv.Configuration.TypeConverterCache.AddConverter(typeof(StrikePanelGrid), new GridConverter<StrikePanel, StrikePanelGrid>());
                csv.Configuration.TypeConverterOptionsCache.AddOptions(typeof(EntityID), IdentifierOptions);
                csv.Configuration.RegisterClassMap(ClassMapper[typeof(TRecord)]);

                var shims = csv.GetRecords(ShimMapper[typeof(TRecord)]).Cast<ShimProvider.Shim>();
                foreach (var shim in shims)
                {
                    records.Add(shim.ToInstance<TRecord>());
                }
            }

            return records;
        }
    }
}
