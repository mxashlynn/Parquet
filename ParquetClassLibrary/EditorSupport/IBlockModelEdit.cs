using ParquetClassLibrary.Items;
using ParquetClassLibrary.Parquets;

namespace ParquetClassLibrary.EditorSupport
{
    /// <summary>
    /// Facilitates editing of a <see cref="BlockModel"/> from design tools while maintaining a read-only face for use during play.
    /// </summary>
    /// <remarks>
    /// By design, children of <see cref="BlockModel"/> should never themselves use <see cref="IBlockModelEdit"/>.
    /// IBlockModelEdit is for use only by external types that require read/write access to model properties.
    /// </remarks>
    public interface IBlockModelEdit : IParquetModelEdit
    {
        /// <summary>The tool used to remove the block.</summary>
        public GatheringTool GatherTool { get; set; }

        /// <summary>The effect generated when a character gathers this Block.</summary>
        public GatheringEffect GatherEffect { get; set; }

        /// <summary>The Collectible spawned when a character gathers this Block.</summary>
        public ModelID CollectibleID { get; set; }

        /// <summary>Whether or not the block is flammable.</summary>
        public bool IsFlammable { get; set; }

        /// <summary>Whether or not the block is a liquid.</summary>
        public bool IsLiquid { get; set; }

        /// <summary>The block's native toughness.</summary>
        public int MaxToughness { get; set; }
    }
}
