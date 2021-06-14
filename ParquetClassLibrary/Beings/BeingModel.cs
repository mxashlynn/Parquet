using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CsvHelper.Configuration.Attributes;
using Parquet.Scripts;

namespace Parquet.Beings
{
    /// <summary>
    /// Models the basic definitions shared by any in-game actor.
    /// </summary>
    public abstract class BeingModel : Model, IMutableBeingModel
    {
        #region Characteristics
        /// <summary>The <see cref="ModelID"/> of the <see cref="Biomes.BiomeRecipe"/> in which this <see cref="BeingModel"/> is at home.</summary>
        [Index(5)]
        public ModelID NativeBiomeID { get; protected set; }

        /// <summary>The <see cref="ModelID"/> of the <see cref="ScriptModel"/> governing the way this <see cref="BeingModel"/> acts.</summary>
        [Index(6)]
        public ModelID PrimaryBehaviorID { get; protected set; }

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
        /// <param name="bounds">
        /// The bounds within which the being's <see cref="ModelID"/> is defined.
        /// Must be one of <see cref="All.BeingIDs"/>.
        /// </param>
        /// <param name="id">Unique identifier for the being.  Cannot be null.</param>
        /// <param name="name">Player-friendly name of the being.  Cannot be null or empty.</param>
        /// <param name="description">Player-friendly description of the being.</param>
        /// <param name="comment">Comment of, on, or by the being.</param>
        /// <param name="tags">Any additional functionality this being has, e.g. contributing to a <see cref="Biomes.BiomeRecipe"/>.</param>
        /// <param name="nativeBiomeID">The <see cref="ModelID"/> for the <see cref="Biomes.BiomeRecipe"/> in which this being is most comfortable.</param>
        /// <param name="primaryBehaviorID">The rules that govern how this being acts.  Cannot be null.</param>
        /// <param name="avoidsIDs">Any parquets this being avoids.</param>
        /// <param name="seeksIDs">Any parquets this being seeks.</param>
        protected BeingModel(Range<ModelID> bounds, ModelID id, string name, string description,
                             string comment, IEnumerable<ModelTag> tags = null, ModelID? nativeBiomeID = null,
                             ModelID? primaryBehaviorID = null, IEnumerable<ModelID> avoidsIDs = null,
                             IEnumerable<ModelID> seeksIDs = null)
            : base(bounds, id, name, description, comment, tags)
        {
            var nonNullNativeBiomeID = nativeBiomeID ?? ModelID.None;
            var nonNullPrimaryBehaviorID = primaryBehaviorID ?? ModelID.None;
            var nonNullAvoidsIDs = (avoidsIDs ?? Enumerable.Empty<ModelID>()).ToList();
            var nonNullSeeksIDs = (seeksIDs ?? Enumerable.Empty<ModelID>()).ToList();

            Precondition.IsInRange(bounds, All.BeingIDs, nameof(bounds));
            Precondition.IsInRange(nonNullNativeBiomeID, All.BiomeRecipeIDs, nameof(nativeBiomeID));
            Precondition.IsInRange(nonNullPrimaryBehaviorID, All.ScriptIDs, nameof(primaryBehaviorID));
            Precondition.AreInRange(nonNullAvoidsIDs, All.ParquetIDs, nameof(avoidsIDs));
            Precondition.AreInRange(nonNullSeeksIDs, All.ParquetIDs, nameof(seeksIDs));

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
