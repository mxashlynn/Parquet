using System.Collections.Generic;
using System.Linq;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Biomes
{
    /// <summary>
    /// Models the biome that a <see cref="Map.MapRegion"/> embodies.
    /// </summary>
    public class Biome : Entity
    {
        #region Characteristics
        /// <summary>
        /// A rating indicating where in the progression this <see cref="Biome"/> falls.
        /// Must be non-negative.  Higher values indicate later Biomes.
        /// </summary>
        public int Tier { get; }

        /// <summary>
        /// Describes where this <see cref="Biome"/> falls in terms of the game world's overall topography.
        /// </summary>
        public Elevation ElevationCategory { get; }

        /// <summary>
        /// Determines whether or not this <see cref="Biome"/> is defined in terms of liquid parquets.
        /// </summary>
        public bool IsLiquidBased { get; }

        /// <summary>
        /// Describes the parquets that make up this <see cref="Biome"/>.
        /// </summary>
        public IReadOnlyList<EntityTag> ParquetCriteria { get; }

        /// <summary>
        /// Describes the <see cref="Item"/>s a <see cref="Beings.PlayerCharacter"/> needs to
        /// safely access this <see cref="Biome"/>.
        /// </summary>
        public IReadOnlyList<EntityTag> EntryRequirements { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="Biome"/> class.
        /// </summary>
        /// <param name="in_id">Unique identifier for the <see cref="Biome"/>.  Cannot be null.</param>
        /// <param name="in_name">Player-friendly name of the <see cref="Biome"/>.  Cannot be null or empty.</param>
        /// <param name="in_description">Player-friendly description of the <see cref="Biome"/>.</param>
        /// <param name="in_comment">Comment of, on, or by the <see cref="Biome"/>.</param>
        /// <param name="in_tier">A rating indicating where in the progression this <see cref="Biome"/> falls.</param>
        /// <param name="in_elevationCategory">Describes where this <see cref="Biome"/> falls in terms of the game world's overall topography.</param>
        /// <param name="in_isLiquidBased">Determines whether or not this <see cref="Biome"/> is defined in terms of liquid parquets.</param>
        /// <param name="in_parquetCriteria">Describes the parquets that make up this <see cref="Biome"/>.</param>
        /// <param name="in_entryRequirements">Describes the <see cref="Item"/>s needed to access this <see cref="Biome"/>.</param>
        public Biome(EntityID in_id, string in_name, string in_description, string in_comment,
                     int in_tier, Elevation in_elevationCategory,
                     bool in_isLiquidBased, List<EntityTag> in_parquetCriteria,
                     List<EntityTag> in_entryRequirements)
            : base(All.BiomeIDs, in_id, in_name, in_description, in_comment)
        {
            Precondition.MustBeNonNegative(in_tier, nameof(in_tier));

            Tier = in_tier;
            ElevationCategory = in_elevationCategory;
            IsLiquidBased = in_isLiquidBased;
            ParquetCriteria = (in_parquetCriteria ?? Enumerable.Empty<EntityTag>()).ToList();
            EntryRequirements = (in_entryRequirements ?? Enumerable.Empty<EntityTag>()).ToList();
        }
        #endregion
    }
}
