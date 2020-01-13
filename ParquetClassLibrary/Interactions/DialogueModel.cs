using System.Collections.Generic;

namespace ParquetClassLibrary.Interactions
{
    /// <summary>
    /// Models dialogue that an <see cref="Beings.NPC"/> may communicate.
    /// </summary>
    public sealed class DialogueModel : InteractionModel
    {
        // TODO This is a stub.
        #region Characteristics

        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="DialogueModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="DialogueModel"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="DialogueModel"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="DialogueModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="DialogueModel"/>.</param>
        /// <param name="inStartCriteria">Describes the criteria for completing this <see cref="DialogueModel"/>.</param>
        /// <param name="inSteps">Describes the criteria for completing this <see cref="DialogueModel"/>.</param>
        /// <param name="inOutcome">Describes the criteria for completing this <see cref="DialogueModel"/>.</param>
        /// <param name="inStatus">The current status of this <see cref="InteractionModel"/>.</param>
        public DialogueModel(EntityID inID, string inName, string inDescription, string inComment,
            List<EntityTag> inStartCriteria, List<string> inSteps, string inOutcome, string inStatus)
            : base(All.DialogueIDs, inID, inName, inDescription, inComment, inStartCriteria, inSteps, inOutcome, inStatus)
        {
            // TODO When implementing dialogue processing (displaying on screen), rememeber to replace a key such as ":they:" with the appropriate pronoun.
        }
        #endregion
    }
}
