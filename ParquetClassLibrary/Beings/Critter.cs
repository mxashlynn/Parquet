using System.Collections.Generic;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Beings
{
    /// <summary>
    /// Models the definition for a simple in-game actor, such as a friendly mob with limited interaction.
    /// </summary>
    public sealed class Critter : BeingModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Critter"/> class.
        /// </summary>
        /// <param name="inID">
        /// Unique identifier for the <see cref="Critter"/>.  Cannot be null.
        /// Must be a <see cref="All.CritterIDs"/>.
        /// </param>
        /// <param name="inName">Player-friendly name of the <see cref="Critter"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="Critter"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="Critter"/>.</param>
        /// <param name="inNativeBiome">The <see cref="BiomeModel"/> in which this <see cref="Critter"/> is most comfortable.</param>
        /// <param name="inPrimaryBehavior">The rules that govern how this <see cref="Critter"/> acts.  Cannot be null.</param>
        /// <param name="inAvoids">Any parquets this <see cref="Critter"/> avoids.</param>
        /// <param name="inSeeks">Any parquets this <see cref="Critter"/> seeks.</param>
        public Critter(EntityID inID, string inName, string inDescription, string inComment,
                       EntityID inNativeBiome, Behavior inPrimaryBehavior,
                       List<EntityID> inAvoids = null, List<EntityID> inSeeks = null)
            : base(All.CritterIDs, inID, inName, inDescription, inComment, inNativeBiome, inPrimaryBehavior, inAvoids, inSeeks)
        {
            Precondition.IsInRange(inID, All.CritterIDs, nameof(inID));
        }
    }
}
