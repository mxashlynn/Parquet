using System;

namespace ParquetClassLibrary.Utilities
{
    /// <summary>
    /// A simple representation of two coordinate integers, tailored for Parquet's needs.
    /// </summary>
    public struct Vector2D : IEquatable<Vector2D>
    {
        /// <summary>The zero vector.</summary>
        public static readonly Vector2D Zero = new Vector2D(0, 0);

        /// <summary>The unit vector.</summary>
        public static readonly Vector2D Unit = new Vector2D(1, 1);

        /// <summary>The vector offset to the North.</summary>
        public static readonly Vector2D North = new Vector2D(0, -1);

        /// <summary>The vector offset to the South.</summary>
        public static readonly Vector2D South = new Vector2D(0, 1);

        /// <summary>The vector offset to the East.</summary>
        public static readonly Vector2D East = new Vector2D(1, 0);

        /// <summary>The vector offset to the West.</summary>
        public static readonly Vector2D West = new Vector2D(-1, 0);

        /// <summary>Offset from origin in x.</summary>
        public readonly int X;

        /// <summary>Offset from origin in y.</summary>
        public readonly int Y;

        /// <summary>The magnitude cached for future reference.</summary>
        private int _magnitude;

        /// <summary>Provides the magnitude of the vector as an integer, rounded-down.</summary>
        /// <value>The magnitude.</value>
        public int Magnitude
        {
            get
            {
                // If this is the first time the value has been accessed, calculate and cache it.
                if (_magnitude == int.MinValue)
                {
                    _magnitude = Convert.ToInt32(Math.Floor(Math.Sqrt(X * X + Y * Y)));
                }
                return _magnitude;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector2D"/> struct.
        /// </summary>
        /// <param name="in_x">Offset in x.</param>
        /// <param name="in_y">Offset in y.</param>
        public Vector2D(int in_x, int in_y)
        {
            X = in_x;
            Y = in_y;
            _magnitude = int.MinValue;
        }

        #region Vector Math
        /// <summary>
        /// Sums the given vectors.
        /// </summary>
        /// <param name="in_vector1">First operand.</param>
        /// <param name="in_vector2">Second operand.</param>
        /// <returns>A vector representing the sum of the given vectors.</returns>
        public static Vector2D operator +(Vector2D in_vector1, Vector2D in_vector2)
            => new Vector2D(in_vector1.X + in_vector2.X, in_vector1.Y + in_vector2.Y);

        /// <summary>
        /// Finds the difference between the given vectors.
        /// </summary>
        /// <param name="in_vector1">First operand.</param>
        /// <param name="in_vector2">Second operand.</param>
        /// <returns>A vector representing the difference of the given vectors.</returns>
        public static Vector2D operator -(Vector2D in_vector1, Vector2D in_vector2)
            => new Vector2D(in_vector1.X - in_vector2.X, in_vector1.Y - in_vector2.Y);

        /// <summary>
        /// Scales a vector.
        /// </summary>
        /// <param name="in_scalar">The scalar.</param>
        /// <param name="in_vector">The vector.</param>
        /// <returns>A scaled vector.</returns>
        public static Vector2D operator *(int in_scalar, Vector2D in_vector)
            => new Vector2D(in_scalar * in_vector.X, in_scalar * in_vector.Y);
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="Vector2D"/> struct.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures.</returns>
        public override int GetHashCode()
            => (X, Y).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="Vector2D"/> is equal to the current <see cref="Vector2D"/>.
        /// </summary>
        /// <param name="in_vector">The <see cref="Vector2D"/> to compare with the current.</param>
        /// <returns><c>true</c> if the <see cref="Vector2D"/>s are equal.</returns>
        public bool Equals(Vector2D in_vector)
            => X == in_vector.X
            && Y == in_vector.Y;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="Vector2D"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="Vector2D"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current <see cref="Vector2D"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is Vector2D vector && Equals(vector);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Vector2D"/> is equal to
        /// another specified instance of <see cref="Vector2D"/>.
        /// </summary>
        /// <param name="in_vector1">The first <see cref="Vector2D"/> to compare.</param>
        /// <param name="in_vector2">The second <see cref="Vector2D"/> to compare.</param>
        /// <returns><c>true</c> if the two operands are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Vector2D in_vector1, Vector2D in_vector2)
            => in_vector1.X == in_vector2.X
            && in_vector1.Y == in_vector2.Y;

        /// <summary>
        /// Determines whether a specified instance of <see cref="Vector2D"/> is not equal
        /// to another specified instance of <see cref="Vector2D"/>.
        /// </summary>
        /// <param name="in_vector1">The first <see cref="Vector2D"/> to compare.</param>
        /// <param name="in_vector2">The second <see cref="Vector2D"/> to compare.</param>
        /// <returns><c>true</c> if the two operands are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Vector2D in_vector1, Vector2D in_vector2)
            => in_vector1.X != in_vector2.X
            || in_vector1.Y != in_vector2.Y;
        #endregion

        #region Utility Methods
        /// <summary>
        /// Returns a <see langword="string"/> that represents the current <see cref="Vector2D"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"({X}, {Y})";
        #endregion
    }
}
