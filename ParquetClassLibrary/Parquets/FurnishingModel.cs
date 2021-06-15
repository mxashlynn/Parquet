using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CsvHelper.Configuration.Attributes;
using Parquet.Biomes;

namespace Parquet.Parquets
{
    /// <summary>
    /// Configurations for large sandbox parquet items, such as furniture or plants.
    /// </summary>
    [SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
                     Justification = "By design, subtypes of Model should never themselves use IMutableModel or derived interfaces to access their own members.  The IMutableModel family of interfaces is for external types that require read/write access.")]
    public class FurnishingModel : ParquetModel, IMutableFurnishingModel
    {
        #region Class Defaults
        /// <summary>The set of values that are allowed for Furnishing IDs.</summary>
        public static Range<ModelID> Bounds
            => All.FurnishingIDs;
        #endregion

        #region Characteristics
        /// <summary>If <c>true</c> this <see cref="FurnishingModel"/> may be walked on.</summary>
        [Index(8)]
        public bool IsWalkable { get; private set; }

        /// <summary>Indicates if and how this <see cref="FurnishingModel"/> serves as an entry to a <see cref="Rooms.Room"/> or <see cref="Regions.RegionModel"/>.</summary>
        [Index(9)]
        public EntryType Entry { get; private set; }

        /// <summary>If <c>true</c> this <see cref="FurnishingModel"/> serves as part of a perimeter of a <see cref="Rooms.Room"/>.</summary>
        [Index(10)]
        public bool IsEnclosing { get; private set; }

        /// <summary>If <c>true</c> the <see cref="FurnishingModel"/> may catch fire.</summary>
        [Index(11)]
        public bool IsFlammable { get; private set; }

        /// <summary>If <c>true</c> this <see cref="FurnishingModel"/> may be opened and closed.</summary>
        [Index(12)]
        public bool IsOpenable { get; private set; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="FurnishingModel"/> class.
        /// </summary>
        /// <param name="id">Unique identifier for the <see cref="FurnishingModel"/>.  Cannot be null.</param>
        /// <param name="name">Player-friendly name of the <see cref="FurnishingModel"/>.  Cannot be null or empty.</param>
        /// <param name="description">Player-friendly description of the <see cref="FurnishingModel"/>.</param>
        /// <param name="comment">Comment of, on, or by the <see cref="FurnishingModel"/>.</param>
        /// <param name="tags">Any additional information about the <see cref="FurnishingModel"/>.</param>
        /// <param name="itemID">The <see cref="ModelID"/> that represents this <see cref="FurnishingModel"/> in the <see cref="Items.InventoryCollection"/>.</param>
        /// <param name="addsToBiome">Indicates which, if any, <see cref="BiomeRecipe"/> this parquet helps to generate.</param>
        /// <param name="addsToRoom">Describes which, if any, <see cref="Rooms.RoomRecipe"/>(s) this parquet helps form.</param>
        /// <param name="isWalkable">If <c>true</c> this <see cref="FurnishingModel"/> may be walked on.</param>
        /// <param name="entry">If <c>true</c> this <see cref="FurnishingModel"/> serves as an entry to a <see cref="Rooms.Room"/>.</param>
        /// <param name="isEnclosing">If <c>true</c> this <see cref="FurnishingModel"/> serves as part of a perimeter of a <see cref="Rooms.Room"/>.</param>
        /// <param name="isFlammable">If <c>true</c> this <see cref="FurnishingModel"/> may catch fire.</param>
        /// <param name="isOpenable">If <c>true</c> this <see cref="FurnishingModel"/> may be opened and closed.</param>
        public FurnishingModel(ModelID id, string name, string description, string comment,
                               IEnumerable<ModelTag> tags = null, ModelID? itemID = null,
                               IEnumerable<ModelTag> addsToBiome = null, IEnumerable<ModelTag> addsToRoom = null,
                               bool isWalkable = false, EntryType entry = EntryType.None, bool isEnclosing = false,
                               bool isFlammable = false, bool isOpenable = false)
            : base(Bounds, id, name, description, comment, tags, itemID, addsToBiome, addsToRoom)
        {
            IsWalkable = isWalkable;
            Entry = entry;
            IsEnclosing = isEnclosing;
            IsFlammable = isFlammable;
            IsOpenable = isOpenable;
        }
        #endregion

        #region IMutableFurnishingModel Implementation
        /// <summary>If <c>true</c> this <see cref="FurnishingModel"/> may be walked on.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableFurnishingModel"/>.
        /// IMutableFurnishingModel is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        bool IMutableFurnishingModel.IsWalkable
        {
            get => IsWalkable;
            set => IsWalkable = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(IsWalkable), IsWalkable)
                : value;
        }

        /// <summary>Indicates if and how this <see cref="FurnishingModel"/> serves as an entry to a <see cref="Rooms.Room"/> or <see cref="Regions.RegionModel"/>.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableFurnishingModel"/>.
        /// IMutableFurnishingModel is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        EntryType IMutableFurnishingModel.Entry
        {
            get => Entry;
            set => Entry = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(Entry), Entry)
                : value;
        }

        /// <summary>If <c>true</c> this <see cref="FurnishingModel"/> serves as part of a perimeter of a <see cref="Rooms.Room"/>.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableFurnishingModel"/>.
        /// IMutableFurnishingModel is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        bool IMutableFurnishingModel.IsEnclosing
        {
            get => IsEnclosing;
            set => IsEnclosing = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(IsEnclosing), IsEnclosing)
                : value;
        }

        /// <summary>If <c>true</c> the <see cref="FurnishingModel"/> may catch fire.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableFurnishingModel"/>.
        /// IMutableFurnishingModel is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        bool IMutableFurnishingModel.IsFlammable
        {
            get => IsFlammable;
            set => IsFlammable = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(IsFlammable), IsFlammable)
                : value;
        }

        /// <summary>If <c>true</c> this <see cref="FurnishingModel"/> may be opened and closed.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableFurnishingModel"/>.
        /// IMutableFurnishingModel is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        bool IMutableFurnishingModel.IsOpenable
        {
            get => IsOpenable;
            set => IsOpenable = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(IsOpenable), IsOpenable)
                : value;
        }
        #endregion
    }
}
