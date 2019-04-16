using System;
using System.Collections.Generic;

namespace ParquetClassLibrary.Items
{
    /// <summary>
    /// Stores all defined <see cref="Item"/>s.
    /// This collection is the source of truth about items for the rest of the library,
    /// something like a color palette that other classes can paint with.
    /// </summary>
    public static class AllItems
    {
        /// <summary>A collection of all defined items of all subtypes.  All IDs must be unique.</summary>
        private static EntityCollection ItemDefinitions { get; set; } = new EntityCollection(All.ItemIDs);

        /// <summary>The number of items currently defined.</summary>
        public static int Count => ItemDefinitions.Count;

        /// <summary>
        /// Adds the given item to the collection of cannonical <see cref="Item"/>s.
        /// This allows items to be created at run-time.
        /// </summary>
        /// <param name="in_item">The item being defined.</param>
        /// <returns><c>true</c> if the item was added successfully; <c>false</c> otherwise.</returns>
        public static bool Add(Item in_item)
        {
            return ItemDefinitions.Add(in_item);
        }

        /// <summary>
        /// Adds a collection of items to the cannonical definitions.
        /// This supports adding items via CSV serialization mechanisms.
        /// </summary>
        /// <param name="in_items">The items to add.  Cannot be null.</param>
        /// <returns><c>true</c> if all of the items were added successfully; <c>false</c> otherwise.</returns>
        public static bool AddRange(IEnumerable<Item> in_items)
        {
            return ItemDefinitions.AddRange(in_items);
        }

        /// <summary>
        /// Determines whether <see cref="AllItems"/> contains the specified <see cref="Item"/>.
        /// </summary>
        /// <param name="in_id">The <see cref="EntityID"/> of the <see cref="Item"/> to find.</param>
        /// <returns><c>true</c> if the <see cref="EntityID"/> was found; <c>false</c> otherwise.</returns>
        /// <remarks>This method is equivalent to <see cref="Dictionary{EntityID, Item}.ContainsKey"/>.</remarks>
        public static bool Contains(EntityID in_id)
        {
            return ItemDefinitions.Contains(in_id);
        }

        /// <summary>
        /// Removes the <see cref="Item"/> with the specified <see cref="EntityID"/> from the <see cref="AllItems"/>.
        /// </summary>
        /// <param name="in_id">The <see cref="EntityID"/> of the <see cref="Item"/> to remove.</param>
        /// <returns>
        /// <c>true</c> if the <see cref="Entity"/> is successfully found and removed; otherwise, <c>false</c>.
        /// This method returns <c>false</c> if <see cref="EntityID"/> is not found.
        /// </returns>
        /// <remarks>
        /// From the perspective of the game and tools client code, removing an <see cref="Item"/> from
        /// <see cref="AllItems"/> is the same as undefining it.
        /// </remarks>
        public static bool Remove(EntityID in_id)
        {
            return ItemDefinitions.Remove(in_id);
        }

        /// <summary>
        /// Returns the specified <see cref="Item"/>.
        /// </summary>
        /// <param name="in_id">A valid, defined identifier from <see cref="All.ItemIDs"/>.</param>
        /// <returns>The specified item definition.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown when the given ID is not a valid <see cref="All.ItemIDs"/>.
        /// </exception>
        public static Item Get(EntityID in_id)
        {
            if (!in_id.IsValidForRange(All.ItemIDs))
            {
                throw new ArgumentOutOfRangeException(nameof(in_id));
            }

            return (Item)ItemDefinitions.Get(in_id);
        }

        /// <summary>
        /// Serializes all defined <see cref="Item"/>s to a string.
        /// </summary>
        /// <returns>The serialized items.</returns>
        public static string SerializeToString()
        {
            return ItemDefinitions.SerializeToString();
        }

        /// <summary>
        /// Tries to deserialize a collection of <see cref="Item"/>s from the given string.
        /// </summary>
        /// <param name="in_serializedItems">The serialized items.</param>
        /// <returns><c>true</c>, if deserialization was successful, <c>false</c> otherwise.</returns>
        public static bool TryDeserializeFromString(string in_serializedItems)
        {
            return ItemDefinitions.TryDeserializeFromString(in_serializedItems);
        }
    }
}
