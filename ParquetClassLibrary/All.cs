using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Beings;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Crafts;
using ParquetClassLibrary.EditorSupport;
using ParquetClassLibrary.Games;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Properties;
using ParquetClassLibrary.Rooms;
using ParquetClassLibrary.Scripts;

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

        /// <summary>The location of the game data files.  Defaults to the current application's working directory.</summary>
        public static string ProjectDirectory { get; set; }

        #region Serialization Lookup Tables
        /// <summary>Instructions for integer parsing.</summary>
        internal const NumberStyles SerializedNumberStyle = NumberStyles.AllowLeadingSign & NumberStyles.Integer;

        /// <summary>Instructions for handling type conversion when reading identifiers.</summary>
        internal static TypeConverterOptions IdentifierOptions { get; }

        /// <summary>Mappings for all classes serialized via <see cref="ITypeConverter"/>.</summary>
        internal static Dictionary<Type, ITypeConverter> ConversionConverters { get; }
        #endregion

        #region ModelID Ranges
        /// <summary>
        /// A subset of the values of <see cref="ModelID"/> set aside for identifying <see cref="GameModel"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test characters.
        /// </summary>
        public static readonly Range<ModelID> GameIDs;

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
        /// A subset of the values of <see cref="ModelID"/> set aside for <see cref="BiomeRecipe"/>s.
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
        /// A subset of the values of <see cref="ModelID"/> set aside for <see cref="MapChunkModel"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Items.
        /// </summary>
        public static readonly Range<ModelID> MapChunkIDs;

        /// <summary>
        /// A subset of the values of <see cref="ModelID"/> set aside for <see cref="MapRegionModel"/>s.
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

        /// <summary>
        /// A collection containing all defined <see cref="Range{ModelID}"/>s.
        /// </summary>
        public static readonly IReadOnlyList<Range<ModelID>> AllDefinedIDs;
        #endregion

        #region ModelCollections
        /// <summary>
        /// A collection of all defined <see cref="CharacterModel"/>s.
        /// This collection is the source of truth about mobs and characters for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="ModelID"/>s must be unique.</remarks>
        public static ModelCollection<CharacterModel> Characters { get; private set; }

        /// <summary>
        /// A collection of all defined <see cref="CritterModel"/>s.
        /// This collection is the source of truth about mobs and characters for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="ModelID"/>s must be unique.</remarks>
        public static ModelCollection<CritterModel> Critters { get; private set; }

        /// <summary>
        /// A collection of all defined <see cref="BiomeRecipe"/>s.
        /// This collection is the source of truth about biome for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="ModelID"/>s must be unique.</remarks>
        public static ModelCollection<BiomeRecipe> Biomes { get; private set; }

        /// <summary>
        /// A collection of all defined <see cref="CraftingRecipe"/>s.
        /// This collection is the source of truth about crafting for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="ModelID"/>s must be unique.</remarks>
        public static ModelCollection<CraftingRecipe> CraftingRecipes { get; private set; }

        /// <summary>
        /// A collection of all defined <see cref="GameModel"/>s.
        /// This collection is the source of truth about crafting for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="ModelID"/>s must be unique.</remarks>
        public static ModelCollection<GameModel> Games { get; private set; }

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
        [SuppressMessage("Performance", "CA1810:Initialize reference type static fields inline",
                         Justification = "Inline initializers would notably complicate the code in this instance.")]
        static All()
        {
            #region Default Values for Collections
            CollectionsHaveBeenInitialized = false;
            Characters = ModelCollection<CharacterModel>.Default;
            Critters = ModelCollection<CritterModel>.Default;
            Biomes = ModelCollection<BiomeRecipe>.Default;
            CraftingRecipes = ModelCollection<CraftingRecipe>.Default;
            Interactions = ModelCollection<InteractionModel>.Default;
            Maps = ModelCollection<MapModel>.Default;
            Parquets = ModelCollection<ParquetModel>.Default;
            RoomRecipes = ModelCollection<RoomRecipe>.Default;
            Items = ModelCollection<ItemModel>.Default;

            PronounGroups = new HashSet<PronounGroup>();
            #endregion

            #region Initialize Ranges
            // By convention, the first ModelID in each Range is a multiple of this number.
            const int TargetMultiple = 10000;

            // Note: The order of the definitions and computations in the following regions is important.

            #region Define Most Ranges
            GameIDs = new Range<ModelID>(1, 9000);

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

            #region Define Most Range Collections
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
            var ItemUpperBound = (TargetMultiple / 10) + ItemLowerBound + (2 * (MaximumParquetID - MinimumParquetID));

            ItemIDs = new Range<ModelID>(ItemLowerBound, ItemUpperBound);
            #endregion

            #region Define Collection of All Ranges
            AllDefinedIDs = new List<Range<ModelID>>
            {
                GameIDs,
                CritterIDs,
                CharacterIDs,
                BiomeIDs,
                CraftingRecipeIDs,
                InteractionIDs,
                MapChunkIDs,
                MapRegionIDs,
                FloorIDs,
                BlockIDs,
                FurnishingIDs,
                CollectibleIDs,
                RoomRecipeIDs,
                ScriptIDs
            };
            #endregion
            #endregion

            #region Initialize Serialization Values & Lookup Tables
            ProjectDirectory =
#if DEBUG
                Path.GetFullPath($"{Directory.GetCurrentDirectory()}/../../../../ExampleData");
#else
                Path.GetFullPath(Directory.GetCurrentDirectory());
#endif

            IdentifierOptions = new TypeConverterOptions
            {
                NumberStyle = SerializedNumberStyle,
                CultureInfo = CultureInfo.InvariantCulture,
            };

            ConversionConverters = new Dictionary<Type, ITypeConverter>
            {
                #region ITypeConverters
                { typeof(ChunkDetail), ChunkDetail.ConverterFactory },
                { typeof(ModelID), ModelID.ConverterFactory },
                { typeof(ModelTag), ModelTag.ConverterFactory },
                { typeof(InventorySlot), InventorySlot.ConverterFactory },
                { typeof(ParquetStack), ParquetStack.ConverterFactory },
                { typeof(ParquetStatus), ParquetStatus.ConverterFactory },
                { typeof(Range<ModelID>), Range<ModelID>.ConverterFactory },
                { typeof(Range<int>), Range<int>.ConverterFactory },
                { typeof(RecipeElement), RecipeElement.ConverterFactory },
                { typeof(ScriptNode), ScriptNode.ConverterFactory },
                { typeof(StrikePanel), StrikePanel.ConverterFactory },
                { typeof(Vector2D), Vector2D.ConverterFactory },
                #endregion

                #region Linear Series Types
                { typeof(IEnumerable<ModelID>), SeriesConverter<ModelID, List<ModelID>>.ConverterFactory },
                { typeof(IEnumerable<ModelTag>), SeriesConverter<ModelTag, List<ModelTag>>.ConverterFactory },
                { typeof(IEnumerable<InventorySlot>), SeriesConverter<InventorySlot, List<InventorySlot>>.ConverterFactory },
                { typeof(IEnumerable<RecipeElement>), SeriesConverter<RecipeElement, List<RecipeElement>>.ConverterFactory },
                { typeof(IEnumerable<ScriptNode>), SeriesConverter<ScriptNode, List<ScriptNode>>.ConverterFactory },
                { typeof(IReadOnlyList<ModelID>), SeriesConverter<ModelID, List<ModelID>>.ConverterFactory },
                { typeof(IReadOnlyList<ModelTag>), SeriesConverter<ModelTag, List<ModelTag>>.ConverterFactory },
                { typeof(IReadOnlyList<InventorySlot>), SeriesConverter<InventorySlot, List<InventorySlot>>.ConverterFactory },
                { typeof(IReadOnlyList<RecipeElement>), SeriesConverter<RecipeElement, List<RecipeElement>>.ConverterFactory },
                { typeof(IReadOnlyList<ScriptNode>), SeriesConverter<ScriptNode, List<ScriptNode>>.ConverterFactory },
                #endregion

                #region 2D Grid Types
                { typeof(ModelIDGrid), GridConverter<ModelID, ModelIDGrid>.ConverterFactory },
                { typeof(ParquetStackGrid), GridConverter<ParquetStack, ParquetStackGrid>.ConverterFactory },
                { typeof(ParquetStatusGrid), GridConverter<ParquetStatus, ParquetStatusGrid>.ConverterFactory },
                { typeof(StrikePanelGrid), GridConverter<StrikePanel, StrikePanelGrid>.ConverterFactory },
                #endregion
            };
            #endregion
        }

        /// <summary>
        /// Initializes the <see cref="ModelCollection{T}"/>s from the given collections.
        /// </summary>
        /// <param name="inPronouns">The pronouns that the game knows by default.</param>
        /// <param name="inCharacters">All characters to be used in the game.</param>
        /// <param name="inCritters">All critters to be used in the game.</param>
        /// <param name="inBiomes">All biomes to be used in the game.</param>
        /// <param name="inCraftingRecipes">All crafting recipes to be used in the game.</param>
        /// <param name="inGames">All games or episodes to be used in the game.</param>
        /// <param name="inInteractions">All interactions to be used in the game.</param>
        /// <param name="inMaps">All maps to be used in the game.</param>
        /// <param name="inParquets">All parquets to be used in the game.</param>
        /// <param name="inRoomRecipes">All room recipes to be used in the game.</param>
        /// <param name="inScripts">All scripts to be used in the game.</param>
        /// <param name="inItems">All items to be used in the game.</param>
        /// <remarks>The collections of models must be separately cleared between calls to this initialization routine.</remarks>
        /// <seealso cref="All.Clear"/>
        /// <exception cref="InvalidOperationException">When called more than once.</exception>
        public static void InitializeCollections(IEnumerable<PronounGroup> inPronouns,
                                                 IEnumerable<CharacterModel> inCharacters,
                                                 IEnumerable<CritterModel> inCritters,
                                                 IEnumerable<BiomeRecipe> inBiomes,
                                                 IEnumerable<CraftingRecipe> inCraftingRecipes,
                                                 IEnumerable<GameModel> inGames,
                                                 IEnumerable<InteractionModel> inInteractions,
                                                 IEnumerable<MapModel> inMaps,
                                                 IEnumerable<ParquetModel> inParquets,
                                                 IEnumerable<RoomRecipe> inRoomRecipes,
                                                 IEnumerable<ScriptModel> inScripts,
                                                 IEnumerable<ItemModel> inItems)
        {
            if (CollectionsHaveBeenInitialized)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorClearAllFirst,
                                                                  nameof(All), "initialization"));
            }
            Precondition.IsNotNull(inPronouns, nameof(inPronouns));
            Precondition.IsNotNull(inCharacters, nameof(inCharacters));
            Precondition.IsNotNull(inCritters, nameof(inCritters));
            Precondition.IsNotNull(inBiomes, nameof(inBiomes));
            Precondition.IsNotNull(inCraftingRecipes, nameof(inCraftingRecipes));
            Precondition.IsNotNull(inGames, nameof(inGames));
            Precondition.IsNotNull(inInteractions, nameof(inInteractions));
            Precondition.IsNotNull(inMaps, nameof(inMaps));
            Precondition.IsNotNull(inParquets, nameof(inParquets));
            Precondition.IsNotNull(inRoomRecipes, nameof(inRoomRecipes));
            Precondition.IsNotNull(inScripts, nameof(inScripts));
            Precondition.IsNotNull(inItems, nameof(inItems));

            Characters = new ModelCollection<CharacterModel>(BeingIDs, inCharacters);
            Critters = new ModelCollection<CritterModel>(BeingIDs, inCritters);
            Biomes = new ModelCollection<BiomeRecipe>(BiomeIDs, inBiomes);
            CraftingRecipes = new ModelCollection<CraftingRecipe>(CraftingRecipeIDs, inCraftingRecipes);
            Games = new ModelCollection<GameModel>(GameIDs, inGames);
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
        /// <returns><c>true</c> if no exceptions were caught, <c>false</c> otherwise.</returns>
        [SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Parquet does not throw exceptions.")]
        public static bool LoadFromCSVs()
        {
            #region Read Configuration
            var pronounGroups = PronounGroup.GetRecords();
            BiomeConfiguration.GetRecord();
            CraftConfiguration.GetRecord();
            RoomConfiguration.GetRecord();
            #endregion

            #region Read Models
            var characters = ModelCollection<CharacterModel>.ConverterFactory.GetRecordsForType<CharacterModel>(CharacterIDs);
            var critters = ModelCollection<CritterModel>.ConverterFactory.GetRecordsForType<CritterModel>(CritterIDs);
            var biomes = ModelCollection<BiomeRecipe>.ConverterFactory.GetRecordsForType<BiomeRecipe>(BiomeIDs);
            var craftingRecipes = ModelCollection<CraftingRecipe>.ConverterFactory.GetRecordsForType<CraftingRecipe>(CraftingRecipeIDs);
            var games = ModelCollection<GameModel>.ConverterFactory.GetRecordsForType<GameModel>(GameIDs);
            var interactions = ModelCollection<InteractionModel>.ConverterFactory.GetRecordsForType<InteractionModel>(InteractionIDs);
            var maps = ModelCollection<MapModel>.ConverterFactory.GetRecordsForType<MapChunkModel>(MapIDs)
                .Concat(ModelCollection<MapModel>.ConverterFactory.GetRecordsForType<MapRegionSketch>(MapIDs))
                .Concat(ModelCollection<MapModel>.ConverterFactory.GetRecordsForType<MapRegionModel>(MapIDs));
            var parquets = ModelCollection<ParquetModel>.ConverterFactory.GetRecordsForType<FloorModel>(ParquetIDs)
                .Concat(ModelCollection<ParquetModel>.ConverterFactory.GetRecordsForType<BlockModel>(ParquetIDs))
                .Concat(ModelCollection<ParquetModel>.ConverterFactory.GetRecordsForType<FurnishingModel>(ParquetIDs))
                .Concat(ModelCollection<ParquetModel>.ConverterFactory.GetRecordsForType<CollectibleModel>(ParquetIDs));
            var roomRecipes = ModelCollection<RoomRecipe>.ConverterFactory.GetRecordsForType<RoomRecipe>(RoomRecipeIDs);
            var scripts = ModelCollection<ScriptModel>.ConverterFactory.GetRecordsForType<ScriptModel>(ScriptIDs);
            var items = ModelCollection<ItemModel>.ConverterFactory.GetRecordsForType<ItemModel>(ItemIDs);
            #endregion

            InitializeCollections(pronounGroups, characters, critters, biomes, craftingRecipes, games, interactions, maps, parquets, roomRecipes, scripts, items);

            // TODO In case of exception, log it and return false;
            return true;
        }

        /// <summary>
        /// Stores the content of <see cref="All"/> to CSV files for later reinitialization.
        /// </summary>
        /// <returns><c>true</c> if no exceptions were caught, <c>false</c> otherwise.</returns>
        [SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Parquet does not throw exceptions.")]
        public static bool SaveToCSVs()
        {
            #region Write Configuration
            PronounGroup.PutRecords(PronounGroups);
            BiomeConfiguration.PutRecord();
            CraftConfiguration.PutRecord();
            RoomConfiguration.PutRecord();
            #endregion

            #region Write Models
            Characters.PutRecordsForType<CharacterModel>();
            Critters.PutRecordsForType<CritterModel>();
            Biomes.PutRecordsForType<BiomeRecipe>();
            CraftingRecipes.PutRecordsForType<CraftingRecipe>();
            Games.PutRecordsForType<GameModel>();
            Interactions.PutRecordsForType<InteractionModel>();
            Maps.PutRecordsForType<MapChunkModel>();
            Maps.PutRecordsForType<MapRegionSketch>();
            Maps.PutRecordsForType<MapRegionModel>();
            Parquets.PutRecordsForType<FloorModel>();
            Parquets.PutRecordsForType<BlockModel>();
            Parquets.PutRecordsForType<FurnishingModel>();
            Parquets.PutRecordsForType<CollectibleModel>();
            RoomRecipes.PutRecordsForType<RoomRecipe>();
            Scripts.PutRecordsForType<ScriptModel>();
            Items.PutRecordsForType<ItemModel>();
            #endregion

            // TODO In case of exception, log it and return false;
            return true;
        }

        /// <summary>
        /// Clears all the <see cref="ModelCollection{T}"/>s contained in <see cref="All"/>.
        /// </summary>
        /// <remarks>This method must be called between calls to the initialization routines.</remarks>
        /// <seealso cref="InitializeCollections(IEnumerable{PronounGroup}, IEnumerable{BeingModel}, IEnumerable{BiomeRecipe}, IEnumerable{CraftingRecipe}, IEnumerable{GameModel}, IEnumerable{InteractionModel}, IEnumerable{MapModel}, IEnumerable{ParquetModel}, IEnumerable{RoomRecipe}, IEnumerable{ScriptModel}, IEnumerable{ItemModel})"/>
        /// <exception cref="InvalidOperationException">When called more than once.</exception>
        public static void Clear()
        {
            ((IModelCollectionEdit<CharacterModel>)Characters)?.Clear();
            ((IModelCollectionEdit<CritterModel>)Critters)?.Clear();
            ((IModelCollectionEdit<BiomeRecipe>)Biomes)?.Clear();
            ((IModelCollectionEdit<CraftingRecipe>)CraftingRecipes)?.Clear();
            ((IModelCollectionEdit<GameModel>)Games)?.Clear();
            ((IModelCollectionEdit<InteractionModel>)Interactions)?.Clear();
            ((IModelCollectionEdit<MapModel>)Maps)?.Clear();
            ((IModelCollectionEdit<ParquetModel>)Parquets)?.Clear();
            ((IModelCollectionEdit<RoomRecipe>)RoomRecipes)?.Clear();
            ((IModelCollectionEdit<ScriptModel>)Scripts)?.Clear();
            ((IModelCollectionEdit<ItemModel>)Items)?.Clear();
            ((HashSet<PronounGroup>)PronounGroups)?.Clear();
            CollectionsHaveBeenInitialized = false;
        }
        #endregion

        #region ModelID Range Helper Methods
        /// <summary>
        /// Given a <see cref="ModelID"/>, return the <see cref="Range{ModelID}"/> within which it is defined.
        /// </summary>
        /// <param name="inID">The ID whose <see cref="Range{ModelID}"/> is sought.</param>
        /// <returns>
        /// The range within which this <see cref="ModelID"/> is defined, or <see cref="Range{ModelID}.None"/> if there is none.
        /// </returns>
        public static Range<ModelID> GetIDRangeForType(ModelID inID)
            => inID == ModelID.None
                ? Range<ModelID>.None
                : AllDefinedIDs.Where(range => range.ContainsValue(inID)).DefaultIfEmpty(Range<ModelID>.None).First();

        /// <summary>
        /// Given an instance of <see cref="Model"/>, return the appropriate <see cref="Range{ModelID}"/>.
        /// </summary>
        /// <param name="inModel">The model whose <see cref="Range{ModelID}"/> is sought.</param>
        /// <returns>
        /// The range within which this model's <see cref="ModelID"/> is defined, or <see cref="Range{ModelID}.None"/> if there is none.
        /// </returns>
        public static Range<ModelID> GetIDRangeForType(Model inModel)
            => inModel == null
            || inModel.ID == ModelID.None
                ? Range<ModelID>.None
                : inModel switch
                {
                    GameModel _ => GameIDs,
                    BlockModel _ => BlockIDs,
                    FloorModel _ => FloorIDs,
                    FurnishingModel _ => FurnishingIDs,
                    CollectibleModel _ => CollectibleIDs,
                    CharacterModel _ => CharacterIDs,
                    CritterModel _ => CritterIDs,
                    ItemModel _ => ItemIDs,
                    BiomeRecipe _ => BiomeIDs,
                    CraftingRecipe _ => CraftingRecipeIDs,
                    MapChunkModel _ => MapChunkIDs,
                    MapRegionSketch _ => MapRegionIDs,
                    MapRegionModel _ => MapRegionIDs,
                    ScriptModel _ => ScriptIDs,
                    InteractionModel _ => InteractionIDs,
                    _ => Range<ModelID>.None,
                };

        /// <summary>
        /// Given a <see cref="Type"/> derived from a <see cref="Model"/>, return the appropriate <see cref="Range{ModelID}"/>.
        /// </summary>
        /// <param name="inModelType">The model type whose ID range is sought.</param>
        /// <returns>
        /// The range within which this model type's <see cref="ModelID"/> would be define,
        /// dor <see cref="Range{ModelID}.None"/> if there is none exists.
        /// </returns>
        public static Range<ModelID> GetIDRangeForType(Type inModelType)
            => inModelType == typeof(GameModel) ? GameIDs
            : inModelType == typeof(BlockModel) ? BlockIDs
            : inModelType == typeof(FloorModel) ? FloorIDs
            : inModelType == typeof(FurnishingModel) ? FurnishingIDs
            : inModelType == typeof(CollectibleModel) ? CollectibleIDs
            : inModelType == typeof(CharacterModel) ? CharacterIDs
            : inModelType == typeof(CritterModel) ? CritterIDs
            : inModelType == typeof(ItemModel) ? ItemIDs
            : inModelType == typeof(BiomeRecipe) ? BiomeIDs
            : inModelType == typeof(CraftingRecipe) ? CraftingRecipeIDs
            : inModelType == typeof(MapChunkModel) ? MapChunkIDs
            : inModelType == typeof(ScriptModel) ? ScriptIDs
            : inModelType == typeof(InteractionModel) ? InteractionIDs
            : inModelType == typeof(MapRegionSketch) || inModelType == typeof(MapRegionModel) ? MapRegionIDs
            : Range<ModelID>.None;
        #endregion
    }
}
