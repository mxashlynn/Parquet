using System.Collections.Generic;
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.Parquets;

namespace ParquetClassLibrary.Maps
{
    /// <summary>
    /// Models details of a playable chunk in sandbox.
    /// <see cref="MapChunk"/>s are composed of parquets and <see cref="ExitPoint"/>s.
    /// </summary>
    public sealed class MapChunk : MapModel
    {
        #region Class Defaults
        /// <summary>Used to indicate an empty grid.</summary>
        public static readonly MapChunk Empty = new MapChunk(ModelID.None, "Empty MapChunk", "", "", AssemblyInfo.SupportedMapDataVersion);

        /// <summary>The chunk's dimensions in parquets.</summary>
        public override Vector2D DimensionsInParquets { get; } = new Vector2D(Rules.Dimensions.ParquetsPerChunk,
                                                                              Rules.Dimensions.ParquetsPerChunk);

        /// <summary>The set of values that are allowed for <see cref="MapChunk"/> <see cref="ModelID"/>s.</summary>
        public static Range<ModelID> Bounds
            => All.MapChunkIDs;
        #endregion

        #region Characteristics
        /// <summary>The statuses of parquets in the chunk.</summary>
        [Index(10)]
        public override ParquetStatusGrid ParquetStatuses { get; }

        /// <summary>Floors and walkable terrain in the chunk.</summary>
        [Index(11)]
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
        /// <param name="inDataVersion">Describes the version of serialized data, to support versioning.</param>
        /// <param name="inRevision">An option revision count.</param>
        /// <param name="inExits">Locations on the map at which a something happens that cannot be determined from parquets alone.</param>
        /// <param name="inParquetStatuses">The statuses of the collected parquets.</param>
        /// <param name="inParquetDefinitions">The definitions of the collected parquets.</param>
        public MapChunk(ModelID inID, string inName, string inDescription, string inComment, string inDataVersion, int inRevision = 0,
                        IEnumerable<ExitPoint> inExits = null, ParquetStatusGrid inParquetStatuses = null,
                        ParquetStackGrid inParquetDefinitions = null)
            : base(Bounds, inID, inName, inDescription, inComment, inDataVersion, inRevision, inExits)
        {
            ParquetStatuses = inParquetStatuses ?? new ParquetStatusGrid(Rules.Dimensions.ParquetsPerChunk, Rules.Dimensions.ParquetsPerChunk);
            ParquetDefinitions = inParquetDefinitions ?? new ParquetStackGrid(Rules.Dimensions.ParquetsPerChunk, Rules.Dimensions.ParquetsPerChunk);
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Describes the <see cref="MapChunk"/> as a <see langword="string"/> containing basic information.
        /// </summary>
        /// <returns>A <see langword="string"/> that represents the current <see cref="MapChunk"/>.</returns>
        public override string ToString()
            => $"Chunk {Name} {base.ToString()}";
        #endregion
    }
}
