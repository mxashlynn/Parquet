using System;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParquetClassLibrary.Stubs;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Sandbox
{
    /// <summary>
    /// A pattern for generating a playable region in sandbox-mode.
    /// Regions in the editor are stored as Chunk Grids before being fleshed out on load in-game.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class MapChunkGrid
    {
        #region Class Defaults
        /// <summary>The region's dimensions in chunks.</summary>
        public static readonly Vector2Int DimensionsInChunks = new Vector2Int(Assembly.ChunksPerRegionDimension, Assembly.ChunksPerRegionDimension);
        #endregion

        #region Whole-Region Characteristics
        /// <summary>
        /// Describes the version of serialized data.
        /// Allows selecting data files that can be successfully deserialized.
        /// </summary>
        public readonly string DataVersion = Assembly.SupportedDataVersion;

        /// <summary>The region identifier, used when referencing unloaded regions.</summary>
        public readonly Guid RegionID;

        /// <summary>What the region that this grid generates will be called in-game.</summary>
        public string Title { get; set; }

        /// <summary>A color to display in any empty areas of the region that this grid will generate.</summary>
        public Color Background { get; set; }

        /// <summary>The region's elevation relative to all other regions.</summary>
        public int GlobalElevation { get; set; };
        #endregion

        #region Region Contents
        /// <summary>The type of chunks which make up the region.</summary>
        private readonly ChunkType[,] _chunkTypes = new ChunkType[DimensionsInChunks.X, DimensionsInChunks.Y];

        /// <summary>The orientation of the chunks which make up the region.</summary>
        private readonly ChunkOrientation[,] _chunkOrientations = new ChunkOrientation[DimensionsInChunks.X, DimensionsInChunks.Y];
        #endregion

        #region Initialization
        /// <summary>
        /// Constructs a new instance of the <see cref="T:ParquetClassLibrary.Sandbox.MapChunk"/> class.
        /// </summary>
        /// <param name="in_title">The name of the new region.</param>
        /// <param name="in_background">Background color for the new region.</param>
        /// <param name="in_globalElevation">The relative elevation of this region expressed as a signed integer.</param>
        /// <param name="in_id">A pre-existing RegionID; if null, a new RegionID is generated.</param>
        public MapChunkGrid(string in_title = null, Color? in_background = null,
                            int in_globalElevation = MapRegion.DefaultGlobalElevation, Guid? in_id = null)
        {
            Title = string.IsNullOrEmpty(in_title)
                ? MapRegion.DefaultTitle
                : in_title;
            Background = in_background ?? MapRegion.DefaultColor;
            GlobalElevation = in_globalElevation;
            RegionID = in_id ?? Guid.NewGuid();
        }

        /// <summary>
        /// Constructs a new instance of the <see cref="T:ParquetClassLibrary.Sandbox.MapChunk"/> class.
        /// </summary>
        /// <param name="in_generateID">For unit testing, if set to <c>false</c> the RegionID is set to a default value.</param>
        public MapChunkGrid(bool in_generateID)
        {
            // Overwrite default behavior for tests.
            RegionID = in_generateID
                ? Guid.NewGuid()
                : Guid.Empty;
        }
        #endregion

        #region Chunk Methods
        /// <summary>
        /// Places the given chunk type at the given position anbd orients it.
        /// </summary>
        /// <param name="in_type">The new chunk type to set.</param>
        /// <param name="in_orientation">The orientation to set.</param>
        /// <param name="in_position">The position at which to set it.</param>
        /// <returns><c>true</c> if the position was valid, <c>false</c> otherwise.</returns>
        public bool SetChunk(ChunkType in_type, ChunkOrientation in_orientation, Vector2Int in_position)
        {
            var valid = IsValidPosition(in_position);

            if (valid)
            {
                _chunkTypes[in_position.X, in_position.Y] = in_type;
                _chunkOrientations[in_position.X, in_position.Y] = in_orientation;
            }

            return valid;
        }

        /// <summary>
        /// Gets chunk type and orientation at the given position.
        /// </summary>
        /// <param name="in_position">The position whose chunk data is sought.</param>
        /// <returns>
        /// If <paramref name="in_position"/> is valid, the chunk type and orientation; null otherwise.
        /// </returns>
        public (ChunkType type, ChunkOrientation orientation)? GetChunk(Vector2Int in_position)
        {
            return IsValidPosition(in_position)
                ? ((ChunkType type, ChunkOrientation orientation)?)
                (
                    _chunkTypes[in_position.X, in_position.Y],
                    _chunkOrientations[in_position.X, in_position.Y]
                )
                : null;
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
            return JsonConvert.SerializeObject(this, Formatting.None);
        }

        /// <summary>
        /// Tries to deserialize a MapRegion from the given string.
        /// </summary>
        /// <param name="in_serializedMapChunkGrid">The serialized region map.</param>
        /// <param name="out_mapChunkGrid">The deserialized region map, or null if deserialization was impossible.</param>
        /// <returns><c>true</c>, if deserialize was posibile, <c>false</c> otherwise.</returns>
        public static bool TryDeserializeFromString(string in_serializedMapChunkGrid,
                                                    out MapChunkGrid out_mapChunkGrid)
        {
            var result = false;
            out_mapChunkGrid = null;

            if (string.IsNullOrEmpty(in_serializedMapChunkGrid))
            {
                Error.Handle("Tried to deserialize a null string as a MapChunkGrid.");
            }
            else
            {
                // Determine what version of region map was serialized.
                try
                {
                    var document = JObject.Parse(in_serializedMapChunkGrid);
                    var version = document?.Value<string>(nameof(DataVersion));

                    // Deserialize only if this class supports the version given.
                    if (Assembly.SupportedDataVersion.Equals(version, StringComparison.OrdinalIgnoreCase))
                    {
                        out_mapChunkGrid = JsonConvert.DeserializeObject<MapChunkGrid>(in_serializedMapChunkGrid);
                        result = true;
                    }
                }
                catch (JsonReaderException exception)
                {
                    Error.Handle($"Error reading string while deserializing a MapChunkGrid: {exception}");
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
            return in_position.X > -1
                && in_position.Y > -1
                && in_position.X < DimensionsInChunks.X
                && in_position.Y < DimensionsInChunks.Y;
        }

        /// <summary>
        /// Visualizes the region as an array of chunks.
        /// Intended for Console debugging.
        /// </summary>
        /// <returns>A string containing a 2D grid representing the chunks.</returns>
        public string DumpMap()
        {
            var representation = new StringBuilder(DimensionsInChunks.Magnitude);
            #region Compose visual represenation of contents.
            for (var x = 0; x < DimensionsInChunks.X; x++)
            {
                for (var y = 0; y < DimensionsInChunks.Y; y++)
                {
                    representation.Append(_chunkTypes[x, y].ToString());
                }
                representation.AppendLine();
            }
            #endregion

            return $"Chunk Grid:\n{representation}";
        }

        /// <summary>
        /// Describes the grid's basic information.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current map.</returns>
        public override string ToString()
        {
            return $"Chunk Grid {Title} is ({Background}) at {GlobalElevation}.";
        }
        #endregion
    }
}
