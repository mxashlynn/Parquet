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
        public readonly string DataVersion = AssemblyInfo.SupportedCharacterDataVersion;

        /// <summary>Tracks how many times the data structure has been serialized.</summary>
        public int Revision { get; private set; }

        /// <summary>The <see cref="Quests.Quest"/>s that this <see cref="PlayerCharacter"/> has undertaken.</summary>
        public readonly List<EntityID> Quests = new List<EntityID>();

        /// <summary>This <see cref="Character"/>'s set of belongings.</summary>
        // TODO This is just a place-holder, inventory needs to be its own class.
        public readonly List<EntityID> Inventory = new List<EntityID>();

        /// <summary>The <see cref="Crafting.CraftingRecipe"/>s that this <see cref="Character"/> knows.</summary>
        public readonly List<EntityID> KnownCraftingRecipes = new List<EntityID>();

        /// <summary>The <see cref="Sandbox.RoomRecipe"/>s that this <see cref="Character"/> knows.</summary>
        public readonly List<EntityID> KnownRoomRecipes = new List<EntityID>();

        /// <summary>The <see cref="NPC"/>s that this <see cref="Character"/> has met.</summary>
        public readonly List<EntityID> KnownCharacters = new List<EntityID>();

        /// <summary>The <see cref="Critter"/>s that this <see cref="Character"/> has encountered.</summary>
        public readonly List<EntityID> KnownCritters = new List<EntityID>();

        /// <summary>The parquets that this <see cref="Character"/> has analyzed.</summary>
        public readonly List<EntityID> KnownParquets = new List<EntityID>();

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerCharacter"/> class.
        /// </summary>
        /// <param name="in_id">
        /// Unique identifier for the <see cref="PlayerCharacter"/>.  Cannot be null.
        /// Must be a valid <see cref="AssemblyInfo.PlayerCharacterIDs"/>.
        /// </param>
        /// <param name="in_name">Player-friendly name of the <see cref="PlayerCharacter"/>.  Cannot be null or empty.</param>
        /// <param name="in_avoids">Any parquets this <see cref="PlayerCharacter"/> avoids.</param>
        /// <param name="in_seeks">Any parquets this <see cref="PlayerCharacter"/> seeks.</param>
        /// <param name="in_pronoun">How to refer to this <see cref="PlayerCharacter"/>.</param>
        /// <param name="in_quests">Any quests this <see cref="PlayerCharacter"/> has to offer.</param>
        /// <param name="in_dialogue">All dialogue this <see cref="PlayerCharacter"/> may say.</param>
        /// <param name="in_inventory">Any items this <see cref="PlayerCharacter"/> owns.</param>
        public PlayerCharacter(EntityID in_id, string in_name,
                               List<EntityID> in_avoids = null, List<EntityID> in_seeks = null,
                               List<EntityID> in_quests = null, List<string> in_dialogue = null,
                               List<EntityID> in_inventory = null, string in_pronoun = DefaultPronoun)
            : base(All.PlayerCharacterIDs, in_id, in_name, Biome.Town, Behavior.PlayerControlled,
                   in_avoids, in_seeks, in_pronoun, null, null, in_inventory)
        {
            if (!in_id.IsValidForRange(All.PlayerCharacterIDs))
            {
                throw new ArgumentOutOfRangeException(nameof(in_id));
            }
        }
        #endregion
    }
}
