using System;
using System.Collections.Generic;
using System.Text;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Map
{
    /// <summary>
    /// Facilitates editing of <see cref="MapRegion"/> characteristics from design tools while maintaining a read-only face for use during play.
    /// </summary>
    interface IMapRegionEdit
    {
        /// <summary>What the region is called in-game.</summary>
        string Title { get; set; }

        /// <summary>A color to display in any empty areas of the region.</summary>
        PCLColor Background { get; set; }

        /// <summary>The region's elevation in absolute terms.</summary>
        Elevation ElevationLocal { get; set; }

        /// <summary>The region's elevation relative to all other regions.</summary>
        int ElevationGlobal { get; set; }
    }
}
