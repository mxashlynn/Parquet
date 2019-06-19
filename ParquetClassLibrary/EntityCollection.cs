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
    /// Stores an <see cref="Entity"/> collection.
    /// Provides bounds-checking and type-checking against <typeparamref name="ParentType"/>.
    /// </summary>
    /// <remarks>
    /// This generic version is intended to support <see cref="All.Parquets"/> allowing
    /// the collection to store all parquet types but return only the requested subtype.
    /// </remarks>
    public class EntityCollection<ParentType> : IEnumerable<ParentType> where ParentType : Entity
    {
        /// <summary>A value to use in place of uninitialized <see cref="EntityCollection{T}"/>s.</summary>
        public static readonly EntityCollection<ParentType> Default = new EntityCollection<ParentType>(
            new List<Range<EntityID>> { new Range<EntityID>(int.MinValue, int.MaxValue) }, Enumerable.Empty<Entity>());

        /// <summary>The internal collection mechanism.</summary>
        private IReadOnlyDictionary<EntityID, Entity> Entities { get; }

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

            var baseDictionary = new Dictionary<EntityID, Entity> { { EntityID.None, null } };
            foreach (var entity in in_entities)
            {
                Precondition.IsInRange(entity.ID, in_bounds, nameof(in_entities));

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
        /// <param name="in_serializedParquets">The serialized parquets.</param>
        public EntityCollection(List<Range<EntityID>> in_bounds, string in_serializedParquets)
        {
            Precondition.IsNotEmpty(in_serializedParquets, nameof(in_serializedParquets));

            // TODO: Ensure this is working as intended.  See:
            // https://stackoverflow.com/questions/6348215/how-to-deserialize-json-into-ienumerablebasetype-with-newtonsoft-json-net
            // https://www.newtonsoft.com/json/help/html/SerializeTypeNameHandling.htm

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
            return Entities.ContainsKey(in_entity.ID);
        }

        /// <summary>
        /// Determines whether the <see cref="EntityCollection{T}"/> contains the specified <see cref="Entity"/>.
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

        /// <summary>
        /// Exposes an <see cref="IEnumerator{ParentType}"/>, which supports simple iteration.
        /// </summary>
        /// <returns>An enumerator.</returns>
        IEnumerator<ParentType> IEnumerable<ParentType>.GetEnumerator()
            => (IEnumerator<ParentType>)Entities.Values.GetEnumerator();

        /// <summary>
        /// Exposes an <see cref="IEnumerator"/>, which supports simple iteration.
        /// </summary>
        /// <returns>An enumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
            => Entities.Values.GetEnumerator();
        #endregion

        #region LINQ
        /// <summary>
        /// Returns an arbitrary element in the collection.
        /// </summary>
        /// <typeparam name="T">A subtype of <typeparamref name="ParentType"/> to reurn.</typeparam>
        /// <returns>An element</returns>
        public T First<T>() where T : ParentType
            => (T)Entities.First(kvp => kvp.Key != EntityID.None).Value;

        /// <summary>
        /// Returns an arbitrary element in the collection corresponding to the given predicate.
        /// </summary>
        /// <param name="in_predicate">True for the element sought.</param>
        /// <typeparam name="T">A subtype of <typeparamref name="ParentType"/> to reurn.</typeparam>
        /// <returns>An element</returns>
        public T First<T>(Func<T, bool> in_predicate) where T : ParentType
            => (T)Entities.First(kvp => kvp.Key != EntityID.None
                                     && in_predicate((T)kvp.Value)).Value;

        /// <summary>
        /// Returns an arbitrary element in the collection, or null if none exists.
        /// </summary>
        /// <typeparam name="T">A subtype of <typeparamref name="ParentType"/> to reurn.</typeparam>
        /// <returns>An element</returns>
        public T FirstOrDefault<T>() where T : ParentType
            => (T)Entities.FirstOrDefault(kvp => kvp.Key != EntityID.None).Value;

        /// <summary>
        /// Returns an arbitrary element in the collection corresponding to the given predicate, or null if none exists.
        /// </summary>
        /// <param name="in_predicate">True for the element sought.</param>
        /// <typeparam name="T">A subtype of <typeparamref name="ParentType"/> to reurn.</typeparam>
        /// <returns>An element</returns>
        public T FirstOrDefault<T>(Func<T, bool> in_predicate) where T : ParentType
            => (T)Entities.FirstOrDefault(kvp => kvp.Key != EntityID.None
                                              && in_predicate((T)kvp.Value)).Value;
        #endregion

        #region Utility Methods
        /// <summary>
        /// Serializes all defined parquets to a string.
        /// </summary>
        /// <returns>The serialized parquets.</returns>
        public string SerializeToString()
            => JsonConvert.SerializeObject(Entities, Formatting.None);

        /// <summary>
        /// Retrieves an enumerator for the <see cref="EntityCollection{T}"/>.
        /// </summary>
        /// <returns>An enumerator that iterates through the collection.</returns>
        public IEnumerator<Entity> GetEnumerator()
            => Entities.Values.GetEnumerator();

        /// <summary>
        /// Returns a <see langword="string"/> that represents the current <see cref="EntityCollection{T}"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
        {
            var allBoundNames = new StringBuilder();
            foreach (var bound in Bounds)
            {
                allBoundNames.Append(bound.ToString());
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
        {
            return Get<Entity>(in_id);
        }
    }
}
