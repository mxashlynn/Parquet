#if DESIGN
using System.Collections.Generic;
using ParquetClassLibrary.Items;

namespace ParquetClassLibrary.EditorSupport
{
    /// <summary>
    /// Facilitates editing of an <see cref="Inventory"/> from design tools while maintaining a read-only face for use during play.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1710:Identifiers should have correct suffix",
                                                     Justification = "Inventory implies InventorySlotCollection.")]
    public interface IMutableInventory : ICollection<InventorySlot>
    {
        #region ICollection Implementation
        /// <summary>
        /// Adds the given <see cref="InventorySlot"/> to the <see cref="Inventory"/>.
        /// </summary>
        new void Add(InventorySlot inSlot);

        /// <summary>
        /// Removes all <see cref="InventorySlot"/>s from the <see cref="Inventory"/>.
        /// <remarks>This method does not respect gameplay rules, but forcibly empties the collection.</remarks>
        /// </summary>
        new void Clear();

        /// <summary>
        /// Copies the elements of the <see cref="Inventory"/> to an <see cref="System.Array"/>, starting at the given index.
        /// </summary>
        /// <param name="inArray">The array to copy to.</param>
        /// <param name="inArrayIndex">The index at which to begin copying.</param>
        new void CopyTo(InventorySlot[] inArray, int inArrayIndex);

        /// <summary>
        /// Removes the first occurrence of the given <see cref="InventorySlot"/> from the <see cref="Inventory"/>.
        /// </summary>
        /// <param name="inSlot">The slot to remove.</param>
        /// <returns><c>False</c> if slot was found but could not be removed; otherwise, <c>true</c>.</returns>
        new bool Remove(InventorySlot inSlot);
        #endregion
    }
}
#endif
