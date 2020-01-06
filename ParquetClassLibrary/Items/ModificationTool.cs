namespace ParquetClassLibrary.Items
{
    /// <summary>
    /// IDs for <see cref="Item"/> tools that Characters can use to modify <see cref="Parquets.Block"/>s and <see cref="Parquets.Floor"/>s.
    /// </summary>
    /// <remarks>
    /// The tool subtypes are hard-coded, but individual <see cref="Item"/>s themselves are configured in CSV files.
    /// </remarks>
    public enum ModificationTool
    {
        None,
        Shovel,
        Hammer,
    }
}
