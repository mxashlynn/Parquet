using System.Collections.Generic;
using System.Linq;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Beings
{
    /// <summary>
    /// Models the basic definitions shared by any in-game actor.
    /// </summary>
    public abstract class Being : Entity
    {
        #region Characteristics
        /// <summary>The <see cref="EntityID"/> of the <see cref="Biome"/> in which this character is at home.</summary>
        public EntityID NativeBiome { get; }

        /// <summary>The <see cref="Behavior"/> governing the way this character acts.</summary>
        public Behavior PrimaryBehavior { get; }

        /// <summary>Types of parquets this <see cref="Being"/> avoids, if any.</summary>
        public IReadOnlyList<EntityID> Avoids { get; }

        /// <summary>Types of parquets this <see cref="Being"/> seeks out, if any.</summary>
        public IReadOnlyList<EntityID> Seeks { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Used by <see cref="Being"/> subtypes.
        /// </summary>
        /// <param name="in_bounds">
        /// The bounds within which the <see cref="Being"/>'s <see cref="EntityID"/> is defined.
        /// Must be one of <see cref="All.BeingIDs"/>.
        /// </param>
        /// <param name="in_id">Unique identifier for the <see cref="Being"/>.  Cannot be null.</param>
        /// <param name="in_name">Player-friendly name of the <see cref="Being"/>.  Cannot be null or empty.</param>
        /// <param name="in_description">Player-friendly description of the <see cref="Being"/>.</param>
        /// <param name="in_comment">Comment of, on, or by the <see cref="Being"/>.</param>
        /// <param name="in_nativeBiome">The <see cref="EntityID"/> for the <see cref="Biome"/> in which this <see cref="Being"/> is most comfortable.</param>
        /// <param name="in_primaryBehavior">The rules that govern how this <see cref="Being"/> acts.  Cannot be null.</param>
        /// <param name="in_avoids">Any parquets this <see cref="Being"/> avoids.</param>
        /// <param name="in_seeks">Any parquets this <see cref="Being"/> seeks.</param>
        protected Being(Range<EntityID> in_bounds, EntityID in_id, string in_name, string in_description,
                        string in_comment, EntityID in_nativeBiome, Behavior in_primaryBehavior,
                        List<EntityID> in_avoids = null, List<EntityID> in_seeks = null)
            : base(in_bounds, in_id, in_name, in_description, in_comment)
        {
            Precondition.IsInRange(in_bounds, All.BeingIDs, nameof(in_bounds));
            Precondition.IsInRange(in_nativeBiome, All.BiomeIDs, nameof(in_nativeBiome));
            Precondition.AreInRange(in_avoids, All.ParquetIDs, nameof(in_avoids));
            Precondition.AreInRange(in_seeks, All.ParquetIDs, nameof(in_seeks));

            NativeBiome = in_nativeBiome;
            PrimaryBehavior = in_primaryBehavior;
            Avoids = (in_avoids ?? Enumerable.Empty<EntityID>()).ToList();
            Seeks = (in_seeks ?? Enumerable.Empty<EntityID>()).ToList();
        }
        #endregion
    }
}
