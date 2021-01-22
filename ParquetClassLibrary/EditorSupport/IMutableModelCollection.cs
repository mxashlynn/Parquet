#if DESIGN
using System.Collections.Generic;

namespace ParquetClassLibrary.EditorSupport
{
    /// <summary>
    /// Facilitates updating elements of a <see cref="ModelCollection"/> from design tools
    /// while maintaining a read-only facade during play.
    /// </summary>
    /// <typeparam name="TModel">The type collected, typically a concrete descendant of <see cref="Model"/>.</typeparam>
    public interface IMutableModelCollection<TModel> : ICollection<TModel>
        where TModel : Model
    {
        /// <summary>
        /// Removes the <typeparamref name="TModel"/> associated with the given <see cref="ModelID"/> from the collection.
        /// </summary>
        /// <param name="inID">The ID for a valid, defined <typeparamref name="TModel"/> contained in this collection.</param>
        public bool Remove(ModelID inID);

        /// <summary>
        /// Replaces a contained <typeparamref name="TModel"/> with the given <typeparamref name="TModel"/> whose
        /// <see cref="ModelID"/> is identical to that of the model being replaced.
        /// </summary>
        /// <param name="inModel">A valid, defined <typeparamref name="TModel"/> contained in this collection.</param>
        public void Replace(TModel inModel);
    }
}
#endif
