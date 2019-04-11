using System;
using Newtonsoft.Json;
using ParquetClassLibrary.Crafting;

namespace ParquetClassLibrary.Items
{
    /// <summary>
    /// Models an item that characters may carry, use, equip, trade, and/or build with.
    /// </summary>
    public class Item : IEquatable<Item>
    {
        /// <summary>Unique identifier of the item.</summary>
        [JsonProperty(PropertyName = "in_ID")]
        public EntityID ID { get; }

        /// <summary>The type of item this is.</summary>
        [JsonProperty(PropertyName = "in_subtype")]
        public ItemType Subtype { get; }

        /// <summary>Player-facing name of the item.</summary>
        [JsonProperty(PropertyName = "in_name")]
        public string Name { get; }

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
        // TODO This is not actually an int; this type needs to be implemented.
        public int EffectWhileHeld { get; }

        /// <summary>An in-game effect caused by using (consuming) the item.</summary>
        [JsonProperty(PropertyName = "in_effectWhenUsed")]
        // TODO This is not actually an int; this type needs to be implemented.
        public int EffectWhenUsed { get; }

        /// <summary>The parquet that corresponds to this item, if any.</summary>
        [JsonProperty(PropertyName = "in_asParquet")]
        public EntityID AsParquet { get; }

        /// <summary>The key item this item acts as, if any.</summary>
        [JsonProperty(PropertyName = "in_asKeyItem")]
        public KeyItem AsKeyItem { get; }

        /// <summary>How this item is produced.</summary>
        [JsonProperty(PropertyName = "in_recipe")]
        public CraftingRecipe Recipe { get; }

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ParquetClassLibrary.Items.Item"/> class.
        /// </summary>
        /// <param name="in_id">Unique identifier for the parquet.  Cannot be null.</param>
        /// <param name="in_subtype">The type of item.</param>
        /// <param name="in_name">Player-friendly name of the item.  Cannot be null or empty.</param>
        /// <param name="in_price">Item cost.</param>
        /// <param name="in_rarity">Item rarity.</param>
        // TODO Implement the Inventory class.
        /// <param name="in_stackMax">How many such items may be stacked together in the <see cref="Inventory"/>.  Must be positive.</param>
        /// <param name="in_effectWhileHeld">Item's passive effect.</param>
        /// <param name="in_effectWhenUsed">Item's active effect.</param>
        /// <param name="in_asParquet">The parquet represented, if any.</param>
        /// <param name="in_asKeyItem">The key item action, if any.</param>
        /// <param name="in_recipe">How to craft this item.</param>
        [JsonConstructor]
        public Item(EntityID in_id, ItemType in_subtype, string in_name, int in_price, int in_rarity, int in_stackMax,
                    int in_effectWhileHeld, int in_effectWhenUsed, EntityID in_asParquet, KeyItem in_asKeyItem,
                    CraftingRecipe in_recipe)
        {
            if (!in_id.IsValidForRange(AssemblyInfo.ItemIDs))
            {
                throw new ArgumentOutOfRangeException(nameof(in_id));
            }
            if (string.IsNullOrEmpty(in_name))
            {
                throw new ArgumentNullException(nameof(in_name));
            }
            if (in_stackMax < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(in_stackMax));
            }
            // TODO Do we need to bounds-check in_effectWhileHeld?
            // TODO Do we need to bounds-check in_effectWhenUsed?
            if (!in_asParquet.IsValidForRange(AssemblyInfo.ParquetIDs))
            {
                throw new ArgumentOutOfRangeException(nameof(in_id));
            }

            // TODO: What smarts does Item need?

            ID = in_id;
            Subtype = in_subtype;
            Name = in_name;
            Price = in_price;
            Rarity = in_rarity;
            StackMax = in_stackMax;
            EffectWhileHeld = in_effectWhileHeld;
            EffectWhenUsed = in_effectWhenUsed;
            AsParquet = in_asParquet;
            AsKeyItem = in_asKeyItem;
            Recipe = in_recipe;
        }
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for an <see cref="Item"/> struct.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures.</returns>
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="Item"/> is equal to the current <see cref="Item"/>.
        /// </summary>
        /// <param name="in_item">The <see cref="Item"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(Item in_item)
        {
            return in_item != null && ID == in_item.ID;
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the
        /// current <see cref="Item"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="Item"/>.
        /// </param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        // ReSharper disable once InconsistentNaming
        public override bool Equals(object obj)
        {
            var result = false;

            if (obj is Item in_item)
            {
                result = Equals(in_item);
            }

            return result;
        }

        /// <summary>
        /// Determines whether a specified instance of <see cref="Item"/> is equal to
        /// another specified instance of <see cref="Item"/>.
        /// </summary>
        /// <param name="in_item1">The first <see cref="Item"/> to compare.</param>
        /// <param name="in_item2">The second <see cref="Item"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Item in_item1, Item in_item2)
        {
            if (ReferenceEquals(in_item1, in_item2)) return true;
            if (ReferenceEquals(in_item1, null)) return false;
            if (ReferenceEquals(in_item2, null)) return false;

            return in_item1.ID == in_item2.ID;
        }

        /// <summary>
        /// Determines whether a specified instance of <see cref="Item"/> is not equal
        /// to another specified instance of <see cref="Item"/>.
        /// </summary>
        /// <param name="in_item1">The first <see cref="Item"/> to compare.</param>
        /// <param name="in_item2">The second <see cref="Item"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Item in_item1, Item in_item2)
        {
            if (ReferenceEquals(in_item1, in_item2)) return false;
            if (ReferenceEquals(in_item1, null)) return true;
            if (ReferenceEquals(in_item2, null)) return true;

            return in_item1.ID != in_item2.ID;
        }
        #endregion

        #region Utility Methods
        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="Item"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
        {
            return Name[0].ToString();
        }
        #endregion
    }
}
