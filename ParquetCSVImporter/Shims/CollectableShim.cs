using ParquetClassLibrary.Sandbox.ID;
using ParquetClassLibrary.Sandbox.Parquets;

namespace ParquetCSVImporter.ClassMaps
{
    /// <summary>
    /// Provides a default public parameterless constructor for a
    /// <see cref="T:ParquetClassLibrary.Sandbox.Parquets.Collectable"/>-like
    /// class that CSVHelper can instantiate.
    /// 
    /// Provides the ability to generate a <see cref="T:ParquetClassLibrary.Sandbox.Parquets.Collectable"/>
    /// from this class.
    /// </summary>
    public class CollectableShim : ParquetParentShim
    {
        /// <summary>The effect generated when a character encounters this Collectable.</summary>
        public CollectionEffect Effect;

        /// <summary>
        /// The scale in points of the effect.  That is, how much to alter a stat if the
        /// <see cref="T:ParquetClassLibrary.Sandbox.ID.CollectionEffect"/> is set to alter a stat.
        /// </summary>
        public int EffectAmount;

        /// <summary>The item spawned when a character encounters this Collectable.</summary>
        public EntityID ItemID;

        /// <summary>
        /// Converts a shim into the class is corresponds to.
        /// </summary>
        /// <typeparam name="T">The type to convert this shim to.</typeparam>
        /// <returns>An instance of a child class of <see cref="T:ParquetClassLibrary.Sandbox.Parquets.ParquetParent"/>.</returns>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the current shim does not correspond to the specified type.
        /// </exception>
        public override T To<T>()
        {
            T result;

            if (typeof(T) == typeof(Collectable))
            {
                result = (T)(ParquetParent)new Collectable(ID, Name, AddsToBiome, Effect, EffectAmount, ItemID);
            }
            else
            {
                throw new System.ArgumentException(nameof(T));
            }

            return result;
        }
    }
}
