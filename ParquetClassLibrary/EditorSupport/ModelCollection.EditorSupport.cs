#if DESIGN
using System;
using System.Globalization;
using ParquetClassLibrary.EditorSupport;
using ParquetClassLibrary.Properties;

namespace ParquetClassLibrary
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
        Justification = "By design, ModelCollection should never use IMutableModelCollection to alter its own collection.  IMutableModelCollection is for external types that require read/write access.")]
    public partial class ModelCollection<TModel> : IMutableModelCollection<TModel>
        where TModel : Model
    {
        #region IModelCollectionEdit Implementation
        /// <summary>
        /// Adds the given <typeparamref name="TModel"/> to the collection.
        /// </summary>
        /// <param name="inModel">A valid, defined <typeparamref name="TModel"/> contianed in this collection.</param>
        void IMutableModelCollection<TModel>.Add(TModel inModel)
        {
            Precondition.IsNotNull(inModel);
            Precondition.IsNotNone(inModel.ID);
            Precondition.IsInRange(inModel.ID, Bounds, nameof(inModel.ID));

            EditableModels[inModel.ID] = !Contains(inModel.ID)
                ? inModel
                : throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotAdd,
                                                            typeof(TModel).Name, inModel.Name));
        }

        /// <summary>
        /// Removes the given <typeparamref name="TModel"/> from the collection.
        /// </summary>
        /// <param name="inModel">A valid, defined <typeparamref name="TModel"/> contianed in this collection.</param>
        void IMutableModelCollection<TModel>.Remove(TModel inModel)
            => ((IMutableModelCollection<TModel>)this).Remove(inModel?.ID
                ?? throw new ArgumentNullException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorMustNotBeNull, nameof(inModel))));


        /// <summary>
        /// Removes the <typeparamref name="TModel"/> associated with the given <see cref="ModelID"/> from the collection.
        /// </summary>
        /// <param name="inID">The ID for a valid, defined <typeparamref name="TModel"/> contianed in this collection.</param>
        void IMutableModelCollection<TModel>.Remove(ModelID inID)
        {
            Precondition.IsNotNone(inID);
            Precondition.IsInRange(inID, Bounds, nameof(inID));

            if (!EditableModels.Remove(inID))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotRemove,
                                                          typeof(TModel).Name, inID));
            }
        }

        /// <summary>
        /// Empties the entire collection.
        /// </summary>
        void IMutableModelCollection<TModel>.Clear()
            => EditableModels.Clear();


        /// <summary>
        /// Replaces a contained <typeparamref name="TModel"/> with the given <typeparamref name="TModel"/> whose
        /// <see cref="ModelID"/> is identicle to that of the model being replaced.
        /// </summary>
        /// <param name="inModel">A valid, defined <typeparamref name="TModel"/> contianed in this collection.</param>
        /// <remarks>Facilitates updating elements from design tools while maintaining a read-only facade during play.</remarks>
        void IMutableModelCollection<TModel>.Replace(TModel inModel)
        {
            Precondition.IsNotNull(inModel);
            Precondition.IsNotNone(inModel.ID);
            Precondition.IsInRange(inModel.ID, Bounds, nameof(inModel.ID));

            EditableModels[inModel.ID] = Contains(inModel.ID)
                ? inModel
                : throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotReplace,
                                                            typeof(TModel).Name, inModel.Name));
        }
        #endregion
    }
}
#endif
