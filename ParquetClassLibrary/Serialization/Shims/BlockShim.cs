using ParquetClassLibrary.Items;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Serialization.Shims
{
    /// <summary>
    /// Provides a default public parameterless constructor for a
    /// <see cref="Block"/>-like class that CSVHelper can instantiate.
    /// 
    /// Provides the ability to generate a <see cref="Block"/> from this class.
    /// </summary>
    public class BlockShim : ParquetParentShim
    {
        /// <summary>The tool used to remove the block.</summary>
        public GatheringTool GatherTool;

        /// <summary>The effect generated when a character gathers this Block.</summary>
        public GatherEffect GatherEffect;

        /// <summary>The collectible spawned when a character gathers this Block.</summary>
        public EntityID CollectibleID;

        /// <summary>The block is flammable.</summary>
        public bool IsFlammable;

        /// <summary>The block is a liquid.</summary>
        public bool IsLiquid;

        /// <summary>The block's native toughness.</summary>
        public int MaxToughness;

        /// <summary>
        /// Converts a shim into the class it corresponds to.
        /// </summary>
        /// <typeparam name="T">The type to convert this shim to.</typeparam>
        /// <returns>An instance of a child class of <see cref="ParquetParent"/>.</returns>
        public override T ToEntity<T>()
        {
            Precondition.IsOfType<T, Block>(typeof(T).ToString());

            return (T)(EntityModel)new Block(ID, Name, Description, Comment, ItemID, AddsToBiome,
                                             AddsToRoom, GatherTool, GatherEffect, CollectibleID,
                                             IsFlammable, IsLiquid, MaxToughness);
        }
    }
}
