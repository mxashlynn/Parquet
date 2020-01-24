using System;
using System.Collections.Generic;
using System.Linq;
using CsvHelper.Configuration;
using ParquetClassLibrary.Crafts;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Items
{
    /// <summary>
    /// Models an item that characters may carry, use, equip, trade, and/or build with.
    /// </summary>
    public sealed class ItemModel : EntityModel
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

        #region Serialization
        #region Serializer Shim
        /// <summary>
        /// Provides a default public parameterless constructor for a
        /// <see cref="ItemModel"/>-like class that CSVHelper can instantiate.
        /// 
        /// Provides the ability to generate a <see cref="ItemModel"/> from this class.
        /// </summary>
        internal class ItemShim : EntityShim
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
            public IReadOnlyList<EntityTag> ItemTags;

            /// <summary>How this item is crafted.</summary>
            public EntityID Recipe;

            /// <summary>
            /// Converts a shim into the class it corresponds to.
            /// </summary>
            /// <typeparam name="TModel">The type to convert this shim to.</typeparam>
            /// <returns>An instance of a child class of <see cref="EntityModel"/>.</returns>
            public override TModel ToEntity<TModel>()
            {
                Precondition.IsOfType<TModel, ItemModel>(typeof(TModel).ToString());

                return (TModel)(EntityModel)new ItemModel(ID, Name, Description, Comment, Subtype, Price, Rarity, StackMax,
                                                          EffectWhileHeld, EffectWhenUsed, AsParquet, ItemTags, Recipe);
            }
        }
        #endregion

        #region Class Map
        /// <summary>
        /// Maps the values in a <see cref="ItemShim"/> to records that CSVHelper recognizes.
        /// </summary>
        internal sealed class ItemClassMap : ClassMap<ItemShim>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ItemClassMap"/> class.
            /// </summary>
            public ItemClassMap()
            {
                // Properties are ordered by index to facilitate a logical layout in spreadsheet apps.
                Map(m => m.ID).Index(0);
                Map(m => m.Name).Index(1);
                Map(m => m.Description).Index(2);
                Map(m => m.Comment).Index(3);

                Map(m => m.Subtype).Index(4);
                Map(m => m.Price).Index(5);
                Map(m => m.Rarity).Index(6);
                Map(m => m.StackMax).Index(7);
                Map(m => m.EffectWhileHeld).Index(8);
                Map(m => m.EffectWhenUsed).Index(9);
                Map(m => m.AsParquet).Index(10);
                Map(m => m.ItemTags).Index(11);
                Map(m => m.Recipe).Index(12);
            }
        }
        #endregion

        /// <summary>Caches a class mapper.</summary>
        private static ItemClassMap classMapCache;

        /// <summary>
        /// Provides the means to map all members of this class to a CSV file.
        /// </summary>
        /// <returns>The member mapping.</returns>
        internal static ClassMap GetClassMap()
            => classMapCache
            ?? (classMapCache = new ItemClassMap());

        /// <summary>
        /// Provides the means to map all members of this class to a CSV file.
        /// </summary>
        /// <returns>The member mapping.</returns>
        internal static Type GetShimType()
            => typeof(ItemShim);
        #endregion
    }
}
