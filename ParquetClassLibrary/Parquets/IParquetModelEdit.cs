namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// Facilitates editing of a <see cref="ParquetModel"/> from design tools while maintaining a read-only face for use during play.
    /// </summary>
    /// <remarks>
    /// By design, children of <see cref="ParquetModel"/> should never themselves use <see cref="IParquetModelEdit"/>.
    /// IParquetModelEdit is for use only by external types that require read/write access to model properties.
    /// </remarks>
    public interface IParquetModelEdit : IModelEdit
    {
        /// <summary>
        /// The <see cref="ModelID"/> of the <see cref="Items.ItemModel"/> awarded to the player when a character gathers or collects this parquet.
        /// </summary>
        public ModelID ItemID { get; set; }

        /// <summary>
        /// Describes the <see cref="Biomes.BiomeRecipe"/>(s) that this parquet helps form.
        /// Guaranteed to never be <c>null</c>.
        /// </summary>
        public ModelTag AddsToBiome { get; set; }

        /// <summary>
        /// A property of the parquet that can, for example, be used by <see cref="Rooms.RoomRecipe"/>s.
        /// Guaranteed to never be <c>null</c>.
        /// </summary>
        /// <remarks>
        /// Allows the creation of classes of constructs, for example "wooden", "golden", "rustic", or "fancy" rooms.
        /// </remarks>
        public ModelTag AddsToRoom { get; set; }
    }
}
