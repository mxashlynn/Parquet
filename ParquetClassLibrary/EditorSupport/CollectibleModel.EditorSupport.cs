#if DESIGN
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.EditorSupport;

namespace ParquetClassLibrary.Parquets
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
        Justification = "By design, subtypes of Model should never themselves use IModelEdit or derived interfaces to access their own members.  The IModelEdit family of interfaces is for external types that require read/write access.")]
    public partial class CollectibleModel : ICollectibleModelEdit
    {
        #region ICollectibleModelEdit Implementation
        /// <summary>The effect generated when a character encounters this Collectible.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        CollectingEffect ICollectibleModelEdit.CollectionEffect { get => CollectionEffect; set => CollectionEffect = value; }

        /// <summary>
        /// The scale in points of the effect.
        /// For example, how much to alter a stat if the <see cref="CollectingEffect"/> is set to alter a stat.
        /// </summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        int ICollectibleModelEdit.EffectAmount { get => EffectAmount; set => EffectAmount = value; }
        #endregion
    }
}
#endif
