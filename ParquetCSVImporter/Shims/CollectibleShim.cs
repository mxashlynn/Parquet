using System;
using ParquetClassLibrary;
using ParquetClassLibrary.Sandbox.IDs;
using ParquetClassLibrary.Sandbox.Parquets;

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

        /// <summary>The item spawned when a character encounters this collectible.</summary>
        public EntityID ItemID;

        /// <summary>
        /// Converts a shim into the class is corresponds to.
        /// </summary>
        /// <typeparam name="T">The type to convert this shim to.</typeparam>
        /// <returns>An instance of a child class of <see cref="ParquetParent"/>.</returns>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the current shim does not correspond to the specified type.
        /// </exception>
        public override T To<T>()
        {
            T result;

            if (typeof(T) == typeof(Collectible))
            {
                result = (T)(ParquetParent)new Collectible(ID, Name, AddsToBiome, Effect, EffectAmount, ItemID);
            }
            else
            {
                throw new ArgumentException(nameof(T));
            }

            return result;
        }
    }
}
