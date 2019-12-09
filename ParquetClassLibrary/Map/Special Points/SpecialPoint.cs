using System;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Map.SpecialPoints
{
    /// <summary>
    /// A location on a <see cref="MapParent"/> at which something happens
    /// that cannot be determined from Parquet mechanics alone.  For example, critter spawning.
    /// </summary>
    public class SpecialPoint : IEquatable<SpecialPoint>
    {
        /// <summary>Location of this point.</summary>
        public Vector2D Position { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="SpecialPoint"/>.
        /// </summary>
        /// <param name="in_position">The location of this point.</param>
        public SpecialPoint(Vector2D in_position)
        {
            Position = in_position;
        }

        #region Implements IEquatable
        /// <summary>
        /// Hash function for a <see cref="SpecialPoint"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures.</returns>
        public override int GetHashCode()
            => Position.GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="SpecialPoint"/> is equal to the current <see cref="SpecialPoint"/>.
        /// </summary>
        /// <param name="in_point">The <see cref="SpecialPoint"/> to compare with.</param>
        /// <returns><c>true</c> if the given <see cref="SpecialPoint"/> is equal to the current <see cref="SpecialPoint"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(SpecialPoint in_point)
            => null != in_point && Position == in_point.Position;

        /// <summary>
        /// Determines whether the given <see cref="object"/> is equal to this <see cref="SpecialPoint"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current <see cref="SpecialPoint"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is SpecialPoint point && Equals(point);

        /// <summary>
        /// Determines whether a specified instance of <see cref="SpecialPoint"/>
        /// is equal to another specified instance of <see cref="SpecialPoint"/>.
        /// </summary>
        /// <param name="in_point1">The first <see cref="SpecialPoint"/> to compare.</param>
        /// <param name="in_point2">The second <see cref="SpecialPoint"/> to compare.</param>
        /// <returns><c>true</c> if <c>in_point1</c> and <c>in_point2</c> are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(SpecialPoint in_point1, SpecialPoint in_point2)
            => (in_point1 is null && in_point2 is null)
            || (!(in_point1 is null) && !(in_point2 is null) && in_point1.Position == in_point2.Position);

        /// <summary>
        /// Determines whether a specified instance of <see cref="SpecialPoint"/>
        /// is not equal to another specified <see cref="SpecialPoint"/>.
        /// </summary>
        /// <param name="in_point1">The first <see cref="SpecialPoint"/> to compare.</param>
        /// <param name="in_point2">The second <see cref="SpecialPoint"/> to compare.</param>
        /// <returns>
        /// <c>true</c> if <c>in_point1</c> and <c>in_point2</c> are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(SpecialPoint in_point1, SpecialPoint in_point2)
            => (!(in_point1 is null) && !(in_point2 is null) && in_point1.Position != in_point2.Position)
            || (!(in_point1 is null) && in_point2 is null)
            || (in_point1 is null && !(in_point2 is null));
        #endregion
    }
}
