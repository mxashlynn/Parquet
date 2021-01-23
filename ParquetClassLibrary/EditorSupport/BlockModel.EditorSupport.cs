#if DESIGN
using System.Diagnostics.CodeAnalysis;
using CsvHelper.Configuration.Attributes;
using Parquet.EditorSupport;
using Parquet.Items;

namespace Parquet.Parquets
{
    [SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
                     Justification = "By design, subtypes of Model should never themselves use IMutableModel or derived interfaces to access their own members.  The IMutableModel family of interfaces is for external types that require read/write access.")]
    public partial class BlockModel : IMutableBlockModel
    {
        #region IBlockModelEdit Implementation
        /// <summary>The tool used to remove the block.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="BlockModel"/> should never themselves use <see cref="IMutableBlockModel"/>.
        /// IBlockModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        GatheringTool IMutableBlockModel.GatherTool { get => GatherTool; set => GatherTool = value; }

        /// <summary>The effect generated when a character gathers this Block.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="BlockModel"/> should never themselves use <see cref="IMutableBlockModel"/>.
        /// IBlockModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        GatheringEffect IMutableBlockModel.GatherEffect { get => GatherEffect; set => GatherEffect = value; }

        /// <summary>The Collectible spawned when a character gathers this Block.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="BlockModel"/> should never themselves use <see cref="IMutableBlockModel"/>.
        /// IBlockModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ModelID IMutableBlockModel.CollectibleID { get => CollectibleID; set => CollectibleID = value; }

        /// <summary>Whether or not the block is flammable.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="BlockModel"/> should never themselves use <see cref="IMutableBlockModel"/>.
        /// IBlockModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        bool IMutableBlockModel.IsFlammable { get => IsFlammable; set => IsFlammable = value; }

        /// <summary>Whether or not the block is a liquid.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="BlockModel"/> should never themselves use <see cref="IMutableBlockModel"/>.
        /// IBlockModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        bool IMutableBlockModel.IsLiquid { get => IsLiquid; set => IsLiquid = value; }

        /// <summary>The block's native toughness.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="BlockModel"/> should never themselves use <see cref="IMutableBlockModel"/>.
        /// IBlockModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        int IMutableBlockModel.MaxToughness { get => MaxToughness; set => MaxToughness = value; }
        #endregion
    }
}
#endif
