using ParquetClassLibrary.Stubs;

namespace ParquetClassLibrary.Sandbox.SpecialPoints
{
    /// <summary>
    /// The location at which a character spawns.
    /// </summary>
    public class SpawnPoint : SpecialPoint
    {
        /// <summary>The character that spawns at this location.</summary>
        public SpawnType WhatToSpawn { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="T:ParquetClassLibrary.Sandbox.SpecialPoints.SpawnPoint"/>.
        /// </summary>
        /// <param name="in_position">The location of this point.</param>
        /// <param name="in_whatToSpawn">The entity that spawns in this location.</param>
        public SpawnPoint(Vector2Int in_position, SpawnType in_whatToSpawn) : base(in_position)
           => WhatToSpawn = in_whatToSpawn;
    }
}
