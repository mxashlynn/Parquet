using System;
using ParquetClassLibrary.Stubs;

namespace ParquetClassLibrary.Sandbox
{
    /// <summary>
    /// Represents a specific position within a specific <see cref="MapRegion"/>.
    /// </summary>
    public struct Location
    {
        /// <summary>The identifier for the <see cref="MapRegion"/> this character is located in.</summary>
        public Guid RegionID;

        /// <summary>The position within the current <see cref="MapRegion"/> where this character is located.</summary>
        public Vector2Int Position;

        /// <summary>
        /// Describes the <see cref="Location"/> as a <see cref="string"/>.
        /// </summary>
        /// <returns>A <see cref="string"/> that represents the current <see cref="Location"/>.</returns>
        public override string ToString()
        {
            return $"{Position} in {RegionID}";
        }
    }
}
