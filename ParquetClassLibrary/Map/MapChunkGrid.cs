using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Map
{
    /// <summary>
    /// A pattern for generating a playable <see cref="MapRegion"/> in sandbox-mode.
    /// Regions in the editor are stored as <see cref="MapChunkGrid"/>s before being fleshed out on load in-game.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class MapChunkGrid
    {
        /// <summary>Used to indicate an empty grid.</summary>
        public static readonly MapChunkGrid Empty = new MapChunkGrid(false);

        #region Class Defaults
        /// <summary>The grid's dimensions in chunks.</summary>
        public static Vector2D DimensionsInChunks { get; } = new Vector2D(Rules.Dimensions.ChunksPerRegion,
                                                                          Rules.Dimensions.ChunksPerRegion);
        #endregion

        #region Whole-Region Characteristics
        /// <summary>
        /// Describes the version of serialized data.
        /// Allows selecting data files that can be successfully deserialized.
        /// </summary>
        public string DataVersion { get; } = AssemblyInfo.SupportedMapDataVersion;

        /// <summary>The identifier for the region that this grid will generate.</summary>
        public Guid RegionID { get; set; }

        /// <summary>What the region that this grid generates will be called in-game.</summary>
        public string Title { get; set; }

        /// <summary>A color to display in any empty areas of the region that this grid will generate.</summary>
        public PCLColor Background { get; set; }

        /// <summary>The region's elevation relative to all other regions.</summary>
        public int GlobalElevation { get; set; }
        #endregion

        #region Grid Contents
        // TODO These are begging to be collapsed into a single struct, says I.
        // !! Do this at the same time that we revise ChunkType !!
        /// <summary>The type of chunks which make up the grid.</summary>
        private readonly ChunkType[,] _chunkTypes = new ChunkType[DimensionsInChunks.Y, DimensionsInChunks.X];

        /// <summary>The orientation of the chunks which make up the grid.</summary>
        private readonly ChunkOrientation[,] _chunkOrientations = new ChunkOrientation[DimensionsInChunks.Y, DimensionsInChunks.X];
        #endregion

        #region Initialization
        /// <summary>
        /// Constructs a new instance of the <see cref="MapChunk"/> class.
        /// </summary>
        /// <param name="in_title">The name of the new region.</param>
        /// <param name="in_background">Background color for the new region.</param>
        /// <param name="in_globalElevation">The relative elevation of this region expressed as a signed integer.</param>
        /// <param name="in_id">A pre-existing RegionID; if null, a new RegionID is generated.</param>
        public MapChunkGrid(string in_title = null, PCLColor? in_background = null,
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
        /// Constructs a new instance of the <see cref="MapChunk"/> class.
        /// </summary>
        /// <param name="in_generateID">For unit testing, if set to <c>false</c> the <see cref="RegionID"/> is set to a default value.</param>
        public MapChunkGrid(bool in_generateID)
        {
            Title = MapRegion.DefaultTitle;
            Background = MapRegion.DefaultColor;
            GlobalElevation = 0;

            // Overwrite default behavior for tests.
            RegionID = in_generateID
                ? Guid.NewGuid()
                : Guid.Empty;
        }
        #endregion

        #region Chunk Access Methods
        /// <summary>
        /// Places the given chunk type at the given position and orients it.
        /// </summary>
        /// <param name="in_type">The new chunk type to set.</param>
        /// <param name="in_orientation">The orientation to set.</param>
        /// <param name="in_position">The position at which to set it.</param>
        /// <returns><c>true</c> if the position was valid, <c>false</c> otherwise.</returns>
        public bool SetChunk(ChunkType in_type, ChunkOrientation in_orientation, Vector2D in_position)
        {
            var valid = IsValidPosition(in_position);

            if (valid)
            {
                _chunkTypes[in_position.Y, in_position.X] = in_type;
                _chunkOrientations[in_position.Y, in_position.X] = in_orientation;
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
        public (ChunkType type, ChunkOrientation orientation) GetChunk(Vector2D in_position)
            => IsValidPosition(in_position)
                ? (_chunkTypes[in_position.Y, in_position.X], _chunkOrientations[in_position.Y, in_position.X])
                : (ChunkType.Empty, ChunkOrientation.None);
        #endregion

        #region Serialization Methods
        /// <summary>
        /// Serializes to the current <see cref="MapChunkGrid"/> to a string.
        /// </summary>
        /// <returns>The serialized MapRegion.</returns>
        public string SerializeToString()
            => JsonConvert.SerializeObject(this, Formatting.None);

        /// <summary>
        /// Tries to deserialize a <see cref="MapChunkGrid"/> from the given string.
        /// </summary>
        /// <param name="in_serializedMapChunkGrid">The serialized region map.</param>
        /// <param name="out_mapChunkGrid">The deserialized region map, or null if deserialization was impossible.</param>
        /// <returns><c>true</c>, if deserialize was posibile, <c>false</c> otherwise.</returns>
        public static bool TryDeserializeFromString(string in_serializedMapChunkGrid,
                                                    out MapChunkGrid out_mapChunkGrid)
        {
            Precondition.IsNotNullOrEmpty(in_serializedMapChunkGrid, nameof(in_serializedMapChunkGrid));
            var result = false;
            out_mapChunkGrid = Empty;

            // Determine what version of region map was serialized.
            try
            {
                var document = JObject.Parse(in_serializedMapChunkGrid);
                var version = document?.Value<string>(nameof(DataVersion));

                // Deserialize only if this class supports the version given.
                if (AssemblyInfo.SupportedMapDataVersion.Equals(version, StringComparison.OrdinalIgnoreCase))
                {
                    out_mapChunkGrid = JsonConvert.DeserializeObject<MapChunkGrid>(in_serializedMapChunkGrid);
                    result = true;
                }
            }
            catch (JsonReaderException exception)
            {
                LibraryError.Handle($"Error reading string while deserializing a MapChunkGrid: {exception}");
            }

            return result;
        }
        #endregion

        #region Utility Methods
        /// <summary>
        /// Determines if the given position corresponds to a point on the grid.
        /// </summary>
        /// <param name="in_position">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public bool IsValidPosition(Vector2D in_position)
            => _chunkTypes.IsValidPosition(in_position);

        /// <summary>
        /// Describes the <see cref="MapChunkGrid"/>'s basic information.
        /// </summary>
        /// <returns>A <see langword="string"/> that represents the current <see cref="MapChunkGrid"/>.</returns>
        public override string ToString()
            => $"Chunk Grid {Title} is ({Background}) at {GlobalElevation}.";
        #endregion
    }
}
