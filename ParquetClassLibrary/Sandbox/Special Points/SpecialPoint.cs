using System;
using ParquetClassLibrary.Stubs;

namespace ParquetClassLibrary.Sandbox.SpecialPoints
{
    public class SpecialPoint : IEquatable<SpecialPoint>
    {
        /// <summary>Location of this point.</summary>
        public Vector2Int Position { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="T:ParquetClassLibrary.Sandbox.SpecialPoints.SpecialPoint"/>.
        /// </summary>
        /// <param name="in_position">The location of this point.</param>
        public SpecialPoint(Vector2Int in_position)
        {
            Position = in_position;
        }

        #region Implements IEquatable
        /// <summary>
        /// Hash function for a <see cref="T:ParquetClassLibrary.Sandbox.SpecialPoints.SpecialPoint"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures.</returns>
        public override int GetHashCode() => Position.GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="ParquetClassLibrary.Sandbox.SpecialPoints.SpecialPoint"/> is
        /// equal to the current <see cref="T:ParquetClassLibrary.Sandbox.SpecialPoints.SpecialPoint"/>.
        /// </summary>
        /// <param name="in_point">
        /// The <see cref="ParquetClassLibrary.Sandbox.SpecialPoints.SpecialPoint"/> to compare with.
        /// </param>
        /// <returns>
        /// <c>true</c> if the given <see cref="ParquetClassLibrary.Sandbox.SpecialPoints.SpecialPoint"/> is equal
        /// to the current <see cref="T:ParquetClassLibrary.Sandbox.SpecialPoints.SpecialPoint"/>;
        /// otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(SpecialPoint in_point)
        {
            return null != in_point
                   && Position.X == in_point.Position.X
                   && Position.Y == in_point.Position.Y;
        }

        /// <summary>
        /// Determines whether the given <see cref="object"/> is equal to this <see cref="T:ParquetClassLibrary.Sandbox.SpecialPoints.SpecialPoint"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="object"/> is equal to the current
        /// <see cref="T:ParquetClassLibrary.Sandbox.SpecialPoints.SpecialPoint"/>; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            var point = obj as SpecialPoint;
            return point != null
                && Equals(point);
        }

        /// <summary>
        /// Determines whether a specified instance of <see cref="ParquetClassLibrary.Sandbox.SpecialPoints.SpecialPoint"/>
        /// is equal to another specified instance of <see cref="ParquetClassLibrary.Sandbox.SpecialPoints.SpecialPoint"/>.
        /// </summary>
        /// <param name="in_point1">The first <see cref="ParquetClassLibrary.Sandbox.SpecialPoints.SpecialPoint"/> to compare.</param>
        /// <param name="in_point2">The second <see cref="ParquetClassLibrary.Sandbox.SpecialPoints.SpecialPoint"/> to compare.</param>
        /// <returns><c>true</c> if <c>in_point1</c> and <c>in_point2</c> are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(SpecialPoint in_point1, SpecialPoint in_point2)
        {
            if (object.ReferenceEquals(in_point1, in_point2)) return true;
            if (object.ReferenceEquals(in_point1, null)) return false;
            if (object.ReferenceEquals(in_point2, null)) return false;

            return in_point1.Equals(in_point2);
        }

        /// <summary>
        /// Determines whether a specified instance of <see cref="ParquetClassLibrary.Sandbox.SpecialPoints.SpecialPoint"/>
        /// is not equal to another specified <see cref="ParquetClassLibrary.Sandbox.SpecialPoints.SpecialPoint"/>.
        /// </summary>
        /// <param name="in_point1">The first <see cref="ParquetClassLibrary.Sandbox.SpecialPoints.SpecialPoint"/> to compare.</param>
        /// <param name="in_point2">The second <see cref="ParquetClassLibrary.Sandbox.SpecialPoints.SpecialPoint"/> to compare.</param>
        /// <returns>
        /// <c>true</c> if <c>in_point1</c> and <c>in_point2</c> are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(SpecialPoint in_point1, SpecialPoint in_point2)
        {
            if (object.ReferenceEquals(in_point1, in_point2)) return false;
            if (object.ReferenceEquals(in_point1, null)) return true;
            if (object.ReferenceEquals(in_point2, null)) return true;

            return !in_point1.Equals(in_point2);
        }
        #endregion
    }
}
