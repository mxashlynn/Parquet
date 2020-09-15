#if DESIGN
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.EditorSupport;

namespace ParquetClassLibrary
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
        Justification = "By design, Model should never itself use IModelEdit the interface to access its own members.  The IModelEdit family of interfaces is for external types that require read/write access.")]
    public abstract partial class Model : IModelEdit
    {
        #region IModelEdit Implementation
        /// <summary>Game-wide unique identifier.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require read/write access.
        ///
        /// Be especially cautious editing this property.
        /// </remarks>
        [Ignore]
        ModelID IModelEdit.ID { get => ID; set => ID = value; }

        /// <summary>Player-facing name.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        string IModelEdit.Name { get => Name; set => Name = value; }

        /// <summary>Player-facing description.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        string IModelEdit.Description { get => Description; set => Description = value; }

        /// <summary>Optional comment.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        string IModelEdit.Comment { get => Comment; set => Comment = value; }
        #endregion
    }
}
#endif
