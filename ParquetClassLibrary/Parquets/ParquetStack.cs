using System;
using System.Collections.Generic;
using ParquetClassLibrary.Stubs;
using ParquetClassLibrary.Utilities;
using ParquetClassLibrary.Rooms;

namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// Simple container for one of each layer of parquet that can occupy the same position.
    /// </summary>
    public struct ParquetStack : IParquetStack, IEquatable<ParquetStack>
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
            Precondition.IsInRange(in_block, All.BlockIDs, nameof(in_block));
            Precondition.IsInRange(in_furnishing, All.FurnishingIDs, nameof(in_furnishing));
            Precondition.IsInRange(in_collectible, All.CollectibleIDs, nameof(in_collectible));

            Floor = in_floor;
            Block = in_block;
            Furnishing = in_furnishing;
            Collectible = in_collectible;
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
        /// 1, It is either Walkable or Enclosing; and,
        /// 2, It has a <see cref="Furnishing"/> that is <see cref="Furnishing.IsEntry"/>.
        /// </summary>
        /// <returns><c>true</c>, if this <see cref="ParquetStack"/> is Entry, <c>false</c> otherwise.</returns>
        internal bool IsEntry
            => All.Parquets.Get<Furnishing>(Furnishing)?.IsEntry ?? false
            && (IsWalkable ^ IsEnclosing);

        /// <summary>
        /// A <see cref="ParquetStack"/> is considered walkable iff:
        /// 1, It has a <see cref="Floor"/>;
        /// 2, It does not have a <see cref="Block"/>;
        /// 3, It does not have a <see cref="Furnishing"/> that is not <see cref="Furnishing.IsEnclosing"/>.
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
        /// <param name="in_stack">The <see cref="ParquetStack"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(ParquetStack in_stack)
            => Floor == in_stack.Floor
            && Block == in_stack.Block
            && Furnishing == in_stack.Furnishing
            && Collectible == in_stack.Collectible;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="ParquetStack"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="ParquetStack"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        // ReSharper disable once InconsistentNaming
        public override bool Equals(object obj)
            => obj is ParquetStack stack && Equals(stack);

        /// <summary>
        /// Determines whether a specified instance of <see cref="ParquetStack"/> is equal to another specified instance of <see cref="ParquetStack"/>.
        /// </summary>
        /// <param name="in_stack1">The first <see cref="ParquetStack"/> to compare.</param>
        /// <param name="in_stack2">The second <see cref="ParquetStack"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(ParquetStack in_stack1, ParquetStack in_stack2)
            => in_stack1.Floor == in_stack2.Floor
            && in_stack1.Block == in_stack2.Block
            && in_stack1.Furnishing == in_stack2.Furnishing
            && in_stack1.Collectible == in_stack2.Collectible;

        /// <summary>
        /// Determines whether a specified instance of <see cref="ParquetStack"/> is not equal to another specified instance of <see cref="ParquetStack"/>.
        /// </summary>
        /// <param name="in_stack1">The first <see cref="ParquetStack"/> to compare.</param>
        /// <param name="in_stack2">The second <see cref="ParquetStack"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(ParquetStack in_stack1, ParquetStack in_stack2)
            => in_stack1.Floor != in_stack2.Floor
            || in_stack1.Block != in_stack2.Block
            || in_stack1.Furnishing != in_stack2.Furnishing
            || in_stack1.Collectible != in_stack2.Collectible;
        #endregion

        #region Utility Methods
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
        /// <param name="in_position">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public static bool IsValidPosition(this ParquetStack[,] in_subregion, Vector2Int in_position)
            => in_position.X > -1
            && in_position.Y > -1
            && in_position.X < in_subregion.GetLength(1)
            && in_position.Y < in_subregion.GetLength(0);

        /// <summary>
        /// Returns the set of <see cref="Space"/>s corresponding to the subregion.
        /// </summary>
        /// <param name="in_subregion">The collection of <see cref="ParquetStack"/>s to consider.</param>
        /// <returns>The <see cref="Space"/>s defined by this subregion.</returns>
        public static SpaceCollection GetSpaces(this ParquetStack[,] in_subregion)
        {
            var uniqueResults = new HashSet<Space>();
            var subregionRows = in_subregion.GetLength(0);
            var subregionCols = in_subregion.GetLength(1);

            for (var y = 0; y < subregionRows; y++)
            {
                for (var x = 0; x < subregionCols; x++)
                {
                    var currentSpace = new Space(x, y, in_subregion[y, x]);
                    uniqueResults.Add(currentSpace);
                }
            }

            return new SpaceCollection(uniqueResults);
        }
    }
}
