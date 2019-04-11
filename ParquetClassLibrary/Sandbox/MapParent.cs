using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using ParquetClassLibrary.Sandbox.Parquets;
using ParquetClassLibrary.Sandbox.SpecialPoints;
using ParquetClassLibrary.Stubs;

// ReSharper disable InconsistentNaming

namespace ParquetClassLibrary.Sandbox
{
    /// <summary>
    /// Provides methods that are used by all Parquet-based Map models
    /// (for example <see cref="T:ParquetClassLibrary.Sandbox.MapRegion"/> and
    /// <see cref="T:ParquetClassLibrary.Sandbox.MapChunk"/>, but contrast
    /// <see cref="T:ParquetClassLibrary.Sandbox.MapChunkGrid"/> which is not
    /// Parquet-based).
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
        protected readonly string DataVersion = AssemblyInfo.SupportedDataVersion;

        /// <summary>Tracks how many times the data structure has been serialized.</summary>
        public int Revision { get; private set; }
        #endregion

        #region Map Contents
        /// <summary>Exit, spawn, and other special points on the map.</summary>
        protected readonly List<SpecialPoint> _specialPoints = new List<SpecialPoint>();

        /// <summary>Floors and walkable terrain on the map.</summary>
        protected abstract ParquetStatus[,] _parquetStatus { get; }

        /// <summary>Floors and walkable terrain on the map.</summary>
        protected abstract EntityID[,] _floorLayer { get; }

        /// <summary>Walls and obstructing terrain on the map.</summary>
        protected abstract EntityID[,] _blockLayer { get; }

        /// <summary>Furniture and natural items on the map.</summary>
        protected abstract EntityID[,] _furnishingLayer { get; }

        /// <summary>Collectible materials on the map.</summary>
        protected abstract EntityID[,] _collectibleLayer { get; }

