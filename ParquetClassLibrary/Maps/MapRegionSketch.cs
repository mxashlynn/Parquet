using System;
using System.Globalization;
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Properties;

namespace ParquetClassLibrary.Maps
{
    /// <summary>
    /// A pattern and metadata to generate a <see cref="MapRegion"/>.
    /// </summary>
    /// <remarks>
    /// Before play begins, <see cref="MapRegion"/>s may be stored as <see cref="MapRegionSketch"/>es, for example in an editor tool.
    ///
    /// MapRegionSketches allow additional flexibility, primarily by way of allowing map subsections to be represented not as actual
    /// collection of parquets, but instead as <see cref="MapChunk"/>s, instructions to procedural generation routines.  These
    /// instructions can be used by the library when the MapRegionSketch is loaded for the first time to generate actual parquets
    /// for the map.  In this way portions of the game world will be different every time the game is played, while still corresponding
    /// to some general layout instructions provided by the game's designers.
    /// 
    /// The <see cref="Stitch"/> method accomplishes this, forming a composite whole from generated parts.
    /// </remarks>
    public sealed class MapRegionSketch : MapModel, IMapRegionEdit
    {
        #region Class Defaults
        /// <summary>Used to indicate a blank sketch.</summary>
        public static readonly MapRegionSketch Empty = new MapRegionSketch(ModelID.None, "Empty Ungenerated Region");

        /// <summary>The length of each <see cref="MapRegionSketch"/> dimension in <see cref="MapChunk"/>s.</summary>
        public const int ChunksPerRegionDimension = 4;

        /// <summary>The grid's dimensions in chunks.</summary>
        public static Vector2D DimensionsInChunks { get; } = new Vector2D(ChunksPerRegionDimension, ChunksPerRegionDimension);

        /// <summary>The region's dimensions in parquets.</summary>
        public override Vector2D DimensionsInParquets { get; } = new Vector2D(MapRegion.ParquetsPerRegionDimension,
                                                                              MapRegion.ParquetsPerRegionDimension);

        /// <summary>The set of values that are allowed for <see cref="MapRegionSketch"/> <see cref="ModelID"/>s.</summary>
        public static Range<ModelID> Bounds
            => All.MapRegionIDs;

        /// <summary>Default name for new regions.</summary>
        internal const string DefaultTitle = "New Region";

        /// <summary>Default color for new regions.</summary>
        internal const string DefaultColor = "#FFFFFFFF";
        #endregion

        #region Characteristics
        #region Whole-Map Characteristics
        /// <summary>What the region is called in-game.</summary>
        [Ignore]
        string IMapRegionEdit.Name
        {
            get => Name;
            set
            {
                IModelEdit editableThis = this;
                editableThis.Name = value;
            }
        }

        /// <summary>A color to display in any empty areas of the region.</summary>
        [Index(5)]
        public string BackgroundColor { get; private set; }

        /// <summary>A color to display in any empty areas of the region.</summary>
        [Ignore]
        string IMapRegionEdit.BackgroundColor { get => BackgroundColor; set => BackgroundColor = value; }
        #endregion

        #region Map Contents
        #region Exit IDs
        /// <summary>The <see cref="ModelID"/> of the region to the north of this one.</summary>
        [Index(6)]
        public ModelID RegionToTheNorth { get; private set; }

        /// <summary>The <see cref="ModelID"/> of the region to the north of this one.</summary>
        [Ignore]
        ModelID IMapRegionEdit.RegionToTheNorth { get => RegionToTheNorth; set => RegionToTheNorth = value; }

        /// <summary>The <see cref="ModelID"/> of the region to the east of this one.</summary>
        [Index(7)]
        public ModelID RegionToTheEast { get; private set; }

        /// <summary>The <see cref="ModelID"/> of the region to the east of this one.</summary>
        [Ignore]
        ModelID IMapRegionEdit.RegionToTheEast { get => RegionToTheEast; set => RegionToTheEast = value; }

        /// <summary>The <see cref="ModelID"/> of the region to the south of this one.</summary>
        [Index(8)]
        public ModelID RegionToTheSouth { get; private set; }

        /// <summary>The <see cref="ModelID"/> of the region to the south of this one.</summary>
        [Ignore]
        ModelID IMapRegionEdit.RegionToTheSouth { get => RegionToTheSouth; set => RegionToTheSouth = value; }

        /// <summary>The <see cref="ModelID"/> of the region to the west of this one.</summary>
        [Index(9)]
        public ModelID RegionToTheWest { get; private set; }

        /// <summary>The <see cref="ModelID"/> of the region to the west of this one.</summary>
        [Ignore]
        ModelID IMapRegionEdit.RegionToTheWest { get => RegionToTheWest; set => RegionToTheWest = value; }

