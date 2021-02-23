using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using CsvHelper.Configuration.Attributes;
using Parquet.Parquets;
using Parquet.Properties;

namespace Parquet.Regions
{
    /// <summary>
    /// A pattern and metadata to generate a <see cref="RegionModel"/>.
    /// </summary>
    /// <remarks>
    /// Before play begins, <see cref="RegionModel"/>s may be stored as <see cref="MapRegionSketch"/>es, for example in an editor tool.
    ///
    /// MapRegionSketches allow additional flexibility, primarily by way of allowing map subsections to be represented not as actual
    /// collection of parquets, but instead as <see cref="MapChunk"/>s, instructions to procedural generation routines.  These
    /// instructions can be used by the library when the MapRegionSketch is loaded for the first time to generate actual parquets
    /// for the map.  In this way portions of the game world will be different every time the game is played, while still corresponding
    /// to some general layout instructions provided by the game's designers.
    /// 
    /// The <see cref="Stitch"/> method accomplishes this, forming a composite whole from generated parts.
    /// </remarks>
    public partial class OLD_MapRegionSketch : RegionModel
    {
        #region Class Defaults
        /// <summary>Used to indicate a blank sketch.</summary>
        public static readonly MapRegionSketch Empty = new MapRegionSketch(ModelID.None, "Empty Ungenerated Region", "", "");

        /// <summary>The length of each <see cref="MapRegionSketch"/> dimension in <see cref="MapChunk"/>s.</summary>
        public const int ChunksPerRegionDimension = 4;

        /// <summary>The grid's dimensions in chunks.</summary>
        public static Vector2D DimensionsInChunks { get; } = new Vector2D(ChunksPerRegionDimension, ChunksPerRegionDimension);

        /// <summary>The region's dimensions in parquets.</summary>
        public override Vector2D DimensionsInParquets { get; } = new Vector2D(RegionModel.ParquetsPerRegionDimension,
                                                                              RegionModel.ParquetsPerRegionDimension);

        /// <summary>The set of values that are allowed for <see cref="MapRegionSketch"/> <see cref="ModelID"/>s.</summary>
        public static Range<ModelID> Bounds
            => All.RegionIDs;

        /// <summary>Default color for new regions.</summary>
        internal const string DefaultColor = "#FFFFFFFF";
        #endregion

        #region Characteristics
        #region Whole-Map Characteristics
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

        /// <summary>The <see cref="ModelID"/> of the <see cref="RegionModel"/> below this one.</summary>
        [Index(11)]
        public ModelID RegionBelow { get; private set; }

        /// <summary><see cref="ChunkDetail"/>s that can generate parquets to compose a <see cref="RegionModel"/>.</summary>
        [Index(12)]
        public ModelIDGrid Chunks { get; }

