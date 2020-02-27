using System;
using System.Collections.Generic;
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Parquets;

namespace ParquetClassLibrary.Maps
{
    /// <summary>
    /// A pattern and metadata to generate a playable region.
    /// </summary>
    /// <remarks>
    /// <see cref="MapRegion"/>s are stored as <see cref="MapRegionSketch"/>es, for example in an editor tool,
    /// before being fleshed, for example on load in-game.
    /// </remarks>
    public sealed class MapRegionSketch : MapModel, IMapRegionEdit
    {
        #region Class Defaults
        /// <summary>Used to indicate an empty grid.</summary>
        public static readonly MapRegionSketch Empty = new MapRegionSketch(ModelID.None, "Empty Ungenerated Region");

        /// <summary>The region's dimensions in parquets.</summary>
        public override Vector2D DimensionsInParquets { get; } = new Vector2D(Rules.Dimensions.ParquetsPerRegion, Rules.Dimensions.ParquetsPerRegion);

        /// <summary>The set of values that are allowed for <see cref="MapRegionSketch"/> <see cref="ModelID"/>s.</summary>
        public static Range<ModelID> Bounds
            => All.MapRegionIDs;

        /// <summary>Default name for new regions.</summary>
        internal const string DefaultTitle = "New Region";

        /// <summary>Relative elevation to use if none is provided.</summary>
        internal const int DefaultGlobalElevation = 0;

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
        [Index(7)]
        public string BackgroundColor { get; private set; }

        /// <summary>A color to display in any empty areas of the region.</summary>
        [Ignore]
        string IMapRegionEdit.BackgroundColor { get => BackgroundColor; set => BackgroundColor = value; }

        /// <summary>The region's elevation in absolute terms.</summary>
        [Index(8)]
        public Elevation ElevationLocal { get; private set; }

        /// <summary>The region's elevation in absolute terms.</summary>
        [Ignore]
        Elevation IMapRegionEdit.ElevationLocal { get => ElevationLocal; set => ElevationLocal = value; }

        /// <summary>The region's elevation relative to all other regions.</summary>
        [Index(9)]
        public int ElevationGlobal { get; private set; }

        /// <summary>The region's elevation relative to all other regions.</summary>
        [Ignore]
        int IMapRegionEdit.ElevationGlobal { get => ElevationGlobal; set => ElevationGlobal = value; }
        #endregion

        #region Map Contents
        /// <summary>Call <see cref="Generate"/> before accessing parquet statuses.</summary>
        [Ignore]
        [Index(10)]
        public override ParquetStatusGrid ParquetStatuses
            => throw new InvalidOperationException($"Cannot access parquet statuses on ungenerated {nameof(MapRegionSketch)}.");

        /// <summary>Call <see cref="Generate"/> before accessing parquets.</summary>
        [Ignore]
        [Index(11)]
        public override ParquetStackGrid ParquetDefinitions
            => throw new InvalidOperationException($"Cannot access parquets on ungenerated {nameof(MapRegionSketch)}.");

        /// <summary><see cref="ChunkType"/>s that can generate parquets to compose a <see cref="MapRegion"/>.</summary>
        [Index(12)]
        public ChunkTypeGrid Chunks { get; }
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
        /// <param name="inDataVersion">Describes the version of serialized data, to support versioning.</param>
        /// <param name="inRevision">An option revision count.</param>
        /// <param name="inBackgroundColor">A color to show in the new region when no parquet is present.</param>
        /// <param name="inElevationLocal">The absolute elevation of this region.</param>
        /// <param name="inElevationGlobal">The relative elevation of this region expressed as a signed integer.</param>
        /// <param name="inExits">Locations on the map at which a something happens that cannot be determined from parquets alone.</param>
        /// <param name="inChunks">The pattern from which a <see cref="MapRegion"/> may be generated.</param>
        public MapRegionSketch(ModelID inID, string inName = null, string inDescription = null, string inComment = null,
                               string inDataVersion = AssemblyInfo.SupportedMapDataVersion, int inRevision = 0,
                               string inBackgroundColor = DefaultColor, Elevation inElevationLocal = Elevation.LevelGround,
                               int inElevationGlobal = DefaultGlobalElevation, IEnumerable<ExitPoint> inExits = null, ChunkTypeGrid inChunks = null)
            : base(Bounds, inID, string.IsNullOrEmpty(inName) ? DefaultTitle : inName, inDescription, inComment, inDataVersion, inRevision, inExits)
        {
            BackgroundColor = inBackgroundColor;
            ElevationLocal = inElevationLocal;
            ElevationGlobal = inElevationGlobal;
            Chunks = inChunks ?? new ChunkTypeGrid();
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Describes the <see cref="MapRegionSketch"/>.
        /// </summary>
        /// <returns>A <see langword="string"/> that represents the current <see cref="MapRegionSketch"/>.</returns>
        public override string ToString()
            => $"Sketch {Name} ({Chunks.Columns}, {Chunks.Rows}) contains {Chunks.Columns * Chunks.Rows} chunks.";
        #endregion
    }
}