        /// <summary>The total number of parquets in the entire map.</summary>
        protected int ParquetsCount
        {
            get
            {
                var count = 0;

                for (var x = 0; x < DimensionsInParquets.X; x++)
                {
                    for (var y = 0; y < DimensionsInParquets.Y; y++)
                    {
                        count += EntityID.None != _floorLayer[x, y] ? 1 : 0;
                        count += EntityID.None != _blockLayer[x, y] ? 1 : 0;
                        count += EntityID.None != _furnishingLayer[x, y] ? 1 : 0;
                        count += EntityID.None != _collectibleLayer[x, y] ? 1 : 0;
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
        public bool TrySetFloor(EntityID in_floorID, Vector2Int in_position)
        {
            return TrySetParquet(in_floorID, in_position, _floorLayer);
        }

        /// <summary>
        /// Attempts to update the block parquet at the given position.
        /// </summary>
        /// <param name="in_blockID">ID for the new block to set.</param>
        /// <param name="in_position">The position to set.</param>
        /// <returns><c>true</c>, if the block was set, <c>false</c> otherwise.</returns>
        public bool TrySetBlock(EntityID in_blockID, Vector2Int in_position)
        {
            return TrySetParquet(in_blockID, in_position, _blockLayer);
        }

        /// <summary>
        /// Attempts to update the furnishing parquet at the given position.
        /// </summary>
        /// <param name="in_furnishingID">ID for the new furnishing to set.</param>
        /// <param name="in_position">The position to set.</param>
        /// <returns><c>true</c>, if the furnishing was set, <c>false</c> otherwise.</returns>
        public bool TrySetFurnishing(EntityID in_furnishingID, Vector2Int in_position)
        {
            return TrySetParquet(in_furnishingID, in_position, _furnishingLayer);
        }

        /// <summary>
        /// Attempts to update the collectible parquet at the given position.
        /// </summary>
        /// <param name="in_collectibleID">ID for the new collectible to set.</param>
        /// <param name="in_position">The position to set.</param>
        /// <returns><c>true</c>, if the collectible was set, <c>false</c> otherwise.</returns>
        public bool TrySetCollectible(EntityID in_collectibleID, Vector2Int in_position)
        {
            return TrySetParquet(in_collectibleID, in_position, _collectibleLayer);
        }

        /// <summary>
        /// Attempts to update the parquet at the given position in the given layer.
        /// </summary>
        /// <param name="in_parquetID">The parquet to put.</param>
        /// <param name="in_position">The position to put the parquet in.</param>
        /// <param name="in_parquetLayer">The layer to put the parquet on.</param>
        /// <returns><c>true</c>, if the parquet was removed, <c>false</c> otherwise.</returns>
        private bool TrySetParquet(EntityID in_parquetID, Vector2Int in_position, EntityID[,] in_parquetLayer)
        {
            var result = false;
            if (IsValidPosition(in_position) && EntityID.None != in_parquetID)
            {
                in_parquetLayer[in_position.X, in_position.Y] = in_parquetID;
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Attempts to remove the floor parquet at the given position.
        /// </summary>
        /// <param name="in_position">The position to clear.</param>
        /// <returns><c>true</c>, if the floor was removed, <c>false</c> otherwise.</returns>
        public bool TryRemoveFloor(Vector2Int in_position)
        {
            return TryRemoveParquet(in_position, _floorLayer);
        }

        /// <summary>
        /// Attempts to remove the block parquet at the given position.
        /// </summary>
        /// <param name="in_position">The position to clear.</param>
        /// <returns><c>true</c>, if the block was removed, <c>false</c> otherwise.</returns>
        public bool TryRemoveBlock(Vector2Int in_position)
        {
            return TryRemoveParquet(in_position, _blockLayer);
        }

        /// <summary>
        /// Attempts to remove the furnishing parquet at the given position.
        /// </summary>
        /// <param name="in_position">The position to clear.</param>
        /// <returns><c>true</c>, if the furnishing was removed, <c>false</c> otherwise.</returns>
        public bool TryRemoveFurnishing(Vector2Int in_position)
        {
            return TryRemoveParquet(in_position, _furnishingLayer);
        }

        /// <summary>
        /// Attempts to update the collectible parquet at the given position.
        /// </summary>
        /// <param name="in_position">The position to clear.</param>
        /// <returns><c>true</c>, if the collectible was removed, <c>false</c> otherwise.</returns>
        public bool TryRemoveCollectible(Vector2Int in_position)
        {
            return TryRemoveParquet(in_position, _collectibleLayer);
        }

        /// <summary>
        /// Attempts to update the parquet at the given position in the given layer.
        /// </summary>
        /// <param name="in_position">The position to clear.</param>
        /// <param name="in_parquetLayer">The layer to clear.</param>
        /// <returns><c>true</c>, if the parquet was removed, <c>false</c> otherwise.</returns>
        private bool TryRemoveParquet(Vector2Int in_position, EntityID[,] in_parquetLayer)
        {
            var result = false;
            if (IsValidPosition(in_position))
            {
                in_parquetLayer[in_position.X, in_position.Y] = EntityID.None;
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
        {
            return TryRemoveSpecialPoint(in_point);
        }

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
        {
            return TryRemoveSpecialPoint(in_point);
        }

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
        {
            ParquetStatus result = null;

            if (IsValidPosition(in_position))
            {
                result = _parquetStatus[in_position.X, in_position.Y];
            }

            return result;
        }

        /// <summary>
        /// Gets any floor parquet at the position.
        /// </summary>
        /// <param name="in_position">The position whose floor is sought.</param>
        /// <returns>The floor at the given position, or <c>null</c> if there is none.</returns>
        public Floor GetFloorAtPosition(Vector2Int in_position)
        {
            Floor result = null;

            if (IsValidPosition(in_position))
            {
                result = AllParquets.Get<Floor>(_floorLayer[in_position.X, in_position.Y]);
            }

            return result;
        }

        /// <summary>
        /// Gets any block parquet at the position.
        /// </summary>
        /// <param name="in_position">The position whose block is sought.</param>
        /// <returns>The block at the given position, or <c>null</c> if there is none.</returns>
        public Block GetBlockAtPosition(Vector2Int in_position)
        {
            Block result = null;

            if (IsValidPosition(in_position))
            {
                result = AllParquets.Get<Block>(_blockLayer[in_position.X, in_position.Y]);
            }

            return result;
        }

        /// <summary>
        /// Gets any furnishing parquet at the position.
        /// </summary>
        /// <param name="in_position">The position whose furnishing  is sought.</param>
        /// <returns>The furnishing  at the given position, or <c>null</c> if there is none.</returns>
        public Furnishing GetFurnishingAtPosition(Vector2Int in_position)
        {
            Furnishing result = null;

            if (IsValidPosition(in_position))
            {
                result = AllParquets.Get<Furnishing>(_furnishingLayer[in_position.X, in_position.Y]);
            }

            return result;
        }

        /// <summary>
        /// Gets any collectible parquet at the position.
        /// </summary>
        /// <param name="in_position">The position whose collectible is sought.</param>
        /// <returns>The collectible at the given position, or <c>null</c> if there is none.</returns>
        public Collectible GetCollectibleAtPosition(Vector2Int in_position)
        {
            Collectible result = null;

            if (IsValidPosition(in_position))
            {
                result = AllParquets.Get<Collectible>(_collectibleLayer[in_position.X, in_position.Y]);
            }

            return result;
        }

        /// <summary>
        /// Gets any parquets at the position.
        /// </summary>
        /// <param name="in_position">The position whose parquets are sought.</param>
        /// <returns>The parquets at the given position, if any.</returns>
        public ParquetStack GetAllParquetsAtPosition(Vector2Int in_position)
        {
            return new ParquetStack(GetFloorAtPosition(in_position),
                                    GetBlockAtPosition(in_position),
                                    GetFurnishingAtPosition(in_position),
                                    GetCollectibleAtPosition(in_position));
        }

        /// <summary>
        /// Gets all the parquets in the entire map.
        /// </summary>
        /// <returns>A collection of parquets.</returns>
        public IEnumerable<ParquetParent> GetAllParquets()
        {
            var result = new List<ParquetParent>();

            for (var x = 0; x < DimensionsInParquets.X; x++)
            {
                for (var y = 0; y < DimensionsInParquets.Y; y++)
                {
                    var parquetID = _floorLayer[x, y];
                    if (EntityID.None != parquetID) { result.Add(AllParquets.Get<Floor>(parquetID)); }
                    parquetID = _blockLayer[x, y];
                    if (EntityID.None != parquetID) { result.Add(AllParquets.Get<Block>(parquetID)); }
                    parquetID = _furnishingLayer[x, y];
                    if (EntityID.None != parquetID) { result.Add(AllParquets.Get<Furnishing>(parquetID)); }
                    parquetID = _collectibleLayer[x, y];
                    if (EntityID.None != parquetID) { result.Add(AllParquets.Get<Collectible>(parquetID)); }
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
        {
            return _specialPoints.FindAll(in_point => in_point.Position.Equals(in_position));
        }
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
        /// Determines if the given position corresponds to a point on the map.
        /// </summary>
        /// <param name="in_position">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public bool IsValidPosition(Vector2Int in_position)
        {
            return in_position.X > -1
                && in_position.Y > -1
                && in_position.X < DimensionsInParquets.X
                && in_position.Y < DimensionsInParquets.Y;
        }

        /// <summary>
        /// Visualizes the map as a string with merged layers.
        /// Intended for Console debugging.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current map.</returns>
        internal string DumpMap()
        {
            var representation = new StringBuilder(DimensionsInParquets.Magnitude);
            #region Compose visual represenation of contents.
            for (var x = 0; x < DimensionsInParquets.X; x++)
            {
                for (var y = 0; y < DimensionsInParquets.Y; y++)
                {
                    // TODO: This fails with TestParquet values.  Do we want to support ToStringing test values??
                    var parquet = EntityID.None != _collectibleLayer[x, y]
                        ? AllParquets.Get<ParquetParent>(_collectibleLayer[x, y]) 
                        : EntityID.None != _furnishingLayer[x, y]
                            ? AllParquets.Get<ParquetParent>(_furnishingLayer[x, y])
                            : EntityID.None != _blockLayer[x, y]
                                ? AllParquets.Get<ParquetParent>(_blockLayer[x, y])
                                : EntityID.None != _floorLayer[x, y]
                                    ? AllParquets.Get<ParquetParent>(_floorLayer[x, y])
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
        /// <returns>A <see cref="T:System.String"/> that represents the current map.</returns>
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
                    floorRepresentation.Append(EntityID.None != _floorLayer[x, y]
                        ? _floorLayer[x, y].ToString()
                        : "~");
                    blocksRepresentation.Append(EntityID.None != _blockLayer[x, y]
                        ? _blockLayer[x, y].ToString()
                        : " ");
                    furnishingsRepresentation.Append(EntityID.None != _furnishingLayer[x, y]
                        ? _furnishingLayer[x, y].ToString()
                        : " ");
                    collectiblesRepresentation.Append(EntityID.None != _collectibleLayer[x, y]
                        ? _collectibleLayer[x, y].ToString()
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
        /// Describes the map as a string containing basic information.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current map.</returns>
        public override string ToString()
        {
            return $"({DimensionsInParquets.X }, {DimensionsInParquets.Y}) contains {ParquetsCount} parquets and {_specialPoints.Count} special points.";
        }
        #endregion
    }
}
