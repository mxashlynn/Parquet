namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// Interface to a simple container for one of each layer of parquet occupying the same position.
    /// Supports injecting <see cref="ParquetStack"/> into <see cref="Utilities.Rasterization"/> methods.
    /// </summary>
    public interface IParquetStack
    {
        /// <summary>The floor contained in this stack.</summary>
        EntityID Floor { get; }

        /// <summary>The block contained in this stack.</summary>
        EntityID Block { get; }

        /// <summary>The furnishing contained in this stack.</summary>
        EntityID Furnishing { get; }

        /// <summary>The collectible contained in this stack.</summary>
        EntityID Collectible { get; }

        /// <summary>
        /// Indicates whether this <see cref="ParquetStack"/> is empty.
        /// </summary>
        /// <value><c>true</c> if the stack contains no parquet at all; otherwise, <c>false</c>.</value>
        bool IsEmpty { get; }
    }
}
