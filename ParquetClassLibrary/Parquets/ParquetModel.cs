using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// Models a sandbox parquet.
    /// </summary>
    public abstract class ParquetModel : EntityModel
    {
        #region Characteristics
        /// <summary>
        /// The <see cref="EntityID"/> of the <see cref="Items.ItemModel"/> awarded to the player when a character gathers or collects this parquet.
        /// </summary>
        public EntityID ItemID { get; }

        /// <summary>
        /// Describes the <see cref="BiomeModel"/>(s) that this parquet helps form.
        /// Guaranteed to never be <c>null</c>.
        /// </summary>
        public EntityTag AddsToBiome { get; }

        /// <summary>
        /// A property of the parquet that can, for example, be used by <see cref="Rooms.RoomRecipe"/>s.
        /// Guaranteed to never be <c>null</c>.
        /// </summary>
        /// <remarks>
        /// Allows the creation of classes of constructs, for example "wooden", "golden", "rustic", or "fancy" rooms.
        /// </remarks>
        public EntityTag AddsToRoom { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Used by children of the <see cref="ParquetModel"/> class.
        /// </summary>
        /// <param name="inBounds">The bounds within which the derived parquet type's EntityID is defined.</param>
        /// <param name="inID">Unique identifier for the parquet.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the parquet.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the parquet.</param>
        /// <param name="inComment">Comment of, on, or by the parquet.</param>
        /// <param name="inItemID">The <see cref="EntityID"/> of the <see cref="Items.ItemModel"/> awarded to the player when a character gathers or collects this parquet.</param>
        /// <param name="inAddsToBiome">Describes which, if any, <see cref="BiomeModel"/>(s) this parquet helps form.</param>
        /// <param name="inAddsToRoom">Describes which, if any, <see cref="Rooms.RoomRecipe"/>(s) this parquet helps form.</param>
        protected ParquetModel(Range<EntityID> inBounds, EntityID inID, string inName, string inDescription,
                                string inComment, EntityID inItemID, EntityTag inAddsToBiome, EntityTag inAddsToRoom)
            : base(inBounds, inID, inName, inDescription, inComment)
        {
            Precondition.IsInRange(inItemID, All.ItemIDs, nameof(inItemID));

            ItemID = inItemID;
            AddsToBiome = string.IsNullOrEmpty(inAddsToBiome) ? EntityTag.None : inAddsToBiome;
            AddsToRoom = string.IsNullOrEmpty(inAddsToRoom) ? EntityTag.None : inAddsToRoom;
        }
        #endregion

        #region Serialization
        /// <summary>
        /// Parent class for all shims of parquet definitions.
        /// </summary>
        internal abstract class ParquetModelShim : EntityShim
        {
            /// <summary>The <see cref="EntityID"/> of the item that corresponds to this parquet.</summary>
            public EntityID ItemID;

            /// <summary>The <see cref="BiomeModel"/>(s) this parquet helps form.</summary>
            public EntityTag AddsToBiome;

            /// <summary>The <see cref="Rooms.RoomRecipe"/>(s) this parquet helps form.</summary>
            public EntityTag AddsToRoom;
        }
        #endregion
    }
}
