namespace ParquetClassLibrary.Items
{
    /// <summary>
    /// IDs for <see cref="ItemModel"/> tools that Characters can use to modify <see cref="Parquets.BlockModel"/>s and <see cref="Parquets.FloorModel"/>s.
    /// </summary>
    /// <remarks>
    /// The tool subtypes are hard-coded, but individual <see cref="ItemModel"/>s themselves are configured in CSV files.
    /// </remarks>
    public enum ModificationTool
    {
        /// <summary>This parquet cannot be modified.</summary>
        None,
        /// <summary>This parquet can be modified with a shovel-like tool.</summary>
        Shovel,
        /// <summary>This parquet can be modified with a hammer-like tool.</summary>
        Hammer,
    }
}
