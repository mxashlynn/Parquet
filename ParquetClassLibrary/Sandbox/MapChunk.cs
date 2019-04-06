using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParquetClassLibrary.Sandbox.Parquets;
using ParquetClassLibrary.Stubs;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Sandbox
{
    /// <summary>
    /// Models details of a playable chunk in sandbox-mode.
    /// Map Chunks are composed of Parquets and Special Points.
    /// <see cref="T:ParquetClassLibrary.Sandbox.MapChunk"/> are
    /// handmade (as opposed to procedurally generated) components
    /// of <see cref="T:ParquetClassLibrary.Sandbox.MapRegion"/>s.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public sealed class MapChunk : MapParent
    {
        #region Class Defaults
        /// <summary>The chunk's dimensions in parquets.</summary>
        public override Vector2Int DimensionsInParquets { get; } = new Vector2Int(AssemblyInfo.ParquetsPerChunkDimension,
                                                                                  AssemblyInfo.ParquetsPerChunkDimension);
        #endregion

        #region Chunk Contents
        /// <summary>The statuses of parquets in the chunk.</summary>
        protected override ParquetStatus[,] _parquetStatus { get; } = new ParquetStatus[AssemblyInfo.ParquetsPerChunkDimension,
                                                                                        AssemblyInfo.ParquetsPerChunkDimension];

        /// <summary>Floors and walkable terrain in the chunk.</summary>
        protected override EntityID[,] _floorLayer { get; } = new EntityID[AssemblyInfo.ParquetsPerChunkDimension,
                                                                           AssemblyInfo.ParquetsPerChunkDimension];

        /// <summary>Walls and obstructing terrain in the chunk.</summary>
        protected override EntityID[,] _blockLayer { get; } = new EntityID[AssemblyInfo.ParquetsPerChunkDimension,
                                                                           AssemblyInfo.ParquetsPerChunkDimension];

        /// <summary>Furniture and natural items in the chunk.</summary>
        protected override EntityID[,] _furnishingLayer { get; } = new EntityID[AssemblyInfo.ParquetsPerChunkDimension,
                                                                                AssemblyInfo.ParquetsPerChunkDimension];

        /// <summary>Collectible materials in the chunk.</summary>
        protected override EntityID[,] _collectibleLayer { get; } = new EntityID[AssemblyInfo.ParquetsPerChunkDimension,
                                                                                 AssemblyInfo.ParquetsPerChunkDimension];
        #endregion

        #region Serialization Methods
        /// <summary>
        /// Tries to deserialize a <see cref="T:ParquetClassLibrary.Sandbox.MapChunk"/> from the given string.
        /// </summary>
        /// <param name="in_serializedMap">The serialized <see cref="T:ParquetClassLibrary.Sandbox.MapChunk"/>.</param>
        /// <param name="out_map">
        /// The deserialized <see cref="T:ParquetClassLibrary.Sandbox.MapChunk"/>, or null if deserialization was impossible.
        /// </param>
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
                // Determine what version of map was serialized.
                try
                {
                    var document = JObject.Parse(in_serializedMap);
                    var version = document?.Value<string>(nameof(DataVersion));

                    // Deserialize only if this class supports the version given.
                    if (AssemblyInfo.SupportedDataVersion.Equals(version, StringComparison.OrdinalIgnoreCase))
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
        /// Describes the chunk as a string containing basic information.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:ParquetClassLibrary.Sandbox.MapChunk"/>.</returns>
        public override string ToString()
        {
            return $"Chunk {base.ToString()}";
        }
        #endregion
    }
}
