using System.Collections.Generic;

namespace ParquetClassLibrary.Items
{
    /// <summary>
    /// Facilitates editing of a <see cref="ItemModel"/> from design tools while maintaining a read-only face for use during play.
    /// </summary>
    /// <remarks>
    /// By design, children of <see cref="ItemModel"/> should never themselves use <see cref="IItemModelEdit"/>.
    /// IItemModelEdit is for use only by external types that require read/write access to model properties.
    /// </remarks>
    public interface IItemModelEdit : IModelEdit
    {
        /// <summary>The type of item this is.</summary>
        public ItemType Subtype { get; set; }

        /// <summary>In-game value of the item.  Must be non-negative.</summary>
        public int Price { get; set; }

        /// <summary>How relatively rare this item is.</summary>
        public int Rarity { get; set; }

        /// <summary>How many of the item may share a single inventory slot.</summary>
        public int StackMax { get; set; }

        /// <summary>
        /// The <see cref="ModelID"/> of the <see cref="Scripts.ScriptModel"/> generating the in-game effect caused by
        /// keeping the item in a <see cref="Beings.CharacterModel"/>'s <see cref="Inventory"/>.
        /// </summary>
        public ModelID EffectWhileHeld { get; set; }

        /// <summary>
        /// The <see cref="ModelID"/> of the <see cref="Scripts.ScriptModel"/> generating the in-game effect caused by
        /// using (consuming) the item.
        /// </summary>
        public ModelID EffectWhenUsed { get; set; }

        /// <summary>The parquet that corresponds to this item, if any.</summary>
        public ModelID ParquetID { get; set; }

        /// <summary>Any additional functionality this item has, e.g. contributing to a <see cref="Biomes.BiomeModel"/>.</summary>
        public IList<ModelTag> ItemTags { get; }
    }
}
