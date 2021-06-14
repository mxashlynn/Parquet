using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CsvHelper.Configuration.Attributes;
using Parquet.Biomes;

namespace Parquet.Parquets
{
    /// <summary>
    /// Configurations for a sandbox collectible object, such as crafting materials.
    /// </summary>
    [SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
                     Justification = "By design, subtypes of Model should never themselves use IMutableModel or derived interfaces to access their own members.  The IMutableModel family of interfaces is for external types that require read/write access.")]
    public class CollectibleModel : ParquetModel, IMutableCollectibleModel
    {
        #region Class Defaults
        /// <summary>The set of values that are allowed for Collectible IDs.</summary>
        public static Range<ModelID> Bounds
            => All.CollectibleIDs;
        #endregion

        #region Characteristics
        /// <summary>The effect generated when a character encounters this Collectible.</summary>
        [Index(8)]
        public CollectingEffect CollectionEffect { get; private set; }

        /// <summary>
        /// The scale in points of the effect.
        /// For example, how much to alter a stat if the <see cref="CollectingEffect"/> is set to alter a stat.
        /// </summary>
        [Index(9)]
        public int EffectAmount { get; private set; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="CollectibleModel"/> class.
        /// </summary>
        /// <param name="id">Unique identifier for the <see cref="CollectibleModel"/>.  Cannot be null.</param>
        /// <param name="name">Player-friendly name of the <see cref="CollectibleModel"/>.  Cannot be null.</param>
        /// <param name="description">Player-friendly description of the <see cref="CollectibleModel"/>.</param>
        /// <param name="comment">Comment of, on, or by the <see cref="CollectibleModel"/>.</param>
        /// <param name="tags">Any additional information about the <see cref="CollectibleModel"/>.</param>
        /// <param name="inItemID">The <see cref="ModelID"/> of the <see cref="Items.ItemModel"/> that this <see cref="CollectibleModel"/> corresponds to, if any.</param>
        /// <param name="inAddsToBiome">A set of flags indicating which, if any, <see cref="BiomeRecipe"/> this parquet helps to generate.</param>
        /// <param name="inAddsToRoom">A set of flags indicating which, if any, <see cref="Rooms.RoomRecipe"/> this parquet helps to generate.</param>
        /// <param name="inCollectionEffect">Effect of this <see cref="CollectibleModel"/>.</param>
        /// <param name="inEffectAmount">The scale in points of the effect. For example, how much to alter a stat if <paramref name="inCollectionEffect"/> is set to alter a stat.</param>
        public CollectibleModel(ModelID id, string name, string description, string comment,
                                IEnumerable<ModelTag> tags = null, ModelID? inItemID = null,
                                IEnumerable<ModelTag> inAddsToBiome = null, IEnumerable<ModelTag> inAddsToRoom = null,
                                CollectingEffect inCollectionEffect = CollectingEffect.None, int inEffectAmount = 0)
            : base(Bounds, id, name, description, comment, tags, inItemID, inAddsToBiome, inAddsToRoom)
        {
            CollectionEffect = inCollectionEffect;
            EffectAmount = inEffectAmount;
        }
        #endregion

        #region IMutableCollectibleModel Implementation
        /// <summary>The effect generated when a character encounters this Collectible.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="CollectibleModel"/> should never themselves use <see cref="IMutableCollectibleModel"/>.
        /// IMutableCollectibleModel is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        CollectingEffect IMutableCollectibleModel.CollectionEffect
        {
            get => CollectionEffect;
            set => CollectionEffect = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(CollectionEffect), CollectionEffect)
                : value;
        }

        /// <summary>
        /// The scale in points of the effect.
        /// For example, how much to alter a stat if the <see cref="CollectingEffect"/> is set to alter a stat.
        /// </summary>
        /// <remarks>
        /// By design, subtypes of <see cref="CollectibleModel"/> should never themselves use <see cref="IMutableCollectibleModel"/>.
        /// IMutableCollectibleModel is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        int IMutableCollectibleModel.EffectAmount
        {
            get => EffectAmount;
            set => EffectAmount = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(EffectAmount), EffectAmount)
                : value;
        }
        #endregion
    }
}
