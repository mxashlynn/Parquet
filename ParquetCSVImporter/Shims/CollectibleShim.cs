using ParquetClassLibrary;

using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Utilities;

namespace ParquetCSVImporter.Shims
{
    /// <summary>
    /// Provides a default public parameterless constructor for a <see cref="Collectible"/>-like
    /// class that CSVHelper can instantiate.
    /// 
    /// Provides the ability to generate a <see cref="Collectible"/> from this class.
    /// </summary>
    public class CollectibleShim : ParquetParentShim
    {
        /// <summary>The effect generated when a character encounters this collectible.</summary>
        public CollectionEffect Effect;

        /// <summary>
        /// The scale in points of the effect.  That is, how much to alter a stat if the
        /// <see cref="CollectionEffect"/> is set to alter a stat.
        /// </summary>
        public int EffectAmount;

        /// <summary>
        /// Converts a shim into the class is corresponds to.
        /// </summary>
        /// <typeparam name="TargetType">The type to convert this shim to.</typeparam>
        /// <returns>An instance of a child class of <see cref="ParquetParent"/>.</returns>
        public override TargetType To<TargetType>()
        {
            Precondition.IsOfType<TargetType, Collectible>(typeof(TargetType).ToString());

            return (TargetType)(ParquetParent)new Collectible(ID, Name, Description, Comment, ItemID,
                                                              AddsToBiome, AddsToRoom, Effect, EffectAmount);
        }
    }
}
