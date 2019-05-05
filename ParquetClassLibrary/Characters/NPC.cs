using System;
using System.Collections.Generic;
using ParquetClassLibrary.Sandbox.IDs;

namespace ParquetClassLibrary.Characters
{
    /// <summary>
    /// Models the definition for a non-player character, such as a shop keeper.
    /// </summary>
    public sealed class NPC : Character
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NPC"/> class.
        /// </summary>
        /// <param name="in_id">
        /// Unique identifier for the <see cref="NPC"/>.  Cannot be null.
        /// Must be a valid <see cref="All.NpcIDs"/>.
        /// </param>
        /// <param name="in_personalName">Personal name of the <see cref="NPC"/>.  Cannot be null or empty.</param>
        /// <param name="in_familyName">Family name of the <see cref="NPC"/>.  Cannot be null or empty.</param>
        /// <param name="in_nativeBiome">The <see cref="Biome"/> in which this <see cref="NPC"/> is most comfortable.</param>
        /// <param name="in_currentBehavior">The rules that govern how this <see cref="NPC"/> acts.  Cannot be null.</param>
        /// <param name="in_avoids">Any parquets this <see cref="NPC"/> avoids.</param>
        /// <param name="in_seeks">Any parquets this <see cref="NPC"/> seeks.</param>
        /// <param name="in_pronoun">How to refer to this <see cref="NPC"/>.</param>
        /// <param name="in_storyCharacterID">A means of identifying this <see cref="PlayerCharacter"/> across multiple shipped game titles.</param>
        /// <param name="in_quests">Any quests this <see cref="NPC"/> has to offer.</param>
        /// <param name="in_dialogue">All dialogue this <see cref="NPC"/> may say.</param>
        /// <param name="in_inventory">Any items this <see cref="NPC"/> owns.</param>
        public NPC(EntityID in_id, string in_personalName, string in_familyName,
                   Biome in_nativeBiome, Behavior in_currentBehavior,
                   List<EntityID> in_avoids = null, List<EntityID> in_seeks = null,
                   string in_pronoun = DefaultPronoun, string in_storyCharacterID = "",
                   List<EntityID> in_quests = null, List<string> in_dialogue = null,
                   List<EntityID> in_inventory = null)
            : base(All.NpcIDs, in_id, in_personalName, in_familyName, in_nativeBiome, in_currentBehavior,
                   in_avoids, in_seeks, in_pronoun, in_storyCharacterID, in_quests, in_dialogue, in_inventory)
        {
            if (!in_id.IsValidForRange(All.NpcIDs))
            {
                throw new ArgumentOutOfRangeException(nameof(in_id));
            }
        }
    }
}
