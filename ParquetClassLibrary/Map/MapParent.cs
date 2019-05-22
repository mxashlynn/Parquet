using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Map.SpecialPoints;
using System;
#if UNITY_2018_4_OR_NEWER
using UnityEngine;
#else
using ParquetClassLibrary.Stubs;
#endif

// ReSharper disable InconsistentNaming

namespace ParquetClassLibrary.Map
{
    /// <summary>
    /// Provides methods that are used by all parquet-based map models
    /// (for example <see cref="MapRegion"/> and <see cref="MapChunk"/>, but contrast
    /// <see cref="MapChunkGrid"/> which is not parquet-based).
    /// </summary>
    public abstract class MapParent
    {
        #region Class Defaults
        /// <summary>Dimensions in parquets.  Defined by child classes.</summary>
        public abstract Vector2Int DimensionsInParquets { get; }
        #endregion

        #region Whole-Map Characteristics
        /// <summary>
        /// Describes the version of serialized data.
        /// Allows selecting data files that can be successfully deserialized.
        /// </summary>
        protected readonly string DataVersion = AssemblyInfo.SupportedMapDataVersion;

        /// <summary>Tracks how many times the data structure has been serialized.</summary>
        public int Revision { get; private set; }
        #endregion

        #region Map Contents
        /// <summary>Exit, spawn, and other special points on the map.</summary>
        protected readonly List<SpecialPoint> _specialPoints = new List<SpecialPoint>();

        /// <summary>Floors and walkable terrain on the map.</summary>
        protected abstract ParquetStatus[,] _parquetStatus { get; }

        /// <summary>
        /// Definitions for every <see cref="Floor"/>, <see cref="Block"/>, <see cref="Furnishing"/>,
        /// and <see cref="Collectible"/> that makes up this part of the game world.
        /// </summary>
        protected abstract ParquetStack[,] _parquetDefintion { get; }

        /// <summary>The total number of parquets in the entire map.</summary>
        protected int ParquetsCount
        {
            get
            {
                var count = 0;

                for (var y = 0; y < DimensionsInParquets.Y; y++)
                {
                    for (var x = 0; x < DimensionsInParquets.X; x++)
                    {
                        count += EntityID.None != _parquetDefintion[y, x].Floor ? 1 : 0;
                        count += EntityID.None != _parquetDefintion[y, x].Block ? 1 : 0;
                        count += EntityID.None != _parquetDefintion[y, x].Furnishing ? 1 : 0;
                        count += EntityID.None != _parquetDefintion[y, x].Collectible ? 1 : 0;
                    }
                }

                return count;
            }
        }
        #endregion

        #region Parquets Replacement Methods
        /// <summary>
        /// Attempts to update the floor parquet at the given position.
        /// </summary>
        /// <param name="in_floorID">ID for the new floor to set.</param>
        /// <param name="in_position">The position to set.</param>
        /// <returns><c>true</c>, if the floor was set, <c>false</c> otherwise.</returns>
        public bool TrySetFloorDefinition(EntityID in_floorID, Vector2Int in_position)
            // TODO If you make these nullable in TrySetParquet these calls can besimplified and the validity check postponned
            => IsValidPosition(in_position)
            && TrySetParquetDefinition(
                    in_floorID,
                    _parquetDefintion[in_position.Y, in_position.X].Block,
                    _parquetDefintion[in_position.Y, in_position.X].Furnishing,
                    _parquetDefintion[in_position.Y, in_position.X].Collectible,
                    in_position);

        /// <summary>
        /// Attempts to update the block parquet at the given position.
        /// </summary>
        /// <param name="in_blockID">ID for the new block to set.</param>
        /// <param name="in_position">The position to set.</param>
        /// <returns><c>true</c>, if the block was set, <c>false</c> otherwise.</returns>
        public bool TrySetBlockDefinition(EntityID in_blockID, Vector2Int in_position)
            => IsValidPosition(in_position)
            && TrySetParquetDefinition(
                    _parquetDefintion[in_position.Y, in_position.X].Floor,
                    in_blockID,
                    _parquetDefintion[in_position.Y, in_position.X].Furnishing,
                    _parquetDefintion[in_position.Y, in_position.X].Collectible,
                    in_position);

