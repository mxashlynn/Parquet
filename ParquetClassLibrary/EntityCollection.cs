using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary
{
    /// <summary>
    /// Stores a collection of <see cref="Entity"/>s.
    /// </summary>
    public class EntityCollection
    {
        /// <summary>The internal collection mechanism.</summary>
        private Dictionary<EntityID, Entity> Entities { get; set; } = new Dictionary<EntityID, Entity>
        {
            { EntityID.None, null }
        };

        /// <summary>The number of <see cref="Entity"/>s in the <see cref="EntityCollection"/>.</summary>
        public int Count => Entities.Count;

        /// <summary>
        /// Adds the given <see cref="Entity"/> to the collection.
        /// </summary>
        /// <param name="in_entity">The <see cref="Entity"/> being added.</param>
        /// <returns><c>true</c> if the <see cref="Entity"/> was added successfully; <c>false</c> otherwise.</returns>
        public bool Add(Entity in_entity)
        {
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
            var succeeded = true;

            if (null == in_entities)
            {
                throw new ArgumentNullException(nameof(in_entities));
            }

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
        /// <remarks>
        /// From the perspective of the game and tools client code, removing an <see cref="Entity"/> from its associated
        /// <see cref="EntityCollection"/> is the same as undefining it.
        /// </remarks>
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
        /// <remarks>
        /// From the perspective of the game and tools client code, removing an <see cref="Entity"/> from its associated
        /// <see cref="EntityCollection"/> is the same as undefining it.
        /// </remarks>
        public bool Remove(EntityID in_id)
        {
            return Entities.Remove(in_id);
        }

        /// <summary>
        /// Returns the specified <see cref="Entity"/>.
        /// </summary>
        /// <param name="in_id">A valid, defined <see cref="Entity"/> identifier.</param>
        /// <typeparam name="T">The type of <see cref="Entity"/> sought.  Must correspond to the given ID.</typeparam>
        /// <returns>The specified <see cref="Entity"/>.</returns>
        public Entity Get(EntityID in_id)
        {
            return Entities[in_id];
        }

        /// <summary>
        /// Retrieves an enumerator for the <see cref="EntityCollection"/>.
        /// </summary>
        /// <returns>An enumerator that iterates through the collection.</returns>
        public IEnumerator<Entity> GetEnumerator()
        {
            return Entities.Values.GetEnumerator();
        }

        /// <summary>
        /// Serializes all defined parquets to a string.
        /// </summary>
        /// <returns>The serialized parquets.</returns>
        public string SerializeToString()
        {
            return JsonConvert.SerializeObject(Entities, Formatting.None);
        }

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
    }
}
