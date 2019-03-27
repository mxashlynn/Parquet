using Newtonsoft.Json;
using ParquetClassLibrary.Sandbox.ID;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Sandbox.Parquets
{
    /// <summary>
    /// Configurations for a sandbox-mode parquet block.
    /// </summary>
    public class Block : ParquetParent
    {
        #region Class Defaults
        /// <summary>Minimum toughness value.</summary>
        public const int LowestPossibleToughness = 0;

        /// <summary>Maximum toughness value to use when none is specified.</summary>
        private const int DefaultMaxToughness = 10;

        /// <summary>The set of values that are allowed for Block IDs.</summary>
        [JsonIgnore]
        protected override Range<EntityID> Bounds { get { return Assembly.BlockIDs; } }
        #endregion

        #region Parquet Mechanics
        /// <summary>The tool used to remove the block.</summary>
        [JsonProperty(PropertyName = "in_gatherTool")]
        public GatheringTools GatherTool { get; private set; }

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

        #region Block Status
        /// <summary>The block's current toughness.</summary>
        [JsonIgnore]
        private int _toughness;

        /// <summary>The block's current toughness, from 0 to <see cref="MaxToughness"/>.</summary>
        [JsonIgnore]
        public int Toughness
        {
            get => _toughness;
            set => _toughness = value.Normalize(LowestPossibleToughness, MaxToughness);
        }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ParquetClassLibrary.Sandbox.Parquets.Block"/> class.
        /// </summary>
        /// <param name="in_ID">Unique identifier for the parquet.  Cannot be null.</param>
        /// <param name="in_name">Player-friendly name of the parquet.  Cannot be null.</param>
        /// <param name="in_addsToBiome">A set of flags indicating which, if any, <see cref="T:ParquetClassLibrary.Sandbox.Biome"/> this parquet helps to generate.</param>
        /// <param name="in_gatherTool">The tool used to gather this block.</param>
        /// <param name="in_isFlammable">If <c>true</c> this block may burn.</param>
        /// <param name="in_isLiquid">If <c>true</c> this block will flow.</param>
        /// <param name="in_maxToughness">Representation of the difficulty involved in gathering this block.</param>
        [JsonConstructor]
        public Block(EntityID in_ID, string in_name, BiomeMask in_addsToBiome = BiomeMask.None, GatheringTools in_gatherTool = GatheringTools.None,
                     bool in_isFlammable = false, bool in_isLiquid = false, int in_maxToughness = DefaultMaxToughness)
                     : base(in_ID, in_name, in_addsToBiome)
        {
            GatherTool = in_gatherTool;
            IsFlammable = in_isFlammable;
            IsLiquid = in_isLiquid;
            MaxToughness = in_maxToughness;
            Toughness = MaxToughness;
        }
        #endregion
    }
}
