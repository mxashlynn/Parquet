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

// Allow unit tests to access classes and members with internal accessibility.
[assembly: InternalsVisibleTo("ParquetUnitTests")]

// The assembly version has the format "{Major}.{Minor}.{Build}.{Revision}".
[assembly: AssemblyVersion(AssemblyInfo.LibraryVersion)]
[assembly: AssemblyInformationalVersion(AssemblyInfo.LibraryVersion)]
[assembly: AssemblyFileVersion(AssemblyInfo.LibraryVersion)]

namespace ParquetClassLibrary
{
    /// <summary>
    /// Provides assembly-wide information.
    /// </summary>
    public struct AssemblyInfo
    {
        /// <summary>Describes the version of the serialized data that the class library understands.</summary>
        public const string SupportedDataVersion = "0.1.0";

        /// <summary>Describes the version of the class library itself.</summary>
        public const string LibraryVersion = "0.1.0.0";

        #region Entity ID Ranges
        /// <summary>
        /// A subset of the values of <see cref="T:ParquetClassLibrary.Sandbox.ID.EntityID"/> set aside for
        /// <see cref="T:ParquetClassLibrary.Sandbox.Parquet.Floor"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test parquets.
        /// </summary>
        public static readonly Range<EntityID> FloorIDs = new Range<EntityID>(10000, 19000);

        /// <summary>
        /// A subset of the values of <see cref="T:ParquetClassLibrary.Sandbox.ID.EntityID"/> set aside for
        /// <see cref="T:ParquetClassLibrary.Sandbox.Parquet.Block"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test parquets.
        /// </summary>
        public static readonly Range<EntityID> BlockIDs = new Range<EntityID>(20000, 29000);

        /// <summary>
        /// A subset of the values of <see cref="T:ParquetClassLibrary.Sandbox.ID.EntityID"/> set aside for
        /// <see cref="T:ParquetClassLibrary.Sandbox.Parquet.Furnishing"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test parquets.
        /// </summary>
        public static readonly Range<EntityID> FurnishingIDs = new Range<EntityID>(30000, 39000);

        /// <summary>
        /// A subset of the values of <see cref="T:ParquetClassLibrary.Sandbox.ID.EntityID"/> set aside for
        /// <see cref="T:ParquetClassLibrary.Sandbox.Parquet.Collectibles"/>s.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test parquets.
        /// </summary>
        public static readonly Range<EntityID> CollectibleIDs = new Range<EntityID>(40000, 49000);

        /// <summary>
        /// The largest <see cref="Range{EntityID}.Maximum"/> defined in <see cref="AssemblyInfo"/>,
        /// excluding <see cref="ItemIDs"/>.
        /// </summary>
        private static readonly int IDsMaxExcludingItems = typeof(AssemblyInfo).GetFields()
            .Where(fieldInfo => fieldInfo.FieldType.IsGenericType
                && fieldInfo.FieldType == typeof(Range<EntityID>)
                && fieldInfo.Name != nameof(ItemIDs))
            .Select(fieldInfo => fieldInfo.GetValue(null))
            .Cast<Range<EntityID>>()
            .Select(range => range.Maximum)
            .Max();

        /// <summary>By convention, the first EntityID in each Range begins with at a multiple of this.</summary>
        private const int TargetMultiple = 10000;

        /// <summary>
        /// A subset of the values of <see cref="T:ParquetClassLibrary.Sandbox.ID.EntityID"/> set aside for items.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Items.
        /// </summary>
        /// <remarks>
        /// Since it is possible for every parquet to have a corresponding item, this range must be at least
        /// as large as all four parquet ranges put together.  Therefore, the <see cref="Range{T}.Minimum"/>
        /// is well above the largest <see cref="Range{EntityID}.Maximum"/> already defined in <see cref="AssemblyInfo"/>.
        /// </remarks>
        public static readonly Range<EntityID> ItemIDs = new Range<EntityID>(
                TargetMultiple * ((FloorIDs.Minimum + IDsMaxExcludingItems + (TargetMultiple - 1)) / TargetMultiple),
                TargetMultiple * ((CollectibleIDs.Maximum + IDsMaxExcludingItems + (TargetMultiple - 1)) / TargetMultiple)
            );

        /// <summary>
        /// A collection containing all defined parquet <see cref="Range{EntityID}"/>s of parquet types.
        /// </summary>
        public static readonly List<Range<EntityID>> ParquetIDs = new List<Range<EntityID>>
            {
                FloorIDs, BlockIDs, FurnishingIDs, CollectibleIDs
            };
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
