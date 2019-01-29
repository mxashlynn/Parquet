namespace Queertet.Sandbox
{
    /// <summary>
    /// Scriptable Object containing details of a playable region in sandbox-mode.
    /// </summary>
    public class RegionMap
    {
        #region Region Data
        /// <summary>What the region is called in-game.</summary>
        public string title;

        /// <summary>The region's dimensions.</summary>
        public Stubs.Vector2 dimensions;
        #endregion

        #region Contents of the region.
        /// <summary>A color to display in any empty areas of the region.</summary>
        private Stubs.Color _background;

        /// <summary>Floors and walkable terrain in the region.</summary>
        private Floor[,] _floorLayer;

        /// <summary>Walls and obstructing terrain in the region.</summary>
        private Block[,] _blockLayer;
        
        /// <summary>Furniture and natural items in the region.</summary>
        private Furnishing[,] _furnishingsLayer;

        /// <summary>Collectable materials in the region.</summary>
        private CraftingMaterial[,] _craftingMaterialsLayer;

        // IDEA: a foreground layer?
        #endregion

        #region Methods for working with Blocks
        #endregion
    }
}
