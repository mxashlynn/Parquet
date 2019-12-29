using System.Collections.Generic;
using System.Linq;

namespace ParquetClassLibrary.Quests
{
    /// <summary>
    /// Models a quest that an <see cref="Beings.NPC"/> may give to a <see cref="Beings.PlayerCharacter"/> embodies.
    /// </summary>
    public class Quest : Entity
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
        /// <param name="in_id">Unique identifier for the <see cref="Quest"/>.  Cannot be null.</param>
        /// <param name="in_name">Player-friendly name of the <see cref="Quest"/>.  Cannot be null or empty.</param>
        /// <param name="in_description">Player-friendly description of the <see cref="Quest"/>.</param>
        /// <param name="in_comment">Comment of, on, or by the <see cref="Quest"/>.</param>
        /// <param name="in_completionRequirements">Describes the criteria for completing this <see cref="Quest"/>.</param>
        public Quest(EntityID in_id, string in_name, string in_description, string in_comment,
                     List<EntityTag> in_completionRequirements)
            : base(All.QuestIDs, in_id, in_name, in_description, in_comment)
        {
            CompletionRequirements = (in_completionRequirements ?? Enumerable.Empty<EntityTag>()).ToList();
        }
        #endregion
    }
}
