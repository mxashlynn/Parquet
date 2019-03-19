using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParquetClassLibrary.Sandbox.SpecialPoints;
using ParquetClassLibrary.Sandbox.Parquets;
using ParquetClassLibrary.Sandbox.ID;
using ParquetClassLibrary.Stubs;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Sandbox
{
    /// <summary>
    /// Models details of a playable chunk in sandbox-mode.
    /// Map Chunks are composed of Parquets and Special Points.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class MapChunk
    {
        #region Class Defaults
        /// <summary>The chunk's dimensions in parquets.</summary>
        public static readonly Vector2Int DimensionsInParquets = new Vector2Int(Assembly.ParquetsPerChunkDimension,
                                                                                Assembly.ParquetsPerChunkDimension);
        #endregion

        #region Whole-Region Characteristics
        /// <summary>
        /// Describes the version of serialized data.
        /// Allows selecting data files that can be successfully deserialized.
        /// </summary>
        public readonly string DataVersion = Assembly.SupportedDataVersion;

        /// <summary>Tracks how many times the data structure has been serialized.</summary>
        public int Revision { get; private set; } = 0;

        /// <summary>Exit, spawn, and other special points in the region.</summary>
        private readonly List<SpecialPoint> _specialPoints = new List<SpecialPoint>();
        #endregion

        #region Region Parquet Contents
        // TODO Change these to IDs as well
        /// <summary>Floors and walkable terrain in the region.</summary>
        private readonly ParquetID[,] _floorLayer = new ParquetID[DimensionsInParquets.x, DimensionsInParquets.y];

        /// <summary>Walls and obstructing terrain in the region.</summary>
        private readonly ParquetID[,] _blockLayer = new ParquetID[DimensionsInParquets.x, DimensionsInParquets.y];

        /// <summary>Furniture and natural items in the region.</summary>
        private readonly ParquetID[,] _furnishingLayer = new ParquetID[DimensionsInParquets.x, DimensionsInParquets.y];

        /// <summary>Collectable materials in the region.</summary>
        private readonly ParquetID[,] _collectableLayer = new ParquetID[DimensionsInParquets.x, DimensionsInParquets.y];
        #endregion

        #region Parquets Replacement Methods
        /// <summary>
        /// Attempts to update the floor parquet at the given position.
        /// </summary>
        /// <param name="in_floorID">ID for the new floor to set.</param>
        /// <param name="in_position">The position to set.</param>
        /// <returns><c>true</c>, if the floor was set, <c>false</c> otherwise.</returns>
        public bool TrySetFloor(ParquetID in_floorID, Vector2Int in_position)
        {
            return TrySetParquet(in_floorID, in_position, _floorLayer);
        }

        /// <summary>
        /// Attempts to update the block parquet at the given position.
        /// </summary>
        /// <param name="in_blockID">ID for the new block to set.</param>
        /// <param name="in_position">The position to set.</param>
        /// <returns><c>true</c>, if the block was set, <c>false</c> otherwise.</returns>
        public bool TrySetBlock(ParquetID in_blockID, Vector2Int in_position)
        {
            return TrySetParquet(in_blockID, in_position, _blockLayer);
        }

        /// <summary>
        /// Attempts to update the furnishing parquet at the given position.
        /// </summary>
        /// <param name="in_furnishingID">ID for the new furnishing to set.</param>
        /// <param name="in_position">The position to set.</param>
        /// <returns><c>true</c>, if the furnishing was set, <c>false</c> otherwise.</returns>
        public bool TrySetFurnishing(ParquetID in_furnishingID, Vector2Int in_position)
        {
            return TrySetParquet(in_furnishingID, in_position, _furnishingLayer);
        }

        /// <summary>
        /// Attempts to update the collectable parquet at the given position.
        /// </summary>
        /// <param name="in_collectableID">ID for the new collectable to set.</param>
        /// <param name="in_position">The position to set.</param>
        /// <returns><c>true</c>, if the collectable was set, <c>false</c> otherwise.</returns>
        public bool TrySetCollectable(ParquetID in_collectableID, Vector2Int in_position)
        {
            return TrySetParquet(in_collectableID, in_position, _collectableLayer);
        }

        /// <summary>
        /// Attempts to update the parquet at the given position in the given layer.
        /// </summary>
        /// <param name="in_position">The position to clear.</param>
        /// <returns><c>true</c>, if the parquet was removed, <c>false</c> otherwise.</returns>
        private bool TrySetParquet(ParquetID in_parquetID, Vector2Int in_position, ParquetID[,] in_parquetLayer)
        {
            var result = false;
            if (IsValidPosition(in_position) && ParquetID.None != in_parquetID)
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
        private bool TryRemoveParquet(Vector2Int in_position, ParquetID[,] in_parquetLayer)
        {
            var result = false;
            if (IsValidPosition(in_position))
            {
                in_parquetLayer[in_position.x, in_position.y] = ParquetID.None;
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
        /// Serializes to the current MapChunk to a string,
        /// incrementing the revision number in the process.
        /// </summary>
        /// <returns>The serialized MapChunk.</returns>
        public string SerializeToString()
        {
            Revision++;
            return JsonConvert.SerializeObject(this, Formatting.None);
        }

        /// <summary>
        /// Tries to deserialize a MapChunk from the given string.
        /// </summary>
        /// <param name="in_serializedMapChunk">The serialized region map.</param>
        /// <param name="out_mapChunk">The deserialized region map, or null if deserialization was impossible.</param>
        /// <returns><c>true</c>, if deserialize was posibile, <c>false</c> otherwise.</returns>
        public static bool TryDeserializeFromString(string in_serializedMapChunk,
                                                    out MapChunk out_mapChunk)
        {
            var result = false;
            out_mapChunk = null;

            if (string.IsNullOrEmpty(in_serializedMapChunk))
            {
                Error.Handle("Error deserializing a MapChunk.");
            }
            else
            {
                // Determine what version of region map was serialized.
                try
                {
                    var document = JObject.Parse(in_serializedMapChunk);
                    var version = document?.Value<string>(nameof(DataVersion));

                    // Deserialize only if this class supports the version given.
                    if (Assembly.SupportedDataVersion.Equals(version, StringComparison.OrdinalIgnoreCase))
                    {
                        out_mapChunk = JsonConvert.DeserializeObject<MapChunk>(in_serializedMapChunk);
                        result = true;
                    }
                }
                catch (JsonReaderException exception)
                {
                    Error.Handle("Error reading string while deserializing a MapChunk: " + exception);
                }
            }

            return result;
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
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:ParquetClassLibrary.Sandbox.MapChunk"/>.</returns>
        public override string ToString()
        {
            var representation = new StringBuilder(DimensionsInParquets.Magnitude);
            #region Compose visual represenation of contents.
            for (var x = 0; x < DimensionsInParquets.x; x++)
            {
                for (var y = 0; y < DimensionsInParquets.y; y++)
                {
                    representation.Append(ParquetID.None != _collectableLayer[x, y]
                            ? _collectableLayer[x, y].ToString()
                            : ParquetID.None != _furnishingLayer[x, y]
                                ? _furnishingLayer[x, y].ToString()
                                : ParquetID.None != _blockLayer[x, y]
                                    ? _blockLayer[x, y].ToString()
                                    : ParquetID.None != _floorLayer[x, y]
                                        ? _floorLayer[x, y].ToString()
                                        : "@");
                }
                representation.AppendLine();
            }
            #endregion

            return "Chunk: \n" + representation;
        }
        #endregion
    }
}
