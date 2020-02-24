using System.Collections.Generic;
using System.Linq;
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Beings
{
    /// <summary>
    /// Models the basic definitions shared by any in-game actor.
    /// </summary>
    public abstract class BeingModel : Model
    {
        #region Characteristics
        /// <summary>The <see cref="ModelID"/> of the <see cref="Biome"/> in which this character is at home.</summary>
        [Index(4)]
        public ModelID NativeBiome { get; }

        /// <summary>The <see cref="Behavior"/> governing the way this character acts.</summary>
        [Index(5)]
        public Behavior PrimaryBehavior { get; }

        /// <summary>Types of parquets this <see cref="BeingModel"/> avoids, if any.</summary>
        [Index(6)]
        public IReadOnlyList<ModelID> Avoids { get; }

        /// <summary>Types of parquets this <see cref="BeingModel"/> seeks out, if any.</summary>
        [Index(7)]
        public IReadOnlyList<ModelID> Seeks { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Used by <see cref="BeingModel"/> subtypes.
        /// </summary>
        /// <param name="inBounds">
        /// The bounds within which the <see cref="BeingModel"/>'s <see cref="ModelID"/> is defined.
        /// Must be one of <see cref="All.BeingIDs"/>.
        /// </param>
        /// <param name="inID">Unique identifier for the <see cref="BeingModel"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="BeingModel"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="BeingModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="BeingModel"/>.</param>
        /// <param name="inNativeBiome">The <see cref="ModelID"/> for the <see cref="Biomes.BiomeModel"/> in which this <see cref="BeingModel"/> is most comfortable.</param>
        /// <param name="inPrimaryBehavior">The rules that govern how this <see cref="BeingModel"/> acts.  Cannot be null.</param>
        /// <param name="inAvoids">Any parquets this <see cref="BeingModel"/> avoids.</param>
        /// <param name="inSeeks">Any parquets this <see cref="BeingModel"/> seeks.</param>
        protected BeingModel(Range<ModelID> inBounds, ModelID inID, string inName, string inDescription,
                        string inComment, ModelID inNativeBiome, Behavior inPrimaryBehavior,
                        IEnumerable<ModelID> inAvoids = null, IEnumerable<ModelID> inSeeks = null)
            : base(inBounds, inID, inName, inDescription, inComment)
        {
            Precondition.IsInRange(inBounds, All.BeingIDs, nameof(inBounds));
            Precondition.IsInRange(inNativeBiome, All.BiomeIDs, nameof(inNativeBiome));
            Precondition.AreInRange(inAvoids, All.ParquetIDs, nameof(inAvoids));
            Precondition.AreInRange(inSeeks, All.ParquetIDs, nameof(inSeeks));

            NativeBiome = inNativeBiome;
            PrimaryBehavior = inPrimaryBehavior;
            Avoids = (inAvoids ?? Enumerable.Empty<ModelID>()).ToList();
            Seeks = (inSeeks ?? Enumerable.Empty<ModelID>()).ToList();
        }
        #endregion
    }
}
