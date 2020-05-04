using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.Biomes;

namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// Configurations for a sandbox collectible object, such as crafting materials.
    /// </summary>
    public sealed class CollectibleModel : ParquetModel
    {
        #region Class Defaults
        /// <summary>The set of values that are allowed for Collectible IDs.</summary>
        public static Range<ModelID> Bounds
            => All.CollectibleIDs;
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
        /// <param name="inItemID">The <see cref="ModelID"/> of the <see cref="Items.ItemModel"/> that this <see cref="CollectibleModel"/> corresponds to, if any.</param>
        /// <param name="inAddsToBiome">A set of flags indicating which, if any, <see cref="BiomeModel"/> this parquet helps to generate.</param>
        /// <param name="inAddsToRoom">A set of flags indicating which, if any, <see cref="Rooms.RoomRecipe"/> this parquet helps to generate.</param>
        /// <param name="inCollectionEffect">Effect of this collectible.</param>
        /// <param name="inEffectAmount">
        /// The scale in points of the effect.
        /// For example, how much to alter a stat if inEffect is set to alter a stat.
        /// </param>
        public CollectibleModel(ModelID inID, string inName, string inDescription, string inComment,
                           ModelID? inItemID = null, ModelTag inAddsToBiome = null,
                           ModelTag inAddsToRoom = null, CollectingEffect inCollectionEffect = CollectingEffect.None,
                           int inEffectAmount = 0)
            : base(Bounds, inID, inName, inDescription, inComment, inItemID ?? ModelID.None,
                   inAddsToBiome ?? ModelTag.None, inAddsToRoom ?? ModelTag.None)
        {
            var nonNullItemID = inItemID ?? ModelID.None;
            Precondition.IsInRange(nonNullItemID, All.ItemIDs, nameof(inItemID));

            CollectionEffect = inCollectionEffect;
            EffectAmount = inEffectAmount;
        }
        #endregion
    }
}
