using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using ParquetClassLibrary;
using ParquetClassLibrary.Utilities;

// Set assembly values.
[assembly: AssemblyTitle("Parquet Class Library")]
[assembly: AssemblyDescription("Core game mechanics for Parquet.")]
[assembly: AssemblyCompany("Queertet")]
[assembly: AssemblyCopyright("2018-2019 Paige Ashlynn")]
[assembly: AssemblyProduct("ParquetClassLibrary")]
[assembly: AssemblyVersion(AssemblyInfo.LibraryVersion)]
[assembly: AssemblyInformationalVersion(AssemblyInfo.LibraryVersion)]
[assembly: AssemblyFileVersion(AssemblyInfo.LibraryVersion)]

// Allow unit tests to access classes and members with internal accessibility.
[assembly: InternalsVisibleTo("ParquetUnitTests")]

namespace ParquetClassLibrary
{
    /// <summary>
    /// Provides assembly-wide information.
    /// </summary>
    public struct AssemblyInfo
    {
        #region Version Strings
        /// <summary>Describes the version of the serialized data that the class library understands.</summary>
        /// <remarks>
        /// The version has the format "{Major}.{Minor}.{Build}".
        /// - Major ⇒ Breaking changes resulting in lost saves.
        /// - Minor ⇒ Backwards-compatible changes, preserving existing saves.
        /// - Build ⇒ Procedural updates that do not imply any changes.
        /// </remarks>
        public const string SupportedDataVersion = "0.1.0";

        /// <summary>Describes the version of the class library itself.</summary>
        /// <remarks>
        /// The version has the format "{Major}.{Minor}.{Patch}.{Build}".
        /// - Major ⇒ Enhancements or fixes that break the API or its serialized data.
        /// - Minor ⇒ Enhancements that do not break the API or its serialized data.
        /// - Patch ⇒ Fixes that do not break the API or its serialized data.
        /// - Build ⇒ Procedural updates that do not imply any changes, such as when rebuilding for APK/IPA submission.
        /// </remarks>
        public const string LibraryVersion = "0.1.0.0";
        #endregion

        #region EntityID Ranges
        /// <summary>
        /// A subset of the values of <see cref="EntityID"/> set aside for <see cref="Sandbox.Parquets.Floor"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test parquets.
        /// </summary>
        public static readonly Range<EntityID> FloorIDs;

        /// <summary>
        /// A subset of the values of <see cref="EntityID"/> set aside for <see cref="Sandbox.Parquets.Block"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test parquets.
        /// </summary>
        public static readonly Range<EntityID> BlockIDs;

        /// <summary>
        /// A subset of the values of <see cref="EntityID"/> set aside for <see cref="Sandbox.Parquets.Furnishing"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test parquets.
        /// </summary>
        public static readonly Range<EntityID> FurnishingIDs;

        /// <summary>
        /// A subset of the values of <see cref="EntityID"/> set aside for <see cref="Sandbox.Parquets.Collectible"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test parquets.
        /// </summary>
        public static readonly Range<EntityID> CollectibleIDs;

        /// <summary>
        /// A collection containing all defined <see cref="Range{EntityID}"/>s of parquet types.
        /// </summary>
        public static readonly List<Range<EntityID>> ParquetIDs = new List<Range<EntityID>>
            {
                FloorIDs, BlockIDs, FurnishingIDs, CollectibleIDs
            };

        /// <summary>
        /// A subset of the values of <see cref="EntityID"/> set aside for <see cref="Characters.Critter"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Items.
        /// </summary>
        public static readonly Range<EntityID> CritterIDs;

        /// <summary>
        /// A subset of the values of <see cref="EntityID"/> set aside for <see cref="Characters.Character"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Items.
        /// </summary>
        public static readonly Range<EntityID> CharacterIDs;

        /// <summary>
        /// A subset of the values of <see cref="EntityID"/> set aside for <see cref="Characters.Player"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Items.
        /// </summary>
        public static readonly Range<EntityID> PlayerIDs;

        /// <summary>
        /// A collection containing all defined <see cref="Range{EntityID}"/>s of <see cref="Characters.Being"/>s.
        /// </summary>
        public static readonly List<Range<EntityID>> BeingIDs = new List<Range<EntityID>>
            {
                CritterIDs, CharacterIDs, PlayerIDs
            };

        /// <summary>
        /// A subset of the values of <see cref="EntityID"/> set aside for <see cref="Sandbox.RoomRecipe"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Items.
        /// </summary>
        public static readonly Range<EntityID> RoomRecipeIDs;

