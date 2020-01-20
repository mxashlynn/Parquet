using System.Collections.Generic;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Serialization.Shims
{
    /// <summary>
    /// Provides a default public parameterless constructor for a
    /// <see cref="BiomeModel"/>-like class that CSVHelper can instantiate.
    /// 
    /// Provides the ability to generate a <see cref="BiomeModel"/> from this class.
    /// </summary>
    public class BiomeShim : EntityShim
    {
        /// <summary>
        /// A rating indicating where in the progression this <see cref="BiomeModel"/> falls.
        /// Must be non-negative.  Higher values indicate later Biomes.
        /// </summary>
        public int Tier;

        /// <summary>Describes where this <see cref="BiomeModel"/> falls in terms of the game world's overall topography.</summary>
        public Elevation ElevationCategory;

        /// <summary>Determines whether or not this <see cref="BiomeModel"/> is defined in terms of liquid parquets.</summary>
        public bool IsLiquidBased;

        /// <summary>Describes the parquets that make up this <see cref="BiomeModel"/>.</summary>
        public EntityTag ParquetCriteria;
        // TODO public IReadOnlyList<EntityTag> ParquetCriteria;

        /// <summary>Describes the <see cref="Item"/>s a <see cref="Beings.PlayerCharacterModel"/> needs to safely access this <see cref="BiomeModel"/>.
        /// </summary>
        public EntityTag EntryRequirements;
        // TODO public IReadOnlyList<EntityTag> EntryRequirements;

        /// <summary>
        /// Converts a shim into the class it corresponds to.
        /// </summary>
        /// <typeparam name="T">The type to convert this shim to.</typeparam>
        /// <returns>An instance of a child class of <see cref="EnityModel"/>.</returns>
        public override T ToEntity<T>()
        {
            Precondition.IsOfType<T, BiomeModel>(typeof(T).ToString());

            return (T)(EntityModel)new BiomeModel(ID, Name, Description, Comment, Tier, ElevationCategory,
                                                  IsLiquidBased, new List<EntityTag>() { ParquetCriteria },
                                                  new List<EntityTag>() { EntryRequirements });
        }
    }
}
