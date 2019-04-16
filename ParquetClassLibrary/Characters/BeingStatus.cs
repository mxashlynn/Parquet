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

        /// <summary>The <see cref="Behavior"/> currently governing the tracked <see cref="Being"/>.</summary>
        [JsonProperty(PropertyName = "in_currentBehavior")]
        public Behavior CurrentBehavior { get; set; }

        // IDEA I expect more will be added here as design goes on.

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="BeingStatus"/> class.
        /// </summary>
        /// <param name="in_beingDefinition">The parquets whose status this instance is tracking.</param>
        /// <param name="in_position">Whether or not the <see cref="Floor"/> associated with this status has been dug out.</param>
        /// <param name="in_currentBehavior">The <see cref="Behavior"/> currently governing .</param>
        [JsonConstructor]
        public BeingStatus(Being in_beingDefinition, Location in_position, Behavior in_currentBehavior)
        {
            BeingDefinition = in_beingDefinition;
            Position = in_position;
            CurrentBehavior = in_currentBehavior;
        }
        #endregion

        #region Utility Methods
        /// <summary>
        /// Returns a <see langword="string"/> that represents the current <see cref="BeingStatus"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
        {
            return $"{BeingDefinition.Name}";
        }
        #endregion
    }
}