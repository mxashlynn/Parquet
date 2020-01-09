using System.Collections.Generic;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Parquets;

namespace ParquetClassLibrary.Serialization.Shims
{
    /// <summary>
    /// Parent class for all shims of map definitions.
    /// </summary>
    public abstract class MapParentShim : EntityShim
    {
        /// <summary>Describes the version of serialized data.  Allows selecting data files that can be successfully deserialized.</summary>
        public string DataVersion;

        /// <summary>Tracks how many times the data structure has been serialized.</summary>
        public int Revision;

        /// <summary>Locations on the map at which a something happens that cannot be determined from parquets alone.</summary>
        public List<ExitPoint> ExitPoints;

        /// <summary>Floors and walkable terrain on the map.</summary>
        public ParquetStatusGrid ParquetStatuses;

        /// <summary>
        /// Definitions for every <see cref="FloorModel"/>, <see cref="BlockModel"/>, <see cref="FurnishingModel"/>,
        /// and <see cref="CollectibleModel"/> that makes up this part of the game world.
        /// </summary>
        public ParquetStackGrid ParquetDefintion;
    }
}
