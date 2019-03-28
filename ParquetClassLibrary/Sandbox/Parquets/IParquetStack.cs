namespace ParquetClassLibrary.Sandbox.Parquets
{
    /// <summary>
    /// Interface to a simple container for one of each layer of parquet occupying the same position.
    /// Supports injecting ParquetStack into Rasterization methods.
    /// </summary>
    public interface IParquetStack
    {
        /// <summary>The floor contained in this stack.</summary>
        Floor Floor { get; }

        /// <summary>The block contained in this stack.</summary>
        Block Block { get; }

        /// <summary>The furnishing contained in this stack.</summary>
        Furnishing Furnishing { get; }

        /// <summary>The collectable contained in this stack.</summary>
        Collectable Collectable { get; }

        /// <summary>
        /// Indicates whether this <see cref="T:ParquetClassLibrary.Sandbox.Parquets.ParquetStack"/> is empty.
        /// </summary>
        /// <value><c>true</c> if the stack contains only null references; otherwise, <c>false</c>.</value>
        bool IsEmpty { get; }
    }
}
