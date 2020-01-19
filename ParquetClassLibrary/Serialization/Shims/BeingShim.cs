using System.Collections.Generic;
using ParquetClassLibrary.Beings;

namespace ParquetClassLibrary.Serialization.Shims
{
    /// <summary>
    /// Provides a default public parameterless constructor for a
    /// <see cref="BeingModel"/>-like class that CSVHelper can instantiate.
    /// 
    /// Provides the ability to generate a <see cref="BeingModel"/> from this class.
    /// </summary>
    public abstract class BeingShim : EntityShim
    {
        /// <summary>The <see cref="EntityID"/> of the <see cref="Biome"/> in which this character is at home.</summary>
        public EntityID NativeBiome;

        /// <summary>The <see cref="Behavior"/> governing the way this character acts.</summary>
        public Behavior PrimaryBehavior;

        /// <summary>Types of parquets this <see cref="BeingModel"/> avoids, if any.</summary>
        public EntityID Avoids;
        // TODO public List<EntityID> Avoids;

        /// <summary>Types of parquets this <see cref="BeingModel"/> seeks out, if any.</summary>
        public EntityID Seeks;
        // TODO public List<EntityID> Seeks;
    }
}
