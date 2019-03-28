using Newtonsoft.Json;
using ParquetClassLibrary.Sandbox.ID;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Sandbox.Parquets
{
    /// <summary>
    /// Configurations for a sandbox-mode parquet floor.
    /// </summary>
    public class Floor : ParquetParent
    {
        #region Class Defaults
        /// <summary>A name to employ for parquets when IsHole is set, if none is provided.</summary>
        private const string DefaultNameWhenHole = "dark hole";

        /// <summary>The set of values that are allowed for Floor IDs.</summary>
        [JsonIgnore]
        protected override Range<EntityID> Bounds { get { return Assembly.FloorIDs; } }
        #endregion

        #region Parquet Mechanics
        /// <summary>The tool used to dig out or fill in the floor.</summary>
        [JsonProperty(PropertyName = "in_modTool")]
        public ModificationTools ModTool { get; private set; }

        /// <summary>Player-facing name of the parquet, used when it has been dug out.</summary>
        [JsonProperty(PropertyName = "in_nameWhenHole")]
        public string NameWhenHole { get; private set; }

        /// <summary>The floor may be walked on.</summary>
        [JsonProperty(PropertyName = "in_isWalkable")]
        public bool IsWalkable { get; private set; }
        #endregion

        #region Floor Status
        /// <summary>The floor has been dug out.</summary>
        [JsonIgnore]
        public bool IsHole { get; set; } = false;
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ParquetClassLibrary.Sandbox.Parquets.Floor"/> class.
        /// </summary>
        /// <param name="in_ID">Unique identifier for the parquet.  Cannot be null.</param>
        /// <param name="in_name">Player-friendly name of the parquet.  Cannot be null.</param>
        /// <param name="in_addsToBiome">A set of flags indicating which, if any, <see cref="T:ParquetClassLibrary.Sandbox.Biome"/> this parquet helps to generate.</param>
        /// <param name="in_modTool">The tool used to modify this floor.</param>
        /// <param name="in_nameWhenHole">The name to use for this floor when it has been dug out.</param>
        /// <param name="in_isWalkable">If <c>true</c> this floor may be walked on.</param>
        [JsonConstructor]
        public Floor(EntityID in_ID, string in_name, BiomeMask in_addsToBiome = BiomeMask.None,
                     ModificationTools in_modTool = ModificationTools.None,
                     string in_nameWhenHole = DefaultNameWhenHole, bool in_isWalkable = true)
                     : base(in_ID, in_name, in_addsToBiome)
        {
            ModTool = in_modTool;
            NameWhenHole = in_nameWhenHole;
            IsWalkable = in_isWalkable;
        }
        #endregion
    }
}
