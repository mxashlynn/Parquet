using System;
using System.Collections.Generic;
using System.Linq;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Beings;
using ParquetClassLibrary.Crafting;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Rooms;
using ParquetClassLibrary.Utilities;
using ParquetClassLibrary.Quests;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Dialogues;

namespace ParquetClassLibrary
{
    /// <summary>
    /// Provides content and identifiers for the game.
    /// </summary>
    /// <remarks>
    /// This is the source of truth about game objects whose definitions do not change during play.<para />
    /// For more details, see remarks on <see cref="EntityModel"/>.
    /// </remarks>
    /// <seealso cref="EntityID"/>
    /// <seealso cref="EntityCollection{T}"/>
    public static class All
    {
        #region EntityID Ranges
        /// <summary>
        /// A subset of the values of <see cref="EntityID"/> set aside for <see cref="Beings.PlayerCharacter"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test characters.
        /// </summary>
        public static readonly Range<EntityID> PlayerCharacterIDs;

        /// <summary>
        /// A subset of the values of <see cref="EntityID"/> set aside for <see cref="Beings.Critter"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Critters.
        /// </summary>
        public static readonly Range<EntityID> CritterIDs;

        /// <summary>
        /// A subset of the values of <see cref="EntityID"/> set aside for <see cref="Beings.NPC"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test NPCs.
        /// </summary>
        public static readonly Range<EntityID> NpcIDs;

        /// <summary>
        /// A collection containing all defined <see cref="Range{EntityID}"/>s of <see cref="Beings.Being"/>s.
        /// </summary>
        public static readonly List<Range<EntityID>> BeingIDs;

        /// <summary>
        /// A subset of the values of <see cref="EntityID"/> set aside for <see cref="Biome"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Biomes.
        /// </summary>
        public static readonly Range<EntityID> BiomeIDs;

        /// <summary>
        /// A subset of the values of <see cref="EntityID"/> set aside for <see cref="CraftingRecipe"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test recipes.
        /// </summary>
        public static readonly Range<EntityID> CraftingRecipeIDs;

        /// <summary>
        /// A subset of the values of <see cref="EntityID"/> set aside for <see cref="Dialogue"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test recipes.
        /// </summary>
        public static readonly Range<EntityID> DialogueIDs;

        /// <summary>
        /// A subset of the values of <see cref="EntityID"/> set aside for <see cref="MapChunk"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Items.
        /// </summary>
        public static readonly Range<EntityID> MapChunkIDs;

        /// <summary>
        /// A subset of the values of <see cref="EntityID"/> set aside for <see cref="MapRegion"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Items.
        /// </summary>
        public static readonly Range<EntityID> MapRegionIDs;

        /// <summary>
        /// A subset of the values of <see cref="EntityID"/> set aside for <see cref="MapParent"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Items.
        /// </summary>
        public static readonly List<Range<EntityID>> MapIDs;

        /// <summary>
        /// A subset of the values of <see cref="EntityID"/> set aside for <see cref="Floor"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test parquets.
        /// </summary>
        public static readonly Range<EntityID> FloorIDs;

        /// <summary>
        /// A subset of the values of <see cref="EntityID"/> set aside for <see cref="Block"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test parquets.
        /// </summary>
        public static readonly Range<EntityID> BlockIDs;

        /// <summary>
        /// A subset of the values of <see cref="EntityID"/> set aside for <see cref="Furnishing"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test parquets.
        /// </summary>
        public static readonly Range<EntityID> FurnishingIDs;

        /// <summary>
        /// A subset of the values of <see cref="EntityID"/> set aside for <see cref="Collectible"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test parquets.
        /// </summary>
        public static readonly Range<EntityID> CollectibleIDs;

        /// <summary>
        /// A collection containing all defined <see cref="Range{EntityID}"/>s of parquets.
        /// </summary>
        public static readonly List<Range<EntityID>> ParquetIDs;

        /// <summary>
        /// A subset of the values of <see cref="EntityID"/> set aside for <see cref="Quest"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Items.
        /// </summary>
        public static readonly Range<EntityID> QuestIDs;

        /// <summary>
        /// A subset of the values of <see cref="EntityID"/> set aside for <see cref="RoomRecipe"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test recipes.
        /// </summary>
        public static readonly Range<EntityID> RoomRecipeIDs;

        /// <summary>
        /// A subset of the values of <see cref="EntityID"/> set aside for <see cref="Item"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Items.
        /// </summary>
        public static readonly Range<EntityID> ItemIDs;
        #endregion

