using System.Diagnostics.CodeAnalysis;
using CsvHelper.Configuration.Attributes;
using Parquet.EditorSupport;
using Parquet.Items;

namespace Parquet.Parquets
{
    [SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
                     Justification = "By design, subtypes of Model should never themselves use IMutableModel or derived interfaces to access their own members.  The IMutableModel family of interfaces is for external types that require read/write access.")]
    public partial class FloorModel : IMutableFloorModel
    {
        #region IFloorModelEdit Implementation
        /// <summary>The tool used to dig out or fill in the floor.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ModificationTool IMutableFloorModel.ModTool { get => ModTool; set => ModTool = value; }

        /// <summary>Player-facing name of the parquet, used when it has been dug out.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        string IMutableFloorModel.TrenchName { get => TrenchName; set => TrenchName = value; }
        #endregion
    }
}
