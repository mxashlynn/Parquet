using System.Collections.Generic;
using CsvHelper.Configuration.Attributes;
using Parquet.Biomes;
using Parquet.Items;

namespace Parquet.Parquets
{
    /// <summary>
    /// Configurations for a sandbox parquet walking surface.
    /// </summary>
    public partial class FloorModel : ParquetModel
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

        /// <summary>Player-facing name of the parquet, used when it has been dug out.</summary>
        [Index(8)]
        public string TrenchName { get; private set; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="FloorModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the parquet.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the parquet.  Cannot be null.</param>
        /// <param name="inDescription">Player-friendly description of the parquet.</param>
        /// <param name="inComment">Comment of, on, or by the parquet.</param>
        /// <param name="inItemID">The <see cref="ModelID"/> of the <see cref="ItemModel"/> awarded to the player when a character gathers this parquet.</param>
        /// <param name="inAddsToBiome">Which, if any, <see cref="BiomeRecipe"/> this parquet helps to generate.</param>
        /// <param name="inAddsToRoom">Describes which, if any, <see cref="Rooms.RoomRecipe"/>(s) this parquet helps form.</param>
        /// <param name="inModTool">The tool used to modify this floor.</param>
        /// <param name="inTrenchName">The name to use for this floor when it has been dug out.</param>
        public FloorModel(ModelID inID, string inName, string inDescription, string inComment,
                          ModelID? inItemID = null, IEnumerable<ModelTag> inAddsToBiome = null,
                          IEnumerable<ModelTag> inAddsToRoom = null, ModificationTool inModTool = ModificationTool.None,
                          string inTrenchName = defaultTrenchName)
            : base(Bounds, inID, inName, inDescription, inComment, inItemID, inAddsToBiome, inAddsToRoom)
        {
            ModTool = inModTool;
            TrenchName = inTrenchName;
        }
        #endregion
    }
}
