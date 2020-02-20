using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// Configurations for a sandbox collectible object, such as crafting materials.
    /// </summary>
    public sealed class CollectibleModel : ParquetModel
    {
        #region Class Defaults
        /// <summary>The set of values that are allowed for Collectible IDs.</summary>
        public static Range<EntityID> Bounds => All.CollectibleIDs;
        #endregion

        #region Characteristics
        /// <summary>The effect generated when a character encounters this Collectible.</summary>
        [Index(7)]
        public CollectingEffect CollectionEffect { get; }

        /// <summary>
        /// The scale in points of the effect.
        /// For example, how much to alter a stat if the <see cref="CollectingEffect"/> is set to alter a stat.
        /// </summary>
        [Index(8)]
        public int EffectAmount { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="CollectibleModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the parquet.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the parquet.  Cannot be null.</param>
        /// <param name="inDescription">Player-friendly description of the parquet.</param>
        /// <param name="inComment">Comment of, on, or by the parquet.</param>
        /// <param name="inItemID">The <see cref="EntityID"/> of the <see cref="Item"/> that this <see cref="CollectibleModel"/> corresponds to, if any.</param>
        /// <param name="inAddsToBiome">A set of flags indicating which, if any, <see cref="BiomeModel"/> this parquet helps to generate.</param>
        /// <param name="inEffect">Effect of this collectible.</param>
        /// <param name="inEffectAmount">
        /// The scale in points of the effect.
        /// For example, how much to alter a stat if inEffect is set to alter a stat.
        /// </param>
        public CollectibleModel(EntityID inID, string inName, string inDescription, string inComment,
                           EntityID? inItemID = null, EntityTag inAddsToBiome = null,
                           EntityTag inAddsToRoom = null, CollectingEffect inEffect = CollectingEffect.None,
                           int inEffectAmount = 0)
            : base(Bounds, inID, inName, inDescription, inComment, inItemID ?? EntityID.None,
                   inAddsToBiome ?? EntityTag.None, inAddsToRoom ?? EntityTag.None)
        {
            var nonNullItemID = inItemID ?? EntityID.None;
            Precondition.IsInRange(nonNullItemID, All.ItemIDs, nameof(inItemID));

            CollectionEffect = inEffect;
            EffectAmount = inEffectAmount;
        }
        #endregion
    }
}
