using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Serialization.Shims
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
        public CollectEffect Effect;

        /// <summary>The scale in points of the effect.</summary>
        public int EffectAmount;

        /// <summary>
        /// Converts a shim into the class it corresponds to.
        /// </summary>
        /// <typeparam name="T">The type to convert this shim to.</typeparam>
        /// <returns>An instance of a child class of <see cref="ParquetParent"/>.</returns>
        public override T ToEntity<T>()
        {
            Precondition.IsOfType<T, Collectible>(typeof(T).ToString());

            return (T)(EntityModel)new Collectible(ID, Name, Description, Comment, ItemID,
                                                   AddsToBiome, AddsToRoom, Effect, EffectAmount);
        }
    }
}
