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
        [JsonProperty(PropertyName = "inEffect")]
        public CollectEffect Effect { get; }

        /// <summary>
        /// The scale in points of the effect.  For example, how much to alter a stat if the
        /// <see cref="CollectEffect"/> is set to alter a stat.
        /// </summary>
        [JsonProperty(PropertyName = "inEffectAmount")]
        public int EffectAmount { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="Collectible"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the parquet.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the parquet.  Cannot be null.</param>
        /// <param name="inDescription">Player-friendly description of the parquet.</param>
        /// <param name="inComment">Comment of, on, or by the parquet.</param>
        /// <param name="inItemID">The <see cref="EntityID"/> of the <see cref="Item"/> that this <see cref="Collectible"/> corresponds to, if any.</param>
        /// <param name="inAddsToBiome">A set of flags indicating which, if any, <see cref="Biome"/> this parquet helps to generate.</param>
        /// <param name="inEffect">Effect of this collectible.</param>
        /// <param name="inEffectAmount">
        /// The scale in points of the effect.
        /// For example, how much to alter a stat if inEffect is set to alter a stat.
        /// </param>
        [JsonConstructor]
        public Collectible(EntityID inID, string inName, string inDescription, string inComment,
                           EntityID? inItemID = null, EntityTag inAddsToBiome = null,
                           EntityTag inAddsToRoom = null, CollectEffect inEffect = CollectEffect.None,
                           int inEffectAmount = 0)
            : base(Bounds, inID, inName, inDescription, inComment, inItemID ?? EntityID.None,
                   inAddsToBiome ?? EntityTag.None, inAddsToRoom ?? EntityTag.None)
        {
            var nonNullItemID = inItemID ?? EntityID.None;
            Precondition.IsInRange(nonNullItemID, All.ItemIDs, nameof(inItemID));

            Effect = inEffect;
            EffectAmount = inEffectAmount;
        }
        #endregion
    }
}
