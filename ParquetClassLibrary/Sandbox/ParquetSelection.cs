using System;

namespace ParquetClassLibrary.Sandbox
{
    /// <summary>
    /// Models which, if any, parquet layers have been selected (for instance in the map editor).
    /// </summary>
    [Flags]
    internal enum ParquetSelection
    {
        None        = 0,
        Floor       = 1,
        Block       = 2,
        Furnishing  = 4,
        Collectable = 8,
    }
}