        /// <summary>The <see cref="ModelID"/> of the region above this one.</summary>
        [Index(10)]
        public ModelID RegionAbove { get; private set; }

        /// <summary>The <see cref="ModelID"/> of the region above this one.</summary>
        [Ignore]
        ModelID IMapRegionEdit.RegionAbove { get => RegionAbove; set => RegionAbove = value; }

        /// <summary>The <see cref="ModelID"/> of the <see cref="MapRegion"/> below this one.</summary>
        [Index(11)]
        public ModelID RegionBelow { get; private set; }

        /// <summary>The <see cref="ModelID"/> of the <see cref="MapRegion"/> below this one.</summary>
        [Ignore]
        ModelID IMapRegionEdit.RegionBelow { get => RegionBelow; set => RegionBelow = value; }
        #endregion

        /// <summary>Generate a <see cref="MapRegion"/> before accessing parquet statuses.</summary>
        [Ignore]
        // Index(12)
        public override ParquetStatusGrid ParquetStatuses
            => throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorUngenerated,
                                                                 nameof(ParquetStatuses), nameof(MapRegionSketch)));

        /// <summary>Generate a <see cref="MapRegion"/> before accessing parquets.</summary>
        [Ignore]
        // Index(13)
        public override ParquetStackGrid ParquetDefinitions
            => throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorUngenerated,
                                                                 nameof(ParquetDefinitions), nameof(MapRegionSketch)));

        /// <summary><see cref="ChunkDetail"/>s that can generate parquets to compose a <see cref="MapRegion"/>.</summary>
        [Index(14)]
        public ModelIDGrid Chunks { get; }
        #endregion
        #endregion

        #region Initialization
        /// <summary>
        /// Constructs a new instance of the <see cref="MapRegionSketch"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the map.  Cannot be null.</param>
        /// <param name="inName">The player-facing name of the new region.</param>
        /// <param name="inDescription">Player-friendly description of the map.</param>
        /// <param name="inComment">Comment of, on, or by the map.</param>
        /// <param name="inRevision">An option revision count.</param>
        /// <param name="inBackgroundColor">A color to show in the new region when no parquet is present.</param>
        /// <param name="inRegionToTheNorth">The <see cref="ModelID"/> of the region to the north of this one.</param>
        /// <param name="inRegionToTheEast">The <see cref="ModelID"/> of the region to the east of this one.</param>
        /// <param name="inRegionToTheSouth">The <see cref="ModelID"/> of the region to the south of this one.</param>
        /// <param name="inRegionToTheWest">The <see cref="ModelID"/> of the region to the west of this one.</param>
        /// <param name="inRegionAbove">The <see cref="ModelID"/> of the region above this one.</param>
        /// <param name="inRegionBelow">The <see cref="ModelID"/> of the region below this one.</param>
        /// <param name="inChunks">The pattern from which a <see cref="MapRegion"/> may be generated.</param>
        public MapRegionSketch(ModelID inID, string inName = null, string inDescription = null, string inComment = null,
                               int inRevision = 0, string inBackgroundColor = DefaultColor,
                               ModelID? inRegionToTheNorth = null,
                               ModelID? inRegionToTheEast = null,
                               ModelID? inRegionToTheSouth = null,
                               ModelID? inRegionToTheWest = null,
                               ModelID? inRegionAbove = null,
                               ModelID? inRegionBelow = null,
                               ModelIDGrid inChunks = null)
            : base(Bounds, inID, string.IsNullOrEmpty(inName) ? DefaultTitle : inName, inDescription, inComment, inRevision)
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
            Chunks = inChunks ?? new ModelIDGrid(ChunksPerRegionDimension, ChunksPerRegionDimension);
        }
        #endregion

        /// <summary>
        /// Combines all consituent <see cref="MapChunk"/>s to produce a playable <see cref="MapRegion"/>.
        /// </summary>
        /// <remarks>
        /// Invokes procedural generation routines on any <see cref="MapChunk"/>s that need it.
        /// </remarks>
        public void Stitch()
        {
            // TODO This.
            // TODO One issue here is, how do we (and should we) update the definitions in All so that
            // the newly stitched MapRegion replaces the old MapRegionSketch?
        }

        #region Utilities
        /// <summary>
        /// Describes the <see cref="MapRegionSketch"/>.
        /// </summary>
        /// <returns>A <see cref="string"/> that represents the current <see cref="MapRegionSketch"/>.</returns>
        public override string ToString()
            => $"Sketch {Name} ({Chunks.Columns}, {Chunks.Rows}) contains {Chunks.Count} chunks.";
        #endregion
    }
}
