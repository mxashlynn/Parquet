using System.Collections.Generic;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Beings
{
    /// <summary>
    /// Models the definition for a player character, the game object that represents the player during play.
    /// </summary>
    public sealed class PlayerCharacter : Character
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerCharacter"/> class.
        /// </summary>
        /// <param name="inID">
        /// Unique identifier for the <see cref="PlayerCharacter"/>.  Cannot be null.
        /// Must be a valid <see cref="All.PlayerCharacterIDs"/>.
        /// </param>
        /// <param name="inPersonalName">Personal name of the <see cref="PlayerCharacter"/>.  Cannot be null or empty.</param>
        /// <param name="inFamilyName">Family name of the <see cref="PlayerCharacter"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="PlayerCharacter"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="PlayerCharacter"/>.</param>
        /// <param name="inPronoun">How to refer to this <see cref="PlayerCharacter"/>.</param>
        /// <param name="inStoryCharacterID">A means of identifying this <see cref="PlayerCharacter"/> across multiple shipped game titles.</param>
        /// <param name="inStartingQuests">Any quests this <see cref="PlayerCharacter"/> has to offer or has undertaken.</param>
        /// <param name="inStartingInventory">Any items this <see cref="PlayerCharacter"/> owns at the outset.</param>
        public PlayerCharacter(EntityID inID, string inPersonalName, string inFamilyName, string inDescription, string inComment,
                               string inPronoun = DefaultPronoun, string inStoryCharacterID = "",
                               List<EntityID> inStartingQuests = null, List<EntityID> inStartingInventory = null)
            : base(All.PlayerCharacterIDs, inID, inPersonalName, inFamilyName, inDescription, inComment,
                   EntityID.None, Behavior.PlayerControlled, null, null, inPronoun, inStoryCharacterID,
                   inStartingQuests, null, inStartingInventory)
        {
            Precondition.IsInRange(inID, All.PlayerCharacterIDs, nameof(inID));
        }
    }
}
