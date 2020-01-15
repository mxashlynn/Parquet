using System.Collections.Generic;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Beings
{
    /// <summary>
    /// Models the definition for a player character, the game object that represents the player during play.
    /// </summary>
    public sealed class PlayerCharacterModel : CharacterModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerCharacterModel"/> class.
        /// </summary>
        /// <param name="inID">
        /// Unique identifier for the <see cref="PlayerCharacterModel"/>.  Cannot be null.
        /// Must be a valid <see cref="All.PlayerCharacterIDs"/>.
        /// </param>
        /// <param name="inPersonalName">Personal name of the <see cref="PlayerCharacterModel"/>.  Cannot be null or empty.</param>
        /// <param name="inFamilyName">Family name of the <see cref="PlayerCharacterModel"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="PlayerCharacterModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="PlayerCharacterModel"/>.</param>
        /// <param name="inPronoun">How to refer to this <see cref="PlayerCharacterModel"/>.</param>
        /// <param name="inStoryCharacterID">A means of identifying this <see cref="PlayerCharacterModel"/> across multiple shipped game titles.</param>
        /// <param name="inStartingQuests">Any quests this <see cref="PlayerCharacterModel"/> has to offer or has undertaken.</param>
        /// <param name="inStartingInventory">Any items this <see cref="PlayerCharacterModel"/> owns at the outset.</param>
        public PlayerCharacterModel(EntityID inID, string inPersonalName, string inFamilyName, string inDescription, string inComment,
                                    PronounGroup inPronoun = null, string inStoryCharacterID = "",
                                    List<EntityID> inStartingQuests = null, List<EntityID> inStartingInventory = null)
            : base(All.PlayerCharacterIDs, inID, inPersonalName, inFamilyName, inDescription, inComment,
                   EntityID.None, Behavior.PlayerControlled, null, null, inPronoun, inStoryCharacterID,
                   inStartingQuests, null, inStartingInventory)
        {
            Precondition.IsInRange(inID, All.PlayerCharacterIDs, nameof(inID));
        }
    }
}
