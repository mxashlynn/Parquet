using System.Collections.Generic;
using System.Linq;
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Maps;

namespace ParquetClassLibrary.Biomes
{
    /// <summary>
    /// Models the biome that a <see cref="MapRegionModel"/> embodies.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1033:Interface methods should be callable by child types",
        Justification = "By design, children of Model should never themselves use IModelEdit or its decendent interfaces to access their own members.  The IModelEdit family of interfaces is for external types that require read/write access.")]
    public sealed class BiomeRecipe : Model, IBiomeRecipeEdit
    {
        #region Class Defaults
        /// <summary>Represents the lack of a <see cref="BiomeRecipe"/> for <see cref="MapRegionModel"/>s that fail to qualify.</summary>
        public static BiomeRecipe None { get; } = new BiomeRecipe(ModelID.None, "Expanse", "A featureless region.", "The default biome.",
                                                                0, false, false, null, null);
        #endregion

        #region Characteristics
        /// <summary>
        /// A rating indicating where in the progression this <see cref="BiomeRecipe"/> falls.
        /// Must be non-negative.  Higher values indicate later Biomes.
        /// </summary>
        [Index(4)]
        public int Tier { get; private set; }

        /// <summary>
        /// A rating indicating where in the progression this <see cref="BiomeRecipe"/> falls.
        /// Must be non-negative.  Higher values indicate later Biomes.
        /// </summary>
        /// <remarks>
        /// By design, children of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require readwrite access.
        /// </remarks>
        [Ignore]
        int IBiomeRecipeEdit.Tier { get => Tier; set => Tier = value; }

        /// <summary>Determines whether or not this <see cref="BiomeRecipe"/> is defined in terms of <see cref="Rooms.Room"/>s.</summary>
        [Index(5)]
        public bool IsRoomBased { get; private set; }

        /// <summary>Determines whether or not this <see cref="BiomeRecipe"/> is defined in terms of <see cref="Rooms.Room"/>s.</summary>
        /// <remarks>
        /// By design, children of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require readwrite access.
        /// </remarks>
        [Ignore]
        bool IBiomeRecipeEdit.IsRoomBased { get => IsRoomBased; set => IsRoomBased = value; }

        /// <summary>Determines whether or not this <see cref="BiomeRecipe"/> is defined in terms of liquid parquets.</summary>
        [Index(6)]
        public bool IsLiquidBased { get; private set; }

        /// <summary>Determines whether or not this <see cref="BiomeRecipe"/> is defined in terms of liquid parquets.</summary>
        /// <remarks>
        /// By design, children of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require readwrite access.
        /// </remarks>
        [Ignore]
        bool IBiomeRecipeEdit.IsLiquidBased { get => IsLiquidBased; set => IsLiquidBased = value; }

        /// <summary>Describes the parquets that make up this <see cref="BiomeRecipe"/>.</summary>
        [Index(7)]
        public IReadOnlyList<ModelTag> ParquetCriteria { get; }

        /// <summary>Describes the parquets that make up this <see cref="BiomeRecipe"/>.</summary>
        /// <remarks>
        /// By design, children of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require readwrite access.
        /// </remarks>
        [Ignore]
        IList<ModelTag> IBiomeRecipeEdit.ParquetCriteria => (IList<ModelTag>)ParquetCriteria;

        /// <summary>Describes the <see cref="ItemModel"/>s a <see cref="Beings.CharacterModel"/> needs to safely access this biome.</summary>
        [Index(8)]
        public IReadOnlyList<ModelTag> EntryRequirements { get; }

        /// <summary>Describes the <see cref="ItemModel"/>s a <see cref="Beings.CharacterModel"/> needs to safely access this biome.</summary>
        /// <remarks>
        /// By design, children of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require readwrite access.
        /// </remarks>
        [Ignore]
        IList<ModelTag> IBiomeRecipeEdit.EntryRequirements => (IList<ModelTag>)EntryRequirements;
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="BiomeRecipe"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="BiomeRecipe"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="BiomeRecipe"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="BiomeRecipe"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="BiomeRecipe"/>.</param>
        /// <param name="inTier">A rating indicating where in the progression this <see cref="BiomeRecipe"/> falls.</param>
        /// <param name="inIsRoomBased">Determines whether or not this <see cref="BiomeRecipe"/> is defined in terms of <see cref="Rooms.Room"/>s.</param>
        /// <param name="inIsLiquidBased">Determines whether or not this <see cref="BiomeRecipe"/> is defined in terms of liquid parquets.</param>
        /// <param name="inParquetCriteria">Describes the parquets that make up this <see cref="BiomeRecipe"/>.</param>
        /// <param name="inEntryRequirements">Describes the <see cref="ItemModel"/>s needed to access this <see cref="BiomeRecipe"/>.</param>
        public BiomeRecipe(ModelID inID, string inName, string inDescription, string inComment,
                          int inTier = 0, bool inIsRoomBased = false, bool inIsLiquidBased = false,
                          IEnumerable<ModelTag> inParquetCriteria = null,
                          IEnumerable<ModelTag> inEntryRequirements = null)
            : base(All.BiomeIDs, inID, inName, inDescription, inComment)
        {
            Precondition.MustBeNonNegative(inTier, nameof(inTier));

            Tier = inTier;
            IsRoomBased = inIsRoomBased;
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
             => base.GetAllTags().Union(ParquetCriteria.Union(EntryRequirements));
        #endregion
    }
}
