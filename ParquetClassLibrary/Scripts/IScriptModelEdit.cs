using System.Collections.Generic;

namespace ParquetClassLibrary.Scripts
{
    /// <summary>
    /// Facilitates editing of a <see cref="ScriptModel"/> from design tools while maintaining a read-only face for use during play.
    /// </summary>
    public interface IScriptModelEdit : IModelEdit
    {
        /// <summary>
        /// A series of imperative, procedural commands.
        /// </summary>
        public IList<ScriptNode> Nodes { get; }
    }
}
