using System.Collections.Generic;
using Newtonsoft.Json;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// Configurations for a sandbox-mode Characters, Furnishings, Crafting Materils, etc.
    /// </summary>
    public sealed class Collectible : ParquetParent
    {
        #region Class Defaults
        /// <summary>The set of values that are allowed for Collectible IDs.</summary>
        // TODO Test if we can remove this ignore tag.
        [JsonIgnore]
        public static Range<EntityID> Bounds => All.CollectibleIDs;
        #endregion

        #region Parquet Mechanics
        /// <summary>The effect generated when a character encounters this Collectible.</summary>
        [JsonProperty(PropertyName = "in_effect")]
        public CollectionEffect Effect { get; }

        /// <summary>
        /// The scale in points of the effect.  That is, how much to alter a stat if the
        /// <see cref="CollectionEffect"/> is set to alter a stat.
        /// </summary>
        [JsonProperty(PropertyName = "in_effectAmount")]
        public int EffectAmount { get; }

        /// <summary>The item spawned when a character encounters this Collectible.</summary>
        [JsonProperty(PropertyName = "in_itemID")]
        public EntityID ItemID { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="Collectible"/> class.
        /// </summary>
        /// <param name="in_id">Unique identifier for the parquet.  Cannot be null.</param>
        /// <param name="in_name">Player-friendly name of the parquet.  Cannot be null.</param>
        /// <param name="in_addsToBiome">
        /// A set of flags indicating which, if any, <see cref="Biome"/> this parquet helps to generate.
        /// </param>
        /// <param name="in_effect">Effect of this collectible.</param>
        /// <param name="in_effectAmount">
        /// The scale in points of the effect.  That is, how much to alter a stat if in_effect is set to alter a stat.
        /// </param>
        /// <param name="in_itemID">The item that this collectible corresponds to, if any.</param>
        [JsonConstructor]
        public Collectible(EntityID in_id, string in_name, List<EntityTag> in_addsToBiome = null,
                           CollectionEffect in_effect = CollectionEffect.None, int in_effectAmount = 0,
                           EntityID? in_itemID = null)
            : base(Bounds, in_id, in_name, in_addsToBiome)
        {
            var nonNullItemID = in_itemID ?? EntityID.None;

            Precondition.IsInRange(nonNullItemID, All.ItemIDs, nameof(in_itemID));

            Effect = in_effect;
            EffectAmount = in_effectAmount;
            ItemID = nonNullItemID;
        }
        #endregion
    }
}
