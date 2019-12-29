using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Parquets;
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
        public static readonly MapRegion Empty = new MapRegion(false);

        #region Class Defaults
        /// <summary>The region's dimensions in parquets.</summary>
        public override Vector2D DimensionsInParquets { get; } = new Vector2D(Rules.Dimensions.ParquetsPerRegion,
                                                                                  Rules.Dimensions.ParquetsPerRegion);

        /// <summary>Default name for new regions.</summary>
        internal const string DefaultTitle = "New Region";

        /// <summary>Relative elevation to use if none is provided.</summary>
        internal const int DefaultGlobalElevation = 0;

        /// <summary>Default color for new regions.</summary>
        internal static readonly PCLColor DefaultColor = PCLColor.White;
        #endregion

        #region Whole-Map Characteristics
        /// <summary>The region identifier, used when referencing unloaded regions.</summary>
        public Guid RegionID { get; }

        /// <summary>What the region is called in-game.</summary>
        public string Title { get; private set; }
        string IMapRegionEdit.Title { get => Title; set => Title = value; }

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
        protected override ParquetStatus2DCollection ParquetStatuses { get; } = new ParquetStatus2DCollection(Rules.Dimensions.ParquetsPerRegion);

        /// <summary>Floors and walkable terrain in the region.</summary>
        protected override ParquetStack2DCollection ParquetDefintion { get; } = new ParquetStack2DCollection(Rules.Dimensions.ParquetsPerRegion);
        #endregion

        #region Initialization
        /// <summary>
        /// Constructs a new instance of the <see cref="MapRegion"/> class.
        /// </summary>
        /// <param name="inTitle">The player-facing name of the new region.</param>
        /// <param name="inBackground">A color to show in the new region when no parquet is present.</param>
        /// <param name="inLocalElevation">The absolute elevation of this region.</param>
        /// <param name="inGlobalElevation">The relative elevation of this region expressed as a signed integer.</param>
        /// <param name="inID">An identifier derived from a <see cref="MapChunkGrid"/>; if null, a new <see cref="RegionID"/> is generated.</param>
        public MapRegion(string inTitle = null, PCLColor? inBackground = null,
                         Elevation inLocalElevation = Elevation.LevelGround,
                         int inGlobalElevation = DefaultGlobalElevation, Guid? inID = null)
        {
            Title = string.IsNullOrEmpty(inTitle)
                ? DefaultTitle
                : inTitle;
            Background = inBackground ?? PCLColor.White;
            RegionID = inID ?? Guid.NewGuid();
            ElevationLocal = inLocalElevation;
            ElevationGlobal = inGlobalElevation;
        }

        /// <summary>
        /// Constructs a new instance of the <see cref="MapRegion"/> class.
        /// </summary>
        /// <param name="inGenerateID">For unit testing, if set to <c>false</c> the <see cref="RegionID"/> is set to a default value.</param>
        public MapRegion(bool inGenerateID)
        {
            Title = DefaultTitle;
            Background = PCLColor.White;
            ElevationLocal = Elevation.LevelGround;
            ElevationGlobal = 0;

            // Overwrite default behavior for tests.
            RegionID = inGenerateID
                ? Guid.NewGuid()
                : Guid.Empty;
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
