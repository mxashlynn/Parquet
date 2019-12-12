using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Map
{
    /// <summary>
    /// A playable region in sandbox-mode.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public sealed class MapRegion : MapParent
    {
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

        // TODO The setters bellow are here to facilitate region editing, but they shouldn't be changed in-game.
        // Is there a better way to handle this?

        /// <summary>What the region is called in-game.</summary>
        public string Title { get; set; }

        /// <summary>A color to display in any empty areas of the region.</summary>
        public PCLColor Background { get; set; }

        /// <summary>The region's elevation in absolute terms.</summary>
        public Elevation ElevationLocal { get; set; }

        /// <summary>The region's elevation relative to all other regions.</summary>
        public int ElevationGlobal { get; set; }
        #endregion

        #region Map Contents
        /// <summary>The statuses of parquets in the chunk.</summary>
        protected override ParquetStatus[,] ParquetStatus { get; } =
            new ParquetStatus[Rules.Dimensions.ParquetsPerRegion, Rules.Dimensions.ParquetsPerRegion];

        /// <summary>Floors and walkable terrain in the region.</summary>
        protected override ParquetStack[,] ParquetDefintion { get; } =
            new ParquetStack[Rules.Dimensions.ParquetsPerRegion, Rules.Dimensions.ParquetsPerRegion];
        #endregion

        #region Initialization
        /// <summary>
        /// Constructs a new instance of the <see cref="MapRegion"/> class.
        /// </summary>
        /// <param name="in_title">The player-facing name of the new region.</param>
        /// <param name="in_background">A color to show in the new region when no parquet is present.</param>
        /// <param name="in_localElevation">The absolute elevation of this region.</param>
        /// <param name="in_globalElevation">The relative elevation of this region expressed as a signed integer.</param>
        /// <param name="in_id">An identifier derived from a <see cref="MapChunkGrid"/>; if null, a new <see cref="RegionID"/> is generated.</param>
        public MapRegion(string in_title = null, PCLColor? in_background = null,
                         Elevation in_localElevation = Elevation.LevelGround,
                         int in_globalElevation = DefaultGlobalElevation, Guid? in_id = null)
        {
            Title = string.IsNullOrEmpty(in_title)
                ? DefaultTitle
                : in_title;
            Background = in_background ?? PCLColor.White;
            RegionID = in_id ?? Guid.NewGuid();
            ElevationLocal = in_localElevation;
            ElevationGlobal = in_globalElevation;
        }

        /// <summary>
        /// Constructs a new instance of the <see cref="MapRegion"/> class.
        /// </summary>
        /// <param name="in_generateID">For unit testing, if set to <c>false</c> the <see cref="RegionID"/> is set to a default value.</param>
        public MapRegion(bool in_generateID)
        {
            // Overwrite default behavior for tests.
            RegionID = in_generateID
                ? Guid.NewGuid()
                : Guid.Empty;
        }
        #endregion

        #region Serialization Methods
        /// <summary>
        /// Tries to deserialize a <see cref="MapRegion"/> from the given string.
        /// </summary>
        /// <param name="in_serializedMap">The serialized <see cref="MapRegion"/>.</param>
        /// <param name="out_map">The deserialized <see cref="MapRegion"/>, or null if deserialization was impossible.</param>
        /// <returns><c>true</c>, if deserialization was successful, <c>false</c> otherwise.</returns>
        public static bool TryDeserializeFromString(string in_serializedMap, out MapRegion out_map)
        {
            Precondition.IsNotNullOrEmpty(in_serializedMap, nameof(in_serializedMap));
            var result = false;
            out_map = null;

            // Determine what version of region map was serialized.
            try
            {
                var document = JObject.Parse(in_serializedMap);
                var version = document?.Value<string>(nameof(DataVersion));

                // Deserialize only if this class supports the version given.
                if (AssemblyInfo.SupportedMapDataVersion.Equals(version, StringComparison.OrdinalIgnoreCase))
                {
                    out_map = JsonConvert.DeserializeObject<MapRegion>(in_serializedMap);
                    result = true;
                }
            }
            catch (JsonReaderException exception)
            {
                LibraryError.Handle($"Error reading string while deserializing a MapRegion: {exception}");
            }

            return result;
        }
        #endregion

        #region Utility Methods
        /// <summary>
        /// Describes the <see cref="MapRegion"/>.
        /// </summary>
        /// <returns>A <see langword="string"/> that represents the current <see cref="MapRegion"/>.</returns>
        public override string ToString()
            => $"Region {Title} {base.ToString()}";
        #endregion
    }
}
