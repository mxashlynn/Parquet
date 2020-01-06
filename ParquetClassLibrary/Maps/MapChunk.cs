using System;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Maps
{
    /// <summary>
    /// Models details of a playable chunk in sandbox.
    /// <see cref="MapChunk"/>s are composed of parquets and <see cref="SpecialPoints.SpecialPoint"/>s.
    /// </summary>
    public sealed class MapChunk : MapParent
    {
        /// <summary>Used to indicate an empty grid.</summary>
        public static readonly MapChunk Empty = new MapChunk(EntityID.None, "Empty MapChunk");

        #region Class Defaults
        /// <summary>The chunk's dimensions in parquets.</summary>
        public override Vector2D DimensionsInParquets { get; } = new Vector2D(Rules.Dimensions.ParquetsPerChunk,
                                                                              Rules.Dimensions.ParquetsPerChunk);

        /// <summary>The set of values that are allowed for <see cref="MapChunk"/> <see cref="EntityID"/>s.</summary>
        public static Range<EntityID> Bounds => All.MapChunkIDs;
        #endregion

        #region Chunk Contents
        /// <summary>The statuses of parquets in the chunk.</summary>
        protected override ParquetStatusGrid ParquetStatuses { get; } = new ParquetStatusGrid(Rules.Dimensions.ParquetsPerChunk, Rules.Dimensions.ParquetsPerChunk);

        /// <summary>Floors and walkable terrain in the chunk.</summary>
        protected override ParquetStackGrid ParquetDefintion { get; } = new ParquetStackGrid(Rules.Dimensions.ParquetsPerChunk, Rules.Dimensions.ParquetsPerChunk);
        #endregion

        #region Initialization
        /// <summary>
        /// Used by children of the <see cref="MapParent"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the map.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the map.  Cannot be null or empty.</param>
        public MapChunk(EntityID inID, string inName)
            : base(Bounds, inID, inName, "", "") { }
        #endregion

        #region Serialization

        #endregion

        #region Utilities
        /// <summary>
        /// Describes the <see cref="MapChunk"/> as a <see langword="string"/> containing basic information.
        /// </summary>
        /// <returns>A <see langword="string"/> that represents the current <see cref="MapChunk"/>.</returns>
        public override string ToString()
            => $"Chunk {base.ToString()}";
        #endregion
    }
}
