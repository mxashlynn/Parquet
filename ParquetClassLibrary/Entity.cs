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
    /// Entity is intended to model the parts of a game object that do not change from one
    /// instance to another.  In this sense, it can be thought of as analagous to a <see cref="class"/>.
    /// Individual game objects are represented and referenced as instances of <see cref="EntityID"/>
    /// within collections in other classes.  Their definitions are found by submitting their EntityID
    /// to the appropriate <see cref="EntityCollection"/>.
    /// 
    /// If individual game objects must have mutable state then a separate wrapper class,
    /// such as <see cref="Sandbox.Parquets.ParquetStatus"/>, models that state.
    /// </remarks>
    /// <seealso cref="Sandbox.Parquets.ParquetStatus"/>
    /// <seealso cref="Items.Item"/>
    public abstract class Entity : IEquatable<Entity>
    {
        /// <summary>Game-wide unique identifier.</summary>
        [JsonProperty(PropertyName = "in_ID")]
        public EntityID ID { get; }

        /// <summary>Player-facing name.</summary>
        [JsonProperty(PropertyName = "in_name")]
        public string Name { get; }

        #region Initialization
        /// <summary>
        /// Initializes a new instance of concrete implementations of the <see cref="Entity"/> class.
        /// </summary>
        /// <param name="in_bounds">The bounds within which the derived type's EntityID is defined.</param>
        /// <param name="in_id">Unique identifier for the entity.  Cannot be null.</param>
        /// <param name="in_name">Player-friendly name of the entity.  Cannot be null or empty.</param>
        [JsonConstructor]
        protected Entity(Range<EntityID> in_bounds, EntityID in_id, string in_name)
        {
            if (!in_id.IsValidForRange(in_bounds))
            {
                throw new ArgumentOutOfRangeException(nameof(in_id));
            }
            if (string.IsNullOrEmpty(in_name))
            {
                throw new ArgumentNullException(nameof(in_name));
            }

            ID = in_id;
            Name = in_name;
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
        {
            return ID.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="Entity"/> is equal to the current <see cref="Entity"/>.
        /// </summary>
        /// <param name="in_entity">The <see cref="Entity"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(Entity in_entity)
        {
            return in_entity != null && ID == in_entity.ID;
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="Entity"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="Entity"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        // ReSharper disable once InconsistentNaming
        public override bool Equals(object obj)
        {
            var result = false;

            if (obj is Entity parquet)
            {
                result = Equals(parquet);
            }

            return result;
        }

        /// <summary>
        /// Determines whether a specified instance of <see cref="Entity"/> is equal to another specified instance of <see cref="Entity"/>.
        /// </summary>
        /// <param name="in_entity1">The first <see cref="Entity"/> to compare.</param>
        /// <param name="in_entity2">The second <see cref="Entity"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Entity in_entity1, Entity in_entity2)
        {
            if (ReferenceEquals(in_entity1, in_entity2)) return true;
            if (ReferenceEquals(in_entity1, null)) return false;
            if (ReferenceEquals(in_entity2, null)) return false;

            return in_entity1.ID == in_entity2.ID;
        }

        /// <summary>
        /// Determines whether a specified instance of <see cref="Entity"/> is not equal to another specified instance of <see cref="Entity"/>.
        /// </summary>
        /// <param name="in_entity1">The first <see cref="Entity"/> to compare.</param>
        /// <param name="in_entity2">The second <see cref="Entity"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Entity in_entity1, Entity in_entity2)
        {
            if (ReferenceEquals(in_entity1, in_entity2)) return false;
            if (ReferenceEquals(in_entity1, null)) return true;
            if (ReferenceEquals(in_entity2, null)) return true;

            return in_entity1.ID != in_entity2.ID;
        }
        #endregion

        #region Utility Methods
        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="Entity"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
        {
            return Name;
        }
        #endregion
    }
}
