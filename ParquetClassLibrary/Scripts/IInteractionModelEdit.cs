using System.Collections.Generic;

namespace ParquetClassLibrary.Scripts
{
    /// <summary>
    /// Facilitates editing of a <see cref="ScriptModel"/> from design tools while maintaining a read-only face for use during play.
    /// </summary>
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
