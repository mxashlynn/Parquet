namespace Parquet.Parquets
{
    /// <summary>
    /// Interface to a simple container for one of each layer of parquet occupying the same position.
    /// </summary>
    /// <remarks>
    /// Supports injecting <see cref="ParquetStack"/> into game-level methods that performs simple operations, such as rasterization.
    /// </remarks>
    // TODO: Let's consider if there is another word than Stack that we can use.  Bundle?  Sheaf?
    public interface IParquetStack
    {
        /// <summary>The floor contained in this stack.</summary>
        ModelID FloorID { get; }

        /// <summary>The block contained in this stack.</summary>
        ModelID BlockID { get; }

        /// <summary>The furnishing contained in this stack.</summary>
        ModelID FurnishingID { get; }

        /// <summary>The collectible contained in this stack.</summary>
        ModelID CollectibleID { get; }

        /// <summary>
        /// Indicates whether this <see cref="ParquetStack"/> is empty.
        /// </summary>
        /// <value><c>true</c> if the stack contains no parquet at all; otherwise, <c>false</c>.</value>
        bool IsEmpty { get; }
    }
}
