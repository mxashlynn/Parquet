using System;
using System.Collections.Generic;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Maps;

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
        /// Special points at the given position.
        /// </summary>
        /// <value>The special points.</value>
        public IReadOnlyList<ExitPoint> SpecialPoints { get; }

        /// <summary>
        /// Triggered when the information about a specific map location is ready to be displayed.
        /// </summary>
        /// <param name="inParquets">Any and all parquets at the location.</param>
        /// <param name="inPoints">Any and all special points at the location.</param>
        public PositionInfoEventArgs(ParquetStack inParquets, ParquetStatus inStatuses, List<ExitPoint> inPoints)
        {
            Stack = inParquets;
            Status = inStatuses;
            SpecialPoints = inPoints;
        }
    }
}
