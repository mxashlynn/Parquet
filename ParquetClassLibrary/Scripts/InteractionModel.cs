using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CsvHelper.Configuration.Attributes;

namespace Parquet.Scripts
{
    /// <summary>
    /// Models input, output, and process of an in-game interaction.
    /// This could be a quest, cutscene, environmental effect, or dialogue between <see cref="Beings.CharacterModel"/>s
    /// </summary>
    public class InteractionModel : Model, IMutableInteractionModel
    {
        #region Characteristics
        /// <summary>Describes the criteria for beginning this interaction.</summary>
        [Index(5)]
        public IReadOnlyList<ModelID> PrerequisitesIDs { get; }

        /// <summary>Everything this interaction entails.</summary>
        // TODO [SCRIPTING] This likely needs to be a sorted list.  Is there an IReadOnlySortedList?
        // ANSWER: The closest thing I can find is SortedList<TV,TK> which only implements ISortedCollection
        // and ISortedDictionary.  See for more: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.sortedlist-2?view=net-5.0
        [Index(6)]
        public IReadOnlyList<ModelID> StepsIDs { get; }

        /// <summary>Describes the results of finishing this interaction.</summary>
        [Index(7)]
        public IReadOnlyList<ModelID> OutcomesIDs { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="InteractionModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="InteractionModel"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="InteractionModel"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="InteractionModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="InteractionModel"/>.</param>
        /// <param name="inTags">Any additional information about this <see cref="InteractionModel"/>.</param>
        /// <param name="inPrerequisitesIDs">Describes the criteria for beginning this <see cref="InteractionModel"/>.</param>
        /// <param name="inStepsIDs">Describes the criteria for completing this <see cref="InteractionModel"/>.</param>
        /// <param name="inOutcomesIDs">Describes the results of finishing this <see cref="InteractionModel"/>.</param>
        public InteractionModel(ModelID inID, string inName, string inDescription, string inComment,
                                IEnumerable<ModelTag> inTags = null, IEnumerable<ModelID> inPrerequisitesIDs = null,
                                IEnumerable<ModelID> inStepsIDs = null, IEnumerable<ModelID> inOutcomesIDs = null)
            : base(All.InteractionIDs, inID, inName, inDescription, inComment, inTags)
        {
            var nonNullPrerequisites = (inPrerequisitesIDs ?? Enumerable.Empty<ModelID>()).ToList();
            var nonNullSteps = (inStepsIDs ?? Enumerable.Empty<ModelID>()).ToList();
            var nonNullOutcomes = (inOutcomesIDs ?? Enumerable.Empty<ModelID>()).ToList();

            Precondition.AreInRange(nonNullPrerequisites, All.ScriptIDs, nameof(inPrerequisitesIDs));
            Precondition.AreInRange(nonNullSteps, All.ScriptIDs, nameof(inStepsIDs));
            Precondition.AreInRange(nonNullOutcomes, All.ScriptIDs, nameof(inOutcomesIDs));

            PrerequisitesIDs = nonNullPrerequisites;
            StepsIDs = nonNullSteps;
            OutcomesIDs = nonNullOutcomes;
        }
        #endregion

        #region IMutableInteractionModel Implementation
        /// <summary>
        /// Describes the criteria for beginning this interaction.
        /// </summary>
        /// <remarks>
        /// By design, subtypes of <see cref="InteractionModel"/> should never themselves use <see cref="IMutableInteractionModel"/>.
        /// IMutableInteractionModel is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ICollection<ModelID> IMutableInteractionModel.PrerequisitesIDs
            => LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(PrerequisitesIDs), new Collection<ModelID>())
                : (ICollection<ModelID>)PrerequisitesIDs;

        /// <summary>
        /// Everything this interaction entails.
        /// </summary>
        /// <remarks>
        /// By design, subtypes of <see cref="InteractionModel"/> should never themselves use <see cref="IMutableInteractionModel"/>.
        /// IMutableInteractionModel is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ICollection<ModelID> IMutableInteractionModel.StepsIDs
            => LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(StepsIDs), new Collection<ModelID>())
                : (ICollection<ModelID>)StepsIDs;

        /// <summary>
        /// Describes the results of finishing this interaction.
        /// </summary>
        /// <remarks>
        /// By design, subtypes of <see cref="InteractionModel"/> should never themselves use <see cref="IMutableInteractionModel"/>.
        /// IMutableInteractionModel is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ICollection<ModelID> IMutableInteractionModel.OutcomesIDs
            => LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(OutcomesIDs), new Collection<ModelID>())
                : (ICollection<ModelID>)OutcomesIDs;
        #endregion
    }
}
