#if DESIGN
using System.Collections.Generic;
using ParquetClassLibrary.EditorSupport;

namespace ParquetClassLibrary.Items
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
        Justification = "By design, Inventory should never itself use IInventoryEdit to access its own members.  The IInventoryEdit interface is for external types that require read/write access.")]
    public partial class Inventory : IInventoryEdit
    {
        #region IInventoryEdit Implementation
        /// <summary>The internal collection mechanism.</summary>
        IList<InventorySlot> IInventoryEdit.Slots => Slots;

        /// <summary>How many <see cref="InventorySlot"/>s exits.</summary>
        int IInventoryEdit.Capacity { get => Capacity; set => Capacity = value; }
        #endregion
    }
}
#endif
