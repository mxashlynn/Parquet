using System;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// Simple container for one of each overlapping layer of parquet.
    /// </summary>
    public readonly struct ParquetStack : IParquetStack, IEquatable<ParquetStack>
    {
        /// <summary>Cannonical null <see cref="ParquetStack"/>, representing an arbitrary empty stack.</summary>
        public static ParquetStack Empty => new ParquetStack(EntityID.None, EntityID.None, EntityID.None, EntityID.None);

        /// <summary>The number of parquets actually present in this stack.</summary>
        public int Count => EntityID.None != Floor ? 1 : 0
                          + EntityID.None != Block ? 1 : 0
                          + EntityID.None != Furnishing ? 1 : 0
                          + EntityID.None != Collectible ? 1 : 0;

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
        /// <param name="inFloor">The floor-layer parquet.</param>
        /// <param name="inBlock">The The floor-layer parquet-layer parquet.</param>
        /// <param name="inFurnishing">The furnishing-layer parquet.</param>
        /// <param name="inCollectible">The collectible-layer parquet.</param>
        public ParquetStack(EntityID inFloor, EntityID inBlock, EntityID inFurnishing, EntityID inCollectible)
        {
            Precondition.IsInRange(inFloor, All.FloorIDs, nameof(inFloor));
            Precondition.IsInRange(inBlock, All.BlockIDs, nameof(inBlock));
            Precondition.IsInRange(inFurnishing, All.FurnishingIDs, nameof(inFurnishing));
            Precondition.IsInRange(inCollectible, All.CollectibleIDs, nameof(inCollectible));

            Floor = inFloor;
            Block = inBlock;
            Furnishing = inFurnishing;
            Collectible = inCollectible;
        }

        #region Gameplay Algorithm Support
        /// <summary>
        /// Indicates whether this <see cref="ParquetStack"/> is empty.
        /// </summary>
        /// <value><c>true</c> if the stack contains only null references; otherwise, <c>false</c>.</value>
        public bool IsEmpty => EntityID.None == Floor &&
                               EntityID.None == Block &&
                               EntityID.None == Furnishing &&
                               EntityID.None == Collectible;

        /// <summary>
        /// A <see cref="ParquetStack"/> is Enclosing iff:
        /// 1, It has a <see cref="Block"/> that is not <see cref="Block.IsLiquid"/>; or,
        /// 2, It has a <see cref="Furnishing"/> that is <see cref="Furnishing.IsEnclosing"/>.
        /// </summary>
        /// <returns><c>true</c>, if this <see cref="ParquetStack"/> is Enclosing, <c>false</c> otherwise.</returns>
        public bool IsEnclosing
            => !(All.Parquets.Get<Block>(Block)?.IsLiquid ?? true)
            || (All.Parquets.Get<Furnishing>(Furnishing)?.IsEnclosing ?? false);

        /// <summary>
        /// A <see cref="ParquetStack"/> is Entry iff:
        /// 1, It is either Walkable or Enclosing but not both; and,
        /// 2, It has a <see cref="Furnishing"/> that is <see cref="Furnishing.IsEntry"/>.
        /// </summary>
        /// <returns><c>true</c>, if this <see cref="ParquetStack"/> is Entry, <c>false</c> otherwise.</returns>
        internal bool IsEntry
            => All.Parquets.Get<Furnishing>(Furnishing)?.IsEntry ?? false
            // Inequality standing in for missing conditional XOR here.
            && (IsWalkable != IsEnclosing);

        /// <summary>
        /// A <see cref="ParquetStack"/> is considered walkable iff:
        /// 1, It has a <see cref="Floor"/>;
        /// 2, It does not have a <see cref="Block"/>;
        /// 3, It does not have a <see cref="Furnishing"/> that <see cref="Furnishing.IsEnclosing"/>.
        /// </summary>
        /// <returns><c>true</c>, if this <see cref="ParquetStack"/> is Walkable, <c>false</c> otherwise.</returns>
        internal bool IsWalkable
            => Floor != EntityID.None
            && Block == EntityID.None
            && !(All.Parquets.Get<Furnishing>(Furnishing)?.IsEnclosing ?? false);
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for an <see cref="ParquetStack"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public override int GetHashCode()
            => (Floor, Block, Furnishing, Collectible).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="ParquetStack"/> is equal to the current <see cref="ParquetStack"/>.
        /// </summary>
        /// <param name="inStack">The <see cref="ParquetStack"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(ParquetStack inStack)
            => Floor == inStack.Floor
            && Block == inStack.Block
            && Furnishing == inStack.Furnishing
            && Collectible == inStack.Collectible;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="ParquetStack"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="ParquetStack"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is ParquetStack stack && Equals(stack);

        /// <summary>
        /// Determines whether a specified instance of <see cref="ParquetStack"/> is equal to another specified instance of <see cref="ParquetStack"/>.
        /// </summary>
        /// <param name="inStack1">The first <see cref="ParquetStack"/> to compare.</param>
        /// <param name="inStack2">The second <see cref="ParquetStack"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(ParquetStack inStack1, ParquetStack inStack2)
            => inStack1.Floor == inStack2.Floor
            && inStack1.Block == inStack2.Block
            && inStack1.Furnishing == inStack2.Furnishing
            && inStack1.Collectible == inStack2.Collectible;

        /// <summary>
        /// Determines whether a specified instance of <see cref="ParquetStack"/> is not equal to another specified instance of <see cref="ParquetStack"/>.
        /// </summary>
        /// <param name="inStack1">The first <see cref="ParquetStack"/> to compare.</param>
        /// <param name="inStack2">The second <see cref="ParquetStack"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(ParquetStack inStack1, ParquetStack inStack2)
            => inStack1.Floor != inStack2.Floor
            || inStack1.Block != inStack2.Block
            || inStack1.Furnishing != inStack2.Furnishing
            || inStack1.Collectible != inStack2.Collectible;
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see langword="string"/> that represents the current <see cref="ParquetStack"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"[{Floor} {Block} {Furnishing} {Collectible}]";
        #endregion
    }

    /// <summary>
    /// Provides extension methods useful when dealing with 2D arrays of <see cref="ParquetStack"/>s.
    /// </summary>
    public static class ParquetStackArrayExtensions
    {
        /// <summary>
        /// Determines if the given position corresponds to a point within the current array.
        /// </summary>
        /// <param name="inPosition">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public static bool IsValidPosition(this ParquetStack[,] inSubregion, Vector2D inPosition)
        {
            Precondition.IsNotNull(inSubregion, nameof(inSubregion));

            return inPosition.X > -1
                && inPosition.Y > -1
                && inPosition.X < inSubregion.GetLength(1)
                && inPosition.Y < inSubregion.GetLength(0);
        }
    }
}
