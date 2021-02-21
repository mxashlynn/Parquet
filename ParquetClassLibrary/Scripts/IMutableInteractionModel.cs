using System.Collections.Generic;

namespace Parquet.Scripts
{
    /// <summary>
    /// Facilitates editing of a <see cref="InteractionModel"/> from design tools while maintaining a read-only face for use during play.
    /// </summary>
    /// <remarks>
    /// By design, subtypes of <see cref="InteractionModel"/> should never themselves use <see cref="IMutableInteractionModel"/>.
    /// IInteractionModelEdit is for use only by external types that require read/write access to model properties.
    /// </remarks>
    public interface IMutableInteractionModel : IMutableModel
    {
        /// <summary>
        /// Describes the criteria for beginning this interaction.
        /// </summary>
        public ICollection<ModelID> PrerequisitesIDs { get; }

        /// <summary>
        /// Everything this interaction entails.
        /// </summary>
        public ICollection<ModelID> StepsIDs { get; }

        /// <summary>
        /// Describes the results of finishing this interaction.
        /// </summary>
        public ICollection<ModelID> OutcomesIDs { get; }
    }
}
