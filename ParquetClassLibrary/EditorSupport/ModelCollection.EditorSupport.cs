#if DESIGN
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Parquet.EditorSupport;
using Parquet.Properties;

namespace Parquet
{
    [SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
                     Justification = "By design, ModelCollection should never use IMutableModelCollection to alter its own collection.  IMutableModelCollection is for external types that require read/write access.")]
    public partial class ModelCollection<TModel> : IMutableModelCollection<TModel>
        where TModel : Model
    {
        int ICollection<TModel>.Count => throw new NotImplementedException();

        bool ICollection<TModel>.IsReadOnly => throw new NotImplementedException();
        #region IModelCollectionEdit Implementation
        /// <summary>
        /// Adds the given <typeparamref name="TModel"/> to the collection.
        /// </summary>
        /// <param name="inModel">A valid, defined <typeparamref name="TModel"/> contained in this collection.</param>
        void ICollection<TModel>.Add(TModel inModel)
        {
            Precondition.IsNotNull(inModel);
            Precondition.IsNotNone(inModel.ID);
            Precondition.IsInRange(inModel.ID, Bounds, nameof(inModel.ID));

            EditableModels[inModel.ID] = !Contains(inModel.ID)
                ? inModel
                : throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotAdd,
                                                            typeof(TModel).Name, inModel.Name));
        }

        bool ICollection<TModel>.Contains(TModel item) => throw new NotImplementedException();
        void ICollection<TModel>.CopyTo(TModel[] array, int arrayIndex) => throw new NotImplementedException();

        /// <summary>
        /// Removes the given <typeparamref name="TModel"/> from the collection.
        /// </summary>
        /// <param name="inModel">A valid, defined <typeparamref name="TModel"/> contained in this collection.</param>
        bool ICollection<TModel>.Remove(TModel inModel)
            => ((IMutableModelCollection<TModel>)this).Remove(inModel?.ID ??
                                                                throw new ArgumentNullException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorMustNotBeNull,
                                                              nameof(inModel))));


        /// <summary>
        /// Removes the <typeparamref name="TModel"/> associated with the given <see cref="ModelID"/> from the collection.
        /// </summary>
        /// <param name="inID">The ID for a valid, defined <typeparamref name="TModel"/> contained in this collection.</param>
        bool IMutableModelCollection<TModel>.Remove(ModelID inID)
        {
            Precondition.IsNotNone(inID);
            Precondition.IsInRange(inID, Bounds, nameof(inID));

            return !EditableModels.Remove(inID)
                ? throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotRemove,
                                                          typeof(TModel).Name, inID))
                : true;
        }

        /// <summary>
        /// Empties the entire collection.
        /// </summary>
        void ICollection<TModel>.Clear()
            => EditableModels.Clear();

        /// <summary>
        /// Replaces a contained <typeparamref name="TModel"/> with the given <typeparamref name="TModel"/> whose
        /// <see cref="ModelID"/> is identical to that of the model being replaced.
        /// </summary>
        /// <param name="inModel">A valid, defined <typeparamref name="TModel"/> contained in this collection.</param>
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
