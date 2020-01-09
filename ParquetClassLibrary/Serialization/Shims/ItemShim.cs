using System.Collections.Generic;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Serialization.Shims
{
    /// <summary>
    /// Provides a default public parameterless constructor for a
    /// <see cref="ItemModel"/>-like class that CSVHelper can instantiate.
    /// 
    /// Provides the ability to generate a <see cref="ItemModel"/> from this class.
    /// </summary>
    public class ItemShim : EntityShim
    {
        /// <summary>The type of item this is.</summary>
        public ItemType Subtype;

        /// <summary>In-game value of the item.  Must be non-negative.</summary>
        public int Price;

        /// <summary>How relatively rare this item is.</summary>
        public int Rarity;

        /// <summary>How many of the item may share a single inventory slot.</summary>
        public int StackMax;

        /// <summary>An in-game effect caused by keeping the item in a character's inventory.</summary>
        public int EffectWhileHeld;

        /// <summary>An in-game effect caused by using (consuming) the item.</summary>
        public int EffectWhenUsed;

        /// <summary>The parquet that corresponds to this item, if any.</summary>
        public EntityID AsParquet;

        /// <summary>Any additional functionality this item has, e.g. contributing to a <see cref="Biomes.BiomeModel"/>.</summary>
        public List<EntityTag> ItemTags;

        /// <summary>How this item is crafted.</summary>
        public EntityID Recipe;

        /// <summary>
        /// Converts a shim into the class it corresponds to.
        /// </summary>
        /// <typeparam name="T">The type to convert this shim to.</typeparam>
        /// <returns>An instance of a child class of <see cref="Enity"/>.</returns>
        public override T ToEntity<T>()
        {
            Precondition.IsOfType<T, ItemModel>(typeof(T).ToString());

            return (T)(EntityModel)new ItemModel(ID, Name, Description, Comment, Subtype, Price, Rarity, StackMax,
                                            EffectWhileHeld, EffectWhenUsed, AsParquet, ItemTags, Recipe);
        }
    }
}
