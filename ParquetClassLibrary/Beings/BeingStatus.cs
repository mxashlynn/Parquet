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
        /// <remarks>For example, for <see cref="CharacterModel"/>s, this might be the spot the where when the game was last saved.</remarks>
        public Location SpawnAt { get; set; }

        /// <summary>The <see cref="Location"/> the <see cref="Rooms.Room"/> assigned to this <see cref="BeingModel"/>.</summary>
        public Location RoomAssignment { get; set; }

        /// <summary>The <see cref="ModelID"/> for the <see cref="Scripts.ScriptModel"/> currently governing the tracked <see cref="BeingModel"/>.</summary>
        public ModelID CurrentBehavior { get; set; }

        /// <summary>The time remaining that the tracked <see cref="BeingModel"/> can safely remain in the current <see cref="Biomes.BiomeModel"/>.</summary>
        /// <remarks>It is likely that this will only be used by <see cref="CharacterModel"/> but may be useful for other beings as well.</remarks>
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
        /// <summary>The <see cref="BeingModel"/>s that this <see cref="CharacterModel"/> has encountered.</summary>
        public List<ModelID> KnownBeings { get; }

        /// <summary>The parquets that this <see cref="CharacterModel"/> has encountered.</summary>
        public List<ModelID> KnownParquets { get; }

        /// <summary>The <see cref="Rooms.RoomRecipe"/>s that this <see cref="CharacterModel"/> knows.</summary>
        public List<ModelID> KnownRoomRecipes { get; }

        /// <summary>The <see cref="Crafts.CraftingRecipe"/>s that this <see cref="CharacterModel"/> knows.</summary>
        public List<ModelID> KnownCraftingRecipes { get; }

        /// <summary>The <see cref="Scripts.InteractionModel"/>s that this <see cref="CharacterModel"/> offers or has undertaken.</summary>
        public List<ModelID> Quests { get; }

        /// <summary>This <see cref="CharacterModel"/>'s set of belongings.</summary>
        public List<ModelID> Inventory { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="BeingStatus"/> class.
        /// </summary>
        /// <param name="inBeingDefinition">The <see cref="BeingModel"/> whose status is being tracked.</param>
        /// <param name="inPosition">The <see cref="Location"/> the tracked <see cref="BeingModel"/> occupies.</param>
        /// <param name="inSpawnAt">The <see cref="Location"/> the tracked <see cref="BeingModel"/> will next spawn at.</param>
        /// <param name="inCurrentBehavior">The behavior currently governing the tracked <see cref="BeingModel"/>.</param>
        /// <param name="inBiomeTimeRemaining">How long [TODO in what units?] to until being kicked out of the current <see cref="Biomes.BiomeModel"/>.</param>
        /// <param name="inBuildingSpeed">The time it takes the tracked <see cref="BeingModel"/> to place new parquets.</param>
        /// <param name="inModificationSpeed">The time it takes the tracked <see cref="BeingModel"/> to modify existing parquets.</param>
        /// <param name="inGatheringSpeed">The time it takes the tracked <see cref="BeingModel"/> to gather existing parquets.</param>
        /// <param name="inMovementSpeed">The time it takes the tracked <see cref="BeingModel"/> to walk from one <see cref="Location"/> to another.</param>
        /// <param name="inKnownBeings">The <see cref="CritterModel"/>s that this <see cref="CharacterModel"/> has encountered.</param>
        /// <param name="inKnownParquets">The parquets that this <see cref="CharacterModel"/> has encountered.</param>
        /// <param name="inKnownRoomRecipes">The <see cref="Rooms.RoomRecipe"/>s that this <see cref="CharacterModel"/> knows.</param>
        /// <param name="inKnownCraftingRecipes">The <see cref="Crafts.CraftingRecipe"/>s that this <see cref="CharacterModel"/> knows.</param>
        /// <param name="inQuests">The <see cref="Scripts.InteractionModel"/>s that this <see cref="CharacterModel"/> offers or has undertaken.</param>
        /// <param name="inInventory">This <see cref="CharacterModel"/>'s set of belongings.</param>
        public BeingStatus(BeingModel inBeingDefinition, ModelID inCurrentBehavior, Location inPosition, Location inSpawnAt,
                           int inBiomeTimeRemaining, float inBuildingSpeed, float inModificationSpeed, float inGatheringSpeed, float inMovementSpeed,
                           List<ModelID> inKnownBeings = null, List<ModelID> inKnownParquets = null, List<ModelID> inKnownRoomRecipes = null,
                           List<ModelID> inKnownCraftingRecipes = null, List<ModelID> inQuests = null, List<ModelID> inInventory = null)
        {
            Precondition.IsNotNull(inBeingDefinition, nameof(inBeingDefinition));
            Precondition.IsInRange(inCurrentBehavior, All.ScriptIDs, nameof(inCurrentBehavior));
            var nonNullBeings = inKnownBeings ?? Enumerable.Empty<ModelID>().ToList();
            var nonNullParquets = inKnownParquets ?? Enumerable.Empty<ModelID>().ToList();
            var nonNullRoomRecipes = inKnownRoomRecipes ?? Enumerable.Empty<ModelID>().ToList();
            var nonNullCraftingRecipes = inKnownCraftingRecipes ?? Enumerable.Empty<ModelID>().ToList();
            var nonNullQuests = inQuests ?? Enumerable.Empty<ModelID>().ToList();
            var nonNullInventory = inInventory ?? Enumerable.Empty<ModelID>().ToList();
            Precondition.AreInRange(nonNullBeings, All.CritterIDs, nameof(inKnownBeings));
            Precondition.AreInRange(nonNullParquets, All.ParquetIDs, nameof(inKnownParquets));
            Precondition.AreInRange(nonNullRoomRecipes, All.RoomRecipeIDs, nameof(inKnownRoomRecipes));
            Precondition.AreInRange(nonNullCraftingRecipes, All.CraftingRecipeIDs, nameof(inKnownCraftingRecipes));
            Precondition.AreInRange(nonNullQuests, All.InteractionIDs, nameof(inQuests));
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
            KnownBeings = nonNullBeings;
            KnownParquets = nonNullParquets;
            KnownRoomRecipes = nonNullRoomRecipes;
            KnownCraftingRecipes = nonNullCraftingRecipes;
            Quests = nonNullQuests;
            Inventory = nonNullInventory;
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="BeingStatus"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => BeingDefinition.Name;
        #endregion
    }
}
