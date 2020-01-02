using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// Configurations for a sandbox-mode Furniture and similar items.
    /// </summary>
    public sealed class Furnishing : ParquetParent
    {
        #region Class Defaults
        /// <summary>The set of values that are allowed for Furnishing IDs.</summary>
        public static Range<EntityID> Bounds => All.FurnishingIDs;
        #endregion

        #region Parquet Mechanics
        /// <summary>Indicates whether this <see cref="Furnishing"/> may be walked on.</summary>
        public bool IsWalkable { get; }

        /// <summary>Indicates whether this <see cref="Furnishing"/> serves as an entry to a <see cref="Room"/>.</summary>
        public bool IsEntry { get; }

        /// <summary>Indicates whether this <see cref="Furnishing"/> serves as part of a perimeter of a <see cref="Room"/>.</summary>
        public bool IsEnclosing { get; }

        /// <summary>The <see cref="Furnishing"/> to swap with this Furnishing on an open/close action.</summary>
        public EntityID SwapID { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="Furnishing"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="Furnishing"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="Furnishing"/>.  Cannot be null or empty.</param>
        /// <param name="inItemID">The <see cref="EntityID"/> that represents this <see cref="Furnishing"/> in the <see cref="Inventory"/>.</param>
        /// <param name="inDescription">Player-friendly description of the parquet.</param>
        /// <param name="inComment">Comment of, on, or by the parquet.</param>
        /// <param name="inAddsToBiome">Indicates which, if any, <see cref="Biome"/> this parquet helps to generate.</param>
        /// <param name="inAddsToRoom">Describes which, if any, <see cref="Rooms.RoomRecipe"/>(s) this parquet helps form.</param>
        /// <param name="inIsWalkable">If <c>true</c> this <see cref="Furnishing"/> may be walked on.</param>
        /// <param name="inIsEntry">If <c>true</c> this <see cref="Furnishing"/> serves as an entry to a <see cref="Room"/>.</param>
        /// <param name="inIsEnclosing">If <c>true</c> this <see cref="Furnishing"/> serves as part of a perimeter of a <see cref="Room"/>.</param>
        /// <param name="inSwapID">A <see cref="Furnishing"/> to swap with this furnishing on open/close actions.</param>
        public Furnishing(EntityID inID, string inName, string inDescription, string inComment,
                          EntityID? inItemID = null, EntityTag inAddsToBiome = null,
                          EntityTag inAddsToRoom = null, bool inIsWalkable = false,
                          bool inIsEntry = false, bool inIsEnclosing = false, EntityID? inSwapID = null)
            : base(Bounds, inID, inName, inDescription, inComment, inItemID ?? EntityID.None,
                   inAddsToBiome ?? EntityTag.None, inAddsToRoom ?? EntityTag.None)
        {
            var nonNullSwapID = inSwapID ?? EntityID.None;
            Precondition.IsInRange(nonNullSwapID, Bounds, nameof(inSwapID));

            IsWalkable = inIsWalkable;
            IsEntry = inIsEntry;
            IsEnclosing = inIsEnclosing;
            SwapID = nonNullSwapID;
        }
        #endregion
    }
}
