using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CsvHelper.Configuration.Attributes;
using Parquet.Biomes;
using Parquet.Items;

namespace Parquet.Parquets
{
    /// <summary>
    /// Configurations for a sandbox parquet walking surface.
    /// </summary>
    [SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
                     Justification = "By design, subtypes of Model should never themselves use IMutableModel or derived interfaces to access their own members.  The IMutableModel family of interfaces is for external types that require read/write access.")]
    public class FloorModel : ParquetModel, IMutableFloorModel
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
        [Index(8)]
        public ModificationTool ModTool { get; private set; }

        /// <summary>Player-facing name of the parquet, used when it has been dug out.</summary>
        [Index(9)]
        public string TrenchName { get; private set; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="FloorModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="FloorModel"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="FloorModel"/>.  Cannot be null.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="FloorModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="FloorModel"/>.</param>
        /// <param name="inTags">Any additional information about the <see cref="FloorModel"/>.</param>
        /// <param name="inItemID">The <see cref="ModelID"/> of the <see cref="ItemModel"/> awarded to the player when a character gathers this <see cref="FloorModel"/>.</param>
        /// <param name="inAddsToBiome">Which, if any, <see cref="BiomeRecipe"/> this <see cref="FloorModel"/> helps to generate.</param>
        /// <param name="inAddsToRoom">Describes which, if any, <see cref="Rooms.RoomRecipe"/>(s) this <see cref="FloorModel"/> helps form.</param>
        /// <param name="inModTool">The tool used to modify this <see cref="FloorModel"/>.</param>
        /// <param name="inTrenchName">The name to use for this <see cref="FloorModel"/> when it has been dug out.</param>
        public FloorModel(ModelID inID, string inName, string inDescription, string inComment,
                          IEnumerable<ModelTag> inTags = null, ModelID? inItemID = null,
                          IEnumerable<ModelTag> inAddsToBiome = null, IEnumerable<ModelTag> inAddsToRoom = null,
                          ModificationTool inModTool = ModificationTool.None, string inTrenchName = defaultTrenchName)
            : base(Bounds, inID, inName, inDescription, inComment, inTags, inItemID, inAddsToBiome, inAddsToRoom)
        {
            ModTool = inModTool;
            TrenchName = inTrenchName;
        }
        #endregion

        #region IMutableFloorModel Implementation
        /// <summary>The tool used to dig out or fill in the floor.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="FloorModel"/> should never themselves use <see cref="IMutableFloorModel"/>.
        /// IMutableFloorModel is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ModificationTool IMutableFloorModel.ModTool
        {
            get => ModTool;
            set => ModTool = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(ModTool), ModTool)
                : value;
        }

        /// <summary>Player-facing name of the parquet, used when it has been dug out.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="FloorModel"/> should never themselves use <see cref="IMutableFloorModel"/>.
        /// IMutableFloorModel is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        string IMutableFloorModel.TrenchName
        {
            get => TrenchName;
            set => TrenchName = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(TrenchName), TrenchName)
                : value;
        }
        #endregion
    }
}
