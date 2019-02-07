using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParquetClassLibrary.Sandbox.SpecialPoints;
using ParquetClassLibrary.Sandbox.Parquets;
using ParquetClassLibrary.Stubs;

namespace ParquetClassLibrary.Sandbox
{
    /// <summary>
    /// Scriptable Object containing details of a playable region in sandbox-mode.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class RegionMap
    {
        #region Class Defaults
        /// <summary>Describes the version of the serialized data that this class understands.</summary>
        public const string SupportedDataVersion = "0.1.0";

        /// <summary>The region's dimensions.</summary>
        // TODO Come up with actual size of regions, (and consider making this editable in Unity?  But maybe not.)
        public static readonly Vector2Int Dimensions = new Vector2Int(5, 5);

        /// <summary>Default name for new regions.</summary>
        // TODO Change this test name once debugging is done.
        public const string DefaultTitle = "Erdrea";
        #endregion

        #region Whole-Region Characteristics
        /// <summary>
        /// Describes the version of serialized data.
        /// Allows selecting data files that can be successfully deserialized.
        /// </summary>
        public string DataVersion { get; private set; } = SupportedDataVersion;

        /// <summary>What the region is called in-game.</summary>
        public string Title { get; private set; } = DefaultTitle;

        /// <summary>A color to display in any empty areas of the region.</summary>
        public Color Background { get; private set; } = Color.White;

        /// <summary>Tracks how many times the data structure has been serialized.</summary>
        public int Revision { get; private set; } = 0;

        /// <summary>Floors and walkable terrain in the region.</summary>
        private readonly List<SpecialPoint> _specialPoints = new List<SpecialPoint>();
        #endregion

        #region Region Parquet Contents
        /// <summary>Floors and walkable terrain in the region.</summary>
        private readonly Floor[,] _floorLayer = new Floor[Dimensions.x, Dimensions.y];

        /// <summary>Walls and obstructing terrain in the region.</summary>
        private readonly Block[,] _blockLayer = new Block[Dimensions.x, Dimensions.y];

        /// <summary>Furniture and natural items in the region.</summary>
        private readonly Furnishing[,] _furnishingLayer = new Furnishing[Dimensions.x, Dimensions.y];

        /// <summary>Collectable materials in the region.</summary>
        private readonly Collectable[,] _collectableLayer = new Collectable[Dimensions.x, Dimensions.y];

        // IDEA: a foreground layer?
        #endregion

        #region Initialization
        /// <summary>
        /// Constructs a new instance of the <see cref="T:ParquetClassLibrary.Sandbox.RegionMap"/> class.
        /// </summary>
        /// <param name="in_title">The name of the new region.</param>
        /// <param name="in_background">Background color for the new region.</param>
        public RegionMap(string in_title = DefaultTitle, Color? in_background = null)
            // Assign defaults that cannot be specified in the argument list.
            => Background = in_background ?? Color.White;
        #endregion

        #region State Modification Methods
        #region Parquets Replacement Methods
        /// <summary>
        /// Attempts to update the floor parquet at the given position.
        /// </summary>
        /// <param name="in_floor">The new floor to set.</param>
        /// <param name="in_position">The position to set.</param>
        /// <returns><c>true</c>, if the floor was set, <c>false</c> otherwise.</returns>
        public bool TrySetFloor(Floor in_floor, Vector2Int in_position)
        {
            return TrySetParquet(in_floor, in_position, _floorLayer);
        }

        /// <summary>
        /// Attempts to update the block parquet at the given position.
        /// </summary>
        /// <param name="in_block">The new block to set.</param>
        /// <param name="in_position">The position to set.</param>
        /// <returns><c>true</c>, if the block was set, <c>false</c> otherwise.</returns>
        public bool TrySetBlock(Block in_block, Vector2Int in_position)
        {
            return TrySetParquet(in_block, in_position, _blockLayer);
        }

        /// <summary>
        /// Attempts to update the furnishing parquet at the given position.
        /// </summary>
        /// <param name="in_furnishing">The new furnishing to set.</param>
        /// <param name="in_position">The position to set.</param>
        /// <returns><c>true</c>, if the furnishing was set, <c>false</c> otherwise.</returns>
        public bool TrySetFurnishing(Furnishing in_furnishing, Vector2Int in_position)
        {
            return TrySetParquet(in_furnishing, in_position, _furnishingLayer);
        }

        /// <summary>
        /// Attempts to update the collectable parquet at the given position.
        /// </summary>
        /// <param name="in_collectable">The new collectable to set.</param>
        /// <param name="in_position">The position to set.</param>
        /// <returns><c>true</c>, if the collectable was set, <c>false</c> otherwise.</returns>
        public bool TrySetCollectable(Collectable in_collectable, Vector2Int in_position)
        {
            return TrySetParquet(in_collectable, in_position, _collectableLayer);
        }

        /// <summary>
        /// Attempts to update the parquet at the given position in the given layer.
        /// </summary>
        /// <param name="in_position">The position to clear.</param>
        /// <returns><c>true</c>, if the parquet was removed, <c>false</c> otherwise.</returns>
        private bool TrySetParquet(ParquetParent in_parquet, Vector2Int in_position, object[,] in_parquetLayer)
        {
            var result = false;
            if (IsValidPosition(in_position) && null != in_parquet)
            {
                // Note: This is an opportunity to introduce Object Pooling should it become neccessary.
                in_parquetLayer[in_position.x, in_position.y] = in_parquet;
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
        private bool TryRemoveParquet(Vector2Int in_position, object[,] in_parquetLayer)
        {
            var result = false;
            if (IsValidPosition(in_position))
            {
                // Note: This is an opportunity to introduce Object Pooling should it become neccessary.
                in_parquetLayer[in_position.x, in_position.y] = null;
                result = true;
            }
            return result;
        }
        #endregion

        #region Parquet Property Modifcation Methods
        /// <summary>
        /// Tries to dig in the specified location.
        /// 
        /// Note that it is not the responsibilty of the RegionMap to determine if game rules
        /// are being violated.  Only bounds-checking and basic data validation is performed.
        /// </summary>
        /// <param name="in_position">The position at which to attempt digging.</param>
        /// <returns><c>true</c>, if the position was valid, <c>false</c> otherwise.</returns>
        public bool TryDig(Vector2Int in_position)
        {
            var result = false;

            if (IsValidPosition(in_position)
                && null != _floorLayer[in_position.x, in_position.y])
            {
                _floorLayer[in_position.x, in_position.y].isHole = true;
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Tries to fill in the specified location.
        /// 
        /// Note that it is not the responsibilty of the RegionMap to determine if game rules
        /// are being violated.  Only bounds-checking and basic data validation is performed.
        /// </summary>
        /// <param name="in_position">The position at which to attempt filling.</param>
        /// <returns><c>true</c>, if the position was valid, <c>false</c> otherwise.</returns>
        public bool TryFill(Vector2Int in_position)
        {
            var result = false;

            if (IsValidPosition(in_position)
                && null != _floorLayer[in_position.x, in_position.y])
            {
                _floorLayer[in_position.x, in_position.y].isHole = false;
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Tries to decrese the toughness of the block or furnishing at the given position.
        /// 
        /// Note that it is not the responsibilty of the RegionMap to determine if game rules
        /// are being violated.  Only bounds-checking and basic data validation is performed.
        /// </summary>
        /// <param name="in_position">The position whose toughness should be reduced.</param>
        /// <param name="in_amount">The amount of toughness to reduce.</param>
        /// <returns><c>true</c>, if toughness was reduced, <c>false</c> otherwise.</returns>
        public bool TryReduceToughness(Vector2Int in_position, int in_amount)
        {
            var result = false;

            if (in_amount > 0
                && IsValidPosition(in_position)
                && null != _blockLayer[in_position.x, in_position.y])
            {
                _blockLayer[in_position.x, in_position.y].Toughness -= in_amount;
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Tries to reset the toughness of the block or furnishing at the given position.
        /// 
        /// Note that it is not the responsibilty of the RegionMap to determine if game rules
        /// are being violated.  Only bounds-checking and basic data validation is performed.
        /// </summary>
        /// <param name="in_position">The position whose toughness should be restored.</param>
        /// <returns><c>true</c>, if toughness was restored, <c>false</c> otherwise.</returns>
        public bool TryRestoreToughness(Vector2Int in_position)
        {
            var result = false;

            if (IsValidPosition(in_position)
                && null != _blockLayer[in_position.x, in_position.y])
            {
                _blockLayer[in_position.x, in_position.y].Toughness =
                    _blockLayer[in_position.x, in_position.y].MaxToughness;
                result = true;
            }

            return result;
        }
        #endregion

        #region Special Point Modification
        /// <summary>
        /// Attempts to assign an exit point to the given location.
        /// If an exit point already exists at this location, it is replaced.
        /// </summary>
        /// <param name="in_point">The point to set.</param>
        /// <returns><c>true</c>, if the exit point was set, <c>false</c> otherwise.</returns>
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
        /// Attempts to remove a point to the given location.
        /// If an exit point already exists at this location, it is replaced.
        /// </summary>
        /// <param name="in_point">The point to remove.</param>
        /// <returns><c>true</c>, if the point was not found or if it was found and removed, <c>false</c> otherwise.</returns>
        public bool TryRemoveExitPoint(ExitPoint in_point)
        {
            return TryRemoveSpecialPoint(in_point);
        }

        /// <summary>
        /// Attempts to assign a spawn point to the given location.
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
        /// Attempts to remove a point to the given location.
        /// If an exit point already exists at this location, it is replaced.
        /// </summary>
        /// <param name="in_point">The point to remove.</param>
        /// <returns><c>true</c>, if the point was not found or if it was found and removed, <c>false</c> otherwise.</returns>
        public bool TryRemoveSpawnPoint(SpawnPoint in_point)
        {
            return TryRemoveSpecialPoint(in_point);
        }

        /// <summary>
        /// Attempts to remove a point to the given location.
        /// If an exit point already exists at this location, it is replaced.
        /// </summary>
        /// <param name="in_point">The point to remove.</param>
        /// <returns><c>true</c>, if the point was not found or if it was found and removed, <c>false</c> otherwise.</returns>
        private bool TryRemoveSpecialPoint(SpecialPoint in_point)
        {
            var result = false;

            // Note: This is an opportunity to introduce Object Pooling should it become neccessary.
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
        #endregion

        #region State Query Methods
        /// <summary>
        /// Checks if the given position is open to walking characters.
        /// </summary>
        /// <param name="in_position">The position to check.</param>
        /// <returns><c>true</c>, if position is walkable, <c>false</c> otherwise.</returns>
        public bool IsFloorWalkable(Vector2Int in_position)
        {
            var result = false;

            if (IsValidPosition(in_position)
                && null != _floorLayer[in_position.x, in_position.y])
            {
                result = _floorLayer[in_position.x, in_position.y].isWalkable;
            }

            return result;
        }

        /// <summary>
        /// Checks if the given position has been dug out.
        /// </summary>
        /// <param name="in_position">The position to check.</param>
        /// <returns><c>true</c>, if position is a hole, <c>false</c> otherwise.</returns>
        public bool IsFloorAHole(Vector2Int in_position)
        {
            var result = false;

            if (IsValidPosition(in_position)
                && null != _floorLayer[in_position.x, in_position.y])
            {
                result = _floorLayer[in_position.x, in_position.y].isHole;
            }

            return result;
        }

        /// <summary>
        /// Checks if the given position contains a flammable block or furnishing.
        /// </summary>
        /// <param name="in_position">The position to check.</param>
        /// <returns><c>true</c>, if position contains a flammable item, <c>false</c> otherwise.</returns>
        public bool IsBlockFlammable(Vector2Int in_position)
        {
            var result = false;

            if (IsValidPosition(in_position)
                && null != _blockLayer[in_position.x, in_position.y])
            {
                result = _blockLayer[in_position.x, in_position.y].IsFlammable;
            }

            return result;
        }

        /// <summary>
        /// Checks if the given position contains a liquid.
        /// </summary>
        /// <param name="in_position">The position to check.</param>
        /// <returns><c>true</c>, if position contains a liquid, <c>false</c> otherwise.</returns>
        public bool IsBlockALiquid(Vector2Int in_position)
        {
            var result = false;

            if (IsValidPosition(in_position)
                && null != _blockLayer[in_position.x, in_position.y])
            {
                result = _blockLayer[in_position.x, in_position.y].IsLiquid;
            }

            return result;
        }

        /// <summary>
        /// Gets the position toughness.
        /// </summary>
        /// <param name="in_position">The position whose toughness is sought.</param>
        /// <returns>Toughtness at the given position</returns>
        public int GetBlockToughnessAtPosition(Vector2Int in_position)
        {
            int result = 0;

            if (IsValidPosition(in_position)
                && null != _blockLayer[in_position.x, in_position.y])
            {
                result = _blockLayer[in_position.x, in_position.y].Toughness;
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
                result = _floorLayer[in_position.x, in_position.y];
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
                result = _blockLayer[in_position.x, in_position.y];
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
                result = _furnishingLayer[in_position.x, in_position.y];
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
                result = _collectableLayer[in_position.x, in_position.y];
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
        /// Serializes to the current RegionMap to a string.
        /// </summary>
        /// <returns>The serialized RegionMap.</returns>
        public string SerializeToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }

        /// <summary>
        /// Tries to deserialize a RegionMap from the given string.
        /// </summary>
        /// <param name="in_serializedRegionMap">The serialized region map.</param>
        /// <param name="out_regionMap">The deserialized region map, or null if deserialization was impossible.</param>
        /// <returns><c>true</c>, if deserialize was posibile, <c>false</c> otherwise.</returns>
        public static bool TryDeserializeFromString(string in_serializedRegionMap,
                                                    out RegionMap out_regionMap)
        {
            var result = false;
            out_regionMap = null;

            // Determine what version of region map was serialized.
            var dataFragment = JObject.Parse(in_serializedRegionMap);
            var version = dataFragment.Value<string>(nameof(DataVersion));

            // Deserialize only if this class supports the version given.
            if (SupportedDataVersion.Equals(version, StringComparison.OrdinalIgnoreCase))
            {
                out_regionMap = JsonConvert.DeserializeObject<RegionMap>(in_serializedRegionMap);
                result = true;
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
        private bool IsValidPosition(Vector2Int in_position)
        {
            return in_position.x > -1
                && in_position.y > -1
                && in_position.x < Dimensions.x
                && in_position.y < Dimensions.y;
        }

        /// <summary>
        /// Visualizes the region as a string with merged layers.
        /// Intended for Console debugging.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:ParquetClassLibrary.Sandbox.RegionMap"/>.</returns>
        public override string ToString()
        {
            // TODO: Replace mutliplication below with Magnitude method call.
            var representation = new StringBuilder(Dimensions.x * Dimensions.y);
            #region Compose visual represenation of contents.
            for (var x = 0; x < Dimensions.x; x++)
            {
                for (var y = 0; y < Dimensions.y; y++)
                {
                    representation.Append(
                        _collectableLayer[x, y]?.ToString()
                        ?? _furnishingLayer[x, y]?.ToString()
                        ?? _blockLayer[x, y]?.ToString()
                        ?? _floorLayer[x, y]?.ToString()
                        ?? "@");
                }
                representation.AppendLine();
            }
            #endregion

            return "Region " + Title + " (" + Dimensions.x + ", " + Dimensions.y + ")\n" + representation;
        }

        /// <summary>
        /// Visualizes the region as a string, listing layers separately.
        /// Intended for Console debugging.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:ParquetClassLibrary.Sandbox.RegionMap"/>.</returns>
        public string ToLayeredString()
        {
            // TODO: Replace mutliplication below with Magnitude method call.
            var floorRepresentation = new StringBuilder(Dimensions.x * Dimensions.y);
            var blocksRepresentation = new StringBuilder(Dimensions.x * Dimensions.y);
            var furnishingsRepresentation = new StringBuilder(Dimensions.x * Dimensions.y);
            var collectablesRepresentation = new StringBuilder(Dimensions.x * Dimensions.y);
            #region Compose visual represenation of contents.
            for (var x = 0; x < Dimensions.x; x++)
            {
                for (var y = 0; y < Dimensions.y; y++)
                {
                    floorRepresentation.Append(_floorLayer[x, y]?.ToString() ?? "@");
                    blocksRepresentation.Append(_blockLayer[x, y]?.ToString() ?? " ");
                    furnishingsRepresentation.Append(_furnishingLayer[x, y]?.ToString() ?? " ");
                    collectablesRepresentation.Append(_collectableLayer[x, y]?.ToString() ?? " ");
                }
                floorRepresentation.AppendLine();
                blocksRepresentation.AppendLine();
                furnishingsRepresentation.AppendLine();
                collectablesRepresentation.AppendLine();
            }
            #endregion

            return "Region " + Title + " (" + Dimensions.x + ", " + Dimensions.y + ")\n" +
                "Floor: \n" + floorRepresentation +
                "Blocks: \n" + blocksRepresentation +
                "Furnishings: \n" + furnishingsRepresentation +
                "Collectables: \n" + collectablesRepresentation;
        }
        #endregion
    }
}
