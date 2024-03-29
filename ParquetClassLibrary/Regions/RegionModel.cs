using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CsvHelper.Configuration.Attributes;
using Parquet.Parquets;
using Parquet.Properties;

namespace Parquet.Regions
{
    /// <summary>
    /// Defines an area within the gameworld, both its metadata and instructions to generate its contents.
    /// </summary>
    /// <remarks>
    /// <see cref="RegionModel"/>s allow map subsections, called <see cref="MapChunk"/>s, to be represented
    /// either as concrete <see cref="ParquetModelPackGrid"/>s or as <see cref="ChunkDetail"/>s --
    /// sets of procedural generation instructions.  These instructions can be used by the library when the
    /// RegionModel is loaded to generate parquet maps.<br />
    /// In this way portions of the game world may vary each run while maintaining a persistent general layout.
    /// </remarks>
    /// <seealso cref="RegionStatus"/>.
    [SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
                     Justification = "By design, subtypes of RegionModel should never themselves use IMutableRegionModel or derived interfaces to access their own members.  IMutableRegionModel is for external types that require read/write access.")]
    public class RegionModel : Model, IMutableRegionModel
    {
        #region Class Defaults
        /// <summary>Indicates an uninitialized region.</summary>
        public static readonly RegionModel Empty = new(ModelID.None, nameof(Empty), "", "");

        /// <summary>The set of values that are allowed for <see cref="RegionModel"/> <see cref="ModelID"/>s.</summary>
        public static Range<ModelID> Bounds
            => All.RegionIDs;

        /// <summary>Default color for new regions.</summary>
        public const string DefaultColor = "#FFFFFFFF";

        /// <summary>The length of each <see cref="RegionModel"/> in <see cref="MapChunk"/>s.</summary>
        public const int ChunksPerRegionDimension = 4;

        /// <summary>Dimensions in chunks of the <see cref="MapChunkGrid"/> stored by this <see cref="RegionModel"/>.</summary>
        public static Point2D DimensionsInChunks { get; } = new Point2D(ChunksPerRegionDimension, ChunksPerRegionDimension);
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
        /// <param name="id">Unique identifier for the <see cref="RegionModel"/>.  Cannot be null.</param>
        /// <param name="name">The player-facing name of the <see cref="RegionModel"/>.</param>
        /// <param name="description">Player-friendly description of the <see cref="RegionModel"/>.</param>
        /// <param name="comment">Comment of, on, or by the <see cref="RegionModel"/>.</param>
        /// <param name="tags">Any additional information about the <see cref="RegionModel"/>.</param>
        /// <param name="backgroundColor">A color to show in the <see cref="RegionModel"/> when no parquets are present at a location.</param>
        /// <param name="regionToTheNorth">The <see cref="ModelID"/> of the <see cref="RegionModel"/> to the north of this one.</param>
        /// <param name="regionToTheEast">The <see cref="ModelID"/> of the <see cref="RegionModel"/> to the east of this one.</param>
        /// <param name="regionToTheSouth">The <see cref="ModelID"/> of the <see cref="RegionModel"/> to the south of this one.</param>
        /// <param name="regionToTheWest">The <see cref="ModelID"/> of the <see cref="RegionModel"/> to the west of this one.</param>
        /// <param name="regionAbove">The <see cref="ModelID"/> of the <see cref="RegionModel"/> above this one.</param>
        /// <param name="regionBelow">The <see cref="ModelID"/> of the <see cref="RegionModel"/> below this one.</param>
        public RegionModel(ModelID id, string name, string description, string comment,
                           IEnumerable<ModelTag> tags = null,
                           string backgroundColor = DefaultColor,
                           ModelID? regionToTheNorth = null,
                           ModelID? regionToTheEast = null,
                           ModelID? regionToTheSouth = null,
                           ModelID? regionToTheWest = null,
                           ModelID? regionAbove = null,
                           ModelID? regionBelow = null)
            : base(Bounds, id, name, description, comment, tags)
        {
            var nonNullRegionToTheNorth = regionToTheNorth ?? ModelID.None;
            var nonNullRegionToTheEast = regionToTheEast ?? ModelID.None;
            var nonNullRegionToTheSouth = regionToTheSouth ?? ModelID.None;
            var nonNullRegionToTheWest = regionToTheWest ?? ModelID.None;
            var nonNullRegionAbove = regionAbove ?? ModelID.None;
            var nonNullRegionBelow = regionBelow ?? ModelID.None;

            Precondition.IsInRange(nonNullRegionToTheNorth, Bounds, nameof(regionToTheNorth));
            Precondition.IsInRange(nonNullRegionToTheEast, Bounds, nameof(regionToTheEast));
            Precondition.IsInRange(nonNullRegionToTheSouth, Bounds, nameof(regionToTheSouth));
            Precondition.IsInRange(nonNullRegionToTheWest, Bounds, nameof(regionToTheWest));
            Precondition.IsInRange(nonNullRegionAbove, Bounds, nameof(regionAbove));
            Precondition.IsInRange(nonNullRegionBelow, Bounds, nameof(regionBelow));

            BackgroundColor = backgroundColor;
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

        /// <summary>Instructions on how to procedurally generate this region.</summary>
        [Ignore]
        MapChunkGrid IMutableRegionModel.MapChunks { get => MapChunks; set => MapChunks = value; }
        #endregion

        #region Exit Analysis
        /// <summary>
        /// Takes a <see cref="RegionModel"/> and returns the <see cref="ModelID" /> of an adjacent RegionModel.
        /// </summary>
        private delegate ModelID IDByDirection(RegionModel region);

        /// <summary>
        /// A database of directions and their opposites, together with the properties needed to inspect both.
        /// </summary>
        private static readonly IReadOnlyCollection<(IDByDirection GetLeavingRegionID,
                                                      string LeavingDirection,
                                                      IDByDirection GetReturningRegionID,
                                                      string ReturningDirection)>
            Directions = new List<(IDByDirection, string, IDByDirection, string)>
            {
                { (region => region.RegionToTheNorth, Resources.DirectionNorth,
                   region => region.RegionToTheSouth, Resources.DirectionSouth) },
                { (region => region.RegionToTheEast, Resources.DirectionEast,
                   region => region.RegionToTheWest, Resources.DirectionWest) },
                { (region => region.RegionToTheSouth, Resources.DirectionSouth,
                   region => region.RegionToTheNorth, Resources.DirectionNorth) },
                { (region => region.RegionToTheWest, Resources.DirectionWest,
                   region => region.RegionToTheEast, Resources.DirectionEast) },
                { (region => region.RegionAbove, Resources.DirectionAbove,
                   region => region.RegionBelow, Resources.DirectionBelow) },
                { (region => region.RegionBelow, Resources.DirectionBelow,
                   region => region.RegionAbove, Resources.DirectionAbove) },
            };

        /// <summary>
        /// Finds adjacent maps from which the given map is not adjacent in the expected direction.
        ///
        /// That is, if the player leaves Region 1 by going North and cannot then return to Region 1 by going south,
        /// that is considered inconsistent and will be reported.
        /// </summary>
        /// <param name="regionID">The <see cref="ModelID"/> of the origination and destination map.</param>
        /// <returns>A report of all exit directions leading to regions whose own exits are inconsistent.</returns>
        [SuppressMessage("Style", "IDE0042:Deconstruct variable declaration",
            Justification = "In this instance it makes the code less readable.")]
        public static ICollection<string> CheckExitConsistency(ModelID regionID)
        {
            var inconsistentExitDirections = new List<string>();

            if (regionID == ModelID.None)
            {
                return inconsistentExitDirections;
            }

            var currentRegion = All.Regions.GetOrNull<RegionModel>(regionID);

            if (currentRegion is null)
            {
                return inconsistentExitDirections;
            }

            foreach (var directionPair in Directions)
            {
                var adjacentRegionID = directionPair.GetLeavingRegionID(currentRegion);
                if (adjacentRegionID == ModelID.None)
                {
                    continue;
                }

                var adjacentRegion = All.Regions.GetOrNull<RegionModel>(adjacentRegionID);
                if (adjacentRegion is null)
                {
                    continue;
                }

                if (directionPair.GetReturningRegionID(adjacentRegion) != regionID)
                {
                    inconsistentExitDirections.Add(
                        $"{adjacentRegion.Name} is {directionPair.LeavingDirection} of {currentRegion.Name} but " +
                        $"{currentRegion.Name} is not {directionPair.ReturningDirection} of {adjacentRegion.Name}.\n");
                }
            }

            return inconsistentExitDirections;
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Determines how many exits lead from this <see cref="RegionModel"/> to other RegionModels.
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
