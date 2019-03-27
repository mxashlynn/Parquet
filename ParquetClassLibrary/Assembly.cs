using ParquetClassLibrary.Sandbox.ID;
using ParquetClassLibrary.Utilities;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("ParquetUnitTests")]

namespace ParquetClassLibrary
{
    /// <summary>
    /// Provides assembly-wide information.
    /// </summary>
    public struct Assembly
    {
        /// <summary>Describes the version of the serialized data that this class understands.</summary>
        public const string SupportedDataVersion = "0.1.0";

        #region Sandbox Parquet ID Ranges
        /// <summary>
        /// A subset of the values of <see cref="T:ParquetClassLibrary.Sandbox.ParquetID"/> set aside for Floors.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test parquets.
        /// </summary>
        public static readonly Range<EnitityID> FloorIDs = new Range<EnitityID>(10000, 19000);

        /// <summary>
        /// A subset of the values of <see cref="T:ParquetClassLibrary.Sandbox.ParquetID"/> set aside for Blocks.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test parquets.
        /// </summary>
        public static readonly Range<EnitityID> BlockIDs = new Range<EnitityID>(20000, 29000);

        /// <summary>
        /// A subset of the values of <see cref="T:ParquetClassLibrary.Sandbox.ParquetID"/> set aside for Furnishings.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test parquets.
        /// </summary>
        public static readonly Range<EnitityID> FurnishingIDs = new Range<EnitityID>(30000, 39000);

        /// <summary>
        /// A subset of the values of <see cref="T:ParquetClassLibrary.Sandbox.ParquetID"/> set aside for Collectables.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test parquets.
        /// </summary>
        public static readonly Range<EnitityID> CollectableIDs = new Range<EnitityID>(40000, 49000);
        #endregion

        #region Sandbox Map Element Dimensions
        /// <summary>The length of each chunk dimension in parquets.</summary>
        public const int ParquetsPerChunkDimension = 16;

        /// <summary>The length of each region dimension in chunks.</summary>
        public const int ChunksPerRegionDimension = 4;

        /// <summary>The length of each region dimension in parquets.</summary>
        public const int ParquetsPerRegionDimension = ChunksPerRegionDimension * ParquetsPerChunkDimension;
        #endregion
    }
}
