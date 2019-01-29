using System;
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
        public static readonly Vector2Int Dimensions = new Vector2Int(5, 5);

        /// <summary>Default name for new regions.</summary>
        public const string DefaultTitle = "New Region";
        #endregion

        #region Region Data
        /// <summary>What the region is called in-game.</summary>
        public string Title { get; private set; }

        /// <summary>A color to display in any empty areas of the region.</summary>
        public Color Background { get; private set; }
        #endregion

        #region Contents of the region.
        /// <summary>Floors and walkable terrain in the region.</summary>
        private readonly Floor[,] _floorLayer = new Floor[Dimensions.x, Dimensions.y];

        /// <summary>Walls and obstructing terrain in the region.</summary>
        private Block[,] _blockLayer = new Block[Dimensions.x, Dimensions.y];

        /// <summary>Furniture and natural items in the region.</summary>
        private Furnishing[,] _furnishingsLayer = new Furnishing[Dimensions.x, Dimensions.y];

        /// <summary>Collectable materials in the region.</summary>
        private CraftingMaterial[,] _craftingMaterialsLayer = new CraftingMaterial[Dimensions.x, Dimensions.y];

        // IDEA: a foreground layer?
        #endregion

        #region Initialization
        /// <summary>
        /// Constructs a new instance of the <see cref="T:Queertet.Sandbox.RegionMap"/> class.
        /// </summary>
        /// <param name="in_title">The name of the new region.</param>
        /// <param name="in_background">Background color for the region.</param>
        public RegionMap(string in_title = DefaultTitle, Color? in_background = null)
            // Assign defaults that cannot be specified in the argument list.
            => Background = in_background ?? Color.white;

        /// <summary>
        /// Fills the region with a test pattern.
        /// </summary>
        public void FillTextPattern()
        {
            for (var x = 0; x < Dimensions.x; x++)
            {
                for (var y = 0; y < Dimensions.y; y++)
                {
                    // TODO: Insert meaningful instantiations here.
                    _floorLayer[x,y] = new Floor();
                    _blockLayer[x, y] = new Block();
                    _furnishingsLayer[x, y] = new Furnishing();
                    _craftingMaterialsLayer[x, y] = new CraftingMaterial();
                }
            }
        }
        #endregion

        #region Utility Methods
        public override string ToString()
        {
            return "Region: " + Title +
                   " (" + Dimensions.x + ", " + Dimensions.y +")\n\n";
        }
        #endregion
    }
}
