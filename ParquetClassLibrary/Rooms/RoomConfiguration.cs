namespace ParquetClassLibrary.Rooms
{
    /// <summary>
    /// Provides parameters for <see cref="Room"/>s.
    /// </summary>
    // TODO Make this configurable via CSV.
    public static class RoomConfiguration
    {
        /// <summary>Minimum number of open walkable spaces needed for any room to register.</summary>
        // TODO Make this configurable via CSV.
        public const int MinWalkableSpaces = 4;

        /// <summary>Maximum number of open walkable spaces needed for any room to register.</summary>
        // TODO Make this configurable via CSV.
        public const int MaxWalkableSpaces = 121;

        /// <summary>Minimum number of enclosing spaces needed for any room to register.</summary>
        public static int MinPerimeterSpaces => MinWalkableSpaces * 3;
    }
}
