using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CsvHelper.Configuration.Attributes;
using Parquet.EditorSupport;
using Parquet.Items;

namespace Parquet.Biomes
{
    [SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
                     Justification = "By design, subtypes of Model should never themselves use IMutableModel or derived interfaces to access their own members.  The IMutableModel family of interfaces is for external types that require read/write access.")]
    public partial class BiomeRecipe : IMutableBiomeRecipe
    {
        #region IBiomeRecipeEdit Implementation
        /// <summary>
        /// A rating indicating where in the progression this <see cref="BiomeRecipe"/> falls.
        /// Must be non-negative.  Higher values indicate later Biomes.
        /// </summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        int IMutableBiomeRecipe.Tier { get => Tier; set => Tier = value; }

        /// <summary>Determines whether or not this <see cref="BiomeRecipe"/> is defined in terms of <see cref="Rooms.Room"/>s.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        bool IMutableBiomeRecipe.IsRoomBased { get => IsRoomBased; set => IsRoomBased = value; }

        /// <summary>Determines whether or not this <see cref="BiomeRecipe"/> is defined in terms of liquid parquets.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        bool IMutableBiomeRecipe.IsLiquidBased { get => IsLiquidBased; set => IsLiquidBased = value; }

        /// <summary>Describes the parquets that make up this <see cref="BiomeRecipe"/>.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        ModelTag IMutableBiomeRecipe.ParquetCriteria { get => ParquetCriteria; set => ParquetCriteria = value; }

        /// <summary>Describes the <see cref="ItemModel"/>s a <see cref="Beings.CharacterModel"/> needs to safely access this biome.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        ICollection<ModelTag> IMutableBiomeRecipe.EntryRequirements => (ICollection<ModelTag>)EntryRequirements;
        #endregion
    }
}
