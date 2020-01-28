using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Crafts;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Items
{
    /// <summary>
    /// Models an item that characters may carry, use, equip, trade, and/or build with.
    /// </summary>
    public sealed class ItemModel : EntityModel, ITypeConverter
    {
        #region Characteristics
        /// <summary>The type of item this is.</summary>
        public ItemType Subtype { get; }

        /// <summary>In-game value of the item.  Must be non-negative.</summary>
        public int Price { get; }

        /// <summary>How relatively rare this item is.</summary>
        public int Rarity { get; }

        /// <summary>How many of the item may share a single inventory slot.</summary>
        public int StackMax { get; }

        /// <summary>An in-game effect caused by keeping the item in a character's inventory.</summary>
        public int EffectWhileHeld { get; }

        /// <summary>An in-game effect caused by using (consuming) the item.</summary>
        public int EffectWhenUsed { get; }

        /// <summary>The parquet that corresponds to this item, if any.</summary>
        public EntityID AsParquet { get; }

        /// <summary>Any additional functionality this item has, e.g. contributing to a <see cref="Biomes.BiomeModel"/>.</summary>
        public IReadOnlyList<EntityTag> ItemTags { get; }

        /// <summary>How this item is crafted.</summary>
        public EntityID Recipe { get; }
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
        /// <param name="inAsParquet">The parquet represented, if any.</param>
        /// <param name="inItemTags">Any additional functionality this item has, e.g. contributing to a <see cref="Biomes.BiomeModel"/>.</param>
        /// <param name="inRecipeID">The <see cref="EntityID"/> that expresses how to craft this <see cref="ItemModel"/>.</param>
        public ItemModel(EntityID inID, string inName, string inDescription, string inComment,
                    ItemType inSubtype, int inPrice, int inRarity, int inStackMax,
                    int inEffectWhileHeld, int inEffectWhenUsed, EntityID inAsParquet,
                    IEnumerable<EntityTag> inItemTags = null, EntityID? inRecipeID = null)
            : base(All.ItemIDs, inID, inName, inDescription, inComment)
        {
            Precondition.IsInRange(inAsParquet, All.ParquetIDs, nameof(inAsParquet));
            Precondition.MustBePositive(inStackMax, nameof(inStackMax));

            var nonNullItemTags = inItemTags ?? Enumerable.Empty<EntityTag>().ToList();
            var nonNullCraftingRecipeID = inRecipeID ?? CraftingRecipe.NotCraftable.ID;

            Subtype = inSubtype;
            Price = inPrice;
            Rarity = inRarity;
            StackMax = inStackMax;
            EffectWhileHeld = inEffectWhileHeld;
            EffectWhenUsed = inEffectWhenUsed;
            AsParquet = inAsParquet;
            ItemTags = nonNullItemTags.ToList();
            Recipe = nonNullCraftingRecipeID;
        }
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static readonly ItemModel ConverterFactory =
            new ItemModel();

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="value">The instance to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
        }

        /// <summary>
        /// Converts the given <see cref="string"/> to an <see cref="object"/> as deserialization.
        /// </summary>
        /// <param name="text">The text to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
        }
        #endregion
    }
}
