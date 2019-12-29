using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Beings
{
    public class BeingStatus
    {
        #region Metadata
        /// <summary>
        /// Describes the version of serialized data.
        /// Allows selecting data files that can be successfully deserialized.
        /// </summary>
        public string DataVersion { get; } = AssemblyInfo.SupportedBeingDataVersion;

        /// <summary>Tracks how many times the data structure has been serialized.</summary>
        public int Revision { get; private set; }
        #endregion

        #region Identity
        /// <summary>The <see cref="Being"/> whose status is being tracked.</summary>
        [JsonProperty(PropertyName = "inBeingDefinition")]
        public Being BeingDefinition { get; }
        #endregion

        #region Stats
        /// <summary>The <see cref="BeingLocation"/> the tracked <see cref="Being"/> occupies.</summary>
        [JsonProperty(PropertyName = "inPosition")]
        public BeingLocation Position { get; set; }

        /// <summary>The <see cref="BeingLocation"/> the tracked <see cref="Being"/> will next spawn at.</summary>
        /// <remarks>For example, for <see cref="PlayerCharacter"/>s this is their last save spot.</remarks>
        [JsonProperty(PropertyName = "inSpawnAt")]
        public BeingLocation SpawnAt { get; set; }

        /// <summary>The <see cref="Behavior"/> currently governing the tracked <see cref="Being"/>.</summary>
        [JsonProperty(PropertyName = "inCurrentBehavior")]
        public Behavior CurrentBehavior { get; set; }

        /// <summary>The time remaining that the tracked <see cref="Being"/> can safely remain in the current <see cref="Biomes.Biome"/>.</summary>
        /// <remarks>It is likely that this will only be used by <see cref="PlayerCharacter"/>.</remarks>
        [JsonProperty(PropertyName = "inBiomeTimeRemaining")]
        public int BiomeTimeRemaining { get; set; }

        /// <summary>The time it takes the tracked <see cref="Being"/> to place new parquets.</summary>
        [JsonProperty(PropertyName = "inBuildingSpeed")]
        public float BuildingSpeed { get; set; }

        /// <summary>The time it takes the tracked <see cref="Being"/> to modify existing parquets.</summary>
        [JsonProperty(PropertyName = "inModificationSpeed")]
        public float ModificationSpeed { get; set; }

        /// <summary>The time it takes the tracked <see cref="Being"/> to gather existing parquets.</summary>
        [JsonProperty(PropertyName = "inGatheringSpeed")]
        public float GatheringSpeed { get; set; }

        /// <summary>The time it takes the tracked <see cref="Being"/> to walk from one <see cref="BeingLocation"/> to another.</summary>
        [JsonProperty(PropertyName = "inMovementSpeed")]
        public float MovementSpeed { get; set; }
        #endregion

        #region Collections
        /// <summary>The <see cref="Critter"/>s that this <see cref="Character"/> has encountered.</summary>
        [JsonProperty(PropertyName = "inKnownCritters")]
        public List<EntityID> KnownCritters { get; }

        /// <summary>The <see cref="NPC"/>s that this <see cref="Character"/> has met.</summary>
        [JsonProperty(PropertyName = "inKnownCharacters")]
        public List<EntityID> KnownNPCs { get; }

        /// <summary>The parquets that this <see cref="Character"/> has encountered.</summary>
        [JsonProperty(PropertyName = "inKnownParquets")]
        public List<EntityID> KnownParquets { get; }

        /// <summary>The <see cref="RoomRecipe"/>s that this <see cref="Character"/> knows.</summary>
        [JsonProperty(PropertyName = "inKnownRoomRecipes")]
        public List<EntityID> KnownRoomRecipes { get; }

        /// <summary>The <see cref="Crafting.CraftingRecipe"/>s that this <see cref="Character"/> knows.</summary>
        [JsonProperty(PropertyName = "inKnownCraftingRecipes")]
        public List<EntityID> KnownCraftingRecipes { get; }

        /// <summary>The <see cref="Quests.Quest"/>s that this <see cref="Character"/> offers or has undertaken.</summary>
        [JsonProperty(PropertyName = "inQuests")]
        public List<EntityID> Quests { get; }

        /// <summary>This <see cref="Character"/>'s set of belongings.</summary>
        [JsonProperty(PropertyName = "inInventory")]
        public List<EntityID> Inventory { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="BeingStatus"/> class.
        /// </summary>
        /// <param name="inBeingDefinition">The <see cref="Being"/> whose status is being tracked.</param>
        /// <param name="inPosition">The <see cref="BeingLocation"/> the tracked <see cref="Being"/> occupies.</param>
        /// <param name="inSpawnAt">The <see cref="BeingLocation"/> the tracked <see cref="Being"/> will next spawn at.</param>
        /// <param name="inCurrentBehavior">The <see cref="Behavior"/> currently governing the tracked <see cref="Being"/>.</param>
        /// <param name="inBiomeTimeRemaining"></param>
        /// <param name="inBuildingSpeed">The time it takes the tracked <see cref="Being"/> to place new parquets.</param>
        /// <param name="inModificationSpeed">The time it takes the tracked <see cref="Being"/> to modify existing parquets.</param>
        /// <param name="inGatheringSpeed">The time it takes the tracked <see cref="Being"/> to gather existing parquets.</param>
        /// <param name="inMovementSpeed">The time it takes the tracked <see cref="Being"/> to walk from one <see cref="BeingLocation"/> to another.</param>
        /// <param name="inKnownCritters">The <see cref="Critter"/>s that this <see cref="Character"/> has encountered.</param>
        /// <param name="inKnownNPCs">The <see cref="NPC"/>s that this <see cref="Character"/> has met.</param>
        /// <param name="inKnownParquets">The parquets that this <see cref="Character"/> has encountered.</param>
        /// <param name="inKnownRoomRecipes">The <see cref="RoomRecipe"/>s that this <see cref="Character"/> knows.</param>
        /// <param name="inKnownCraftingRecipes">The <see cref="Crafting.CraftingRecipe"/>s that this <see cref="Character"/> knows.</param>
        /// <param name="inQuests">The <see cref="Quests.Quest"/>s that this <see cref="Character"/> offers or has undertaken.</param>
        /// <param name="inInventory">This <see cref="Character"/>'s set of belongings.</param>
        [JsonConstructor]
        public BeingStatus(Being inBeingDefinition, Behavior inCurrentBehavior,
                           BeingLocation inPosition, BeingLocation inSpawnAt,
                           int inBiomeTimeRemaining,
                           float inBuildingSpeed, float inModificationSpeed,
                           float inGatheringSpeed, float inMovementSpeed,
                           List<EntityID> inKnownCritters = null, List<EntityID> inKnownNPCs = null,
                           List<EntityID> inKnownParquets = null, List<EntityID> inKnownRoomRecipes = null,
                           List<EntityID> inKnownCraftingRecipes = null, List<EntityID> inQuests = null,
                           List<EntityID> inInventory = null)
        {
            Precondition.IsNotNull(inBeingDefinition, nameof(inBeingDefinition));
            var nonNullCritters = inKnownCritters ?? Enumerable.Empty<EntityID>().ToList();
            var nonNullNPCs = inKnownNPCs ?? Enumerable.Empty<EntityID>().ToList();
            var nonNullParquets = inKnownParquets ?? Enumerable.Empty<EntityID>().ToList();
            var nonNullRoomRecipes = inKnownRoomRecipes  ?? Enumerable.Empty<EntityID>().ToList();
            var nonNullCraftingRecipes = inKnownCraftingRecipes ?? Enumerable.Empty<EntityID>().ToList();
            var nonNullQuests = inQuests ?? Enumerable.Empty<EntityID>().ToList();
            var nonNullInventory = inInventory ?? Enumerable.Empty<EntityID>().ToList();
            Precondition.AreInRange(nonNullCritters, All.CritterIDs, nameof(inKnownCritters));
            Precondition.AreInRange(nonNullNPCs, All.NpcIDs, nameof(inKnownNPCs));
            Precondition.AreInRange(nonNullParquets, All.ParquetIDs, nameof(inKnownParquets));
            Precondition.AreInRange(nonNullRoomRecipes, All.RoomRecipeIDs, nameof(inKnownRoomRecipes));
            Precondition.AreInRange(nonNullCraftingRecipes, All.CraftingRecipeIDs, nameof(inKnownCraftingRecipes));
            Precondition.AreInRange(nonNullQuests, All.QuestIDs, nameof(inQuests));
            Precondition.AreInRange(nonNullInventory, All.ItemIDs, nameof(inInventory));

            BeingDefinition = inBeingDefinition;
            CurrentBehavior = inCurrentBehavior;
            Position = inPosition;
            SpawnAt = inSpawnAt;
            BiomeTimeRemaining = inBiomeTimeRemaining;
            BuildingSpeed = inBuildingSpeed;
            ModificationSpeed = inModificationSpeed;
            GatheringSpeed = inGatheringSpeed;
            MovementSpeed = inMovementSpeed;
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
