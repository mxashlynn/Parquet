using System;
using System.Collections.Generic;

namespace ParquetClassLibrary.Sandbox.Parquets
{
    /// <summary>
    /// Stores all defined parquet models for use in sandbox-mode.
    /// This collection is the source of truth about parquets for the rest of the library,
    /// something like a color palette that other classes can paint with.
    /// </summary>
    public static class AllParquets
    {
        /// <summary>A collection of all defined parquets of all subtypes.  All IDs must be unique.</summary>
        private static EntityCollection ParquetDefinitions { get; set; } = new EntityCollection();

        /// <summary>The number of parquets currently defined.</summary>
        public static int Count => ParquetDefinitions.Count;

        /// <summary>
        /// Adds the given parquet to the collection of cannonical parquets.
        /// This allows parquets to be created at run-time.
        /// </summary>
        /// <param name="in_parquet">The parquet being defined.</param>
        /// <returns><c>true</c> if the parquet was added successfully; <c>false</c> otherwise.</returns>
        public static bool Add(ParquetParent in_parquet)
        {
            return ParquetDefinitions.Add(in_parquet);
        }

        /// <summary>
        /// Adds a collection of parquets to the cannonical definitions.
        /// This supports adding parquets via alternative serialization mechanisms.
        /// </summary>
        /// <param name="in_parquets">The parquets to add.  Cannot be null.</param>
        /// <returns><c>true</c> if all of the parquets were added successfully; <c>false</c> otherwise.</returns>
        public static bool AddRange(IEnumerable<ParquetParent> in_parquets)
        {
            return ParquetDefinitions.AddRange(in_parquets);
        }

        /// <summary>
        /// Determines whether the <see cref="AllParquets"/> contains the specified <see cref="ParquetParent"/>.
        /// </summary>
        /// <param name="in_id">The <see cref="EntityID"/> of the <see cref="Entity"/> to find.</param>
        /// <returns><c>true</c> if the <see cref="EntityID"/> was found; <c>false</c> otherwise.</returns>
        /// <remarks>This method is equivalent to <see cref="Dictionary{EntityID, ParquetParent}.ContainsKey"/>.</remarks>
        public static bool Contains(EntityID in_id)
        {
            return ParquetDefinitions.Contains(in_id);
        }

        /// <summary>
        /// Removes the <see cref="Entity"/> with the specified <see cref="EntityID"/> from the <see cref="AllParquets"/>.
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
        public static bool Remove(EntityID in_id)
        {
            return ParquetDefinitions.Remove(in_id);
        }

        /// <summary>
        /// Returns the specified parquet.
        /// </summary>
        /// <param name="in_id">A valid, defined parquet identifier.</param>
        /// <typeparam name="T">The type of parquet sought.  Must correspond to the given ID.</typeparam>
        /// <returns>The specified parquet.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown when the given ID is not a valid parquet ID.
        /// </exception>
        /// <exception cref="System.InvalidCastException">
        /// Thrown when the specified type does not correspond to the given ID.
        /// </exception>
        public static T Get<T>(EntityID in_id) where T : ParquetParent
        {
            if (!in_id.IsValidForRange(AssemblyInfo.ParquetIDs))
            {
                throw new ArgumentOutOfRangeException(nameof(in_id));
            }

            return (T)ParquetDefinitions.Get(in_id);
        }

        /// <summary>
        /// Serializes all defined parquets to a string.
        /// </summary>
        /// <returns>The serialized parquets.</returns>
        public static string SerializeToString()
        {
            return ParquetDefinitions.SerializeToString();
        }

        /// <summary>
        /// Tries to deserialize a collection of parquets from the given string.
        /// </summary>
        /// <param name="in_serializedParquets">The serialized parquets.</param>
        /// <returns><c>true</c>, if deserialization was successful, <c>false</c> otherwise.</returns>
        public static bool TryDeserializeFromString(string in_serializedParquets)
        {
            return ParquetDefinitions.TryDeserializeFromString(in_serializedParquets);
        }
    }
}
