using System;
using CsvHelper.Configuration;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// Configurations for a sandbox collectible object, such as crafting materials.
    /// </summary>
    public sealed class CollectibleModel : ParquetModel
    {
        #region Class Defaults
        /// <summary>The set of values that are allowed for Collectible IDs.</summary>
        public static Range<EntityID> Bounds => All.CollectibleIDs;
        #endregion

        #region Characteristics
        /// <summary>The effect generated when a character encounters this Collectible.</summary>
        public CollectEffect Effect { get; }

        /// <summary>
        /// The scale in points of the effect.  For example, how much to alter a stat if the
        /// <see cref="CollectEffect"/> is set to alter a stat.
        /// </summary>
        public int EffectAmount { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="CollectibleModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the parquet.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the parquet.  Cannot be null.</param>
        /// <param name="inDescription">Player-friendly description of the parquet.</param>
        /// <param name="inComment">Comment of, on, or by the parquet.</param>
        /// <param name="inItemID">The <see cref="EntityID"/> of the <see cref="Item"/> that this <see cref="CollectibleModel"/> corresponds to, if any.</param>
        /// <param name="inAddsToBiome">A set of flags indicating which, if any, <see cref="BiomeModel"/> this parquet helps to generate.</param>
        /// <param name="inEffect">Effect of this collectible.</param>
        /// <param name="inEffectAmount">
        /// The scale in points of the effect.
        /// For example, how much to alter a stat if inEffect is set to alter a stat.
        /// </param>
        public CollectibleModel(EntityID inID, string inName, string inDescription, string inComment,
                           EntityID? inItemID = null, EntityTag inAddsToBiome = null,
                           EntityTag inAddsToRoom = null, CollectEffect inEffect = CollectEffect.None,
                           int inEffectAmount = 0)
            : base(Bounds, inID, inName, inDescription, inComment, inItemID ?? EntityID.None,
                   inAddsToBiome ?? EntityTag.None, inAddsToRoom ?? EntityTag.None)
        {
            var nonNullItemID = inItemID ?? EntityID.None;
            Precondition.IsInRange(nonNullItemID, All.ItemIDs, nameof(inItemID));

            Effect = inEffect;
            EffectAmount = inEffectAmount;
        }
        #endregion

        #region Serialization
        #region Serializer Shim
        /// <summary>
        /// Provides a default public parameterless constructor for a <see cref="CollectibleModel"/>-like
        /// class that CSVHelper can instantiate.
        /// 
        /// Provides the ability to generate a <see cref="CollectibleModel"/> from this class.
        /// </summary>
        internal class CollectibleShim : ParquetModelShim
        {
            /// <summary>The effect generated when a character encounters this collectible.</summary>
            public CollectEffect Effect;

            /// <summary>The scale in points of the effect.</summary>
            public int EffectAmount;

            /// <summary>
            /// Converts a shim into the class it corresponds to.
            /// </summary>
            /// <typeparam name="TModel">The type to convert this shim to.</typeparam>
            /// <returns>An instance of a child class of <see cref="ParquetModel"/>.</returns>
            public override TModel ToInstance<TModel>()
            {
                Precondition.IsOfType<TModel, CollectibleModel>(typeof(TModel).ToString());

                return (TModel)(ShimProvider)new CollectibleModel(ID, Name, Description, Comment, ItemID,
                                                                  AddsToBiome, AddsToRoom, Effect, EffectAmount);
            }
        }
        #endregion

        #region Class Map
        /// <summary>
        /// Maps the values in a <see cref="CollectibleShim"/> to records that CSVHelper recognizes.
        /// </summary>
        internal sealed class CollectibleClassMap : ClassMap<CollectibleShim>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="CollectibleClassMap"/> class.
            /// </summary>
            public CollectibleClassMap()
            {
                // Properties are ordered by index to facilitate a logical layout in spreadsheet apps.
                Map(m => m.ID).Index(0);
                Map(m => m.Name).Index(1);
                Map(m => m.Description).Index(2);
                Map(m => m.Comment).Index(3);

                Map(m => m.ItemID).Index(4);
                Map(m => m.AddsToBiome).Index(5);
                Map(m => m.AddsToRoom).Index(6);

                Map(m => m.Effect).Index(7);
                Map(m => m.EffectAmount).Index(8);
            }
        }
        #endregion

        /// <summary>Caches a class mapper.</summary>
        private static CollectibleClassMap classMapCache;

        /// <summary>
        /// Provides the means to map all members of this class to a CSV file.
        /// </summary>
        /// <returns>The member mapping.</returns>
        internal static ClassMap GetClassMap()
            => classMapCache
            ?? (classMapCache = new CollectibleClassMap());

        /// <summary>
        /// Provides the means to map all members of this class to a CSV file.
        /// </summary>
        /// <returns>The member mapping.</returns>
        internal new static Type GetShimType()
            => typeof(CollectibleShim);
        #endregion
    }
}
