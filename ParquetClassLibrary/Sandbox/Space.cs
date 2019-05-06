using ParquetClassLibrary.Sandbox.Parquets;
using ParquetClassLibrary.Stubs;

namespace ParquetClassLibrary.Sandbox
{
    /// <summary>
    /// A <see cref="ParquetStack"/> together with its coordinates on the world map.
    /// </summary>
    public struct Space
    {
        /// <summary>The null <see cref="Space"/>, representing an arbitrary empty <see cref="ParquetStack"/>.</summary>
        public static readonly Space Empty = new Space(Vector2Int.ZeroVector, ParquetStack.Empty);

        /// <summary>Location of this <see cref="Space"/>.</summary>
        public readonly Vector2Int Position;

        /// <summary>All parquets occupying this <see cref="Space"/>.</summary>
        public readonly ParquetStack Content;

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
    }
}
