using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.EditorSupport;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Properties;

namespace ParquetClassLibrary.Maps
{
    /// <summary>
    /// A pattern and metadata to generate a <see cref="MapRegionModel"/>.
    /// </summary>
    /// <remarks>
    /// Before play begins, <see cref="MapRegionModel"/>s may be stored as <see cref="MapRegionSketch"/>es, for example in an editor tool.
    ///
    /// MapRegionSketches allow additional flexibility, primarily by way of allowing map subsections to be represented not as actual
    /// collection of parquets, but instead as <see cref="MapChunkModel"/>s, instructions to procedural generation routines.  These
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
        public static readonly MapRegionSketch Empty = new MapRegionSketch(ModelID.None, "Empty Ungenerated Region", "", "");

        /// <summary>The length of each <see cref="MapRegionSketch"/> dimension in <see cref="MapChunkModel"/>s.</summary>
        public const int ChunksPerRegionDimension = 4;

        /// <summary>The grid's dimensions in chunks.</summary>
        public static Vector2D DimensionsInChunks { get; } = new Vector2D(ChunksPerRegionDimension, ChunksPerRegionDimension);

        /// <summary>The region's dimensions in parquets.</summary>
        public override Vector2D DimensionsInParquets { get; } = new Vector2D(MapRegionModel.ParquetsPerRegionDimension,
                                                                              MapRegionModel.ParquetsPerRegionDimension);

        /// <summary>The set of values that are allowed for <see cref="MapRegionSketch"/> <see cref="ModelID"/>s.</summary>
        public static Range<ModelID> Bounds
            => All.MapRegionIDs;

        /// <summary>Default color for new regions.</summary>
        internal const string DefaultColor = "#FFFFFFFF";
        #endregion

        #region Characteristics
        #region Whole-Map Characteristics
        /// <summary>What the region is called in-game.</summary>
        [Ignore]
        string IModelEdit.Name
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
        #endregion

        #region Map Contents
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

        /// <summary>The <see cref="ModelID"/> of the <see cref="MapRegionModel"/> below this one.</summary>
        [Index(11)]
        public ModelID RegionBelow { get; private set; }

        /// <summary><see cref="ChunkDetail"/>s that can generate parquets to compose a <see cref="MapRegionModel"/>.</summary>
        [Index(12)]
        public ModelIDGrid Chunks { get; }

