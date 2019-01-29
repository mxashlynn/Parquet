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
                    var tile = _floorLayer[x, y]?.ToString() ?? "@";
                    tile = _blockLayer[x, y]?.ToString() ?? tile;
                    tile = _furnishingsLayer[x, y]?.ToString() ?? tile;
                    tile = _craftingMaterialsLayer[x, y]?.ToString() ?? tile;

                    representation.Append(tile);
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
            var craftingMaterialsRepresentation = new StringBuilder(Dimensions.x * Dimensions.y);
            #region Compose visual represenation of contents.
            for (var x = 0; x < Dimensions.x; x++)
            {
                for (var y = 0; y < Dimensions.y; y++)
                {
                    floorRepresentation.Append(_floorLayer[x, y]?.ToString() ?? "@");
                    blocksRepresentation.Append(_blockLayer[x, y]?.ToString() ?? " ");
                    furnishingsRepresentation.Append(_furnishingsLayer[x, y]?.ToString() ?? " ");
                    craftingMaterialsRepresentation.Append(_craftingMaterialsLayer[x, y]?.ToString() ?? " ");
                }
                floorRepresentation.AppendLine();
                blocksRepresentation.AppendLine();
                furnishingsRepresentation.AppendLine();
                craftingMaterialsRepresentation.AppendLine();
            }
            #endregion

            return "Region " + Title + " (" + Dimensions.x + ", " + Dimensions.y + ")\n" +
                "Floor: \n" + floorRepresentation +
                "Blocks: \n" + blocksRepresentation +
                "Furnishings: \n" + furnishingsRepresentation +
                "Crafting Materials: \n" + craftingMaterialsRepresentation;
        }
        #endregion
    }
}
