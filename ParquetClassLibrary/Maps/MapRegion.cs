using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Maps
{
    /// <summary>
    /// A playable region in sandbox-mode.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public sealed class MapRegion : MapParent, IMapRegionEdit
    {
        /// <summary>Used to indicate an empty grid.</summary>
        public static readonly MapRegion Empty = new MapRegion(EntityID.None, "Empty Region");

        #region Class Defaults
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

        #region Whole-Map Characteristics
        /// <summary>What the region is called in-game.</summary>
        public string Title { get => Name; }
        string IMapRegionEdit.Title
        {
            get => Name;
            set
            {
                IEntityEdit editableThis = this;
                editableThis.Name = value;
            }
        }

        /// <summary>A color to display in any empty areas of the region.</summary>
        public PCLColor Background { get; private set; }
        PCLColor IMapRegionEdit.Background { get => Background; set => Background = value; }

        /// <summary>The region's elevation in absolute terms.</summary>
        public Elevation ElevationLocal { get; private set; }
        Elevation IMapRegionEdit.ElevationLocal { get => ElevationLocal; set => ElevationLocal = value; }

        /// <summary>The region's elevation relative to all other regions.</summary>
        public int ElevationGlobal { get; private set; }
        int IMapRegionEdit.ElevationGlobal { get => ElevationGlobal; set => ElevationGlobal = value; }
        #endregion

        #region Map Contents
        /// <summary>The statuses of parquets in the chunk.</summary>
        protected override ParquetStatusGridCollection ParquetStatuses { get; } = new ParquetStatusGridCollection(Rules.Dimensions.ParquetsPerRegion);

        /// <summary>Floors and walkable terrain in the region.</summary>
        protected override ParquetStackGridCollection ParquetDefintion { get; } = new ParquetStackGridCollection(Rules.Dimensions.ParquetsPerRegion);
        #endregion

        #region Initialization
        /// <summary>
        /// Constructs a new instance of the <see cref="MapRegion"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the map.  Cannot be null.</param>
        /// <param name="inTitle">The player-facing name of the new region.</param>
        /// <param name="inDescription">Player-friendly description of the map.</param>
        /// <param name="inComment">Comment of, on, or by the map.</param>
        /// <param name="inBackground">A color to show in the new region when no parquet is present.</param>
        /// <param name="inLocalElevation">The absolute elevation of this region.</param>
        /// <param name="inGlobalElevation">The relative elevation of this region expressed as a signed integer.</param>
        public MapRegion(EntityID inID, string inTitle = null,
                         string inDescription = null, string inComment = null,
                         PCLColor? inBackground = null, Elevation inLocalElevation = Elevation.LevelGround,
                         int inGlobalElevation = DefaultGlobalElevation)
            : base(Bounds, inID, string.IsNullOrEmpty(inTitle) ? DefaultTitle : inTitle, inDescription, inComment)
        {
            Background = inBackground ?? PCLColor.White;
            ElevationLocal = inLocalElevation;
            ElevationGlobal = inGlobalElevation;
        }
        #endregion

        #region Serialization
        /// <summary>
        /// Tries to deserialize a <see cref="MapRegion"/> from the given string.
        /// </summary>
        /// <param name="inSerializedMap">The serialized <see cref="MapRegion"/>.</param>
        /// <param name="outMap">The deserialized <see cref="MapRegion"/>, or null if deserialization was impossible.</param>
        /// <returns><c>true</c>, if deserialization was successful, <c>false</c> otherwise.</returns>
        public static bool TryDeserializeFromString(string inSerializedMap, out MapRegion outMap)
        {
            Precondition.IsNotNullOrEmpty(inSerializedMap, nameof(inSerializedMap));
            var result = false;
            outMap = Empty;

            // Determine what version of region map was serialized.
            try
            {
                var document = JObject.Parse(inSerializedMap);
                var version = document?.Value<string>(nameof(DataVersion));

                // Deserialize only if this class supports the version given.
                if (AssemblyInfo.SupportedMapDataVersion.Equals(version, StringComparison.OrdinalIgnoreCase))
                {
                    outMap = JsonConvert.DeserializeObject<MapRegion>(inSerializedMap);
                    result = true;
                }
            }
            catch (JsonReaderException exception)
            {
                throw new JsonReaderException($"Error reading string while deserializing a MapRegion: {exception}");
            }

            return result;
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
