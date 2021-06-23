using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper.TypeConversion;
using Parquet.Beings;
using Parquet.Biomes;
using Parquet.Crafts;
using Parquet.Games;
using Parquet.Items;
using Parquet.Parquets;
using Parquet.Properties;
using Parquet.Regions;
using Parquet.Rooms;
using Parquet.Scripts;

namespace Parquet
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

        /// <summary>The location of the game data files.  Defaults to the application's working directory.</summary>
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
        /// A subset of the values of <see cref="ModelID"/> set aside for <see cref="CritterModel"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Critters.
        /// </summary>
        public static readonly Range<ModelID> CritterIDs;

        /// <summary>
        /// A subset of the values of <see cref="ModelID"/> set aside for <see cref="CharacterModel"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test NPCs.
        /// </summary>
        public static readonly Range<ModelID> CharacterIDs;

        /// <summary>
        /// A collection containing all defined <see cref="Range{ModelID}"/>s of <see cref="BeingModel"/>s.
        /// </summary>
        public static readonly IReadOnlyList<Range<ModelID>> BeingIDs;

        /// <summary>
        /// A subset of the values of <see cref="ModelID"/> set aside for <see cref="BiomeRecipe"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Biomes.
        /// </summary>
        public static readonly Range<ModelID> BiomeRecipeIDs;

        /// <summary>
        /// A subset of the values of <see cref="ModelID"/> set aside for <see cref="CraftingRecipe"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test recipes.
        /// </summary>
        public static readonly Range<ModelID> CraftingRecipeIDs;

        /// <summary>
        /// A subset of the values of <see cref="ModelID"/> set aside for <see cref="RoomRecipe"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test recipes.
        /// </summary>
        public static readonly Range<ModelID> RoomRecipeIDs;

        /// <summary>
        /// A subset of the values of <see cref="ModelID"/> set aside for <see cref="Regions.RegionModel"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Items.
        /// </summary>
        public static readonly Range<ModelID> RegionIDs;

        /// <summary>
        /// A subset of the values of <see cref="ModelID"/> set aside for <see cref="ScriptModel"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Items.
        /// </summary>
        public static readonly Range<ModelID> ScriptIDs;

        /// <summary>
        /// A subset of the values of <see cref="ModelID"/> set aside for <see cref="InteractionModel"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test recipes.
        /// </summary>
        public static readonly Range<ModelID> InteractionIDs;

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
        /// A collection of all defined <see cref="GameModel"/>s.
        /// This collection is the source of truth about game and episode metadata for the rest of the library.
        /// </summary>
        /// <remarks>All <see cref="ModelID"/>s must be unique.</remarks>
        public static ModelCollection<GameModel> Games { get; private set; }

        /// <summary>
        /// A collection of all defined <see cref="FloorModel"/>s.
        /// This collection is the source of truth about floor parquets for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="ModelID"/>s must be unique.</remarks>
        public static ModelCollection<FloorModel> Floors { get; private set; }

        /// <summary>
        /// A collection of all defined <see cref="BlockModel"/>s.
        /// This collection is the source of truth about block parquets for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="ModelID"/>s must be unique.</remarks>
        public static ModelCollection<BlockModel> Blocks { get; private set; }

        /// <summary>
        /// A collection of all defined <see cref="FurnishingModel"/>s.
        /// This collection is the source of truth about furnishing parquets for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="ModelID"/>s must be unique.</remarks>
        public static ModelCollection<FurnishingModel> Furnishings { get; private set; }

        /// <summary>
        /// A collection of all defined <see cref="CollectibleModel"/>s.
        /// This collection is the source of truth about collectible parquets for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="ModelID"/>s must be unique.</remarks>
        public static ModelCollection<CollectibleModel> Collectibles { get; private set; }

        /// <summary>
        /// A collection of all defined parquets of all subtypes.
        /// This collection is the source of truth about parquets for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="ModelID"/>s must be unique.</remarks>
        public static ModelCollection<ParquetModel> Parquets { get; private set; }

        /// <summary>
        /// A collection of all defined <see cref="CritterModel"/>s.
        /// This collection is the source of truth about critters for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="ModelID"/>s must be unique.</remarks>
        public static ModelCollection<CritterModel> Critters { get; private set; }

        /// <summary>
        /// A collection of all defined <see cref="CharacterModel"/>s.
        /// This collection is the source of truth about characters for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="ModelID"/>s must be unique.</remarks>
        public static ModelCollection<CharacterModel> Characters { get; private set; }

        /// <summary>
        /// A collection of all defined <see cref="BeingModel"/>s.
        /// This collection is the source of truth about critters and characters for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="ModelID"/>s must be unique.</remarks>
        public static ModelCollection<BeingModel> Beings { get; private set; }

        /// <summary>
        /// A collection of all defined <see cref="BiomeRecipe"/>s.
        /// This collection is the source of truth about biomes for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="ModelID"/>s must be unique.</remarks>
        public static ModelCollection<BiomeRecipe> BiomeRecipes { get; private set; }

        /// <summary>
        /// A collection of all defined <see cref="CraftingRecipe"/>s.
        /// This collection is the source of truth about crafting for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="ModelID"/>s must be unique.</remarks>
        public static ModelCollection<CraftingRecipe> CraftingRecipes { get; private set; }

        /// <summary>
        /// A collection of all defined <see cref="RoomRecipe"/>s.
        /// This collection is the source of truth about rooms for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="ModelID"/>s must be unique.</remarks>
        public static ModelCollection<RoomRecipe> RoomRecipes { get; private set; }

        /// <summary>
        /// A collection of all defined <see cref="RegionModel"/>s.
        /// This collection is the source of truth about non-map region data for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="ModelID"/>s must be unique.</remarks>
        public static ModelCollection<RegionModel> Regions { get; private set; }

        /// <summary>
        /// A collection of all defined <see cref="ScriptModel"/>s.
        /// This collection is the source of truth about scripts for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="ModelID"/>s must be unique.</remarks>
        public static ModelCollection<ScriptModel> Scripts { get; private set; }

        /// <summary>
        /// A collection of all defined <see cref="InteractionModel"/>s.
        /// This collection is the source of truth about interactions for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="ModelID"/>s must be unique.</remarks>
        public static ModelCollection<InteractionModel> Interactions { get; private set; }

        /// <summary>
        /// A collection of all defined <see cref="ItemModel"/>s.
        /// This collection is the source of truth about items for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="ModelID"/>s must be unique.</remarks>
        public static ModelCollection<ItemModel> Items { get; private set; }
        #endregion

        #region Status Collections
        /// <summary>
        /// An optional collection of all <see cref="CharacterStatus"/>es currently tracked.
        /// Each corresponds to a <see cref="CharacterModel"/> in <see cref="Characters"/>.
        /// This collection is mutable during play.
        /// </summary>
        public static IDictionary<ModelID, CharacterStatus> CharacterStatuses { get; private set; }

        /// <summary>
        /// An optional collection of all <see cref="CritterStatus"/>es currently tracked.
        /// Each corresponds to a <see cref="CritterModel"/> in <see cref="Critters"/>.
        /// This collection is mutable during play.
        /// </summary>
        public static IDictionary<ModelID, CritterStatus> CritterStatuses { get; private set; }

        /// <summary>
        /// An optional collection of all <see cref="BlockStatus"/>es currently tracked.
        /// Each corresponds to a <see cref="BlockModel"/> in <see cref="Blocks"/>.
        /// This collection is mutable during play.
        /// </summary>
        public static IDictionary<ModelID, BlockStatus> BlockStatuses { get; private set; }

        /// <summary>
        /// An optional collection of all <see cref="FloorStatus"/>es currently tracked.
        /// Each corresponds to a <see cref="FloorModel"/> in <see cref="Floors"/>.
        /// This collection is mutable during play.
        /// </summary>
        public static IDictionary<ModelID, FloorStatus> FloorStatuses { get; private set; }

        /// <summary>
        /// An optional collection of all <see cref="FurnishingStatus"/>es currently tracked.
        /// Each corresponds to a <see cref="FurnishingModel"/> in <see cref="Furnishings"/>.
        /// This collection is mutable during play.
        /// </summary>
        public static IDictionary<ModelID, FurnishingStatus> FurnishingStatuses { get; private set; }

        /// <summary>
        /// An optional collection of all <see cref="GameStatus"/>es currently in play.
        /// Each corresponds to a <see cref="GameModel"/> in <see cref="Games"/>.
        /// This collection is mutable during play.
        /// </summary>
        public static IDictionary<ModelID, GameStatus> GameStatuses { get; private set; }

        /// <summary>
        /// An optional collection of all <see cref="InteractionStatus"/>es currently tracked.
        /// Each corresponds to a <see cref="InteractionModel"/> in <see cref="Interactions"/>.
        /// This collection is mutable during play.
        /// </summary>
        public static IDictionary<ModelID, InteractionStatus> InteractionStatuses { get; private set; }

        /// <summary>
        /// An optional collection of all <see cref="RegionStatus"/>es currently generated.
        /// These are the actual maps in play, and each corresponds to a <see cref="RegionModel"/> in <see cref="Regions"/>.
        /// This collection is mutable during play.
        /// </summary>
        public static IDictionary<ModelID, RegionStatus> RegionStatuses { get; private set; }

        /// <summary>
        /// An optional collection of all <see cref="ScriptStatus"/>es currently running.
        /// Each corresponds to a <see cref="ScriptModel"/> in <see cref="Scripts"/>.
        /// This collection is mutable during play.
        /// </summary>
        public static IDictionary<ModelID, ScriptStatus> ScriptStatuses { get; private set; }
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
                         Justification = "Inline initializers would notably complicate the code in this instance.  (Ordering is important.)")]
        static All()
        {
            #region Default Values for Collections
            CollectionsHaveBeenInitialized = false;

            Games = ModelCollection<GameModel>.Default;
            Floors = ModelCollection<FloorModel>.Default;
            Blocks = ModelCollection<BlockModel>.Default;
            Furnishings = ModelCollection<FurnishingModel>.Default;
            Collectibles = ModelCollection<CollectibleModel>.Default;
            Parquets = ModelCollection<ParquetModel>.Default;
            Critters = ModelCollection<CritterModel>.Default;
            Characters = ModelCollection<CharacterModel>.Default;
            Beings = ModelCollection<BeingModel>.Default;
            BiomeRecipes = ModelCollection<BiomeRecipe>.Default;
            CraftingRecipes = ModelCollection<CraftingRecipe>.Default;
            RoomRecipes = ModelCollection<RoomRecipe>.Default;
            Regions = ModelCollection<RegionModel>.Default;
            Scripts = ModelCollection<ScriptModel>.Default;
            Interactions = ModelCollection<InteractionModel>.Default;
            Items = ModelCollection<ItemModel>.Default;

            PronounGroups = new HashSet<PronounGroup>();
            RegionStatuses = new Dictionary<ModelID, RegionStatus>();
            #endregion

            #region Initialize Ranges
            // By convention, the first ModelID in each Range is a multiple of this number.
            const int TargetMultiple = 10000;

            // NOTE that the order of the definitions and computations in the following regions are important.

            #region Define Most Ranges
            GameIDs = new Range<ModelID>(1, 9000);

            FloorIDs = new Range<ModelID>(10000, 19000);
            BlockIDs = new Range<ModelID>(20000, 29000);
            FurnishingIDs = new Range<ModelID>(30000, 39000);
            CollectibleIDs = new Range<ModelID>(40000, 49000);

            CritterIDs = new Range<ModelID>(50000, 59000);
            CharacterIDs = new Range<ModelID>(60000, 69000);

            BiomeRecipeIDs = new Range<ModelID>(70000, 79000);
            CraftingRecipeIDs = new Range<ModelID>(80000, 89000);
            RoomRecipeIDs = new Range<ModelID>(90000, 99000);

            RegionIDs = new Range<ModelID>(110000, 119000);

            ScriptIDs = new Range<ModelID>(120000, 129000);
            InteractionIDs = new Range<ModelID>(130000, 139000);
            #endregion

            #region Define Most Range Collections
            ParquetIDs = new List<Range<ModelID>> { FloorIDs, BlockIDs, FurnishingIDs, CollectibleIDs };
            BeingIDs = new List<Range<ModelID>> { CritterIDs, CharacterIDs };
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
                FloorIDs,
                BlockIDs,
                FurnishingIDs,
                CollectibleIDs,
                CritterIDs,
                CharacterIDs,
                BiomeRecipeIDs,
                CraftingRecipeIDs,
                RoomRecipeIDs,
                RegionIDs,
                ScriptIDs,
                InteractionIDs,
                ItemIDs,
            };
            #endregion
            #endregion

            #region Initialize Serialization Values & Lookup Tables
            ProjectDirectory = LibraryState.IsDebugMode
                ? Path.GetFullPath($"{Directory.GetCurrentDirectory()}/../../../../ExampleData")
                : Path.GetFullPath(Directory.GetCurrentDirectory());

            IdentifierOptions = new TypeConverterOptions
            {
                NumberStyles = SerializedNumberStyle,
                CultureInfo = CultureInfo.InvariantCulture,
            };

            ConversionConverters = new Dictionary<Type, ITypeConverter>
            {
                #region Empty-Tolerant Enumeration Types
                { typeof(ChunkTopography), new EmptyTolerantEnumConverter(typeof(ChunkTopography)) },
                { typeof(CollectingEffect), new EmptyTolerantEnumConverter(typeof(CollectingEffect)) },
                { typeof(EntryType), new EmptyTolerantEnumConverter(typeof(EntryType)) },
                { typeof(GatheringEffect), new EmptyTolerantEnumConverter(typeof(GatheringEffect)) },
                { typeof(GatheringTool), new EmptyTolerantEnumConverter(typeof(GatheringTool)) },
                { typeof(ItemType), new EmptyTolerantEnumConverter(typeof(ItemType)) },
                { typeof(ModificationTool), new EmptyTolerantEnumConverter(typeof(ModificationTool)) },
                { typeof(RunState), new EmptyTolerantEnumConverter(typeof(RunState)) },
                #endregion

                #region Types Implementing ITypeConverter
                { typeof(ChunkDetail), ChunkDetail.ConverterFactory },
                { typeof(InventorySlot), InventorySlot.ConverterFactory },
                { typeof(Location), Location.ConverterFactory },
                { typeof(ModelID), ModelID.ConverterFactory },
                { typeof(ModelTag), ModelTag.ConverterFactory },
                { typeof(ParquetModelPack), ParquetModelPack.ConverterFactory },
                { typeof(ParquetStatusPack), ParquetStatusPack.ConverterFactory },
                { typeof(Point2D), Point2D.ConverterFactory },
                { typeof(Range<ModelID>), Range<ModelID>.ConverterFactory },
                { typeof(Range<int>), Range<int>.ConverterFactory },
                { typeof(RecipeElement), RecipeElement.ConverterFactory },
                { typeof(ScriptNode), ScriptNode.ConverterFactory },
                #endregion

                #region Linear Series Types
                { typeof(IEnumerable<ModelID>), SeriesConverter<ModelID, List<ModelID>>.ConverterFactory },
                { typeof(IEnumerable<ModelTag>), SeriesConverter<ModelTag, List<ModelTag>>.ConverterFactory },
                { typeof(IEnumerable<RecipeElement>), SeriesConverter<RecipeElement, List<RecipeElement>>.ConverterFactory },
                { typeof(IEnumerable<ScriptNode>), SeriesConverter<ScriptNode, List<ScriptNode>>.ConverterFactory },
                { typeof(InventoryCollection), SeriesConverter<InventorySlot, InventoryCollection>.ConverterFactory },
                { typeof(IReadOnlyList<ModelID>), SeriesConverter<ModelID, List<ModelID>>.ConverterFactory },
                { typeof(IReadOnlyList<ModelTag>), SeriesConverter<ModelTag, List<ModelTag>>.ConverterFactory },
                { typeof(IReadOnlyList<RecipeElement>), SeriesConverter<RecipeElement, List<RecipeElement>>.ConverterFactory },
                { typeof(IReadOnlyList<ScriptNode>), SeriesConverter<ScriptNode, List<ScriptNode>>.ConverterFactory },
                #endregion

                #region 2D Grid Types
                { typeof(IGrid<ModelID>), GridConverter<ModelID, ModelIDGrid>.ConverterFactory },
                { typeof(IGrid<ParquetModelPack>), GridConverter<ParquetModelPack, ParquetModelPackGrid>.ConverterFactory },
                { typeof(IGrid<ParquetStatusPack>), GridConverter<ParquetStatusPack, ParquetStatusPackGrid>.ConverterFactory },
                { typeof(IReadOnlyGrid<ModelID>), GridConverter<ModelID, ModelIDGrid>.ConverterFactory },
                { typeof(IReadOnlyGrid<ParquetModelPack>), GridConverter<ParquetModelPack, ParquetModelPackGrid>.ConverterFactory },
                { typeof(IReadOnlyGrid<ParquetStatusPack>), GridConverter<ParquetStatusPack, ParquetStatusPackGrid>.ConverterFactory },
                { typeof(ModelIDGrid), GridConverter<ModelID, ModelIDGrid>.ConverterFactory },
                { typeof(ParquetModelPackGrid), GridConverter<ParquetModelPack, ParquetModelPackGrid>.ConverterFactory },
                { typeof(ParquetStatusPackGrid), GridConverter<ParquetStatusPack, ParquetStatusPackGrid>.ConverterFactory },
                #endregion
            };
            #endregion
        }

        /// <summary>
        /// Initializes the <see cref="ModelCollection{T}"/>s from the given collections.
        /// </summary>
        /// <param name="pronouns">The pronouns that the game knows by default.</param>
        /// <param name="characters">All characters to be used in the game.</param>
        /// <param name="critters">All critters to be used in the game.</param>
        /// <param name="biomes">All biomes to be used in the game.</param>
        /// <param name="craftingRecipes">All crafting recipes to be used in the game.</param>
        /// <param name="games">All games or episodes to be used in the game.</param>
        /// <param name="interactions">All interactions to be used in the game.</param>
        /// <param name="regions">All region metadata to be used in the game.</param>
        /// <param name="regionStatuses">All maps that have already been generated in the game.</param>
        /// <param name="floors">All floors to be used in the game.</param>
        /// <param name="blocks">All blocks to be used in the game.</param>
        /// <param name="furnishings">All furnishings to be used in the game.</param>
        /// <param name="collectibles">All collectibles to be used in the game.</param>
        /// <param name="roomRecipes">All room recipes to be used in the game.</param>
        /// <param name="scripts">All scripts to be used in the game.</param>
        /// <param name="items">All items to be used in the game.</param>
        /// <remarks>The collections of models must be separately cleared between calls to this initialization routine.</remarks>
        /// <seealso cref="Clear"/>
        internal static void InitializeModelCollections(IEnumerable<PronounGroup> pronouns,
                                                        IEnumerable<GameModel> games,
                                                        IEnumerable<FloorModel> floors,
                                                        IEnumerable<BlockModel> blocks,
                                                        IEnumerable<FurnishingModel> furnishings,
                                                        IEnumerable<CollectibleModel> collectibles,
                                                        IEnumerable<CritterModel> critters,
                                                        IEnumerable<CharacterModel> characters,
                                                        IEnumerable<BiomeRecipe> biomes,
                                                        IEnumerable<CraftingRecipe> craftingRecipes,
                                                        IEnumerable<RoomRecipe> roomRecipes,
                                                        IEnumerable<RegionModel> regions,
                                                        IEnumerable<KeyValuePair<ModelID, RegionStatus>> regionStatuses,
                                                        IEnumerable<ScriptModel> scripts,
                                                        IEnumerable<InteractionModel> interactions,
                                                        IEnumerable<ItemModel> items)
        {
            CharacterStatuses
            CritterStatuses
            BlockStatuses
            FloorStatuses
            FurnishingStatuses
            GameStatuses
            InteractionStatuses
            RegionStatuses
            ScriptStatuses


            Games = new ModelCollection<GameModel>(GameIDs, games);
            Floors = new ModelCollection<FloorModel>(FloorIDs, floors);
            Blocks = new ModelCollection<BlockModel>(BlockIDs, blocks);
            Furnishings = new ModelCollection<FurnishingModel>(FurnishingIDs, furnishings);
            Collectibles = new ModelCollection<CollectibleModel>(CollectibleIDs, collectibles);
            Parquets = new ModelCollection<ParquetModel>(ParquetIDs, ((IEnumerable<ParquetModel>)Floors)
                .Concat(Blocks)
                .Concat(Furnishings)
                .Concat(Collectibles));
            Critters = new ModelCollection<CritterModel>(CritterIDs, critters);
            Characters = new ModelCollection<CharacterModel>(CharacterIDs, characters);
            Beings = new ModelCollection<BeingModel>(BeingIDs, ((IEnumerable<BeingModel>)Characters)
                .Concat(Critters));
            BiomeRecipes = new ModelCollection<BiomeRecipe>(BiomeRecipeIDs, biomes);
            CraftingRecipes = new ModelCollection<CraftingRecipe>(CraftingRecipeIDs, craftingRecipes);
            RoomRecipes = new ModelCollection<RoomRecipe>(RoomRecipeIDs, roomRecipes);
            Regions = new ModelCollection<RegionModel>(RegionIDs, regions);
            Scripts = new ModelCollection<ScriptModel>(ScriptIDs, scripts);
            Interactions = new ModelCollection<InteractionModel>(InteractionIDs, interactions);
            Items = new ModelCollection<ItemModel>(ItemIDs, items);

            PronounGroups = new HashSet<PronounGroup>(pronouns);
            RegionStatuses = new Dictionary<ModelID, RegionStatus>(regionStatuses);

            CollectionsHaveBeenInitialized = true;
        }


        /// <summary>
        /// Initializes the <see cref="Status{T}"/> collections from the given collections.
        /// </summary>
        /// <param name="pronouns">The pronouns that the game knows by default.</param>
        /// <param name="characters">All characters to be used in the game.</param>
        /// <param name="critters">All critters to be used in the game.</param>
        /// <param name="biomes">All biomes to be used in the game.</param>
        /// <param name="craftingRecipes">All crafting recipes to be used in the game.</param>
        /// <param name="games">All games or episodes to be used in the game.</param>
        /// <param name="interactions">All interactions to be used in the game.</param>
        /// <param name="regions">All region metadata to be used in the game.</param>
        /// <param name="regionStatuses">All maps that have already been generated in the game.</param>
        /// <param name="floors">All floors to be used in the game.</param>
        /// <param name="blocks">All blocks to be used in the game.</param>
        /// <param name="furnishings">All furnishings to be used in the game.</param>
        /// <param name="collectibles">All collectibles to be used in the game.</param>
        /// <param name="roomRecipes">All room recipes to be used in the game.</param>
        /// <param name="scripts">All scripts to be used in the game.</param>
        /// <param name="items">All items to be used in the game.</param>
        /// <remarks>The collections of models must be separately cleared between calls to this initialization routine.</remarks>
        /// <seealso cref="Clear"/>
        internal static void InitializeStatusCollections(IEnumerable<PronounGroup> pronouns,
                                                        IEnumerable<GameModel> games,
                                                        IEnumerable<FloorModel> floors,
                                                        IEnumerable<BlockModel> blocks,
                                                        IEnumerable<FurnishingModel> furnishings,
                                                        IEnumerable<CollectibleModel> collectibles,
                                                        IEnumerable<CritterModel> critters,
                                                        IEnumerable<CharacterModel> characters,
                                                        IEnumerable<BiomeRecipe> biomes,
                                                        IEnumerable<CraftingRecipe> craftingRecipes,
                                                        IEnumerable<RoomRecipe> roomRecipes,
                                                        IEnumerable<RegionModel> regions,
                                                        IEnumerable<KeyValuePair<ModelID, RegionStatus>> regionStatuses,
                                                        IEnumerable<ScriptModel> scripts,
                                                        IEnumerable<InteractionModel> interactions,
                                                        IEnumerable<ItemModel> items)
        {
            if (CollectionsHaveBeenInitialized)
            {
                Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.ErrorClearAllFirst,
                                                           nameof(All), "initialization"));
                return;
            }
            Precondition.IsNotNull(pronouns, nameof(pronouns));
            Precondition.IsNotNull(games, nameof(games));
            Precondition.IsNotNull(floors, nameof(floors));
            Precondition.IsNotNull(blocks, nameof(blocks));
            Precondition.IsNotNull(furnishings, nameof(furnishings));
            Precondition.IsNotNull(collectibles, nameof(collectibles));
            Precondition.IsNotNull(critters, nameof(critters));
            Precondition.IsNotNull(characters, nameof(characters));
            Precondition.IsNotNull(biomes, nameof(biomes));
            Precondition.IsNotNull(craftingRecipes, nameof(craftingRecipes));
            Precondition.IsNotNull(roomRecipes, nameof(roomRecipes));
            Precondition.IsNotNull(regions, nameof(regions));
            Precondition.IsNotNull(scripts, nameof(scripts));
            Precondition.IsNotNull(interactions, nameof(interactions));
            Precondition.IsNotNull(items, nameof(items));

            Games = new ModelCollection<GameModel>(GameIDs, games);
            Floors = new ModelCollection<FloorModel>(FloorIDs, floors);
            Blocks = new ModelCollection<BlockModel>(BlockIDs, blocks);
            Furnishings = new ModelCollection<FurnishingModel>(FurnishingIDs, furnishings);
            Collectibles = new ModelCollection<CollectibleModel>(CollectibleIDs, collectibles);
            Parquets = new ModelCollection<ParquetModel>(ParquetIDs, ((IEnumerable<ParquetModel>)Floors)
                .Concat(Blocks)
                .Concat(Furnishings)
                .Concat(Collectibles));
            Critters = new ModelCollection<CritterModel>(CritterIDs, critters);
            Characters = new ModelCollection<CharacterModel>(CharacterIDs, characters);
            Beings = new ModelCollection<BeingModel>(BeingIDs, ((IEnumerable<BeingModel>)Characters)
                .Concat(Critters));
            BiomeRecipes = new ModelCollection<BiomeRecipe>(BiomeRecipeIDs, biomes);
            CraftingRecipes = new ModelCollection<CraftingRecipe>(CraftingRecipeIDs, craftingRecipes);
            RoomRecipes = new ModelCollection<RoomRecipe>(RoomRecipeIDs, roomRecipes);
            Regions = new ModelCollection<RegionModel>(RegionIDs, regions);
            Scripts = new ModelCollection<ScriptModel>(ScriptIDs, scripts);
            Interactions = new ModelCollection<InteractionModel>(InteractionIDs, interactions);
            Items = new ModelCollection<ItemModel>(ItemIDs, items);

            PronounGroups = new HashSet<PronounGroup>(pronouns);
            RegionStatuses = new Dictionary<ModelID, RegionStatus>(regionStatuses);

            CollectionsHaveBeenInitialized = true;
        }
        #endregion

        #region Serialization
        /// <summary>
        /// Initializes <see cref="All"/> based on the values in design-time CSV files.
        /// </summary>
        /// <returns><c>true</c> if no exceptions were caught, <c>false</c> otherwise.</returns>
        public static bool TryLoadModels()
        {
            try
            {
                #region Read Configuration
                var pronounGroups = PronounGroup.GetRecords();
                BiomeConfiguration.GetRecord();
                CraftConfiguration.GetRecord();
                InventoryConfiguration.GetRecord();
                RoomConfiguration.GetRecord();
                #endregion

                #region Read Models
                var games = ModelCollection<GameModel>.ConverterFactory.GetRecordsForType<GameModel>(GameIDs);
                var floors = ModelCollection<FloorModel>.ConverterFactory.GetRecordsForType<FloorModel>(ParquetIDs);
                var blocks = ModelCollection<BlockModel>.ConverterFactory.GetRecordsForType<BlockModel>(ParquetIDs);
                var furnishings = ModelCollection<FurnishingModel>.ConverterFactory.GetRecordsForType<FurnishingModel>(ParquetIDs);
                var collectibles = ModelCollection<CollectibleModel>.ConverterFactory.GetRecordsForType<CollectibleModel>(ParquetIDs);
                var critters = ModelCollection<CritterModel>.ConverterFactory.GetRecordsForType<CritterModel>(CritterIDs);
                var characters = ModelCollection<CharacterModel>.ConverterFactory.GetRecordsForType<CharacterModel>(CharacterIDs);
                var biomeRecipes = ModelCollection<BiomeRecipe>.ConverterFactory.GetRecordsForType<BiomeRecipe>(BiomeRecipeIDs);
                var craftingRecipes = ModelCollection<CraftingRecipe>.ConverterFactory.GetRecordsForType<CraftingRecipe>(CraftingRecipeIDs);
                var roomRecipes = ModelCollection<RoomRecipe>.ConverterFactory.GetRecordsForType<RoomRecipe>(RoomRecipeIDs);
                var regions = ModelCollection<RegionModel>.ConverterFactory.GetRecordsForType<RegionModel>(RegionIDs);
                var scripts = ModelCollection<ScriptModel>.ConverterFactory.GetRecordsForType<ScriptModel>(ScriptIDs);
                var interactions = ModelCollection<InteractionModel>.ConverterFactory.GetRecordsForType<InteractionModel>(InteractionIDs);
                var items = ModelCollection<ItemModel>.ConverterFactory.GetRecordsForType<ItemModel>(ItemIDs);
                #endregion

                #region Read Maps
                var maps = RegionStatus.GetRecords();
                #endregion

                InitializeModelCollections(pronounGroups, games, floors, blocks, furnishings, collectibles, critters, characters,
                                      biomeRecipes, craftingRecipes, roomRecipes, regions, maps, scripts, interactions, items);
                return true;
            }
            catch (Exception loadException)
            {
                Logger.Log(LogLevel.Error, Resources.ErrorLoading, loadException);
                return false;
            }
        }

        /// <summary>
        /// Stores the content of <see cref="All"/> to CSV files for later reinitialization.
        /// </summary>
        /// <returns><c>true</c> if no exceptions were caught, <c>false</c> otherwise.</returns>
        public static bool TrySaveModels()
        {
            try
            {
                #region Write Configuration
                BiomeConfiguration.PutRecord();
                CraftConfiguration.PutRecord();
                InventoryConfiguration.PutRecord();
                RoomConfiguration.PutRecord();
                #endregion

                #region Write Models
                Games.PutRecordsForType<GameModel>();
                Floors.PutRecordsForType<FloorModel>();
                Blocks.PutRecordsForType<BlockModel>();
                Furnishings.PutRecordsForType<FurnishingModel>();
                Collectibles.PutRecordsForType<CollectibleModel>();
                Critters.PutRecordsForType<CritterModel>();
                Characters.PutRecordsForType<CharacterModel>();
                BiomeRecipes.PutRecordsForType<BiomeRecipe>();
                CraftingRecipes.PutRecordsForType<CraftingRecipe>();
                RoomRecipes.PutRecordsForType<RoomRecipe>();
                Regions.PutRecordsForType<RegionModel>();
                Scripts.PutRecordsForType<ScriptModel>();
                Interactions.PutRecordsForType<InteractionModel>();
                Items.PutRecordsForType<ItemModel>();
                #endregion

                #region Write Other Collections
                PronounGroup.PutRecords(PronounGroups);
                RegionStatus.PutRecords(RegionStatuses);
                #endregion

                return true;
            }
            catch (Exception saveException)
            {
                Logger.Log(LogLevel.Error, Resources.ErrorSaving, saveException);
                return false;
            }
        }

        /// <summary>
        /// Clears all the <see cref="ModelCollection{T}"/>s contained in <see cref="All"/>.
        /// </summary>
        /// <remarks>
        /// This method must be called between calls to the initialization routines.
        /// This method is only available when <see cref="LibraryState.IsPlayMode"/> is <c>true</c>.
        /// Typically, games should initialize <see cref="All"/> only once per run whereas tools may reinitialize any number of times.
        /// </remarks>
        public static void Clear()
        {
            if (LibraryState.IsPlayMode)
            {
                Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.WarningUnavailableDuringPlay,
                                                           $"{nameof(All.Clear)}"));
            }
            else
            {
                ((IMutableModelCollection<GameModel>)Games)?.Clear();
                ((IMutableModelCollection<FloorModel>)Floors)?.Clear();
                ((IMutableModelCollection<BlockModel>)Blocks)?.Clear();
                ((IMutableModelCollection<FurnishingModel>)Furnishings)?.Clear();
                ((IMutableModelCollection<CollectibleModel>)Collectibles)?.Clear();
                ((IMutableModelCollection<CritterModel>)Critters)?.Clear();
                ((IMutableModelCollection<CharacterModel>)Characters)?.Clear();
                ((IMutableModelCollection<BiomeRecipe>)BiomeRecipes)?.Clear();
                ((IMutableModelCollection<CraftingRecipe>)CraftingRecipes)?.Clear();
                ((IMutableModelCollection<RoomRecipe>)RoomRecipes)?.Clear();
                ((IMutableModelCollection<RegionModel>)Regions)?.Clear();
                ((IMutableModelCollection<ScriptModel>)Scripts)?.Clear();
                ((IMutableModelCollection<InteractionModel>)Interactions)?.Clear();
                ((IMutableModelCollection<ItemModel>)Items)?.Clear();
                ((HashSet<PronounGroup>)PronounGroups)?.Clear();
                RegionStatuses?.Clear();
                CollectionsHaveBeenInitialized = false;
            }
        }
        #endregion

        #region ModelID Range Helper Methods
        /// <summary>
        /// Given a <see cref="ModelID"/>, return the <see cref="Range{ModelID}"/> within which it is defined.
        /// </summary>
        /// <param name="id">The ID whose <see cref="Range{ModelID}"/> is sought.</param>
        /// <returns>
        /// The range within which this <see cref="ModelID"/> is defined, or <see cref="Range{ModelID}.None"/> if there is none.
        /// </returns>
        public static Range<ModelID> GetIDRangeForType(ModelID id)
            => id == ModelID.None
                ? Range<ModelID>.None
                : AllDefinedIDs.Where(range => range.ContainsValue(id)).DefaultIfEmpty(Range<ModelID>.None).First();

        /// <summary>
        /// Given an instance of <see cref="Model"/>, return the appropriate <see cref="Range{ModelID}"/>.
        /// </summary>
        /// <param name="model">The model whose <see cref="Range{ModelID}"/> is sought.</param>
        /// <returns>
        /// The range within which this model's <see cref="ModelID"/> is defined, or <see cref="Range{ModelID}.None"/> if there is none.
        /// </returns>
        public static Range<ModelID> GetIDRangeForType(Model model)
            => model is null
            || model.ID == ModelID.None
                ? Range<ModelID>.None
                : model switch
                {
                    GameModel _ => GameIDs,
                    FloorModel _ => FloorIDs,
                    BlockModel _ => BlockIDs,
                    FurnishingModel _ => FurnishingIDs,
                    CollectibleModel _ => CollectibleIDs,
                    CritterModel _ => CritterIDs,
                    CharacterModel _ => CharacterIDs,
                    BiomeRecipe _ => BiomeRecipeIDs,
                    CraftingRecipe _ => CraftingRecipeIDs,
                    RoomRecipe _ => RoomRecipeIDs,
                    RegionModel _ => RegionIDs,
                    ScriptModel _ => ScriptIDs,
                    InteractionModel _ => InteractionIDs,
                    ItemModel _ => ItemIDs,
                    _ => Range<ModelID>.None,
                };

        /// <summary>
        /// Given a <see cref="Type"/> derived from a <see cref="Model"/>, return the appropriate <see cref="Range{ModelID}"/>.
        /// </summary>
        /// <param name="modelType">The model type whose ID range is sought.</param>
        /// <returns>
        /// The range within which this model type's <see cref="ModelID"/> would be defined,
        /// or <see cref="Range{ModelID}.None"/> if none exists.
        /// </returns>
        public static Range<ModelID> GetIDRangeForType(Type modelType)
            => modelType == typeof(GameModel) ? GameIDs
            : modelType == typeof(BlockModel) ? BlockIDs
            : modelType == typeof(FloorModel) ? FloorIDs
            : modelType == typeof(FurnishingModel) ? FurnishingIDs
            : modelType == typeof(CollectibleModel) ? CollectibleIDs
            : modelType == typeof(CritterModel) ? CritterIDs
            : modelType == typeof(CharacterModel) ? CharacterIDs
            : modelType == typeof(BiomeRecipe) ? BiomeRecipeIDs
            : modelType == typeof(CraftingRecipe) ? CraftingRecipeIDs
            : modelType == typeof(RoomRecipe) ? RoomRecipeIDs
            : modelType == typeof(RegionModel) ? RegionIDs
            : modelType == typeof(ScriptModel) ? ScriptIDs
            : modelType == typeof(InteractionModel) ? InteractionIDs
            : modelType == typeof(ItemModel) ? ItemIDs
            : Range<ModelID>.None;
        #endregion
    }
}
