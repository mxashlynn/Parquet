using CsvHelper.Configuration.Attributes;
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
        public static Range<ModelID> Bounds => All.BlockIDs;
        #endregion

        #region Characteristics
        /// <summary>The tool used to remove the block.</summary>
        [Index(7)]
        public GatheringTool GatherTool { get; }

        /// <summary>The effect generated when a character gathers this Block.</summary>
        [Index(8)]
        public GatheringEffect GatherEffect { get; }

        /// <summary>The Collectible spawned when a character gathers this Block.</summary>
        [Index(9)]
        public ModelID CollectibleID { get; }

        /// <summary>Whether or not the block is flammable.</summary>
        [Index(10)]
        public bool IsFlammable { get; }

        /// <summary>Whether or not the block is a liquid.</summary>
        [Index(11)]
        public bool IsLiquid { get; }

        /// <summary>The block's native toughness.</summary>
        [Index(12)]
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
        public BlockModel(ModelID inID, string inName, string inDescription, string inComment,
                     ModelID? inItemID = null, ModelTag inAddsToBiome = null,
                     ModelTag inAddsToRoom = null,
                     GatheringTool inGatherTool = GatheringTool.None,
                     GatheringEffect inGatherEffect = GatheringEffect.None,
                     ModelID? inCollectibleID = null, bool inIsFlammable = false,
                     bool inIsLiquid = false, int inMaxToughness = DefaultMaxToughness)
            : base(Bounds, inID, inName, inDescription, inComment, inItemID ?? ModelID.None,
                   inAddsToBiome ?? ModelTag.None, inAddsToRoom ?? ModelTag.None)
        {
            var nonNullCollectibleID = inCollectibleID ?? ModelID.None;

            Precondition.IsInRange(nonNullCollectibleID, All.CollectibleIDs, nameof(inCollectibleID));

            GatherTool = inGatherTool;
            GatherEffect = inGatherEffect;
            CollectibleID = nonNullCollectibleID;
            IsFlammable = inIsFlammable;
            IsLiquid = inIsLiquid;
            MaxToughness = inMaxToughness;
        }
        #endregion
    }
}
