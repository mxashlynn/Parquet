using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CsvHelper.Configuration.Attributes;

namespace Parquet
{
    /// <summary>
    /// Models a unique, identifiable category of game object.
    /// </summary>
    /// <remarks>
    /// Model could be considered the fundamental class of the entire Parquet library.
    /// <para />
    /// <see cref="Model"/>s represent the parts of a game object that do not change from
    /// one instance to another or from one moment to the next.  For this reason, Models
    /// are designed to be immutable during play but mutable during game editing.
    /// <para />
    /// Most types derived from Model have a companion type derived from <see cref="Status{T}"/>.
    /// These companion classes represent the parts of a game object that do vary by instance
    /// or with time, and so always have mutable state.
    /// <para />
    /// All Models are identified by a <see cref="ModelID"/>, and are considered equal
    /// if and only if their respective ModelIDs are equal.
    /// <para />
    /// Individual entities in-game are implemented as instances of ModelIDs
    /// within <see cref="ModelIDGrid"/>s.
    /// <para />
    /// Every Model definition used by a given Parquet game is contained in one of
    /// several <see cref="ModelCollection{T}"/>s within global repository <see cref="All"/>.
    /// </remarks>
    /// <seealso cref="ModelTag"/>
    /// <seealso cref="LibraryState.IsPlayMode"/>
    [SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
                     Justification = "By design, Model should never itself use IMutableModel the interface to access its own members.  The IMutableModel family of interfaces is for external types that require read/write access.")]
    public abstract class Model : IEquatable<Model>, IMutableModel
    {
        #region Characteristics
        /// <summary>Game-wide unique identifier.</summary>
        [Index(0)]
        public ModelID ID { get; private set; }

        /// <summary>Player-facing name.</summary>
        [Index(1)]
        public string Name { get; private set; }

        /// <summary>Player-facing description.</summary>
        [Index(2)]
        public string Description { get; private set; }

        /// <summary>Optional comment.</summary>
        /// <remarks>Could be used for designer notes or to implement an in-game dialogue with or on the <see cref="Model"/>.</remarks>
        [Index(3)]
        public string Comment { get; private set; }

        /// <summary>Any additional functionality this model has, e.g. contributing to a <see cref="Crafts.CraftingRecipe"/>.</summary>
        [Index(4)]
        public IReadOnlyList<ModelTag> Tags { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of concrete implementations of the <see cref="Model"/> class.
        /// </summary>
        /// <param name="bounds">The bounds within which the derived type's <see cref="ModelID"/> is defined.</param>
        /// <param name="id">Unique identifier for the <see cref="Model"/>.  Cannot be null.</param>
        /// <param name="name">Player-friendly name of the <see cref="Model"/>.  Cannot be null or empty.</param>
        /// <param name="description">Player-friendly description of the <see cref="Model"/>.</param>
        /// <param name="comment">Comment of, on, or by the <see cref="Model"/>.</param>
        /// <param name="tags">Any additional functionality this <see cref="Model"/> has, e.g. contributing to a <see cref="Biomes.BiomeRecipe"/>.</param>
        protected Model(Range<ModelID> bounds, ModelID id, string name, string description, string comment, IEnumerable<ModelTag> tags)
        {
            Precondition.IsInRange(id, bounds, nameof(id));
            Precondition.IsNotNullOrEmpty(name, nameof(name));

            var nonNullTags = (tags ?? Enumerable.Empty<ModelTag>());

            ID = id;
            Name = name;
            Description = description ?? "";
            Comment = comment ?? "";
            Tags = nonNullTags.ToList();
        }
        #endregion

        #region IMutableModel Implementation
        /// <summary>Game-wide unique identifier.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IMutableModel is for external types that require read/write access.
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
        /// IMutableModel is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        string IMutableModel.Name
        {
            get => Name;
            set
            {
                Name = LibraryState.IsPlayMode
                    ? Logger.DefaultWithImmutableInPlayLog(nameof(Name), Name)
                    : value;
                OnVisibleDataChanged();
            }
        }

        /// <summary>Player-facing description.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IMutableModel is for external types that require read/write access.
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
        /// IMutableModel is for external types that require read/write access.
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
        /// IMutableModel is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        ICollection<ModelTag> IMutableModel.Tags
            => LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(Tags), new Collection<ModelTag>())
                : (ICollection<ModelTag>)Tags;

        /// <summary>
        /// Raised when an external view onto associated data should be updated.
        /// </summary>
        public event DataChangedEventHandler VisibleDataChanged;

        /// <summary>
        /// Indicates an external view onto associated data should be updated.
        /// </summary>
        protected virtual bool OnVisibleDataChanged()
            => VisibleDataChanged?.Invoke(this, EventArgs.Empty) ?? true;
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="Model"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public override int GetHashCode()
            => ID.GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="Model"/> is equal to the current <see cref="Model"/>.
        /// </summary>
        /// <param name="other">The <see cref="Model"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(Model other)
            => other?.ID == ID;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="Model"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="Model"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is Model model
            && Equals(model);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Model"/> is equal to another specified instance of <see cref="Model"/>.
        /// </summary>
        /// <param name="model1">The first <see cref="Model"/> to compare.</param>
        /// <param name="model2">The second <see cref="Model"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Model model1, Model model2)
            => model1?.Equals(model2) ?? model2?.Equals(model1) ?? true;

        /// <summary>
        /// Determines whether a specified instance of <see cref="Model"/> is not equal to another specified instance of <see cref="Model"/>.
        /// </summary>
        /// <param name="model1">The first <see cref="Model"/> to compare.</param>
        /// <param name="model2">The second <see cref="Model"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Model model1, Model model2)
            => !(model1 == model2);
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="Model"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => Name;

        /// <summary>
        /// Returns a collection of all <see cref="ModelTag"/>s the <see cref="Model"/> has applied to it. Classes inheriting from <see cref="Model"/> that include <see cref="ModelTag"/> should override accordingly.
        /// </summary>
        /// <returns>List of all <see cref="ModelTag"/>s.</returns>
        public virtual IEnumerable<ModelTag> GetAllTags()
            => Tags;

        /// <summary>
        /// A tag assigned to this <see cref="Model"/> that begins with the given attribute prefix,
        /// or <see cref="ModelTag.None"/> if no such tag has been assigned.
        /// </summary>
        /// <param name="prefix">
        /// A <see cref="ModelTag"/> substring indicating the sought attribute.
        /// No particular format is required for the prefix:suffix pair,
        /// although no library-wide <see cref="Delimiters"/> may be used.
        /// </param>
        /// <returns>
        /// The attribute sought including the given prefix,
        /// or <see cref="ModelTag.None"/> if no such tag has been assigned.</returns>
        /// <remarks>
        /// This is a convenience for client code and not used by the library itself.
        /// </remarks>
        public ModelTag AttributeTag(ModelTag prefix)
            => Tags.FirstOrDefault(tag => tag.StartsWithOrdinalIgnoreCase(prefix)) ?? "";
        #endregion
    }
}
