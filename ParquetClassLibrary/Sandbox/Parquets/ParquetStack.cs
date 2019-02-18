namespace ParquetClassLibrary.Sandbox.Parquets
{
    /// <summary>
    /// Simple container for one of each layer of parquet that can occupy the same position.
    /// </summary>
    public struct ParquetStack
    {
        public Floor floor;
        public Block block;
        public Furnishing furnishing;
        public Collectable collectable;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ParquetClassLibrary.Sandbox.Parquets.ParquetStack"/> struct.
        /// </summary>
        /// <param name="in_floor">The floor-layer parquet.</param>
        /// <param name="in_block">The The floor-layer parquet-layer parquet.</param>
        /// <param name="in_furnishing">The furnishing-layer parquet.</param>
        /// <param name="in_collectable">The collectable-layer parquet.</param>
        public ParquetStack(Floor in_floor, Block in_block, Furnishing in_furnishing, Collectable in_collectable)
        {
            floor = in_floor;
            block = in_block;
            furnishing = in_furnishing;
            collectable = in_collectable;
        }

        /// <summary>
        /// Indicates whether this <see cref="T:ParquetClassLibrary.Sandbox.Parquets.ParquetStack"/> is empty.
        /// </summary>
        /// <value><c>true</c> if the stack contains only null references; otherwise, <c>false</c>.</value>
        public bool IsEmpty
        {
            get
            {
                return null == floor &&
                       null == block &&
                       null == furnishing &&
                       null == collectable;
            }
        }
    }
}
