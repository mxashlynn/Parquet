using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using CsvHelper.Configuration.Attributes;
using Parquet.EditorSupport;

namespace Parquet.Scripts
{
    [SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
                     Justification = "By design, subtypes of Model should never themselves use IMutableModel or derived interfaces to access their own members.  The IMutableModel family of interfaces is for external types that require read/write access.")]
    public partial class InteractionModel : IMutableInteractionModel
    {
        #region IInteractionModelEdit Implementation
        /// <summary>
        /// Describes the criteria for beginning this interaction.
        /// </summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ICollection<ModelID> IMutableInteractionModel.PrerequisitesIDs
            => LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(PrerequisitesIDs), new Collection<ModelID>())
                : (ICollection<ModelID>)PrerequisitesIDs;

        /// <summary>
        /// Everything this interaction entails.
        /// </summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ICollection<ModelID> IMutableInteractionModel.StepsIDs
            => LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(StepsIDs), new Collection<ModelID>())
                : (ICollection<ModelID>)StepsIDs;

        /// <summary>
        /// Describes the results of finishing this interaction.
        /// </summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ICollection<ModelID> IMutableInteractionModel.OutcomesIDs
            => LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(OutcomesIDs), new Collection<ModelID>())
                : (ICollection<ModelID>)OutcomesIDs;
        #endregion
    }
}
