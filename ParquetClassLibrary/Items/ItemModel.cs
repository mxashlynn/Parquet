using System.Collections.Generic;
using System.Linq;
using CsvHelper.Configuration.Attributes;

namespace ParquetClassLibrary.Items
{
    /// <summary>
    /// Models an item that characters may carry, use, equip, trade, and/or build with.
    /// </summary>
    public sealed class ItemModel : Model
    {
        #region Characteristics
        /// <summary>The type of item this is.</summary>
        [Index(4)]
        public ItemType Subtype { get; }

        /// <summary>In-game value of the item.  Must be non-negative.</summary>
        [Index(5)]
        public int Price { get; }

        /// <summary>How relatively rare this item is.</summary>
        [Index(6)]
        public int Rarity { get; }

        /// <summary>How many of the item may share a single inventory slot.</summary>
        [Index(7)]
        public int StackMax { get; }

        /// <summary>
        /// The <see cref="ModelID"/> of the <see cref="Scripts.ScriptModel"/> generating the in-game effect caused by
        /// keeping the item in a <see cref="Beings.CharacterModel"/>'s <see cref="Inventory"/>.
        /// </summary>
        [Index(8)]
        public ModelID EffectWhileHeld { get; }

        /// <summary>
        /// The <see cref="ModelID"/> of the <see cref="Scripts.ScriptModel"/> generating the in-game effect caused by
        /// using (consuming) the item.
        /// </summary>
        [Index(9)]
        public ModelID EffectWhenUsed { get; }

        /// <summary>The parquet that corresponds to this item, if any.</summary>
        [Index(10)]
        public ModelID ParquetID { get; }

        /// <summary>Any additional functionality this item has, e.g. contributing to a <see cref="Biomes.BiomeModel"/>.</summary>
        [Index(11)]
        public IReadOnlyList<ModelTag> ItemTags { get; }
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
        /// <param name="inEffectWhileHeld"><see cref="ItemModel"/>'s passive effect.</param>
        /// <param name="inEffectWhenUsed"><see cref="ItemModel"/>'s active effect.</param>
        /// <param name="inParquetID">The parquet represented, if any.</param>
        /// <param name="inItemTags">Any additional functionality this item has, e.g. contributing to a <see cref="Biomes.BiomeModel"/>.</param>
        public ItemModel(ModelID inID, string inName, string inDescription, string inComment,
                         ItemType inSubtype, int inPrice, int inRarity, int inStackMax,
                         ModelID inEffectWhileHeld, ModelID inEffectWhenUsed, ModelID inParquetID,
                         IEnumerable<ModelTag> inItemTags = null)
            : base(All.ItemIDs, inID, inName, inDescription, inComment)
        {
            Precondition.IsInRange(inParquetID, All.ParquetIDs, nameof(inParquetID));
            Precondition.MustBePositive(inStackMax, nameof(inStackMax));

            var nonNullItemTags = inItemTags ?? Enumerable.Empty<ModelTag>().ToList();

            Subtype = inSubtype;
            Price = inPrice;
            Rarity = inRarity;
            StackMax = inStackMax;
            EffectWhileHeld = inEffectWhileHeld;
            EffectWhenUsed = inEffectWhenUsed;
            ParquetID = inParquetID;
            ItemTags = nonNullItemTags.ToList();
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
