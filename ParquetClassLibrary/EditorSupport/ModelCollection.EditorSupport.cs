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
        #region IModelCollectionEdit Implementation
        /// <summary>The number of <see cref="TModel"/>s in the <see cref="ModelCollection{TModel}"/>.</summary>
        int ICollection<TModel>.Count => Count;

        /// <summary><c>true</c> if the <see cref="ModelCollection{TModel}"/> is read-only; otherwise, <c>false</c>.</summary>
        bool ICollection<TModel>.IsReadOnly => LibraryState.IsPlayMode;

        /// <summary>
        /// Adds the given <typeparamref name="TModel"/> to the collection.
        /// </summary>
        /// <param name="inModel">A valid, defined <typeparamref name="TModel"/> contained in this collection.</param>
        void ICollection<TModel>.Add(TModel inModel)
        {
            if (LibraryState.IsPlayMode)
            {
                Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.WarningUnavailableDuringPlay,
                                                           $"{nameof(IMutableModelCollection<TModel>.Add)}"));
                return;
            }

            Precondition.IsNotNull(inModel);
            Precondition.IsNotNone(inModel.ID);
            Precondition.IsInRange(inModel.ID, Bounds, nameof(inModel.ID));

            if (!Contains(inModel.ID))
            {
                EditableModels[inModel.ID] = inModel;
            }
            else
            {
                Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotAdd,
                                                           typeof(TModel).Name, inModel.Name));
            }
        }

        /// <summary>
        /// Determines whether the <see cref="ModelCollection{TModel}"/> contains the specified <see cref="TModel"/>.
        /// </summary>
        /// <param name="inModel">The <see cref="TModel"/> to find.</param>
        /// <returns><c>true</c> if the <see cref="TModel"/> was found; <c>false</c> otherwise.</returns>
        bool ICollection<TModel>.Contains(TModel item) => Contains(item);

        /// <summary>
        /// Copies the elements of the <see cref="ModelCollection{TModel}"/> to an <see cref="Array"/>, starting at the given index.
        /// </summary>
        /// <param name="inArray">The array to copy to.</param>
        /// <param name="inArrayIndex">The index at which to begin copying.</param>
        void ICollection<TModel>.CopyTo(TModel[] inArray, int inArrayIndex)
        {
            if (LibraryState.IsPlayMode)
            {
                Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.WarningUnavailableDuringPlay,
                                                           $"{nameof(IMutableModelCollection<TModel>.CopyTo)}"));
                return;
            }

            EditableModels.Values.CopyTo(inArray, inArrayIndex);
        }

        /// <summary>
        /// Removes the given <typeparamref name="TModel"/> from the collection.
        /// </summary>
        /// <param name="inModel">A valid, defined <typeparamref name="TModel"/> contained in this collection.</param>
        bool ICollection<TModel>.Remove(TModel inModel)
        {
            if (LibraryState.IsPlayMode)
            {
                Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.WarningUnavailableDuringPlay,
                                                           $"{nameof(IMutableModelCollection<TModel>.Remove)}"));
                return false;
            }

            Precondition.IsNotNull(inModel);

            return ((IMutableModelCollection<TModel>)this).Remove(inModel?.ID ?? ModelID.None);
        }

        /// <summary>
        /// Removes the <typeparamref name="TModel"/> associated with the given <see cref="ModelID"/> from the collection.
        /// </summary>
        /// <param name="inID">The ID for a valid, defined <typeparamref name="TModel"/> contained in this collection.</param>
        bool IMutableModelCollection<TModel>.Remove(ModelID inID)
        {
            Precondition.IsNotNone(inID);
            Precondition.IsInRange(inID, Bounds, nameof(inID));

            return LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(IMutableModelCollection<TModel>.Remove), false)
                : inID != ModelID.None
                       && EditableModels.Remove(inID);
        }

        /// <summary>
        /// Empties the entire collection.
        /// </summary>
        void ICollection<TModel>.Clear()
        {
            if (LibraryState.IsPlayMode)
            {
                Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.WarningUnavailableDuringPlay,
                                                           $"{nameof(IMutableModelCollection<TModel>.Clear)}"));
                return;
            }

            EditableModels.Clear();
        }

        /// <summary>
        /// Replaces a contained <typeparamref name="TModel"/> with the given <typeparamref name="TModel"/> whose
        /// <see cref="ModelID"/> is identical to that of the model being replaced.
        /// </summary>
        /// <param name="inModel">A valid, defined <typeparamref name="TModel"/> contained in this collection.</param>
        /// <remarks>Facilitates updating elements from design tools while maintaining a read-only facade during play.</remarks>
        void IMutableModelCollection<TModel>.Replace(TModel inModel)
        {
            if (LibraryState.IsPlayMode)
            {
                Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.WarningUnavailableDuringPlay,
                                                           $"{nameof(IMutableModelCollection<TModel>.Replace)}"));
                return;
            }

            Precondition.IsNotNull(inModel);
            Precondition.IsNotNone(inModel.ID);
            Precondition.IsInRange(inModel.ID, Bounds, nameof(inModel.ID));

            if (Contains(inModel.ID))
            {
                Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotReplace,
                                                           typeof(TModel).Name, inModel.Name));
            }
            else
            {
                EditableModels[inModel.ID] = inModel;
            }
        }
        #endregion
    }
}
