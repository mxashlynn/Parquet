using System.Text;
using Queertet.Stubs;

namespace Queertet.Sandbox
{
    /// <summary>
    /// Scriptable Object containing details of a playable region in sandbox-mode.
    /// </summary>
    public class RegionMap
    {
        #region Class Defaults
        /// <summary>The region's dimensions.</summary>
        // TODO Come up with actual size of regions, (and consider making this editable in Unity?  But maybe not.)
        public static readonly Vector2Int Dimensions = new Vector2Int(5, 5);

        /// <summary>Default name for new regions.</summary>
        public const string DefaultTitle = "New Region";
        #endregion

        #region Whole-Region Characteristics
        /// <summary>What the region is called in-game.</summary>
        public string Title { get; private set; }

        /// <summary>A color to display in any empty areas of the region.</summary>
        public Color Background { get; private set; }
        #endregion

        #region Region parquet contents.
        /// <summary>Floors and walkable terrain in the region.</summary>
        private readonly Floor[,] _floorLayer = new Floor[Dimensions.x, Dimensions.y];

        /// <summary>Walls and obstructing terrain in the region.</summary>
        private Block[,] _blockLayer = new Block[Dimensions.x, Dimensions.y];

        /// <summary>Furniture and natural items in the region.</summary>
        private Furnishing[,] _furnishingsLayer = new Furnishing[Dimensions.x, Dimensions.y];

        /// <summary>Collectable materials in the region.</summary>
        private Collectable[,] _collectablesLayer = new Collectable[Dimensions.x, Dimensions.y];

        // IDEA: a foreground layer?
        #endregion

        #region Initialization
        /// <summary>
        /// Constructs a new instance of the <see cref="T:Queertet.Sandbox.RegionMap"/> class.
        /// </summary>
        /// <param name="in_title">The name of the new region.</param>
        /// <param name="in_background">Background color for the new region.</param>
        public RegionMap(string in_title = DefaultTitle, Color? in_background = null)
            // Assign defaults that cannot be specified in the argument list.
            => Background = in_background ?? Color.white;
        #endregion

        #region State Alteration Methods
        #region Parquets Replacement Methods
        /// <summary>
        /// Attempts to update the floor parquet at the given position.
        /// </summary>
        /// <param name="in_floor">The new floor to set.</param>
        /// <param name="in_position">The position to set.</param>
        /// <returns><c>true</c>, if the floor was set, <c>false</c> otherwise.</returns>
        public bool TrySetFloor(Floor in_floor, Vector2Int in_position)
        {
            // TODO: Implement this.
            return false;
        }

        /// <summary>
        /// Attempts to update the block parquet at the given position.
        /// </summary>
        /// <param name="in_block">The new block to set.</param>
        /// <param name="in_position">The position to set.</param>
        /// <returns><c>true</c>, if the block was set, <c>false</c> otherwise.</returns>
        public bool TrySetBlock(Block in_block, Vector2Int in_position)
        {
            // TODO: Implement this.
            return false;
        }

        /// <summary>
        /// Attempts to update the furnishing parquet at the given position.
        /// </summary>
        /// <param name="in_furnishing">The new furnishing to set.</param>
        /// <param name="in_position">The position to set.</param>
        /// <returns><c>true</c>, if the furnishing was set, <c>false</c> otherwise.</returns>
        public bool TrySetFurnishing(Furnishing in_furnishing, Vector2Int in_position)
        {
            // TODO: Implement this.
            return false;
        }

        /// <summary>
        /// Attempts to update the collectable parquet at the given position.
        /// </summary>
        /// <param name="in_collectable">The new collectable to set.</param>
        /// <param name="in_position">The position to set.</param>
        /// <returns><c>true</c>, if the collectable was set, <c>false</c> otherwise.</returns>
        public bool TrySetCollectable(Collectable in_collectable, Vector2Int in_position)
        {
            // TODO: Implement this.
            return false;
        }

        /// <summary>
        /// Attempts to remove the floor parquet at the given position.
        /// </summary>
        /// <param name="in_position">The position to clear.</param>
        /// <returns><c>true</c>, if the floor was removed, <c>false</c> otherwise.</returns>
        public bool TryRemoveFloor(Vector2Int in_position)
        {
            // TODO: Implement this.
            return false;
        }

        /// <summary>
        /// Attempts to remove the block parquet at the given position.
        /// </summary>
        /// <param name="in_position">The position to clear.</param>
        /// <returns><c>true</c>, if the block was removed, <c>false</c> otherwise.</returns>
        public bool TryRemoveBlock(Vector2Int in_position)
        {
            // TODO: Implement this.
            return false;
        }

        /// <summary>
        /// Attempts to remove the furnishing parquet at the given position.
        /// </summary>
        /// <param name="in_position">The position to clear.</param>
        /// <returns><c>true</c>, if the furnishing was removed, <c>false</c> otherwise.</returns>
        public bool TryRemoveFurnishing(Vector2Int in_position)
        {
            // TODO: Implement this.
            return false;
        }

        /// <summary>
        /// Attempts to update the collectable parquet at the given position.
        /// </summary>
        /// <param name="in_position">The position to clear.</param>
        /// <returns><c>true</c>, if the collectable was removed, <c>false</c> otherwise.</returns>
        public bool TryRemoveCollectable(Vector2Int in_position)
        {
            // TODO: Implement this.
            return false;
        }

