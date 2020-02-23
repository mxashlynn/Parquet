using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Items;

namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// Configurations for a sandbox parquet walking surface.
    /// </summary>
    public sealed class FloorModel : ParquetModel
    {
        #region Class Defaults
        /// <summary>A name to employ for parquets when IsTrench is set, if none is provided.</summary>
        private const string defaultTrenchName = "dark hole";

        /// <summary>The set of values that are allowed for Floor IDs.</summary>
        public static Range<EntityID> Bounds => All.FloorIDs;
        #endregion

        #region Characteristics
        /// <summary>The tool used to dig out or fill in the floor.</summary>
        [Index(7)]
        public ModificationTool ModTool { get; }

        /// <summary>Player-facing name of the parquet, used when it has been dug out.</summary>
        [Index(8)]
        public string TrenchName { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="FloorModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the parquet.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the parquet.  Cannot be null.</param>
        /// <param name="inDescription">Player-friendly description of the parquet.</param>
        /// <param name="inComment">Comment of, on, or by the parquet.</param>
        /// <param name="inItemID">The <see cref="EntityID"/> of the <see cref="Items.ItemModel"/> awarded to the player when a character gathers this parquet.</param>
        /// <param name="inAddsToBiome">Which, if any, <see cref="BiomeModel"/> this parquet helps to generate.</param>
        /// <param name="inAddsToRoom">Describes which, if any, <see cref="Rooms.RoomRecipe"/>(s) this parquet helps form.</param>
        /// <param name="inModTool">The tool used to modify this floor.</param>
        /// <param name="inTrenchName">The name to use for this floor when it has been dug out.</param>
        public FloorModel(EntityID inID, string inName, string inDescription, string inComment,
                     EntityID? inItemID = null, EntityTag inAddsToBiome = null,
                     EntityTag inAddsToRoom = null, ModificationTool inModTool = ModificationTool.None,
                     string inTrenchName = defaultTrenchName)
            : base(Bounds, inID, inName, inDescription, inComment, inItemID ?? EntityID.None,
                   inAddsToBiome ?? EntityTag.None, inAddsToRoom ?? EntityTag.None)
        {
            ModTool = inModTool;
            TrenchName = inTrenchName;
        }
        #endregion
    }
}
