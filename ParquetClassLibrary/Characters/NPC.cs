using System;
using System.Collections.Generic;
using ParquetClassLibrary.Sandbox;
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
        /// Must be a valid <see cref="AssemblyInfo.NpcIDs"/>.
        /// </param>
        /// <param name="in_name">Player-friendly name of the <see cref="NPC"/>.  Cannot be null or empty.</param>
        /// <param name="in_nativeBiome">The <see cref="Biome"/> in which this <see cref="NPC"/> is most comfortable.</param>
        /// <param name="in_currentBehavior">The rules that govern how this <see cref="NPC"/> acts.  Cannot be null.</param>
        /// <param name="in_avoids">Any parquets this <see cref="NPC"/> avoids.</param>
        /// <param name="in_seeks">Any parquets this <see cref="NPC"/> seeks.</param>
        /// <param name="in_quests">Any quests this <see cref="NPC"/> has to offer.</param>
        /// <param name="in_dialogue">All dialogue this <see cref="NPC"/> may say.</param>
        /// <param name="in_inventory">Any items this <see cref="NPC"/> owns.</param>
        /// <param name="in_pronoun">How to refer to this <see cref="NPC"/>.</param>
        public NPC(EntityID in_id, string in_name, Biome in_nativeBiome, Behavior in_currentBehavior,
                   List<EntityID> in_avoids = null, List<EntityID> in_seeks = null,
                   List<EntityID> in_quests = null, List<string> in_dialogue = null,
                   List<EntityID> in_inventory = null, string in_pronoun = DefaultPronoun)
            : base(AssemblyInfo.NpcIDs, in_id, in_name, in_nativeBiome, in_currentBehavior,
                   in_avoids, in_seeks, in_quests, in_dialogue, in_inventory, in_pronoun)
        {
            if (!in_id.IsValidForRange(AssemblyInfo.NpcIDs))
            {
                throw new ArgumentOutOfRangeException(nameof(in_id));
            }
        }
    }
}
