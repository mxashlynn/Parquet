using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using ParquetClassLibrary.Sandbox.SpecialPoints;
using ParquetClassLibrary.Sandbox.Parquets;
using ParquetClassLibrary.Sandbox.ID;
using ParquetClassLibrary.Stubs;

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
        protected readonly string DataVersion = Assembly.SupportedDataVersion;

        /// <summary>Tracks how many times the data structure has been serialized.</summary>
        public int Revision { get; protected set; } = 0;
        #endregion

        #region Map Contents
        /// <summary>Exit, spawn, and other special points in the region.</summary>
        protected readonly List<SpecialPoint> _specialPoints = new List<SpecialPoint>();

        /// <summary>Floors and walkable terrain in the region.</summary>
        protected abstract EnitityID[,] _floorLayer { get; }

        /// <summary>Walls and obstructing terrain in the region.</summary>
        protected abstract EnitityID[,] _blockLayer { get; }

        /// <summary>Furniture and natural items in the region.</summary>
        protected abstract EnitityID[,] _furnishingLayer { get; }

        /// <summary>Collectable materials in the region.</summary>
        protected abstract EnitityID[,] _collectableLayer { get; }
        #endregion

        #region Parquets Replacement Methods
        /// <summary>
        /// Attempts to update the floor parquet at the given position.
        /// </summary>
        /// <param name="in_floorID">ID for the new floor to set.</param>
        /// <param name="in_position">The position to set.</param>
        /// <returns><c>true</c>, if the floor was set, <c>false</c> otherwise.</returns>
        public bool TrySetFloor(EnitityID in_floorID, Vector2Int in_position)
        {
            return TrySetParquet(in_floorID, in_position, _floorLayer);
        }

        /// <summary>
        /// Attempts to update the block parquet at the given position.
        /// </summary>
        /// <param name="in_blockID">ID for the new block to set.</param>
        /// <param name="in_position">The position to set.</param>
        /// <returns><c>true</c>, if the block was set, <c>false</c> otherwise.</returns>
        public bool TrySetBlock(EnitityID in_blockID, Vector2Int in_position)
        {
            return TrySetParquet(in_blockID, in_position, _blockLayer);
        }

        /// <summary>
        /// Attempts to update the furnishing parquet at the given position.
        /// </summary>
        /// <param name="in_furnishingID">ID for the new furnishing to set.</param>
        /// <param name="in_position">The position to set.</param>
        /// <returns><c>true</c>, if the furnishing was set, <c>false</c> otherwise.</returns>
        public bool TrySetFurnishing(EnitityID in_furnishingID, Vector2Int in_position)
        {
            return TrySetParquet(in_furnishingID, in_position, _furnishingLayer);
        }

        /// <summary>
        /// Attempts to update the collectable parquet at the given position.
        /// </summary>
        /// <param name="in_collectableID">ID for the new collectable to set.</param>
        /// <param name="in_position">The position to set.</param>
        /// <returns><c>true</c>, if the collectable was set, <c>false</c> otherwise.</returns>
        public bool TrySetCollectable(EnitityID in_collectableID, Vector2Int in_position)
        {
            return TrySetParquet(in_collectableID, in_position, _collectableLayer);
        }

        /// <summary>
        /// Attempts to update the parquet at the given position in the given layer.
        /// </summary>
        /// <param name="in_position">The position to clear.</param>
        /// <returns><c>true</c>, if the parquet was removed, <c>false</c> otherwise.</returns>
        private bool TrySetParquet(EnitityID in_parquetID, Vector2Int in_position, EnitityID[,] in_parquetLayer)
        {
            var result = false;
            if (IsValidPosition(in_position) && EnitityID.None != in_parquetID)
            {
                in_parquetLayer[in_position.x, in_position.y] = in_parquetID;
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
        /// Attempts to update the collectable parquet at the given position.
        /// </summary>
        /// <param name="in_position">The position to clear.</param>
        /// <returns><c>true</c>, if the collectable was removed, <c>false</c> otherwise.</returns>
        public bool TryRemoveCollectable(Vector2Int in_position)
        {
            return TryRemoveParquet(in_position, _collectableLayer);
        }

        /// <summary>
        /// Attempts to remove all parquets at the given position.
        /// </summary>
        /// <param name="in_position">The position to clear.</param>
        /// <returns><c>true</c>, if the position was entirely cleared, <c>false</c> otherwise.</returns>
        private bool TryRemoveAll(Vector2Int in_position)
        {
            return TryRemoveFloor(in_position)
                && TryRemoveBlock(in_position)
                && TryRemoveFurnishing(in_position)
                && TryRemoveCollectable(in_position);
        }

        /// <summary>
        /// Attempts to update the parquet at the given position in the given layer.
        /// </summary>
        /// <param name="in_position">The position to clear.</param>
        /// <returns><c>true</c>, if the parquet was removed, <c>false</c> otherwise.</returns>
        private bool TryRemoveParquet(Vector2Int in_position, EnitityID[,] in_parquetLayer)
        {
            var result = false;
            if (IsValidPosition(in_position))
            {
                in_parquetLayer[in_position.x, in_position.y] = EnitityID.None;
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
                         !_specialPoints.Exists(foundPoint =>
                             foundPoint.GetType() == in_point.GetType() && foundPoint == in_point);
            }

            return result;
        }
        #endregion

        #region State Query Methods
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
                result = AllParquets.Get<Floor>(_floorLayer[in_position.x, in_position.y]);
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
                result = AllParquets.Get<Block>(_blockLayer[in_position.x, in_position.y]);
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
                result = AllParquets.Get<Furnishing>(_furnishingLayer[in_position.x, in_position.y]);
            }

            return result;
        }

        /// <summary>
        /// Gets any collectable parquet at the position.
        /// </summary>
        /// <param name="in_position">The position whose collectable is sought.</param>
        /// <returns>The collectable at the given position, or <c>null</c> if there is none.</returns>
        public Collectable GetCollectableAtPosition(Vector2Int in_position)
        {
            Collectable result = null;

            if (IsValidPosition(in_position))
            {
                result = AllParquets.Get<Collectable>(_collectableLayer[in_position.x, in_position.y]);
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
                                    GetCollectableAtPosition(in_position));
        }

        /// <summary>
        /// Gets all the parquets in the entire region.
        /// </summary>
        /// <returns>A collection of parquets.</returns>
        public IEnumerable<ParquetParent> GetAllParquets()
        {
            var result = new List<ParquetParent>();

            for (var x = 0; x < DimensionsInParquets.x; x++)
            {
                for (var y = 0; y < DimensionsInParquets.y; y++)
                {
                    EnitityID parquetID = _floorLayer[x, y];
                    if (EnitityID.None != parquetID) { result.Add(AllParquets.Get<Floor>(parquetID)); }
                    parquetID = _blockLayer[x, y];
                    if (EnitityID.None != parquetID) { result.Add(AllParquets.Get<Block>(parquetID)); }
                    parquetID = _furnishingLayer[x, y];
                    if (EnitityID.None != parquetID) { result.Add(AllParquets.Get<Furnishing>(parquetID)); }
                    parquetID = _collectableLayer[x, y];
                    if (EnitityID.None != parquetID) { result.Add(AllParquets.Get<Collectable>(parquetID)); }
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
            return _specialPoints.FindAll(point => point.Position.Equals(in_position));
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
        /// Determines if the given position corresponds to a point in the region.
        /// </summary>
        /// <param name="in_position">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public bool IsValidPosition(Vector2Int in_position)
        {
            return in_position.x > -1
                && in_position.y > -1
                && in_position.x < DimensionsInParquets.x
                && in_position.y < DimensionsInParquets.y;
        }

        /// <summary>
        /// Visualizes the region as a string with merged layers.
        /// Intended for Console debugging.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:ParquetClassLibrary.Sandbox.MapParent"/>.</returns>
        public override string ToString()
        {
            var representation = new StringBuilder(DimensionsInParquets.Magnitude);
            #region Compose visual represenation of contents.
            for (var x = 0; x < DimensionsInParquets.x; x++)
            {
                for (var y = 0; y < DimensionsInParquets.y; y++)
                {
                    // TODO: This fails with TestParquet values.  Do we want to support ToStringing test values??
                    var parquet = EnitityID.None != _collectableLayer[x, y]
                        ? AllParquets.Get<ParquetParent>(_collectableLayer[x, y]) 
                        : EnitityID.None != _furnishingLayer[x, y]
                            ? AllParquets.Get<ParquetParent>(_furnishingLayer[x, y])
                            : EnitityID.None != _blockLayer[x, y]
                                ? AllParquets.Get<ParquetParent>(_blockLayer[x, y])
                                : EnitityID.None != _floorLayer[x, y]
                                    ? AllParquets.Get<ParquetParent>(_floorLayer[x, y])
                                    : null;

                    representation.Append(parquet?.ToString() ?? "~");
                }
                representation.AppendLine();
            }
            #endregion

            return representation.ToString();
        }
        #endregion
    }
}
