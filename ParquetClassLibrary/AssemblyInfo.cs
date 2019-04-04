using System.Reflection;
using System.Runtime.CompilerServices;
using ParquetClassLibrary;
using ParquetClassLibrary.Sandbox.ID;
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
        /// A subset of the values of <see cref="T:ParquetClassLibrary.Sandbox.ID.EntityID"/> set aside for items.
        /// Valid identifiers may be positive or negative.  By convention, negative IDs indicate test Items.
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
