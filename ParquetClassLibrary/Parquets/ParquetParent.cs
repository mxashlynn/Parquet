using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// Models a sandbox-mode parquet.
    /// </summary>
    public abstract class ParquetParent : Entity
    {
        /// <summary>
        /// The <see cref="EntityID"/> of the <see cref="Items.Item"/> awarded to the player when a character gathers or collects this parquet.
        /// </summary>
        [JsonProperty(PropertyName = "in_itemID")]
        public EntityID ItemID { get; }

        /// <summary>
        /// Describes the <see cref="Biome"/>(s) that this parquet helps generate.
        /// </summary>
        [JsonProperty(PropertyName = "in_addsToBiome")]
        public EntityTag AddsToBiome { get; }

        /// <summary>
        /// Describes the <see cref="Rooms.RoomRecipe"/>(s) that this parquet helps generate.
        /// </summary>
        [JsonProperty(PropertyName = "in_addsToRoom")]
        public EntityTag AddsToRoom { get; }

        #region Initialization
        /// <summary>
        /// Used by children of the <see cref="ParquetParent"/> class.
        /// </summary>
        /// <param name="in_bounds">The bounds within which the derived parquet type's EntityID is defined.</param>
        /// <param name="in_id">Unique identifier for the parquet.  Cannot be null.</param>
        /// <param name="in_name">Player-friendly name of the parquet.  Cannot be null or empty.</param>
        /// <param name="in_description">Player-friendly description of the parquet.</param>
        /// <param name="in_comment">Comment of, on, or by the parquet.</param>
        /// <param name="in_itemID">The <see cref="EntityID"/> of the <see cref="Items.Item"/> awarded to the player when a character gathers or collects this parquet.</param>
        /// <param name="in_addsToBiome">Describes which, if any, <see cref="Biome"/>(s) this parquet helps form.</param>
        /// <param name="in_addsToRoom">Describes which, if any, <see cref="Rooms.RoomRecipe"/>(s) this parquet helps form.</param>
        [JsonConstructor]
        protected ParquetParent(Range<EntityID> in_bounds, EntityID in_id, string in_name, string in_description,
                                string in_comment, EntityID? in_itemID = null,
                                EntityTag? in_addsToBiome = null, EntityTag? in_addsToRoom = null)
            : base(in_bounds, in_id, in_name, in_description, in_comment)
        {
            var nonNullItemID = in_itemID ?? EntityID.None;
            Precondition.IsInRange(nonNullItemID, All.ItemIDs, nameof(in_itemID));

            ItemID = nonNullItemID;
            AddsToBiome = in_addsToBiome ?? EntityTag.None;
            AddsToRoom = in_addsToRoom ?? EntityTag.None;
        }
        #endregion
    }
}
