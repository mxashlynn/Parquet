using System.Collections.Generic;
using Newtonsoft.Json;
using ParquetClassLibrary.Sandbox;

namespace ParquetClassLibrary.Characters
{
    public class BeingStatus
    {
        /// <summary>
        /// Describes the version of serialized data.
        /// Allows selecting data files that can be successfully deserialized.
        /// </summary>
        public readonly string DataVersion = AssemblyInfo.SupportedBeingDataVersion;

        /// <summary>Tracks how many times the data structure has been serialized.</summary>
        public int Revision { get; private set; }

        /// <summary>The <see cref="Being"/> whose status is being tracked.</summary>
        [JsonProperty(PropertyName = "in_beingDefinition")]
        public Being BeingDefinition { get; }

        /// <summary>The <see cref="Location"/> the tracked <see cref="Being"/> occupies.</summary>
        [JsonProperty(PropertyName = "in_position")]
        public Location Position { get; set; }

        /// <summary>The <see cref="Location"/> the tracked <see cref="Being"/> will next spawn at.</summary>
        /// <remarks>For example, for <see cref="PlayerCharacter"/>s this is their last save spot.</remarks>
        [JsonProperty(PropertyName = "in_spawnAt")]
        public Location SpawnAt { get; set; }

        /// <summary>The <see cref="Behavior"/> currently governing the tracked <see cref="Being"/>.</summary>
        [JsonProperty(PropertyName = "in_currentBehavior")]
        public Behavior CurrentBehavior { get; set; }

        /// <summary>The time remaining that the tracked <see cref="Being"/> can safely remain in the current <see cref="Sandbox.IDs.Biome"/>.</summary>
        /// <remarks>It is likely that this will only be used by <see cref="PlayerCharacter"/>.</remarks>
        [JsonProperty(PropertyName = "in_biomeTimeRemaining")]
        public int BiomeTimeRemaining { get; set; }

        /// <summary>The time it takes the tracked <see cref="Being"/> to place new parquets.</summary>
        [JsonProperty(PropertyName = "in_buildingSpeed")]
        public float BuildingSpeed { get; set; }

        /// <summary>The time it takes the tracked <see cref="Being"/> to modify existing parquets.</summary>
        [JsonProperty(PropertyName = "in_modificationSpeed")]
        public float ModificationSpeed { get; set; }

        /// <summary>The time it takes the tracked <see cref="Being"/> to gather existing parquets.</summary>
        [JsonProperty(PropertyName = "in_gatheringSpeed")]
        public float GatheringSpeed { get; set; }

        /// <summary>The time it takes the tracked <see cref="Being"/> to walk from one <see cref="Location"/> to another.</summary>
        [JsonProperty(PropertyName = "in_movementSpeed")]
        public float MovementSpeed { get; set; }

        /// <summary>The <see cref="Quests.Quest"/>s that this <see cref="PlayerCharacter"/> has undertaken.</summary>
        [JsonProperty(PropertyName = "in_quests")]
        public readonly List<EntityID> Quests = new List<EntityID>();

        /// <summary>This <see cref="Character"/>'s set of belongings.</summary>
        // TODO This is just a place-holder, inventory needs to be its own class.
        [JsonProperty(PropertyName = "in_inventory")]
        public readonly List<EntityID> Inventory = new List<EntityID>();

        /// <summary>The <see cref="Crafting.CraftingRecipe"/>s that this <see cref="Character"/> knows.</summary>
        [JsonProperty(PropertyName = "in_knwonCraftingRecipes")]
        public readonly List<EntityID> KnownCraftingRecipes = new List<EntityID>();

        /// <summary>The <see cref="Sandbox.RoomRecipe"/>s that this <see cref="Character"/> knows.</summary>
        [JsonProperty(PropertyName = "in_knownRoomRecipes")]
        public readonly List<EntityID> KnownRoomRecipes = new List<EntityID>();

        /// <summary>The <see cref="NPC"/>s that this <see cref="Character"/> has met.</summary>
        [JsonProperty(PropertyName = "in_knownCharacters")]
        public readonly List<EntityID> KnownCharacters = new List<EntityID>();

        /// <summary>The <see cref="Critter"/>s that this <see cref="Character"/> has encountered.</summary>
        [JsonProperty(PropertyName = "in_knownCritters")]
        public readonly List<EntityID> KnownCritters = new List<EntityID>();

        /// <summary>The parquets that this <see cref="Character"/> has analyzed.</summary>
        [JsonProperty(PropertyName = "in_knownParquets")]
        public readonly List<EntityID> KnownParquets = new List<EntityID>();

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="BeingStatus"/> class.
        /// </summary>
        /// <param name="in_beingDefinition">The <see cref="Being"/> whose status is being tracked.</param>
        /// <param name="in_position">The <see cref="Location"/> the tracked <see cref="Being"/> occupies.</param>
        /// <param name="in_spawnAt">The <see cref="Location"/> the tracked <see cref="Being"/> will next spawn at.</param>
        /// <param name="in_currentBehavior">The <see cref="Behavior"/> currently governing the tracked <see cref="Being"/>.</param>
        /// <param name="in_buildingSpeed">The time it takes the tracked <see cref="Being"/> to place new parquets.</param>
        /// <param name="in_modificationSpeed">The time it takes the tracked <see cref="Being"/> to modify existing parquets.</param>
        /// <param name="in_gatheringSpeed">The time it takes the tracked <see cref="Being"/> to gather existing parquets.</param>
        /// <param name="in_movementSpeed">The time it takes the tracked <see cref="Being"/> to walk from one <see cref="Location"/> to another.</param>
        [JsonConstructor]
        public BeingStatus(Being in_beingDefinition, Location in_position, Location in_spawnAt,
                           Behavior in_currentBehavior, int in_biomeTimeRemaining,
                           float in_buildingSpeed, float in_modificationSpeed,
                           float in_gatheringSpeed, float in_movementSpeed,
                           List<EntityID> in_quests, List<EntityID> in_inventory,
                           List<EntityID> in_knwonCraftingRecipes, List<EntityID> in_knownRoomRecipes,
                           List<EntityID> in_knownCharacters, List<EntityID> in_knownCritters,
                           List<EntityID> in_knownParquets)
        {
            // TODO Precondition: None of these can be null.
            // TODO Precondition: All of these must be in range.

            // TODO This will require heavy revision once the controllers and views are being implemented.

            BeingDefinition = in_beingDefinition;
            Position = in_position;
            SpawnAt = in_spawnAt;
            CurrentBehavior = in_currentBehavior;
            BiomeTimeRemaining = in_biomeTimeRemaining;
            BuildingSpeed = in_buildingSpeed;
            ModificationSpeed = in_modificationSpeed;
            GatheringSpeed = in_gatheringSpeed;
            MovementSpeed = in_movementSpeed;
            Quests = in_quests;
            Inventory = in_inventory;
            KnownCraftingRecipes = in_knwonCraftingRecipes;
            KnownRoomRecipes = in_knownRoomRecipes;
            KnownCharacters = in_knownCharacters;
            KnownCritters = in_knownCritters;
            KnownParquets = in_knownParquets;
        }
        #endregion

        #region Utility Methods
        /// <summary>
        /// Returns a <see langword="string"/> that represents the current <see cref="BeingStatus"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"{BeingDefinition.Name}";
        #endregion
    }
}
