#if DESIGN
using System.Collections.Generic;
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.EditorSupport;

namespace ParquetClassLibrary.Items
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
        Justification = "By design, subtypes of Model should never themselves use IModelEdit or derived interfaces to access their own members.  The IModelEdit family of interfaces is for external types that require read/write access.")]
    public partial class ItemModel : IItemModelEdit
    {
        #region IItemModelEdit Implementation
        /// <summary>The type of item this is.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require readwrite access.
        /// </remarks>
        [Ignore]
        ItemType IItemModelEdit.Subtype { get => Subtype; set => Subtype = value; }

        /// <summary>In-game value of the item.  Must be non-negative.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require readwrite access.
        /// </remarks>
        [Ignore]
        int IItemModelEdit.Price { get => Price; set => Price = value; }

        /// <summary>How relatively rare this item is.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require readwrite access.
        /// </remarks>
        [Ignore]
        int IItemModelEdit.Rarity { get => Rarity; set => Rarity = value; }

        /// <summary>How many of the item may share a single inventory slot.</summary>
        [Index(7)]
        public int StackMax { get; private set; }

        /// <summary>How many of the item may share a single inventory slot.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require readwrite access.
        /// </remarks>
        [Ignore]
        int IItemModelEdit.StackMax { get => StackMax; set => StackMax = value; }

        /// <summary>
        /// The <see cref="ModelID"/> of the <see cref="Scripts.ScriptModel"/> generating the in-game effect caused by
        /// keeping the item in a <see cref="Beings.CharacterModel"/>'s <see cref="Inventory"/>.
        /// </summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require readwrite access.
        /// </remarks>
        [Ignore]
        ModelID IItemModelEdit.EffectWhileHeldID { get => EffectWhileHeldID; set => EffectWhileHeldID = value; }

        /// <summary>
        /// The <see cref="ModelID"/> of the <see cref="Scripts.ScriptModel"/> generating the in-game effect caused by
        /// using (consuming) the item.
        /// </summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require readwrite access.
        /// </remarks>
        [Ignore]
        ModelID IItemModelEdit.EffectWhenUsedID { get => EffectWhenUsedID; set => EffectWhenUsedID = value; }

        /// <summary>The parquet that corresponds to this item, if any.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require readwrite access.
        /// </remarks>
        [Ignore]
        ModelID IItemModelEdit.ParquetID { get => ParquetID; set => ParquetID = value; }

        /// <summary>Any additional functionality this item has, e.g. contributing to a <see cref="Crafts.CraftingRecipe"/>.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require readwrite access.
        /// </remarks>
        [Ignore]
        IList<ModelTag> IItemModelEdit.ItemTags => (IList<ModelTag>)ItemTags;
        #endregion
    }
}
#endif
