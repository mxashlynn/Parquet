using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Maps
{
    /// <summary>
    /// Provides methods that are used by all parquet-based map models
    /// (for example <see cref="MapRegion"/> and <see cref="MapChunk"/>,
    /// but contrast <see cref="MapChunkGrid"/> which is not parquet-based).
    /// </summary>
    public abstract class MapParent
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
        protected abstract ParquetStatus2DCollection ParquetStatuses { get; }

        /// <summary>
        /// Definitions for every <see cref="Floor"/>, <see cref="Block"/>, <see cref="Furnishing"/>,
        /// and <see cref="Collectible"/> that makes up this part of the game world.
        /// </summary>
        protected abstract ParquetStack2DCollection ParquetDefintion { get; }

        /// <summary>The total number of parquets in the entire map.</summary>
        protected int ParquetsCount => ParquetDefintion.Count;
        #endregion

        #region Parquets Replacement Methods
        /// <summary>
        /// Attempts to update the <see cref="Floor"/> parquet at the given position.
        /// </summary>
        /// <param name="in_floorID">ID for the new floor to set.</param>
        /// <param name="in_position">The position to set.</param>
        /// <returns><c>true</c>, if the floor was set, <c>false</c> otherwise.</returns>
        public bool TrySetFloorDefinition(EntityID in_floorID, Vector2D in_position)
            => TrySetParquetDefinition(in_floorID, null, null, null, in_position);

        /// <summary>
        /// Attempts to update the <see cref="Block"/> at the given position.
        /// </summary>
        /// <param name="in_blockID">ID for the new block to set.</param>
        /// <param name="in_position">The position to set.</param>
        /// <returns><c>true</c>, if the block was set, <c>false</c> otherwise.</returns>
        public bool TrySetBlockDefinition(EntityID in_blockID, Vector2D in_position)
            => TrySetParquetDefinition(null, in_blockID, null, null, in_position);

        /// <summary>
        /// Attempts to update the <see cref="Furnishing"/> at the given position.
        /// </summary>
        /// <param name="in_furnishingID">ID for the new furnishing to set.</param>
        /// <param name="in_position">The position to set.</param>
        /// <returns><c>true</c>, if the furnishing was set, <c>false</c> otherwise.</returns>
        public bool TrySetFurnishingDefinition(EntityID in_furnishingID, Vector2D in_position)
            => TrySetParquetDefinition(null, null, in_furnishingID, null, in_position);

        /// <summary>
        /// Attempts to update the <see cref="Collectible"/> at the given position.
        /// </summary>
        /// <param name="in_collectibleID">ID for the new collectible to set.</param>
        /// <param name="in_position">The position to set.</param>
        /// <returns><c>true</c>, if the collectible was set, <c>false</c> otherwise.</returns>
        public bool TrySetCollectibleDefinition(EntityID in_collectibleID, Vector2D in_position)
            => TrySetParquetDefinition(null, null, null, in_collectibleID, in_position);

        /// <summary>
        /// Attempts to update the parquet at the given position in the given layer.
        /// </summary>
        /// <param name="in_space">IDs and position to set.</param>
        /// <returns><c>true</c>, if the parquet was set, <c>false</c> otherwise.</returns>
        public bool TrySetParquetDefinition(MapSpace in_space)
            => TrySetParquetDefinition(in_space.Content.Floor, in_space.Content.Block,
                                       in_space.Content.Furnishing, in_space.Content.Collectible,
                                       new Vector2D(in_space.Position.X, in_space.Position.Y));

        /// <summary>
        /// Attempts to update the parquet at the given position in the given layer.
        /// </summary>
        /// <param name="in_floorID">ID for the new floor to set.</param>
        /// <param name="in_blockID">ID for the new block to set.</param>
        /// <param name="in_furnishingID">ID for the new furnishing to set.</param>
        /// <param name="in_collectibleID">ID for the new collectible to set.</param>
        /// <param name="in_position">The position to put the parquet in.</param>
        /// <returns><c>true</c>, if the parquet was set, <c>false</c> otherwise.</returns>
        public bool TrySetParquetDefinition(EntityID? in_floorID, EntityID? in_blockID,
                                            EntityID? in_furnishingID, EntityID? in_collectibleID,
                                            Vector2D in_position)
        {
            var result = false;
            if (ParquetDefintion.IsValidPosition(in_position))
            {
                ParquetDefintion[in_position.Y, in_position.X] =
                    new ParquetStack(
                        in_floorID ?? ParquetDefintion[in_position.Y, in_position.X].Floor,
                        in_blockID ?? ParquetDefintion[in_position.Y, in_position.X].Block,
                        in_furnishingID ?? ParquetDefintion[in_position.Y, in_position.X].Furnishing,
                        in_collectibleID ?? ParquetDefintion[in_position.Y, in_position.X].Collectible);
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
        /// <param name="in_point">The point to set.</param>
        /// <returns><c>true</c>, if the point was set, <c>false</c> otherwise.</returns>
        public bool TrySetExitPoint(ExitPoint in_point)
        {
            var result = true;

            if (ExitPoints.Contains(in_point))
            {
                result = TryRemoveExitPoint(in_point);
            }
            ExitPoints.Add(in_point);

            return result;
        }

        /// <summary>
        /// Attempts to remove the given exit point.
        /// </summary>
        /// <param name="in_point">The point to remove.</param>
        /// <returns><c>true</c>, if the point was found and removed, <c>false</c> otherwise.</returns>
        public bool TryRemoveExitPoint(ExitPoint in_point)
            => ParquetDefintion.IsValidPosition(in_point.Position)
            && ExitPoints.Remove(in_point);
        #endregion

        #region State Query Methods
        /// <summary>
        /// Gets the statuses of any parquets at the position.
        /// </summary>
        /// <param name="in_position">The position whose status is sought.</param>
        /// <returns>The status of parquets at the given position.</returns>
        public ParquetStatus GetStatusAtPosition(Vector2D in_position)
            => ParquetStatuses.IsValidPosition(in_position)
                ? ParquetStatuses[in_position.Y, in_position.X]
                : throw new ArgumentOutOfRangeException(nameof(in_position));

        /// <summary>
        /// Gets any floor parquet at the position.
        /// </summary>
        /// <param name="in_position">The position whose floor is sought.</param>
        /// <returns>The floor at the given position.</returns>
        public ParquetStack GetDefinitionAtPosition(Vector2D in_position)
            => ParquetDefintion.IsValidPosition(in_position)
                ? ParquetDefintion[in_position.Y, in_position.X]
                : throw new ArgumentOutOfRangeException(nameof(in_position));

        /// <summary>
        /// Gets any <see cref="ExitPoint"/>s at the given position, if any.
        /// </summary>
        /// <param name="in_position">The position whose data is sought.</param>
        /// <returns>The special points at the position.</returns>
        public List<ExitPoint> GetExitsAtPosition(Vector2D in_position)
            => ExitPoints.FindAll(in_point => in_point.Position.Equals(in_position));
        #endregion

        #region Serialization Methods
        /// <summary>
        /// Serializes the current Map to a string,
        /// incrementing the revision number in the process.
        /// </summary>
        /// <returns>The serialized Map.</returns>
        public string SerializeToString()
        {
            Revision++;
            return JsonConvert.SerializeObject(this, Formatting.None);
        }
        #endregion

        #region Utility Methods
        /// <summary>
        /// Determines if the given position corresponds to a point in the region.
        /// </summary>
        /// <param name="in_position">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public bool IsValidPosition(Vector2D in_position)
            => ParquetDefintion.IsValidPosition(in_position);

        /// <summary>
        /// Provides all parquet definitions within the current map.
        /// </summary>
        /// <returns>The entire map as a subregion.</returns>
        public ParquetStack[,] GetSubregion()
            => GetSubregion(Vector2D.Zero, new Vector2D(DimensionsInParquets.X - 1, DimensionsInParquets.Y - 1));

        /// <summary>
        /// Provides all parquet definitions within the specified rectangular subsection of the current map.
        /// </summary>
        /// <param name="in_upperLeft">The position of the upper-leftmost corner of the subregion.</param>
        /// <param name="in_lowerRight">The position of the lower-rightmost corner of the subregion.</param>
        /// <returns>A portion of the map as a subregion.</returns>
        public ParquetStack[,] GetSubregion(Vector2D in_upperLeft, Vector2D in_lowerRight)
        {
            if (!ParquetDefintion.IsValidPosition(in_upperLeft))
            {
                throw new ArgumentOutOfRangeException(nameof(in_upperLeft));
            }
            else if (!ParquetDefintion.IsValidPosition(in_lowerRight))
            {
                throw new ArgumentOutOfRangeException(nameof(in_lowerRight));
            }
            else if (in_lowerRight.X < in_upperLeft.X && in_lowerRight.Y < in_upperLeft.Y)
            {
                throw new ArgumentException("Improper vector order.", nameof(in_lowerRight));
            }
            else
            {
                var subregion = new ParquetStack[in_lowerRight.X - in_upperLeft.X + 1,
                                                 in_lowerRight.Y - in_upperLeft.Y + 1];

                for (var x = in_upperLeft.X; x <= in_lowerRight.X; x++)
                {
                    for (var y = in_upperLeft.Y; y <= in_lowerRight.Y; y++)
                    {
                        var temp = ParquetDefintion[y, x];
                        subregion[y - in_upperLeft.Y, x - in_upperLeft.X] = temp;
                    }
                }

                return subregion;
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
