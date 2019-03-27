using System;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParquetClassLibrary.Sandbox.ID;
using ParquetClassLibrary.Stubs;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Sandbox
{
    /// <summary>
    /// A playable region in sandbox-mode.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class MapRegion : MapParent
    {
        #region Class Defaults
        /// <summary>The region's dimensions in parquets.</summary>
        public override Vector2Int DimensionsInParquets { get; } = new Vector2Int(Assembly.ParquetsPerRegionDimension,
                                                                                  Assembly.ParquetsPerRegionDimension);

        /// <summary>Default name for new regions.</summary>
        public const string DefaultTitle = "New Region";

        /// <summary>Default color for new regions.</summary>
        public static readonly Color DefaultColor = Color.White;
        #endregion

        #region Whole-Map Characteristics
        /// <summary>The region identifier, used when referencing unloaded regions.</summary>
        public readonly Guid RegionID;

        /// <summary>What the region is called in-game.</summary>
        public string Title { get; set; } = DefaultTitle;

        /// <summary>A color to display in any empty areas of the region.</summary>
        public Color Background { get; set; } = DefaultColor;

        /// <summary>The region's elevation in absolute terms.</summary>
        public Elevation ElevationLocal { get; set; } = Elevation.LevelGround;

        /// <summary>The region's elevation relative to all other regions.</summary>
        public int ElevationGlobal { get; set; } = 0;
        #endregion

        #region Map Contents
        /// <summary>Floors and walkable terrain in the region.</summary>
        protected override EnitityID[,] _floorLayer { get; } = new EnitityID[Assembly.ParquetsPerRegionDimension,
                                                                             Assembly.ParquetsPerRegionDimension];

        /// <summary>Walls and obstructing terrain in the region.</summary>
        protected override EnitityID[,] _blockLayer { get; } = new EnitityID[Assembly.ParquetsPerRegionDimension,
                                                                             Assembly.ParquetsPerRegionDimension];

        /// <summary>Furniture and natural items in the region.</summary>
        protected override EnitityID[,] _furnishingLayer { get; } = new EnitityID[Assembly.ParquetsPerRegionDimension,
                                                                                  Assembly.ParquetsPerRegionDimension];

        /// <summary>Collectable materials in the region.</summary>
        protected override EnitityID[,] _collectableLayer { get; } = new EnitityID[Assembly.ParquetsPerRegionDimension,
                                                                                   Assembly.ParquetsPerRegionDimension];
        #endregion

        #region Initialization
        /// <summary>
        /// Constructs a new instance of the <see cref="T:ParquetClassLibrary.Sandbox.MapRegion"/> class.
        /// </summary>
        /// <param name="in_title">The name of the new region.</param>
        /// <param name="in_background">Background color for the new region.</param>
        /// <param name="in_localElevation">The absolute elevation of this region.</param>
        /// <param name="in_globalElevation">The relative elevation of this region expressed as a signed integer.</param>
        /// <param name="in_ID">A RegionID derived from a MapChunkGrid; if null, a new RegionID is generated.</param>
        public MapRegion(string in_title = DefaultTitle, Color? in_background = null,
                         Elevation in_localElevation = Elevation.LevelGround, int in_globalElevation = 0, Guid? in_ID = null)
        {
            Title = in_title ?? DefaultTitle;
            Background = in_background ?? Color.White;
            RegionID = in_ID ?? Guid.NewGuid();
            ElevationLocal = in_localElevation;
            ElevationGlobal = in_globalElevation;
        }

        /// <summary>
        /// Constructs a new instance of the <see cref="T:ParquetClassLibrary.Sandbox.MapRegion"/> class.
        /// </summary>
        /// <param name="in_generateID">For unit testing, if set to <c>false</c> the RegionID is set to a default value.</param>
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
        /// Tries to deserialize a <see cref="T:ParquetClassLibrary.Sandbox.MapRegion"/> from the given string.
        /// </summary>
        /// <param name="in_serializedMap">The serialized <see cref="T:ParquetClassLibrary.Sandbox.MapRegion"/>.</param>
        /// <param name="out_map">The deserialized <see cref="T:ParquetClassLibrary.Sandbox.MapRegion"/>, or null if deserialization was impossible.</param>
        /// <returns><c>true</c>, if deserialization was successful, <c>false</c> otherwise.</returns>
        public static bool TryDeserializeFromString(string in_serializedMap,
                                                    out MapRegion out_map)
        {
            var result = false;
            out_map = null;

            if (string.IsNullOrEmpty(in_serializedMap))
            {
                Error.Handle("Error deserializing a MapRegion.");
            }
            else
            {
                // Determine what version of region map was serialized.
                try
                {
                    var document = JObject.Parse(in_serializedMap);
                    var version = document?.Value<string>(nameof(DataVersion));

                    // Deserialize only if this class supports the version given.
                    if (Assembly.SupportedDataVersion.Equals(version, StringComparison.OrdinalIgnoreCase))
                    {
                        out_map = JsonConvert.DeserializeObject<MapRegion>(in_serializedMap);
                        result = true;
                    }
                }
                catch (JsonReaderException exception)
                {
                    Error.Handle($"Error reading string while deserializing a MapRegion: {exception}");
                }
            }

            return result;
        }
        #endregion

        #region Utility Methods
        /// <summary>
        /// Visualizes the region as a string with merged layers.
        /// Intended for Console debugging.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:ParquetClassLibrary.Sandbox.MapRegion"/>.</returns>
        public override string ToString()
        {
            return $"Region {Title} ({DimensionsInParquets.x }, {DimensionsInParquets.y})\n{base.ToString()}";
        }

        /// <summary>
        /// Visualizes the region as a string, listing layers separately.
        /// Intended for Console debugging.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:ParquetClassLibrary.Sandbox.MapRegion"/>.</returns>
        public string ToLayeredString()
        {
            var floorRepresentation = new StringBuilder(DimensionsInParquets.Magnitude);
            var blocksRepresentation = new StringBuilder(DimensionsInParquets.Magnitude);
            var furnishingsRepresentation = new StringBuilder(DimensionsInParquets.Magnitude);
            var collectablesRepresentation = new StringBuilder(DimensionsInParquets.Magnitude);
            #region Compose visual represenation of contents.
            for (var x = 0; x < DimensionsInParquets.x; x++)
            {
                for (var y = 0; y < DimensionsInParquets.y; y++)
                {
                    floorRepresentation.Append(EnitityID.None != _floorLayer[x, y]
                        ? _floorLayer[x, y].ToString()
                        : "~");
                    blocksRepresentation.Append(EnitityID.None != _blockLayer[x, y]
                        ? _blockLayer[x, y].ToString()
                        : " ");
                    furnishingsRepresentation.Append(EnitityID.None != _furnishingLayer[x, y]
                        ? _furnishingLayer[x, y].ToString()
                        : " ");
                    collectablesRepresentation.Append(EnitityID.None != _collectableLayer[x, y]
                        ? _collectableLayer[x, y].ToString()
                        : " ");
                }
                floorRepresentation.AppendLine();
                blocksRepresentation.AppendLine();
                furnishingsRepresentation.AppendLine();
                collectablesRepresentation.AppendLine();
            }
            #endregion

            return $"Region {Title} ({DimensionsInParquets.x}, {DimensionsInParquets.y})\n" +
                $"Floor:\n{floorRepresentation}\n" +
                $"Blocks:\n{blocksRepresentation}\n" +
                $"Furnishings:\n{furnishingsRepresentation}\n" +
                $"Collectables:\n{collectablesRepresentation}";
        }
        #endregion
    }
}
