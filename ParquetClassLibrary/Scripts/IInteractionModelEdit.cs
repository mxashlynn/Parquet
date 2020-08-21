using System.Collections.Generic;

namespace ParquetClassLibrary.Scripts
{
    /// <summary>
    /// Facilitates editing of a <see cref="InteractionModel"/> from design tools while maintaining a read-only face for use during play.
    /// </summary>
    /// <remarks>
    /// By design, children of <see cref="InteractionModel"/> should never themselves use <see cref="IInteractionModelEdit"/>.
    /// IInteractionModelEdit is for use only by external types that require read/write access to model properties.
    /// </remarks>
    public interface IInteractionModelEdit : IModelEdit
    {
        /// <summary>
        /// Describes the criteria for begining this interaction.
        /// </summary>
        public IList<ModelID> Prerequisites { get; }

        /// <summary>
        /// Everything this interaction entails.
        /// </summary>
        public IList<ModelID> Steps { get; }

        /// <summary>
        /// Describes the results of finishing this interaction.
        /// </summary>
        public IList<ModelID> Outcomes { get; }
    }
}
