using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CsvHelper.Configuration.Attributes;
using Parquet.Biomes;

namespace Parquet.Parquets
{
    /// <summary>
    /// Models a sandbox parquet.
    /// </summary>
    public abstract class ParquetModel : Model, IMutableParquetModel
    {
        #region Characteristics
        /// <summary>
        /// The <see cref="ModelID"/> of the <see cref="Items.ItemModel"/> awarded to the player when a character gathers or collects this parquet.
        /// </summary>
        [Index(5)]
        public ModelID ItemID { get; protected set; }

        /// <summary>
        /// Describes the <see cref="BiomeRecipe"/>(s) that this parquet helps form.
        /// Guaranteed to never be <c>null</c>.
        /// </summary>
        [Index(6)]
        public IReadOnlyList<ModelTag> AddsToBiome { get; protected set; }

        /// <summary>
        /// A property of the parquet that can, for example, be used by <see cref="Rooms.RoomRecipe"/>s.
        /// Guaranteed to never be <c>null</c>.
        /// </summary>
        /// <remarks>
        /// Allows the creation of classes of constructs, for example "wooden", "golden", "rustic", or "fancy" rooms.
        /// </remarks>
        [Index(7)]
        public IReadOnlyList<ModelTag> AddsToRoom { get; protected set; }
        #endregion

        #region Initialization
        /// <summary>
        /// Used by subtypes of the <see cref="ParquetModel"/> class.
        /// </summary>
        /// <param name="bounds">The bounds within which the derived parquet type's ModelID is defined.</param>
        /// <param name="id">Unique identifier for the parquet.  Cannot be null.</param>
        /// <param name="name">Player-friendly name of the parquet.  Cannot be null or empty.</param>
        /// <param name="description">Player-friendly description of the parquet.</param>
        /// <param name="comment">Comment of, on, or by the parquet.</param>
        /// <param name="tags">Any additional information about this parquet.</param>
        /// <param name="itemID">The <see cref="ModelID"/> of the <see cref="Items.ItemModel"/> awarded to the player when a character gathers or collects this parquet.</param>
        /// <param name="addsToBiome">Describes which, if any, <see cref="BiomeRecipe"/>(s) this parquet helps form.</param>
        /// <param name="addsToRoom">Describes which, if any, <see cref="Rooms.RoomRecipe"/>(s) this parquet helps form.</param>
        protected ParquetModel(Range<ModelID> bounds, ModelID id, string name, string description, string comment,
                               IEnumerable<ModelTag> tags = null, ModelID? itemID = null,
                               IEnumerable<ModelTag> addsToBiome = null, IEnumerable<ModelTag> addsToRoom = null)
            : base(bounds, id, name, description, comment, tags)
        {
            var nonNullItemID = itemID ?? ModelID.None;
            var nonNullAddsToBiome = (addsToBiome ?? Enumerable.Empty<ModelTag>()).ToList();
            var nonNullAddsToRoom = (addsToRoom ?? Enumerable.Empty<ModelTag>()).ToList();

            Precondition.IsInRange(nonNullItemID, All.ItemIDs, nameof(itemID));

            ItemID = nonNullItemID;
            AddsToBiome = nonNullAddsToBiome;
            AddsToRoom = nonNullAddsToRoom;
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a collection of all <see cref="ModelTag"/>s the <see cref="Model"/> has applied to it. Classes inheriting from <see cref="Model"/> that include <see cref="ModelTag"/> should override accordingly.
        /// </summary>
        /// <returns>List of all <see cref="ModelTag"/>s.</returns>
        public override IEnumerable<ModelTag> GetAllTags()
            => base.GetAllTags().Union(AddsToBiome).Union(AddsToRoom);
        #endregion

        #region IMutableParquetModel Implementation
        /// <summary>
        /// The <see cref="ModelID"/> of the <see cref="Items.ItemModel"/> awarded to the player when a character gathers or collects this parquet.
        /// </summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IMutableModel is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ModelID IMutableParquetModel.ItemID
        {
            get => ItemID;
            set => ItemID = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(ItemID), ItemID)
                : value;
        }

        /// <summary>
        /// Describes the <see cref="BiomeRecipe"/>(s) that this parquet helps form.
        /// Guaranteed to never be <c>null</c>.
        /// </summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IMutableModel is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ICollection<ModelTag> IMutableParquetModel.AddsToBiome
            => LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(AddsToBiome), new Collection<ModelTag>())
                : (ICollection<ModelTag>)AddsToBiome;

        /// <summary>
        /// A property of the parquet that can, for example, be used by <see cref="Rooms.RoomRecipe"/>s.
        /// Guaranteed to never be <c>null</c>.
        /// </summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IMutableModel is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ICollection<ModelTag> IMutableParquetModel.AddsToRoom
            => LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(AddsToRoom), new Collection<ModelTag>())
                : (ICollection<ModelTag>)AddsToRoom;
        #endregion
    }
}
