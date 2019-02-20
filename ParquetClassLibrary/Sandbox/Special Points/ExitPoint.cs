using System;
using ParquetClassLibrary.Stubs;

namespace ParquetClassLibrary.Sandbox.SpecialPoints
{
    public class ExitPoint : SpecialPoint
    {
        /// <summary>The region this exit leads to.</summary>
        public Guid Destination { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="T:ParquetClassLibrary.Sandbox.SpecialPoints.ExitPoint"/>.
        /// </summary>
        /// <param name="in_position">The location of this point on its containing region.</param>
        /// <param name="in_guid">The region this exit leads to.</param>
        public ExitPoint(Vector2Int in_position, Guid in_guid) : base(in_position)
           => Destination = in_guid;
    }
}
