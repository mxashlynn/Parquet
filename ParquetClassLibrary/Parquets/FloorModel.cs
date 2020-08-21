using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Items;

namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// Configurations for a sandbox parquet walking surface.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1033:Interface methods should be callable by child types",
        Justification = "By design, children of Model should never themselves use IModelEdit or its decendent interfaces to access their own members.  The IModelEdit family of interfaces is for external types that require read/write access.")]
    public sealed class FloorModel : ParquetModel, IFloorModelEdit
    {
        #region Class Defaults
        /// <summary>A name to employ for parquets when IsTrench is set, if none is provided.</summary>
        private const string defaultTrenchName = "dark hole";

        /// <summary>The set of values that are allowed for Floor IDs.</summary>
        public static Range<ModelID> Bounds
            => All.FloorIDs;
        #endregion

        #region Characteristics
        /// <summary>The tool used to dig out or fill in the floor.</summary>
        [Index(7)]
        public ModificationTool ModTool { get; private set; }

        /// <summary>The tool used to dig out or fill in the floor.</summary>
        /// <remarks>
        /// By design, children of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ModificationTool IFloorModelEdit.ModTool { get => ModTool; set => ModTool = value; }

        /// <summary>Player-facing name of the parquet, used when it has been dug out.</summary>
        [Index(8)]
        public string TrenchName { get; private set; }

        /// <summary>Player-facing name of the parquet, used when it has been dug out.</summary>
        /// <remarks>
        /// By design, children of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        string IFloorModelEdit.TrenchName { get => TrenchName; set => TrenchName = value; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="FloorModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the parquet.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the parquet.  Cannot be null.</param>
        /// <param name="inDescription">Player-friendly description of the parquet.</param>
        /// <param name="inComment">Comment of, on, or by the parquet.</param>
        /// <param name="inItemID">The <see cref="ModelID"/> of the <see cref="Items.ItemModel"/> awarded to the player when a character gathers this parquet.</param>
        /// <param name="inAddsToBiome">Which, if any, <see cref="BiomeRecipe"/> this parquet helps to generate.</param>
        /// <param name="inAddsToRoom">Describes which, if any, <see cref="Rooms.RoomRecipe"/>(s) this parquet helps form.</param>
        /// <param name="inModTool">The tool used to modify this floor.</param>
        /// <param name="inTrenchName">The name to use for this floor when it has been dug out.</param>
        public FloorModel(ModelID inID, string inName, string inDescription, string inComment,
                     ModelID? inItemID = null, ModelTag inAddsToBiome = null,
                     ModelTag inAddsToRoom = null, ModificationTool inModTool = ModificationTool.None,
                     string inTrenchName = defaultTrenchName)
            : base(Bounds, inID, inName, inDescription, inComment, inItemID ?? ModelID.None,
                   inAddsToBiome ?? ModelTag.None, inAddsToRoom ?? ModelTag.None)
        {
            ModTool = inModTool;
            TrenchName = inTrenchName;
        }
        #endregion
    }
}
