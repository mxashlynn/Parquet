using System.Collections.Generic;
using System.Linq;
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Biomes
{
    /// <summary>
    /// Models the biome that a <see cref="Maps.MapRegion"/> embodies.
    /// </summary>
    public sealed class BiomeModel : Model
    {
        #region Characteristics
        /// <summary>
        /// A rating indicating where in the progression this <see cref="BiomeModel"/> falls.
        /// Must be non-negative.  Higher values indicate later Biomes.
        /// </summary>
        [Index(4)]
        public int Tier { get; }

        /// <summary>Describes where this <see cref="BiomeModel"/> falls in terms of the game world's overall topography.</summary>
        [Index(5)]
        public Elevation ElevationCategory { get; }

        /// <summary>Determines whether or not this <see cref="BiomeModel"/> is defined in terms of liquid parquets.</summary>
        [Index(6)]
        public bool IsLiquidBased { get; }

        /// <summary>Describes the parquets that make up this <see cref="BiomeModel"/>.</summary>
        [Index(7)]
        public IReadOnlyList<ModelTag> ParquetCriteria { get; }

        /// <summary>Describes the <see cref="ItemModel"/>s a <see cref="Beings.CharacterModel"/> needs to safely access this <see cref="BiomeModel"/>.</summary>
        [Index(8)]
        public IReadOnlyList<ModelTag> EntryRequirements { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="BiomeModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="BiomeModel"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="BiomeModel"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="BiomeModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="BiomeModel"/>.</param>
        /// <param name="inTier">A rating indicating where in the progression this <see cref="BiomeModel"/> falls.</param>
        /// <param name="inElevationCategory">Describes where this <see cref="BiomeModel"/> falls in terms of the game world's overall topography.</param>
        /// <param name="inIsLiquidBased">Determines whether or not this <see cref="BiomeModel"/> is defined in terms of liquid parquets.</param>
        /// <param name="inParquetCriteria">Describes the parquets that make up this <see cref="BiomeModel"/>.</param>
        /// <param name="inEntryRequirements">Describes the <see cref="ItemModel"/>s needed to access this <see cref="BiomeModel"/>.</param>
        public BiomeModel(ModelID inID, string inName, string inDescription, string inComment,
                          int inTier, Elevation inElevationCategory,
                          bool inIsLiquidBased, IEnumerable<ModelTag> inParquetCriteria,
                          IEnumerable<ModelTag> inEntryRequirements)
            : base(All.BiomeIDs, inID, inName, inDescription, inComment)
        {
            Precondition.MustBeNonNegative(inTier, nameof(inTier));

            Tier = inTier;
            ElevationCategory = inElevationCategory;
            IsLiquidBased = inIsLiquidBased;
            ParquetCriteria = (inParquetCriteria ?? Enumerable.Empty<ModelTag>()).ToList();
            EntryRequirements = (inEntryRequirements ?? Enumerable.Empty<ModelTag>()).ToList();
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a collection of all <see cref="ModelTag"/>s the <see cref="Model"/> has applied to it. Classes inheriting from <see cref="Model"/> that include <see cref="ModelTag"/> should override accordingly.
        /// </summary>
        /// <returns>List of all <see cref="ModelTag"/>s.</returns>
        public override IEnumerable<ModelTag> GetAllTags()
        {
            return base.GetAllTags().Union(ParquetCriteria).Union(EntryRequirements);
        }
        #endregion
    }
}
