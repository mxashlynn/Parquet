using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CsvHelper.Configuration.Attributes;
using Parquet.Biomes;
using Parquet.Items;

namespace Parquet.Parquets
{
    /// <summary>
    /// Configurations for a sandbox parquet block.
    /// </summary>
    [SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
                     Justification = "By design, subtypes of Model should never themselves use IMutableModel or derived interfaces to access their own members.  The IMutableModel family of interfaces is for external types that require read/write access.")]
    public class BlockModel : ParquetModel, IMutableBlockModel
    {
        #region Class Defaults
        /// <summary>Lowest possible toughness for any block.  A block is dislodged when its toughness reaches this.</summary>
        public const int MinToughness = 0;

        /// <summary>Highest possible toughness for any block.  This value is used when none is specified.</summary>
        public const int DefaultMaxToughness = 10;

        /// <summary>The set of values that are allowed for block IDs.</summary>
        public static Range<ModelID> Bounds
            => All.BlockIDs;
        #endregion

        #region Characteristics
        /// <summary>The tool used to remove the Block.</summary>
        [Index(8)]
        public GatheringTool GatherTool { get; private set; }

        /// <summary>The effect generated when a character gathers this Block.</summary>
        [Index(9)]
        public GatheringEffect GatherEffect { get; private set; }

        /// <summary>The Collectible spawned when a character gathers this Block.</summary>
        [Index(10)]
        public ModelID CollectibleID { get; private set; }

        /// <summary>Whether or not the block is flammable.</summary>
        [Index(11)]
        public bool IsFlammable { get; private set; }

        /// <summary>Whether or not the block is a liquid.</summary>
        [Index(12)]
        public bool IsLiquid { get; private set; }

        /// <summary>The block's native toughness.</summary>
        [Index(13)]
        public int MaxToughness { get; private set; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="BlockModel"/> class.
        /// </summary>
        /// <param name="id">Unique identifier for the <see cref="BlockModel"/>.  Cannot be null.</param>
        /// <param name="name">Player-friendly name of the <see cref="BlockModel"/>.  Cannot be null.</param>
        /// <param name="description">Player-friendly description of the <see cref="BlockModel"/>.</param>
        /// <param name="comment">Comment of, on, or by the <see cref="BlockModel"/>.</param>
        /// <param name="tags">Any additional information about the <see cref="BlockModel"/>.</param>
        /// <param name="itemID">The item that this <see cref="BlockModel"/> corresponds to, if any.</param>
        /// <param name="addsToBiome">A set of flags indicating which, if any, <see cref="BiomeRecipe"/> this <see cref="BlockModel"/> helps to generate.</param>
        /// <param name="addsToRoom">A set of flags indicating which, if any, <see cref="Rooms.RoomRecipe"/> this <see cref="BlockModel"/> helps to generate.</param>
        /// <param name="gatherTool">The tool used to gather this <see cref="BlockModel"/>.</param>
        /// <param name="gatherEffect">Effect of this <see cref="BlockModel"/> when gathered.</param>
        /// <param name="collectibleID">The <see cref="CollectibleModel"/> to spawn, if any, when this <see cref="BlockModel"/> is gathered.</param>
        /// <param name="isFlammable">If <c>true</c> this <see cref="BlockModel"/> may burn.</param>
        /// <param name="isLiquid">If <c>true</c> this <see cref="BlockModel"/> will flow.</param>
        /// <param name="maxToughness">Representation of the difficulty involved in gathering this <see cref="BlockModel"/>.</param>
        public BlockModel(ModelID id, string name, string description, string comment,
                          IEnumerable<ModelTag> tags = null,
                          ModelID? itemID = null, IEnumerable<ModelTag> addsToBiome = null,
                          IEnumerable<ModelTag> addsToRoom = null,
                          GatheringTool gatherTool = GatheringTool.None,
                          GatheringEffect gatherEffect = GatheringEffect.None,
                          ModelID? collectibleID = null, bool isFlammable = false,
                          bool isLiquid = false, int maxToughness = DefaultMaxToughness)
            : base(Bounds, id, name, description, comment, tags, itemID, addsToBiome, addsToRoom)
        {
            var nonNullCollectibleID = collectibleID ?? ModelID.None;

            Precondition.IsInRange(nonNullCollectibleID, All.CollectibleIDs, nameof(collectibleID));

            GatherTool = gatherTool;
            GatherEffect = gatherEffect;
            CollectibleID = nonNullCollectibleID;
            IsFlammable = isFlammable;
            IsLiquid = isLiquid;
            MaxToughness = maxToughness;
        }
        #endregion

        #region IMutableBlockModel Implementation
        /// <summary>The tool used to remove the block.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="BlockModel"/> should never themselves use <see cref="IMutableBlockModel"/>.
        /// IMutableBlockModel is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        GatheringTool IMutableBlockModel.GatherTool
        {
            get => GatherTool;
            set => GatherTool = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(GatherTool), GatherTool)
                : value;
        }

        /// <summary>The effect generated when a character gathers this Block.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="BlockModel"/> should never themselves use <see cref="IMutableBlockModel"/>.
        /// IMutableBlockModel is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        GatheringEffect IMutableBlockModel.GatherEffect
        {
            get => GatherEffect;
            set => GatherEffect = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(GatherEffect), GatherEffect)
                : value;
        }

        /// <summary>The Collectible spawned when a character gathers this Block.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="BlockModel"/> should never themselves use <see cref="IMutableBlockModel"/>.
        /// IMutableBlockModel is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ModelID IMutableBlockModel.CollectibleID
        {
            get => CollectibleID;
            set => CollectibleID = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(CollectibleID), CollectibleID)
                : value;
        }

        /// <summary>Whether or not the block is flammable.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="BlockModel"/> should never themselves use <see cref="IMutableBlockModel"/>.
        /// IMutableBlockModel is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        bool IMutableBlockModel.IsFlammable
        {
            get => IsFlammable;
            set => IsFlammable = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(IsFlammable), IsFlammable)
                : value;
        }

        /// <summary>Whether or not the block is a liquid.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="BlockModel"/> should never themselves use <see cref="IMutableBlockModel"/>.
        /// IMutableBlockModel is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        bool IMutableBlockModel.IsLiquid
        {
            get => IsLiquid;
            set => IsLiquid = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(IsLiquid), IsLiquid)
                : value;
        }

        /// <summary>The block's native toughness.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="BlockModel"/> should never themselves use <see cref="IMutableBlockModel"/>.
        /// IMutableBlockModel is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        int IMutableBlockModel.MaxToughness
        {
            get => MaxToughness;
            set => MaxToughness = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(MaxToughness), MaxToughness)
                : value;
        }
        #endregion
    }
}
