using System.Collections.Generic;

namespace ParquetClassLibrary.Interactions
{
    /// <summary>
    /// Models a quest that a may be offered or undertaken by a <see cref="Beings.CharacterModel"/>.
    /// </summary>
    public sealed class QuestModel : InteractionModel
    {
        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="QuestModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="QuestModel"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="QuestModel"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="QuestModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="QuestModel"/>.</param>
        /// <param name="inPrerequisites">Describes the criteria for beginning this <see cref="QuestModel"/>.</param>
        /// <param name="inSteps">Describes the criteria for completing this <see cref="QuestModel"/>.</param>
        /// <param name="inOutcome">Describes the results of completing this <see cref="QuestModel"/>.</param>
        public QuestModel(ModelID inID, string inName, string inDescription, string inComment,
                          IEnumerable<ModelID> inPrerequisites, IEnumerable<ModelID> inSteps, IEnumerable<ModelID> inOutcome)
            : base(All.QuestIDs, inID, inName, inDescription, inComment, inPrerequisites, inSteps, inOutcome)
        { }
        #endregion
    }
}
