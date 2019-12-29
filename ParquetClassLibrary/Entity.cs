using System;
using Newtonsoft.Json;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary
{
    /// <summary>
    /// Models a unique, identifiable type of game object.
    /// </summary>
    /// <remarks>
    /// All <see cref="Entity"/>s are identified with an <see cref="EntityID"/>,
    /// and are considered equal if and only if their respective EntityIDs are equal.
    /// 
    /// Entity is intended to model the parts of a game object that do not change
    /// from one instance to another.  In this sense, it can be thought of as
    /// analogous to a C# <see langword="class"/>.
    /// 
    /// Individual game objects are represented and referenced as instances of <see cref="EntityID"/>
    /// within <see cref="EntityCollection{T}"/>s in other classes.  Like a class instance,
    /// the Entity definition for a given EntityID is looked up from a singular definition,
    /// in this case via <see cref="EntityCollection{T}.Get{T}(EntityID)"/>.
    ///
    /// Collections of the definitions used during play are contained in <see cref="All"/>.
    /// 
    /// If individual game objects must have mutable state then a separate partner class,
    /// such as <see cref="Parquets.ParquetStatus"/> or <see cref="Beings.BeingStatus"/>,
    /// models that state.
    ///
    /// Entity could be considered the fundamental class of the entire Parquet library.
    /// </remarks>
    /// <seealso cref="EntityTag"/>
    public abstract class Entity : IEquatable<Entity>
    {
        /// <summary>Game-wide unique identifier.</summary>
        [JsonProperty(PropertyName = "inID")]
        public EntityID ID { get; }

        /// <summary>Player-facing name.</summary>
        [JsonProperty(PropertyName = "inName")]
        public string Name { get; }

        /// <summary>Player-facing description.</summary>
        [JsonProperty(PropertyName = "inDescription")]
        public string Description { get; }

        /// <summary>Optional comment.</summary>
        /// <remarks>
        /// Could be used for designer notes or to implement an in-game dialogue
        /// with or on the <see cref="Entity"/>.
        /// </remarks>
        [JsonProperty(PropertyName = "inComment")]
        public string Comment { get; }

        #region Initialization
        /// <summary>
        /// Initializes a new instance of concrete implementations of the <see cref="Entity"/> class.
        /// </summary>
        /// <param name="inBounds">The bounds within which the derived type's <see cref="EntityID"/> is defined.</param>
        /// <param name="inID">Unique identifier for the <see cref="Entity"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="Entity"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="Entity"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="Entity"/>.</param>
        [JsonConstructor]
        protected Entity(Range<EntityID> inBounds, EntityID inID, string inName, string inDescription, string inComment)
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
        /// Serves as a hash function for an <see cref="Entity"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public override int GetHashCode()
            => ID.GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="Entity"/> is equal to the current <see cref="Entity"/>.
        /// </summary>
        /// <param name="inEntity">The <see cref="Entity"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(Entity inEntity)
            => null != inEntity && ID == inEntity.ID;

        /// <summary>
        /// Determines whether the specified <see langword="object"/> is equal to the current <see cref="Entity"/>.
        /// </summary>
        /// <param name="obj">The <see langword="object"/> to compare with the current <see cref="Entity"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is Entity entity && Equals(entity);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Entity"/> is equal to another specified instance of <see cref="Entity"/>.
        /// </summary>
        /// <param name="inEntity1">The first <see cref="Entity"/> to compare.</param>
        /// <param name="inEntity2">The second <see cref="Entity"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Entity inEntity1, Entity inEntity2)
            => (inEntity1 is null && inEntity2 is null)
            || (!(inEntity1 is null) && !(inEntity2 is null) && inEntity1.ID == inEntity2.ID);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Entity"/> is not equal to another specified instance of <see cref="Entity"/>.
        /// </summary>
        /// <param name="inEntity1">The first <see cref="Entity"/> to compare.</param>
        /// <param name="inEntity2">The second <see cref="Entity"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Entity inEntity1, Entity inEntity2)
            => (!(inEntity1 is null) && !(inEntity2 is null) && inEntity1.ID != inEntity2.ID)
            || (!(inEntity1 is null) && inEntity2 is null)
            || (inEntity1 is null && !(inEntity2 is null));
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see langword="string"/> that represents the current <see cref="Entity"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => Name;
        #endregion
    }
}
