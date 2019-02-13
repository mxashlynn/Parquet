using System;
using System.IO;
using System.Collections.Generic;
using ParquetClassLibrary.Sandbox.Parquets;
using ParquetClassLibrary.Sandbox.ID;
using ParquetClassLibrary.Stubs;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Sandbox
{
    public class RegionEditor
    {
        public static event EventHandler<PositionInfoEvent> DisplayPositionInfo;
        public static event EventHandler DisplayMap;

        private RegionMap _currentRegion = null;

        private Floors _floorToPaint;
        private Blocks _blockToPaint;
        private Furnishings _furnishingToPaint;
        private Collectables _collectableToPaint;

        private ParquetMask _parquetPaintPattern = ParquetMask.None;

        #region New, Save, Load Methods
        /// <summary>
        /// Creates a new region with a default name.
        /// </summary>
        public void NewRegionMap()
        {
            _currentRegion = new RegionMap("New Region");
            SetLowerStorey();

            DisplayMap?.Invoke(this, null);
        }

        /// <summary>
        /// Writes the current region to storage at the given path.
        /// </summary>
        /// <param name="in_path">The location in which to store the saved region.</param>
        public void SaveRegionMap(string in_path)
        {
            var serialized = _currentRegion.SerializeToString();
            // TODO Convert this to use multiplatform utils.
            File.WriteAllText(in_path, serialized);
        }

        /// <summary>
        /// Reads the region stored at the given location.
        /// </summary>
        /// <param name="in_path">The location of the region to load.</param>
        public void LoadRegionMap(string in_path)
        {
            // TODO Convert this to use multiplatform utils.
            var serialized = File.ReadAllText(in_path);
            if (RegionMap.TryDeserializeFromString(serialized, out RegionMap result))
            {
                _currentRegion = result;
            }
            else
            {
                Error.Handle("Could not load region from " + in_path);
            }

        }
        #endregion

        #region Region Characteristic Editing Methods
        /// <summary>
        /// Indicates that the region represents an above-ground storey.
        /// </summary>
        public void SetUpperStorey()
        {
            if (null != _currentRegion)
            {
                _currentRegion.Background = Color.SkyBlue;
            }
        }

        /// <summary>
        /// Indicates that the region represents an ground-level storey.
        /// </summary>
        public void SetLowerStorey()
        {
            if (null != _currentRegion)
            {
                _currentRegion.Background = Color.Brown;
            }
        }

        /// <summary>
        /// Sets the region's title.
        /// </summary>
        /// <param name="in_title">A title for the region.</param>
        public void SetRegionTitle(string in_title)
        {
            if (null != _currentRegion)
            {
                _currentRegion.Title = in_title;
            }
        }
        #endregion

        #region Map Painting Methods
        /// <summary>
        /// Displays information corresponging to the requested position on the current region map.
        /// </summary>
        /// <param name="in_position">The position whose information is sought.</param>
        public void DisplayInfoAtPosition(Vector2Int in_position)
        {
            DisplayPositionInfo?.Invoke(this,
                    new PositionInfoEvent(_currentRegion.GetAllParquetsAtPosition(in_position),
                                          _currentRegion.GetSpecialPointsAtPosition(in_position)));
        }

        /// <summary>
        /// Select a floor to paint with.
        /// </summary>
        /// <param name="in_floorID">The parquet ID to select.</param>
        // TODO Improve handling of IDs (especially in Unity version).
        public void SetFloorToPaint(Floors in_floorID)
        {
            _floorToPaint = in_floorID;
        }

        /// <summary>
        /// Select a block to paint with.
        /// </summary>
        /// <param name="in_blockID">The parquet ID to select.</param>
        // TODO Improve handling of IDs (especially in Unity version).
        public void SetBlockToPaint(Blocks in_blockID)
        {
            _blockToPaint = in_blockID;
        }

        /// <summary>
        /// Select a furnishing to paint with.
        /// </summary>
        /// <param name="in_furnishingID">The parquet ID to select.</param>
        // TODO Improve handling of IDs (especially in Unity version).
        public void SetFurnishingToPaint(Furnishings in_furnishingID)
        {
            _furnishingToPaint = in_furnishingID;
        }

        /// <summary>
        /// Select a collectable to paint with.
        /// </summary>
        /// <param name="in_collectableID">The parquet ID to select.</param>
        // TODO Improve handling of IDs (especially in Unity version).
        public void SetCollectableToPaint(Collectables in_collectableID)
        {
            _collectableToPaint = in_collectableID;
        }

        /// <summary>
        /// Turns floor painting on or off.
        /// </summary>
        /// <param name="in_enable">If <c>true</c> enable floor painting, otherwise disable it.</param>
        public void SetPaintFloor(bool in_enable)
        {
            _parquetPaintPattern.SetTo(ParquetMask.Floor, in_enable);
        }

        /// <summary>
        /// Turns floor painting on or off.
        /// </summary>
        /// <param name="in_enable">If <c>true</c> enable block painting, otherwise disable it.</param>
        public void SetPaintBlock(bool in_enable)
        {
            _parquetPaintPattern.SetTo(ParquetMask.Block, in_enable);
        }

        /// <summary>
        /// Turns floor painting on or off.
        /// </summary>
        /// <param name="in_enable">If <c>true</c> enable furnishing painting, otherwise disable it.</param>
        public void SetPaintFurnishing(bool in_enable)
        {
            _parquetPaintPattern.SetTo(ParquetMask.Furnishing, in_enable);
        }

        /// <summary>
        /// Turns floor painting on or off.
        /// </summary>
        /// <param name="in_enable">If <c>true</c> enable collectable painting, otherwise disable it.</param>
        public void SetPaintCollectable(bool in_enable)
        {
            _parquetPaintPattern.SetTo(ParquetMask.Collectable, in_enable);
        }

        /// <summary>
        /// Paints currently selected parquets at the given position.
        /// </summary>
        /// <param name="in_position">Where to paint.</param>
        /// <returns><c>true</c>, if location was painted correctly, <c>false</c> if an error occured.</returns>
        public bool PaintAtLocation(Vector2Int in_position)
        {
            var result = true;
            var error = "";

            if (_parquetPaintPattern.IsSet(ParquetMask.Floor))
            {
                error += _currentRegion.TrySetFloor(new Floor(_floorToPaint), in_position)
                    ? ""
                    : " floor ";
            }
            if (_parquetPaintPattern.IsSet(ParquetMask.Block))
            {
                error += _currentRegion.TrySetBlock(new Block(_blockToPaint), in_position)
                    ? ""
                    : " block ";
            }
            if (_parquetPaintPattern.IsSet(ParquetMask.Furnishing))
            {
                error += _currentRegion.TrySetFurnishing(new Furnishing(_furnishingToPaint), in_position)
                    ? ""
                    : " furnishing ";
            }
            if (_parquetPaintPattern.IsSet(ParquetMask.Collectable))
            {
                error += _currentRegion.TrySetCollectable(new Collectable(_collectableToPaint), in_position)
                    ? ""
                    : " collectable ";
            }

            if (!string.IsNullOrEmpty(error))
            {
                Error.Handle("Error at position " + in_position + ".  Could not assign these parquets: " + error);
                result = false;
             }

            return result;
        }

        /// <summary>
        /// Paints currently selected parquets at the given positions.
        /// </summary>
        /// <param name="in_positions">Where to paint.</param>
        public void PaintAtLocations(List<Vector2Int> in_positions)
        {
            foreach (var position in in_positions)
            {
                var errorEncountered = PaintAtLocation(position);
                if (errorEncountered)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Paints currently selected parquets along a line between the given positions.
        /// </summary>
        /// <param name="in_start">The line's start.</param>
        /// <param name="in_end">The line's end.</param>
        public void PaintLine(Vector2Int in_start, Vector2Int in_end)
        {
            PaintAtLocations(Rasterization.PlotLine(in_start, in_end, _currentRegion.IsValidPosition));
        }

        /// <summary>
        /// Paints currently selected parquets in a rectangle between the given positions.
        /// </summary>
        /// <param name="in_upperLeft">The upper left corner of the rectangle.</param>
        /// <param name="in_lowerRight">The lower right corner of the rectangle.</param>
        /// <param name="in_filled">
        /// If set to <c>true</c>, the rectangle will be filled in; otherwise,
        /// only the outline will be painted.
        /// </param>
        public void PaintRectangle(Vector2Int in_upperLeft, Vector2Int in_lowerRight, bool in_filled)
        {
            PaintAtLocations(in_filled
                ? Rasterization.PlotFilledRectangle(in_upperLeft, in_lowerRight, _currentRegion.IsValidPosition)
                : Rasterization.PlotEmptyRectangle(in_upperLeft, in_lowerRight, _currentRegion.IsValidPosition));
        }

        /// <summary>
        /// Paints currently selected parquets in a circle of the given radius around the given position.
        /// </summary>
        /// <param name="in_center">The circle's center.</param>
        /// <param name="in_radius">The circle's radius.</param>
        /// <param name="in_filled">
        /// If set to <c>true</c>, the circle will be filled in; otherwise,
        /// only the outline will be painted.
        /// </param>
        public void PaintCircle(Vector2Int in_center, int in_radius, bool in_filled)
        {
            PaintAtLocations(Rasterization.PlotCircle(in_center, in_radius, in_filled, _currentRegion.IsValidPosition));
        }

        /// <summary>
        /// Paints a contiguous selection using a four-way flood fill, overwritting only those
        /// positions whose parquets match those initially found at the starting position.
        /// </summary>
        /// <param name="in_start">Where to start the fill.</param>
        public void PaintFloodFill(Vector2Int in_start)
        {
            PaintAtLocations(PlotFloodFill(in_start));
        }

        /// <summary>
        /// Plots a contiguous section of the current region using a four-way flood fill.
        /// Plots all valid positions adjacent to the given position, provided that they match
        /// the parquets at the given position according to the current parquet paint pattern.
        /// </summary>
        /// <param name="in_start">The position on which to base the fill.</param>
        /// <returns>A selection of contiguous positions.</returns>
        private List<Vector2Int> PlotFloodFill(Vector2Int in_start)
        {
            var target = _currentRegion.GetAllParquetsAtPosition(in_start);
            var deduplicationList = new HashSet<Vector2Int>();
            var queue = new Queue<Vector2Int>();
            queue.Enqueue(in_start);

            while (queue.Count > 0)
            {
                var position = queue.Dequeue();
                if (_currentRegion.IsValidPosition(position) && Matches(position, target))
                {
                    deduplicationList.Add(position);
                    queue.Enqueue(new Vector2Int(position.x - 1, position.y));
                    queue.Enqueue(new Vector2Int(position.x, position.y - 1));
                    queue.Enqueue(new Vector2Int(position.x + 1, position.y));
                    queue.Enqueue(new Vector2Int(position.x, position.y + 1));
                }
            }

            return new List<Vector2Int>(deduplicationList);
        }

        /// <summary>
        /// Determines if the parquets at the specified position match those in the given stack,
        /// according to the current parquet paint pattern.
        /// </summary>
        /// <param name="in_position">The position to check.</param>
        /// <param name="in_matchAgainst">The stack to match against.</param>
        /// <returns><c>true</c>, if the parquet stacks match, <c>false</c> otherwise.</returns>
        private bool Matches(Vector2Int in_position, ParquetStack in_matchAgainst)
        {
            var result = false;
            if (!_parquetPaintPattern.HasFlag(ParquetMask.None))
            {
                // Assume the parquets match, then attempt to prove that they do not.
                result = true;
                var parquets = _currentRegion.GetAllParquetsAtPosition(in_position);

                if (_parquetPaintPattern.HasFlag(ParquetMask.Floor))
                {
                    result &= parquets.floor == in_matchAgainst.floor;
                }
                if (_parquetPaintPattern.HasFlag(ParquetMask.Block))
                {
                    result &= parquets.block == in_matchAgainst.block;
                }
                if (_parquetPaintPattern.HasFlag(ParquetMask.Furnishing))
                {
                    result &= parquets.furnishing == in_matchAgainst.furnishing;
                }
                if (_parquetPaintPattern.HasFlag(ParquetMask.Collectable))
                {
                    result &= parquets.collectable == in_matchAgainst.collectable;
                }
            }

            return result;
        }
        #endregion

        // TODO: Undo/Redo System
        // TODO: ParquetSelect, ParquetCopy, ParquetPaste, ParquetClear functionality
        // IDEA: Allow painting in a match-only mode similar to the way the flood fill matches,
        //       c.f. the mask properties in TEdit.
    }
}
