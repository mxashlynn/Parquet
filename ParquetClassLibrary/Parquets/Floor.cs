using Newtonsoft.Json;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// Configurations for a sandbox-mode parquet floor.
    /// </summary>
    public sealed class Floor : ParquetParent
    {
        #region Class Defaults
        /// <summary>A name to employ for parquets when IsTrench is set, if none is provided.</summary>
        private const string defaultTrenchName = "dark hole";

        /// <summary>The set of values that are allowed for Floor IDs.</summary>
        public static Range<EntityID> Bounds => All.FloorIDs;
        #endregion

        #region Parquet Mechanics
        /// <summary>The tool used to dig out or fill in the floor.</summary>
        [JsonProperty(PropertyName = "in_modTool")]
        public ModificationTool ModTool { get; }

        /// <summary>Player-facing name of the parquet, used when it has been dug out.</summary>
        [JsonProperty(PropertyName = "in_trenchName")]
        public string TrenchName { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="Floor"/> class.
        /// </summary>
        /// <param name="in_id">Unique identifier for the parquet.  Cannot be null.</param>
        /// <param name="in_name">Player-friendly name of the parquet.  Cannot be null.</param>
        /// <param name="in_description">Player-friendly description of the parquet.</param>
        /// <param name="in_comment">Comment of, on, or by the parquet.</param>
        /// <param name="in_itemID">The <see cref="EntityID"/> of the <see cref="Items.Item"/> awarded to the player when a character gathers this parquet.</param>
        /// <param name="in_addsToBiome">Which, if any, <see cref="Biome"/> this parquet helps to generate.</param>
        /// <param name="in_modTool">The tool used to modify this floor.</param>
        /// <param name="in_trenchName">The name to use for this floor when it has been dug out.</param>
        /// <param name="in_isWalkable">If <c>true</c> this floor may be walked on.</param>
        [JsonConstructor]
        public Floor(EntityID in_id, string in_name, string in_description, string in_comment,
                     EntityID? in_itemID = null, EntityTag in_addsToBiome = null,
                     EntityTag in_addsToRoom = null, ModificationTool in_modTool = ModificationTool.None,
                     string in_trenchName = defaultTrenchName)
            : base(Bounds, in_id, in_name, in_description, in_comment, in_itemID ?? EntityID.None,
                   in_addsToBiome ?? EntityTag.None, in_addsToRoom ?? EntityTag.None)
        {
            ModTool = in_modTool;
            TrenchName = in_trenchName;
        }
        #endregion
    }
}