        /// <summary>
        /// Attempts to update the furnishing parquet at the given position.
        /// </summary>
        /// <param name="in_furnishingID">ID for the new furnishing to set.</param>
        /// <param name="in_position">The position to set.</param>
        /// <returns><c>true</c>, if the furnishing was set, <c>false</c> otherwise.</returns>
        public bool TrySetFurnishingDefinition(EntityID in_furnishingID, Vector2Int in_position)
            => IsValidPosition(in_position)
            && TrySetParquetDefinition(
                    _parquetDefintion[in_position.Y, in_position.X].Floor,
                    _parquetDefintion[in_position.Y, in_position.X].Block,
                    in_furnishingID,
                    _parquetDefintion[in_position.Y, in_position.X].Collectible,
                    in_position);

        /// <summary>
        /// Attempts to update the collectible parquet at the given position.
        /// </summary>
        /// <param name="in_collectibleID">ID for the new collectible to set.</param>
        /// <param name="in_position">The position to set.</param>
        /// <returns><c>true</c>, if the collectible was set, <c>false</c> otherwise.</returns>
        public bool TrySetCollectibleDefinition(EntityID in_collectibleID, Vector2Int in_position)
            => IsValidPosition(in_position)
            && TrySetParquetDefinition(
                    _parquetDefintion[in_position.Y, in_position.X].Floor,
                    _parquetDefintion[in_position.Y, in_position.X].Block,
                    _parquetDefintion[in_position.Y, in_position.X].Furnishing,
                    in_collectibleID,
                    in_position);

