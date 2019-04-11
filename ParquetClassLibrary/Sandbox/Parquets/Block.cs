using System;
using Newtonsoft.Json;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Sandbox.IDs;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Sandbox.Parquets
{
    /// <summary>
    /// Configurations for a sandbox-mode parquet block.
    /// </summary>
    public sealed class Block : ParquetParent
    {
        #region Class Defaults
        /// <summary>Minimum toughness value.</summary>
        public const int LowestPossibleToughness = 0;

        /// <summary>Maximum toughness value to use when none is specified.</summary>
        public const int DefaultMaxToughness = 10;

        /// <summary>The set of values that are allowed for Block IDs.</summary>
        // TODO Test if we can remove this ignore tag.
        [JsonIgnore]
        public static Range<EntityID> Bounds => AssemblyInfo.BlockIDs;
        #endregion

        #region Parquet Mechanics
        /// <summary>The tool used to remove the block.</summary>
        [JsonProperty(PropertyName = "in_gatherTool")]
        public GatheringTools GatherTool { get; private set; }

        /// <summary>The effect generated when a character gathers this Block.</summary>
        [JsonProperty(PropertyName = "in_gatherEffect")]
        public GatheringEffect GatherEffect { get; private set; }

        /// <summary>The item awarded to the player when a character gathers this Block.</summary>
        [JsonProperty(PropertyName = "in_itemID")]
        public EntityID ItemID { get; private set; }

        /// <summary>The Collectible spawned when a character gathers this Block.</summary>
        [JsonProperty(PropertyName = "in_collectibleID")]
        public EntityID CollectibleID { get; private set; }

        /// <summary>The block is flammable.</summary>
        [JsonProperty(PropertyName = "in_isFlammable")]
        public bool IsFlammable { get; private set; }

        /// <summary>The block is a liquid.</summary>
        [JsonProperty(PropertyName = "in_isLiquid")]
        public bool IsLiquid { get; private set; }

        /// <summary>The block's native toughness.</summary>
        [JsonProperty(PropertyName = "in_maxToughness")]
        public int MaxToughness { get; private set; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ParquetClassLibrary.Sandbox.Parquets.Block"/> class.
        /// </summary>
        /// <param name="in_id">Unique identifier for the parquet.  Cannot be null.</param>
        /// <param name="in_name">Player-friendly name of the parquet.  Cannot be null.</param>
        /// <param name="in_addsToBiome">A set of flags indicating which, if any, <see cref="T:ParquetClassLibrary.Sandbox.Biome"/> this parquet helps to generate.</param>
        /// <param name="in_gatherTool">The tool used to gather this block.</param>
        /// <param name="in_gatherEffect">Effect of this block when gathered.</param>
        /// <param name="in_itemID">The item that this collectible corresponds to, if any.</param>
        /// <param name="in_collectibleID">The Collectible to spawn, if any, when this Block is Gathered.</param>
        /// <param name="in_isFlammable">If <c>true</c> this block may burn.</param>
        /// <param name="in_isLiquid">If <c>true</c> this block will flow.</param>
        /// <param name="in_maxToughness">Representation of the difficulty involved in gathering this block.</param>
        [JsonConstructor]
        public Block(EntityID in_id, string in_name, BiomeMask in_addsToBiome = BiomeMask.None,
                     GatheringTools in_gatherTool = GatheringTools.None,
                     GatheringEffect in_gatherEffect = GatheringEffect.None,
                     EntityID? in_itemID = null, EntityID? in_collectibleID = null,
                     bool in_isFlammable = false, bool in_isLiquid = false,
                     int in_maxToughness = DefaultMaxToughness)
                     : base(Bounds, in_id, in_name, in_addsToBiome)
        {
            var nonNullCollectibleID = in_collectibleID ?? EntityID.None;
            if (!nonNullCollectibleID.IsValidForRange(AssemblyInfo.CollectibleIDs))
            {
                throw new ArgumentOutOfRangeException(nameof(in_collectibleID));
            }
            var nonNullItemID = in_itemID ?? EntityID.None;
            if (!nonNullItemID.IsValidForRange(AssemblyInfo.ItemIDs))
            {
                throw new ArgumentOutOfRangeException(nameof(in_itemID));
            }

            GatherTool = in_gatherTool;
            GatherEffect = in_gatherEffect;
            ItemID = nonNullItemID;
            CollectibleID = nonNullCollectibleID;
            IsFlammable = in_isFlammable;
            IsLiquid = in_isLiquid;
            MaxToughness = in_maxToughness;
        }
        #endregion
    }
}
