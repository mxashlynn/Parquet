using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ParquetClassLibrary.Crafting;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Items
{
    /// <summary>
    /// Models an item that characters may carry, use, equip, trade, and/or build with.
    /// </summary>
    public class Item : Entity
    {
        /// <summary>The type of item this is.</summary>
        [JsonProperty(PropertyName = "in_subtype")]
        public ItemType Subtype { get; }

        /// <summary>In-game value of the item.  Must be non-negative.</summary>
        [JsonProperty(PropertyName = "in_price")]
        public int Price { get; }

        /// <summary>How relatively rare this item is.</summary>
        [JsonProperty(PropertyName = "in_rarity")]
        public int Rarity { get; }

        /// <summary>How many of the item may share a single inventory slot.</summary>
        [JsonProperty(PropertyName = "in_stackMax")]
        public int StackMax { get; }

        /// <summary>An in-game effect caused by keeping the item in a character's inventory.</summary>
        [JsonProperty(PropertyName = "in_effectWhileHeld")]
        public int EffectWhileHeld { get; }

        /// <summary>An in-game effect caused by using (consuming) the item.</summary>
        [JsonProperty(PropertyName = "in_effectWhenUsed")]
        public int EffectWhenUsed { get; }

        /// <summary>The parquet that corresponds to this item, if any.</summary>
        [JsonProperty(PropertyName = "in_asParquet")]
        public EntityID AsParquet { get; }

        /// <summary>Any additional functionality this item has, e.g. contributing to a <see cref="Biomes.Biome"/>.</summary>
        [JsonProperty(PropertyName = "in_itemTags")]
        public IReadOnlyList<EntityTag> ItemTags { get; }

        /// <summary>How this item is crafted.</summary>
        [JsonProperty(PropertyName = "in_recipe")]
        public EntityID Recipe { get; }

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class.
        /// </summary>
        /// <param name="in_id">Unique identifier for the <see cref="Item"/>.  Cannot be null.</param>
        /// <param name="in_subtype">The type of <see cref="Item"/>.</param>
        /// <param name="in_name">Player-friendly name of the <see cref="Item"/>.  Cannot be null or empty.</param>
        /// <param name="in_description">Player-friendly description of the <see cref="Item"/>.</param>
        /// <param name="in_comment">Comment of, on, or by the <see cref="Item"/>.</param>
        /// <param name="in_price"><see cref="Item"/> cost.</param>
        /// <param name="in_rarity"><see cref="Item"/> rarity.</param>
        /// <param name="in_stackMax">How many such items may be stacked together in the <see cref="Inventory"/>.  Must be positive.</param>
        /// <param name="in_effectWhileHeld"><see cref="Item"/>'s passive effect.</param>
        /// <param name="in_effectWhenUsed"><see cref="Item"/>'s active effect.</param>
        /// <param name="in_asParquet">The parquet represented, if any.</param>
        /// <param name="in_itemTags">Any additional functionality this item has, e.g. contributing to a <see cref="Biomes.Biome"/>.</param>
        /// <param name="in_recipeID">The <see cref="EntityID"/> that expresses how to craft this <see cref="Item"/>.</param>
        [JsonConstructor]
        public Item(EntityID in_id, ItemType in_subtype, string in_name, string in_description, string in_comment,
                    int in_price, int in_rarity, int in_stackMax, int in_effectWhileHeld,
                    int in_effectWhenUsed, EntityID in_asParquet,
                    List<EntityTag> in_itemTags = null, EntityID? in_recipeID = null)
            : base(All.ItemIDs, in_id, in_name, in_description, in_comment)
        {
            Precondition.IsInRange(in_asParquet, All.ParquetIDs, nameof(in_asParquet));
            Precondition.MustBePositive(in_stackMax, nameof(in_stackMax));

            var nonNullItemTags = in_itemTags ?? Enumerable.Empty<EntityTag>().ToList();
            var nonNullCraftingRecipeID = in_recipeID ?? CraftingRecipe.NotCraftable.ID;

            Subtype = in_subtype;
            Price = in_price;
            Rarity = in_rarity;
            StackMax = in_stackMax;
            EffectWhileHeld = in_effectWhileHeld;
            EffectWhenUsed = in_effectWhenUsed;
            AsParquet = in_asParquet;
            ItemTags = nonNullItemTags;
            Recipe = nonNullCraftingRecipeID;
        }
        #endregion
    }
}