        /// <summary>Generate a <see cref="MapRegionModel"/> before accessing parquets.</summary>
        [Ignore]
        // Index(13)
        public override ParquetStackGrid ParquetDefinitions
            => throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorUngenerated,
                                                                 nameof(ParquetDefinitions), nameof(MapRegionSketch)));
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
        /// <param name="inChunks">The pattern from which a <see cref="MapRegionModel"/> may be generated.</param>
        public MapRegionSketch(ModelID inID, string inName, string inDescription, string inComment, int inRevision = 0,
                               string inBackgroundColor = DefaultColor,
                               ModelID? inRegionToTheNorth = null,
                               ModelID? inRegionToTheEast = null,
                               ModelID? inRegionToTheSouth = null,
                               ModelID? inRegionToTheWest = null,
                               ModelID? inRegionAbove = null,
                               ModelID? inRegionBelow = null,
                               ModelIDGrid inChunks = null)
            : base(Bounds, inID, inName, inDescription, inComment, inRevision)
        {
            var nonNullRegionToTheNorth = inRegionToTheNorth ?? ModelID.None;
            var nonNullRegionToTheEast = inRegionToTheEast ?? ModelID.None;
            var nonNullRegionToTheSouth = inRegionToTheSouth ?? ModelID.None;
            var nonNullRegionToTheWest = inRegionToTheWest ?? ModelID.None;
            var nonNullRegionAbove = inRegionAbove ?? ModelID.None;
            var nonNullRegionBelow = inRegionBelow ?? ModelID.None;
            var nonNullChunks = inChunks ?? new ModelIDGrid(ChunksPerRegionDimension, ChunksPerRegionDimension);

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
            Chunks = nonNullChunks;
        }
        #endregion

        #region IMapRegionEdit Implementation
        /// <summary>A color to display in any empty areas of the region.</summary>
        [Ignore]
        string IMapRegionEdit.BackgroundColor { get => BackgroundColor; set => BackgroundColor = value; }

        /// <summary>The <see cref="ModelID"/> of the region to the north of this one.</summary>
        [Ignore]
        ModelID IMapRegionEdit.RegionToTheNorthID { get => RegionToTheNorth; set => RegionToTheNorth = value; }

        /// <summary>The <see cref="ModelID"/> of the region to the east of this one.</summary>
        [Ignore]
        ModelID IMapRegionEdit.RegionToTheEastID { get => RegionToTheEast; set => RegionToTheEast = value; }

        /// <summary>The <see cref="ModelID"/> of the region to the south of this one.</summary>
        [Ignore]
        ModelID IMapRegionEdit.RegionToTheSouthID { get => RegionToTheSouth; set => RegionToTheSouth = value; }

        /// <summary>The <see cref="ModelID"/> of the region to the west of this one.</summary>
        [Ignore]
        ModelID IMapRegionEdit.RegionToTheWestID { get => RegionToTheWest; set => RegionToTheWest = value; }

        /// <summary>The <see cref="ModelID"/> of the region above this one.</summary>
        [Ignore]
        ModelID IMapRegionEdit.RegionAboveID { get => RegionAbove; set => RegionAbove = value; }

        /// <summary>The <see cref="ModelID"/> of the <see cref="MapRegionModel"/> below this one.</summary>
        [Ignore]
        ModelID IMapRegionEdit.RegionBelowID { get => RegionBelow; set => RegionBelow = value; }
        #endregion

        #region Procedural Generation
        /// <summary>
        /// Combines all consituent <see cref="MapChunkModel"/>s to produce a playable <see cref="MapRegionModel"/>.
        /// </summary>
        /// <remarks>
        /// Invokes procedural generation routines on any <see cref="MapChunkModel"/>s that need it.
        /// </remarks>
        /// <returns>The new <see cref="MapRegionModel"/>.</returns>
        public MapRegionModel Stitch()
        {
            Debug.Assert(Chunks.Rows == ChunksPerRegionDimension, "Row size mismatch.");
            Debug.Assert(Chunks.Columns == ChunksPerRegionDimension, "Column size mismatch.");

            var parquetDefinitions = new ParquetStackGrid(MapRegionModel.ParquetsPerRegionDimension, MapRegionModel.ParquetsPerRegionDimension);
            for (var chunkX = 0; chunkX < Chunks.Columns; chunkX++)
            {
                for (var chunkY = 0; chunkY < Chunks.Rows; chunkY++)
                {
                    // Get potentially ungenerated chunk.
                    var currentChunk = All.Maps.Get<MapChunkModel>(Chunks[chunkY, chunkX]);

                    // Generate chunk if needed.
                    currentChunk = currentChunk.Generate();

                    // Extract definitions and copy them into a larger subregion.
                    var offsetY = chunkY * MapChunkModel.ParquetsPerChunkDimension;
                    var offsetX = chunkX * MapChunkModel.ParquetsPerChunkDimension;
                    for (var parquetX = 0; parquetX < ChunksPerRegionDimension; parquetX++)
                    {
                        for (var parquetY = 0; parquetY < ChunksPerRegionDimension; parquetY++)
                        {
                            parquetDefinitions[offsetY + parquetY, offsetX + parquetX] = currentChunk.ParquetDefinitions[parquetY, parquetX];
                        }
                    }
                }
            }

            // Create a new MapRegionModel with the metadata of this sketch plus the new subregion.
            var newRegion = new MapRegionModel(ID, Name, Description, Comment, Revision + 1, BackgroundColor, RegionToTheNorth,
                                          RegionToTheEast, RegionToTheSouth, RegionToTheWest, RegionAbove, RegionBelow,
                                          null, parquetDefinitions);

            // If the current sketch is contained in the game-wide database, replace it with the newly stitched region.
            if (All.Maps.Contains(ID))
            {
                IModelCollectionEdit<MapModel> allMaps = All.Maps;
                allMaps.Replace(newRegion);
            }

            return newRegion;
        }
        #endregion

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
