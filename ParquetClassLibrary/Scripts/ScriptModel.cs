using System;
using System.Collections.Generic;
using System.Linq;
using CsvHelper.Configuration.Attributes;

namespace ParquetClassLibrary.Scripts
{
    /// <summary>
    /// Models a series of imperative, procedural commands.
    /// </summary>
    public class ScriptModel : Model, IScriptModelEdit
    {
        #region Characteristics
        /// <summary>A series of imperative, procedural commands.</summary>
        [Index(4)]
        public IReadOnlyList<ScriptNode> Nodes { get; }

        /// <summary>A series of imperative, procedural commands.</summary>
        /// <remarks>
        /// By design, children of <see cref="ScriptModel"/> should never themselves use <see cref="IScriptModelEdit"/>.
        /// IScriptModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        IList<ScriptNode> IScriptModelEdit.Nodes => (IList<ScriptNode>)Nodes;
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="ScriptModel"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="ScriptModel"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="ScriptModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="ScriptModel"/>.</param>
        /// <param name="inNodes">Describes the criteria for completing this <see cref="InteractionModel"/>.</param>
        public ScriptModel(ModelID inID, string inName, string inDescription, string inComment, IEnumerable<ScriptNode> inNodes = null)
            : base(All.ScriptIDs, inID, inName, inDescription, inComment)
            => Nodes = (inNodes ?? Enumerable.Empty<ScriptNode>()).ToList();
        #endregion

        /// <summary>
        /// Yields an <see cref="Action"/> for each <see cref="ScriptNode"/>, in order.
        /// </summary>
        /// <returns>The action to perform for the current node.</returns>
        public IEnumerable<Action> GetActions()
        {
            for (var i = 0; i < Nodes.Count; i++)
            {
                yield return Nodes[i].GetAction();
            }
        }
    }
}
