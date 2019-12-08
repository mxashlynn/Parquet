using ParquetClassLibrary.Items;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Utilities;

namespace ParquetCSVImporter.Shims
{
    /// <summary>
    /// Provides a default public parameterless constructor for a <see cref="Floor"/>-like
    /// class that CSVHelper can instantiate.
    /// 
    /// Provides the ability to generate a <see cref="Floor"/> from this class.
    /// </summary>
    public class FloorShim : ParquetParentShim
    {
        /// <summary>The tool used to dig out or fill in the floor.</summary>
        public ModificationTool ModTool;

        /// <summary>Player-facing name of the parquet, used when it has been dug out.</summary>
        public string TrenchName;

        /// <summary>The floor may be walked on.</summary>
        public bool IsWalkable;

        /// <summary>
        /// Converts a shim into the class is corresponds to.
        /// </summary>
        /// <typeparam name="TargetType">The type to convert this shim to.</typeparam>
        /// <returns>An instance of a child class of <see cref="ParquetParent"/>.</returns>
        public override TargetType To<TargetType>()
        {
            Precondition.IsOfType<TargetType, Floor>(typeof(TargetType).ToString());

            return (TargetType)(ParquetParent)new Floor(ID, Name, Description, Comment, ItemID, AddsToBiome,
                                                        AddsToRoom, ModTool, TrenchName, IsWalkable);
        }
    }
}
