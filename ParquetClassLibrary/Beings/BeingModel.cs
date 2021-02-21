using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CsvHelper.Configuration.Attributes;
using Parquet.Scripts;

namespace Parquet.Beings
{
    /// <summary>
    /// Models the basic definitions shared by any in-game actor.
    /// </summary>
    [SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
                     Justification = "By design, subtypes of Model should never themselves use IMutableModel or derived interfaces to access their own members.  The IMutableModel family of interfaces is for external types that require read/write access.")]
    public abstract class BeingModel : Model, IMutableBeingModel
    {
        #region Characteristics
        /// <summary>The <see cref="ModelID"/> of the <see cref="Biomes.BiomeRecipe"/> in which this character is at home.</summary>
        [Index(5)]
        public ModelID NativeBiomeID { get; private set; }

        /// <summary>The <see cref="ModelID"/> of the <see cref="ScriptModel"/> governing the way this being acts.</summary>
        [Index(6)]
        public ModelID PrimaryBehaviorID { get; private set; }

        /// <summary>Types of parquets this <see cref="BeingModel"/> avoids, if any.</summary>
        [Index(7)]
        public IReadOnlyList<ModelID> AvoidsIDs { get; }

        /// <summary>Types of parquets this <see cref="BeingModel"/> seeks out, if any.</summary>
        [Index(8)]
        public IReadOnlyList<ModelID> SeeksIDs { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Used by <see cref="BeingModel"/> subtypes.
        /// </summary>
        /// <param name="inBounds">
        /// The bounds within which the being's <see cref="ModelID"/> is defined.
        /// Must be one of <see cref="All.BeingIDs"/>.
        /// </param>
        /// <param name="inID">Unique identifier for the being.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the being.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the being.</param>
        /// <param name="inComment">Comment of, on, or by the being.</param>
        /// <param name="inTags">Any additional functionality this being has, e.g. contributing to a <see cref="Biomes.BiomeRecipe"/>.</param>
        /// <param name="inNativeBiomeID">The <see cref="ModelID"/> for the <see cref="Biomes.BiomeRecipe"/> in which this being is most comfortable.</param>
        /// <param name="inPrimaryBehaviorID">The rules that govern how this being acts.  Cannot be null.</param>
        /// <param name="inAvoidsIDs">Any parquets this being avoids.</param>
        /// <param name="inSeeksIDs">Any parquets this being seeks.</param>
        protected BeingModel(Range<ModelID> inBounds, ModelID inID, string inName, string inDescription,
                             string inComment, IEnumerable<ModelTag> inTags = null, ModelID? inNativeBiomeID = null,
                             ModelID? inPrimaryBehaviorID = null, IEnumerable<ModelID> inAvoidsIDs = null,
                             IEnumerable<ModelID> inSeeksIDs = null)
            : base(inBounds, inID, inName, inDescription, inComment, inTags)
        {
            var nonNullNativeBiomeID = inNativeBiomeID ?? ModelID.None;
            var nonNullPrimaryBehaviorID = inPrimaryBehaviorID ?? ModelID.None;
            var nonNullAvoidsIDs = (inAvoidsIDs ?? Enumerable.Empty<ModelID>()).ToList();
            var nonNullSeeksIDs = (inSeeksIDs ?? Enumerable.Empty<ModelID>()).ToList();

            Precondition.IsInRange(inBounds, All.BeingIDs, nameof(inBounds));
            Precondition.IsInRange(nonNullNativeBiomeID, All.BiomeRecipeIDs, nameof(inNativeBiomeID));
            Precondition.IsInRange(nonNullPrimaryBehaviorID, All.ScriptIDs, nameof(inPrimaryBehaviorID));
            Precondition.AreInRange(nonNullAvoidsIDs, All.ParquetIDs, nameof(inAvoidsIDs));
            Precondition.AreInRange(nonNullSeeksIDs, All.ParquetIDs, nameof(inSeeksIDs));

            NativeBiomeID = nonNullNativeBiomeID;
            PrimaryBehaviorID = nonNullPrimaryBehaviorID;
            AvoidsIDs = nonNullAvoidsIDs;
            SeeksIDs = nonNullSeeksIDs;
        }
        #endregion

        #region IMutableBeingModel Implementation
        /// <summary>The <see cref="ModelID"/> of the <see cref="Biomes.BiomeRecipe"/> in which this character is at home.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IMutableBeingModel is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ModelID IMutableBeingModel.NativeBiomeID
        {
            get => NativeBiomeID;
            set => NativeBiomeID = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(NativeBiomeID), NativeBiomeID)
                : value;
        }

        /// <summary>The <see cref="ModelID"/> of the <see cref="ScriptModel"/> governing the way this being acts.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IMutableBeingModel is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ModelID IMutableBeingModel.PrimaryBehaviorID
        {
            get => PrimaryBehaviorID;
            set => PrimaryBehaviorID = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(PrimaryBehaviorID), PrimaryBehaviorID)
                : value;
        }

        /// <summary>Types of parquets this <see cref="BeingModel"/> avoids, if any.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IMutableBeingModel is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ICollection<ModelID> IMutableBeingModel.AvoidsIDs
            => LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(AvoidsIDs), new Collection<ModelID>())
                : (ICollection<ModelID>)AvoidsIDs;

        /// <summary>Types of parquets this <see cref="BeingModel"/> seeks out, if any.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IMutableBeingModel is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ICollection<ModelID> IMutableBeingModel.SeeksIDs
            => LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(SeeksIDs), new Collection<ModelID>())
                : (ICollection<ModelID>)SeeksIDs;
        #endregion
    }
}
