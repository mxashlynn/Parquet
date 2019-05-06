using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ParquetClassLibrary.Sandbox;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Characters
{
    public class BeingStatus
    {
        #region Metadata
        /// <summary>
        /// Describes the version of serialized data.
        /// Allows selecting data files that can be successfully deserialized.
        /// </summary>
        public readonly string DataVersion = AssemblyInfo.SupportedBeingDataVersion;

        /// <summary>Tracks how many times the data structure has been serialized.</summary>
        public int Revision { get; private set; }
        #endregion

        #region Identity
        /// <summary>The <see cref="Being"/> whose status is being tracked.</summary>
        [JsonProperty(PropertyName = "in_beingDefinition")]
        public Being BeingDefinition { get; }

        /// <summary>The <see cref="Behavior"/> currently governing the tracked <see cref="Being"/>.</summary>
        [JsonProperty(PropertyName = "in_currentBehavior")]
        public Behavior CurrentBehavior { get; set; }
        #endregion

        #region Stats
        /// <summary>The <see cref="Location"/> the tracked <see cref="Being"/> occupies.</summary>
        [JsonProperty(PropertyName = "in_position")]
        public Location Position { get; set; }

        /// <summary>The <see cref="Location"/> the tracked <see cref="Being"/> will next spawn at.</summary>
        /// <remarks>For example, for <see cref="PlayerCharacter"/>s this is their last save spot.</remarks>
        [JsonProperty(PropertyName = "in_spawnAt")]
        public Location SpawnAt { get; set; }

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
        #endregion

        #region Collections
        /// <summary>The <see cref="Critter"/>s that this <see cref="Character"/> has encountered.</summary>
        [JsonProperty(PropertyName = "in_knownCritters")]
        public List<EntityID> KnownCritters { get; }

        /// <summary>The <see cref="NPC"/>s that this <see cref="Character"/> has met.</summary>
        [JsonProperty(PropertyName = "in_knownCharacters")]
        public List<EntityID> KnownNPCs { get; }

        /// <summary>The parquets that this <see cref="Character"/> has analyzed.</summary>
        [JsonProperty(PropertyName = "in_knownParquets")]
        public List<EntityID> KnownParquets { get; }

        /// <summary>The <see cref="RoomRecipe"/>s that this <see cref="Character"/> knows.</summary>
        [JsonProperty(PropertyName = "in_knownRoomRecipes")]
        public List<EntityID> KnownRoomRecipes { get; }

        /// <summary>The <see cref="Crafting.CraftingRecipe"/>s that this <see cref="Character"/> knows.</summary>
        [JsonProperty(PropertyName = "in_knwonCraftingRecipes")]
        public List<EntityID> KnownCraftingRecipes { get; }

        /// <summary>The <see cref="Quests.Quest"/>s that this <see cref="Character"/> offers or has undertaken.</summary>
        [JsonProperty(PropertyName = "in_quests")]
        public List<EntityID> Quests { get; }

        /// <summary>This <see cref="Character"/>'s set of belongings.</summary>
        // TODO This is just a place-holder, inventory needs to be its own class.
        [JsonProperty(PropertyName = "in_inventory")]
        public List<EntityID> Inventory { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="BeingStatus"/> class.
        /// </summary>
        /// <param name="in_beingDefinition">The <see cref="Being"/> whose status is being tracked.</param>
        /// <param name="in_position">The <see cref="Location"/> the tracked <see cref="Being"/> occupies.</param>
        /// <param name="in_spawnAt">The <see cref="Location"/> the tracked <see cref="Being"/> will next spawn at.</param>
        /// <param name="in_currentBehavior">The <see cref="Behavior"/> currently governing the tracked <see cref="Being"/>.</param>
        /// <param name="in_biomeTimeRemaining"></param>
        /// <param name="in_buildingSpeed">The time it takes the tracked <see cref="Being"/> to place new parquets.</param>
        /// <param name="in_modificationSpeed">The time it takes the tracked <see cref="Being"/> to modify existing parquets.</param>
        /// <param name="in_gatheringSpeed">The time it takes the tracked <see cref="Being"/> to gather existing parquets.</param>
        /// <param name="in_movementSpeed">The time it takes the tracked <see cref="Being"/> to walk from one <see cref="Location"/> to another.</param>
        /// <param name="in_knownCritters">The <see cref="Critter"/>s that this <see cref="Character"/> has encountered.</param>
        /// <param name="in_knownNPCs">The <see cref="NPC"/>s that this <see cref="Character"/> has met.</param>
        /// <param name="in_knownParquets">The parquets that this <see cref="Character"/> has analyzed.</param>
        /// <param name="in_knownRoomRecipes">The <see cref="RoomRecipe"/>s that this <see cref="Character"/> knows.</param>
        /// <param name="in_knownCraftingRecipes">The <see cref="Crafting.CraftingRecipe"/>s that this <see cref="Character"/> knows.</param>
        /// <param name="in_quests">The <see cref="Quests.Quest"/>s that this <see cref="Character"/> offers or has undertaken.</param>
        /// <param name="in_inventory">This <see cref="Character"/>'s set of belongings.</param>
        [JsonConstructor]
        public BeingStatus(Being in_beingDefinition, Behavior in_currentBehavior,
                           Location in_position, Location in_spawnAt,
                           int in_biomeTimeRemaining,
                           float in_buildingSpeed, float in_modificationSpeed,
                           float in_gatheringSpeed, float in_movementSpeed,
                           List<EntityID> in_knownCritters, List<EntityID> in_knownNPCs,
                           List<EntityID> in_knownParquets,
                           List<EntityID> in_knownRoomRecipes, List<EntityID> in_knownCraftingRecipes,
                           List<EntityID> in_quests, List<EntityID> in_inventory)
        {
            Precondition.IsNotNull(in_beingDefinition, nameof(in_beingDefinition));
            var nonNullCritters = in_knownCritters ?? Enumerable.Empty<EntityID>().ToList();
            var nonNullNPCs = in_knownNPCs ?? Enumerable.Empty<EntityID>().ToList();
            var nonNullParquets = in_knownParquets ?? Enumerable.Empty<EntityID>().ToList();
            var nonNullRoomRecipes = in_knownRoomRecipes  ?? Enumerable.Empty<EntityID>().ToList();
            var nonNullCraftingRecipes = in_knownCraftingRecipes ?? Enumerable.Empty<EntityID>().ToList();
            var nonNullQuests = in_quests ?? Enumerable.Empty<EntityID>().ToList();
            var nonNullInventory = in_inventory ?? Enumerable.Empty<EntityID>().ToList();
            Precondition.AreInRange(nonNullCritters, All.CritterIDs, nameof(in_knownCritters));
            Precondition.AreInRange(nonNullNPCs, All.NpcIDs, nameof(in_knownNPCs));
            Precondition.AreInRange(nonNullParquets, All.ParquetIDs, nameof(in_knownParquets));
            Precondition.AreInRange(nonNullRoomRecipes, All.RoomRecipeIDs, nameof(in_knownRoomRecipes));
            Precondition.AreInRange(nonNullCraftingRecipes, All.CraftingRecipeIDs, nameof(in_knownCraftingRecipes));
            Precondition.AreInRange(nonNullQuests, All.QuestIDs, nameof(in_quests));
            Precondition.AreInRange(nonNullInventory, All.ItemIDs, nameof(in_inventory));

            // TODO This will require heavy revision once the controllers and views are being implemented.

            BeingDefinition = in_beingDefinition;
            CurrentBehavior = in_currentBehavior;
            Position = in_position;
            SpawnAt = in_spawnAt;
            BiomeTimeRemaining = in_biomeTimeRemaining;
            BuildingSpeed = in_buildingSpeed;
            ModificationSpeed = in_modificationSpeed;
            GatheringSpeed = in_gatheringSpeed;
            MovementSpeed = in_movementSpeed;
            KnownCritters = nonNullCritters;
            KnownNPCs = nonNullNPCs;
            KnownParquets = nonNullParquets;
            KnownRoomRecipes = nonNullRoomRecipes;
            KnownCraftingRecipes = nonNullCraftingRecipes;
            Quests = nonNullQuests;
            Inventory = nonNullInventory;
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
