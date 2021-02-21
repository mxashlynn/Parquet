using System.Collections.Generic;

namespace Parquet.Scripts
{
    /// <summary>
    /// Facilitates editing of a <see cref="ScriptModel"/> from design tools while maintaining a read-only face for use during play.
    /// </summary>
    /// <remarks>
    /// By design, subtypes of <see cref="ScriptModel"/> should never themselves use <see cref="IMutableScriptModel"/>.
    /// IScriptModelEdit is for use only by external types that require read/write access to model properties.
    /// </remarks>
    public interface IMutableScriptModel : IMutableModel
    {
        /// <summary>
        /// A series of imperative, procedural commands.
        /// </summary>
        public ICollection<ScriptNode> Nodes { get; }
    }
}
