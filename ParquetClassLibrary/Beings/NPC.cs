using System.Collections.Generic;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Beings
{
    /// <summary>
    /// Models the definition for a non-player character, such as a shop keeper.
    /// </summary>
    public sealed class NPC : Character
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NPC"/> class.
        /// </summary>
        /// <param name="inID">
        /// Unique identifier for the <see cref="NPC"/>.  Cannot be null.
        /// Must be a valid <see cref="All.NpcIDs"/>.
        /// </param>
        /// <param name="inPersonalName">Personal name of the <see cref="NPC"/>.  Cannot be null or empty.</param>
        /// <param name="inFamilyName">Family name of the <see cref="NPC"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="NPC"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="NPC"/>.</param>
        /// <param name="inNativeBiome">The <see cref="EntityID"/> of the <see cref="Biome"/> in which this <see cref="NPC"/> is most comfortable.</param>
        /// <param name="inCurrentBehavior">The rules that govern how this <see cref="NPC"/> acts.  Cannot be null.</param>
        /// <param name="inAvoids">Any parquets this <see cref="NPC"/> avoids.</param>
        /// <param name="inSeeks">Any parquets this <see cref="NPC"/> seeks.</param>
        /// <param name="inPronoun">How to refer to this <see cref="NPC"/>.</param>
        /// <param name="inStoryCharacterID">A means of identifying this <see cref="PlayerCharacter"/> across multiple shipped game titles.</param>
        /// <param name="inQuests">Any quests this <see cref="NPC"/> has to offer.</param>
        /// <param name="inDialogue">All dialogue this <see cref="NPC"/> may say.</param>
        /// <param name="inInventory">Any items this <see cref="NPC"/> owns.</param>
        public NPC(EntityID inID, string inPersonalName, string inFamilyName,
                   string inDescription, string inComment,
                   EntityID inNativeBiome, Behavior inCurrentBehavior,
                   List<EntityID> inAvoids = null, List<EntityID> inSeeks = null,
                   string inPronoun = DefaultPronouns, string inStoryCharacterID = "",
                   List<EntityID> inQuests = null, List<string> inDialogue = null,
                   List<EntityID> inInventory = null)
            : base(All.NpcIDs, inID, inPersonalName, inFamilyName, inDescription,
                   inComment, inNativeBiome, inCurrentBehavior, inAvoids, inSeeks,
                   inPronoun, inStoryCharacterID, inQuests, inDialogue, inInventory)
        {
            Precondition.IsInRange(inID, All.NpcIDs, nameof(inID));
        }
    }
}
