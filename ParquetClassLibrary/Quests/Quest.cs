using System.Collections.Generic;
using System.Linq;

namespace ParquetClassLibrary.Quests
{
    /// <summary>
    /// Models a quest that an <see cref="Beings.NPC"/> may give to a <see cref="Beings.PlayerCharacter"/> embodies.
    /// </summary>
    public sealed class Quest : EntityModel
    {
        #region Characteristics
        /// <summary>
        /// Describes the criteria for completing this <see cref="Quest"/>.
        /// </summary>
        public IReadOnlyList<EntityTag> CompletionRequirements { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="Quest"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="Quest"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="Quest"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="Quest"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="Quest"/>.</param>
        /// <param name="inCompletionRequirements">Describes the criteria for completing this <see cref="Quest"/>.</param>
        public Quest(EntityID inID, string inName, string inDescription, string inComment,
                     List<EntityTag> inCompletionRequirements)
            : base(All.QuestIDs, inID, inName, inDescription, inComment)
        {
            CompletionRequirements = (inCompletionRequirements ?? Enumerable.Empty<EntityTag>()).ToList();
        }
        #endregion
    }
}
