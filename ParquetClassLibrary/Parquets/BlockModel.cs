using System;
using CsvHelper.Configuration;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// Configurations for a sandbox parquet block.
    /// </summary>
    public sealed class BlockModel : ParquetModel
    {
        #region Class Defaults
        /// <summary>Minimum toughness value for any Block.</summary>
        public const int LowestPossibleToughness = 0;

        /// <summary>Maximum toughness value to use when none is specified.</summary>
        public const int DefaultMaxToughness = 10;

        /// <summary>The set of values that are allowed for Block IDs.</summary>
        public static Range<EntityID> Bounds => All.BlockIDs;
        #endregion

        #region Characteristics
        /// <summary>The tool used to remove the block.</summary>
        public GatheringTool GatherTool { get; }

        /// <summary>The effect generated when a character gathers this Block.</summary>
        public GatherEffect GatherEffect { get; }

        /// <summary>The Collectible spawned when a character gathers this Block.</summary>
        public EntityID CollectibleID { get; }

        /// <summary>Whether or not the block is flammable.</summary>
        public bool IsFlammable { get; }

        /// <summary>Whether or not the block is a liquid.</summary>
        public bool IsLiquid { get; }

        /// <summary>The block's native toughness.</summary>
        public int MaxToughness { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="BlockModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the parquet.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the parquet.  Cannot be null.</param>
        /// <param name="inDescription">Player-friendly description of the parquet.</param>
        /// <param name="inComment">Comment of, on, or by the parquet.</param>
        /// <param name="inItemID">The item that this collectible corresponds to, if any.</param>
        /// <param name="inAddsToBiome">A set of flags indicating which, if any, <see cref="BiomeModel"/> this parquet helps to generate.</param>
        /// <param name="inGatherTool">The tool used to gather this block.</param>
        /// <param name="inGatherEffect">Effect of this block when gathered.</param>
        /// <param name="inCollectibleID">The Collectible to spawn, if any, when this Block is Gathered.</param>
        /// <param name="inIsFlammable">If <c>true</c> this block may burn.</param>
        /// <param name="inIsLiquid">If <c>true</c> this block will flow.</param>
        /// <param name="inMaxToughness">Representation of the difficulty involved in gathering this block.</param>
        public BlockModel(EntityID inID, string inName, string inDescription, string inComment,
                     EntityID? inItemID = null, EntityTag inAddsToBiome = null,
                     EntityTag inAddsToRoom = null,
                     GatheringTool inGatherTool = GatheringTool.None,
                     GatherEffect inGatherEffect = GatherEffect.None,
                     EntityID? inCollectibleID = null, bool inIsFlammable = false,
                     bool inIsLiquid = false, int inMaxToughness = DefaultMaxToughness)
            : base(Bounds, inID, inName, inDescription, inComment, inItemID ?? EntityID.None,
                   inAddsToBiome ?? EntityTag.None, inAddsToRoom ?? EntityTag.None)
        {
            var nonNullCollectibleID = inCollectibleID ?? EntityID.None;

            Precondition.IsInRange(nonNullCollectibleID, All.CollectibleIDs, nameof(inCollectibleID));

            GatherTool = inGatherTool;
            GatherEffect = inGatherEffect;
            CollectibleID = nonNullCollectibleID;
            IsFlammable = inIsFlammable;
            IsLiquid = inIsLiquid;
            MaxToughness = inMaxToughness;
        }
        #endregion

        #region Serialization
        #region Serializer Shim
        /// <summary>
        /// Provides a default public parameterless constructor for a
        /// <see cref="BlockModel"/>-like class that CSVHelper can instantiate.
        /// 
        /// Provides the ability to generate a <see cref="BlockModel"/> from this class.
        /// </summary>
        internal class BlockShim : ParquetModelShim
        {
            /// <summary>The tool used to remove the block.</summary>
            public GatheringTool GatherTool;

            /// <summary>The effect generated when a character gathers this Block.</summary>
            public GatherEffect GatherEffect;

            /// <summary>The collectible spawned when a character gathers this Block.</summary>
            public EntityID CollectibleID;

            /// <summary>The block is flammable.</summary>
            public bool IsFlammable;

            /// <summary>The block is a liquid.</summary>
            public bool IsLiquid;

            /// <summary>The block's native toughness.</summary>
            public int MaxToughness;

            /// <summary>
            /// Converts a shim into the class it corresponds to.
            /// </summary>
            /// <typeparam name="TModel">The type to convert this shim to.</typeparam>
            /// <returns>An instance of a child class of <see cref="ParquetModel"/>.</returns>
            public override TModel ToInstance<TModel>()
            {
                Precondition.IsOfType<TModel, BlockModel>(typeof(TModel).ToString());

                return (TModel)(ShimProvider)new BlockModel(ID, Name, Description, Comment, ItemID, AddsToBiome,
                                                            AddsToRoom, GatherTool, GatherEffect, CollectibleID,
                                                            IsFlammable, IsLiquid, MaxToughness);
            }
        }
        #endregion

        #region Class Map
        /// <summary>
        /// Maps the values in a <see cref="BlockShim"/> to records that CSVHelper recognizes.
        /// </summary>
        internal sealed class BlockClassMap : ClassMap<BlockShim>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="BlockClassMap"/> class.
            /// </summary>
            public BlockClassMap()
            {
                // Properties are ordered by index to facilitate a logical layout in spreadsheet apps.
                Map(m => m.ID).Index(0);
                Map(m => m.Name).Index(1);
                Map(m => m.Description).Index(2);
                Map(m => m.Comment).Index(3);

                Map(m => m.ItemID).Index(4);
                Map(m => m.AddsToBiome).Index(5);
                Map(m => m.AddsToRoom).Index(6);

                Map(m => m.GatherTool).Index(7);
                Map(m => m.GatherEffect).Index(8);
                Map(m => m.CollectibleID).Index(9);
                Map(m => m.IsFlammable).Index(10);
                Map(m => m.IsLiquid).Index(11);
                Map(m => m.MaxToughness).Index(12);
            }
        }
        #endregion

        /// <summary>Caches a class mapper.</summary>
        private static BlockClassMap classMapCache;

        /// <summary>
        /// Provides the means to map all members of this class to a CSV file.
        /// </summary>
        /// <returns>The member mapping.</returns>
        internal static ClassMap GetClassMap()
            => classMapCache
            ?? (classMapCache = new BlockClassMap());

        /// <summary>
        /// Provides the means to map all members of this class to a CSV file.
        /// </summary>
        /// <returns>The member mapping.</returns>
        internal new static Type GetShimType()
            => typeof(BlockShim);
        #endregion
    }
}
