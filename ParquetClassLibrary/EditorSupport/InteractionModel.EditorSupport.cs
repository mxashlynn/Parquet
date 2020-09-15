#if DESIGN
using System.Collections.Generic;
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.EditorSupport;

namespace ParquetClassLibrary.Scripts
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
        Justification = "By design, subtypes of Model should never themselves use IModelEdit or derived interfaces to access their own members.  The IModelEdit family of interfaces is for external types that require read/write access.")]
    public partial class InteractionModel : IInteractionModelEdit
    {
        #region IInteractionModelEdit Implementation
        /// <summary>
        /// Describes the criteria for begining this interaction.
        /// </summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        IList<ModelID> IInteractionModelEdit.PrerequisitesIDs => (IList<ModelID>)PrerequisitesIDs;

        /// <summary>
        /// Everything this interaction entails.
        /// </summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        IList<ModelID> IInteractionModelEdit.StepsIDs => (IList<ModelID>)StepsIDs;

        /// <summary>
        /// Describes the results of finishing this interaction.
        /// </summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        IList<ModelID> IInteractionModelEdit.OutcomesIDs => (IList<ModelID>)OutcomesIDs;
        #endregion
    }
}
#endif
