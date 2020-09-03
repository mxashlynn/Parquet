using System.Collections.Generic;
using ParquetClassLibrary.EditorSupport;

namespace ParquetClassLibrary.Beings
{
    /// <summary>
    /// Models the definition for a simple in-game actor, such as a friendly mob with limited interaction.
    /// </summary>
    public sealed class CritterModel : BeingModel, ICritterModelEdit
    {
        #region Initialization
        /// <summary>
        /// Initializes an empty <see cref="CritterModel"/> for use by design-time tools.
        /// </summary>
        public CritterModel()
            : this(ModelID.None, $"Default {nameof(CritterModel)}", "", "") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CritterModel"/> class.
        /// </summary>
        /// <param name="inID">
        /// Unique identifier for the <see cref="CritterModel"/>.  Cannot be null.
        /// Must be a <see cref="All.CritterIDs"/>.
        /// </param>
        /// <param name="inName">Player-friendly name of the <see cref="CritterModel"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="CritterModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="CritterModel"/>.</param>
        /// <param name="inNativeBiomeID">The <see cref="Biomes.BiomeRecipe"/> in which this <see cref="CritterModel"/> is most comfortable.</param>
        /// <param name="inPrimaryBehaviorID">The rules that govern how this <see cref="CritterModel"/> acts.  Cannot be null.</param>
        /// <param name="inAvoidsIDs">Any parquets this <see cref="CritterModel"/> avoids.</param>
        /// <param name="inSeeksIDs">Any parquets this <see cref="CritterModel"/> seeks.</param>
        public CritterModel(ModelID inID, string inName, string inDescription, string inComment,
                            ModelID? inNativeBiomeID = null, ModelID? inPrimaryBehaviorID = null,
                            IEnumerable<ModelID> inAvoidsIDs = null, IEnumerable<ModelID> inSeeksIDs = null)
            : base(All.CritterIDs, inID, inName, inDescription, inComment, inNativeBiomeID, inPrimaryBehaviorID, inAvoidsIDs, inSeeksIDs)
            => Precondition.IsInRange(inID, All.CritterIDs, nameof(inID));
        #endregion
    }
}
