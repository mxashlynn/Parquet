namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// IDs for effects that can happen when a character gathers a <see cref="BlockModel"/>.
    /// </summary>
    public enum GatheringEffect
    {
        /// <summary>Gathering this parquet has no effect.</summary>
        None,
        /// <summary>Awards the <see cref="Beings.CharacterModel"/> a given <see cref="Items.ItemModel"/>.</summary>
        Item,
        /// <summary>Replaces this parquet with a <see cref="Parquets.CollectibleModel"/>.</summary>
        Collectible,
    }
}
