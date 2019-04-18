using System;
using System.Collections.Generic;
using ParquetClassLibrary.Sandbox.IDs;

namespace ParquetClassLibrary.Characters
{
    /// <summary>
    /// Models the definition for a player character, the game object that represents the player during play.
    /// </summary>
    public sealed class PlayerCharacter : Character
    {
        /// <summary>
        /// Describes the version of serialized data.
        /// Allows selecting data files that can be successfully deserialized.
        /// </summary>
        // TODO We probably ought to differentiate between character versions and region versions.
        public readonly string DataVersion = AssemblyInfo.SupportedDataVersion;

        /// <summary>Tracks how many times the data structure has been serialized.</summary>
        public int Revision { get; private set; }

        // TODO: This is not fully implemented yet.  It will be implemented in it's own PR.

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerCharacter"/> class.
        /// </summary>
        /// <param name="in_id">
        /// Unique identifier for the <see cref="PlayerCharacter"/>.  Cannot be null.
        /// Must be a valid <see cref="AssemblyInfo.PlayerCharacterIDs"/>.
        /// </param>
        /// <param name="in_name">Player-friendly name of the <see cref="PlayerCharacter"/>.  Cannot be null or empty.</param>
        /// <param name="in_nativeBiome">The <see cref="Biome"/> in which this <see cref="PlayerCharacter"/> is most comfortable.</param>
        /// <param name="in_currentBehavior">The rules that govern how this <see cref="PlayerCharacter"/> acts.  Cannot be null.</param>
        /// <param name="in_avoids">Any parquets this <see cref="PlayerCharacter"/> avoids.</param>
        /// <param name="in_seeks">Any parquets this <see cref="PlayerCharacter"/> seeks.</param>
        /// <param name="in_quests">Any quests this <see cref="PlayerCharacter"/> has to offer.</param>
        /// <param name="in_dialogue">All dialogue this <see cref="PlayerCharacter"/> may say.</param>
        /// <param name="in_inventory">Any items this <see cref="PlayerCharacter"/> owns.</param>
        /// <param name="in_pronoun">How to refer to this <see cref="PlayerCharacter"/>.</param>
        public PlayerCharacter(EntityID in_id, string in_name, Biome in_nativeBiome, Behavior in_currentBehavior,
                               List<EntityID> in_avoids = null, List<EntityID> in_seeks = null,
                               List<EntityID> in_quests = null, List<string> in_dialogue = null,
                               List<EntityID> in_inventory = null, string in_pronoun = DefaultPronoun)
            : base(All.PlayerCharacterIDs, in_id, in_name, in_nativeBiome, in_currentBehavior,
                   in_avoids, in_seeks, in_quests, in_dialogue, in_inventory, in_pronoun)
        {
            if (!in_id.IsValidForRange(All.PlayerCharacterIDs))
            {
                throw new ArgumentOutOfRangeException(nameof(in_id));
            }
        }
        #endregion
    }
}
