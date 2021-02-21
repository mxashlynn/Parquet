using System.Collections.Generic;

namespace Parquet.Biomes
{
    /// <summary>
    /// Facilitates editing of a <see cref="BiomeRecipe"/> from design tools while maintaining a read-only face for use during play.
    /// </summary>
    public interface IMutableBiomeRecipe : IMutableModel
    {
        /// <summary>
        /// A rating indicating where in the progression this <see cref="BiomeRecipe"/> falls.
        /// Must be non-negative.  Higher values indicate later Biomes.
        /// </summary>
        public int Tier { get; set; }

        /// <summary>Determines whether or not this <see cref="BiomeRecipe"/> is defined in terms of <see cref="Rooms.Room"/>s.</summary>
        public bool IsRoomBased { get; set; }

        /// <summary>Determines whether or not this <see cref="BiomeRecipe"/> is defined in terms of liquid parquets.</summary>
        public bool IsLiquidBased { get; set; }

        /// <summary>Describes the parquets that make up this <see cref="BiomeRecipe"/>.</summary>
        public ModelTag ParquetCriteria { get; set;  }

        /// <summary>Describes the <see cref="Items.ItemModel"/>s a <see cref="Beings.CharacterModel"/> needs to safely access this biome.</summary>
        public ICollection<ModelTag> EntryRequirements { get; }
    }
}
