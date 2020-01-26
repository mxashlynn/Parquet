using System;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary
{
    /// <summary>
    /// Models a unique, identifiable type of game object.
    /// </summary>
    /// <remarks>
    /// All <see cref="EntityModel"/>s are identified with an <see cref="EntityID"/>,
    /// and are considered equal if and only if their respective EntityIDs are equal.<para />
    /// <para />
    /// EntityModel is intended to model the parts of a game object that do not change
    /// from one instance to another.  In this sense, it can be thought of as
    /// analogous to a C# <see langword="class"/>.<para />
    /// <para />
    /// Individual game objects are represented and referenced as instances of <see cref="EntityID"/>
    /// within <see cref="ModelCollection{T}"/>s in other classes.  Like a class instance,
    /// the EntityModel for a given EntityID is looked up from a singular definition,
    /// in this case via <see cref="ModelCollection{T}.Get{T}(EntityID)"/>.<para />
    /// <para />
    /// Collections of the definitions used during play are contained in <see cref="All"/>.<para />
    /// <para />
    /// If individual game objects must have mutable state then a separate partner class,
    /// such as <see cref="Parquets.ParquetStatus"/> or <see cref="Beings.BeingStatus"/>,
    /// models that state.<para />
    /// <para />
    /// EntityModel could be considered the fundamental class of the entire Parquet library.
    /// </remarks>
    /// <seealso cref="EntityTag"/>
    public abstract class EntityModel : IEntityModelEdit, IEquatable<EntityModel>, ITypeConverter
    {
        #region Characteristics
        /// <summary>Game-wide unique identifier.</summary>
        public EntityID ID { get; }

        /// <summary>Player-facing name.</summary>
        public string Name { get; private set; }

        /// <summary>Player-facing name.</summary>
        string IEntityModelEdit.Name { get => Name; set => Name = value; }

        /// <summary>Player-facing description.</summary>
        public string Description { get; private set; }

        /// <summary>Player-facing description.</summary>
        string IEntityModelEdit.Description { get => Description; set => Description = value; }

        /// <summary>Optional comment.</summary>
        /// <remarks>Could be used for designer notes or to implement an in-game dialogue with or on the <see cref="EntityModel"/>.
        /// </remarks>
        public string Comment { get; private set; }
        string IEntityModelEdit.Comment { get => Comment; set => Comment = value; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of concrete implementations of the <see cref="EntityModel"/> class.
        /// </summary>
        /// <param name="inBounds">The bounds within which the derived type's <see cref="EntityID"/> is defined.</param>
        /// <param name="inID">Unique identifier for the <see cref="EntityModel"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="EntityModel"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="EntityModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="EntityModel"/>.</param>
        protected EntityModel(Range<EntityID> inBounds, EntityID inID, string inName, string inDescription, string inComment)
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
        /// Serves as a hash function for an <see cref="EntityModel"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public override int GetHashCode()
            => ID.GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="EntityModel"/> is equal to the current <see cref="EntityModel"/>.
        /// </summary>
        /// <param name="inModel">The <see cref="EntityModel"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(EntityModel inModel)
            => null != inModel && ID == inModel.ID;

        /// <summary>
        /// Determines whether the specified <see langword="object"/> is equal to the current <see cref="EntityModel"/>.
        /// </summary>
        /// <param name="obj">The <see langword="object"/> to compare with the current <see cref="EntityModel"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is EntityModel entity && Equals(entity);

        /// <summary>
        /// Determines whether a specified instance of <see cref="EntityModel"/> is equal to another specified instance of <see cref="EntityModel"/>.
        /// </summary>
        /// <param name="inModel1">The first <see cref="EntityModel"/> to compare.</param>
        /// <param name="inModel2">The second <see cref="EntityModel"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(EntityModel inModel1, EntityModel inModel2)
            => (inModel1 is null && inModel2 is null)
            || (!(inModel1 is null) && !(inModel2 is null) && inModel1.ID == inModel2.ID);

        /// <summary>
        /// Determines whether a specified instance of <see cref="EntityModel"/> is not equal to another specified instance of <see cref="EntityModel"/>.
        /// </summary>
        /// <param name="inModel1">The first <see cref="EntityModel"/> to compare.</param>
        /// <param name="inModel2">The second <see cref="EntityModel"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(EntityModel inModel1, EntityModel inModel2)
            => (!(inModel1 is null) && !(inModel2 is null) && inModel1.ID != inModel2.ID)
            || (!(inModel1 is null) && inModel2 is null)
            || (inModel1 is null && !(inModel2 is null));
        #endregion

        #region ITypeConverter Implementation
        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="value">The instance to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
            => throw new InvalidOperationException($"No conversion exists on abstract {nameof(EntityModel)} class.");

        /// <summary>
        /// Converts the given <see cref="string"/> to an <see cref="object"/> as deserialization.
        /// </summary>
        /// <param name="text">The text to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
            => throw new InvalidOperationException($"No conversion exists on abstract {nameof(EntityModel)} class.");
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see langword="string"/> that represents the current <see cref="EntityModel"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => Name;
        #endregion
    }
}
