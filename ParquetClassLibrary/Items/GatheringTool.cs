namespace ParquetClassLibrary.Items
{
    /// <summary>
    /// IDs for <see cref="Item"/> tools that Characters can use to gather <see cref="Parquets.Block"/>s.
    /// </summary>
    /// <remarks>
    /// The tool subtypes are hard-coded, but individual <see cref="Item"/>s themselves are configured in CSV files.
    /// </remarks>
    public enum GatheringTool
    {
        None,
        Pick,
        Axe,
        Shovel,
        Bucket,
    }
}
