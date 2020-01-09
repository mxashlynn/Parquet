using System.Collections.Generic;
using System.Linq;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Biomes
{
    /// <summary>
    /// Models the biome that a <see cref="Maps.MapRegion"/> embodies.
    /// </summary>
    public sealed class Biome : Entity
    {
        #region Characteristics
        /// <summary>
        /// A rating indicating where in the progression this <see cref="Biome"/> falls.
        /// Must be non-negative.  Higher values indicate later Biomes.
        /// </summary>
        public int Tier { get; }

        /// <summary>Describes where this <see cref="Biome"/> falls in terms of the game world's overall topography.</summary>
        public Elevation ElevationCategory { get; }

        /// <summary>Determines whether or not this <see cref="Biome"/> is defined in terms of liquid parquets.</summary>
        public bool IsLiquidBased { get; }

        /// <summary>Describes the parquets that make up this <see cref="Biome"/>.</summary>
        public IReadOnlyList<EntityTag> ParquetCriteria { get; }

        /// <summary>Describes the <see cref="Item"/>s a <see cref="Beings.PlayerCharacter"/> needs to safely access this <see cref="Biome"/>.</summary>
        public IReadOnlyList<EntityTag> EntryRequirements { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="Biome"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="Biome"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="Biome"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="Biome"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="Biome"/>.</param>
        /// <param name="inTier">A rating indicating where in the progression this <see cref="Biome"/> falls.</param>
        /// <param name="inElevationCategory">Describes where this <see cref="Biome"/> falls in terms of the game world's overall topography.</param>
        /// <param name="inIsLiquidBased">Determines whether or not this <see cref="Biome"/> is defined in terms of liquid parquets.</param>
        /// <param name="inParquetCriteria">Describes the parquets that make up this <see cref="Biome"/>.</param>
        /// <param name="inEntryRequirements">Describes the <see cref="Item"/>s needed to access this <see cref="Biome"/>.</param>
        public Biome(EntityID inID, string inName, string inDescription, string inComment,
                     int inTier, Elevation inElevationCategory,
                     bool inIsLiquidBased, List<EntityTag> inParquetCriteria,
                     List<EntityTag> inEntryRequirements)
            : base(All.BiomeIDs, inID, inName, inDescription, inComment)
        {
            Precondition.MustBeNonNegative(inTier, nameof(inTier));

            Tier = inTier;
            ElevationCategory = inElevationCategory;
            IsLiquidBased = inIsLiquidBased;
            ParquetCriteria = (inParquetCriteria ?? Enumerable.Empty<EntityTag>()).ToList();
            EntryRequirements = (inEntryRequirements ?? Enumerable.Empty<EntityTag>()).ToList();
        }
        #endregion
    }
}
