using Newtonsoft.Json;
using ParquetClassLibrary.Utilities;
using ParquetClassLibrary.Sandbox.ID;
using System;

namespace ParquetClassLibrary.Sandbox.Parquets
{
    /// <summary>
    /// Configurations for a sandbox-mode Furniture and similar items.
    /// </summary>
    public class Furnishing : ParquetParent
    {
        #region Class Defaults
        /// <summary>The set of values that are allowed for Furnishing IDs.</summary>
        [JsonIgnore]
        protected override Range<EntityID> Bounds { get { return Assembly.FurnishingIDs; } }
        #endregion

        #region Parquet Mechanics
        /// <summary>The furnishing may be walked on.</summary>
        [JsonProperty(PropertyName = "in_isWalkable")]
        public bool IsWalkable { get; private set; }

        /// <summary>The item that represents this furnishing in the inventory.</summary>
        [JsonProperty(PropertyName = "in_itemID")]
        public EntityID ItemID { get; private set; }

        /// <summary>The furnishing to swap with this furnishing on an open/close action.</summary>
        [JsonProperty(PropertyName = "in_swapID")]
        public EntityID SwapID { get; private set; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ParquetClassLibrary.Sandbox.Parquets.Furnishing"/> class.
        /// </summary>
        /// <param name="in_ID">Unique identifier for the parquet.  Cannot be null.</param>
        /// <param name="in_name">Player-friendly name of the parquet.  Cannot be null.</param>
        /// <param name="in_addsToBiome">
        /// A set of flags indicating which, if any, <see cref="T:ParquetClassLibrary.Sandbox.Biome"/> this parquet helps to generate.
        /// </param>
        /// <param name="in_isWalkable">If <c>true</c> this furnishing may be walked/sat upon.</param>
        /// <param name="in_itemID">The item that represents this furnishing in the inventory.</param>
        /// <param name="in_swapID">A furnishing to swap with this furnishing on open/close actions.</param>
        [JsonConstructor]
        public Furnishing(EntityID in_ID, string in_name, BiomeMask in_addsToBiome = BiomeMask.None,
                          bool in_isWalkable = false, EntityID? in_itemID = null, EntityID? in_swapID = null)
            : base(in_ID, in_name, in_addsToBiome)
        {
            var nonNullItemID = in_itemID ?? EntityID.None;
            if (!nonNullItemID.IsValidForRange(Assembly.ItemIDs))
            {
                throw new ArgumentOutOfRangeException(nameof(in_itemID));
            }
            var nonNullSwapID = in_swapID ?? EntityID.None;
            if (!nonNullItemID.IsValidForRange(Bounds))
            {
                throw new ArgumentOutOfRangeException(nameof(in_swapID));
            }

            IsWalkable = in_isWalkable;
            ItemID = nonNullItemID;
            SwapID = nonNullSwapID;
        }
        #endregion
    }
}
