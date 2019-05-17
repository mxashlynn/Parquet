using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// Simple container for one of each layer of parquet that can occupy the same position.
    /// </summary>
    public struct ParquetStack : IParquetStack
    {
        /// <summary>Cannonical null <see cref="ParquetStack"/>, representing an arbitrary empty stack.</summary>
        public static ParquetStack Empty => new ParquetStack(EntityID.None, EntityID.None, EntityID.None, EntityID.None);

        /// <summary>The floor contained in this stack.</summary>
        public EntityID Floor { get; }

        /// <summary>The block contained in this stack.</summary>
        public EntityID Block { get; }

        /// <summary>The furnishing contained in this stack.</summary>
        public EntityID Furnishing { get; }

        /// <summary>The collectible contained in this stack.</summary>
        public EntityID Collectible { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParquetStack"/> struct.
        /// </summary>
        /// <param name="in_floor">The floor-layer parquet.</param>
        /// <param name="in_block">The The floor-layer parquet-layer parquet.</param>
        /// <param name="in_furnishing">The furnishing-layer parquet.</param>
        /// <param name="in_collectible">The collectible-layer parquet.</param>
        public ParquetStack(EntityID in_floor, EntityID in_block, EntityID in_furnishing, EntityID in_collectible)
        {
            Precondition.IsInRange(in_floor, All.FloorIDs, nameof(in_floor));
            Precondition.IsInRange(in_block, All.FloorIDs, nameof(in_block));
            Precondition.IsInRange(in_furnishing, All.FloorIDs, nameof(in_furnishing));
            Precondition.IsInRange(in_collectible, All.FloorIDs, nameof(in_collectible));

            Floor = in_floor;
            Block = in_block;
            Furnishing = in_furnishing;
            Collectible = in_collectible;
        }

        /// <summary>
        /// Indicates whether this <see cref="ParquetStack"/> is empty.
        /// </summary>
        /// <value><c>true</c> if the stack contains only null references; otherwise, <c>false</c>.</value>
        public bool IsEmpty => EntityID.None == Floor &&
                               EntityID.None == Block &&
                               EntityID.None == Furnishing &&
                               EntityID.None == Collectible;
    }
}
