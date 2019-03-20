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
    /// A playable region in sandbox-mode.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class MapRegion
    {
        #region Class Defaults
        /// <summary>The region's dimensions in parquets.</summary>
        public static readonly Vector2Int DimensionsInParquets = new Vector2Int(Assembly.ParquetsPerRegionDimension,
                                                                                Assembly.ParquetsPerRegionDimension);

        /// <summary>Default name for new regions.</summary>
        public const string DefaultTitle = "New Region";

        /// <summary>Default color for new regions.</summary>
        public static readonly Color DefaultColor = Color.White;
        #endregion

        #region Whole-Region Characteristics
        /// <summary>
        /// Describes the version of serialized data.
        /// Allows selecting data files that can be successfully deserialized.
        /// </summary>
        public readonly string DataVersion = Assembly.SupportedDataVersion;

        /// <summary>The region identifier, used when referencing unloaded regions.</summary>
        public readonly Guid RegionID;

        /// <summary>What the region is called in-game.</summary>
        public string Title { get; set; } = DefaultTitle;

        /// <summary>A color to display in any empty areas of the region.</summary>
        public Color Background { get; set; } = DefaultColor;

        /// <summary>The region's elevation in absolute terms.</summary>
        public Elevation ElevationLocal { get; set; } = Elevation.LevelGround;

        /// <summary>The region's elevation relative to all other regions.</summary>
        public int ElevationGlobal { get; set; } = 0;

        /// <summary>Tracks how many times the data structure has been serialized.</summary>
        public int Revision { get; private set; } = 0;
        #endregion

        #region Region Parquet Contents
        /// <summary>Exit, spawn, and other special points in the region.</summary>
        private readonly List<SpecialPoint> _specialPoints = new List<SpecialPoint>();

        /// <summary>Floors and walkable terrain in the region.</summary>
        private readonly ParquetID[,] _floorLayer = new ParquetID[DimensionsInParquets.x, DimensionsInParquets.y];

        /// <summary>Walls and obstructing terrain in the region.</summary>
        private readonly ParquetID[,] _blockLayer = new ParquetID[DimensionsInParquets.x, DimensionsInParquets.y];

        /// <summary>Furniture and natural items in the region.</summary>
        private readonly ParquetID[,] _furnishingLayer = new ParquetID[DimensionsInParquets.x, DimensionsInParquets.y];

        /// <summary>Collectable materials in the region.</summary>
        private readonly ParquetID[,] _collectableLayer = new ParquetID[DimensionsInParquets.x, DimensionsInParquets.y];
        #endregion

        #region Initialization
        /// <summary>
        /// Constructs a new instance of the <see cref="T:ParquetClassLibrary.Sandbox.MapRegion"/> class.
        /// </summary>
        /// <param name="in_title">The name of the new region.</param>
        /// <param name="in_background">Background color for the new region.</param>
        /// <param name="in_localElevation">The absolute elevation of this region.</param>
        /// <param name="in_globalElevation">The relative elevation of this region expressed as a signed integer.</param>
        /// <param name="in_ID">A RegionID derived from a MapChunkGrid; if null, a new RegionID is generated.</param>
        public MapRegion(string in_title = DefaultTitle, Color? in_background = null,
                         Elevation in_localElevation = Elevation.LevelGround, int in_globalElevation = 0, Guid? in_ID = null)
        {
            Title = in_title ?? DefaultTitle;
            Background = in_background ?? Color.White;
            RegionID = in_ID ?? Guid.NewGuid();
            ElevationLocal = in_localElevation;
            ElevationGlobal = in_globalElevation;
        }
        /// <summary>
        /// Constructs a new instance of the <see cref="T:ParquetClassLibrary.Sandbox.MapRegion"/> class.
        /// </summary>
        /// <param name="in_generateID">For unit testing, if set to <c>false</c> the RegionID is set to a default value.</param>
        public MapRegion(bool in_generateID)
        {
            // Overwrite default behavior for tests.
            RegionID = in_generateID
                ? Guid.NewGuid()
                : Guid.Empty;
        }
        #endregion

        #region Parquets Replacement Methods
        /// <summary>
        /// Attempts to update the floor parquet at the given position.
        /// </summary>
        /// <param name="in_floorID">ID of the new floor to set.</param>
        /// <param name="in_position">The position to set.</param>
        /// <returns><c>true</c>, if the floor was set, <c>false</c> otherwise.</returns>
        public bool TrySetFloor(ParquetID in_floorID, Vector2Int in_position)
        {
            return TrySetParquet(in_floorID, in_position, _floorLayer);
        }

        /// <summary>
        /// Attempts to update the block parquet at the given position.
        /// </summary>
        /// <param name="in_blockID">ID of the new block to set.</param>
        /// <param name="in_position">The position to set.</param>
        /// <returns><c>true</c>, if the block was set, <c>false</c> otherwise.</returns>
        public bool TrySetBlock(ParquetID in_blockID, Vector2Int in_position)
        {
            return TrySetParquet(in_blockID, in_position, _blockLayer);
        }

        /// <summary>
        /// Attempts to update the furnishing parquet at the given position.
        /// </summary>
        /// <param name="in_furnishingID">ID of the new furnishing to set.</param>
        /// <param name="in_position">The position to set.</param>
        /// <returns><c>true</c>, if the furnishing was set, <c>false</c> otherwise.</returns>
        public bool TrySetFurnishing(ParquetID in_furnishingID, Vector2Int in_position)
        {
            return TrySetParquet(in_furnishingID, in_position, _furnishingLayer);
        }

        /// <summary>
        /// Attempts to update the collectable parquet at the given position.
        /// </summary>
        /// <param name="in_collectableID">ID of the new collectable to set.</param>
        /// <param name="in_position">The position to set.</param>
        /// <returns><c>true</c>, if the collectable was set, <c>false</c> otherwise.</returns>
        public bool TrySetCollectable(ParquetID in_collectableID, Vector2Int in_position)
        {
            return TrySetParquet(in_collectableID, in_position, _collectableLayer);
        }

        /// <summary>
        /// Attempts to update the parquet at the given position in the given layer.
        /// </summary>
        /// <param name="in_position">The position to set.</param>
        /// <returns><c>true</c>, if the parquet was set, <c>false</c> otherwise.</returns>
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
        /// Gets all the parquets in the entire region.
        /// </summary>
        /// <returns>A collection of parquets.</returns>
        public IEnumerable<ParquetParent> GetAllParquets()
        {
            // TODO: This is not optimal — it'd be nice to not generate these garbage objects full of duplicates
            // Is there a way we can just use IDs?
            var result = new List<ParquetParent>(DimensionsInParquets.x * DimensionsInParquets.y);

            for (var x = 0; x < DimensionsInParquets.x; x++)
            {
                for (var y = 0; y < DimensionsInParquets.y; y++)
                {
                    ParquetID parquetID = _floorLayer[x, y];
                    if (ParquetID.None != parquetID) { result.Add(AllParquets.Get<Floor>(parquetID)); }
                    parquetID = _blockLayer[x, y];
                    if (ParquetID.None != parquetID) { result.Add(AllParquets.Get<Block>(parquetID)); }
                    parquetID = _furnishingLayer[x, y];
                    if (ParquetID.None != parquetID) { result.Add(AllParquets.Get<Furnishing>(parquetID)); }
                    parquetID = _collectableLayer[x, y];
                    if (ParquetID.None != parquetID) { result.Add(AllParquets.Get<Collectable>(parquetID)); }
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
        /// Serializes to the current MapRegion to a string,
        /// incrementing the revision number in the process.
        /// </summary>
        /// <returns>The serialized MapRegion.</returns>
        public string SerializeToString()
        {
            Revision++;
            return JsonConvert.SerializeObject(this, Formatting.None);
        }

        /// <summary>
        /// Tries to deserialize a MapRegion from the given string.
        /// </summary>
        /// <param name="in_serializedMapRegion">The serialized region map.</param>
        /// <param name="out_mapRegion">The deserialized region map, or null if deserialization was impossible.</param>
        /// <returns><c>true</c>, if deserialize was posibile, <c>false</c> otherwise.</returns>
        public static bool TryDeserializeFromString(string in_serializedMapRegion,
                                                    out MapRegion out_mapRegion)
        {
            var result = false;
            out_mapRegion = null;

            if (string.IsNullOrEmpty(in_serializedMapRegion))
            {
                Error.Handle("Tried to deserialize a null string as a MapRegion.");
            }
            else
            {
                // Determine what version of region map was serialized.
                try
                {
                    var document = JObject.Parse(in_serializedMapRegion);
                    var version = document?.Value<string>(nameof(DataVersion));

                    // Deserialize only if this class supports the version given.
                    if (Assembly.SupportedDataVersion.Equals(version, StringComparison.OrdinalIgnoreCase))
                    {
                        out_mapRegion = JsonConvert.DeserializeObject<MapRegion>(in_serializedMapRegion);
                        result = true;
                    }
                }
                catch (JsonReaderException exception)
                {
                    Error.Handle("Error reading string while deserializing a MapRegion: " + exception);
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
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:ParquetClassLibrary.Sandbox.MapRegion"/>.</returns>
        public override string ToString()
        {
            var representation = new StringBuilder(DimensionsInParquets.Magnitude);
            #region Compose visual represenation of contents.
            for (var x = 0; x < DimensionsInParquets.x; x++)
            {
                for (var y = 0; y < DimensionsInParquets.y; y++)
                {
                    var result = ParquetID.None != _collectableLayer[x, y]
                        ? _collectableLayer[x, y].ToString()
                        : ParquetID.None != _furnishingLayer[x, y]
                            ? _furnishingLayer[x, y].ToString()
                            : ParquetID.None != _blockLayer[x, y]
                                ? _blockLayer[x, y].ToString()
                                : ParquetID.None != _floorLayer[x, y]
                                    ? _floorLayer[x, y].ToString()
                                    : "~";
                    representation.Append(result);
                }
                representation.AppendLine();
            }
            #endregion

            return "Region " + Title + " (" + DimensionsInParquets.x + ", " + DimensionsInParquets.y + ")\n" + representation;
        }

        /// <summary>
        /// Visualizes the region as a string, listing layers separately.
        /// Intended for Console debugging.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:ParquetClassLibrary.Sandbox.MapRegion"/>.</returns>
        public string ToLayeredString()
        {
            var floorRepresentation = new StringBuilder(DimensionsInParquets.Magnitude);
            var blocksRepresentation = new StringBuilder(DimensionsInParquets.Magnitude);
            var furnishingsRepresentation = new StringBuilder(DimensionsInParquets.Magnitude);
            var collectablesRepresentation = new StringBuilder(DimensionsInParquets.Magnitude);
            #region Compose visual represenation of contents.
            for (var x = 0; x < DimensionsInParquets.x; x++)
            {
                for (var y = 0; y < DimensionsInParquets.y; y++)
                {
                    floorRepresentation.Append(ParquetID.None != _floorLayer[x, y]
                        ? _floorLayer[x, y].ToString()
                        : "~");
                    blocksRepresentation.Append(ParquetID.None != _blockLayer[x, y]
                        ? _blockLayer[x, y].ToString()
                        : " ");
                    furnishingsRepresentation.Append(ParquetID.None != _furnishingLayer[x, y]
                        ? _furnishingLayer[x, y].ToString()
                        : " ");
                    collectablesRepresentation.Append(ParquetID.None != _collectableLayer[x, y]
                        ? _collectableLayer[x, y].ToString()
                        : " ");
                }
                floorRepresentation.AppendLine();
                blocksRepresentation.AppendLine();
                furnishingsRepresentation.AppendLine();
                collectablesRepresentation.AppendLine();
            }
            #endregion

            return "Region " + Title + " (" + DimensionsInParquets.x + ", " + DimensionsInParquets.y + ")\n" +
                "Floor: \n" + floorRepresentation +
                "Blocks: \n" + blocksRepresentation +
                "Furnishings: \n" + furnishingsRepresentation +
                "Collectables: \n" + collectablesRepresentation;
        }
        #endregion
    }
}
