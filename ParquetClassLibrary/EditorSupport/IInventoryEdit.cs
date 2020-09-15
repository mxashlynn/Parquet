#if DESIGN
using System.Collections.Generic;
using ParquetClassLibrary.Items;

namespace ParquetClassLibrary.EditorSupport
{
    /// <summary>
    /// Facilitates editing of an <see cref="Inventory"/> from design tools while maintaining a read-only face for use during play.
    /// </summary>
    public interface IInventoryEdit
    {
        #region IInventoryEdit Implementation
        /// <summary>The internal collection mechanism.</summary>
        public IList<InventorySlot> Slots { get; }

        /// <summary>How many <see cref="InventorySlot"/>s exits.</summary>
        public int Capacity { get; set; }
        #endregion
    }
}
#endif
