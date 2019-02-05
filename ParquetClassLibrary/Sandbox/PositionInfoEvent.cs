using System;
using System.Collections.Generic;
using ParquetClassLibrary.Sandbox.Parquets;
using ParquetClassLibrary.Sandbox.SpecialPoints;

namespace ParquetClassLibrary.Sandbox
{
    /// <summary>Information corresponding to a particular position in the current region map.</summary>
    public class PositionInfoEvent : EventArgs
    {
        public ParquetStack Parquets { get; private set; }
        public List<SpecialPoint> SpecialPoints { get; private set; }

        public PositionInfoEvent(ParquetStack in_parquets, List<SpecialPoint> in_points)
        {
            Parquets = in_parquets;
            SpecialPoints = in_points;
        }
    }
}
