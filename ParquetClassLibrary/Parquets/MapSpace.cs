using System;
using System.Collections.Generic;
using System.Linq;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// A <see cref="ParquetStack"/> together with its coordinates within a given <see cref="Map.MapRegion"/>.
    /// </summary>
    public struct MapSpace : IEquatable<MapSpace>
    {
        /// <summary>The null <see cref="MapSpace"/>, which exists nowhere and contains nothing.</summary>
        public static readonly MapSpace Empty = new MapSpace(new Vector2D(int.MinValue, int.MinValue), ParquetStack.Empty);

        /// <summary>Location of this <see cref="MapSpace"/>.</summary>
        public readonly Vector2D Position;

        /// <summary>All parquets occupying this <see cref="MapSpace"/>.</summary>
        public readonly ParquetStack Content;

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="MapSpace"/> class.
        /// </summary>
        /// <param name="in_position">Location of this <see cref="MapSpace"/>.</param>
        /// <param name="in_content">All parquets occupying this <see cref="MapSpace"/>.</param>
        public MapSpace(Vector2D in_position, ParquetStack in_content)
        {
            Position = in_position;
            Content = in_content;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapSpace"/> class.
        /// </summary>
        /// <param name="in_x">X-coordinate of this <see cref="MapSpace"/>.</param>
        /// <param name="in_y">Y-coordinate of this <see cref="MapSpace"/>.</param>
        /// <param name="in_content">All parquets occupying this <see cref="MapSpace"/>.</param>
        public MapSpace(int in_x, int in_y, ParquetStack in_content)
        {
            Position = new Vector2D(in_x, in_y);
            Content = in_content;
        }
        #endregion

        #region Position Offsets
        /// <summary>Finds the <see cref="MapSpace"/> related to the given space by the given offset, if any.</summary>
        /// <param name="in_subregion">The subregion containing the <see cref="MapSpace"/>s.</param>
        /// <returns>A <see cref="MapSpace"/> if it exists, or <see cref="Empty"/> otherwise.</returns>
        public MapSpace Neighbor(ParquetStack[,] in_subregion, Vector2D in_offset)
        {
            var offsetPosition = Position + in_offset;
            return in_subregion.IsValidPosition(offsetPosition)
                ? new MapSpace(offsetPosition, in_subregion[offsetPosition.Y, offsetPosition.X])
                : Empty;
        }

        /// <summary>Finds the <see cref="MapSpace"/> to the north of the given space, if any.</summary>
        /// <param name="in_subregion">The subregion containing the <see cref="MapSpace"/>s.</param>
        /// <returns>A <see cref="MapSpace"/> if it exists, or <see cref="Empty"/> otherwise.</returns>
        public MapSpace NorthNeighbor(ParquetStack[,] in_subregion)
            => Neighbor(in_subregion, Vector2D.North);

        /// <summary>Finds the <see cref="MapSpace"/> to the south of the given space, if any.</summary>
        /// <param name="in_subregion">The subregion containing the <see cref="MapSpace"/>s.</param>
        /// <returns>A <see cref="MapSpace"/> if it exists, or <see cref="Empty"/> otherwise.</returns>
        public MapSpace SouthNeighbor(ParquetStack[,] in_subregion)
            => Neighbor(in_subregion, Vector2D.South);

        /// <summary>Finds the <see cref="MapSpace"/> to the east of the given space, if any.</summary>
        /// <param name="in_subregion">The subregion containing the <see cref="MapSpace"/>s.</param>
        /// <returns>A <see cref="MapSpace"/> if it exists, or <see cref="Empty"/> otherwise.</returns>
        public MapSpace EastNeighbor(ParquetStack[,] in_subregion)
            => Neighbor(in_subregion, Vector2D.East);

        /// <summary>Finds the <see cref="MapSpace"/> to the west of the given space, if any.</summary>
        /// <param name="in_subregion">The subregion containing the <see cref="MapSpace"/>s.</param>
        /// <returns>A <see cref="MapSpace"/> if it exists, or <see cref="Empty"/> otherwise.</returns>
        public MapSpace WestNeighbor(ParquetStack[,] in_subregion)
            => Neighbor(in_subregion, Vector2D.West);

        /// <summary>Finds the <see cref="MapSpace"/> related to the given space by the given offset, if any.</summary>
        /// <param name="in_subregion">The subregion containing the <see cref="MapSpace"/>s.</param>
        /// <returns>A <see cref="MapSpace"/> if it exists, or <see cref="Empty"/> otherwise.</returns>
        public List<MapSpace> Neighbors(ParquetStack[,] in_subregion)
            => new List<MapSpace>
            {
                NorthNeighbor(in_subregion),
                SouthNeighbor(in_subregion),
                EastNeighbor(in_subregion),
                WestNeighbor(in_subregion),
            };
        #endregion

        #region Gameplay Support
        /// <summary>
        /// Indicates whether this <see cref="ParquetStack"/> is empty.
        /// </summary>
        /// <value><c>true</c> if the stack contains only null references; otherwise, <c>false</c>.</value>
        public bool IsEmpty => EntityID.None == Content.Floor &&
                               EntityID.None == Content.Block &&
                               EntityID.None == Content.Furnishing &&
                               EntityID.None == Content.Collectible;

        /// <summary>
        /// A <see cref="MapSpace"/> is Enclosing iff:
        /// 1, It has a <see cref="Block"/> that is not <see cref="Block.IsLiquid"/>; or,
        /// 2, It has a <see cref="Furnishing"/> that is <see cref="Furnishing.IsEnclosing"/>.
        /// </summary>
        /// <returns><c>true</c>, if this <see cref="MapSpace"/> is Enclosing, <c>false</c> otherwise.</returns>
        public bool IsEnclosing
            => Content.IsEnclosing;

        /// <summary>
        /// A <see cref="MapSpace"/> is Entry iff:
        /// 1, Its <see cref="Content"/> is either Walkable or Enclosing; and,
        /// 2, It has a <see cref="Furnishing"/> that is <see cref="Furnishing.IsEntry"/>.
        /// </summary>
        /// <returns><c>true</c>, if this <see cref="MapSpace"/> is Entry, <c>false</c> otherwise.</returns>
        internal bool IsEntry
            => Content.IsEntry;

        /// <summary>
        /// A <see cref="MapSpace"/> is Walkable iff:
        /// 1, It has a <see cref="Floor"/>;
        /// 2, It does not have a <see cref="Block"/>;
        /// 3, It does not have a <see cref="Furnishing"/> that is not <see cref="Furnishing.IsEnclosing"/>.
        /// </summary>
        /// <returns><c>true</c>, if this <see cref="MapSpace"/> is Walkable, <c>false</c> otherwise.</returns>
        internal bool IsWalkable
            => Content.IsWalkable;

        #region Neighbor-Relative Gameplay Algorithm Support
        /// <summary>
        /// Determines if this <see cref="Content"/> is both <see cref="ParquetStack.IsEntry"/>
        /// and <see cref="ParquetStack.IsWalkable"/>.
        /// </summary>
        /// <seealso cref="IsEnclosingEntry"/>
        /// <returns><c>true</c>, if this <see cref="MapSpace"/> may be used as a walkable entry by a <see cref="Room"/>, <c>false</c> otherwise.</returns>
        internal bool IsWalkableEntry
            => All.Parquets.Get<Furnishing>(Content.Furnishing)?.IsEntry ?? false
            && Content.IsWalkable;

        /// <summary>
        /// Determines if this <see cref="MapSpace"/> is:
        /// 1) <see cref="ParquetStack.IsEntry"/>
        /// 2) <see cref="ParquetStack.IsEnclosing"/>
        /// 3) has one walkable neighbor that is within the given <see cref="MapSpaceCollection"/> and one not within it.
        /// </summary>
        /// <seealso cref="IsWalkableEntry"/>
        /// <returns><c>true</c>, if this <see cref="MapSpace"/> may be used as an enclosing entry by a <see cref="Room"/>, <c>false</c> otherwise.</returns>
        internal bool IsEnclosingEntry(ParquetStack[,] in_subregion, MapSpaceCollection in_walkableArea)
        
        {
            // NOTE This logic fails when evaluated as a single if-statement, incorrectly reporting
            // that a neighbor2 exists that is not a part of in_walkableArea.  I have not yet
            // tracked down the cause of this failure.
            if (All.Parquets.Get<Furnishing>(Content.Furnishing)?.IsEntry ?? false
                && Content.IsEnclosing
                && Neighbors(in_subregion).Any(neighbor1 => in_walkableArea.Contains(neighbor1)))
            {
                if (Neighbors(in_subregion).Any(neighbor2 => !in_walkableArea.Contains(neighbor2)
                                                          && neighbor2.Content.IsWalkable))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="MapSpace"/> struct.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures.</returns>
        public override int GetHashCode()
            => (Position, Content).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="MapSpace"/> is equal to the current <see cref="MapSpace"/>.
        /// </summary>
        /// <param name="in_space">The <see cref="MapSpace"/> to compare with the current.</param>
        /// <returns><c>true</c> if the <see cref="MapSpace"/>s are equal.</returns>
        public bool Equals(MapSpace in_space)
            => Position == in_space.Position
            && Content == in_space.Content;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="MapSpace"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="MapSpace"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current <see cref="MapSpace"/>; otherwise, <c>false</c>.</returns>
        // ReSharper disable once InconsistentNaming
        public override bool Equals(object obj)
            => obj is MapSpace vector && Equals(vector);

        /// <summary>
        /// Determines whether a specified instance of <see cref="MapSpace"/> is equal to
        /// another specified instance of <see cref="MapSpace"/>.
        /// </summary>
        /// <param name="in_space1">The first <see cref="MapSpace"/> to compare.</param>
        /// <param name="in_space2">The second <see cref="MapSpace"/> to compare.</param>
        /// <returns><c>true</c> if the two operands are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(MapSpace in_space1, MapSpace in_space2)
            => in_space1.Position == in_space2.Position
            && in_space1.Content == in_space2.Content;

        /// <summary>
        /// Determines whether a specified instance of <see cref="MapSpace"/> is unequal to
        /// another specified instance of <see cref="MapSpace"/>.
        /// </summary>
        /// <param name="in_space1">The first <see cref="MapSpace"/> to compare.</param>
        /// <param name="in_space2">The second <see cref="MapSpace"/> to compare.</param>
        /// <returns><c>true</c> if the two operands are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(MapSpace in_space1, MapSpace in_space2)
            => in_space1.Position != in_space2.Position
            && in_space1.Content != in_space2.Content;
        #endregion

        #region Utility Methods
        /// <summary>
        /// Returns a <see langword="string"/> that represents the current <see cref="ParquetStack"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"{Position}{Content}]";
        #endregion
    }
}