namespace ParquetClassLibrary.Sandbox.Parquets
{
    /// <summary>
    /// Simple container for one of each layer of parquet that can occupy the same position.
    /// </summary>
    public struct ParquetStack : ParquetStackI
    {
        /// <summary>The floor contained in this stack.</summary>
        public Floor Floor { get; private set; }

        /// <summary>The block contained in this stack.</summary>
        public Block Block { get; private set; }

        /// <summary>The furnishing contained in this stack.</summary>
        public Furnishing Furnishing { get; private set; }

        /// <summary>The collectable contained in this stack.</summary>
        public Collectable Collectable { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ParquetClassLibrary.Sandbox.Parquets.ParquetStack"/> struct.
        /// </summary>
        /// <param name="in_floor">The floor-layer parquet.</param>
        /// <param name="in_block">The The floor-layer parquet-layer parquet.</param>
        /// <param name="in_furnishing">The furnishing-layer parquet.</param>
        /// <param name="in_collectable">The collectable-layer parquet.</param>
        public ParquetStack(Floor in_floor, Block in_block, Furnishing in_furnishing, Collectable in_collectable)
        {
            Floor = in_floor;
            Block = in_block;
            Furnishing = in_furnishing;
            Collectable = in_collectable;
        }

        /// <summary>
        /// Indicates whether this <see cref="T:ParquetClassLibrary.Sandbox.Parquets.ParquetStack"/> is empty.
        /// </summary>
        /// <value><c>true</c> if the stack contains only null references; otherwise, <c>false</c>.</value>
        public bool IsEmpty
        {
            get
            {
                return null == Floor &&
                       null == Block &&
                       null == Furnishing &&
                       null == Collectable;
            }
        }
    }
}
