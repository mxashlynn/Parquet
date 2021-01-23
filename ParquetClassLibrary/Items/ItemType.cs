namespace Parquet.Items
{
    /// <summary>
    /// Represents the different types of <see cref="ItemModel"/>s that may be carried and used.
    /// </summary><para />
    /// <remarks>
    /// The <see cref="ItemModel"/> subtypes are hard-coded, but individual items themselves are configured in CSV files.
    /// </remarks>
    public enum ItemType
    {
        /// <summary>This item corresponds to no particular category.</summary>
        Other = 0,
        /// <summary>This item may be used only once.</summary>
        Consumable,
        /// <summary>This item may be worn, carried, or otherwise employed in an ongoing fashion.</summary>
        Equipment,
        /// <summary>This item unlocks a mechanic, domain, or door.</summary>
        KeyItem,
        /// <summary>This item may be used in crafting a recipe.</summary>
        Material,
        /// <summary>This item may contain other items.</summary>
        Storage,
        /// <summary>This item may be used multiple times to gather parquets.</summary>
        ToolForGathering,
        /// <summary>This item may be used multiple times to alter parquets.</summary>
        ToolForModification,
    }
}
