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
        public Vector2 dimensions;
        #endregion

        #region Contents of the region.
        /// <summary>A color to display in any empty areas of the region.</summary>
        private Color _background;

        /// <summary>The region's dimensions.</summary>
        // TODO: Probably it is a better idea to store these as IDs that reference their floor type.
        private Floor[,] _floorLayer;

        /// <summary>The region's dimensions.</summary>
        // TODO: Probably it is a better idea to store these as IDs that reference their floor type.
        private Block[,] _blockLayer;
        
        /// <summary>The region's dimensions.</summary>
        // TODO: I'm gussing these are classes or structs, not IDs.
        private Entity[,] _entitiesLayer;
        
        // IDEA: a foreground layer?
        #endregion

        #region Methods for working with Blocks
        #endregion
    }
}
