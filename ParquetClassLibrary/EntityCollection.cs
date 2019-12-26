using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary
{
    /// <summary>
    /// Collects a group of <see cref="Entity"/>s.
    /// Provides bounds-checking and type-checking against <typeparamref name="TParentType"/>.
    /// </summary>
    /// <remarks>
    /// All <see cref="EntityCollection{EntityID}"/>s implicitly contain <see cref="EntityID.None"/>.
    ///
    /// This generic version is intended to support <see cref="All.Parquets"/> allowing
    /// the collection to store all parquet types but return only the requested subtype.
    ///
    /// For more details, see remarks on <see cref="Entity"/>.
    /// </remarks>
    /// <seealso cref="EntityID"/>
    /// <seealso cref="EntityTag"/>
    /// <seealso cref="All"/>
    public class EntityCollection<TParentType> : IReadOnlyCollection<TParentType> where TParentType : Entity
    {
        /// <summary>A value to use in place of uninitialized <see cref="EntityCollection{T}"/>s.</summary>
        public static readonly EntityCollection<TParentType> Default = new EntityCollection<TParentType>(
            new List<Range<EntityID>> { new Range<EntityID>(int.MinValue, int.MaxValue) },
            Enumerable.Empty<Entity>());

        /// <summary>The internal collection mechanism.</summary>
        private IReadOnlyDictionary<EntityID, Entity> Entities { get; }

        /// <summary>The bounds within which all collected <see cref="Entity"/>s must be defined.</summary>
        private List<Range<EntityID>> Bounds { get; }

        /// <summary>The number of <see cref="Entity"/>s in the <see cref="EntityCollection{T}"/>.</summary>
        public int Count => Entities.Count;

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityCollection{T}"/> class.
        /// </summary>
        /// <param name="in_bounds">The bounds within which the collected <see cref="EntityID"/>s are defined.</param>
        /// <param name="in_entities">The <see cref="Entity"/>s to collect.  Cannot be null.</param>
        public EntityCollection(List<Range<EntityID>> in_bounds, IEnumerable<Entity> in_entities)
        {
            Precondition.IsNotNull(in_entities, nameof(in_entities));

            // All Collections of Entities implicitly contain the None Entity.
            var baseDictionary = new Dictionary<EntityID, Entity> { { EntityID.None, null } };
            foreach (var entity in in_entities)
            {
                Precondition.IsInRange(entity.ID, in_bounds, nameof(in_entities));

                if (entity.ID == EntityID.None)
                {
                    continue;
                }
                if (!baseDictionary.ContainsKey(entity.ID))
                {
                    baseDictionary[entity.ID] = entity;
                }
                else
                {
                    throw new InvalidOperationException($"Tried to duplicate entity ID {entity.ID}.");
                }
            }

            Bounds = in_bounds;
            Entities = baseDictionary;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityCollection{T}"/> class.
        /// </summary>
        /// <param name="in_bounds">The bounds within which the collected <see cref="EntityID"/>s are defined.</param>
        /// <param name="in_entities">The <see cref="Entity"/>s to collect.  Cannot be null.</param>
        public EntityCollection(Range<EntityID> in_bounds, IEnumerable<Entity> in_entities) :
            this(new List<Range<EntityID>> { in_bounds }, in_entities) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityCollection{T}"/> class.
        /// </summary>
        /// <param name="in_bounds">The bounds within which the collected <see cref="EntityID"/>s are defined.</param>
        /// <param name="in_serializedParquets">The serialized parquets.</param>
        public EntityCollection(List<Range<EntityID>> in_bounds, string in_serializedParquets)
        {
            Precondition.IsNotNullOrEmpty(in_serializedParquets, nameof(in_serializedParquets));

            Dictionary<EntityID, Entity> baseCollection;
            try
            {
                baseCollection = JsonConvert.DeserializeObject<Dictionary<EntityID, Entity>>(in_serializedParquets);
            }
            catch (JsonReaderException exception)
            {
                throw new System.Runtime.Serialization.SerializationException(
                    $"Error reading string while deserializing an {nameof(Entity)} or {nameof(EntityID)}", exception);
            }

            Bounds = in_bounds;
            Entities = baseCollection;
        }
        #endregion

        #region Collection Access
        /// <summary>
        /// Determines whether the <see cref="EntityCollection{T}"/> contains the specified <see cref="Entity"/>.
        /// </summary>
        /// <param name="in_entity">The <see cref="Entity"/> to find.</param>
        /// <returns><c>true</c> if the <see cref="Entity"/> was found; <c>false</c> otherwise.</returns>
        public bool Contains(Entity in_entity)
        {
            Precondition.IsNotNull(in_entity);

            return Entities.ContainsKey(in_entity.ID);
        }

        /// <summary>
        /// Determines whether the <see cref="EntityCollection{T}"/> contains an <see cref="Entity"/> with the specified <see cref="EntityID"/>.
        /// </summary>
        /// <param name="in_id">The <see cref="EntityID"/> of the <see cref="Entity"/> to find.</param>
        /// <returns><c>true</c> if the <see cref="EntityID"/> was found; <c>false</c> otherwise.</returns>
        public bool Contains(EntityID in_id)
        {
            // TODO Remove this test after debugging.
            Precondition.IsInRange(in_id, Bounds, nameof(in_id));

            return Entities.ContainsKey(in_id);
        }

        /// <summary>
        /// Returns the specified <typeparamref name="T"/>.
        /// </summary>
        /// <param name="in_id">A valid, defined <typeparamref name="T"/> identifier.</param>
        /// <typeparam name="T">
        /// The type of <typeparamref name="TParentType"/> sought.  Must correspond to the given <paramref name="in_id"/>.
        /// </typeparam>
        /// <returns>The specified <typeparamref name="T"/>.</returns>
        public T Get<T>(EntityID in_id) where T : TParentType
        {
            Precondition.IsInRange(in_id, Bounds, nameof(in_id));

            return (T)Entities[in_id];
        }

        /// <summary>
        /// Exposes an <see cref="IEnumerator{ParentType}"/> to support simple iteration.
        /// </summary>
        /// <remarks>Used by LINQ. No accessibility modifiers are valid in this context.</remarks>
        /// <returns>An enumerator.</returns>
        IEnumerator<TParentType> IEnumerable<TParentType>.GetEnumerator()
            => Entities.Values.Cast<TParentType>().GetEnumerator();

        /// <summary>
        /// Exposes an <see cref="IEnumerator"/> to support simple iteration.
        /// </summary>
        /// <remarks>Used by LINQ. No accessibility modifiers are valid in this context.</remarks>
        /// <returns>An enumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
            => Entities.Values.GetEnumerator();

        /// <summary>
        /// Retrieves an enumerator for the <see cref="EntityCollection{T}"/>.
        /// </summary>
        /// <returns>An enumerator that iterates through the collection.</returns>
        public IEnumerator<Entity> GetEnumerator()
            => Entities.Values.GetEnumerator();
        #endregion

        #region Utility Methods
        /// <summary>
        /// Serializes all defined parquets to a string.
        /// </summary>
        /// <returns>The serialized parquets.</returns>
        public string SerializeToString()
            => JsonConvert.SerializeObject(Entities, Formatting.None);

        /// <summary>
        /// Returns a <see langword="string"/> that represents the current <see cref="EntityCollection{T}"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
        {
            var allBounds = new StringBuilder();
            foreach (var bound in Bounds)
            {
                allBounds.Append($"{bound.ToString()} ");
            }
            return $"Collects {typeof(TParentType)} over {allBounds}.";
        }
        #endregion
    }

    /// <summary>
    /// Stores an <see cref="Entity"/> collection.
    /// Provides bounds-checking and type-checking against <see cref="Entity"/>.
    /// </summary>
    /// <remarks>
    /// All <see cref="EntityCollection"/>s implicitly contain <see cref="EntityID.None"/>.
    /// 
    /// This version supports collections that do not rely heavily on
    /// multiple incompatible subclasses of <see cref="Entity"/>.
    ///
    /// For more details, see remarks on <see cref="Entity"/>.
    /// </remarks>
    public class EntityCollection : EntityCollection<Entity>
    {
        /// <summary>A value to use in place of uninitialized <see cref="EntityCollection{T}"/>s.</summary>
        public static new readonly EntityCollection Default =
            new EntityCollection(new Range<EntityID>(int.MinValue, int.MaxValue), Enumerable.Empty<Entity>());

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityCollection"/> class.
        /// </summary>
        /// <param name="in_bounds">The bounds within which the collected <see cref="EntityID"/>s are defined.</param>
        /// <param name="in_entities">The <see cref="Entity"/>s to collect.  Cannot be null.</param>
        public EntityCollection(Range<EntityID> in_bounds, IEnumerable<Entity> in_entities)
            : base(new List<Range<EntityID>> { in_bounds }, in_entities) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityCollection"/> class.
        /// </summary>
        /// <param name="in_bounds">The bounds within which the collected <see cref="EntityID"/>s are defined.</param>
        /// <param name="in_serializedParquets">The serialized parquets.</param>
        public EntityCollection(Range<EntityID> in_bounds, string in_serializedParquets)
            : base(new List<Range<EntityID>> { in_bounds }, in_serializedParquets) { }

        /// <summary>
        /// Returns the specified <see cref="Entity"/>.
        /// </summary>
        /// <param name="in_id">A valid, defined <see cref="Entity"/> identifier.</param>
        /// <returns>The specified <see cref="Entity"/>.</returns>
        public Entity Get(EntityID in_id)
            => Get<Entity>(in_id);
    }
}
