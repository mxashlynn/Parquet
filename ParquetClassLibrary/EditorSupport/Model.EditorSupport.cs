#if DESIGN
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.EditorSupport;

namespace ParquetClassLibrary
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
        Justification = "By design, Model should never itself use IMutableModel the interface to access its own members.  The IMutableModel family of interfaces is for external types that require read/write access.")]
    public abstract partial class Model : IMutableModel
    {
        #region IModelEdit Implementation
        /// <summary>Game-wide unique identifier.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read/write access.
        ///
        /// Be especially cautious editing this property.
        /// </remarks>
        [Ignore]
        ModelID IMutableModel.ID { get => ID; set => ID = value; }

        /// <summary>Player-facing name.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        string IMutableModel.Name { get => Name; set => Name = value; }

        /// <summary>Player-facing description.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        string IMutableModel.Description { get => Description; set => Description = value; }

        /// <summary>Optional comment.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        string IMutableModel.Comment { get => Comment; set => Comment = value; }
        #endregion
    }
}
#endif
