namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// IDs for effects that can happen when a character encounters a Collectible.
    /// </summary>
    public enum CollectingEffect
    {
        /// <summary>Collecting this parquet has no effect.</summary>
        None = 0,
        /// <summary>Awards the <see cref="Beings.CharacterModel"/> a given <see cref="Items.ItemModel"/>.</summary>
        Item,
        /// <summary>Allows the <see cref="Beings.CharacterModel"/> to remain safely in the <see cref="Biomes.BiomeRecipe"/> longer.</summary>
        BiomeTime,
    }
}
