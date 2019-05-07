using System;
using System.Collections.Generic;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Map.SpecialPoints;

namespace ParquetClassLibrary.Map
{
    /// <summary>
    /// Indicates that the encapsulated info corresponding to a particular position in the current region map
    /// should be communicated to the player.
    /// </summary>
    public class PositionInfoEvent : EventArgs
    {
        /// <summary>
        /// Parquets at the given position.
        /// </summary>
        /// <value>The parquets.</value>
        public ParquetStack Parquets { get; }

        /// <summary>
        /// Special points at the given position.
        /// </summary>
        /// <value>The special points.</value>
        public List<SpecialPoint> SpecialPoints { get; }

        /// <summary>
        /// Triggered when the information about a specific map location is ready to be displayed.
        /// </summary>
        /// <param name="in_parquets">Any and all parquets at the location.</param>
        /// <param name="in_points">Any and all special points at the location.</param>
        public PositionInfoEvent(ParquetStack in_parquets, List<SpecialPoint> in_points)
        {
            Parquets = in_parquets;
            SpecialPoints = in_points;
        }
    }
}
