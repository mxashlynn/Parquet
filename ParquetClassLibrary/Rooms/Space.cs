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
    }
}
