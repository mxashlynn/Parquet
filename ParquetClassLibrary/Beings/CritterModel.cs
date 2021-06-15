using System.Collections.Generic;

namespace Parquet.Beings
{
    /// <summary>
    /// Models the definition for a simple in-game actor, such as a friendly mob with limited interaction.
    /// </summary>
    public class CritterModel : BeingModel, IMutableCritterModel
    {
        #region Class Defaults
        /// <summary>Indicates an uninitialized critter.</summary>
        public static CritterModel Unused { get; } = new CritterModel(ModelID.None, nameof(Unused), "", "");
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="CritterModel"/> class.
        /// </summary>
        /// <param name="id">
        /// Unique identifier for the <see cref="CritterModel"/>.  Cannot be null.
        /// Must be a <see cref="All.CritterIDs"/>.
        /// </param>
        /// <param name="name">Player-friendly name of the <see cref="CritterModel"/>.  Cannot be null or empty.</param>
        /// <param name="description">Player-friendly description of the <see cref="CritterModel"/>.</param>
        /// <param name="comment">Comment of, on, or by the <see cref="CritterModel"/>.</param>
        /// <param name="tags">Any additional information about the <see cref="CritterModel"/>.</param>
        /// <param name="nativeBiomeID">The <see cref="Biomes.BiomeRecipe"/> in which this <see cref="CritterModel"/> is most comfortable.</param>
        /// <param name="primaryBehaviorID">The rules that govern how this <see cref="CritterModel"/> acts.  Cannot be null.</param>
        /// <param name="avoidsIDs">Any parquets this <see cref="CritterModel"/> avoids.</param>
        /// <param name="seeksIDs">Any parquets this <see cref="CritterModel"/> seeks.</param>
        public CritterModel(ModelID id, string name, string description, string comment,
                            IEnumerable<ModelTag> tags = null, ModelID? nativeBiomeID = null,
                            ModelID? primaryBehaviorID = null, IEnumerable<ModelID> avoidsIDs = null,
                            IEnumerable<ModelID> seeksIDs = null)
            : base(All.CritterIDs, id, name, description, comment, tags,
                   nativeBiomeID, primaryBehaviorID, avoidsIDs, seeksIDs)
            => Precondition.IsInRange(id, All.CritterIDs, nameof(id));
        #endregion

        #region IMutableCritterModel Implementation
        // Currently, everything needed for editing CritterModels is provided by IBeingModelEdit.
        #endregion
    }
}
