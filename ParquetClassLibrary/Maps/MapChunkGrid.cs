using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Maps
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
        /// <summary>The types of chunks which make up the grid.</summary>
        private readonly ChunkType[,] chunkTypes = new ChunkType[DimensionsInChunks.Y, DimensionsInChunks.X];
        #endregion

        #region Initialization
        /// <summary>
        /// Constructs a new instance of the <see cref="MapChunk"/> class.
        /// </summary>
        /// <param name="inTitle">The name of the new region.</param>
        /// <param name="inBackground">Background color for the new region.</param>
        /// <param name="inGlobalElevation">The relative elevation of this region expressed as a signed integer.</param>
        /// <param name="inID">A pre-existing RegionID; if null, a new RegionID is generated.</param>
        public MapChunkGrid(string inTitle = null, PCLColor? inBackground = null,
                            int inGlobalElevation = MapRegion.DefaultGlobalElevation, Guid? inID = null)
        {
            Title = string.IsNullOrEmpty(inTitle)
                ? MapRegion.DefaultTitle
                : inTitle;
            Background = inBackground ?? MapRegion.DefaultColor;
            GlobalElevation = inGlobalElevation;
            RegionID = inID ?? Guid.NewGuid();
        }

        /// <summary>
        /// Constructs a new instance of the <see cref="MapChunk"/> class.
        /// </summary>
        /// <param name="inGenerateID">For unit testing, if set to <c>false</c> the <see cref="RegionID"/> is set to a default value.</param>
        public MapChunkGrid(bool inGenerateID)
        {
            Title = MapRegion.DefaultTitle;
            Background = MapRegion.DefaultColor;
            GlobalElevation = 0;

            // Overwrite default behavior for tests.
            RegionID = inGenerateID
                ? Guid.NewGuid()
                : Guid.Empty;
        }
        #endregion

        #region Chunk Access
        /// <summary>
        /// Places the given chunk type at the given position and orients it.
        /// </summary>
        /// <param name="inChunkType">The new chunk type to set.</param>
        /// <param name="inPosition">The position at which to set it.</param>
        public void SetChunk(ChunkType inChunkType, Vector2D inPosition)
        {
            if (IsValidPosition(inPosition))
            {
                chunkTypes[inPosition.Y, inPosition.X] = inChunkType;
            }
        }

        /// <summary>
        /// Gets chunk type and orientation at the given position.
        /// </summary>
        /// <param name="inPosition">The position whose chunk data is sought.</param>
        /// <returns>
        /// If <paramref name="inPosition"/> is valid, the chunk type and orientation; null otherwise.
        /// </returns>
        public ChunkType GetChunk(Vector2D inPosition)
            => IsValidPosition(inPosition)
                ? chunkTypes[inPosition.Y, inPosition.X]
                : ChunkType.Empty;
        #endregion

        #region Serialization
        /// <summary>
        /// Serializes to the current <see cref="MapChunkGrid"/> to a string.
        /// </summary>
        /// <returns>The serialized MapRegion.</returns>
        public string SerializeToString()
            => JsonConvert.SerializeObject(this, Formatting.None);

        /// <summary>
        /// Tries to deserialize a <see cref="MapChunkGrid"/> from the given string.
        /// </summary>
        /// <param name="inSerializedMapChunkGrid">The serialized region map.</param>
        /// <param name="outMapChunkGrid">The deserialized region map, or null if deserialization was impossible.</param>
        /// <returns><c>true</c>, if deserialize was posibile, <c>false</c> otherwise.</returns>
        public static bool TryDeserializeFromString(string inSerializedMapChunkGrid,
                                                    out MapChunkGrid outMapChunkGrid)
        {
            Precondition.IsNotNullOrEmpty(inSerializedMapChunkGrid, nameof(inSerializedMapChunkGrid));
            var result = false;
            outMapChunkGrid = Empty;

            // Determine what version of region map was serialized.
            try
            {
                var document = JObject.Parse(inSerializedMapChunkGrid);
                var version = document?.Value<string>(nameof(DataVersion));

                // Deserialize only if this class supports the version given.
                if (AssemblyInfo.SupportedMapDataVersion.Equals(version, StringComparison.OrdinalIgnoreCase))
                {
                    outMapChunkGrid = JsonConvert.DeserializeObject<MapChunkGrid>(inSerializedMapChunkGrid);
                    result = true;
                }
            }
            catch (JsonReaderException exception)
            {
                throw new JsonReaderException($"Error reading string while deserializing a MapChunkGrid: {exception}");
            }

            return result;
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Determines if the given position corresponds to a point on the grid.
        /// </summary>
        /// <param name="inPosition">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public bool IsValidPosition(Vector2D inPosition)
            => chunkTypes.IsValidPosition(inPosition);

        /// <summary>
        /// Describes the <see cref="MapChunkGrid"/>'s basic information.
        /// </summary>
        /// <returns>A <see langword="string"/> that represents the current <see cref="MapChunkGrid"/>.</returns>
        public override string ToString()
            => $"Chunk Grid {Title} is ({Background}) at {GlobalElevation}.";
        #endregion
    }
}
