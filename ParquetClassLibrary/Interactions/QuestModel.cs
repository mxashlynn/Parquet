using System.Collections.Generic;
using System.Linq;
using CsvHelper.TypeConversion;

namespace ParquetClassLibrary.Interactions
{
    /// <summary>
    /// Models a quest that an <see cref="Beings.NPCModel"/> may give to a <see cref="Beings.PlayerCharacterModel"/> embodies.
    /// </summary>
    public sealed class QuestModel : InteractionModel, ITypeConverter
    {
        #region Characteristics
        /// <summary>
        /// Describes the criteria for completing this <see cref="QuestModel"/>.
        /// </summary>
        public IReadOnlyList<EntityTag> CompletionRequirements { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="QuestModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="QuestModel"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="QuestModel"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="QuestModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="QuestModel"/>.</param>
        /// <param name="inStartCriteria">Describes the criteria for completing this <see cref="DialogueModel"/>.</param>
        /// <param name="inSteps">Describes the criteria for completing this <see cref="DialogueModel"/>.</param>
        /// <param name="inOutcome">Describes the criteria for completing this <see cref="DialogueModel"/>.</param>
        /// <param name="inCompletionRequirements">Describes the criteria for completing this <see cref="QuestModel"/>.</param>
        public QuestModel(EntityID inID, string inName, string inDescription, string inComment,
                          IEnumerable<EntityTag> inStartCriteria, IEnumerable<string> inSteps, string inOutcome,
                          IEnumerable<EntityTag> inCompletionRequirements)
            : base(All.QuestIDs, inID, inName, inDescription, inComment, inStartCriteria, inSteps, inOutcome)
        {
            CompletionRequirements = (inCompletionRequirements ?? Enumerable.Empty<EntityTag>()).ToList();
        }
        #endregion

        #region ITypeConverter Implementation

        #endregion
    }
}
