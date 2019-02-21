using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParquetClassLibrary.Sandbox.SpecialPoints;
using ParquetClassLibrary.Sandbox.Parquets;
using ParquetClassLibrary.Stubs;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Sandbox
{
    /// <summary>
    /// A pattern for generating a playable region in sandbox-mode.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class MapChunkGrid
    {
        #region Class Defaults
        /// <summary>The region's dimensions in chunks.</summary>
        public static readonly Vector2Int DimensionsInChunks = new Vector2Int(Assembly.ChunksPerRegionDimension, Assembly.ChunksPerRegionDimension);

        /// <summary>Default name for new regions.</summary>
        public const string DefaultTitle = "New Region";
        #endregion

        #region Whole-Region Characteristics
        /// <summary>
        /// Describes the version of serialized data.
        /// Allows selecting data files that can be successfully deserialized.
        /// </summary>
        public readonly string DataVersion = Assembly.SupportedDataVersion;

        /// <summary>The region identifier, used when referencing unloaded regions.</summary>
        public readonly Guid RegionID;

        /// <summary>What the region is called in-game.</summary>
        public string Title { get; set; } = DefaultTitle;

        /// <summary>A color to display in any empty areas of the region.</summary>
        public Color Background { get; set; } = Color.White;

        /// <summary>The region's relative global elevation.</summary>
        public int GlobalElevation { get; private set; } = 0;

        /// <summary>Tracks how many times the data structure has been serialized.</summary>
        public int Revision { get; private set; } = 0;
        #endregion

        #region Region Contents
        /// <summary>The chunks of which the region consists.</summary>
        private readonly MapChunk[,] _chunks = new MapChunk[DimensionsInChunks.x, DimensionsInChunks.y];
        #endregion

        #region Initialization
        /*
        /// <summary>
        /// Constructs a new instance of the <see cref="T:ParquetClassLibrary.Sandbox.MapRegion"/> class.
        /// </summary>
        /// <param name="in_title">The name of the new region.</param>
        /// <param name="in_background">Background color for the new region.</param>
        /// <param name="in_generateID">For unit testing, if set to <c>false</c> the RegionID is set to a default value.</param>
        public MapChunkGrid(string in_title = DefaultTitle, Color? in_background = null, bool in_generateID = true)
        {
            Title = in_title ?? DefaultTitle;
            Background = in_background ?? Color.White;

            // Overwrite default behavior for tests.
            RegionID = in_generateID
                ? Guid.NewGuid()
                : Guid.Empty;
        }
        */
        #endregion

        #region Parquets Replacement Methods
        /// <summary>
        /// Attempts to update the floor parquet at the given position.
        /// </summary>
        /// <param name="in_floor">The new floor to set.</param>
        /// <param name="in_position">The position to set.</param>
        /// <returns><c>true</c>, if the floor was set, <c>false</c> otherwise.</returns>
        public bool TrySetChunk(Floor in_floor, Vector2Int in_position)
        {
            return false;
        }

        /// <summary>
        /// Attempts to remove the floor parquet at the given position.
        /// </summary>
        /// <param name="in_position">The position to clear.</param>
        /// <returns><c>true</c>, if the floor was removed, <c>false</c> otherwise.</returns>
        public bool TryRemoveChunk(Vector2Int in_position)
        {
            return false;
        }
        #endregion

        #region State Query Methods
        /// <summary>
        /// Gets any floor parquet at the position.
        /// </summary>
        /// <param name="in_position">The position whose floor is sought.</param>
        /// <returns>The floor at the given position, or <c>null</c> if there is none.</returns>
        public bool GetChunkAtPosition(Vector2Int in_position)
        {
            return false;
        }
        #endregion

        #region Serialization Methods
        /// <summary>
        /// Serializes to the current MapRegion to a string,
        /// incrementing the revision number in the process.
        /// </summary>
        /// <returns>The serialized MapRegion.</returns>
        public string SerializeToString()
        {
            Revision++;
            return JsonConvert.SerializeObject(this, Formatting.None);
        }

        /// <summary>
        /// Tries to deserialize a MapRegion from the given string.
        /// </summary>
        /// <param name="in_serializedMapRegion">The serialized region map.</param>
        /// <param name="out_mapRegion">The deserialized region map, or null if deserialization was impossible.</param>
        /// <returns><c>true</c>, if deserialize was posibile, <c>false</c> otherwise.</returns>
        public static bool TryDeserializeFromString(string in_serializedMapRegion,
                                                    out MapRegion out_mapRegion)
        {
            var result = false;
            out_mapRegion = null;

            if (string.IsNullOrEmpty(in_serializedMapRegion))
            {
                Error.Handle("Tried to deserialize a null string as a MapRegion.");
            }
            else
            {
                // Determine what version of region map was serialized.
                try
                {
                    var document = JObject.Parse(in_serializedMapRegion);
                    var version = document?.Value<string>(nameof(DataVersion));

                    // Deserialize only if this class supports the version given.
                    if (Assembly.SupportedDataVersion.Equals(version, StringComparison.OrdinalIgnoreCase))
                    {
                        out_mapRegion = JsonConvert.DeserializeObject<MapRegion>(in_serializedMapRegion);
                        result = true;
                    }
                }
                catch (JsonReaderException exception)
                {
                    Error.Handle("Error reading string while deserializing a MapRegion: " + exception);
                }
            }

            return result;
        }
        #endregion

        #region Utility Methods
        /// <summary>
        /// Determines if the given position corresponds to a point in the region.
        /// </summary>
        /// <param name="in_position">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public bool IsValidPosition(Vector2Int in_position)
        {
            return in_position.x > -1
                && in_position.y > -1
                && in_position.x < DimensionsInChunks.x
                && in_position.y < DimensionsInChunks.y;
        }

        /// <summary>
        /// Visualizes the region as a string with merged layers.
        /// Intended for Console debugging.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:ParquetClassLibrary.Sandbox.MapRegion"/>.</returns>
        public override string ToString()
        {
            var representation = new StringBuilder(DimensionsInChunks.Magnitude);
            #region Compose visual represenation of contents.
            for (var x = 0; x < DimensionsInChunks.x; x++)
            {
                for (var y = 0; y < DimensionsInChunks.y; y++)
                {
                    representation.Append(
                        _chunks[x, y]?.ToString()
                        ?? "@");
                }
                representation.AppendLine();
            }
            #endregion

            return "Chunk Grid:\n" + representation;
        }
        #endregion
    }
}
