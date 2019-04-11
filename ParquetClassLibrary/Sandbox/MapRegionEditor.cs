using System;
using System.Collections.Generic;
using System.IO;
using ParquetClassLibrary.Sandbox.Parquets;
using ParquetClassLibrary.Stubs;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Sandbox
{
    // TODO: Undo/Redo System
    // TODO: ParquetSelect, ParquetCopy, ParquetPaste, ParquetClear functionality
    // IDEA: Allow painting in a match-only mode similar to the way the flood fill matches,
    //       c.f. the mask properties in TEdit.

    /// <summary>
    /// Controller to manage in-game MapRegion editing.
    /// </summary>
    public class MapRegionEditor
    {
        #region Events
        /// <summary>
        /// Indicates when it is time to update the display of current position info.
        /// </summary>
        public static event EventHandler<PositionInfoEvent> DisplayPositionInfo;

        /// <summary>
        /// Indicates when it is time to update the display of the map.
        /// </summary>
        public static event EventHandler DisplayMap;
        #endregion

        /// <summary>The <see cref="T:ParquetClassLibrary.Sandbox.MapRegion"/> currently being edited.</summary>
        private MapRegion _currentRegion;

        /// <summary>Indicates whether a <see cref="T:ParquetClassLibrary.Sandbox.MapRegion"/> is map loaded.</summary>
        /// <value><c>true</c> if a map has been loaded; otherwise, <c>false</c>.</value>
        internal bool IsMapLoaded => null != _currentRegion;

        /// <summary>Backing variable that determines which type of parquets will be painted.</summary>
        private ParquetMask _parquetPaintPattern = ParquetMask.None;

        /// <summary>Determines which type of parquets will be painted.</summary>
        internal ParquetMask ParquetPaintPattern => _parquetPaintPattern;

        /// <summary>Identifier for the selected floor.</summary>
        private EntityID _floorToPaint;

        /// <summary>Identifier for the selected block.</summary>
        private EntityID _blockToPaint;

        /// <summary>Identifier for the selected furnishing.</summary>
        private EntityID _furnishingToPaint;

        /// <summary>Identifier for the selected collectible.</summary>
        private EntityID _collectibleToPaint;

        #region New, Save, Load Methods
        /// <summary>
        /// Creates a new region with a default name.
        /// </summary>
        public void NewMapRegion()
        {
            _currentRegion = new MapRegion();
            SetLowerStory();

            DisplayMap?.Invoke(this, null);
        }

        /// <summary>
        /// Writes the current region to storage at the given path.
        /// </summary>
        /// <param name="in_path">The location in which to store the saved region.</param>
        public void SaveMapRegion(string in_path)
        {
            var serialized = _currentRegion.SerializeToString();
            // TODO Convert this to use multiplatform utils.
            File.WriteAllText(in_path, serialized);
        }

        /// <summary>
        /// Reads the region stored at the given location.
        /// </summary>
        /// <param name="in_path">The location of the region to load.</param>
        public void LoadMapRegion(string in_path)
        {
            // TODO Convert this to use multiplatform utils.
            var serialized = File.ReadAllText(in_path);
            if (MapRegion.TryDeserializeFromString(serialized, out var result))
            {
                _currentRegion = result;
            }
            else
            {
                Error.Handle($"Could not load region from {in_path}");
            }

        }
        #endregion

        #region Region Characteristic Editing Methods
        /// <summary>
        /// Indicates that the region represents an above-ground storey.
        /// </summary>
        public void SetUpperStory()
        {
            if (null != _currentRegion)
            {
                _currentRegion.Background = Color.SkyBlue;
            }
        }

        /// <summary>
        /// Indicates that the region represents an ground-level storey.
        /// </summary>
        public void SetLowerStory()
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
        /// <param name="in_floorID">The parquet ID to select.  Must represent a valid Floor.</param>
        public void SetFloorToPaint(EntityID in_floorID)
        {
            //Adds bounds-checking using the Ranges defined in Assembly.
            if (in_floorID.IsValidForRange(AssemblyInfo.FloorIDs))
            {
                _floorToPaint = in_floorID;
            }
            else
            {
                Error.Handle($"Cannot paint non-Floor {in_floorID} as if it were a Floor.");
            }
        }

        /// <summary>
        /// Select a block to paint with.
        /// </summary>
        /// <param name="in_blockID">The parquet ID to select.  Must represent a valid Block.</param>
        public void SetBlockToPaint(EntityID in_blockID)
        {
            if (in_blockID.IsValidForRange(AssemblyInfo.BlockIDs))
            {
                _blockToPaint = in_blockID;
            }
            else
            {
                Error.Handle($"Cannot paint non-Block {in_blockID} as if it were a Block.");
            }
        }

        /// <summary>
        /// Select a furnishing to paint with.
        /// </summary>
        /// <param name="in_furnishingID">The parquet ID to select.  Must represent a valid Furnishing.</param>
        public void SetFurnishingToPaint(EntityID in_furnishingID)
        {
            if (in_furnishingID.IsValidForRange(AssemblyInfo.FurnishingIDs))
            {
                _furnishingToPaint = in_furnishingID;
            }
            else
            {
                Error.Handle($"Cannot paint non-Furnishing {in_furnishingID} as if it were a Furnishing.");
            }
        }

        /// <summary>
        /// Select a collectible to paint with.
        /// </summary>
        /// <param name="in_collectibleID">The parquet ID to select.  Must represent a valid Collectible.</param>
        public void SetCollectibleToPaint(EntityID in_collectibleID)
        {
            if (in_collectibleID.IsValidForRange(AssemblyInfo.CollectibleIDs))
            {
                _collectibleToPaint = in_collectibleID;
            }
            else
            {
                Error.Handle($"Cannot paint non-Collectible {in_collectibleID} as if it were a Collectible.");
            }
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
        /// <param name="in_enable">If <c>true</c> enable collectible painting, otherwise disable it.</param>
        public void SetPaintCollectible(bool in_enable)
        {
            _parquetPaintPattern.SetTo(ParquetMask.Collectible, in_enable);
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
                error += _currentRegion.TrySetFloor(_floorToPaint, in_position)
                    ? ""
                    : " floor ";
            }
            if (_parquetPaintPattern.IsSet(ParquetMask.Block))
            {
                error += _currentRegion.TrySetBlock(_blockToPaint, in_position)
                    ? ""
                    : " block ";
            }
            if (_parquetPaintPattern.IsSet(ParquetMask.Furnishing))
            {
                error += _currentRegion.TrySetFurnishing(_furnishingToPaint, in_position)
                    ? ""
                    : " furnishing ";
            }
            if (_parquetPaintPattern.IsSet(ParquetMask.Collectible))
            {
                error += _currentRegion.TrySetCollectible(_collectibleToPaint, in_position)
                    ? ""
                    : " collectible ";
            }

            if (!string.IsNullOrEmpty(error))
            {
                Error.Handle($"Error at position {in_position}.  Could not assign these parquets: {error}");
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
                // TODO: Consider if we really want to abort on a failed position.
                // If we don't, it would make more sense for PaintAtLocation to be void.
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
            PaintAtLocations(Rasterization.PlotFloodFill(in_start,
                                                         _currentRegion.GetAllParquetsAtPosition(in_start),
                                                         _currentRegion.IsValidPosition,
                                                         Matches));
        }

        /// <summary>
        /// Determines if the parquets at the specified position match those in the given stack,
        /// according to the current parquet paint pattern.
        /// </summary>
        /// <param name="in_position">The position to check.</param>
        /// <param name="in_matchAgainst">The stack to match against.</param>
        /// <returns><c>true</c>, if the parquet stacks match, <c>false</c> otherwise.</returns>
        private bool Matches<T>(Vector2Int in_position, T in_matchAgainst) where T : IParquetStack
        {
            bool result;
            var parquets = _currentRegion.GetAllParquetsAtPosition(in_position);

            if (_parquetPaintPattern.HasFlag(ParquetMask.None))
            {
                // Match only against completely empty map positions.
                result = parquets.IsEmpty;
            }
            else
            {
                // For positions with at least some parquets, assume a match
                // then attempt to disprove that assumption.
                result = true;

                if (_parquetPaintPattern.HasFlag(ParquetMask.Floor))
                {
                    result &= parquets.Floor == in_matchAgainst.Floor;
                }
                if (_parquetPaintPattern.HasFlag(ParquetMask.Block))
                {
                    result &= parquets.Block == in_matchAgainst.Block;
                }
                if (_parquetPaintPattern.HasFlag(ParquetMask.Furnishing))
                {
                    result &= parquets.Furnishing == in_matchAgainst.Furnishing;
                }
                if (_parquetPaintPattern.HasFlag(ParquetMask.Collectible))
                {
                    result &= parquets.Collectible == in_matchAgainst.Collectible;
                }
            }

            return result;
        }
        #endregion
    }
}
