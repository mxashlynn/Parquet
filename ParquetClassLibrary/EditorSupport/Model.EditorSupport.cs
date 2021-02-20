using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using CsvHelper.Configuration.Attributes;
using Parquet.EditorSupport;

namespace Parquet
{
    [SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
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
        ModelID IMutableModel.ID
        {
            get => ID;
            set => ID = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(ID), ID)
                : value;
        }

        /// <summary>Player-facing name.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        string IMutableModel.Name
        {
            get => Name;
            set => Name = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(Name), Name)
                : value;
        }

        /// <summary>Player-facing description.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        string IMutableModel.Description
        {
            get => Description;
            set => Description = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(Description), Description)
                : value;
        }

        /// <summary>Optional comment.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        string IMutableModel.Comment
        {
            get => Comment;
            set => Comment = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(Comment), Comment)
                : value;
        }

        /// <summary>Any additional functionality this item has, e.g. contributing to a <see cref="Crafts.CraftingRecipe"/>.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        ICollection<ModelTag> IMutableModel.Tags
            => LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(Tags), new Collection<ModelTag>())
                : (ICollection<ModelTag>) Tags;

        #endregion
    }
}
