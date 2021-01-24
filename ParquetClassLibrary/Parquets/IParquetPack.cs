namespace Parquet.Parquets
{
    /// <summary>
    /// Interface to a simple container for one of each layer of parquet occupying the same position.
    /// </summary>
    /// <remarks>
    /// Supports injecting <see cref="ParquetPack"/> into game-level methods that performs simple operations, such as rasterization.
    /// </remarks>
    public interface IParquetPack
    {
        /// <summary>The floor contained in this pack.</summary>
        ModelID FloorID { get; }

        /// <summary>The block contained in this pack.</summary>
        ModelID BlockID { get; }

        /// <summary>The furnishing contained in this pack.</summary>
        ModelID FurnishingID { get; }

        /// <summary>The collectible contained in this pack.</summary>
        ModelID CollectibleID { get; }

        /// <summary>
        /// Indicates whether this <see cref="ParquetPack"/> is empty.
        /// </summary>
        /// <value><c>true</c> if the stack contains no parquet at all; otherwise, <c>false</c>.</value>
        bool IsEmpty { get; }
    }
}
