using System.Collections.Generic;
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Parquets;

namespace ParquetClassLibrary.Maps
{
    /// <summary>
    /// A playable region in sandbox.
    /// </summary>
    public sealed class MapRegion : MapModel, IMapRegionEdit
    {
        #region Class Defaults
        /// <summary>Used to indicate an empty grid.</summary>
        public static readonly MapRegion Empty = new MapRegion(EntityID.None, "Empty Region");

        /// <summary>The region's dimensions in parquets.</summary>
        public override Vector2D DimensionsInParquets { get; } = new Vector2D(Rules.Dimensions.ParquetsPerRegion,
                                                                              Rules.Dimensions.ParquetsPerRegion);

        /// <summary>The set of values that are allowed for <see cref="MapRegion"/> <see cref="EntityID"/>s.</summary>
        public static Range<EntityID> Bounds => All.MapRegionIDs;

        /// <summary>Default name for new regions.</summary>
        internal const string DefaultName = "New Region";

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
                IEntityModelEdit editableThis = this;
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
        /// <summary>The statuses of parquets in the chunk.</summary>
        [Index(10)]
        public override ParquetStatusGrid ParquetStatuses { get; }

        /// <summary>
        /// Parquets that make up the region.  If changing or replacing one of these,
        /// remember to update the corresponding element in <see cref="MapRegion.ParquetStatuses"/>!
        /// </summary>
        [Index(11)]
        public override ParquetStackGrid ParquetDefinitions { get; }
        #endregion
        #endregion

        #region Initialization
        /// <summary>
        /// Constructs a new instance of the <see cref="MapRegion"/> class.
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
        /// <param name="inStatuses">The statuses of the collected parquets.</param>
        /// <param name="inDefinitions">The definitions of the collected parquets.</param>
        public MapRegion(EntityID inID, string inName = null, string inDescription = null, string inComment = null,
                         string inDataVersion = AssemblyInfo.SupportedMapDataVersion, int inRevision = 0, string inBackgroundColor = DefaultColor,
                         Elevation inElevationLocal = Elevation.LevelGround, int inElevationGlobal = DefaultGlobalElevation,
                         IEnumerable<ExitPoint> inExits = null, ParquetStatusGrid inStatuses = null, ParquetStackGrid inDefinitions = null)

            : base(Bounds, inID, string.IsNullOrEmpty(inName) ? DefaultName : inName, inDescription, inComment, inDataVersion, inRevision, inExits)
        {
            BackgroundColor = inBackgroundColor;
            ElevationLocal = inElevationLocal;
            ElevationGlobal = inElevationGlobal;
            ParquetStatuses = inStatuses ?? new ParquetStatusGrid(Rules.Dimensions.ParquetsPerRegion, Rules.Dimensions.ParquetsPerRegion);
            ParquetDefinitions = inDefinitions ?? new ParquetStackGrid(Rules.Dimensions.ParquetsPerRegion, Rules.Dimensions.ParquetsPerRegion);
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Describes the <see cref="MapRegion"/>.
        /// </summary>
        /// <returns>A <see langword="string"/> that represents the current <see cref="MapRegion"/>.</returns>
        public override string ToString()
            => $"Region {Name} {base.ToString()}";
        #endregion
    }
}
