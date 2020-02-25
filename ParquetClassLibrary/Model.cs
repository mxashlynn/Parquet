using System;
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary
{
    /// <summary>
    /// Models a unique, identifiable type of game object.
    /// </summary>
    /// <remarks>
    /// All <see cref="Model"/>s are identified with a <see cref="ModelID"/>,
    /// and are considered equal if and only if their respective ModelIDs are equal.<para />
    /// <para />
    /// Model is intended to represent the parts of a game object that do not change
    /// from one instance to another.  In this sense, it can be thought of as
    /// analogous to a C# <see langword="class"/>.<para />
    /// <para />
    /// Individual game objects are represented and referenced as instances of <see cref="ModelID"/>
    /// within <see cref="ModelCollection{T}"/>s in other classes.  Like a class instance,
    /// the Model for a given ModelID is looked up from a singular definition,
    /// in this case via <see cref="ModelCollection{T}.Get{T}(ModelID)"/>.<para />
    /// <para />
    /// Collections of the definitions used during play are contained in <see cref="All"/>.<para />
    /// <para />
    /// If individual game objects must have mutable state then a separate partner class,
    /// such as <see cref="Parquets.ParquetStatus"/> or <see cref="Beings.BeingStatus"/>,
    /// represents that state.<para />
    /// <para />
    /// Model could be considered the fundamental class of the entire Parquet library.
    /// </remarks>
    /// <seealso cref="ModelTag"/>
    public abstract class Model : IModelEdit, IEquatable<Model>
    {
        #region Characteristics
        /// <summary>Game-wide unique identifier.</summary>
        [Index(0)]
        public ModelID ID { get; }

        /// <summary>Player-facing name.</summary>
        [Index(1)]
        public string Name { get; private set; }

        /// <summary>Player-facing name.</summary>
        [Ignore]
        string IModelEdit.Name { get => Name; set => Name = value; }

        /// <summary>Player-facing description.</summary>
        [Index(2)]
        public string Description { get; private set; }

        /// <summary>Player-facing description.</summary>
        [Ignore]
        string IModelEdit.Description { get => Description; set => Description = value; }

        /// <summary>Optional comment.</summary>
        /// <remarks>Could be used for designer notes or to implement an in-game dialogue with or on the <see cref="Model"/>.</remarks>
        [Index(3)]
        public string Comment { get; private set; }

        /// <summary>Optional comment.</summary>
        [Ignore]
        string IModelEdit.Comment { get => Comment; set => Comment = value; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of concrete implementations of the <see cref="Model"/> class.
        /// </summary>
        /// <param name="inBounds">The bounds within which the derived type's <see cref="ModelID"/> is defined.</param>
        /// <param name="inID">Unique identifier for the <see cref="Model"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="Model"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="Model"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="Model"/>.</param>
        protected Model(Range<ModelID> inBounds, ModelID inID, string inName, string inDescription, string inComment)
        {
            Precondition.IsInRange(inID, inBounds, nameof(inID));
            Precondition.IsNotNullOrEmpty(inName, nameof(inName));

            ID = inID;
            Name = inName;
            Description = inDescription ?? "";
            Comment = inComment ?? "";
        }
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
        /// <param name="inModel">The <see cref="Model"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(Model inModel)
            => inModel?.ID == ID;

        /// <summary>
        /// Determines whether the specified <see langword="object"/> is equal to the current <see cref="Model"/>.
        /// </summary>
        /// <param name="obj">The <see langword="object"/> to compare with the current <see cref="Model"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is Model model
            && Equals(model);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Model"/> is equal to another specified instance of <see cref="Model"/>.
        /// </summary>
        /// <param name="inModel1">The first <see cref="Model"/> to compare.</param>
        /// <param name="inModel2">The second <see cref="Model"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Model inModel1, Model inModel2)
           => inModel1?.Equals(inModel2) ?? inModel2?.Equals(inModel1) ?? true;

        /// <summary>
        /// Determines whether a specified instance of <see cref="Model"/> is not equal to another specified instance of <see cref="Model"/>.
        /// </summary>
        /// <param name="inModel1">The first <see cref="Model"/> to compare.</param>
        /// <param name="inModel2">The second <see cref="Model"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Model inModel1, Model inModel2)
           => !(inModel1 == inModel2);
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see langword="string"/> that represents the current <see cref="Model"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => Name;
        #endregion
    }
}