        #region EntityCollections
        /// <summary><c>true</c> if the collections have been initialized; otherwise, <c>false</c>.</summary>
        public static bool CollectionsHaveBeenInitialized { get; private set; }

        /// <summary>
        /// A collection of all defined <see cref="Being"/>s.
        /// This collection is the source of truth about mobs and characters for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="EntityID"/>s must be unique.</remarks>
        public static EntityCollection<Being> Beings { get; private set; }

        /// <summary>
        /// A collection of all defined <see cref="Biome"/>s.
        /// This collection is the source of truth about biome for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="EntityID"/>s must be unique.</remarks>
        public static EntityCollection<Biome> Biomes { get; private set; }

        /// <summary>
        /// A collection of all defined <see cref="CraftingRecipe"/>s.
        /// This collection is the source of truth about crafting for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="EntityID"/>s must be unique.</remarks>
        public static EntityCollection<CraftingRecipe> CraftingRecipes { get; private set; }

        /// <summary>
        /// A collection of all defined <see cref="Dialogue"/>s.
        /// This collection is the source of truth about crafting for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="EntityID"/>s must be unique.</remarks>
        public static EntityCollection<Dialogue> Dialogues { get; private set; }

        /// <summary>
        /// A collection of all defined <see cref="MapParent"/>s.
        /// This collection is the source of truth about biome for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="EntityID"/>s must be unique.</remarks>
        public static EntityCollection<MapParent> Maps { get; private set; }

        /// <summary>
        /// A collection of all defined parquets of all subtypes.
        /// This collection is the source of truth about parquets for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="EntityID"/>s must be unique.</remarks>
        public static EntityCollection<ParquetParent> Parquets { get; private set; }

        /// <summary>
        /// A collection of all defined <see cref="Quest"/>s.
        /// This collection is the source of truth about quests for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="EntityID"/>s must be unique.</remarks>
        public static EntityCollection<Quest> Quests { get; private set; }

        /// <summary>
        /// A collection of all defined <see cref="RoomRecipe"/>s.
        /// This collection is the source of truth about crafting for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="EntityID"/>s must be unique.</remarks>
        public static EntityCollection<RoomRecipe> RoomRecipes { get; private set; }

        /// <summary>
        /// A collection of all defined <see cref="Item"/>s.
        /// This collection is the source of truth about items for the rest of the library,
        /// something like a color palette that other classes can paint with.
        /// </summary>
        /// <remarks>All <see cref="EntityID"/>s must be unique.</remarks>
        public static EntityCollection<Item> Items { get; private set; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes the <see cref="Range{T}"/>s and <see cref="EntityCollection{T}"/>s defined in <see cref="All"/>.
        /// </summary>
        /// <remarks>
        /// This supports defining ItemIDs in terms of the other Ranges.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance",
            "CA1810:Initialize reference type static fields inline",
            Justification = "Inline initializers would notably complicate the code in this instance.")]
        static All()
        {
            #region Default Values for Enitity Collections
            CollectionsHaveBeenInitialized = false;
            Beings = EntityCollection<Being>.Default;
            Biomes = EntityCollection<Biome>.Default;
            CraftingRecipes = EntityCollection<CraftingRecipe>.Default;
            Dialogues = EntityCollection<Dialogue>.Default;
            Maps = EntityCollection<MapParent>.Default;
            Parquets = EntityCollection<ParquetParent>.Default;
            Quests = EntityCollection<Quest>.Default;
            RoomRecipes = EntityCollection<RoomRecipe>.Default;
            Items = EntityCollection<Item>.Default;
            #endregion

            #region Initialize Ranges
            ///<summary>By convention, the first EntityID in each Range is a multiple of this number.</summary>
            ///<remarks>An exception is made for PlayerCharacters as these values are undefined at designtime.</remarks>
            const int TargetMultiple = 10000;

            #region Define Most Ranges
            PlayerCharacterIDs = new Range<EntityID>(1, 9000);
            CritterIDs = new Range<EntityID>(10000, 19000);
            NpcIDs = new Range<EntityID>(20000, 29000);

            BiomeIDs = new Range<EntityID>(30000, 39000);

            CraftingRecipeIDs = new Range<EntityID>(40000, 49000);

            DialogueIDs = new Range<EntityID>(50000, 59000);

            MapChunkIDs = new Range<EntityID>(60000, 69000);
            MapRegionIDs = new Range<EntityID>(70000, 79000);

            FloorIDs = new Range<EntityID>(80000, 89000);
            BlockIDs = new Range<EntityID>(90000, 99000);
            FurnishingIDs = new Range<EntityID>(100000, 109000);
            CollectibleIDs = new Range<EntityID>(110000, 119000);

            QuestIDs = new Range<EntityID>(120000, 129000);

            RoomRecipeIDs = new Range<EntityID>(130000, 139000);
            #endregion

            #region Define Range Collections
            BeingIDs = new List<Range<EntityID>> { PlayerCharacterIDs, CritterIDs, NpcIDs };
            MapIDs = new List<Range<EntityID>> { MapChunkIDs, MapRegionIDs };
            ParquetIDs = new List<Range<EntityID>> { FloorIDs, BlockIDs, FurnishingIDs, CollectibleIDs };
            #endregion

            #region Calculate Item Range
            // The largest Range.Maximum defined in All, excluding ItemIDs.
            int MaximumIDNotCountingItems = typeof(All).GetFields()
                .Where(fieldInfo => fieldInfo.FieldType.IsGenericType
                    && fieldInfo.FieldType == typeof(Range<EntityID>)
                    && fieldInfo.Name != nameof(ItemIDs))
                .Select(fieldInfo => fieldInfo.GetValue(null))
                .Cast<Range<EntityID>>()
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

            ItemIDs = new Range<EntityID>(ItemLowerBound, ItemUpperBound);
            #endregion
            #endregion
        }

