using System.Collections.Generic;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Serialization.Shims
{
    /// <summary>
    /// Provides a default public parameterless constructor for a
    /// <see cref="Biome"/>-like class that CSVHelper can instantiate.
    /// 
    /// Provides the ability to generate a <see cref="Biome"/> from this class.
    /// </summary>
    public class BiomeShim : EntityShim
    {
        /// <summary>
        /// A rating indicating where in the progression this <see cref="Biome"/> falls.
        /// Must be non-negative.  Higher values indicate later Biomes.
        /// </summary>
        public int Tier;

        /// <summary>Describes where this <see cref="Biome"/> falls in terms of the game world's overall topography.</summary>
        public Elevation ElevationCategory;

        /// <summary>Determines whether or not this <see cref="Biome"/> is defined in terms of liquid parquets.</summary>
        public bool IsLiquidBased;

        /// <summary>Describes the parquets that make up this <see cref="Biome"/>.</summary>
        public List<EntityTag> ParquetCriteria;

        /// <summary>Describes the <see cref="Item"/>s a <see cref="Beings.PlayerCharacter"/> needs to safely access this <see cref="Biome"/>.
        /// </summary>
        public List<EntityTag> EntryRequirements;

        /// <summary>
        /// Converts a shim into the class it corresponds to.
        /// </summary>
        /// <typeparam name="T">The type to convert this shim to.</typeparam>
        /// <returns>An instance of a child class of <see cref="Enity"/>.</returns>
        public override T ToEntity<T>()
        {
            Precondition.IsOfType<T, Biome>(typeof(T).ToString());

            return (T)(EntityModel)new Biome(ID, Name, Description, Comment, Tier, ElevationCategory,
                                             IsLiquidBased, ParquetCriteria, EntryRequirements);
        }
    }
}
