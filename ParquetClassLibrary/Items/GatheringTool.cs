namespace ParquetClassLibrary.Items
{
    /// <summary>
    /// IDs for <see cref="ItemModel"/> tools that Characters can use to gather <see cref="Parquets.BlockModel"/>s.
    /// </summary>
    /// <remarks>
    /// The tool subtypes are hard-coded, but individual <see cref="ItemModel"/>s themselves are configured in CSV files.
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
