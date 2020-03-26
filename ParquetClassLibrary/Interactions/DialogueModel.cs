using System.Collections.Generic;
using System.Linq;
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Interactions
{
    /// <summary>
    /// Models dialogue displayed as though someone were talking.
    /// </summary>
    public sealed class DialogueModel : InteractionModel
    {
        #region Characteristics
        /// <summary>
        /// <see cref="Beings.CharacterModel"/>s present during this <see cref="DialogueModel"/>.
        /// </summary>
        [Index(7)]
        public IReadOnlyList<ModelID> Participants { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="DialogueModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="DialogueModel"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="DialogueModel"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="DialogueModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="DialogueModel"/>.</param>
        /// <param name="inPrerequisites">Describes the criteria for beginning this <see cref="DialogueModel"/>.</param>
        /// <param name="inSteps">Describes the criteria for completing this <see cref="DialogueModel"/>.</param>
        /// <param name="inOutcome">Describes the criteria for completing this <see cref="DialogueModel"/>.</param>
        /// <param name="inParticipants">Describes the <see cref="Beings.CharacterModel"/>s present during this <see cref="DialogueModel"/>.</param>
        public DialogueModel(ModelID inID, string inName, string inDescription, string inComment,
            IEnumerable<ModelID> inPrerequisites, IEnumerable<ModelID> inSteps, IEnumerable<ModelID> inOutcome, IEnumerable<ModelID> inParticipants)
            : base(All.DialogueIDs, inID, inName, inDescription, inComment, inPrerequisites, inSteps, inOutcome)
        {
            Precondition.AreInRange(inParticipants, All.CharacterIDs, nameof(inParticipants));

            Participants = inParticipants.ToList();
            // TODO When implementing dialogue processing (displaying on screen), rememeber to replace a key such as ":they:" with the appropriate pronoun.
        }
        #endregion
    }
}
