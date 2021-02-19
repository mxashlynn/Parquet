using System.Diagnostics.CodeAnalysis;
using CsvHelper.Configuration.Attributes;
using Parquet.EditorSupport;

namespace Parquet.Items
{
    [SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
                     Justification = "By design, subtypes of Model should never themselves use IMutableModel or derived interfaces to access their own members.  The IMutableModel family of interfaces is for external types that require read/write access.")]
    public partial class ItemModel : IMutableItemModel
    {
        #region IItemModelEdit Implementation
        /// <summary>The type of item this is.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        ItemType IMutableItemModel.Subtype { get => Subtype; set => Subtype = value; }

        /// <summary>In-game value of the item.  Must be non-negative.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        int IMutableItemModel.Price { get => Price; set => Price = value; }

        /// <summary>How relatively rare this item is.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        int IMutableItemModel.Rarity { get => Rarity; set => Rarity = value; }

        /// <summary>How many of the item may share a single inventory slot.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        int IMutableItemModel.StackMax { get => StackMax; set => StackMax = value; }

        /// <summary>
        /// The <see cref="ModelID"/> of the <see cref="Scripts.ScriptModel"/> generating the in-game effect caused by
        /// keeping the item in a <see cref="Beings.CharacterModel"/>'s <see cref="Inventory"/>.
        /// </summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        ModelID IMutableItemModel.EffectWhileHeldID { get => EffectWhileHeldID; set => EffectWhileHeldID = value; }

        /// <summary>
        /// The <see cref="ModelID"/> of the <see cref="Scripts.ScriptModel"/> generating the in-game effect caused by
        /// using (consuming) the item.
        /// </summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        ModelID IMutableItemModel.EffectWhenUsedID { get => EffectWhenUsedID; set => EffectWhenUsedID = value; }

        /// <summary>The parquet that corresponds to this item, if any.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        ModelID IMutableItemModel.ParquetID { get => ParquetID; set => ParquetID = value; }
        #endregion
    }
}
