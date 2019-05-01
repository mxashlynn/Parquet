using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary
{
    /// <summary>
    /// Stores an <see cref="Entity"/> collection.
    /// Provides bounds-checking and type-checking against <typeparamref name="ParentType"/>.
    /// </summary>
    /// <remarks>
    /// This generic version is intended to support <see cref="All.Parquets"/> allowing
    /// the collection to store all parquet types but return only the requested subtype.
    /// </remarks>
    public class EntityCollection<ParentType> where ParentType : Entity
    {
        /// <summary>The internal collection mechanism.</summary>
        private Dictionary<EntityID, Entity> Entities { get; set; }

        private List<Range<EntityID>> Bounds { get; }

        /// <summary>The number of <see cref="Entity"/>s in the <see cref="EntityCollection"/>.</summary>
        public int Count => Entities.Count;

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityCollection"/> class.
        /// </summary>
        /// <param name="in_bounds">The bounds within which the collected <see cref="EntityID"/>s are defined.</param>
        public EntityCollection(List<Range<EntityID>> in_bounds)
        {
            if (!in_bounds.IsValid())
            {
                throw new ArgumentException($"Invalid bounds given: {nameof(in_bounds)}");
            }

            Bounds = in_bounds;
            Entities = new Dictionary<EntityID, Entity> { { EntityID.None, null } };
        }
        #endregion

        #region Collection Access
        /// <summary>
        /// Adds the given <see cref="Entity"/> to the collection.
        /// </summary>
        /// <param name="in_entity">The <see cref="Entity"/> being added.</param>
        /// <returns><c>true</c> if the <see cref="Entity"/> was added successfully; <c>false</c> otherwise.</returns>
        public bool Add(Entity in_entity)
        {
            Precondition.IsNotNull(in_entity, nameof(in_entity));
            Precondition.IsInRange(in_entity.ID, Bounds, nameof(in_entity));

            var isNew = !Entities.ContainsKey(in_entity.ID);

            if (isNew)
            {
                Entities[in_entity.ID] = in_entity;
            }
            else
            {
                Error.Handle($"Tried to create duplicate entity ID {in_entity.ID}.");
            }

            return isNew;
        }

        /// <summary>
        /// Adds a collection of <see cref="Entity"/>s to the collection.
        /// </summary>
        /// <param name="in_entities">The <see cref="Entity"/>s to add.  Cannot be null.</param>
        /// <returns><c>true</c> if all of the <see cref="Entity"/>s were added successfully; <c>false</c> otherwise.</returns>
        public bool AddRange(IEnumerable<Entity> in_entities)
        {
            Precondition.IsNotNull(in_entities, nameof(in_entities));

            var succeeded = true;

            foreach (var entity in in_entities)
            {
                succeeded &= Add(entity);
            }

            return succeeded;
        }

        /// <summary>
        /// Determines whether the <see cref="EntityCollection"/> contains the specified <see cref="Entity"/>.
        /// </summary>
        /// <param name="in_entity">The <see cref="Entity"/> to find.</param>
        /// <returns><c>true</c> if the <see cref="Entity"/> was found; <c>false</c> otherwise.</returns>
        public bool Contains(Entity in_entity)
        {
            return Entities.ContainsKey(in_entity.ID);
        }

        /// <summary>
        /// Determines whether the <see cref="EntityCollection"/> contains the specified <see cref="Entity"/>.
        /// </summary>
        /// <param name="in_id">The <see cref="EntityID"/> of the <see cref="Entity"/> to find.</param>
        /// <returns><c>true</c> if the <see cref="EntityID"/> was found; <c>false</c> otherwise.</returns>
        /// <remarks>This method is equivalent to <see cref="Dictionary{EntityID, Entity}.ContainsKey"/>.</remarks>
        public bool Contains(EntityID in_id)
        {
            Precondition.IsInRange(in_id, Bounds, nameof(in_id));

            return Entities.ContainsKey(in_id);
        }

        /// <summary>
        /// Removes the given <see cref="Entity"/> from the <see cref="EntityCollection"/>.
        /// </summary>
        /// <param name="in_entity">The <see cref="Entity"/> to remove.</param>
        /// <returns>
        /// <c>true</c> if the <see cref="Entity"/> is successfully found and removed; otherwise, <c>false</c>.
        /// This method returns <c>false</c> if <see cref="EntityID"/> is not found.
        /// </returns>
        public bool Remove(Entity in_entity)
        {
            return Entities.Remove(in_entity.ID);
        }

        /// <summary>
        /// Removes the <see cref="Entity"/> with the specified <see cref="EntityID"/> from the <see cref="EntityCollection"/>.
        /// </summary>
        /// <param name="in_id">The <see cref="EntityID"/> of the <see cref="Entity"/> to remove.</param>
        /// <returns>
        /// <c>true</c> if the <see cref="Entity"/> is successfully found and removed; otherwise, <c>false</c>.
        /// This method returns <c>false</c> if <see cref="EntityID"/> is not found.
        /// </returns>
        public bool Remove(EntityID in_id)
        {
            Precondition.IsInRange(in_id, Bounds, nameof(in_id));

            return Entities.Remove(in_id);
        }

        /// <summary>
        /// Returns the specified <typeparamref name="T"/>.
        /// </summary>
        /// <param name="in_id">A valid, defined <typeparamref name="T"/> identifier.</param>
        /// <typeparam name="T">
        /// The type of <typeparamref name="ParentType"/> sought.  Must correspond to the given <paramref name="in_id"/>.
        /// </typeparam>
        /// <returns>The specified <typeparamref name="T"/>.</returns>
        public T Get<T>(EntityID in_id) where T : ParentType
        {
            Precondition.IsInRange(in_id, Bounds, nameof(in_id));

            return (T)Entities[in_id];
        }
        #endregion

        #region Utility Methods
        /// <summary>
        /// Serializes all defined parquets to a string.
        /// </summary>
        /// <returns>The serialized parquets.</returns>
        public string SerializeToString()
            => JsonConvert.SerializeObject(Entities, Formatting.None);

        /// <summary>
        /// Tries to deserialize an <see cref="EntityCollection"/> from the given string.
        /// </summary>
        /// <param name="in_serializedParquets">The serialized parquets.</param>
        /// <returns><c>true</c>, if deserialization was successful, <c>false</c> otherwise.</returns>
        public bool TryDeserializeFromString(string in_serializedParquets)
        {
            // TODO: Ensure this is working as intended.  See:
            // https://stackoverflow.com/questions/6348215/how-to-deserialize-json-into-ienumerablebasetype-with-newtonsoft-json-net
            // https://www.newtonsoft.com/json/help/html/SerializeTypeNameHandling.htm
            var result = false;

            if (string.IsNullOrEmpty(in_serializedParquets))
            {
                Error.Handle($"Error deserializing an {nameof(EntityCollection)}.");
            }
            else
            {
                try
                {
                    Entities = JsonConvert.DeserializeObject<Dictionary<EntityID, Entity>>(in_serializedParquets);
                    result = true;
                }
                catch (JsonReaderException exception)
                {
                    Error.Handle($"Error reading string while deserializing an {nameof(Entity)} or {nameof(EntityID)}: {exception}");
                }
            }

            return result;
        }

        /// <summary>
        /// Retrieves an enumerator for the <see cref="EntityCollection{T}"/>.
        /// </summary>
        /// <returns>An enumerator that iterates through the collection.</returns>
        public IEnumerator<Entity> GetEnumerator()
            => Entities.Values.GetEnumerator();

        /// <summary>
        /// Returns a <see langword="string"/> that represents the current <see cref="EntityCollection"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
        {
            var allBoundNames = new StringBuilder();
            foreach (var bound in Bounds)
            {
                allBoundNames.Append(bound);
            }
            return $"Collects {typeof(ParentType)} over {allBoundNames}.";
        }
        #endregion
    }

    /// <summary>
    /// Stores an <see cref="Entity"/> collection.
    /// Provides bounds-checking and type-checking against <see cref="Entity"/>.
    /// </summary>
    /// <remarks>
    /// This version supports collections that do not rely heavily on
    /// multiple incompatible subclasses of <see cref="Entity"/>.
    /// </remarks>
    public class EntityCollection : EntityCollection<Entity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityCollection"/> class.
        /// </summary>
        /// <param name="in_bounds">The bounds within which the collected <see cref="EntityID"/>s are defined.</param>
        public EntityCollection(List<Range<EntityID>> in_bounds) : base(in_bounds) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityCollection"/> class.
        /// </summary>
        /// <param name="in_bounds">The bounds within which the collected <see cref="EntityID"/>s are defined.</param>
        public EntityCollection(Range<EntityID> in_bounds) : base(new List<Range<EntityID>> { in_bounds }) { }

        /// <summary>
        /// Returns the specified <see cref="Entity"/>.
        /// </summary>
        /// <param name="in_id">A valid, defined <see cref="Entity"/> identifier.</param>
        /// <returns>The specified <see cref="Entity"/>.</returns>
        public Entity Get(EntityID in_id)
        {
            return Get<Entity>(in_id);
        }
    }
}
