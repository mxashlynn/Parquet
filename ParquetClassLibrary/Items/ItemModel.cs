using System.Collections.Generic;
using System.Linq;
using CsvHelper.Configuration.Attributes;

namespace ParquetClassLibrary.Items
{
    /// <summary>
    /// Models an item that characters may carry, use, equip, trade, and/or build with.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1033:Interface methods should be callable by child types",
        Justification = "By design, children of Model should never themselves use IModelEdit or its decendent interfaces to access their own members.  The IModelEdit family of interfaces is for external types that require read/write access.")]
    public sealed class ItemModel : Model, IItemModelEdit
    {
        #region Class Defaults
        /// <summary>Stack maximum assumed when none is defined.</summary>
        public const int DefaultStackMax = 999;
        #endregion

        #region Characteristics
        /// <summary>The type of item this is.</summary>
        [Index(4)]
        public ItemType Subtype { get; private set; }

        /// <summary>The type of item this is.</summary>
        /// <remarks>
        /// By design, children of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require readwrite access.
        /// </remarks>
        [Ignore]
        ItemType IItemModelEdit.Subtype { get => Subtype; set => Subtype = value; }

        /// <summary>In-game value of the item.  Must be non-negative.</summary>
        [Index(5)]
        public int Price { get; private set; }

        /// <summary>In-game value of the item.  Must be non-negative.</summary>
        /// <remarks>
        /// By design, children of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require readwrite access.
        /// </remarks>
        [Ignore]
        int IItemModelEdit.Price { get => Price; set => Price = value; }

        /// <summary>How relatively rare this item is.</summary>
        [Index(6)]
        public int Rarity { get; private set; }

        /// <summary>How relatively rare this item is.</summary>
        /// <remarks>
        /// By design, children of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require readwrite access.
        /// </remarks>
        [Ignore]
        int IItemModelEdit.Rarity { get => Rarity; set => Rarity = value; }

        /// <summary>How many of the item may share a single inventory slot.</summary>
        [Index(7)]
        public int StackMax { get; private set; }

        /// <summary>How many of the item may share a single inventory slot.</summary>
        /// <remarks>
        /// By design, children of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require readwrite access.
        /// </remarks>
        [Ignore]
        int IItemModelEdit.StackMax { get => StackMax; set => StackMax = value; }

        /// <summary>
        /// The <see cref="ModelID"/> of the <see cref="Scripts.ScriptModel"/> generating the in-game effect caused by
        /// keeping the item in a <see cref="Beings.CharacterModel"/>'s <see cref="Inventory"/>.
        /// </summary>
        [Index(8)]
        public ModelID EffectWhileHeldID { get; private set; }

        /// <summary>
        /// The <see cref="ModelID"/> of the <see cref="Scripts.ScriptModel"/> generating the in-game effect caused by
        /// keeping the item in a <see cref="Beings.CharacterModel"/>'s <see cref="Inventory"/>.
        /// </summary>
        /// <remarks>
        /// By design, children of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require readwrite access.
        /// </remarks>
        [Ignore]
        ModelID IItemModelEdit.EffectWhileHeldID { get => EffectWhileHeldID; set => EffectWhileHeldID = value; }

        /// <summary>
        /// The <see cref="ModelID"/> of the <see cref="Scripts.ScriptModel"/> generating the in-game effect caused by
        /// using (consuming) the item.
        /// </summary>
        [Index(9)]
        public ModelID EffectWhenUsedID { get; private set; }

        /// <summary>
        /// The <see cref="ModelID"/> of the <see cref="Scripts.ScriptModel"/> generating the in-game effect caused by
        /// using (consuming) the item.
        /// </summary>
        /// <remarks>
        /// By design, children of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require readwrite access.
        /// </remarks>
        [Ignore]
        ModelID IItemModelEdit.EffectWhenUsedID { get => EffectWhenUsedID; set => EffectWhenUsedID = value; }

        /// <summary>The parquet that corresponds to this item, if any.</summary>
        [Index(10)]
        public ModelID ParquetID { get; private set; }

        /// <summary>The parquet that corresponds to this item, if any.</summary>
        /// <remarks>
        /// By design, children of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require readwrite access.
        /// </remarks>
        [Ignore]
        ModelID IItemModelEdit.ParquetID { get => ParquetID; set => ParquetID = value; }

        /// <summary>Any additional functionality this item has, e.g. contributing to a <see cref="Biomes.BiomeRecipe"/>.</summary>
        [Index(11)]
        public IReadOnlyList<ModelTag> ItemTags { get; }

        /// <summary>Any additional functionality this item has, e.g. contributing to a <see cref="Biomes.BiomeRecipe"/>.</summary>
        /// <remarks>
        /// By design, children of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require readwrite access.
        /// </remarks>
        [Ignore]
        IList<ModelTag> IItemModelEdit.ItemTags => (IList<ModelTag>)ItemTags;
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="ItemModel"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="ItemModel"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="ItemModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="ItemModel"/>.</param>
        /// <param name="inSubtype">The type of <see cref="ItemModel"/>.</param>
        /// <param name="inPrice"><see cref="ItemModel"/> cost.</param>
        /// <param name="inRarity"><see cref="ItemModel"/> rarity.</param>
        /// <param name="inStackMax">How many such items may be stacked together in the <see cref="Inventory"/>.  Must be positive.</param>
        /// <param name="inEffectWhileHeldID"><see cref="ItemModel"/>'s passive effect.</param>
        /// <param name="inEffectWhenUsedID"><see cref="ItemModel"/>'s active effect.</param>
        /// <param name="inParquetID">The parquet represented, if any.</param>
        /// <param name="inItemTags">Any additional functionality this item has, e.g. contributing to a <see cref="Biomes.BiomeRecipe"/>.</param>
        public ItemModel(ModelID inID, string inName, string inDescription, string inComment,
                         ItemType inSubtype = ItemType.Other, int inPrice = 0, int inRarity = 0,
                         int inStackMax = DefaultStackMax, ModelID? inEffectWhileHeldID = null,
                         ModelID? inEffectWhenUsedID = null, ModelID? inParquetID = null,
                         IEnumerable<ModelTag> inItemTags = null)
            : base(All.ItemIDs, inID, inName, inDescription, inComment)
        {
            var nonNullEffectWhileHeldID = inEffectWhileHeldID ?? ModelID.None;
            var nonNullEffectWhenUsedID = inEffectWhenUsedID ?? ModelID.None;
            var nonNullParquetID = inParquetID ?? ModelID.None;
            var nonNullItemTags = (inItemTags ?? Enumerable.Empty<ModelTag>()).ToList();

            Precondition.IsInRange(nonNullEffectWhileHeldID, All.ScriptIDs, nameof(inEffectWhileHeldID));
            Precondition.IsInRange(nonNullEffectWhenUsedID, All.ScriptIDs, nameof(inEffectWhenUsedID));
            Precondition.IsInRange(nonNullParquetID, All.ParquetIDs, nameof(inParquetID));
            Precondition.MustBePositive(inStackMax, nameof(inStackMax));

            Subtype = inSubtype;
            Price = inPrice;
            Rarity = inRarity;
            StackMax = inStackMax;
            EffectWhileHeldID = nonNullEffectWhileHeldID;
            EffectWhenUsedID = nonNullEffectWhenUsedID;
            ParquetID = nonNullParquetID;
            ItemTags = nonNullItemTags;
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a collection of all <see cref="ModelTag"/>s the <see cref="Model"/> has applied to it. Classes inheriting from <see cref="Model"/> that include <see cref="ModelTag"/> should override accordingly.
        /// </summary>
        /// <returns>List of all <see cref="ModelTag"/>s.</returns>
        public override IEnumerable<ModelTag> GetAllTags()
            => base.GetAllTags().Union(ItemTags);
        #endregion
    }
}
