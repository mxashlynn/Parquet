using System.Diagnostics.CodeAnalysis;
using CsvHelper.Configuration.Attributes;
using Parquet.EditorSupport;

namespace Parquet.Parquets
{
    [SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
                     Justification = "By design, subtypes of Model should never themselves use IMutableModel or derived interfaces to access their own members.  The IMutableModel family of interfaces is for external types that require read/write access.")]
    public partial class CollectibleModel : IMutableCollectibleModel
    {
        #region ICollectibleModelEdit Implementation
        /// <summary>The effect generated when a character encounters this Collectible.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read/write access.
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
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read/write access.
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
