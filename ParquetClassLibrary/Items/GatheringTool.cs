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
        /// <summary>This parquet cannot be gathered.</summary>
        None,
        /// <summary>This parquet can be gathered by using a pick-like tool.</summary>
        Pick,
        /// <summary>This parquet can be gathered by using a axe-like tool.</summary>
        Axe,
        /// <summary>This parquet can be gathered by using a shovel-like tool.</summary>
        Shovel,
        /// <summary>This parquet can be gathered by using a bucket-like tool.</summary>
        Bucket,
    }
}
