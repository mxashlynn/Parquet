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
        /// A set of <see cref="EntityTag"/>s describing the <see cref="Biome"/>(s) thhat this parquet helps generate.
        /// </summary>
        [JsonProperty(PropertyName = "in_addsToBiome")]
        public IReadOnlyList<EntityTag> AddsToBiome { get; }

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
        /// <param name="in_addsToBiome">A set of <see cref="EntityTag"/>s indicating which, if any, <see cref="Biome"/> this parquet helps to generate.</param>
        [JsonConstructor]
        protected ParquetParent(Range<EntityID> in_bounds, EntityID in_id, string in_name, string in_description,
                                string in_comment, EntityID? in_itemID = null, List<EntityTag> in_addsToBiome = null)
            : base(in_bounds, in_id, in_name, in_description, in_comment)
        {
            var nonNullItemID = in_itemID ?? EntityID.None;
            Precondition.IsInRange(nonNullItemID, All.ItemIDs, nameof(in_itemID));

            ItemID = nonNullItemID;
            AddsToBiome = in_addsToBiome ?? Enumerable.Empty<EntityTag>().ToList();
        }
        #endregion
    }
}
