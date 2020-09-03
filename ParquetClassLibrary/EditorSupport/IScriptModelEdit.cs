using System.Collections.Generic;
using ParquetClassLibrary.Scripts;

namespace ParquetClassLibrary.EditorSupport
{
    /// <summary>
    /// Facilitates editing of a <see cref="ScriptModel"/> from design tools while maintaining a read-only face for use during play.
    /// </summary>
    /// <remarks>
    /// By design, subtypes of <see cref="ScriptModel"/> should never themselves use <see cref="IScriptModelEdit"/>.
    /// IScriptModelEdit is for use only by external types that require read/write access to model properties.
    /// </remarks>
    public interface IScriptModelEdit : IModelEdit
    {
        /// <summary>
        /// A series of imperative, procedural commands.
        /// </summary>
        public IList<ScriptNode> Nodes { get; }
    }
}
