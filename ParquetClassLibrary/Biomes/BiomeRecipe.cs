using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CsvHelper.Configuration.Attributes;
using Parquet.Items;
using Parquet.Regions;

namespace Parquet.Biomes
{
    /// <summary>
    /// Models the biome that a <see cref="RegionModel"/> embodies.
    /// </summary>
    /// <remarks>
    /// Runtime biome detection is an important feature in the design of Parquet.
    /// </remarks>
    [SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
                     Justification = "By design, subtypes of Model should never themselves use IMutableModel or derived interfaces to access their own members.  The IMutableModel family of interfaces is for external types that require read/write access.")]
    public class BiomeRecipe : Model, IMutableBiomeRecipe
    {
        #region Class Defaults
        /// <summary>Represents the lack of a <see cref="BiomeRecipe"/> for <see cref="RegionModel"/>s that fail to qualify.</summary>
        public static BiomeRecipe None { get; } = new BiomeRecipe(ModelID.None, "Expanse", "A featureless region.", "The default biome.",
                                                                  null, 0, false, false, null, null);
        #endregion

        #region Characteristics
        /// <summary>
        /// A rating indicating where in the progression this <see cref="BiomeRecipe"/> falls.
        /// Must be non-negative.  Higher values indicate later Biomes.
        /// </summary>
        [Index(5)]
        public int Tier { get; private set; }

        /// <summary>When <c>true</c> this <see cref="BiomeRecipe"/> is defined in terms of <see cref="Rooms.Room"/>s.</summary>
        [Index(6)]
        public bool IsRoomBased { get; private set; }

        /// <summary>When <c>true</c> this <see cref="BiomeRecipe"/> is defined in terms of liquid parquets.</summary>
        [Index(7)]
        public bool IsLiquidBased { get; private set; }

        /// <summary>Describes the parquets that make up this <see cref="BiomeRecipe"/>.</summary>
        [Index(8)]
        public ModelTag ParquetCriteria { get; private set; }

        /// <summary>Describes the <see cref="ItemModel"/>s a <see cref="Beings.CharacterModel"/> needs to safely access this biome.</summary>
        [Index(9)]
        public IReadOnlyList<ModelTag> EntryRequirements { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="BiomeRecipe"/> class.
        /// </summary>
        /// <param name="id">Unique identifier for the <see cref="BiomeRecipe"/>.  Cannot be null.</param>
        /// <param name="name">Player-friendly name of the <see cref="BiomeRecipe"/>.  Cannot be null or empty.</param>
        /// <param name="description">Player-friendly description of the <see cref="BiomeRecipe"/>.</param>
        /// <param name="comment">Comment of, on, or by the <see cref="BiomeRecipe"/>.</param>
        /// <param name="tags">Any additional functionality this <see cref="BiomeRecipe"/> has.</param>
        /// <param name="tier">A rating indicating where in the progression this <see cref="BiomeRecipe"/> falls.</param>
        /// <param name="isRoomBased">Determines whether or not this <see cref="BiomeRecipe"/> is defined in terms of <see cref="Rooms.Room"/>s.</param>
        /// <param name="isLiquidBased">Determines whether or not this <see cref="BiomeRecipe"/> is defined in terms of liquid parquets.</param>
        /// <param name="parquetCriteria">Describes the parquets that make up this <see cref="BiomeRecipe"/>.</param>
        /// <param name="entryRequirements">Describes the <see cref="ItemModel"/>s needed to access this <see cref="BiomeRecipe"/>.</param>
        public BiomeRecipe(ModelID id, string name, string description, string comment,
                           IEnumerable<ModelTag> tags = null, int tier = 0, bool isRoomBased = false,
                           bool isLiquidBased = false, ModelTag parquetCriteria = null,
                           IEnumerable<ModelTag> entryRequirements = null)
            : base(All.BiomeRecipeIDs, id, name, description, comment, tags)
        {
            Precondition.MustBeNonNegative(tier, nameof(tier));

            Tier = tier;
            IsRoomBased = isRoomBased;
            IsLiquidBased = isLiquidBased;
            ParquetCriteria = parquetCriteria ?? ModelTag.None;
            EntryRequirements = (entryRequirements ?? Enumerable.Empty<ModelTag>()).ToList();
        }
        #endregion

        #region IMutableBiomeRecipe Implementation
        /// <summary>
        /// A rating indicating where in the progression this <see cref="BiomeRecipe"/> falls.
        /// Must be non-negative.  Higher values indicate later Biomes.
        /// </summary>
        /// <remarks>
        /// By design, subtypes of <see cref="BiomeRecipe"/> should never themselves use <see cref="IMutableBiomeRecipe"/>.
        /// IMutableBiomeRecipe is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        int IMutableBiomeRecipe.Tier
        {
            get => Tier;
            set => Tier = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(Tier), Tier)
                : value;
        }

        /// <summary>Determines whether or not this <see cref="BiomeRecipe"/> is defined in terms of <see cref="Rooms.Room"/>s.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="BiomeRecipe"/> should never themselves use <see cref="IMutableBiomeRecipe"/>.
        /// IMutableBiomeRecipe is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        bool IMutableBiomeRecipe.IsRoomBased
        {
            get => IsRoomBased;
            set => IsRoomBased = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(IsRoomBased), IsRoomBased)
                : value;
        }

        /// <summary>Determines whether or not this <see cref="BiomeRecipe"/> is defined in terms of liquid parquets.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="BiomeRecipe"/> should never themselves use <see cref="IMutableBiomeRecipe"/>.
        /// IMutableBiomeRecipe is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        bool IMutableBiomeRecipe.IsLiquidBased
        {
            get => IsLiquidBased;
            set => IsLiquidBased = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(IsLiquidBased), IsLiquidBased)
                : value;
        }

        /// <summary>Describes the parquets that make up this <see cref="BiomeRecipe"/>.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="BiomeRecipe"/> should never themselves use <see cref="IMutableBiomeRecipe"/>.
        /// IMutableBiomeRecipe is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        ModelTag IMutableBiomeRecipe.ParquetCriteria
        {
            get => ParquetCriteria;
            set => ParquetCriteria = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(ParquetCriteria), ParquetCriteria)
                : value;
        }

        /// <summary>Describes the <see cref="ItemModel"/>s a <see cref="Beings.CharacterModel"/> needs to safely access this biome.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="BiomeRecipe"/> should never themselves use <see cref="IMutableBiomeRecipe"/>.
        /// IMutableBiomeRecipe is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        ICollection<ModelTag> IMutableBiomeRecipe.EntryRequirements
            => LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(EntryRequirements), new Collection<ModelTag>())
                : (ICollection<ModelTag>)EntryRequirements;
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a collection of all <see cref="ModelTag"/>s the <see cref="Model"/> has applied to it. Classes inheriting from <see cref="Model"/> that include <see cref="ModelTag"/> should override accordingly.
        /// </summary>
        /// <returns>List of all <see cref="ModelTag"/>s.</returns>
        public override IEnumerable<ModelTag> GetAllTags()
             => base.GetAllTags().Union(EntryRequirements).Append(ParquetCriteria);
        #endregion
    }
}
