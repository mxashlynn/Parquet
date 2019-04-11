namespace ParquetClassLibrary.Items
{
    /// <summary>
    /// Represents the different types of items that may be carried and used.
    /// 
    /// The types of items are hard-coded, as well as the individual subtypes
    /// of Tools, Equipment, and Key Items.  But individual items themselves
    /// are configured in files similar to parquets.
    /// </summary>
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
