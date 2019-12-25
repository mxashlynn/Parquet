using System;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Map
{
    /// <summary>
    /// A location at which the player moves from one <see cref="MapRegion"/> to another.
    /// </summary>
    /// <remarks>
    /// Since only one Exit Point can exist in a given location, exit points are considered e</remarks>
    public struct ExitPoint : IEquatable<ExitPoint>
    {
        /// <summary>Location of this exit point.</summary>
        public Vector2D Position { get; }

        /// <summary>The region this exit leads to.</summary>
        public Guid Destination { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="ExitPoint"/>.
        /// </summary>
        /// <param name="in_position">The location of this point on its containing region.</param>
        /// <param name="in_guid">The region this exit leads to.</param>
        public ExitPoint(Vector2D in_position, Guid in_guid)
        {
            Destination = in_guid;
            Position = in_position;
        }

        #region IEquatable Implementation
        /// <summary>
        /// Hash function for a <see cref="SpecialPoint"/>.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures.</returns>
        public override int GetHashCode()
            => Position.GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="ExitPoint"/> is equal to the current <see cref="ExitPoint"/>.
        /// </summary>
        /// <param name="in_point">The <see cref="ExitPoint"/> to compare with.</param>
        /// <returns><c>true</c> if the given <see cref="ExitPoint"/> is equal to the current <see cref="ExitPoint"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(ExitPoint in_point)
            => null != in_point && Position == in_point.Position;

        /// <summary>
        /// Determines whether the given <see cref="object"/> is equal to this <see cref="ExitPoint"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current <see cref="SpecialPoint"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is ExitPoint point && Position == point.Position;

        /// <summary>
        /// Determines whether a specified instance of <see cref="SpecialPoint"/>
        /// is equal to another specified instance of <see cref="SpecialPoint"/>.
        /// </summary>
        /// <param name="in_point1">The first <see cref="SpecialPoint"/> to compare.</param>
        /// <param name="in_point2">The second <see cref="SpecialPoint"/> to compare.</param>
        /// <returns><c>true</c> if <c>in_point1</c> and <c>in_point2</c> are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(ExitPoint in_point1, ExitPoint in_point2)
            => in_point1.Position == in_point2.Position;

        /// <summary>
        /// Determines whether a specified instance of <see cref="SpecialPoint"/>
        /// is not equal to another specified <see cref="SpecialPoint"/>.
        /// </summary>
        /// <param name="in_point1">The first <see cref="SpecialPoint"/> to compare.</param>
        /// <param name="in_point2">The second <see cref="SpecialPoint"/> to compare.</param>
        /// <returns>
        /// <c>true</c> if <c>in_point1</c> and <c>in_point2</c> are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(ExitPoint in_point1, ExitPoint in_point2)
            => in_point1.Position != in_point2.Position;
        #endregion
    }
}
