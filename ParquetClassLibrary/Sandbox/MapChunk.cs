using System;
using Newtonsoft.Json;
using ParquetClassLibrary.Sandbox.ID;
using ParquetClassLibrary.Stubs;
using ParquetClassLibrary.Utilities;
using Newtonsoft.Json.Linq;

namespace ParquetClassLibrary.Sandbox
{
    /// <summary>
    /// Models details of a playable chunk in sandbox-mode.
    /// Map Chunks are composed of Parquets and Special Points.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class MapChunk : MapParent
    {
        #region Class Defaults
        /// <summary>The chunk's dimensions in parquets.</summary>
        public override Vector2Int DimensionsInParquets { get; } = new Vector2Int(Assembly.ParquetsPerChunkDimension,
                                                                                  Assembly.ParquetsPerChunkDimension);
        #endregion

        #region Chunk Contents
        /// <summary>Floors and walkable terrain in the region.</summary>
        protected override EntityID[,] _floorLayer { get; } = new EntityID[Assembly.ParquetsPerChunkDimension,
                                                                             Assembly.ParquetsPerChunkDimension];

        /// <summary>Walls and obstructing terrain in the region.</summary>
        protected override EntityID[,] _blockLayer { get; } = new EntityID[Assembly.ParquetsPerChunkDimension,
                                                                             Assembly.ParquetsPerChunkDimension];

        /// <summary>Furniture and natural items in the region.</summary>
        protected override EntityID[,] _furnishingLayer { get; } = new EntityID[Assembly.ParquetsPerChunkDimension,
                                                                                  Assembly.ParquetsPerChunkDimension];

        /// <summary>Collectable materials in the region.</summary>
        protected override EntityID[,] _collectableLayer { get; } = new EntityID[Assembly.ParquetsPerChunkDimension,
                                                                                   Assembly.ParquetsPerChunkDimension];
        #endregion

        #region Serialization Methods
        /// <summary>
        /// Tries to deserialize a <see cref="T:ParquetClassLibrary.Sandbox.MapChunk"/> from the given string.
        /// </summary>
        /// <param name="in_serializedMap">The serialized <see cref="T:ParquetClassLibrary.Sandbox.MapChunk"/>.</param>
        /// <param name="out_map">The deserialized <see cref="T:ParquetClassLibrary.Sandbox.MapChunk"/>, or null if deserialization was impossible.</param>
        /// <returns><c>true</c>, if deserialize was posibile, <c>false</c> otherwise.</returns>
        public static bool TryDeserializeFromString(string in_serializedMap,
                                                    out MapChunk out_map)
        {
            var result = false;
            out_map = null;

            if (string.IsNullOrEmpty(in_serializedMap))
            {
                Error.Handle("Error deserializing a MapChunk.");
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
                        out_map = JsonConvert.DeserializeObject<MapChunk>(in_serializedMap);
                        result = true;
                    }
                }
                catch (JsonReaderException exception)
                {
                    Error.Handle($"Error reading string while deserializing a MapChunk: {exception}");
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
            return $"Chunk: \n{base.ToString()}";
        }
        #endregion
    }
}
