using System.Collections.Generic;
using System.Linq;
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.EditorSupport;
using ParquetClassLibrary.Scripts;

namespace ParquetClassLibrary.Beings
{
    /// <summary>
    /// Models the basic definitions shared by any in-game actor.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
        Justification = "By design, subtypes of Model should never themselves use IModelEdit or derived interfaces to access their own members.  The IModelEdit family of interfaces is for external types that require read/write access.")]
    public abstract class BeingModel : Model, IBeingModelEdit
    {
        #region Characteristics
        /// <summary>The <see cref="ModelID"/> of the <see cref="Biomes.BiomeRecipe"/> in which this character is at home.</summary>
        [Index(4)]
        public ModelID NativeBiomeID { get; private set; }

        /// <summary>The <see cref="ModelID"/> of the <see cref="Biomes.BiomeRecipe"/> in which this character is at home.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ModelID IBeingModelEdit.NativeBiomeID { get => NativeBiomeID; set => NativeBiomeID = value; }

        /// <summary>The <see cref="ModelID"/> of the <see cref="ScriptModel"/> governing the way this being acts.</summary>
        [Index(5)]
        public ModelID PrimaryBehaviorID { get; private set; }

        /// <summary>The <see cref="ModelID"/> of the <see cref="ScriptModel"/> governing the way this being acts.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ModelID IBeingModelEdit.PrimaryBehaviorID { get => PrimaryBehaviorID; set => PrimaryBehaviorID = value; }

        /// <summary>Types of parquets this <see cref="BeingModel"/> avoids, if any.</summary>
        [Index(6)]
        public IReadOnlyList<ModelID> AvoidsIDs { get; }

        /// <summary>Types of parquets this <see cref="BeingModel"/> avoids, if any.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        IList<ModelID> IBeingModelEdit.AvoidsIDs => (IList<ModelID>)AvoidsIDs;

        /// <summary>Types of parquets this <see cref="BeingModel"/> seeks out, if any.</summary>
        [Index(7)]
        public IReadOnlyList<ModelID> SeeksIDs { get; }

        /// <summary>Types of parquets this <see cref="BeingModel"/> seeks out, if any.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        IList<ModelID> IBeingModelEdit.SeeksIDs => (IList<ModelID>)SeeksIDs;
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
        /// <param name="inNativeBiomeID">The <see cref="ModelID"/> for the <see cref="Biomes.BiomeRecipe"/> in which this <see cref="BeingModel"/> is most comfortable.</param>
        /// <param name="inPrimaryBehaviorID">The rules that govern how this <see cref="BeingModel"/> acts.  Cannot be null.</param>
        /// <param name="inAvoidsIDs">Any parquets this <see cref="BeingModel"/> avoids.</param>
        /// <param name="inSeeksIDs">Any parquets this <see cref="BeingModel"/> seeks.</param>
        protected BeingModel(Range<ModelID> inBounds, ModelID inID, string inName, string inDescription,
                             string inComment, ModelID? inNativeBiomeID = null, ModelID? inPrimaryBehaviorID = null,
                             IEnumerable<ModelID> inAvoidsIDs = null, IEnumerable<ModelID> inSeeksIDs = null)
            : base(inBounds, inID, inName, inDescription, inComment)
        {
            var nonNullNativeBiomeID = inNativeBiomeID ?? ModelID.None;
            var nonNullPrimaryBehaviorID = inPrimaryBehaviorID ?? ModelID.None;
            var nonNullAvoidsIDs = (inAvoidsIDs ?? Enumerable.Empty<ModelID>()).ToList();
            var nonNullSeeksIDs = (inSeeksIDs ?? Enumerable.Empty<ModelID>()).ToList();

            Precondition.IsInRange(inBounds, All.BeingIDs, nameof(inBounds));
            Precondition.IsInRange(nonNullNativeBiomeID, All.BiomeIDs, nameof(inNativeBiomeID));
            Precondition.IsInRange(nonNullPrimaryBehaviorID, All.ScriptIDs, nameof(inPrimaryBehaviorID));
            Precondition.AreInRange(nonNullAvoidsIDs, All.ParquetIDs, nameof(inAvoidsIDs));
            Precondition.AreInRange(nonNullSeeksIDs, All.ParquetIDs, nameof(inSeeksIDs));

            NativeBiomeID = nonNullNativeBiomeID;
            PrimaryBehaviorID = nonNullPrimaryBehaviorID;
            AvoidsIDs = nonNullAvoidsIDs;
            SeeksIDs = nonNullSeeksIDs;
        }
        #endregion
    }
}
