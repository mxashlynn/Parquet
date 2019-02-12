using System;
namespace ParquetClassLibrary.Stubs
{
    /// <summary>
    /// Stand-in for Unity Vector2 class.
    /// </summary>
    public struct Vector2Int
    {
        /// <summary>The zero vector.</summary>
        public static readonly Vector2Int ZeroVector = new Vector2Int(0, 0);

        /// <summary>Offset from origin in x.</summary>
        public readonly int x;

        /// <summary>Offset from origin in y.</summary>
        public readonly int y;

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
                    _magnitude = Convert.ToInt32(Math.Floor(Math.Sqrt(x * x + y * y)));
                }
                return _magnitude;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ParquetClassLibrary.Stubs.Vector2Int"/> struct.
        /// </summary>
        /// <param name="in_x">Offset in x.</param>
        /// <param name="in_y">Offset in y.</param>
        public Vector2Int(int in_x, int in_y)
        {
            x = in_x;
            y = in_y;
            _magnitude = int.MinValue;
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="T:ParquetClassLibrary.Stubs.Vector2Int"/> struct.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures.</returns>
        public override int GetHashCode()
        {
            return x.GetHashCode() ^ (y.GetHashCode() << 2);
        }
    }
}