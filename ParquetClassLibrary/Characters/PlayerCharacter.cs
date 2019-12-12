using System.Collections.Generic;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Characters
{
    /// <summary>
    /// Models the definition for a player character, the game object that represents the player during play.
    /// </summary>
    public sealed class PlayerCharacter : Character
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerCharacter"/> class.
        /// </summary>
        /// <param name="in_id">
        /// Unique identifier for the <see cref="PlayerCharacter"/>.  Cannot be null.
        /// Must be a valid <see cref="All.PlayerCharacterIDs"/>.
        /// </param>
        /// <param name="in_description">Player-friendly description of the <see cref="PlayerCharacter"/>.</param>
        /// <param name="in_comment">Comment of, on, or by the <see cref="PlayerCharacter"/>.</param>
        /// <param name="in_personalName">Personal name of the <see cref="PlayerCharacter"/>.  Cannot be null or empty.</param>
        /// <param name="in_familyName">Family name of the <see cref="PlayerCharacter"/>.  Cannot be null or empty.</param>
        /// <param name="in_pronoun">How to refer to this <see cref="PlayerCharacter"/>.</param>
        /// <param name="in_storyCharacterID">A means of identifying this <see cref="PlayerCharacter"/> across multiple shipped game titles.</param>
        /// <param name="in_startingQuests">Any quests this <see cref="PlayerCharacter"/> has to offer or has undertaken.</param>
        /// <param name="in_startingInventory">Any items this <see cref="PlayerCharacter"/> owns at the outset.</param>
        public PlayerCharacter(EntityID in_id, string in_description, string in_comment,
                               string in_personalName, string in_familyName,
                               string in_pronoun = DefaultPronoun, string in_storyCharacterID = "",
                               List<EntityID> in_startingQuests = null, List<EntityID> in_startingInventory = null)
            : base(All.PlayerCharacterIDs, in_id, in_description, in_comment, in_personalName, in_familyName,
                   EntityID.None, Behavior.PlayerControlled, null, null, in_pronoun, in_storyCharacterID,
                   in_startingQuests, null, in_startingInventory)
        {
            Precondition.IsInRange(in_id, All.PlayerCharacterIDs, nameof(in_id));
        }
    }
}
