using System;
using System.Collections;
using System.Collections.Generic;
using CsvHelper.Configuration.Attributes;

namespace Parquet.Regions
{
    /// <summary>
    /// Defines an area within the gameworld, both its metadata (such as <see cref="BackgroundColor"/>)
    /// and instructions on how to procedurally generate its contents (via a <see cref="MapChunkGrid"/>.
    /// <seealso cref="RegionStatus"/>.
    /// </summary>
    public class RegionModel : Model, IMutableRegionModel
    {
        #region Class Defaults
        /// <summary>Indicates an uninitialized region.</summary>
        public static readonly RegionModel Empty = new RegionModel(ModelID.None, nameof(Empty), "", "");

        /// <summary>The set of values that are allowed for <see cref="RegionModel"/> <see cref="ModelID"/>s.</summary>
        public static Range<ModelID> Bounds
            => All.RegionIDs;

        /// <summary>Default color for new regions.</summary>
        internal const string DefaultColor = "#FFFFFFFF";

        /// <summary>The length of each <see cref="RegionModel"/> in <see cref="MapChunk"/>s.</summary>
        public const int ChunksPerRegionDimension = 4;

        /// <summary>Dimensions in chunks of the <see cref="MapChunkGrid"/> stored by this <see cref="RegionModel"/>.</summary>
        public static Vector2D DimensionsInChunks { get; } = new Vector2D(ChunksPerRegionDimension, ChunksPerRegionDimension);
        #endregion

        #region Characteristics
        /// <summary>A color to display in any empty areas of the region.</summary>
        [Index(5)]
        public string BackgroundColor { get; private set; }

        /// <summary>The <see cref="ModelID"/> of the region to the north of this one.</summary>
        [Index(6)]
        public ModelID RegionToTheNorth { get; private set; }

        /// <summary>The <see cref="ModelID"/> of the region to the east of this one.</summary>
        [Index(7)]
        public ModelID RegionToTheEast { get; private set; }

        /// <summary>The <see cref="ModelID"/> of the region to the south of this one.</summary>
        [Index(8)]
        public ModelID RegionToTheSouth { get; private set; }

        /// <summary>The <see cref="ModelID"/> of the region to the west of this one.</summary>
        [Index(9)]
        public ModelID RegionToTheWest { get; private set; }

        /// <summary>The <see cref="ModelID"/> of the region above this one.</summary>
        [Index(10)]
        public ModelID RegionAbove { get; private set; }

        /// <summary>The <see cref="ModelID"/> of the region below this one.</summary>
        [Index(11)]
        public ModelID RegionBelow { get; private set; }

        /// <summary>Instructions on how to procedurally generate this region.</summary>
        [Index(12)]
        public MapChunkGrid MapChunks { get; private set; }
        #endregion

