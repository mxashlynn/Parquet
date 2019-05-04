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
    /// <see cref="MapChunk"/>s are composed of parquets and <see cref="SpecialPoints.SpecialPoint"/>s.
    /// MapChunks are handmade (as opposed to procedurally generated) components of <see cref="MapRegion"/>s.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public sealed class MapChunk : MapParent
    {
        #region Class Defaults
        /// <summary>The chunk's dimensions in parquets.</summary>
        public override Vector2Int DimensionsInParquets { get; } = new Vector2Int(All.Dimensions.ParquetsPerChunk,
                                                                                  All.Dimensions.ParquetsPerChunk);
        #endregion

        #region Chunk Contents
        /// <summary>The statuses of parquets in the chunk.</summary>
        protected override ParquetStatus[,] _parquetStatus { get; } = new ParquetStatus[All.Dimensions.ParquetsPerChunk,
                                                                                        All.Dimensions.ParquetsPerChunk];

        /// <summary>Floors and walkable terrain in the chunk.</summary>
        protected override EntityID[,] _floorLayer { get; } = new EntityID[All.Dimensions.ParquetsPerChunk,
                                                                           All.Dimensions.ParquetsPerChunk];

        /// <summary>Walls and obstructing terrain in the chunk.</summary>
        protected override EntityID[,] _blockLayer { get; } = new EntityID[All.Dimensions.ParquetsPerChunk,
                                                                           All.Dimensions.ParquetsPerChunk];

        /// <summary>Furniture and natural items in the chunk.</summary>
        protected override EntityID[,] _furnishingLayer { get; } = new EntityID[All.Dimensions.ParquetsPerChunk,
                                                                                All.Dimensions.ParquetsPerChunk];

        /// <summary>Collectible materials in the chunk.</summary>
        protected override EntityID[,] _collectibleLayer { get; } = new EntityID[All.Dimensions.ParquetsPerChunk,
                                                                                 All.Dimensions.ParquetsPerChunk];
        #endregion

        #region Serialization Methods
        /// <summary>
        /// Tries to deserialize a <see cref="MapChunk"/> from the given string.
        /// </summary>
        /// <param name="in_serializedMap">The serialized <see cref="MapChunk"/>.</param>
        /// <param name="out_map">
        /// The deserialized <see cref="MapChunk"/>, or null if deserialization was impossible.
        /// </param>
        /// <returns><c>true</c>, if deserialize was posibile, <c>false</c> otherwise.</returns>
        public static bool TryDeserializeFromString(string in_serializedMap, out MapChunk out_map)
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
                    if (AssemblyInfo.SupportedMapDataVersion.Equals(version, StringComparison.OrdinalIgnoreCase))
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
        /// Describes the <see cref="MapChunk"/> as a <see langword="string"/> containing basic information.
        /// </summary>
        /// <returns>A <see langword="string"/> that represents the current <see cref="MapChunk"/>.</returns>
        public override string ToString()
            => $"Chunk {base.ToString()}";
        #endregion
    }
}
