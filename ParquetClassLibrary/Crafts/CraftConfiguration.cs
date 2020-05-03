namespace ParquetClassLibrary.Crafts
{
    /// <summary>
    /// Provides parameters for <see cref="CraftingRecipe"/>s.
    /// </summary>
    // TODO Make this configurable via CSV.
    public static class CraftConfiguration
    {
        /// <summary>Number of ingredient categories per recipe.</summary>
        // TODO Make this configurable via CSV.
        public static Range<int> IngredientCount { get; } = new Range<int>(1, 5);

        /// <summary>Number of product categories per recipe.</summary>
        // TODO Make this configurable via CSV.
        public static Range<int> ProductCount { get; } = new Range<int>(1, 5);
    }
}