        #region Initialization
        /// <summary>
        /// Constructs a new instance of the <see cref="RegionModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="RegionModel"/>.  Cannot be null.</param>
        /// <param name="inName">The player-facing name of the <see cref="RegionModel"/>.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="RegionModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="RegionModel"/>.</param>
        /// <param name="inTags">Any additional information about the <see cref="RegionModel"/>.</param>
        /// <param name="inBackgroundColor">A color to show in the <see cref="RegionModel"/> when no parquets are present at a location.</param>
        /// <param name="inRegionToTheNorth">The <see cref="ModelID"/> of the <see cref="RegionModel"/> to the north of this one.</param>
        /// <param name="inRegionToTheEast">The <see cref="ModelID"/> of the <see cref="RegionModel"/> to the east of this one.</param>
        /// <param name="inRegionToTheSouth">The <see cref="ModelID"/> of the <see cref="RegionModel"/> to the south of this one.</param>
        /// <param name="inRegionToTheWest">The <see cref="ModelID"/> of the <see cref="RegionModel"/> to the west of this one.</param>
        /// <param name="inRegionAbove">The <see cref="ModelID"/> of the <see cref="RegionModel"/> above this one.</param>
        /// <param name="inRegionBelow">The <see cref="ModelID"/> of the <see cref="RegionModel"/> below this one.</param>
        public RegionModel(ModelID inID, string inName, string inDescription, string inComment,
                           IEnumerable<ModelTag> inTags = null,
                           string inBackgroundColor = DefaultColor,
                           ModelID? inRegionToTheNorth = null,
                           ModelID? inRegionToTheEast = null,
                           ModelID? inRegionToTheSouth = null,
                           ModelID? inRegionToTheWest = null,
                           ModelID? inRegionAbove = null,
                           ModelID? inRegionBelow = null)
            : base(Bounds, inID, inName, inDescription, inComment, inTags)
        {
            var nonNullRegionToTheNorth = inRegionToTheNorth ?? ModelID.None;
            var nonNullRegionToTheEast = inRegionToTheEast ?? ModelID.None;
            var nonNullRegionToTheSouth = inRegionToTheSouth ?? ModelID.None;
            var nonNullRegionToTheWest = inRegionToTheWest ?? ModelID.None;
            var nonNullRegionAbove = inRegionAbove ?? ModelID.None;
            var nonNullRegionBelow = inRegionBelow ?? ModelID.None;

            Precondition.IsInRange(nonNullRegionToTheNorth, Bounds, nameof(inRegionToTheNorth));
            Precondition.IsInRange(nonNullRegionToTheEast, Bounds, nameof(inRegionToTheEast));
            Precondition.IsInRange(nonNullRegionToTheSouth, Bounds, nameof(inRegionToTheSouth));
            Precondition.IsInRange(nonNullRegionToTheWest, Bounds, nameof(inRegionToTheWest));
            Precondition.IsInRange(nonNullRegionAbove, Bounds, nameof(inRegionAbove));
            Precondition.IsInRange(nonNullRegionBelow, Bounds, nameof(inRegionBelow));

            BackgroundColor = inBackgroundColor;
            RegionToTheNorth = nonNullRegionToTheNorth;
            RegionToTheEast = nonNullRegionToTheEast;
            RegionToTheSouth = nonNullRegionToTheSouth;
            RegionToTheWest = nonNullRegionToTheWest;
            RegionAbove = nonNullRegionAbove;
            RegionBelow = nonNullRegionBelow;
        }
        #endregion

        #region IMutableRegionModel Implementation
        /// <summary>A color to display in any empty areas of the region.</summary>
        [Ignore]
        string IMutableRegionModel.BackgroundColor { get => BackgroundColor; set => BackgroundColor = value; }

        /// <summary>The <see cref="ModelID"/> of the region to the north of this one.</summary>
        [Ignore]
        ModelID IMutableRegionModel.RegionToTheNorthID { get => RegionToTheNorth; set => RegionToTheNorth = value; }

        /// <summary>The <see cref="ModelID"/> of the region to the east of this one.</summary>
        [Ignore]
        ModelID IMutableRegionModel.RegionToTheEastID { get => RegionToTheEast; set => RegionToTheEast = value; }

        /// <summary>The <see cref="ModelID"/> of the region to the south of this one.</summary>
        [Ignore]
        ModelID IMutableRegionModel.RegionToTheSouthID { get => RegionToTheSouth; set => RegionToTheSouth = value; }

        /// <summary>The <see cref="ModelID"/> of the region to the west of this one.</summary>
        [Ignore]
        ModelID IMutableRegionModel.RegionToTheWestID { get => RegionToTheWest; set => RegionToTheWest = value; }

        /// <summary>The <see cref="ModelID"/> of the region above this one.</summary>
        [Ignore]
        ModelID IMutableRegionModel.RegionAboveID { get => RegionAbove; set => RegionAbove = value; }

        /// <summary>The <see cref="ModelID"/> of the region below this one.</summary>
        [Ignore]
        ModelID IMutableRegionModel.RegionBelowID { get => RegionBelow; set => RegionBelow = value; }
        #endregion

        #region Utilities
        /// <summary>
        /// Determines how many exist lead from this <see cref="RegionModel"/> to other RegionModels.
        /// </summary>
        /// <returns>The number of exit IDs that are not <see cref="ModelID.None"/>.</returns>
        public int ExitCount()
        {
            var exitCount = 0;
            if (RegionToTheNorth != ModelID.None) { exitCount++; }
            if (RegionToTheSouth != ModelID.None) { exitCount++; }
            if (RegionToTheEast != ModelID.None) { exitCount++; }
            if (RegionToTheWest != ModelID.None) { exitCount++; }
            if (RegionAbove != ModelID.None) { exitCount++; }
            if (RegionBelow != ModelID.None) { exitCount++; }
            return exitCount;
        }

        /// <summary>
        /// Describes the <see cref="RegionModel"/>.
        /// </summary>
        /// <returns>A <see cref="string"/> that represents the current <see cref="RegionModel"/>.</returns>
        public override string ToString()
            => $"Region {Name}: {ExitCount()} exits";
        #endregion
    }
}
