using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CsvHelper.Configuration.Attributes;

namespace Parquet.Scripts
{
    /// <summary>
    /// Models a series of imperative, procedural commands.
    /// This might be an AI behavior, for example.
    /// </summary>
    public class ScriptModel : Model, IMutableScriptModel
    {
        #region Characteristics
        /// <summary>A series of imperative, procedural commands.</summary>
        // TODO [SCRIPTING] This likely needs to be a sorted list.  Is there an IReadOnlySortedList?
        // ANSWER: The closest thing I can find is SortedList<TV,TK> which only implements ISortedCollection
        // and ISortedDictionary.  See for more: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.sortedlist-2?view=net-5.0
        [Index(5)]
        public IReadOnlyList<ScriptNode> Nodes { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptModel"/> class.
        /// </summary>
        /// <param name="id">Unique identifier for the <see cref="ScriptModel"/>.  Cannot be null.</param>
        /// <param name="name">Player-friendly name of the <see cref="ScriptModel"/>.  Cannot be null or empty.</param>
        /// <param name="description">Player-friendly description of the <see cref="ScriptModel"/>.</param>
        /// <param name="comment">Comment of, on, or by the <see cref="ScriptModel"/>.</param>
        /// <param name="tags">Any additional information about this <see cref="ScriptModel"/>.</param>
        /// <param name="inNodes">Describes the criteria for completing this <see cref="InteractionModel"/>.</param>
        public ScriptModel(ModelID id, string name, string description, string comment,
                           IEnumerable<ModelTag> tags = null, IEnumerable<ScriptNode> inNodes = null)
            : base(All.ScriptIDs, id, name, description, comment, tags)
            => Nodes = (inNodes ?? Enumerable.Empty<ScriptNode>()).ToList();
        #endregion

        #region IMutableScriptModel Implementation
        /// <summary>A series of imperative, procedural commands.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="ScriptModel"/> should never themselves use <see cref="IMutableScriptModel"/>.
        /// IMutableScriptModel is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ICollection<ScriptNode> IMutableScriptModel.Nodes
            => LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(Nodes), new Collection<ScriptNode>())
                : (ICollection<ScriptNode>)Nodes;
        #endregion

        #region Utilities
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
        #endregion
    }
}
