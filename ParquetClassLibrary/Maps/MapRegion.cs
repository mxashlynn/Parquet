using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Maps
{
    /// <summary>
    /// A playable region in sandbox.
    /// </summary>
    public sealed class MapRegion : MapModel, IMapRegionEdit, ITypeConverter
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
        internal const string DefaultTitle = "New Region";

        /// <summary>Relative elevation to use if none is provided.</summary>
        internal const int DefaultGlobalElevation = 0;

        /// <summary>Default color for new regions.</summary>
        internal static readonly PCLColor DefaultColor = PCLColor.White;
        #endregion

        #region Characteristics
        #region Whole-Map Characteristics
        /// <summary>What the region is called in-game.</summary>
        public string Title { get => Name; }
        string IMapRegionEdit.Title
        {
            get => Name;
            set
            {
                IEntityModelEdit editableThis = this;
                editableThis.Name = value;
            }
        }

        /// <summary>A color to display in any empty areas of the region.</summary>
        public PCLColor Background { get; private set; }

        /// <summary>A color to display in any empty areas of the region.</summary>
        PCLColor IMapRegionEdit.Background { get => Background; set => Background = value; }

        /// <summary>The region's elevation in absolute terms.</summary>
        public Elevation ElevationLocal { get; private set; }

        /// <summary>The region's elevation in absolute terms.</summary>
        Elevation IMapRegionEdit.ElevationLocal { get => ElevationLocal; set => ElevationLocal = value; }

        /// <summary>The region's elevation relative to all other regions.</summary>
        public int ElevationGlobal { get; private set; }

        /// <summary>The region's elevation relative to all other regions.</summary>
        int IMapRegionEdit.ElevationGlobal { get => ElevationGlobal; set => ElevationGlobal = value; }
        #endregion

        #region Map Contents
        /// <summary>The statuses of parquets in the chunk.</summary>
        protected override ParquetStatusGrid ParquetStatuses { get; } =
            new ParquetStatusGrid(Rules.Dimensions.ParquetsPerRegion, Rules.Dimensions.ParquetsPerRegion);

        /// <summary>
        /// Parquets that make up the region.  If changing or replacing one of these,
        /// remember to update the corresponding element in <see cref="MapRegion.ParquetStatuses"/>!
        /// </summary>
        protected override ParquetStackGrid ParquetDefintion { get; } =
            new ParquetStackGrid(Rules.Dimensions.ParquetsPerRegion, Rules.Dimensions.ParquetsPerRegion);
        #endregion
        #endregion

        #region Initialization
        /// <summary>
        /// Constructs a new instance of the <see cref="MapRegion"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the map.  Cannot be null.</param>
        /// <param name="inTitle">The player-facing name of the new region.</param>
        /// <param name="inDescription">Player-friendly description of the map.</param>
        /// <param name="inComment">Comment of, on, or by the map.</param>
        /// <param name="inRevision">An option revision count.</param>
        /// <param name="inBackground">A color to show in the new region when no parquet is present.</param>
        /// <param name="inLocalElevation">The absolute elevation of this region.</param>
        /// <param name="inGlobalElevation">The relative elevation of this region expressed as a signed integer.</param>
        public MapRegion(EntityID inID, string inTitle = null,
                         string inDescription = null, string inComment = null, int inRevision = 0,
                         PCLColor? inBackground = null, Elevation inLocalElevation = Elevation.LevelGround,
                         int inGlobalElevation = DefaultGlobalElevation)
            : base(Bounds, inID, string.IsNullOrEmpty(inTitle) ? DefaultTitle : inTitle, inDescription, inComment, inRevision)
        {
            Background = inBackground ?? PCLColor.White;
            ElevationLocal = inLocalElevation;
            ElevationGlobal = inGlobalElevation;
        }
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static readonly MapRegion ConverterFactory =
            new MapRegion();

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
        {
        }

        /// <summary>
        /// Converts the given <see cref="string"/> to an <see cref="object"/> as deserialization.
        /// </summary>
        /// <param name="inText">The text to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Describes the <see cref="MapRegion"/>.
        /// </summary>
        /// <returns>A <see langword="string"/> that represents the current <see cref="MapRegion"/>.</returns>
        public override string ToString()
            => $"Region {Title} {base.ToString()}";
        #endregion
    }
}
