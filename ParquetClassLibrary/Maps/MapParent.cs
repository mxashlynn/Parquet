using System;
using System.Collections.Generic;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Maps
{
    /// <summary>
    /// Provides methods that are used by all parquet-based map models
    /// (for example <see cref="MapRegion"/> and <see cref="MapChunk"/>,
    /// but contrast <see cref="ChunkTypeGrid"/> which is not parquet-based).
    /// </summary>
    public abstract class MapParent : Entity
    {
        #region Class Defaults
        /// <summary>Dimensions in parquets.  Defined by child classes.</summary>
        public abstract Vector2D DimensionsInParquets { get; }
        #endregion

        #region Whole-Map Characteristics
        /// <summary>
        /// Describes the version of serialized data.
        /// Allows selecting data files that can be successfully deserialized.
        /// </summary>
        protected string DataVersion { get; } = AssemblyInfo.SupportedMapDataVersion;

        /// <summary>Tracks how many times the data structure has been serialized.</summary>
        public int Revision { get; private set; }
        #endregion

        #region Map Contents
        /// <summary>Locations on the map at which a something happens that cannot be determined from parquets alone.</summary>
        protected List<ExitPoint> ExitPoints { get; } = new List<ExitPoint>();

        /// <summary>Floors and walkable terrain on the map.</summary>
        protected abstract ParquetStatusGrid ParquetStatuses { get; }

        /// <summary>
        /// Definitions for every <see cref="Floor"/>, <see cref="Block"/>, <see cref="Furnishing"/>,
        /// and <see cref="Collectible"/> that makes up this part of the game world.
        /// </summary>
        protected abstract ParquetStackGrid ParquetDefintion { get; }

        /// <summary>The total number of parquets in the entire map.</summary>
        protected int ParquetsCount => ParquetDefintion?.Count ?? 0;
        #endregion

        #region Initialization
        /// <summary>
        /// Used by children of the <see cref="MapParent"/> class.
        /// </summary>
        /// <param name="inBounds">The bounds within which the derived map type's EntityID is defined.</param>
        /// <param name="inID">Unique identifier for the map.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the map.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the map.</param>
        /// <param name="inComment">Comment of, on, or by the map.</param>
        protected MapParent(Range<EntityID> inBounds, EntityID inID, string inName, string inDescription, string inComment)
            : base(inBounds, inID, inName, inDescription, inComment) { }
        #endregion

        #region Parquets Replacement
        /// <summary>
        /// Attempts to update the <see cref="Floor"/> parquet at the given position.
        /// </summary>
        /// <param name="inFloorID">ID for the new floor to set.</param>
        /// <param name="inPosition">The position to set.</param>
        /// <returns><c>true</c>, if the floor was set, <c>false</c> otherwise.</returns>
        public bool TrySetFloorDefinition(EntityID inFloorID, Vector2D inPosition)
            => TrySetParquetDefinition(inFloorID, null, null, null, inPosition);

        /// <summary>
        /// Attempts to update the <see cref="Block"/> at the given position.
        /// </summary>
        /// <param name="inBlockID">ID for the new block to set.</param>
        /// <param name="inPosition">The position to set.</param>
        /// <returns><c>true</c>, if the block was set, <c>false</c> otherwise.</returns>
        public bool TrySetBlockDefinition(EntityID inBlockID, Vector2D inPosition)
            => TrySetParquetDefinition(null, inBlockID, null, null, inPosition);

        /// <summary>
        /// Attempts to update the <see cref="Furnishing"/> at the given position.
        /// </summary>
        /// <param name="inFurnishingID">ID for the new furnishing to set.</param>
        /// <param name="inPosition">The position to set.</param>
        /// <returns><c>true</c>, if the furnishing was set, <c>false</c> otherwise.</returns>
        public bool TrySetFurnishingDefinition(EntityID inFurnishingID, Vector2D inPosition)
            => TrySetParquetDefinition(null, null, inFurnishingID, null, inPosition);

        /// <summary>
        /// Attempts to update the <see cref="Collectible"/> at the given position.
        /// </summary>
        /// <param name="inCollectibleID">ID for the new collectible to set.</param>
        /// <param name="inPosition">The position to set.</param>
        /// <returns><c>true</c>, if the collectible was set, <c>false</c> otherwise.</returns>
        public bool TrySetCollectibleDefinition(EntityID inCollectibleID, Vector2D inPosition)
            => TrySetParquetDefinition(null, null, null, inCollectibleID, inPosition);

        /// <summary>
        /// Attempts to update the parquet at the given position in the given layer.
        /// </summary>
        /// <param name="inSpace">IDs and position to set.</param>
        /// <returns><c>true</c>, if the parquet was set, <c>false</c> otherwise.</returns>
        public bool TrySetParquetDefinition(Rooms.MapSpace inSpace)
            => TrySetParquetDefinition(inSpace.Content.Floor, inSpace.Content.Block,
                                       inSpace.Content.Furnishing, inSpace.Content.Collectible,
                                       new Vector2D(inSpace.Position.X, inSpace.Position.Y));

        /// <summary>
        /// Attempts to update the parquet at the given position in the given layer.
        /// </summary>
        /// <param name="inFloorID">ID for the new floor to set.</param>
        /// <param name="inBlockID">ID for the new block to set.</param>
        /// <param name="inFurnishingID">ID for the new furnishing to set.</param>
        /// <param name="inCollectibleID">ID for the new collectible to set.</param>
        /// <param name="inPosition">The position to put the parquet in.</param>
        /// <returns><c>true</c>, if the parquet was set, <c>false</c> otherwise.</returns>
        public bool TrySetParquetDefinition(EntityID? inFloorID, EntityID? inBlockID,
                                            EntityID? inFurnishingID, EntityID? inCollectibleID,
                                            Vector2D inPosition)
        {
            var result = false;
            if (ParquetDefintion.IsValidPosition(inPosition))
            {
                ParquetDefintion[inPosition.Y, inPosition.X] =
                    new ParquetStack(
                        inFloorID ?? ParquetDefintion[inPosition.Y, inPosition.X].Floor,
                        inBlockID ?? ParquetDefintion[inPosition.Y, inPosition.X].Block,
                        inFurnishingID ?? ParquetDefintion[inPosition.Y, inPosition.X].Furnishing,
                        inCollectibleID ?? ParquetDefintion[inPosition.Y, inPosition.X].Collectible);
                result = true;
            }
            return result;
        }
        #endregion

        #region Special Point Modification
        /// <summary>
        /// Attempts to assign the given exit point.
        /// If an exit point already exists at this location, it is replaced.
        /// </summary>
        /// <param name="inPoint">The point to set.</param>
        /// <returns><c>true</c>, if the point was set, <c>false</c> otherwise.</returns>
        public bool TrySetExitPoint(ExitPoint inPoint)
        {
            var result = true;

            if (ExitPoints.Contains(inPoint))
            {
                result = TryRemoveExitPoint(inPoint);
            }
            ExitPoints.Add(inPoint);

            return result;
        }

        /// <summary>
        /// Attempts to remove the given exit point.
        /// </summary>
        /// <param name="inPoint">The point to remove.</param>
        /// <returns><c>true</c>, if the point was found and removed, <c>false</c> otherwise.</returns>
        public bool TryRemoveExitPoint(ExitPoint inPoint)
            => ParquetDefintion.IsValidPosition(inPoint.Position)
            && ExitPoints.Remove(inPoint);
        #endregion

        #region State Queries
        /// <summary>
        /// Gets the statuses of any parquets at the position.
        /// </summary>
        /// <param name="inPosition">The position whose status is sought.</param>
        /// <returns>The status of parquets at the given position.</returns>
        public ParquetStatus GetStatusAtPosition(Vector2D inPosition)
            => ParquetStatuses.IsValidPosition(inPosition)
                ? ParquetStatuses[inPosition.Y, inPosition.X]
                : throw new ArgumentOutOfRangeException(nameof(inPosition));

        /// <summary>
        /// Gets any floor parquet at the position.
        /// </summary>
        /// <param name="inPosition">The position whose floor is sought.</param>
        /// <returns>The floor at the given position.</returns>
        public ParquetStack GetDefinitionAtPosition(Vector2D inPosition)
            => ParquetDefintion.IsValidPosition(inPosition)
                ? ParquetDefintion[inPosition.Y, inPosition.X]
                : throw new ArgumentOutOfRangeException(nameof(inPosition));

        /// <summary>
        /// Gets any <see cref="ExitPoint"/>s at the given position, if any.
        /// </summary>
        /// <param name="inPosition">The position whose data is sought.</param>
        /// <returns>The special points at the position.</returns>
        public List<ExitPoint> GetExitsAtPosition(Vector2D inPosition)
            => ExitPoints.FindAll(inPoint => inPoint.Position.Equals(inPosition));
        #endregion

        #region Serialization

        #endregion

        #region Utilities
        /// <summary>
        /// Determines if the given position corresponds to a point in the region.
        /// </summary>
        /// <param name="inPosition">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public bool IsValidPosition(Vector2D inPosition)
            => ParquetDefintion.IsValidPosition(inPosition);

        /// <summary>
        /// Provides all parquet definitions within the current map.
        /// </summary>
        /// <returns>The entire map as a subregion.</returns>
        public ParquetStackGrid GetSubregion()
            => GetSubregion(Vector2D.Zero, new Vector2D(DimensionsInParquets.X - 1, DimensionsInParquets.Y - 1));

        /// <summary>
        /// Provides all parquet definitions within the specified rectangular subsection of the current map.
        /// </summary>
        /// <param name="inUpperLeft">The position of the upper-leftmost corner of the subregion.</param>
        /// <param name="inLowerRight">The position of the lower-rightmost corner of the subregion.</param>
        /// <returns>A portion of the map as a subregion.</returns>
        public ParquetStackGrid GetSubregion(Vector2D inUpperLeft, Vector2D inLowerRight)
        {
            if (!ParquetDefintion.IsValidPosition(inUpperLeft))
            {
                throw new ArgumentOutOfRangeException(nameof(inUpperLeft));
            }
            else if (!ParquetDefintion.IsValidPosition(inLowerRight))
            {
                throw new ArgumentOutOfRangeException(nameof(inLowerRight));
            }
            else if (inLowerRight.X < inUpperLeft.X && inLowerRight.Y < inUpperLeft.Y)
            {
                throw new ArgumentException("Improper vector order.", nameof(inLowerRight));
            }
            else
            {
                var subregion = new ParquetStack[inLowerRight.X - inUpperLeft.X + 1,
                                                 inLowerRight.Y - inUpperLeft.Y + 1];

                for (var x = inUpperLeft.X; x <= inLowerRight.X; x++)
                {
                    for (var y = inUpperLeft.Y; y <= inLowerRight.Y; y++)
                    {
                        var temp = ParquetDefintion[y, x];
                        subregion[y - inUpperLeft.Y, x - inUpperLeft.X] = temp;
                    }
                }

                return new ParquetStackGrid(subregion);
            }
        }

        /// <summary>
        /// Describes the map through general characteristics.
        /// </summary>
        /// <returns>A <see langword="string"/> that represents the current map.</returns>
        public override string ToString()
            => $"({DimensionsInParquets.X }, {DimensionsInParquets.Y}) contains {ParquetsCount} parquets and {ExitPoints.Count} special points.";
        #endregion
    }
}
