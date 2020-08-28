using System.Collections.Generic;
using System.Linq;
using CsvHelper.Configuration.Attributes;

namespace ParquetClassLibrary.Scripts
{
    /// <summary>
    /// Models input, output, and process of an in-game interaction.
    /// This could be a quest, cutscene, environmental effect, or dialogue between <see cref="Beings.CharacterModel"/>s
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1033:Interface methods should be callable by child types",
        Justification = "By design, children of Model should never themselves use IModelEdit or its decendent interfaces to access their own members.  The IModelEdit family of interfaces is for external types that require read/write access.")]
    public class InteractionModel : Model, IInteractionModelEdit
    {
        #region Characteristics
        /// <summary>Describes the criteria for begining this interaction.</summary>
        [Index(4)]
        public IReadOnlyList<ModelID> PrerequisitesIDs { get; }

        /// <summary>
        /// Describes the criteria for begining this interaction.
        /// </summary>
        /// <remarks>
        /// By design, children of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        IList<ModelID> IInteractionModelEdit.PrerequisitesIDs => (IList<ModelID>)PrerequisitesIDs;

        /// <summary>Everything this interaction entails.</summary>
        [Index(5)]
        public IReadOnlyList<ModelID> StepsIDs { get; }

        /// <summary>
        /// Everything this interaction entails.
        /// </summary>
        /// <remarks>
        /// By design, children of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        IList<ModelID> IInteractionModelEdit.StepsIDs => (IList<ModelID>)StepsIDs;

        /// <summary>Describes the results of finishing this interaction.</summary>
        [Index(6)]
        public IReadOnlyList<ModelID> OutcomesIDs { get; }

        /// <summary>
        /// Describes the results of finishing this interaction.
        /// </summary>
        /// <remarks>
        /// By design, children of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        IList<ModelID> IInteractionModelEdit.OutcomesIDs => (IList<ModelID>)OutcomesIDs;
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="InteractionModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="InteractionModel"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="InteractionModel"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="InteractionModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="InteractionModel"/>.</param>
        /// <param name="inPrerequisites">Describes the criteria for beginning this <see cref="InteractionModel"/>.</param>
        /// <param name="inSteps">Describes the criteria for completing this <see cref="InteractionModel"/>.</param>
        /// <param name="inOutcomes">Describes the results of finishing this <see cref="InteractionModel"/>.</param>
        public InteractionModel(ModelID inID, string inName, string inDescription, string inComment,
                                IEnumerable<ModelID> inPrerequisites, IEnumerable<ModelID> inSteps, IEnumerable<ModelID> inOutcomes)
            : base(All.InteractionIDs, inID, inName, inDescription, inComment)
        {
            var nonNullPrerequisites = inPrerequisites ?? Enumerable.Empty<ModelID>();
            var nonNullSteps = inSteps ?? Enumerable.Empty<ModelID>();
            var nonNullOutcomes = inOutcomes ?? Enumerable.Empty<ModelID>();
            Precondition.AreInRange(nonNullPrerequisites, All.ScriptIDs, nameof(inPrerequisites));
            Precondition.AreInRange(nonNullSteps, All.ScriptIDs, nameof(inSteps));
            Precondition.AreInRange(nonNullOutcomes, All.ScriptIDs, nameof(inOutcomes));

            PrerequisitesIDs = nonNullPrerequisites.ToList();
            StepsIDs = nonNullSteps.ToList();
            OutcomesIDs = nonNullOutcomes.ToList();
        }
        #endregion
    }
}
