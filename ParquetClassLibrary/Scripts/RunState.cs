namespace ParquetClassLibrary.Scripts
{
    /// <summary>
    /// Status of a <see cref="ScriptModel"/> in an <see cref="InteractionModel"/>.
    /// </summary>
    public enum RunState
    {
        /// <summary>This script has not yet begun execution.</summary>
        Unstarted,
        /// <summary>This script is currently executing.</summary>
        InProgress,
        /// <summary>This script is completed execution.</summary>
        Completed,
    }
}
