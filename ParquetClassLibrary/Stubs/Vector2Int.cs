using System;

namespace ParquetClassLibrary.Stubs
{
    /// <summary>
    /// Stand-in for Unity Vector2 class.
    /// </summary>
    public struct Vector2Int : IEquatable<Vector2Int>
    {
        /// <summary>The zero vector.</summary>
        public static readonly Vector2Int ZeroVector = new Vector2Int(0, 0);

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
        /// Initializes a new instance of the <see cref="Vector2Int"/> struct.
        /// </summary>
        /// <param name="in_x">Offset in x.</param>
        /// <param name="in_y">Offset in y.</param>
        public Vector2Int(int in_x, int in_y)
        {
            X = in_x;
            Y = in_y;
            _magnitude = int.MinValue;
        }

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="Vector2Int"/> struct.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures.</returns>
        public override int GetHashCode()
            => (X, Y).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="Vector2Int"/> is equal to the current <see cref="Vector2Int"/>.
        /// </summary>
        /// <param name="in_vector">The <see cref="Vector2Int"/> to compare with the current.</param>
        /// <returns><c>true</c> if the <see cref="Vector2Int"/>s are equal.</returns>
        public bool Equals(Vector2Int in_vector)
            => X == in_vector.X
            && Y == in_vector.Y;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="Vector2Int"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="Vector2Int"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current <see cref="Vector2Int"/>; otherwise, <c>false</c>.</returns>
        // ReSharper disable once InconsistentNaming
        public override bool Equals(object obj)
            => obj is Vector2Int vector && Equals(vector);

        /// <summary>
        /// Determines whether a specified instance of <see cref="ParquetClassLibrary.Stubs.Vector2Int"/> is equal to
        /// another specified instance of <see cref="ParquetClassLibrary.Stubs.Vector2Int"/>.
        /// </summary>
        /// <param name="in_vector1">The first <see cref="ParquetClassLibrary.Stubs.Vector2Int"/> to compare.</param>
        /// <param name="in_vector2">The second <see cref="ParquetClassLibrary.Stubs.Vector2Int"/> to compare.</param>
        /// <returns><c>true</c> if <c>in_vector1</c> and <c>in_vector2</c> are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Vector2Int in_vector1, Vector2Int in_vector2)
            => in_vector1.X == in_vector2.X
            && in_vector1.Y == in_vector2.Y;

        /// <summary>
        /// Determines whether a specified instance of <see cref="ParquetClassLibrary.Stubs.Vector2Int"/> is not equal
        /// to another specified instance of <see cref="ParquetClassLibrary.Stubs.Vector2Int"/>.
        /// </summary>
        /// <param name="in_vector1">The first <see cref="ParquetClassLibrary.Stubs.Vector2Int"/> to compare.</param>
        /// <param name="in_vector2">The second <see cref="ParquetClassLibrary.Stubs.Vector2Int"/> to compare.</param>
        /// <returns><c>true</c> if <c>in_vector1</c> and <c>in_vector2</c> are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Vector2Int in_vector1, Vector2Int in_vector2)
            => in_vector1.X != in_vector2.X
            || in_vector1.Y != in_vector2.Y;
        #endregion

        #region Utility Methods
        /// <summary>
        /// Returns a <see langword="string"/> that represents the current <see cref="Vector2Int"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"({X}, {Y})";
        #endregion
    }
}
