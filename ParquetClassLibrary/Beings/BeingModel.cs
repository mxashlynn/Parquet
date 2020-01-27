using System.Collections.Generic;
using System.Linq;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Beings
{
    /// <summary>
    /// Models the basic definitions shared by any in-game actor.
    /// </summary>
    public abstract class BeingModel : EntityModel
    {
        #region Characteristics
        /// <summary>The <see cref="EntityID"/> of the <see cref="Biome"/> in which this character is at home.</summary>
        public EntityID NativeBiome { get; }

        /// <summary>The <see cref="Behavior"/> governing the way this character acts.</summary>
        public Behavior PrimaryBehavior { get; }

        /// <summary>Types of parquets this <see cref="BeingModel"/> avoids, if any.</summary>
        public IReadOnlyList<EntityID> Avoids { get; }

        /// <summary>Types of parquets this <see cref="BeingModel"/> seeks out, if any.</summary>
        public IReadOnlyList<EntityID> Seeks { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Used by <see cref="BeingModel"/> subtypes.
        /// </summary>
        /// <param name="inBounds">
        /// The bounds within which the <see cref="BeingModel"/>'s <see cref="EntityID"/> is defined.
        /// Must be one of <see cref="All.BeingIDs"/>.
        /// </param>
        /// <param name="inID">Unique identifier for the <see cref="BeingModel"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="BeingModel"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="BeingModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="BeingModel"/>.</param>
        /// <param name="inNativeBiome">The <see cref="EntityID"/> for the <see cref="Biomes.BiomeModel"/> in which this <see cref="BeingModel"/> is most comfortable.</param>
        /// <param name="inPrimaryBehavior">The rules that govern how this <see cref="BeingModel"/> acts.  Cannot be null.</param>
        /// <param name="inAvoids">Any parquets this <see cref="BeingModel"/> avoids.</param>
        /// <param name="inSeeks">Any parquets this <see cref="BeingModel"/> seeks.</param>
        protected BeingModel(Range<EntityID> inBounds, EntityID inID, string inName, string inDescription,
                        string inComment, EntityID inNativeBiome, Behavior inPrimaryBehavior,
                        IEnumerable<EntityID> inAvoids = null, IEnumerable<EntityID> inSeeks = null)
            : base(inBounds, inID, inName, inDescription, inComment)
        {
            Precondition.IsInRange(inBounds, All.BeingIDs, nameof(inBounds));
            Precondition.IsInRange(inNativeBiome, All.BiomeIDs, nameof(inNativeBiome));
            Precondition.AreInRange(inAvoids, All.ParquetIDs, nameof(inAvoids));
            Precondition.AreInRange(inSeeks, All.ParquetIDs, nameof(inSeeks));

            NativeBiome = inNativeBiome;
            PrimaryBehavior = inPrimaryBehavior;
            Avoids = (inAvoids ?? Enumerable.Empty<EntityID>()).ToList();
            Seeks = (inSeeks ?? Enumerable.Empty<EntityID>()).ToList();
        }
        #endregion
    }
}