        /// <summary>
        /// A subset of the values of <see cref="EntityID"/> set aside for <see cref="Crafting.CraftingRecipe"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Items.
        /// </summary>
        public static readonly Range<EntityID> CraftingRecipeIDs;

        /// <summary>
        /// A subset of the values of <see cref="EntityID"/> set aside for <see cref="Quests.Quest"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Items.
        /// </summary>
        public static readonly Range<EntityID> QuestIDs;

        /// <summary>
        /// A subset of the values of <see cref="EntityID"/> set aside for <see cref="Items.Item"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Items.
        /// </summary>
        public static readonly Range<EntityID> ItemIDs;
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes the <see cref="Range{EntityID}"/>s defined in <see cref="AssemblyInfo"/>.
        /// This supports defining ItemIDs in terms of the other Ranges.
        /// </summary>
        static AssemblyInfo()
        {
            // By convention, the first EntityID in each Range is a multiple of this number.
            // An exception is made for Critter, Character, and Player as they are treated as sub-ranges.
            var TargetMultiple = 10000;

            FloorIDs = new Range<EntityID>(10000, 19000);
            BlockIDs = new Range<EntityID>(20000, 29000);
            FurnishingIDs = new Range<EntityID>(30000, 39000);
            CollectibleIDs = new Range<EntityID>(40000, 49000);
            CritterIDs = new Range<EntityID>(50000, 52900);
            CharacterIDs = new Range<EntityID>(53000, 55900);
            PlayerIDs = new Range<EntityID>(56000, 58900);
            RoomRecipeIDs = new Range<EntityID>(60000, 69000);
            CraftingRecipeIDs = new Range<EntityID>(70000, 79000);
            QuestIDs = new Range<EntityID>(80000, 89000);

            // The largest Range.Maximum defined in AssemblyInfo, excluding ItemIDs.
            int MaximumIDNotCountingItems = typeof(AssemblyInfo).GetFields()
                .Where(fieldInfo => fieldInfo.FieldType.IsGenericType
                    && fieldInfo.FieldType == typeof(Range<EntityID>)
                    && fieldInfo.Name != nameof(ItemIDs))
                .Select(fieldInfo => fieldInfo.GetValue(null))
                .Cast<Range<EntityID>>()
                .Select(range => range.Maximum)
                .Max();

            // Since ItemIDs is being defined at runtime, its Range.Minimum must be chosen well above existing maxima.
            var ItemLowerBound = TargetMultiple * ((MaximumIDNotCountingItems + (TargetMultiple - 1)) / TargetMultiple);

            // The largest Range.Maximum of any paruet IDs.
            int MaximumParquetID = ParquetIDs
                .Select(range => range.Maximum)
                .Max();

            // The smallest Range.Minimum of any paruet IDs.
            int MinimumParquetID = ParquetIDs
                .Select(range => range.Minimum)
                .Min();

            // Since it is possible for every parquet to have a corresponding item, this range must be at least
            // as large as all four parquet ranges put together.  Therefore, the Range.Maximum is twice the combined
            // ranges of all parquets.
            var ItemUpperBound = ItemLowerBound + 2 * ((TargetMultiple / 10) + MaximumParquetID - MinimumParquetID);

            ItemIDs = new Range<EntityID>(ItemLowerBound, ItemUpperBound);
        }
        #endregion

        #region Sandbox Map Element Dimensions
        /// <summary>The length of each <see cref="T:ParquetClassLibrary.Sandbox.MapChunkGrid"/> dimension in parquets.</summary>
        public const int ParquetsPerChunkDimension = 16;

        /// <summary>The length of each <see cref="T:ParquetClassLibrary.Sandbox.MapRegion"/> dimension in <see cref="T:ParquetClassLibrary.Sandbox.MapChunkGrid"/>s.</summary>
        public const int ChunksPerRegionDimension = 4;

        /// <summary>The length of each <see cref="T:ParquetClassLibrary.Sandbox.MapRegion"/> dimension in parquets.</summary>
        public const int ParquetsPerRegionDimension = ChunksPerRegionDimension * ParquetsPerChunkDimension;

        /// <summary>Width of the <see cref="Crafting.StrikePanel"/> pattern in <see cref="Crafting.CraftingRecipe"/>.</summary>
        public const int PanelPatternWidth = 2;

        /// <summary>Height of the <see cref="Crafting.StrikePanel"/> pattern in <see cref="Crafting.CraftingRecipe"/>.</summary>
        public const int PanelPatternHeight = 8;
        #endregion
    }
}
