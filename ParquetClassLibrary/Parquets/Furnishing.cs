using Newtonsoft.Json;
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
        // TODO Test if we can remove this ignore tag.
        [JsonIgnore]
        public static Range<EntityID> Bounds => All.FurnishingIDs;
        #endregion

        #region Parquet Mechanics
        /// <summary>Indicates whether this <see cref="Furnishing"/> may be walked on.</summary>
        [JsonProperty(PropertyName = "in_isWalkable")]
        public bool IsWalkable { get; }

        /// <summary>Indicates whether this <see cref="Furnishing"/> serves as an entry to a <see cref="Room"/>.</summary>
        [JsonProperty(PropertyName = "in_isEntry")]
        public bool IsEntry { get; }

        /// <summary>Indicates whether this <see cref="Furnishing"/> serves as part of a perimeter of a <see cref="Room"/>.</summary>
        [JsonProperty(PropertyName = "in_isEnclosing")]
        public bool IsEnclosing { get; }

        /// <summary>The <see cref="ItemID"/> that represents this <see cref="Furnishing"/> in the <see cref="Inventory"/>.</summary>
        [JsonProperty(PropertyName = "in_itemID")]
        public EntityID ItemID { get; }

        /// <summary>The <see cref="Furnishing"/> to swap with this Furnishing on an open/close action.</summary>
        [JsonProperty(PropertyName = "in_swapID")]
        public EntityID SwapID { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="Furnishing"/> class.
        /// </summary>
        /// <param name="in_id">Unique identifier for the <see cref="Furnishing"/>.  Cannot be null.</param>
        /// <param name="in_name">Player-friendly name of the <see cref="Furnishing"/>.  Cannot be null or empty.</param>
        /// <param name="in_addsToBiome">Indicates which, if any, <see cref="Biome"/> this parquet helps to generate.</param>
        /// <param name="in_isWalkable">If <c>true</c> this <see cref="Furnishing"/> may be walked/sat upon.</param>
        /// <param name="in_isEntry">If <c>true</c> this <see cref="Furnishing"/> serves as an entry to a <see cref="Room"/>.</param>
        /// <param name="in_isEnclosing">If <c>true</c> this <see cref="Furnishing"/> serves as part of a perimeter of a <see cref="Room"/>.</param>
        /// <param name="in_itemID">The item that represents this furnishing in the inventory.</param>
        /// <param name="in_swapID">A furnishing to swap with this furnishing on open/close actions.</param>
        [JsonConstructor]
        public Furnishing(EntityID in_id, string in_name, BiomeMask in_addsToBiome = BiomeMask.None,
                          bool in_isWalkable = false, bool in_isEntry = false, bool in_isEnclosing = false,
                          EntityID? in_itemID = null, EntityID? in_swapID = null)
            : base(Bounds, in_id, in_name, in_addsToBiome)
        {
            var nonNullItemID = in_itemID ?? EntityID.None;
            var nonNullSwapID = in_swapID ?? EntityID.None;

            Precondition.IsInRange(nonNullItemID, All.ItemIDs, nameof(in_itemID));
            Precondition.IsInRange(nonNullSwapID, Bounds, nameof(in_swapID));

            IsWalkable = in_isWalkable;
            IsEntry = in_isEntry;
            IsEnclosing = in_isEnclosing;
            ItemID = nonNullItemID;
            SwapID = nonNullSwapID;
        }
        #endregion
    }
}