        /// <summary>
        /// Attempts to remove all parquets at the given position.
        /// </summary>
        /// <param name="in_position">The position to clear.</param>
        /// <returns><c>true</c>, if the position was entirely cleared, <c>false</c> otherwise.</returns>
        public bool TryRemoveAll(Vector2Int in_position)
        {
            // TODO: Implement this.
            return false;
        }
        #endregion

        #region Parquet Adjustment Methods
        /// <summary>
        /// Tries to dig in the specified location.
        /// </summary>
        /// <param name="in_position">The position at which to attempt digging.</param>
        /// <returns><c>true</c>, if the position was diggable, <c>false</c> otherwise.</returns>
        public bool TryToDig(Vector2Int in_position)
        {
            // TODO: Implement this.
            return false;
        }

        /// <summary>
        /// Tries to decrese the toughness of the block or furnishing at the given position.
        /// </summary>
        /// <param name="in_position">The position whose toughness should be reduced.</param>
        /// <param name="in_amount">The amount of toughness to reduce.</param>
        /// <returns><c>true</c>, if toughness was reduced, <c>false</c> otherwise.</returns>
        public bool TryToReduceToughness(Vector2Int in_position, int in_amount)
        {
            // TODO: Implement this.
            return false;
        }

        /// <summary>
        /// Tries to reset the toughness of the block or furnishing at the given position.
        /// </summary>
        /// <param name="in_position">The position whose toughness should be restored.</param>
        /// <returns><c>true</c>, if toughness was restored, <c>false</c> otherwise.</returns>
        public bool TryToRestoreToughness(Vector2Int in_position)
        {
            // TODO: Implement this.
            return false;
        }
        #endregion
        #endregion

        #region State Query Methods
        /// <summary>
        /// Checks if the given position is open to walking characters.
        /// </summary>
        /// <param name="in_position">The position to check.</param>
        /// <returns><c>true</c>, if position is walkable, <c>false</c> otherwise.</returns>
        public bool IsPositionWalkable(Vector2Int in_position)
        {
            // TODO: Implement this.
            return false;
        }

        /// <summary>
        /// Checks if the given position has been dug out.
        /// </summary>
        /// <param name="in_position">The position to check.</param>
        /// <returns><c>true</c>, if position is a hole, <c>false</c> otherwise.</returns>
        public bool IsPositionAHole(Vector2Int in_position)
        {
            // TODO: Implement this.
            return false;
        }

        /// <summary>
        /// Checks if the given position contains a flammable block or furnishing.
        /// </summary>
        /// <param name="in_position">The position to check.</param>
        /// <returns><c>true</c>, if position contains a flammable item, <c>false</c> otherwise.</returns>
        public bool IsPositionFlammable(Vector2Int in_position)
        {
            // TODO: Implement this.
            return false;
        }

        /// <summary>
        /// Checks if the given position contains a liquid.
        /// </summary>
        /// <param name="in_position">The position to check.</param>
        /// <returns><c>true</c>, if position contains a liquid, <c>false</c> otherwise.</returns>
        public bool IsPositionLiquid(Vector2Int in_position)
        {
            // TODO: Implement this.
            return false;
        }

        /// <summary>
        /// Gets the position toughness.
        /// </summary>
        /// <param name="in_position">The position whose toughness is sought.</param>
        /// <returns>Toughtness at the given position</returns>
        public int GetBlockToughnessAtPosition(Vector2Int in_position)
        {
            // TODO: Implement this.
            return 0;
        }

        /// <summary>
        /// Gets any collectable parquets at the position.
        /// </summary>
        /// <param name="in_position">The position whose collectable is sought.</param>
        /// <returns>The collectable at the given position, or <c>null</c> if there is none.</returns>
        public int GetCollectableAtPosition(Vector2Int in_position)
        {
            // TODO: Implement this.
            return 0;
        }
        #endregion

        #region Utility Methods
        /// <summary>
        /// Fills the region with a test pattern.
        /// Intended for debugging.
        /// </summary>
        // TODO: This method belongs in some test class, not in the actual model
        public void FillTestPattern()
        {
            // TODO: Insert meaningful instantiations here, rather thn simply default constructors, i.e. new parquet().
            for (var x = 0; x < Dimensions.x; x++)
            {
                for (var y = 0; y < Dimensions.y; y++)
                {
                    _floorLayer[x, y] = new Floor();
                }
            }
            for (var x = 0; x < Dimensions.x; x++)
            {
                _blockLayer[x, 0] = new Block();
                _blockLayer[x, Dimensions.y - 1] = new Block();
            }
            for (var y = 0; y < Dimensions.y; y++)
            {
                _blockLayer[0, y] = new Block();
                _blockLayer[Dimensions.x - 1, y] = new Block();
            }
            _furnishingsLayer[1, 2] = new Furnishing();
            _collectablesLayer[3, 3] = new Collectable();
        }

        /// <summary>
        /// Visualizes the region as a string with merged layers.
        /// Intended for Console debugging.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Queertet.Sandbox.RegionMap"/>.</returns>
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
                        _collectablesLayer[x, y]?.ToString()
                        ?? _furnishingsLayer[x, y]?.ToString()
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
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Queertet.Sandbox.RegionMap"/>.</returns>
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
                    furnishingsRepresentation.Append(_furnishingsLayer[x, y]?.ToString() ?? " ");
                    collectablesRepresentation.Append(_collectablesLayer[x, y]?.ToString() ?? " ");
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
