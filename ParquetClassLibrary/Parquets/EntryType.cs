namespace ParquetClassLibrary.Scripts
{
    /// <summary>
    /// Whether and how a <see cref="Furnishing"/> communicates to an adjacent <see cref="Maps.MapRegion"/>.
    /// </summary>
    public enum EntryType
    {
        /// <summary>This furnishing does not communicate to another map or room.</summary>
        None,
        /// <summary>This furnishing communicates between rooms on the same map.</summary>
        Room,
        /// <summary>This furnishing communicates to the map above.</summary>
        Up,
        /// <summary>This furnishing communicates to the map below.</summary>
        Down,
    }
}
