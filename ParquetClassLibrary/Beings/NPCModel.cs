using System.Collections.Generic;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Beings
{
    /// <summary>
    /// Models the definition for a non-player character, such as a shop keeper.
    /// </summary>
    public sealed class NPCModel : CharacterModel
    {
        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="NPCModel"/> class.
        /// </summary>
        /// <param name="inID">
        /// Unique identifier for the <see cref="NPCModel"/>.  Cannot be null.
        /// Must be a valid <see cref="All.NpcIDs"/>.
        /// </param>
        /// <param name="inName">Personal and family names of the <see cref="NPCModel"/>, separated by a space.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="NPCModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="NPCModel"/>.</param>
        /// <param name="inNativeBiome">The <see cref="ModelID"/> of the <see cref="Biome"/> in which this <see cref="NPCModel"/> is most comfortable.</param>
        /// <param name="inPrimaryBehavior">The rules that govern how this <see cref="NPCModel"/> acts.  Cannot be null.</param>
        /// <param name="inAvoids">Any parquets this <see cref="NPCModel"/> avoids.</param>
        /// <param name="inSeeks">Any parquets this <see cref="NPCModel"/> seeks.</param>
        /// <param name="inPronouns">How to refer to this <see cref="NPCModel"/>.</param>
        /// <param name="inStoryCharacterID">A means of identifying this <see cref="NPCModel"/> across multiple shipped game titles.</param>
        /// <param name="inStartingQuests">Any quests this <see cref="NPCModel"/> has to offer.</param>
        /// <param name="inDialogue">All dialogue this <see cref="NPCModel"/> may say.</param>
        /// <param name="inStartingInventory">Any items this <see cref="NPCModel"/> owns.</param>
        public NPCModel(ModelID inID, string inName, string inDescription, string inComment,
                        ModelID inNativeBiome, Behavior inPrimaryBehavior,
                        IEnumerable<ModelID> inAvoids = null, IEnumerable<ModelID> inSeeks = null,
                        string inPronouns = null, string inStoryCharacterID = "",
                        IEnumerable<ModelID> inStartingQuests = null, IEnumerable<ModelID> inDialogue = null,
                        IEnumerable<ModelID> inStartingInventory = null)
            : base(All.NpcIDs, inID, inName, inDescription,
                   inComment, inNativeBiome, inPrimaryBehavior, inAvoids, inSeeks,
                   inPronouns, inStoryCharacterID, inStartingQuests, inDialogue, inStartingInventory)
        {
            Precondition.IsInRange(inID, All.NpcIDs, nameof(inID));
        }
        #endregion
    }
}
