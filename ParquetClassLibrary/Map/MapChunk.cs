using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Map
{
    /// <summary>
    /// Models details of a playable chunk in sandbox-mode.
    /// <see cref="MapChunk"/>s are composed of parquets and <see cref="SpecialPoints.SpecialPoint"/>s.
    // TODO Is the statement below true?  If so, it is confusing.  What then is a ChunkType used for?
    // Probably we just need to rename things a bit.
    /// MapChunks are handmade (as opposed to procedurally generated) components of <see cref="MapRegion"/>s.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public sealed class MapChunk : MapParent
    {
        /// <summary>Used to indicate an empty grid.</summary>
        public static readonly MapChunk Empty = new MapChunk();

        #region Class Defaults
        /// <summary>The chunk's dimensions in parquets.</summary>
        public override Vector2D DimensionsInParquets { get; } = new Vector2D(Rules.Dimensions.ParquetsPerChunk,
                                                                              Rules.Dimensions.ParquetsPerChunk);
        #endregion

        #region Chunk Contents
        /// <summary>The statuses of parquets in the chunk.</summary>
        protected override ParquetStatus[,] ParquetStatus { get; } =
            new ParquetStatus[Rules.Dimensions.ParquetsPerChunk, Rules.Dimensions.ParquetsPerChunk];

        /// <summary>Floors and walkable terrain in the chunk.</summary>
        protected override ParquetStack[,] ParquetDefintion { get; } =
            new ParquetStack[Rules.Dimensions.ParquetsPerChunk, Rules.Dimensions.ParquetsPerChunk];
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
            Precondition.IsNotNullOrEmpty(in_serializedMap, nameof(in_serializedMap));
            var result = false;
            out_map = Empty;

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
                LibraryError.Handle($"Error reading string while deserializing a MapChunk: {exception}");
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
