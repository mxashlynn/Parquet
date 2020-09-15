#if DESIGN
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.EditorSupport;
using ParquetClassLibrary.Items;

namespace ParquetClassLibrary.Parquets
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
        Justification = "By design, subtypes of Model should never themselves use IModelEdit or derived interfaces to access their own members.  The IModelEdit family of interfaces is for external types that require read/write access.")]
    public partial class BlockModel : IBlockModelEdit
    {
        #region IBlockModelEdit Implementation
        /// <summary>The tool used to remove the block.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="BlockModel"/> should never themselves use <see cref="IBlockModelEdit"/>.
        /// IBlockModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        GatheringTool IBlockModelEdit.GatherTool { get => GatherTool; set => GatherTool = value; }

        /// <summary>The effect generated when a character gathers this Block.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="BlockModel"/> should never themselves use <see cref="IBlockModelEdit"/>.
        /// IBlockModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        GatheringEffect IBlockModelEdit.GatherEffect { get => GatherEffect; set => GatherEffect = value; }

        /// <summary>The Collectible spawned when a character gathers this Block.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="BlockModel"/> should never themselves use <see cref="IBlockModelEdit"/>.
        /// IBlockModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ModelID IBlockModelEdit.CollectibleID { get => CollectibleID; set => CollectibleID = value; }

        /// <summary>Whether or not the block is flammable.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="BlockModel"/> should never themselves use <see cref="IBlockModelEdit"/>.
        /// IBlockModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        bool IBlockModelEdit.IsFlammable { get => IsFlammable; set => IsFlammable = value; }

        /// <summary>Whether or not the block is a liquid.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="BlockModel"/> should never themselves use <see cref="IBlockModelEdit"/>.
        /// IBlockModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        bool IBlockModelEdit.IsLiquid { get => IsLiquid; set => IsLiquid = value; }

        /// <summary>The block's native toughness.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="BlockModel"/> should never themselves use <see cref="IBlockModelEdit"/>.
        /// IBlockModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        int IBlockModelEdit.MaxToughness { get => MaxToughness; set => MaxToughness = value; }
        #endregion
    }
}
#endif
