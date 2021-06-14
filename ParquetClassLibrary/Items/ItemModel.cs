using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CsvHelper.Configuration.Attributes;

namespace Parquet.Items
{
    /// <summary>
    /// Models an item that characters may carry, use, equip, trade, and/or build with.
    /// </summary>
    [SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
                     Justification = "By design, subtypes of Model should never themselves use IMutableModel or derived interfaces to access their own members.  The IMutableModel family of interfaces is for external types that require read/write access.")]
    public class ItemModel : Model, IMutableItemModel
    {
        #region Class Defaults
        /// <summary>Stack maximum assumed when none is defined.</summary>
        public const int DefaultStackMax = 999;
        #endregion

        #region Characteristics
        /// <summary>The type of item this is.</summary>
        [Index(5)]
        public ItemType Subtype { get; private set; }

        /// <summary>In-game value of the item.  Must be non-negative.</summary>
        [Index(6)]
        public int Worth { get; private set; }

        /// <summary>How relatively rare this item is.</summary>
        [Index(7)]
        public int Rarity { get; private set; }

        /// <summary>How many of the item may share a single inventory slot.</summary>
        [Index(8)]
        public int StackMax { get; private set; }

        /// <summary>
        /// The <see cref="ModelID"/> of the <see cref="Scripts.ScriptModel"/> generating the in-game effect caused by
        /// keeping the item in a <see cref="Beings.CharacterModel"/>'s <see cref="InventoryCollection"/>.
        /// </summary>
        [Index(9)]
        public ModelID EffectWhileHeldID { get; private set; }

        /// <summary>
        /// The <see cref="ModelID"/> of the <see cref="Scripts.ScriptModel"/> generating the in-game effect caused by
        /// using (consuming) the item.
        /// </summary>
        [Index(10)]
        public ModelID EffectWhenUsedID { get; private set; }

        /// <summary>The parquet that corresponds to this item, if any.</summary>
        [Index(11)]
        public ModelID ParquetID { get; private set; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemModel"/> class.
        /// </summary>
        /// <param name="id">Unique identifier for the <see cref="ItemModel"/>.  Cannot be null.</param>
        /// <param name="name">Player-friendly name of the <see cref="ItemModel"/>.  Cannot be null or empty.</param>
        /// <param name="description">Player-friendly description of the <see cref="ItemModel"/>.</param>
        /// <param name="comment">Comment of, on, or by the <see cref="ItemModel"/>.</param>
        /// <param name="tags">Any additional functionality this <see cref="ItemModel"/> has, e.g. contributing to a <see cref="Biomes.BiomeRecipe"/>.</param>
        /// <param name="subtype">The type of <see cref="ItemModel"/>.</param>
        /// <param name="worth"><see cref="ItemModel"/> cost.</param>
        /// <param name="rarity"><see cref="ItemModel"/> rarity.</param>
        /// <param name="stackMax">How many such items may be stacked together in the <see cref="InventoryCollection"/>.  Must be positive.</param>
        /// <param name="effectWhileHeldID"><see cref="ItemModel"/>'s passive effect.</param>
        /// <param name="effectWhenUsedID"><see cref="ItemModel"/>'s active effect.</param>
        /// <param name="parquetID">The parquet represented by this <see cref="ItemModel"/>, if any.</param>
        public ItemModel(ModelID id, string name, string description, string comment,
                         IEnumerable<ModelTag> tags = null, ItemType subtype = ItemType.Other,
                         int worth = 0, int rarity = 0, int stackMax = DefaultStackMax,
                         ModelID? effectWhileHeldID = null, ModelID? effectWhenUsedID = null,
                         ModelID? parquetID = null)
            : base(All.ItemIDs, id, name, description, comment, tags)
        {
            var nonNullEffectWhileHeldID = effectWhileHeldID ?? ModelID.None;
            var nonNullEffectWhenUsedID = effectWhenUsedID ?? ModelID.None;
            var nonNullParquetID = parquetID ?? ModelID.None;

            Precondition.IsInRange(nonNullEffectWhileHeldID, All.ScriptIDs, nameof(effectWhileHeldID));
            Precondition.IsInRange(nonNullEffectWhenUsedID, All.ScriptIDs, nameof(effectWhenUsedID));
            Precondition.IsInRange(nonNullParquetID, All.ParquetIDs, nameof(parquetID));
            Precondition.MustBePositive(stackMax, nameof(stackMax));

            Subtype = subtype;
            Worth = worth;
            Rarity = rarity;
            StackMax = stackMax;
            EffectWhileHeldID = nonNullEffectWhileHeldID;
            EffectWhenUsedID = nonNullEffectWhenUsedID;
            ParquetID = nonNullParquetID;
        }
        #endregion

        #region IMutableItemModel Implementation
        /// <summary>The type of item this is.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="ItemModel"/> should never themselves use <see cref="IMutableItemModel"/>.
        /// IMutableItemModel is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        ItemType IMutableItemModel.Subtype
        {
            get => Subtype;
            set => Subtype = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(Subtype), Subtype)
                : value;
        }

        /// <summary>In-game value of the item.  Must be non-negative.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="ItemModel"/> should never themselves use <see cref="IMutableItemModel"/>.
        /// IMutableItemModel is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        int IMutableItemModel.Worth
        {
            get => Worth;
            set => Worth = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(Worth), Worth)
                : value;
        }

        /// <summary>How relatively rare this item is.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="ItemModel"/> should never themselves use <see cref="IMutableItemModel"/>.
        /// IMutableItemModel is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        int IMutableItemModel.Rarity
        {
            get => Rarity;
            set => Rarity = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(Rarity), Rarity)
                : value;
        }

        /// <summary>How many of the item may share a single inventory slot.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="ItemModel"/> should never themselves use <see cref="IMutableItemModel"/>.
        /// IMutableItemModel is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        int IMutableItemModel.StackMax
        {
            get => StackMax;
            set => StackMax = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(StackMax), StackMax)
                : value;
        }

        /// <summary>
        /// The <see cref="ModelID"/> of the <see cref="Scripts.ScriptModel"/> generating the in-game effect caused by
        /// keeping the item in a <see cref="Beings.CharacterModel"/>'s <see cref="InventoryCollection"/>.
        /// </summary>
        /// <remarks>
        /// By design, subtypes of <see cref="ItemModel"/> should never themselves use <see cref="IMutableItemModel"/>.
        /// IMutableItemModel is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        ModelID IMutableItemModel.EffectWhileHeldID
        {
            get => EffectWhileHeldID;
            set => EffectWhileHeldID = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(EffectWhileHeldID), EffectWhileHeldID)
                : value;
        }

        /// <summary>
        /// The <see cref="ModelID"/> of the <see cref="Scripts.ScriptModel"/> generating the in-game effect caused by
        /// using (consuming) the item.
        /// </summary>
        /// <remarks>
        /// By design, subtypes of <see cref="ItemModel"/> should never themselves use <see cref="IMutableItemModel"/>.
        /// IMutableItemModel is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        ModelID IMutableItemModel.EffectWhenUsedID
        {
            get => EffectWhenUsedID;
            set => EffectWhenUsedID = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(EffectWhenUsedID), EffectWhenUsedID)
                : value;
        }

        /// <summary>The parquet that corresponds to this item, if any.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="ItemModel"/> should never themselves use <see cref="IMutableItemModel"/>.
        /// IMutableItemModel is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        ModelID IMutableItemModel.ParquetID
        {
            get => ParquetID;
            set => ParquetID = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(ParquetID), ParquetID)
                : value;
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a collection of all <see cref="ModelTag"/>s the <see cref="Model"/> has applied to it. Classes inheriting from <see cref="Model"/> that include <see cref="ModelTag"/> should override accordingly.
        /// </summary>
        /// <returns>List of all <see cref="ModelTag"/>s.</returns>
        public override IEnumerable<ModelTag> GetAllTags()
            => base.GetAllTags().Union(Tags);
        #endregion
    }
}
