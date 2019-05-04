namespace ParquetClassLibrary.Characters
{
    /// <summary>
    /// The way a <see cref="Being"/> acts, on their own on the <see cref="ParquetClassLibrary.Sandbox.MapRegion"/>.
    /// </summary>
    public enum Behavior
    {
        // TODO Update these with more reasonable values.
        // TODO Will this actually be expanded into a class that governs behavior?
        PlayerControlled,
        Still,
        Homebody,
        Adventurer,
    }
}
