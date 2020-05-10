namespace ParquetClassLibrary.Scripts
{
    /// <summary>
    /// Whether and how a <see cref="Furnishing"/> communicates to an adjacent <see cref="Maps.MapRegion"/>.
    /// </summary>
    public enum ExitType
    {
        /// <summary>This furnishing does not communicate to another map.</summary>
        None,
        /// <summary>This furnishing communicates to the map above.</summary>
        Up,
        /// <summary>This furnishing communicates to the map below.</summary>
        Down,
    }
}