        /// <summary>
        /// Initializes the <see cref="EntityCollection{T}s"/> from the given collections.
        /// </summary>
        /// <param name="inBeings">All beings to be used in the game.</param>
        /// <param name="inBiomes">All biomes to be used in the game.</param>
        /// <param name="inCraftingRecipes">All crafting recipes to be used in the game.</param>
        /// <param name="inDialogues">All dialgoues to be used in the game.</param>
        /// <param name="inMaps">All maps to be used in the game.</param>
        /// <param name="inParquets">All parquets to be used in the game.</param>
        /// <param name="inQuests">All quests to be used in the game.</param>
        /// <param name="inRoomRecipes">All room recipes to be used in the game.</param>
        /// <param name="inItems">All items to be used in the game.</param>
        /// <remarks>This initialization routine may be called only once per library execution.</remarks>
        /// <exception cref="InvalidOperationException">When called more than once.</exception>
        public static void InitializeCollections(IEnumerable<Being> inBeings,
                                                 IEnumerable<Biome> inBiomes,
                                                 IEnumerable<CraftingRecipe> inCraftingRecipes,
                                                 IEnumerable<Dialogue> inDialogues,
                                                 IEnumerable<MapParent> inMaps,
                                                 IEnumerable<ParquetParent> inParquets,
                                                 IEnumerable<Quest> inQuests,
                                                 IEnumerable<RoomRecipe> inRoomRecipes,
                                                 IEnumerable<Item> inItems)
        {
            if (CollectionsHaveBeenInitialized)
            {
                throw new InvalidOperationException($"Attempted to reinitialize {typeof(All)}.");
            }
            Precondition.IsNotNull(inBeings, nameof(inBeings));
            Precondition.IsNotNull(inBiomes, nameof(inBiomes));
            Precondition.IsNotNull(inCraftingRecipes, nameof(inCraftingRecipes));
            Precondition.IsNotNull(inDialogues, nameof(inDialogues));
            Precondition.IsNotNull(inMaps, nameof(inMaps));
            Precondition.IsNotNull(inParquets, nameof(inParquets));
            Precondition.IsNotNull(inQuests, nameof(inQuests));
            Precondition.IsNotNull(inRoomRecipes, nameof(inRoomRecipes));
            Precondition.IsNotNull(inItems, nameof(inItems));

            Beings = new EntityCollection<Being>(BeingIDs, inBeings);
            Biomes = new EntityCollection<Biome>(BiomeIDs, inBiomes);
            CraftingRecipes = new EntityCollection<CraftingRecipe>(CraftingRecipeIDs, inCraftingRecipes);
            Dialogues = new EntityCollection<Dialogue>(DialogueIDs, inDialogues);
            Maps = new EntityCollection<MapParent>(MapIDs, inMaps);
            Parquets = new EntityCollection<ParquetParent>(ParquetIDs, inParquets);
            Quests = new EntityCollection<Quest>(QuestIDs, inQuests);
            RoomRecipes = new EntityCollection<RoomRecipe>(RoomRecipeIDs, inRoomRecipes);
            Items = new EntityCollection<Item>(ItemIDs, inItems);
            CollectionsHaveBeenInitialized = true;
        }
        #endregion
    }
}
