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
        public static Range<EntityID> Bounds => All.CollectibleIDs;
        #endregion

        #region Parquet Mechanics
        /// <summary>The effect generated when a character encounters this Collectible.</summary>
        [JsonProperty(PropertyName = "in_effect")]
        public CollectEffect Effect { get; }

        /// <summary>
        /// The scale in points of the effect.  For example, how much to alter a stat if the
        /// <see cref="CollectEffect"/> is set to alter a stat.
        /// </summary>
        [JsonProperty(PropertyName = "in_effectAmount")]
        public int EffectAmount { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="Collectible"/> class.
        /// </summary>
        /// <param name="in_id">Unique identifier for the parquet.  Cannot be null.</param>
        /// <param name="in_name">Player-friendly name of the parquet.  Cannot be null.</param>
        /// <param name="in_description">Player-friendly description of the parquet.</param>
        /// <param name="in_comment">Comment of, on, or by the parquet.</param>
        /// <param name="in_itemID">The <see cref="EntityID"/> of the <see cref="Item"/> that this <see cref="Collectible"/> corresponds to, if any.</param>
        /// <param name="in_addsToBiome">A set of flags indicating which, if any, <see cref="Biome"/> this parquet helps to generate.</param>
        /// <param name="in_effect">Effect of this collectible.</param>
        /// <param name="in_effectAmount">
        /// The scale in points of the effect.
        /// For example, how much to alter a stat if in_effect is set to alter a stat.
        /// </param>
        [JsonConstructor]
        public Collectible(EntityID in_id, string in_name, string in_description, string in_comment,
                           EntityID? in_itemID = null, EntityTag in_addsToBiome = null,
                           EntityTag in_addsToRoom = null, CollectEffect in_effect = CollectEffect.None,
                           int in_effectAmount = 0)
            : base(Bounds, in_id, in_name, in_description, in_comment, in_itemID ?? EntityID.None,
                   in_addsToBiome ?? EntityTag.None, in_addsToRoom ?? EntityTag.None)
        {
            var nonNullItemID = in_itemID ?? EntityID.None;
            Precondition.IsInRange(nonNullItemID, All.ItemIDs, nameof(in_itemID));

            Effect = in_effect;
            EffectAmount = in_effectAmount;
        }
        #endregion
    }
}
