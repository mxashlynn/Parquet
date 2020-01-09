using System.Collections.Generic;
using System.Linq;
using ParquetClassLibrary.Crafting;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Items
{
    /// <summary>
    /// Models an item that characters may carry, use, equip, trade, and/or build with.
    /// </summary>
    public sealed class Item : EntityModel
    {
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

        /// <summary>Any additional functionality this item has, e.g. contributing to a <see cref="Biomes.Biome"/>.</summary>
        public IReadOnlyList<EntityTag> ItemTags { get; }

        /// <summary>How this item is crafted.</summary>
        public EntityID Recipe { get; }

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="Item"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="Item"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="Item"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="Item"/>.</param>
        /// <param name="inSubtype">The type of <see cref="Item"/>.</param>
        /// <param name="inPrice"><see cref="Item"/> cost.</param>
        /// <param name="inRarity"><see cref="Item"/> rarity.</param>
        /// <param name="inStackMax">How many such items may be stacked together in the <see cref="Inventory"/>.  Must be positive.</param>
        /// <param name="inEffectWhileHeld"><see cref="Item"/>'s passive effect.</param>
        /// <param name="inEffectWhenUsed"><see cref="Item"/>'s active effect.</param>
        /// <param name="inAsParquet">The parquet represented, if any.</param>
        /// <param name="inItemTags">Any additional functionality this item has, e.g. contributing to a <see cref="Biomes.Biome"/>.</param>
        /// <param name="inRecipeID">The <see cref="EntityID"/> that expresses how to craft this <see cref="Item"/>.</param>
        public Item(EntityID inID, string inName, string inDescription, string inComment,
                    ItemType inSubtype, int inPrice, int inRarity, int inStackMax,
                    int inEffectWhileHeld, int inEffectWhenUsed, EntityID inAsParquet,
                    List<EntityTag> inItemTags = null, EntityID? inRecipeID = null)
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
            ItemTags = nonNullItemTags;
            Recipe = nonNullCraftingRecipeID;
        }
        #endregion
    }
}