        /// <summary>Do not use.  Generate a <see cref="RegionModel"/> before accessing parquets.</summary>
        // Index(13)
        [Ignore]
        [Obsolete("Do not use.  Generate a MapRegionModel by calling Stitch, then access the parquet via that instance.")]
        // TODO [MAP EDITOR] [API] Should this be IReadOnlyGrid<ParquetPack> instead?
        public override ParquetModelPackGrid ParquetDefinitions
        {
            get
            {
                Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.ErrorUngenerated,
                                                           nameof(ParquetDefinitions), nameof(MapRegionSketch)));
                return new ParquetModelPackGrid();
            }
        }
        #endregion
        #endregion

        #region Initialization
        /// <summary>
        /// Constructs a new instance of the <see cref="MapRegionSketch"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="MapRegionSketch"/>.  Cannot be null.</param>
        /// <param name="inName">The player-facing name of the <see cref="MapRegionSketch"/>.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="MapRegionSketch"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="MapRegionSketch"/>.</param>
        /// <param name="inTags">Any additional information about the <see cref="MapRegionSketch"/>.</param>
        /// <param name="inBackgroundColor">A color to show in the <see cref="MapRegionSketch"/> when no parquets are present at a location.</param>
        /// <param name="inRegionToTheNorth">The <see cref="ModelID"/> of the <see cref="MapRegionSketch"/> to the north of this one.</param>
        /// <param name="inRegionToTheEast">The <see cref="ModelID"/> of the <see cref="MapRegionSketch"/> to the east of this one.</param>
        /// <param name="inRegionToTheSouth">The <see cref="ModelID"/> of the <see cref="MapRegionSketch"/> to the south of this one.</param>
        /// <param name="inRegionToTheWest">The <see cref="ModelID"/> of the <see cref="MapRegionSketch"/> to the west of this one.</param>
        /// <param name="inRegionAbove">The <see cref="ModelID"/> of the <see cref="MapRegionSketch"/> above this one.</param>
        /// <param name="inRegionBelow">The <see cref="ModelID"/> of the <see cref="MapRegionSketch"/> below this one.</param>
        /// <param name="inChunks">The patterns of which this <see cref="MapRegionSketch"/> consists, from which a <see cref="RegionModel"/> may be generated.</param>
        public MapRegionSketch(ModelID inID, string inName, string inDescription, string inComment,
                               IEnumerable<ModelTag> inTags = null,
                               string inBackgroundColor = DefaultColor,
                               ModelID? inRegionToTheNorth = null,
                               ModelID? inRegionToTheEast = null,
                               ModelID? inRegionToTheSouth = null,
                               ModelID? inRegionToTheWest = null,
                               ModelID? inRegionAbove = null,
                               ModelID? inRegionBelow = null,
                               ModelIDGrid inChunks = null)
            : base(Bounds, inID, inName, inDescription, inComment, inTags)
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

        #region Procedural Generation
        /// <summary>
        /// Combines all constituent <see cref="MapChunk"/>s to produce a playable <see cref="RegionModel"/>.
        /// </summary>
        /// <remarks>
        /// Invokes procedural generation routines on any <see cref="MapChunk"/>s that need it.
        /// </remarks>
        /// <returns>The new <see cref="RegionModel"/>.</returns>
        public RegionModel Stitch()
        {
            Debug.Assert(Chunks.Rows == ChunksPerRegionDimension, "Row size mismatch.");
            Debug.Assert(Chunks.Columns == ChunksPerRegionDimension, "Column size mismatch.");

            var parquetDefinitions = new ParquetModelPackGrid(RegionModel.ParquetsPerRegionDimension, RegionModel.ParquetsPerRegionDimension);
            for (var chunkX = 0; chunkX < Chunks.Columns; chunkX++)
            {
                for (var chunkY = 0; chunkY < Chunks.Rows; chunkY++)
                {
                    // Get potentially ungenerated chunk.
                    var currentChunk = All.RegionModels.GetOrNull<MapChunk>(Chunks[chunkY, chunkX]);
                    if (currentChunk is null)
                    {
                        continue;
                    }

                    // Generate chunk if needed.
                    currentChunk = currentChunk.Generate();

                    // Extract definitions and copy them into a larger subregion.
                    var offsetY = chunkY * MapChunk.ParquetsPerChunkDimension;
                    var offsetX = chunkX * MapChunk.ParquetsPerChunkDimension;
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
            var newRegion = new RegionModel(ID, Name, Description, Comment, null, BackgroundColor,
                                            RegionToTheNorth, RegionToTheEast, RegionToTheSouth, RegionToTheWest,
                                            RegionAbove, RegionBelow, null, parquetDefinitions);

            // TODO [MAP EDITOR] Fix this section:
            /*
            // If the current sketch is contained in the game-wide database, replace it with the newly stitched region.
            if (All.Maps.Contains(ID))
            {
                // TODO [MAP EDITOR] This bug surfaces a design flaw in RegionModel -- we need MapModelStatus classes.
                IModelCollectionEdit<RegionModel> allMaps = All.Maps;
                allMaps.Replace(newRegion);
            }
            */

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
