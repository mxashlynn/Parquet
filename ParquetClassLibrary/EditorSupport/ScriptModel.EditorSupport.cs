#if DESIGN
using System.Collections.Generic;
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.EditorSupport;

namespace ParquetClassLibrary.Scripts
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
        Justification = "By design, subtypes of Model should never themselves use IModelEdit or derived interfaces to access their own members.  The IModelEdit family of interfaces is for external types that require read/write access.")]
    public partial class ScriptModel : IScriptModelEdit
    {
        #region IScriptModelEdit Implementation
        /// <summary>A series of imperative, procedural commands.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="ScriptModel"/> should never themselves use <see cref="IScriptModelEdit"/>.
        /// IScriptModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        IList<ScriptNode> IScriptModelEdit.Nodes => (IList<ScriptNode>)Nodes;
        #endregion
    }
}
#endif
