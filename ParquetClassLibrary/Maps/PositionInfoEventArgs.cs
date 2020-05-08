using System;
using ParquetClassLibrary.Parquets;

namespace ParquetClassLibrary.Maps
{
    /// <summary>
    /// Indicates that the encapsulated info corresponding to a particular position in the current map
    /// is ready to be displayed.
    /// </summary>
    public class PositionInfoEventArgs : EventArgs
    {
        /// <summary>
        /// Parquets at the given position.
        /// </summary>
        /// <value>The parquets.</value>
        public ParquetStack Stack { get; }

        /// <summary>
        /// Status of parquets at the given position.
        /// </summary>
        /// <value>The parquets.</value>
        public ParquetStatus Status { get; }

        /// <summary>
        /// Triggered when the information about a specific map location is ready to be displayed.
        /// </summary>
        /// <param name="inStacks">Definition of any and all parquets at the location.</param>
        /// <param name="inStatuses">Status of any and all parquets at the location.</param>
        public PositionInfoEventArgs(ParquetStack inStacks, ParquetStatus inStatuses)
        {
            Stack = inStacks;
            Status = inStatuses;
        }
    }
}
