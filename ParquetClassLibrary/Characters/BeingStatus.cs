using Newtonsoft.Json;
using ParquetClassLibrary.Sandbox;

namespace ParquetClassLibrary.Characters
{
    public class BeingStatus
    {
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
                           float in_gatheringSpeed, float in_movementSpeed)
        {
            // TODO Precondition: None of these can be null.
            // TODO Precondition: All of these must be in range.

            BeingDefinition = in_beingDefinition;
            Position = in_position;
            SpawnAt = in_spawnAt;
            CurrentBehavior = in_currentBehavior;
            BiomeTimeRemaining = in_biomeTimeRemaining;
            BuildingSpeed = in_buildingSpeed;
            ModificationSpeed = in_modificationSpeed;
            GatheringSpeed = in_gatheringSpeed;
            MovementSpeed = in_movementSpeed;
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
