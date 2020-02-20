using System.Collections.Generic;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Beings
{
    /// <summary>
    /// Models the definition for a player character, the game object that represents the player during play.
    /// </summary>
    public sealed class PlayerCharacterModel : CharacterModel
    {
        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerCharacterModel"/> class.
        /// </summary>
        /// <param name="inID">
        /// Unique identifier for the <see cref="PlayerCharacterModel"/>.  Cannot be null.
        /// Must be a valid <see cref="All.NpcIDs"/>.
        /// </param>
        /// <param name="inDescription">Player-friendly description of the <see cref="PlayerCharacterModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="PlayerCharacterModel"/>.</param>
        /// <param name="inNativeBiome">The <see cref="EntityID"/> of the <see cref="Biome"/> in which this <see cref="PlayerCharacterModel"/> is most comfortable.</param>
        /// <param name="inPrimaryBehavior">The rules that govern how this <see cref="PlayerCharacterModel"/> acts.  Cannot be null.</param>
        /// <param name="inAvoids">Any parquets this <see cref="PlayerCharacterModel"/> avoids.</param>
        /// <param name="inSeeks">Any parquets this <see cref="PlayerCharacterModel"/> seeks.</param>
        /// <param name="inPronouns">How to refer to this <see cref="PlayerCharacterModel"/>.</param>
        /// <param name="inStoryCharacterID">A means of identifying this <see cref="PlayerCharacterModel"/> across multiple shipped game titles.</param>
        /// <param name="inStartingQuests">Any quests this <see cref="PlayerCharacterModel"/> has to offer.</param>
        /// <param name="inDialogue">All dialogue this <see cref="PlayerCharacterModel"/> may say.</param>
        /// <param name="inStartingInventory">Any items this <see cref="PlayerCharacterModel"/> owns.</param>
        public PlayerCharacterModel(EntityID inID, string inName, string inDescription, string inComment,
                                    EntityID inNativeBiome, Behavior inPrimaryBehavior,
                                    IEnumerable<EntityID> inAvoids = null, IEnumerable<EntityID> inSeeks = null,
                                    string inPronouns = null, string inStoryCharacterID = "",
                                    IEnumerable<EntityID> inStartingQuests = null, IEnumerable<EntityID> inDialogue = null,
                                    IEnumerable<EntityID> inStartingInventory = null)
            : base(All.PlayerCharacterIDs, inID, inName, inDescription,
                   inComment, inNativeBiome, inPrimaryBehavior, inAvoids, inSeeks,
                   inPronouns, inStoryCharacterID, inStartingQuests, inDialogue, inStartingInventory)
        {
            Precondition.IsInRange(inID, All.PlayerCharacterIDs, nameof(inID));
        }
        #endregion
    }
}
