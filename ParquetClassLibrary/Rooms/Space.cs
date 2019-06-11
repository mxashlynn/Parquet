using ParquetClassLibrary.Parquets;
#if UNITY_2018_4_OR_NEWER
using UnityEngine;
#else
using ParquetClassLibrary.Stubs;
#endif

namespace ParquetClassLibrary.Rooms
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
    }
}