        /// <summary>
        /// Attempts to update the parquet at the given position in the given layer.
        /// </summary>
        /// <param name="in_floorID">ID for the new floor to set.</param>
        /// <param name="in_blockID">ID for the new block to set.</param>
        /// <param name="in_furnishingID">ID for the new furnishing to set.</param>
        /// <param name="in_collectibleID">ID for the new collectible to set.</param>
        /// <param name="in_position">The position to put the parquet in.</param>
        /// <returns><c>true</c>, if the parquet was set, <c>false</c> otherwise.</returns>
        public bool TrySetParquetDefinition(EntityID in_floorID, EntityID in_blockID, EntityID in_furnishingID,
                                            EntityID in_collectibleID, Vector2Int in_position)
        {
            var result = false;
            if (IsValidPosition(in_position))
            {
                _parquetDefintion[in_position.Y, in_position.X] =
                    new ParquetStack(in_floorID, in_blockID, in_furnishingID, in_collectibleID);
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
            var result = false;

            if (TryRemoveExitPoint(in_point))
            {
                _specialPoints.Add(in_point);
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Attempts to remove the given exit point.
        /// </summary>
        /// <param name="in_point">The point to remove.</param>
        /// <returns><c>true</c>, if the point was not found or if it was found and removed, <c>false</c> otherwise.</returns>
        public bool TryRemoveExitPoint(ExitPoint in_point)
            => TryRemoveSpecialPoint(in_point);

        /// <summary>
        /// Attempts to assign the given spawn point.
        /// If a spawn point already exists at this location, it is replaced.
        /// </summary>
        /// <param name="in_point">The point to set.</param>
        /// <returns><c>true</c>, if the point was set, <c>false</c> otherwise.</returns>
        public bool TrySetSpawnPoint(SpawnPoint in_point)
        {
            var result = false;

            if (TryRemoveSpawnPoint(in_point))
            {
                _specialPoints.Add(in_point);
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Attempts to remove a spawn point at the given location.
        /// </summary>
        /// <param name="in_point">The location of the spawn point to remove.</param>
        /// <returns><c>true</c>, if the point was not found or if it was found and removed, <c>false</c> otherwise.</returns>
        public bool TryRemoveSpawnPoint(SpawnPoint in_point)
            => TryRemoveSpecialPoint(in_point);

        /// <summary>
        /// Attempts to remove a special point at the given location.
        /// </summary>
        /// <param name="in_point">The location of the special point to remove.</param>
        /// <returns><c>true</c>, if the point was not found or if it was found and removed, <c>false</c> otherwise.</returns>
        private bool TryRemoveSpecialPoint(SpecialPoint in_point)
        {
            var result = false;

            if (null != in_point
                && IsValidPosition(in_point.Position))
            {
                // Return true if the point was removed or if the point never existed.
                result = _specialPoints.Remove(in_point) ||
                         !_specialPoints.Exists(in_foundPoint =>
                             in_foundPoint.GetType() == in_point.GetType() && in_foundPoint == in_point);
            }

            return result;
        }
        #endregion

        #region State Query Methods
        /// <summary>
        /// Gets the statuses of any parquets at the position.
        /// </summary>
        /// <param name="in_position">The position whose status is sought.</param>
        /// <returns>The status of parquets at the given position, or <c>null</c> if the position is invalid.</returns>
        public ParquetStatus GetStatusAtPosition(Vector2Int in_position)
            => IsValidPosition(in_position)
                ? _parquetStatus[in_position.Y, in_position.X]
                : null;

        /// <summary>
        /// Gets any floor parquet at the position.
        /// </summary>
        /// <param name="in_position">The position whose floor is sought.</param>
        /// <returns>The floor at the given position, or <c>null</c> if there is none.</returns>
        public ParquetStack GetDefinitionAtPosition(Vector2Int in_position)
            => IsValidPosition(in_position)
                ? _parquetDefintion[in_position.Y, in_position.X]
                : ParquetStack.Empty;

        /// <summary>
        /// Gets all the parquets in the entire map.
        /// </summary>
        /// <returns>A collection of parquets.</returns>
        // TODO This should probably be rethought.
        public IEnumerable<EntityID> GetAllParquets()
        {
            var result = new List<EntityID>();

            for (var y = 0; y < DimensionsInParquets.Y; y++)
            {
                for (var x = 0; x < DimensionsInParquets.X; x++)
                {
                    if (EntityID.None != _parquetDefintion[y, x].Floor)
                    {
                        result.Add(_parquetDefintion[y, x].Floor);
                    }
                    if (EntityID.None != _parquetDefintion[y, x].Block)
                    {
                        result.Add(_parquetDefintion[y, x].Floor);
                    }
                    if (EntityID.None != _parquetDefintion[y, x].Furnishing)
                    {
                        result.Add(_parquetDefintion[y, x].Floor);
                    }
                    if (EntityID.None != _parquetDefintion[y, x].Collectible)
                    {
                        result.Add(_parquetDefintion[y, x].Floor);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Gets all special data at the given position, if any.
        /// </summary>
        /// <param name="in_position">The position whose data is sought.</param>
        /// <returns>The special points at the position.</returns>
        public List<SpecialPoint> GetSpecialPointsAtPosition(Vector2Int in_position)
            => _specialPoints.FindAll(in_point => in_point.Position.Equals(in_position));
        #endregion

        #region Serialization Methods
        /// <summary>
        /// Serializes to the current Map to a string,
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
        /// Provides all parquet definitions within the current map.
        /// </summary>
        /// <returns>The entire map as a subregion.</returns>
        public ParquetStack[,] GetSubregion()
            => GetSubregion(Vector2Int.ZeroVector, new Vector2Int(DimensionsInParquets.X - 1,
                                                                  DimensionsInParquets.Y - 1));

        /// <summary>
        /// Provides all parquet definitions within the specified rectangular subsection of the current map.
        /// </summary>
        /// <param name="in_upperLeft">The position of the upper-leftmost corner of the subregion.</param>
        /// <param name="in_lowerRight">The position of the lower-rightmost corner of the subregion.</param>
        /// <returns>A portion of the map as a subregion.</returns>
        public ParquetStack[,] GetSubregion(Vector2Int in_upperLeft, Vector2Int in_lowerRight)
        {
            if (!IsValidPosition(in_upperLeft))
            {
                throw new ArgumentOutOfRangeException(nameof(in_upperLeft));
            }
            else if (!IsValidPosition(in_lowerRight))
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
                        var temp = _parquetDefintion[x, y];
                        subregion[x - in_upperLeft.X, y - in_upperLeft.Y] = temp;
                    }
                }

                return subregion;
            }
        }

        /// <summary>
        /// Determines if the given position corresponds to a point on the map.
        /// </summary>
        /// <param name="in_position">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public bool IsValidPosition(Vector2Int in_position)
            => in_position.X > -1
            && in_position.Y > -1
            && in_position.X < DimensionsInParquets.X
            && in_position.Y < DimensionsInParquets.Y;

        /// <summary>
        /// Visualizes the map as a string with merged layers.
        /// Intended for Console debugging.
        /// </summary>
        /// <returns>A <see langword="string"/> that represents the current map.</returns>
        internal string DumpMap()
        {
            var representation = new StringBuilder(DimensionsInParquets.Magnitude);
            #region Compose visual represenation of contents.
            for (var x = 0; x < DimensionsInParquets.X; x++)
            {
                for (var y = 0; y < DimensionsInParquets.Y; y++)
                {
                    var parquet = EntityID.None != _parquetDefintion[y, x].Collectible
                        ? All.Parquets.Get<ParquetParent>(_parquetDefintion[y, x].Collectible) 
                        : EntityID.None != _parquetDefintion[y, x].Furnishing
                            ? All.Parquets.Get<ParquetParent>(_parquetDefintion[y, x].Furnishing)
                            : EntityID.None != _parquetDefintion[y, x].Block
                                ? All.Parquets.Get<ParquetParent>(_parquetDefintion[y, x].Block)
                                : EntityID.None != _parquetDefintion[y, x].Floor
                                    ? All.Parquets.Get<ParquetParent>(_parquetDefintion[y, x].Floor)
                                    : null;

                    representation.Append(parquet?.ToString() ?? "~");
                }
                representation.AppendLine();
            }
            #endregion

            return representation.ToString();
        }

        /// <summary>
        /// Visualizes the map as a string, listing layers separately.
        /// Intended for Console debugging.
        /// </summary>
        /// <returns>A <see langword="string"/> that represents the current map.</returns>
        public string DumpMapWithLayers()
        {
            var floorRepresentation = new StringBuilder(DimensionsInParquets.Magnitude);
            var blocksRepresentation = new StringBuilder(DimensionsInParquets.Magnitude);
            var furnishingsRepresentation = new StringBuilder(DimensionsInParquets.Magnitude);
            var collectiblesRepresentation = new StringBuilder(DimensionsInParquets.Magnitude);
            #region Compose visual represenation of contents.
            for (var x = 0; x < DimensionsInParquets.X; x++)
            {
                for (var y = 0; y < DimensionsInParquets.Y; y++)
                {
                    floorRepresentation.Append(EntityID.None != _parquetDefintion[y, x].Floor
                        ? All.Parquets.Get<Floor>(_parquetDefintion[y, x].Floor).ToString()
                        : "~");
                    blocksRepresentation.Append(EntityID.None != _parquetDefintion[y, x].Block
                        ? All.Parquets.Get<Block>(_parquetDefintion[y, x].Block).ToString()
                        : " ");
                    furnishingsRepresentation.Append(EntityID.None != _parquetDefintion[y, x].Furnishing
                        ? All.Parquets.Get<Furnishing>(_parquetDefintion[y, x].Furnishing).ToString()
                        : " ");
                    collectiblesRepresentation.Append(EntityID.None != _parquetDefintion[y, x].Collectible
                        ? All.Parquets.Get<Collectible>(_parquetDefintion[y, x].Collectible).ToString()
                        : " ");
                }
                floorRepresentation.AppendLine();
                blocksRepresentation.AppendLine();
                furnishingsRepresentation.AppendLine();
                collectiblesRepresentation.AppendLine();
            }
            #endregion

            return $"Floor:\n{floorRepresentation}\n" +
                $"Blocks:\n{blocksRepresentation}\n" +
                $"Furnishings:\n{furnishingsRepresentation}\n" +
                $"Collectibles:\n{collectiblesRepresentation}";
        }

        /// <summary>
        /// Describes the map's basic information.
        /// </summary>
        /// <returns>A <see langword="string"/> that represents the current map.</returns>
        public override string ToString()
            => $"({DimensionsInParquets.X }, {DimensionsInParquets.Y}) contains {ParquetsCount} parquets and {_specialPoints.Count} special points.";
        #endregion
    }
}
