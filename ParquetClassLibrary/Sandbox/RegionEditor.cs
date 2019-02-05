using System;
using System.Collections.Generic;
using ParquetClassLibrary.Sandbox.Parquets;
using ParquetClassLibrary.Sandbox.ID;
using ParquetClassLibrary.Stubs;

namespace ParquetClassLibrary.Sandbox
{
    public class RegionEditor
    {
        public static event EventHandler<PositionInfoEvent> DisplayPositionInfo;

        private RegionMap _currentRegion;

        private Floors _floorToPaint;
        private Blocks _blockToPaint;
        private Furnishings _furnishingToPaint;
        private Collectables _collectableToPaint;

        private ParquetSelection _parquetPaintPattern = ParquetSelection.None;

        #region Initialization
        #endregion

        /// <summary>
        /// Displays information corresponging to the requested position on the current region map.
        /// </summary>
        /// <param name="in_position">The position whose information is sought.</param>
        void DisplayInfoAtPosition(Vector2Int in_position)
        {
            DisplayPositionInfo?.Invoke(this,
                    new PositionInfoEvent(_currentRegion.GetAllParquetsAtPosition(in_position),
                                          _currentRegion.GetSpecialPointsAtPosition(in_position)));
        }

        /// <summary>
        /// Select a floor to paint with.
        /// </summary>
        /// <param name="in_floorID">The parquet ID to select.</param>
        // TODO How the ID info gets passed around will likely change when we return to Unity.
        void SetFloorToPaint(Floors in_floorID)
        {
            _floorToPaint = in_floorID;
        }

        /// <summary>
        /// Select a block to paint with.
        /// </summary>
        /// <param name="in_blockID">The parquet ID to select.</param>
        // TODO How the ID info gets passed around will likely change when we return to Unity.
        void SetBlockToPaint(Blocks in_blockID)
        {
            _blockToPaint = in_blockID;
        }

        /// <summary>
        /// Select a furnishing to paint with.
        /// </summary>
        /// <param name="in_furnishingID">The parquet ID to select.</param>
        // TODO How the ID info gets passed around will likely change when we return to Unity.
        void SetFurnishingToPaint(Furnishings in_furnishingID)
        {
            _furnishingToPaint = in_furnishingID;
        }

        /// <summary>
        /// Select a collectable to paint with.
        /// </summary>
        /// <param name="in_collectableID">The parquet ID to select.</param>
        // TODO How the ID info gets passed around will likely change when we return to Unity.
        void SetCollectableToPaint(Collectables in_collectableID)
        {
            _collectableToPaint = in_collectableID;
        }

        /// <summary>
        /// Turns floor painting on or off.
        /// </summary>
        /// <param name="in_enable">If <c>true</c> enable floor painting, otherwise disable it.</param>
        void SetPaintFloor(bool in_enable)
        {
            _parquetPaintPattern.SetTo(ParquetSelection.Floor, in_enable);
        }

        /// <summary>
        /// Turns floor painting on or off.
        /// </summary>
        /// <param name="in_enable">If <c>true</c> enable block painting, otherwise disable it.</param>
        void SetPaintBlock(bool in_enable)
        {
            _parquetPaintPattern.SetTo(ParquetSelection.Block, in_enable);
        }

        /// <summary>
        /// Turns floor painting on or off.
        /// </summary>
        /// <param name="in_enable">If <c>true</c> enable furnishing painting, otherwise disable it.</param>
        void SetPaintFurnishing(bool in_enable)
        {
            _parquetPaintPattern.SetTo(ParquetSelection.Furnishing, in_enable);
        }

        /// <summary>
        /// Turns floor painting on or off.
        /// </summary>
        /// <param name="in_enable">If <c>true</c> enable collectable painting, otherwise disable it.</param>
        void SetPaintCollectable(bool in_enable)
        {
            _parquetPaintPattern.SetTo(ParquetSelection.Collectable, in_enable);
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

            if (_parquetPaintPattern.IsSet(ParquetSelection.Floor))
            {
                error += _currentRegion.TrySetFloor(new Floor(_floorToPaint), in_position)
                    ? ""
                    : " floor ";
            }
            if (_parquetPaintPattern.IsSet(ParquetSelection.Block))
            {
                error += _currentRegion.TrySetBlock(new Block(_blockToPaint), in_position)
                    ? ""
                    : " block ";
            }
            if (_parquetPaintPattern.IsSet(ParquetSelection.Furnishing))
            {
                error += _currentRegion.TrySetFurnishing(new Furnishing(_furnishingToPaint), in_position)
                    ? ""
                    : " furnishing ";
            }
            if (_parquetPaintPattern.IsSet(ParquetSelection.Collectable))
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

        /*
        Needed:   
            NewRegionMap
            SaveRegionMap
            LoadRegionMap

        Nice-To-Haves:
            Undo/Redo   
            SetParquetForLine
            SetParquetForSquare
            SetParquetForCircle
            SetParquetForSquare
            SetParquetForFloodfillReplacement       
            ParquetSelect, ParquetCopy, ParquetPaste, ParquetClear
         */
    }
}
