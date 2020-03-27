using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Beings;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Crafts;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Rooms;
using ParquetClassLibrary.Scripts;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary
{
    /// <summary>
    /// Provides content and identifiers for the game.
    /// </summary>
    /// <remarks>
    /// This is the source of truth about game objects whose definitions do not change during play.<para />
    /// For more details, see remarks on <see cref="Model"/>.
    /// </remarks>
    /// <seealso cref="ModelID"/>
    /// <seealso cref="ModelCollection{T}"/>
    public static class All
    {
        /// <summary><c>true</c> if the collections have been initialized; otherwise, <c>false</c>.</summary>
        public static bool CollectionsHaveBeenInitialized { get; private set; }

        #region Serialization Lookup Tables
        /// <summary>
        /// The location of the designer CSV files, set to either the working directory
        /// or a predefined designer directory, depending on build type.
        /// </summary>
        public static string WorkingDirectory { get; }

        /// <summary>Instructions for integer parsing.</summary>
        internal const NumberStyles SerializedNumberStyle = NumberStyles.AllowLeadingSign & NumberStyles.Integer;

        /// <summary>Instructions for string parsing.</summary>
        internal static CultureInfo SerializedCultureInfo { get; }

        /// <summary>Instructions for handling type conversion when reading identifiers.</summary>
        internal static TypeConverterOptions IdentifierOptions { get; }

        /// <summary>Mappings for all classes serialized via <see cref="ITypeConverter"/>.</summary>
        internal static Dictionary<Type, ITypeConverter> ConversionConverters { get; }
        #endregion

        #region ModelID Ranges
        /// <summary>
        /// A subset of the values of <see cref="ModelID"/> set aside for identifying active players.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test characters.
        /// </summary>
        public static readonly Range<ModelID> PlayerIDs;

        /// <summary>
        /// A subset of the values of <see cref="ModelID"/> set aside for <see cref="Beings.CritterModel"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Critters.
        /// </summary>
        public static readonly Range<ModelID> CritterIDs;

        /// <summary>
        /// A subset of the values of <see cref="ModelID"/> set aside for <see cref="Beings.CharacterModel"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test NPCs.
        /// </summary>
        public static readonly Range<ModelID> CharacterIDs;

        /// <summary>
        /// A collection containing all defined <see cref="Range{ModelID}"/>s of <see cref="Beings.BeingModel"/>s.
        /// </summary>
        public static readonly IReadOnlyList<Range<ModelID>> BeingIDs;

        /// <summary>
        /// A subset of the values of <see cref="ModelID"/> set aside for <see cref="BiomeModel"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Biomes.
        /// </summary>
        public static readonly Range<ModelID> BiomeIDs;

        /// <summary>
        /// A subset of the values of <see cref="ModelID"/> set aside for <see cref="CraftingRecipe"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test recipes.
        /// </summary>
        public static readonly Range<ModelID> CraftingRecipeIDs;

        /// <summary>
        /// A subset of the values of <see cref="ModelID"/> set aside for <see cref="InteractionModel"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test recipes.
        /// </summary>
        public static readonly Range<ModelID> InteractionIDs;

        /// <summary>
        /// A subset of the values of <see cref="ModelID"/> set aside for <see cref="MapChunk"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Items.
        /// </summary>
        public static readonly Range<ModelID> MapChunkIDs;

        /// <summary>
        /// A subset of the values of <see cref="ModelID"/> set aside for <see cref="MapRegion"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Items.
        /// </summary>
        public static readonly Range<ModelID> MapRegionIDs;

        /// <summary>
        /// A subset of the values of <see cref="ModelID"/> set aside for <see cref="MapModel"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Items.
        /// </summary>
        public static readonly IReadOnlyList<Range<ModelID>> MapIDs;

        /// <summary>
        /// A subset of the values of <see cref="ModelID"/> set aside for <see cref="FloorModel"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test parquets.
        /// </summary>
        public static readonly Range<ModelID> FloorIDs;

        /// <summary>
        /// A subset of the values of <see cref="ModelID"/> set aside for <see cref="BlockModel"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test parquets.
        /// </summary>
        public static readonly Range<ModelID> BlockIDs;

        /// <summary>
        /// A subset of the values of <see cref="ModelID"/> set aside for <see cref="FurnishingModel"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test parquets.
        /// </summary>
        public static readonly Range<ModelID> FurnishingIDs;

        /// <summary>
        /// A subset of the values of <see cref="ModelID"/> set aside for <see cref="CollectibleModel"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test parquets.
        /// </summary>
        public static readonly Range<ModelID> CollectibleIDs;

        /// <summary>
        /// A collection containing all defined <see cref="Range{ModelID}"/>s of parquets.
        /// </summary>
        public static readonly IReadOnlyList<Range<ModelID>> ParquetIDs;

        /// <summary>
        /// A subset of the values of <see cref="ModelID"/> set aside for <see cref="RoomRecipe"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test recipes.
        /// </summary>
        public static readonly Range<ModelID> RoomRecipeIDs;

        /// <summary>
        /// A subset of the values of <see cref="ModelID"/> set aside for <see cref="Scripts.ScriptModel"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Items.
        /// </summary>
        public static readonly Range<ModelID> ScriptIDs;

        /// <summary>
        /// A subset of the values of <see cref="ModelID"/> set aside for <see cref="ItemModel"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Items.
        /// </summary>
        public static readonly Range<ModelID> ItemIDs;
        #endregion

        #region ModelCollections
        /// <summary>
        /// A collection of all defined <see cref="BeingModel"/>s.
        /// This collection is the source of truth about mobs and characters for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="ModelID"/>s must be unique.</remarks>
        public static ModelCollection<BeingModel> Beings { get; private set; }

        /// <summary>
        /// A collection of all defined <see cref="BiomeModel"/>s.
        /// This collection is the source of truth about biome for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="ModelID"/>s must be unique.</remarks>
        public static ModelCollection<BiomeModel> Biomes { get; private set; }

        /// <summary>
        /// A collection of all defined <see cref="CraftingRecipe"/>s.
        /// This collection is the source of truth about crafting for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="ModelID"/>s must be unique.</remarks>
        public static ModelCollection<CraftingRecipe> CraftingRecipes { get; private set; }

        /// <summary>
        /// A collection of all defined <see cref="InteractionModel"/>s.
        /// This collection is the source of truth about crafting for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="ModelID"/>s must be unique.</remarks>
        public static ModelCollection<InteractionModel> Interactions { get; private set; }

        /// <summary>
        /// A collection of all defined <see cref="MapModel"/>s.
        /// This collection is the source of truth about biome for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="ModelID"/>s must be unique.</remarks>
        public static ModelCollection<MapModel> Maps { get; private set; }

        /// <summary>
        /// A collection of all defined parquets of all subtypes.
        /// This collection is the source of truth about parquets for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="ModelID"/>s must be unique.</remarks>
        public static ModelCollection<ParquetModel> Parquets { get; private set; }

        /// <summary>
        /// A collection of all defined <see cref="RoomRecipe"/>s.
        /// This collection is the source of truth about crafting for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="ModelID"/>s must be unique.</remarks>
        public static ModelCollection<RoomRecipe> RoomRecipes { get; private set; }

        /// <summary>
        /// A collection of all defined <see cref="ScriptModel"/>s.
        /// This collection is the source of truth about crafting for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="ModelID"/>s must be unique.</remarks>
        public static ModelCollection<ScriptModel> Scripts { get; private set; }

        /// <summary>
        /// A collection of all defined <see cref="ItemModel"/>s.
        /// This collection is the source of truth about items for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="ModelID"/>s must be unique.</remarks>
        public static ModelCollection<ItemModel> Items { get; private set; }
        #endregion

        #region Other Collections
        /// <summary>
        /// A collection of all defined <see cref="PronounGroup"/>s.
        /// This collection is the source of truth about pronouns for the rest of the library.
        /// </summary>
        public static IReadOnlyCollection<PronounGroup> PronounGroups { get; private set; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes the <see cref="Range{T}"/>s and <see cref="ModelCollection{T}"/>s defined in <see cref="All"/>.
        /// </summary>
        /// <remarks>
        /// This supports defining ItemIDs in terms of the other Ranges.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance",
            "CA1810:Initialize reference type static fields inline",
            Justification = "Inline initializers would notably complicate the code in this instance.")]
        static All()
        {
            #region Default Values for Collections
            CollectionsHaveBeenInitialized = false;
            Beings = ModelCollection<BeingModel>.Default;
            Biomes = ModelCollection<BiomeModel>.Default;
            CraftingRecipes = ModelCollection<CraftingRecipe>.Default;
            Interactions = ModelCollection<InteractionModel>.Default;
            Maps = ModelCollection<MapModel>.Default;
            Parquets = ModelCollection<ParquetModel>.Default;
            RoomRecipes = ModelCollection<RoomRecipe>.Default;
            Items = ModelCollection<ItemModel>.Default;

            PronounGroups = new HashSet<PronounGroup>();
            #endregion

            #region Initialize Ranges
            ///<summary>By convention, the first ModelID in each Range is a multiple of this number.</summary>
            const int TargetMultiple = 10000;

            #region Define Most Ranges
            PlayerIDs = new Range<ModelID>(1, 9000);

            CritterIDs = new Range<ModelID>(10000, 19000);
            CharacterIDs = new Range<ModelID>(20000, 29000);

            BiomeIDs = new Range<ModelID>(30000, 39000);

            CraftingRecipeIDs = new Range<ModelID>(40000, 49000);

            InteractionIDs = new Range<ModelID>(50000, 59000);

            MapChunkIDs = new Range<ModelID>(70000, 79000);
            MapRegionIDs = new Range<ModelID>(80000, 89000);

            FloorIDs = new Range<ModelID>(90000, 99000);
            BlockIDs = new Range<ModelID>(100000, 109000);
            FurnishingIDs = new Range<ModelID>(110000, 119000);
            CollectibleIDs = new Range<ModelID>(120000, 129000);

            RoomRecipeIDs = new Range<ModelID>(130000, 139000);

            ScriptIDs = new Range<ModelID>(140000, 149000);
            #endregion

            #region Define Range Collections
            BeingIDs = new List<Range<ModelID>> { CritterIDs, CharacterIDs };
            MapIDs = new List<Range<ModelID>> { MapChunkIDs, MapRegionIDs };
            ParquetIDs = new List<Range<ModelID>> { FloorIDs, BlockIDs, FurnishingIDs, CollectibleIDs };
            #endregion

            #region Calculate Item Range
            // The largest Range.Maximum defined in All, excluding ItemIDs.
            int MaximumIDNotCountingItems = typeof(All).GetFields()
                .Where(fieldInfo => fieldInfo.FieldType.IsGenericType
                    && fieldInfo.FieldType == typeof(Range<ModelID>)
                    && fieldInfo.Name != nameof(ItemIDs))
                .Select(fieldInfo => fieldInfo.GetValue(null))
                .Cast<Range<ModelID>>()
                .Select(range => range.Maximum)
                .Max();

            // Since ItemIDs is being defined at runtime, its Range.Minimum must be chosen well above existing maxima.
            var ItemLowerBound = TargetMultiple * ((MaximumIDNotCountingItems + (TargetMultiple - 1)) / TargetMultiple);

            // The smallest Range.Minimum of any parquet IDs.
            int MinimumParquetID = ParquetIDs
                .Select(range => range.Minimum)
                .Min();

            // The largest Range.Maximum of any parquet IDs.
            int MaximumParquetID = ParquetIDs
                .Select(range => range.Maximum)
                .Max();

            // Since it is possible for every parquet to have a corresponding item, this range must be at least
            // as large as all four parquet ranges put together.  Therefore, the Range.Maximum is twice the combined
            // ranges of all parquets.
            var ItemUpperBound = (TargetMultiple / 10) + ItemLowerBound + 2 * (MaximumParquetID - MinimumParquetID);

            ItemIDs = new Range<ModelID>(ItemLowerBound, ItemUpperBound);
            #endregion
            #endregion

            #region Initialize Serialization Values & Lookup Tables
            WorkingDirectory =
#if DEBUG
                $"{Directory.GetCurrentDirectory()}/../../../../Designer";
#else
                Directory.GetCurrentDirectory();
#endif

            SerializedCultureInfo = CultureInfo.InvariantCulture;

            IdentifierOptions = new TypeConverterOptions
            {
                NumberStyle = SerializedNumberStyle,
                CultureInfo = SerializedCultureInfo,
            };

            ConversionConverters = new Dictionary<Type, ITypeConverter>
            {
                #region ITypeConverters
                { typeof(ChunkType), ChunkType.ConverterFactory },
                { typeof(ModelID), ModelID.ConverterFactory },
                { typeof(ModelTag), ModelTag.ConverterFactory },
                { typeof(ExitPoint), ExitPoint.ConverterFactory },
                { typeof(InventorySlot), InventorySlot.ConverterFactory },
                { typeof(ParquetStack), ParquetStack.ConverterFactory },
                { typeof(ParquetStatus), ParquetStatus.ConverterFactory },
                { typeof(Range<ModelID>), Range<ModelID>.ConverterFactory },
                { typeof(Range<int>), Range<int>.ConverterFactory },
                { typeof(RecipeElement), RecipeElement.ConverterFactory },
                { typeof(StrikePanel), StrikePanel.ConverterFactory },
                { typeof(Vector2D), Vector2D.ConverterFactory },
                #endregion

                #region Linear Series Types
                { typeof(IEnumerable<ModelID>), SeriesConverter<ModelID, List<ModelID>>.ConverterFactory },
                { typeof(IEnumerable<ModelTag>), SeriesConverter<ModelTag, List<ModelTag>>.ConverterFactory },
                { typeof(IEnumerable<ExitPoint>), SeriesConverter<ExitPoint, List<ExitPoint>>.ConverterFactory },
                { typeof(IEnumerable<InventorySlot>), SeriesConverter<InventorySlot, List<InventorySlot>>.ConverterFactory },
                { typeof(IEnumerable<RecipeElement>), SeriesConverter<RecipeElement, List<RecipeElement>>.ConverterFactory },
                { typeof(IReadOnlyList<ModelID>), SeriesConverter<ModelID, List<ModelID>>.ConverterFactory },
                { typeof(IReadOnlyList<ModelTag>), SeriesConverter<ModelTag, List<ModelTag>>.ConverterFactory },
                { typeof(IReadOnlyList<ExitPoint>), SeriesConverter<ExitPoint, List<ExitPoint>>.ConverterFactory },
                { typeof(IReadOnlyList<InventorySlot>), SeriesConverter<InventorySlot, List<InventorySlot>>.ConverterFactory },
                { typeof(IReadOnlyList<RecipeElement>), SeriesConverter<RecipeElement, List<RecipeElement>>.ConverterFactory },
                { typeof(List<ExitPoint>), SeriesConverter<ExitPoint, List<ExitPoint>>.ConverterFactory },
                #endregion

                #region 2D Grid Types
                { typeof(ChunkTypeGrid), GridConverter<ChunkType, ChunkTypeGrid>.ConverterFactory },
                { typeof(ParquetStackGrid), GridConverter<ParquetStack, ParquetStackGrid>.ConverterFactory },
                { typeof(ParquetStatusGrid), GridConverter<ParquetStatus, ParquetStatusGrid>.ConverterFactory },
                { typeof(StrikePanelGrid), GridConverter<StrikePanel, StrikePanelGrid>.ConverterFactory },
                #endregion
            };
            #endregion
        }

        /// <summary>
        /// Initializes the <see cref="ModelCollection{T}s"/> from the given collections.
        /// </summary>
        /// <param name="inPronouns">The pronouns that the game knows by default.</param>
        /// <param name="inBeings">All beings to be used in the game.</param>
        /// <param name="inBiomes">All biomes to be used in the game.</param>
        /// <param name="inCraftingRecipes">All crafting recipes to be used in the game.</param>
        /// <param name="inInteractions">All interactions to be used in the game.</param>
        /// <param name="inMaps">All maps to be used in the game.</param>
        /// <param name="inParquets">All parquets to be used in the game.</param>
        /// <param name="inRoomRecipes">All room recipes to be used in the game.</param>
        /// <param name="inScripts">All scripts to be used in the game.</param>
        /// <param name="inItems">All items to be used in the game.</param>
        /// <remarks>This initialization routine may be called only once per library execution.</remarks>
        /// <exception cref="InvalidOperationException">When called more than once.</exception>
        public static void InitializeCollections(IEnumerable<PronounGroup> inPronouns,
                                                 IEnumerable<BeingModel> inBeings,
                                                 IEnumerable<BiomeModel> inBiomes,
                                                 IEnumerable<CraftingRecipe> inCraftingRecipes,
                                                 IEnumerable<InteractionModel> inInteractions,
                                                 IEnumerable<MapModel> inMaps,
                                                 IEnumerable<ParquetModel> inParquets,
                                                 IEnumerable<RoomRecipe> inRoomRecipes,
                                                 IEnumerable<ScriptModel> inScripts,
                                                 IEnumerable<ItemModel> inItems)
        {
            if (CollectionsHaveBeenInitialized)
            {
                throw new InvalidOperationException($"Attempted to reinitialize {typeof(All)}.");
            }
            Precondition.IsNotNull(inPronouns, nameof(inPronouns));
            Precondition.IsNotNull(inBeings, nameof(inBeings));
            Precondition.IsNotNull(inBiomes, nameof(inBiomes));
            Precondition.IsNotNull(inCraftingRecipes, nameof(inCraftingRecipes));
            Precondition.IsNotNull(inInteractions, nameof(inInteractions));
            Precondition.IsNotNull(inMaps, nameof(inMaps));
            Precondition.IsNotNull(inParquets, nameof(inParquets));
            Precondition.IsNotNull(inRoomRecipes, nameof(inRoomRecipes));
            Precondition.IsNotNull(inScripts, nameof(inScripts));
            Precondition.IsNotNull(inItems, nameof(inItems));

            Beings = new ModelCollection<BeingModel>(BeingIDs, inBeings);
            Biomes = new ModelCollection<BiomeModel>(BiomeIDs, inBiomes);
            CraftingRecipes = new ModelCollection<CraftingRecipe>(CraftingRecipeIDs, inCraftingRecipes);
            Interactions = new ModelCollection<InteractionModel>(InteractionIDs, inInteractions);
            Maps = new ModelCollection<MapModel>(MapIDs, inMaps);
            Parquets = new ModelCollection<ParquetModel>(ParquetIDs, inParquets);
            RoomRecipes = new ModelCollection<RoomRecipe>(RoomRecipeIDs, inRoomRecipes);
            Scripts = new ModelCollection<ScriptModel>(ScriptIDs, inScripts);
            Items = new ModelCollection<ItemModel>(ItemIDs, inItems);
            PronounGroups = new HashSet<PronounGroup>(inPronouns);
            CollectionsHaveBeenInitialized = true;
        }
        #endregion

        #region Serialization
        /// <summary>
        /// Initializes <see cref="All"/> based on the values in design-time CSV files.
        /// </summary>
        public static void LoadFromCSV()
        {
            var pronounGroups = PronounGroup.GetRecords();
            var beings = ModelCollection<BeingModel>.ConverterFactory.GetRecordsForType<CritterModel>(BeingIDs)
                .Concat(ModelCollection<BeingModel>.ConverterFactory.GetRecordsForType<CharacterModel>(BeingIDs));
            var biomes = ModelCollection<BiomeModel>.ConverterFactory.GetRecordsForType<BiomeModel>(BiomeIDs);
            var craftingRecipes = ModelCollection<CraftingRecipe>.ConverterFactory.GetRecordsForType<CraftingRecipe>(CraftingRecipeIDs);
            var interactions = ModelCollection<InteractionModel>.ConverterFactory.GetRecordsForType<InteractionModel>(InteractionIDs);
            var maps = ModelCollection<MapModel>.ConverterFactory.GetRecordsForType<MapChunk>(MapIDs)
                .Concat(ModelCollection<MapModel>.ConverterFactory.GetRecordsForType<MapRegionSketch>(MapIDs))
                .Concat(ModelCollection<MapModel>.ConverterFactory.GetRecordsForType<MapRegion>(MapIDs));
            var parquets = ModelCollection<ParquetModel>.ConverterFactory.GetRecordsForType<FloorModel>(ParquetIDs)
                .Concat(ModelCollection<ParquetModel>.ConverterFactory.GetRecordsForType<BlockModel>(ParquetIDs))
                .Concat(ModelCollection<ParquetModel>.ConverterFactory.GetRecordsForType<FurnishingModel>(ParquetIDs))
                .Concat(ModelCollection<ParquetModel>.ConverterFactory.GetRecordsForType<CollectibleModel>(ParquetIDs));
            var roomRecipes = ModelCollection<RoomRecipe>.ConverterFactory.GetRecordsForType<RoomRecipe>(RoomRecipeIDs);
            var scripts = ModelCollection<ScriptModel>.ConverterFactory.GetRecordsForType<ScriptModel>(RoomRecipeIDs);
            var items = ModelCollection<ItemModel>.ConverterFactory.GetRecordsForType<ItemModel>(ItemIDs);

            InitializeCollections(pronounGroups, beings, biomes, craftingRecipes, interactions, maps, parquets, roomRecipes, scripts, items);
        }

        /// <summary>
        /// Stores the content of <see cref="All"/> to CSV files for later reinitialization.
        /// </summary>
        public static void SaveToCSV()
        {
            PronounGroup.PutRecords(PronounGroups);
            Beings.PutRecordsForType<CritterModel>();
            Beings.PutRecordsForType<CharacterModel>();
            Biomes.PutRecordsForType<BiomeModel>();
            CraftingRecipes.PutRecordsForType<CraftingRecipe>();
            Interactions.PutRecordsForType<InteractionModel>();
            Maps.PutRecordsForType<MapChunk>();
            Maps.PutRecordsForType<MapRegionSketch>();
            Maps.PutRecordsForType<MapRegion>();
            Parquets.PutRecordsForType<FloorModel>();
            Parquets.PutRecordsForType<BlockModel>();
            Parquets.PutRecordsForType<FurnishingModel>();
            Parquets.PutRecordsForType<CollectibleModel>();
            RoomRecipes.PutRecordsForType<RoomRecipe>();
            Items.PutRecordsForType<ItemModel>();
        }
        #endregion
    }
}
