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
        /// <summary>An adjective to employ for trenches if none is provided.</summary>
        private const string DefaultTrenchAdjective = "dark";

        /// <summary>The set of values that are allowed for Floor's allowed ParquetIDs.</summary>
        [JsonIgnore]
        protected override Range<ParquetID> Bounds { get { return Assembly.FloorIDs; } }
        #endregion

        #region Parquet Physics
        /// <summary>The tool used to dig out or fill in the floor.</summary>
        [JsonProperty(PropertyName = "in_modTool")]
        public ModificationTools ModTool { get; private set; }

        /// <summary>An adjective to employ for trenches.</summary>
        [JsonProperty(PropertyName = "in_trenchAdjective")]
        public string TrenchAdjective { get; private set; }

        /// <summary>The floor may be walked on.</summary>
        [JsonProperty(PropertyName = "in_isWalkable")]
        public bool IsWalkable { get; private set; }

        // IDEA: Add isFlyable
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
        /// <param name="in_modTool">The tool used to gather this block.</param>
        /// <param name="in_trenchAdjective">In trench adjective.</param>
        /// <param name="in_isWalkable">If <c>true</c> this block may burn.</param>
        [JsonConstructor]
        public Floor(ParquetID in_ID, string in_name, BiomeMask in_addsToBiome = BiomeMask.None,
                     ModificationTools in_modTool = ModificationTools.None,
                     string in_trenchAdjective = DefaultTrenchAdjective, bool in_isWalkable = true)
                     : base(in_ID, in_name, in_addsToBiome)
        {
            ModTool = in_modTool;
            TrenchAdjective = in_trenchAdjective;
            IsWalkable = in_isWalkable;
        }
        #endregion
    }
}
