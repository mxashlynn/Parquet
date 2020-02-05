using System.Collections.Generic;
using System.Linq;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Beings
{
    /// <summary>
    /// Models the status of a <see cref="BeingModel"/>.
    /// </summary>
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
        /// <summary>The <see cref="BeingModel"/> whose status is being tracked.</summary>
        public BeingModel BeingDefinition { get; }
        #endregion

        #region Stats
        /// <summary>The <see cref="Location"/> the tracked <see cref="BeingModel"/> occupies.</summary>
        public Location Position { get; set; }

        /// <summary>The <see cref="Location"/> the tracked <see cref="BeingModel"/> will next spawn at.</summary>
        /// <remarks>For example, for <see cref="PlayerCharacterModel"/>s this is their last save spot.</remarks>
        public Location SpawnAt { get; set; }

        /// <summary>The <see cref="Location"/> the <see cref="Rooms.Room"/> assigned to this <see cref="BeingModel"/>.</summary>
        public Location RoomAssignment { get; set; }

        /// <summary>The <see cref="Behavior"/> currently governing the tracked <see cref="BeingModel"/>.</summary>
        public Behavior CurrentBehavior { get; set; }

        /// <summary>The time remaining that the tracked <see cref="BeingModel"/> can safely remain in the current <see cref="Biomes.BiomeModel"/>.</summary>
        /// <remarks>It is likely that this will only be used by <see cref="PlayerCharacterModel"/>.</remarks>
        public int BiomeTimeRemaining { get; set; }

        /// <summary>The time it takes the tracked <see cref="BeingModel"/> to place new parquets.</summary>
        public float BuildingSpeed { get; set; }

        /// <summary>The time it takes the tracked <see cref="BeingModel"/> to modify existing parquets.</summary>
        public float ModificationSpeed { get; set; }

        /// <summary>The time it takes the tracked <see cref="BeingModel"/> to gather existing parquets.</summary>
        public float GatheringSpeed { get; set; }

        /// <summary>The time it takes the tracked <see cref="BeingModel"/> to walk from one <see cref="Location"/> to another.</summary>
        public float MovementSpeed { get; set; }
        #endregion

        #region Collections
        /// <summary>The <see cref="CritterModel"/>s that this <see cref="CharacterModel"/> has encountered.</summary>
        public List<EntityID> KnownCritters { get; }

        /// <summary>The <see cref="NPCModel"/>s that this <see cref="CharacterModel"/> has met.</summary>
        public List<EntityID> KnownNPCs { get; }

        /// <summary>The parquets that this <see cref="CharacterModel"/> has encountered.</summary>
        public List<EntityID> KnownParquets { get; }

        /// <summary>The <see cref="RoomRecipe"/>s that this <see cref="CharacterModel"/> knows.</summary>
        public List<EntityID> KnownRoomRecipes { get; }

        /// <summary>The <see cref="Crafts.CraftingRecipe"/>s that this <see cref="CharacterModel"/> knows.</summary>
        public List<EntityID> KnownCraftingRecipes { get; }

        /// <summary>The <see cref="Quests.QuestModel"/>s that this <see cref="CharacterModel"/> offers or has undertaken.</summary>
        public List<EntityID> Quests { get; }

        /// <summary>This <see cref="CharacterModel"/>'s set of belongings.</summary>
        public List<EntityID> Inventory { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="BeingStatus"/> class.
        /// </summary>
        /// <param name="inBeingDefinition">The <see cref="BeingModel"/> whose status is being tracked.</param>
        /// <param name="inPosition">The <see cref="Location"/> the tracked <see cref="BeingModel"/> occupies.</param>
        /// <param name="inSpawnAt">The <see cref="Location"/> the tracked <see cref="BeingModel"/> will next spawn at.</param>
        /// <param name="inCurrentBehavior">The <see cref="Behavior"/> currently governing the tracked <see cref="BeingModel"/>.</param>
        // TODO Fill in units bellow.
        /// <param name="inBiomeTimeRemaining">How long [TODO in what units?] to until being kicked out of the current <see cref="Biomes.BiomeModel"/>.</param>
        /// <param name="inBuildingSpeed">The time it takes the tracked <see cref="BeingModel"/> to place new parquets.</param>
        /// <param name="inModificationSpeed">The time it takes the tracked <see cref="BeingModel"/> to modify existing parquets.</param>
        /// <param name="inGatheringSpeed">The time it takes the tracked <see cref="BeingModel"/> to gather existing parquets.</param>
        /// <param name="inMovementSpeed">The time it takes the tracked <see cref="BeingModel"/> to walk from one <see cref="Location"/> to another.</param>
        /// <param name="inKnownCritters">The <see cref="CritterModel"/>s that this <see cref="CharacterModel"/> has encountered.</param>
        /// <param name="inKnownNPCs">The <see cref="NPCModel"/>s that this <see cref="CharacterModel"/> has met.</param>
        /// <param name="inKnownParquets">The parquets that this <see cref="CharacterModel"/> has encountered.</param>
        /// <param name="inKnownRoomRecipes">The <see cref="RoomRecipe"/>s that this <see cref="CharacterModel"/> knows.</param>
        /// <param name="inKnownCraftingRecipes">The <see cref="Crafts.CraftingRecipe"/>s that this <see cref="CharacterModel"/> knows.</param>
        /// <param name="inQuests">The <see cref="Quests.QuestModel"/>s that this <see cref="CharacterModel"/> offers or has undertaken.</param>
        /// <param name="inInventory">This <see cref="CharacterModel"/>'s set of belongings.</param>
        public BeingStatus(BeingModel inBeingDefinition, Behavior inCurrentBehavior,
                           Location inPosition, Location inSpawnAt,
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

        #region Utilities
        /// <summary>
        /// Returns a <see langword="string"/> that represents the current <see cref="BeingStatus"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"{BeingDefinition.Name}";
        #endregion
    }
}
