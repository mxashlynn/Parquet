using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.Parquets;

namespace ParquetClassLibrary.Maps
{
    /// <summary>
    /// Models details of a playable chunk in sandbox.
    /// <see cref="MapChunk"/>s are composed of parquets.
    /// </summary>
    public sealed class MapChunk : MapModel
    {
        #region Class Defaults
        /// <summary>Used to indicate an empty grid.</summary>
        public static MapChunk Empty { get; } = new MapChunk(ModelID.None, "Empty MapChunk", "", "");

        /// <summary>The length of each <see cref="ChunkTypeGrid"/> dimension in parquets.</summary>
        public const int ParquetsPerChunkDimension = 16;

        /// <summary>The chunk's dimensions in parquets.</summary>
        public override Vector2D DimensionsInParquets { get; } = new Vector2D(ParquetsPerChunkDimension,
                                                                              ParquetsPerChunkDimension);

        /// <summary>The set of values that are allowed for <see cref="MapChunk"/> <see cref="ModelID"/>s.</summary>
        public static Range<ModelID> Bounds
            => All.MapChunkIDs;
        #endregion

        #region Characteristics
        /// <summary>The statuses of parquets in the chunk.</summary>
        [Index(12)]
        public override ParquetStatusGrid ParquetStatuses { get; }

        /// <summary>Floors and walkable terrain in the chunk.</summary>
        [Index(13)]
        public override ParquetStackGrid ParquetDefinitions { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Used by children of the <see cref="MapModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the map.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the map.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the map.</param>
        /// <param name="inComment">Comment of, on, or by the map.</param>
        /// <param name="inRevision">An option revision count.</param>
        /// <param name="inParquetStatuses">The statuses of the collected parquets.</param>
        /// <param name="inParquetDefinitions">The definitions of the collected parquets.</param>
        public MapChunk(ModelID inID, string inName, string inDescription, string inComment, int inRevision = 0,
                        ParquetStatusGrid inParquetStatuses = null,
                        ParquetStackGrid inParquetDefinitions = null)
            : base(Bounds, inID, inName, inDescription, inComment, inRevision)
        {
            ParquetStatuses = inParquetStatuses ?? new ParquetStatusGrid(ParquetsPerChunkDimension, ParquetsPerChunkDimension);
            ParquetDefinitions = inParquetDefinitions ?? new ParquetStackGrid(ParquetsPerChunkDimension, ParquetsPerChunkDimension);
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Describes the <see cref="MapChunk"/> as a <see cref="string"/> containing basic information.
        /// </summary>
        /// <returns>A <see cref="string"/> that represents the current <see cref="MapChunk"/>.</returns>
        public override string ToString()
            => $"Chunk {Name} {base.ToString()}";
        #endregion
    }
}
