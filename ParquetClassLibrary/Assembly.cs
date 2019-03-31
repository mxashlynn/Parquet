using System.Runtime.CompilerServices;
using ParquetClassLibrary.Sandbox.ID;
using ParquetClassLibrary.Utilities;

// Allow unit tests to access classes and members with internal accessibility.
[assembly: InternalsVisibleTo("ParquetUnitTests")]

namespace ParquetClassLibrary
{
    /// <summary>
    /// Provides assembly-wide information.
    /// </summary>
    public struct Assembly
    {
        /// <summary>Describes the version of the serialized data that this class understands.</summary>
        public const string SupportedDataVersion = "0.1.0";

        #region Sandbox Parquet and Item ID Ranges
        /// <summary>
        /// A subset of the values of <see cref="T:ParquetClassLibrary.Sandbox.ID.EntityID"/> set aside for Floors.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test parquets.
        /// </summary>
        public static readonly Range<EntityID> FloorIDs = new Range<EntityID>(10000, 19000);

        /// <summary>
        /// A subset of the values of <see cref="T:ParquetClassLibrary.Sandbox.ID.EntityID"/> set aside for Blocks.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test parquets.
        /// </summary>
        public static readonly Range<EntityID> BlockIDs = new Range<EntityID>(20000, 29000);

        /// <summary>
        /// A subset of the values of <see cref="T:ParquetClassLibrary.Sandbox.ID.EntityID"/> set aside for Furnishings.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test parquets.
        /// </summary>
        public static readonly Range<EntityID> FurnishingIDs = new Range<EntityID>(30000, 39000);

        /// <summary>
        /// A subset of the values of <see cref="T:ParquetClassLibrary.Sandbox.ID.EntityID"/> set aside for Collectables.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test parquets.
        /// </summary>
        public static readonly Range<EntityID> CollectableIDs = new Range<EntityID>(40000, 49000);

        /// <summary>
        /// A subset of the values of <see cref="T:ParquetClassLibrary.Sandbox.ID.EntityID"/> set aside for Items.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test items.
        /// </summary>
        public static readonly Range<EntityID> ItemIDs = new Range<EntityID>(50000, 59000);
        #endregion

        #region Sandbox Map Element Dimensions
        /// <summary>The length of each <see cref="T:ParquetClassLibrary.Sandbox.MapChunkGrid"/> dimension in parquets.</summary>
        public const int ParquetsPerChunkDimension = 16;

        /// <summary>The length of each <see cref="T:ParquetClassLibrary.Sandbox.MapRegion"/> dimension in <see cref="T:ParquetClassLibrary.Sandbox.MapChunkGrid"/>s.</summary>
        public const int ChunksPerRegionDimension = 4;

        /// <summary>The length of each <see cref="T:ParquetClassLibrary.Sandbox.MapRegion"/> dimension in parquets.</summary>
        public const int ParquetsPerRegionDimension = ChunksPerRegionDimension * ParquetsPerChunkDimension;
        #endregion
    }
}
