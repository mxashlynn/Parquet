using System.Collections.Generic;

namespace ParquetClassLibrary.Biomes
{
    /// <summary>
    /// Facilitates editing of a <see cref="BiomeModel"/> from design tools while maintaining a read-only face for use during play.
    /// </summary>
    public interface IBiomeModelEdit : IModelEdit
    {
        /// <summary>
        /// A rating indicating where in the progression this <see cref="BiomeModel"/> falls.
        /// Must be non-negative.  Higher values indicate later Biomes.
        /// </summary>
        public int Tier { get; set; }

        /// <summary>Determines whether or not this <see cref="BiomeModel"/> is defined in terms of <see cref="Rooms.Room"/>s.</summary>
        public bool IsRoomBased { get; set; }

        /// <summary>Determines whether or not this <see cref="BiomeModel"/> is defined in terms of liquid parquets.</summary>
        public bool IsLiquidBased { get; set; }

        /// <summary>Describes the parquets that make up this <see cref="BiomeModel"/>.</summary>
        public IList<ModelTag> ParquetCriteria { get; }

        /// <summary>Describes the <see cref="Items.ItemModel"/>s a <see cref="Beings.CharacterModel"/> needs to safely access this <see cref="BiomeModel"/>.</summary>
        public IList<ModelTag> EntryRequirements { get; }
    }
}
