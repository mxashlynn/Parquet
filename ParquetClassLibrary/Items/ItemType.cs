namespace ParquetClassLibrary.Items
{
    /// <summary>
    /// Represents the different types of <see cref="ItemModel"/>s that may be carried and used.
    /// </summary><para />
    /// <remarks>
    /// The <see cref="ItemModel"/> subtypes are hard-coded, but individual items themselves are configured in CSV files.
    /// </remarks>
    public enum ItemType
    {
        Other,
        Consumable,
        Equipment,
        KeyItem,
        Material,
        Storage,
        ToolForGathering,
        ToolForModification,
    }
}
