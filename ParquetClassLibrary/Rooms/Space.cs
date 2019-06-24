using System;
using ParquetClassLibrary.Parquets;
#if UNITY_2018_4_OR_NEWER
using UnityEngine;
#else
using ParquetClassLibrary.Stubs;
#endif

namespace ParquetClassLibrary.Rooms
{
    /// <summary>
    /// A <see cref="ParquetStack"/> together with its coordinates within a given <see cref="Map.MapRegion"/>.
    /// </summary>
    public struct Space : IEquatable<Space>
    {
        /// <summary>The null <see cref="Space"/>, which exists nowhere and contains nothing.</summary>
        public static readonly Space Empty = new Space(new Vector2Int(int.MinValue, int.MinValue), ParquetStack.Empty);

        /// <summary>Location of this <see cref="Space"/>.</summary>
        public readonly Vector2Int Position;

        /// <summary>All parquets occupying this <see cref="Space"/>.</summary>
        public readonly ParquetStack Content;

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="Space"/> class.
        /// </summary>
        /// <param name="in_position">Location of this <see cref="Space"/>.</param>
        /// <param name="in_content">All parquets occupying this <see cref="Space"/>.</param>
        public Space(Vector2Int in_position, ParquetStack in_content)
        {
            Position = in_position;
            Content = in_content;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Space"/> class.
        /// </summary>
        /// <param name="in_x">X-coordinate of this <see cref="Space"/>.</param>
        /// <param name="in_y">Y-coordinate of this <see cref="Space"/>.</param>
        /// <param name="in_content">All parquets occupying this <see cref="Space"/>.</param>
        public Space(int in_x, int in_y, ParquetStack in_content)
        {
            Position = new Vector2Int(in_x, in_y);
            Content = in_content;
        }
        #endregion

        #region Position Offsets
        /// <summary>Finds the <see cref="Space"/> related to the given space by the given offset, if any.</summary>
        /// <param name="in_subregion">The subregion containing the <see cref="Space"/>s.</param>
        /// <param name="in_isValid"><c>true</c> when the given position is defined for the given subregion.</param>
        /// <returns>A <see cref="Space"/> if it exists, or <see cref="Empty"/> otherwise.</returns>
        public Space Neighbor(ParquetStack[,] in_subregion, Predicate<Vector2Int> in_isValid, Vector2Int in_offset)
        {
            var offsetPosition = Position + in_offset;
            return in_isValid(offsetPosition)
                ? new Space(offsetPosition, in_subregion[offsetPosition.Y, offsetPosition.X])
                : Empty;
        }

        /// <summary>Finds the <see cref="Space"/> to the north of the given space, if any.</summary>
        /// <param name="in_subregion">The subregion containing the <see cref="Space"/>s.</param>
        /// <param name="in_isValid"><c>true</c> when the given position is defined for the given subregion.</param>
        /// <returns>A <see cref="Space"/> if it exists, or <see cref="Empty"/> otherwise.</returns>
        public Space NorthNeighbor(ParquetStack[,] in_subregion, Predicate<Vector2Int> in_isValid)
            => Neighbor(in_subregion, in_isValid, Vector2Int.North);

        /// <summary>Finds the <see cref="Space"/> to the south of the given space, if any.</summary>
        /// <param name="in_subregion">The subregion containing the <see cref="Space"/>s.</param>
        /// <param name="in_isValid"><c>true</c> when the given position is defined for the given subregion.</param>
        /// <returns>A <see cref="Space"/> if it exists, or <see cref="Empty"/> otherwise.</returns>
        public Space SouthNeighbor(ParquetStack[,] in_subregion, Predicate<Vector2Int> in_isValid)
            => Neighbor(in_subregion, in_isValid, Vector2Int.South);

        /// <summary>Finds the <see cref="Space"/> to the east of the given space, if any.</summary>
        /// <param name="in_subregion">The subregion containing the <see cref="Space"/>s.</param>
        /// <param name="in_isValid"><c>true</c> when the given position is defined for the given subregion.</param>
        /// <returns>A <see cref="Space"/> if it exists, or <see cref="Empty"/> otherwise.</returns>
        public Space EastNeighbor(ParquetStack[,] in_subregion, Predicate<Vector2Int> in_isValid)
            => Neighbor(in_subregion, in_isValid, Vector2Int.East);

        /// <summary>Finds the <see cref="Space"/> to the west of the given space, if any.</summary>
        /// <param name="in_subregion">The subregion containing the <see cref="Space"/>s.</param>
        /// <param name="in_isValid"><c>true</c> when the given position is defined for the given subregion.</param>
        /// <returns>A <see cref="Space"/> if it exists, or <see cref="Empty"/> otherwise.</returns>
        public Space WestNeighbor(ParquetStack[,] in_subregion, Predicate<Vector2Int> in_isValid)
            => Neighbor(in_subregion, in_isValid, Vector2Int.West);
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="Space"/> struct.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures.</returns>
        public override int GetHashCode()
            => (Position, Content).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="Space"/> is equal to the current <see cref="Space"/>.
        /// </summary>
        /// <param name="in_space">The <see cref="Space"/> to compare with the current.</param>
        /// <returns><c>true</c> if the <see cref="Space"/>s are equal.</returns>
        public bool Equals(Space in_space)
            => Position == in_space.Position
            && Content == in_space.Content;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="Space"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="Space"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current <see cref="Space"/>; otherwise, <c>false</c>.</returns>
        // ReSharper disable once InconsistentNaming
        public override bool Equals(object obj)
            => obj is Space vector && Equals(vector);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Space"/> is equal to
        /// another specified instance of <see cref="Space"/>.
        /// </summary>
        /// <param name="in_space1">The first <see cref="Space"/> to compare.</param>
        /// <param name="in_space2">The second <see cref="Space"/> to compare.</param>
        /// <returns><c>true</c> if the two operands are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Space in_space1, Space in_space2)
            => in_space1.Position == in_space2.Position
            && in_space1.Content == in_space2.Content;

        /// <summary>
        /// Determines whether a specified instance of <see cref="Space"/> is unequal to
        /// another specified instance of <see cref="Space"/>.
        /// </summary>
        /// <param name="in_space1">The first <see cref="Space"/> to compare.</param>
        /// <param name="in_space2">The second <see cref="Space"/> to compare.</param>
        /// <returns><c>true</c> if the two operands are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Space in_space1, Space in_space2)
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
