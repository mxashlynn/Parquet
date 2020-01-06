using ParquetClassLibrary;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Serialization.Shims
{
    /// <summary>
    /// Provides a default public parameterless constructor for a <see cref="Furnishing"/>-like
    /// class that CSVHelper can instantiate.
    /// 
    /// Provides the ability to generate a <see cref="Furnishing"/> from this class.
    /// </summary>
    public class FurnishingShim : ParquetParentShim
    {
        /// <summary>Indicates if the furnishing may be walked on.</summary>
        public bool IsWalkable;

        /// <summary>Indicates if the furnishing may be entered through.</summary>
        public bool IsEntry;

        /// <summary>Indicates if the furnishing acts like a wall.</summary>
        public bool IsEnclosing;

        /// <summary>The furnishing to swap with this furnishing on an open/close action.</summary>
        public EntityID SwapID;

        /// <summary>
        /// Converts a shim into the class it corresponds to.
        /// </summary>
        /// <typeparam name="TargetType">The type to convert this shim to.</typeparam>
        /// <returns>An instance of a child class of <see cref="ParquetParent"/>.</returns>
        public override TargetType To<TargetType>()
        {
            Precondition.IsOfType<TargetType, Furnishing>(typeof(TargetType).ToString());

            return (TargetType)(Entity)new Furnishing(ID, Name, Description, Comment, ItemID, AddsToBiome,
                                                      AddsToBiome, IsWalkable, IsEntry, IsEnclosing, SwapID);
        }
    }
}
