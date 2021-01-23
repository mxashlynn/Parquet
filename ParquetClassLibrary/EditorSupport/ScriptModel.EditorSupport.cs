#if DESIGN
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CsvHelper.Configuration.Attributes;
using Parquet.EditorSupport;

namespace Parquet.Scripts
{
    [SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
                     Justification = "By design, subtypes of Model should never themselves use IMutableModel or derived interfaces to access their own members.  The IMutableModel family of interfaces is for external types that require read/write access.")]
    public partial class ScriptModel : IMutableScriptModel
    {
        #region IScriptModelEdit Implementation
        /// <summary>A series of imperative, procedural commands.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="ScriptModel"/> should never themselves use <see cref="IMutableScriptModel"/>.
        /// IScriptModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ICollection<ScriptNode> IMutableScriptModel.Nodes => (ICollection<ScriptNode>)Nodes;
        #endregion
    }
}
#endif
